using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Dashboard_WPF.Views.Compras;
using static Dashboard_WPF.Views.Compras.VEmergente;

namespace Dashboard_WPF.Views.Compras
{
    /// <summary>
    /// Lógica de interacción para SubVCompras1.xaml
    /// </summary>
    public partial class SubVCompras1 : Page
    {
        private string connectionString = "Server= (LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true; TrustServerCertificate=True";
        public SubVCompras1()
        {
            InitializeComponent();
            CalcularTotal();
            CargarComboBox();
            
        }

        public void CargarComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Define your SQL query to retrieve supplier names
                string sqlQuery = "SELECT NombreCompañia FROM Proveedor";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the ComboBox
                        CmbProve.ItemsSource = dataTable.DefaultView;
                        CmbProve.DisplayMemberPath = "NombreCompañia";
                    }
                }
            }
        }

        public double CalcularTotal()
        {
            double total = 0, iva = 0, subtotal = 0;

            foreach (var item in TablaCompras.Items)
            {
                if (item is Productosgg data)
                {
                    total += data.SubTotal;
                }
            }


            iva = total * (18.0/100);
            subtotal = total - iva;

            txtSubtotal.Text = subtotal.ToString();
            txtIva.Text = iva.ToString();
            txtTotal.Text = total.ToString();

            return total;
        }

        private void btnVerificarProducto_Click(object sender, RoutedEventArgs e)
        {
            // Obtén el código de barras ingresado en el TextBox
            string codigoDeBarras = txtCodigoBarra.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Define la consulta SQL para verificar si el producto existe
                string query = "SELECT COUNT(*) FROM Producto WHERE CodigoBarra = @CodigoBarra";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CodigoBarra", codigoDeBarras);

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        txtCodigoBarra.Text = "";
                        VEmergente vEmergente = new VEmergente(codigoDeBarras, TablaCompras,this);
                        vEmergente.Show();
                    }
                    else
                    {
                        MessageBox.Show("Codigo de Barra no valido");
                    }
                }
            }


            
        }

      

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (TablaCompras.SelectedItem != null)
            {
                // Obtén el elemento seleccionado
                var item = (Productosgg)TablaCompras.SelectedItem;

                // Elimina el elemento de la lista enlazada a tu DataGrid
                TablaCompras.Items.Remove(item);

                // Llama a CalcularTotal para actualizar el total
                CalcularTotal();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CargarComboBox();
        }

        private void btnGuardarCompra_Click(object sender, RoutedEventArgs e)
        {
            if (dtpFecha.Text != "" && CmbProve.Text != "")
            {
                InsertarDetallesVenta();
                InsertarProductosCompra();
                ActualizarProductos();
                LimpiarTodo();
                
            }
            else
            {
                MessageBox.Show("Llene los campos obligatorios");
            }
        }

        private void ActualizarProductos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (Productosgg producto in TablaCompras.Items)
                {
                    // Accede a las propiedades del objeto Productosgg
                    string codigoBarra = producto.CodigoBarra;
                    int cantidadEnDataGrid = producto.Cantidad; // Obtén el valor del DataGrid

                    // Obtén el valor actual de StockExistencia desde la base de datos
                    int stockExistenciaActual = ObtenerStockExistenciaActual(connection, codigoBarra);

                    long precioCompra = (long)producto.PrecioCompra;
                    long precioVenta = (long)producto.PrecioVenta;
                    long precioMayoreo = (long)producto.PrecioMayoreo;


                    // Calcula el nuevo StockExistencia sumando la cantidad en el DataGrid al valor actual
                    int nuevoStockExistencia = stockExistenciaActual + cantidadEnDataGrid;

                   
                    // Actualiza los campos en la tabla Producto
                    string query = "UPDATE Producto " +
                                   "SET StockExistencia = @StockExistencia, PrecioCompra = @PrecioCompra, PrecioVenta = @PrecioVenta, PrecioMayoreo = @PrecioMayoreo " +
                                   "WHERE CodigoBarra = @CodigoBarra";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StockExistencia", nuevoStockExistencia);
                        command.Parameters.AddWithValue("@PrecioCompra", precioCompra);
                        command.Parameters.AddWithValue("@PrecioVenta", precioVenta);
                        command.Parameters.AddWithValue("@PrecioMayoreo", precioMayoreo);
                        command.Parameters.AddWithValue("@CodigoBarra", codigoBarra);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private int ObtenerStockExistenciaActual(SqlConnection connection, string codigoBarra)
        {
            // Función para obtener el valor actual de StockExistencia desde la base de datos
            string query = "SELECT StockExistencia FROM Producto WHERE CodigoBarra = @CodigoBarra";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CodigoBarra", codigoBarra);

                var result = command.ExecuteScalar();
                if (result != null)
                {
                    return (int)result;
                }

                return 0; // Devuelve 0 si no se encuentra el producto
            }
        }

        public void LimpiarTodo()
        {
            txtIva.Text = "";
            txtSubtotal.Text = "";
            txtTotal.Text = "";
            CmbProve.Text = "";
            dtpFecha.Text = "";
            TablaCompras.Items.Clear();
        }
        public void InsertarDetallesVenta()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Obtenemos los valores seleccionados
                DateTime fecha = dtpFecha.SelectedDate.Value;
                if (CmbProve.SelectedItem is DataRowView selectedRow)
                {
                    // Accede a los valores de las columnas específicas del DataRowView
                    string nombreCompañia = selectedRow["NombreCompañia"].ToString();

                    // Continúa con la lógica para obtener el NIT y realizar la inserción en DetallesCompra.
                    // Creamos una consulta SQL para obtener el NIT del proveedor basado en el nombre de la compañía
                    string nitQuery = "SELECT NIT FROM Proveedor WHERE NombreCompañia = @NombreCompañia";

                    using (SqlCommand nitCommand = new SqlCommand(nitQuery, connection))
                    {
                        nitCommand.Parameters.AddWithValue("@NombreCompañia", nombreCompañia);

                        object result = nitCommand.ExecuteScalar();

                        if (result != null)
                        {
                            long idProveedor = (long)result;

                            // Continúa con la inserción en DetallesCompra
                            Decimal total = Convert.ToDecimal(txtTotal.Text); // Ajusta el valor según tus necesidades

                            // Creamos la consulta SQL para insertar en DetallesCompra
                            string query = "INSERT INTO DetallesCompra (Fecha, idProveedor, Total) VALUES (@Fecha, @idProveedor, @Total)";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                // Asignamos los parámetros
                                command.Parameters.AddWithValue("@Fecha", fecha);
                                command.Parameters.AddWithValue("@idProveedor", idProveedor);
                                command.Parameters.AddWithValue("@Total", total);

                                // Ejecutamos la consulta
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Compra guardada exitosamente.");
                                }
                                else
                                {
                                    MessageBox.Show("Hubo un problema al guardar la compra.");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontró un proveedor con ese nombre de compañía.");
                        }
                    }
                }
            }
        }
        public void InsertarProductosCompra()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (Productosgg producto in TablaCompras.Items)
                {
                    // Accede a las propiedades del objeto Productosgg
                    string codigoBarra = producto.CodigoBarra;
                    long precioCompra = (long)producto.PrecioCompra;
                    long precioVenta = (long)producto.PrecioVenta;
                    long precioMayoreo = (long)producto.PrecioMayoreo;
                    int stockEntrada = producto.Cantidad; // Cantidad del objeto Productosgg

                    // Inserta un nuevo registro en la tabla ProductosCompra
                    string query = "INSERT INTO ProductosCompra (PrecioCompra, PrecioVenta, PrecioMayoreo, idProducto, idDetallesCompra, StockEntrada) " +
                                   "VALUES (@PrecioCompra, @PrecioVenta, @PrecioMayoreo, @idProducto, @idDetallesCompra, @StockEntrada)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PrecioCompra", precioCompra);
                        command.Parameters.AddWithValue("@PrecioVenta", precioVenta);
                        command.Parameters.AddWithValue("@PrecioMayoreo", precioMayoreo);
                        command.Parameters.AddWithValue("@idProducto", codigoBarra); // Utiliza el código de barras como idProducto
                        command.Parameters.AddWithValue("@idDetallesCompra", ObtenerUltimoIdDetallesCompra());
                        command.Parameters.AddWithValue("@StockEntrada", stockEntrada);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private int ObtenerUltimoIdDetallesCompra()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT TOP 1 idDetallesCompra FROM DetallesCompra ORDER BY idDetallesCompra DESC";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return (int)result;
                    }
                }

                return 0; // Devuelve 0 si no se encuentra ningún registro en DetallesCompra
            }
        }
    }
}

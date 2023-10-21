using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using Dashboard_WPF.Modelos;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using Dashboard_WPF.Views.Productos;

namespace Dashboard_WPF.Views.Ventas
{
    /// <summary>
    /// Interaction logic for SubVVentas1.xaml
    /// </summary>
    public partial class SubVVentas1 : Page
    {
        // Define una instancia de la clase de conexión
        private Conexion conexion = Conexion.getInstancia();
        private ObservableCollection<Productos> productos = new ObservableCollection<Productos>();
        public SubVVentas1()
        {
            InitializeComponent();
            ProdAgreg.ItemsSource = productos;


            // Suscríbete al evento CollectionChanged para detectar cambios en la colección de productos
            productos.CollectionChanged += Productos_CollectionChanged;
        }
        private void TotalPagado_TextChanged(object sender, TextChangedEventArgs e)
        {
            ActualizarCambioVenta();
        }

        private void ActualizarCambioVenta()
        {
            if (float.TryParse(TotalPagado.Text, out float totalPagado))
            {
                float totalVenta = float.Parse(TotalVenta.Text.Replace(" BOB", ""));
                float cambio = totalPagado - totalVenta;
                CambioVenta.Text = $"{cambio:N2} BOB";
            }
            else
            {
                CambioVenta.Text = "0.00 BOB";
            }
        }

        private void ActualizarSubTotalVenta()
        {
            float sumaSubtotales = productos.Sum(producto => producto.SubTotal);
            SubTotalVenta.Text = $"+ {sumaSubtotales:N2} BOB";
            TotalVenta.Text = $"{sumaSubtotales:N2} BOB";
            // Calcular descuento y actualizar DescuentoVentaTotal
            if (float.TryParse(DescuentoVenta.Text, out float descuento))
            {
                float descuentoTotal = (sumaSubtotales * descuento) / 100;
                DescuentoVentaTotal.Text = $"- {descuentoTotal:N2} BOB";

                // Calcular total y actualizar TotalVenta
                float totalVenta = sumaSubtotales - descuentoTotal;
                TotalVenta.Text = $"{totalVenta:N2} BOB";
            }
        }
        private void DescuentoVenta_TextChanged(object sender, TextChangedEventArgs e)
        {
            ActualizarSubTotalVenta();
        }
        private void Productos_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Calcula la suma de los subtotales y actualiza SubTotalVenta
            float sumaSubtotales = productos.Sum(producto => producto.SubTotal);
            SubTotalVenta.Text = $"+ {sumaSubtotales:N2} BOB"; // Formatea la suma con dos decimales
        }

        private void ProdAgreg_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var editedElement = e.EditingElement as FrameworkElement;
                if (editedElement != null)
                {
                    var dataGrid = sender as DataGrid;
                    if (dataGrid != null)
                    {
                        var editedItem = dataGrid.SelectedItem as Productos;
                        if (editedItem != null)
                        {
                            // Calcula el nuevo subtotal (precio * cantidad)
                            editedItem.SubTotal = editedItem.Cantidad * editedItem.Precio;
                            ActualizarSubTotalVenta(); // Actualiza SubTotalVenta
                        }
                    }
                }
            }
        }








        public class Productos : INotifyPropertyChanged
        {

            public int Numero { get; set; }
            public string CodigoBarra { get; set; }
            public string Producto { get; set; }

            private int cantidad;
            public int Cantidad
            {
                get { return cantidad; }
                set
                {
                    if (cantidad != value)
                    {
                        cantidad = value;
                        RaisePropertyChanged("Cantidad");
                        SubTotal = cantidad * Precio; // Actualiza el subtotal cuando cambia la cantidad
                    }
                }
            }

            public float Precio { get; set; }

            private float subTotal;
            public float SubTotal
            {
                get { return subTotal; }
                set
                {
                    if (subTotal != value)
                    {
                        subTotal = value;
                        RaisePropertyChanged("SubTotal");
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void RaisePropertyChanged(string property)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
            }



        }
        private void ActualizarNumeracion()
        {
            for (int i = 0; i < productos.Count; i++)
            {
                productos[i].Numero = i + 1;
            }
            ProdAgreg.Items.Refresh(); // Esto actualiza la vista
        }

        private void EliminarFila_Click(object sender, RoutedEventArgs e)
        {
            // Obtiene el botón que desencadenó el evento
            Button btnEliminar = (Button)sender;

            // Obtiene la fila de datos asociada al botón
            if (btnEliminar.DataContext is Productos producto)
            {
                // Remueve la fila de la colección
                productos.Remove(producto);

                // Actualiza la numeración de todas las filas restantes y refresca la vista
                ActualizarNumeracion();
            }
        }





        private void BtnAgregarProd_Click(object sender, RoutedEventArgs e)
        {
            // Obtén el código de barras ingresado
            string codigoBarras = TbCodigoBarras.Text;

            // Validación básica
            if (string.IsNullOrWhiteSpace(codigoBarras))
            {
                MessageBox.Show("Ingrese un código de barras válido.");
                return;
            }

            try
            {
                // Verifica si ya existe un producto con el mismo código de barras
                var productoExistente = productos.FirstOrDefault(p => p.CodigoBarra == codigoBarras);

                if (productoExistente != null)
                {
                    // Si ya existe, simplemente incrementa la cantidad y actualiza el subtotal
                    productoExistente.Cantidad++;
                    productoExistente.SubTotal = productoExistente.Cantidad * productoExistente.Precio;
                }
                else
                {
                    // Si no existe, agrega un nuevo producto
                    // Conecta a la base de datos para obtener los datos del producto
                    using (SqlConnection conexion = Conexion.getInstancia().CrearConexion())
                    {
                        // Abre la conexión
                        conexion.Open();

                        // Crea el comando SQL para obtener los datos del producto
                        string consulta = "SELECT * FROM Producto WHERE CodigoBarra = @CodigoBarra";
                        SqlCommand comando = new SqlCommand(consulta, conexion);
                        comando.Parameters.AddWithValue("@CodigoBarra", codigoBarras);

                        // Ejecuta la consulta y obtén el resultado
                        SqlDataReader reader = comando.ExecuteReader();
                        if (reader.Read())
                        {
                            // Crea un objeto que representa la fila que deseas agregar
                            var nuevaFila = new Productos
                            {
                                Numero = productos.Count + 1, // Incrementa el número de acuerdo a las filas existentes
                                CodigoBarra = reader["CodigoBarra"].ToString(),
                                Producto = reader["Nombre"].ToString(),
                                Cantidad = 1,
                                Precio = float.Parse(reader["PrecioVenta"].ToString()),
                                SubTotal = float.Parse(reader["PrecioVenta"].ToString())
                            };

                            // Agrega la nueva fila a la colección
                            productos.Add(nuevaFila);
                        }
                        else
                        {
                            MessageBox.Show("No se encontró un producto con el código de barras ingresado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al acceder a la base de datos: " + ex.Message);
            }
            ActualizarSubTotalVenta();
        }

        private string GenerarIDDetallesVentaUnico()
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            string idDetallesVenta = null;

            using (SqlConnection conexion = Conexion.getInstancia().CrearConexion())
            {
                conexion.Open();

                while (true)
                {
                    char[] idDetallesVentaArray = new char[15];

                    for (int i = 0; i < 15; i++)
                    {
                        idDetallesVentaArray[i] = caracteres[random.Next(caracteres.Length)];
                    }

                    idDetallesVenta = new string(idDetallesVentaArray);

                    // Verifica si el ID generado ya existe en la base de datos
                    string consulta = "SELECT COUNT(*) FROM DetallesVenta WHERE idDetallesVenta = @IdDetallesVenta";
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@IdDetallesVenta", idDetallesVenta);

                    int count = (int)comando.ExecuteScalar();

                    if (count == 0)
                    {
                        // El ID generado no existe en la base de datos, es único
                        break;
                    }
                    // Si el ID ya existe, se generará uno nuevo en el próximo ciclo del bucle
                }
            }

            return idDetallesVenta;
        }



        private void GuardarVenta_Click(object sender, RoutedEventArgs e)
        {
            // Genera un nuevo IDDetallesVenta
            string idDetallesVenta = GenerarIDDetallesVentaUnico();

            // Obtén los datos para la inserción
            DateTime fecha = FechaVenta.SelectedDate ?? DateTime.Now;
            fecha = fecha.Add(DateTime.Now.TimeOfDay); // Agregar la hora actual

            long idCliente = Convert.ToInt64(CiCliente.Text);
            decimal totalPagado = decimal.Parse(TotalPagado.Text);

            // Limpia y parsea el valor del cambio
            string cambioText = CambioVenta.Text.Replace(" BOB", "").Replace("+", "");
            //cambioText = cambioText.Replace(".", ",");
            //MessageBox.Show(cambioText);

            decimal cambio = decimal.Parse(cambioText);

            // Limpia y parsea el valor del total
            string totalText = TotalVenta.Text.Replace(" BOB", "").Replace("+", "");
            //totalText = totalText.Replace(".", ",");

            decimal total = decimal.Parse(totalText);

            // Limpia y parsea el valor del descuento
            string descuentoText = DescuentoVentaTotal.Text.Replace(" BOB", "").Replace("-", "");
            //descuentoText = descuentoText.Replace(".", ",");

            decimal descuento = decimal.Parse(descuentoText);



            // Verifica si el IDDetallesVenta ya existe
            bool idDetallesVentaExiste = false;
            using (SqlConnection conexion = Conexion.getInstancia().CrearConexion())
            {
                conexion.Open();

                string consulta = "SELECT COUNT(*) FROM DetallesVenta WHERE idDetallesVenta = @IdDetallesVenta";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@IdDetallesVenta", idDetallesVenta);

                int count = (int)comando.ExecuteScalar();
                idDetallesVentaExiste = count > 0;
            }

            if (!idDetallesVentaExiste)
            {
                // Inserta los datos en la tabla DetallesVenta
                using (SqlConnection conexion = Conexion.getInstancia().CrearConexion())
                {
                    conexion.Open();

                    string consulta = "INSERT INTO DetallesVenta (idDetallesVenta, Fecha, idCliente, TotalPagado, Total, Cambio, Descuento) " +
                                      "VALUES (@IdDetallesVenta, @Fecha, @IdCliente, @TotalPagado, @Total, @Cambio, @Descuento)";

                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@IdDetallesVenta", idDetallesVenta);
                    comando.Parameters.AddWithValue("@Fecha", fecha);
                    comando.Parameters.AddWithValue("@IdCliente", idCliente);
                    comando.Parameters.AddWithValue("@TotalPagado", totalPagado);
                    comando.Parameters.AddWithValue("@Total", total);
                    comando.Parameters.AddWithValue("@Cambio", cambio);
                    comando.Parameters.AddWithValue("@Descuento", descuento);

                    comando.ExecuteNonQuery();
                    MessageBox.Show("Venta guardada exitosamente.");
                }
            }
            else
            {
                MessageBox.Show("Ya existe una venta con el mismo IDDetallesVenta.");
            }





            List<string> codigosYCantidades = new List<string>();

            // Iterar a través de los productos en ProdAgreg
            foreach (Productos producto in ProdAgreg.Items)
            {
                string codigoBarras = producto.CodigoBarra;
                int cantidad = producto.Cantidad;

                long precioCompra = 0;
                long precioVenta = 0;
                long precioMayoreo = 0;
                int stockExistencia = 0;

                // Realizar una consulta para obtener los datos de Producto
                using (SqlConnection conexion = Conexion.getInstancia().CrearConexion())
                {
                    conexion.Open();

                    string consultaProducto = "SELECT PrecioCompra, PrecioVenta, PrecioMayoreo, StockExistencia FROM Producto WHERE CodigoBarra = @CodigoBarra";
                    SqlCommand comandoProducto = new SqlCommand(consultaProducto, conexion);
                    comandoProducto.Parameters.AddWithValue("@CodigoBarra", codigoBarras);

                    using (SqlDataReader reader = comandoProducto.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            precioCompra = reader.GetInt64(reader.GetOrdinal("PrecioCompra"));
                            precioVenta = reader.GetInt64(reader.GetOrdinal("PrecioVenta"));
                            precioMayoreo = reader.GetInt64(reader.GetOrdinal("PrecioMayoreo"));
                            stockExistencia = reader.GetInt32(reader.GetOrdinal("StockExistencia"));
                        }

                        // Importante: Cerrar el DataReader
                        reader.Close();
                    }

                    // Insertar en ProductosVenta
                    using (SqlConnection conexionVenta = Conexion.getInstancia().CrearConexion())
                    {
                        conexionVenta.Open();

                        // Consulta de inserción en ProductosVenta con idProducto
                        string consultaVenta = "INSERT INTO ProductosVenta (idDetallesVenta, idProducto, PrecioCompra, PrecioVenta, PrecioMayoreo, StockSalida) " +
                            "VALUES (@IdDetallesVenta, @IdProducto, @PrecioCompra, @PrecioVenta, @PrecioMayoreo, @StockSalida)";

                        SqlCommand comandoVenta = new SqlCommand(consultaVenta, conexionVenta);
                        comandoVenta.Parameters.AddWithValue("@IdDetallesVenta", idDetallesVenta);
                        comandoVenta.Parameters.AddWithValue("@IdProducto", codigoBarras); // Agregar idProducto
                        comandoVenta.Parameters.AddWithValue("@PrecioCompra", precioCompra);
                        comandoVenta.Parameters.AddWithValue("@PrecioVenta", precioVenta);
                        comandoVenta.Parameters.AddWithValue("@PrecioMayoreo", precioMayoreo);
                        comandoVenta.Parameters.AddWithValue("@StockSalida", cantidad);

                        comandoVenta.ExecuteNonQuery();
                    }

                    // Actualizar StockExistencia en Producto
                    stockExistencia -= cantidad;

                    string consultaActualizarStock = "UPDATE Producto SET StockExistencia = @StockExistencia WHERE CodigoBarra = @CodigoBarra";
                    SqlCommand comandoActualizarStock = new SqlCommand(consultaActualizarStock, conexion);
                    comandoActualizarStock.Parameters.AddWithValue("@StockExistencia", stockExistencia);
                    comandoActualizarStock.Parameters.AddWithValue("@CodigoBarra", codigoBarras);
                    comandoActualizarStock.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Venta guardada exitosamente.");

        }

    }
}

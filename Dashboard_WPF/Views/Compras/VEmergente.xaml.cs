using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Dashboard_WPF.Views.Compras
{
    /// <summary>
    /// Lógica de interacción para VEmergente.xaml
    /// </summary>
    public partial class VEmergente : Window
    {
        string codbarras,nombreProducto;
        DataGrid Tablaprin;
        private string connectionString = "Server= (LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true; TrustServerCertificate=True";
        private SubVCompras1 subVCompras1;

        public VEmergente(string CodigoBarras ,DataGrid tablaprin, SubVCompras1 subVCompras1)
        {
            InitializeComponent();
            codbarras = CodigoBarras;
            Tablaprin = tablaprin;
            this.subVCompras1 = subVCompras1;

        }


        public class Productosgg
        {
            public string CodigoBarra { get; set; }
            public string Producto { get; set; }
            public int Cantidad { get; set; }
            public double PrecioCompra { get; set; }
            public double PrecioVenta { get; set; }
            public double PrecioMayoreo { get; set; }
            public double SubTotal { get; set; }
        }


        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnCerrar2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnVerificarProducto_Click(object sender, RoutedEventArgs e)
        {
            string stock, precioCompra, precioVenta, precioMayoreo;
            double Subtotal;
            stock = txtStock.Text;
            precioCompra = txtPrecioCompra.Text;
            precioVenta = txtPrecioVenta.Text;
            precioMayoreo = txtPrecioMayoreo.Text;

            // Realiza validaciones y obtén los valores de stock, precioCompra, precioVenta, precioMayoreo desde tus controles de entrada

            if (!string.IsNullOrEmpty(stock) && !string.IsNullOrEmpty(precioCompra) && !string.IsNullOrEmpty(precioVenta) && !string.IsNullOrEmpty(precioMayoreo))
            {
                Subtotal = Convert.ToInt32(stock) * Convert.ToInt32(precioCompra);
                Productosgg nuevoProducto = new Productosgg
                {
                    CodigoBarra = codbarras,
                    Producto = nombreProducto,
                    Cantidad = Convert.ToInt32(stock),
                    PrecioCompra = Convert.ToDouble(precioCompra),
                    PrecioVenta = Convert.ToDouble(precioVenta),
                    PrecioMayoreo = Convert.ToDouble(precioMayoreo),
                    SubTotal = Convert.ToInt32(stock) * Convert.ToDouble(precioCompra)
                };

                // Agrega el nuevo producto a la fuente de datos del DataGrid
                Tablaprin.Items.Add(nuevoProducto);

                subVCompras1.CalcularTotal();

                // Cierra la ventana emergente
                Close();
            }
            else
            {
                MessageBox.Show("Llene los campos obligatorios");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtCodigoBarras.Text = codbarras;
            string query = "SELECT Nombre FROM Producto WHERE CodigoBarra = @CodigoBarra";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CodigoBarra", codbarras);
                    var result = command.ExecuteScalar();

                    if (result != null)
                    {
                        nombreProducto = result.ToString();
                        // Asigna el nombre del producto al TextBox u otro control en tu ventana
                        txtNombres.Text = nombreProducto;
                    }
                    
                }
            }


        }
    }
}

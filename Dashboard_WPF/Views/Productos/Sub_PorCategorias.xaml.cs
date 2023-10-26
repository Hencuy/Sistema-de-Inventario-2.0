using Dashboard_WPF.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Dashboard_WPF.Views.Productos
{
    /// <summary>
    /// Lógica de interacción para Sub_PorCategorias.xaml
    /// </summary>
    public partial class Sub_PorCategorias : Page
    {
        public class Producto
        {
            public long CodigoBarra { get; set; }
            public string Nombre { get; set; }
            public string Presentacion { get; set; }
            public string Marca { get; set; }
            public string Modelo { get; set; }
            public int StockExistencia { get; set; }
            public int StockMinimo { get; set; }
            public long PrecioCompra { get; set; }
            public long PrecioVenta { get; set; }
            public long PrecioMayoreo { get; set; }
            public long Descuento { get; set; }
            public bool TieneVencimiento { get; set; }
            public DateTime? FechaVencimiento { get; set; }
            public int Estado { get; set; }
            public byte[] Foto { get; set; }
            public long idProveedor { get; set; }
            public int idCategoria { get; set; }
        }


        SqlConnection conexion = new SqlConnection("Server= (LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true; TrustServerCertificate=True");
        public Sub_PorCategorias()
        {
            InitializeComponent();

        }

        private void ComboboxCategorias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboboxCategorias.SelectedItem != null)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)ComboboxCategorias.SelectedItem;
                int categoryId = (int)selectedItem.Tag;
                
                LoadProductsByCategory(categoryId);
            }
        }


        private void LoadProductsByCategory(int categoryId)
        {
            Categorias.ItemsSource = null;
            try
            {
                using (SqlConnection connection = new SqlConnection("Server= (LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true; TrustServerCertificate=True"))
                {
                    connection.Open();

                    string consulta = "SELECT * FROM Producto WHERE idCategoria = @CategoryId";
                    SqlCommand command = new SqlCommand(consulta, connection);
                    command.Parameters.AddWithValue("@CategoryId", categoryId);
                    SqlDataReader reader = command.ExecuteReader();

                    List<Producto> productos = new List<Producto>();

                    while (reader.Read())
                    {
                        Producto producto = new Producto
                        {
                            CodigoBarra = (long)reader["CodigoBarra"],
                            Nombre = reader["Nombre"].ToString(),
                            Presentacion = reader["Presentacion"].ToString(),
                            Marca = reader["Marca"].ToString(),
                            Modelo = reader["Modelo"].ToString(),
                            StockExistencia = (int)reader["StockExistencia"],
                            StockMinimo = (int)reader["StockMinimo"],
                            PrecioCompra = (long)reader["PrecioCompra"],
                            PrecioVenta = (long)reader["PrecioVenta"],
                            PrecioMayoreo = (long)reader["PrecioMayoreo"],
                            Descuento = (long)reader["Descuento"],
                            TieneVencimiento = (bool)reader["TieneVencimiento"],
                            FechaVencimiento = reader["FechaVencimiento"] as DateTime?,
                            Estado = (int)reader["Estado"],
                            Foto = reader["Foto"] as byte[],
                            idProveedor = (long)reader["idProveedor"],
                            idCategoria = (int)reader["idCategoria"]
                        };
                        productos.Add(producto);
                    }

                    reader.Close();

                    Categorias.ItemsSource = productos;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :c: " + ex.Message);
            }
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                conexion.Open();

                string consulta = "SELECT idCategoria, Nombre FROM Categoria";
                SqlCommand command = new SqlCommand(consulta, conexion);
                SqlDataReader reader = command.ExecuteReader();

                ComboboxCategorias.Items.Clear();

                while (reader.Read())
                {
                    int idCategoria = reader.GetInt32(0);
                    string nombreCategoria = reader.GetString(1);
                    ComboboxCategorias.Items.Add(new ComboBoxItem { Content = nombreCategoria, Tag = idCategoria });
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las categorías: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            LoadProductsByCategory(1);
        }
    }
}

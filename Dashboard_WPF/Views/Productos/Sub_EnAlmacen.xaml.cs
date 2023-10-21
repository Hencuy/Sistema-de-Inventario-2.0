using Dashboard_WPF.Modelos;
using Dashboard_WPF.Views.Proveedores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
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

    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value is byte[] bytes && bytes.Length > 0)
                {
                    var imageStream = new MemoryStream(bytes);
                    var bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = imageStream;
                    bitmapImage.EndInit();
                    return bitmapImage;
                }
            }
            catch (Exception ex)
            {
                
            }

            var genericImage = new BitmapImage(new Uri("/Views/Productos/Imagenes/default.png", UriKind.Relative));
            return genericImage;
        }




        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public partial class Sub_EnAlmacen : Page
    {
        private List<Producto> productos = new List<Producto>();
        SqlConnection conexion = new SqlConnection("Server= (LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true; TrustServerCertificate=True");
        public Sub_EnAlmacen()
        {
            InitializeComponent();
            CargarDatos();
            EnAlmacen.ItemsSource = productos;
        }

        private void CargarDatos()
        {
            // Asegúrate de tener una lista de productos llamada "productos" declarada en el ámbito más amplio de tu aplicación.
            conexion.Open();
            string consulta = "SELECT * FROM Producto WHERE StockExistencia > 0";
            using (SqlCommand command = new SqlCommand(consulta, conexion))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
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
                }
            }
        }
    }
}

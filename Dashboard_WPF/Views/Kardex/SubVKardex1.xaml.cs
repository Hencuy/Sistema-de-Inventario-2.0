using Dashboard_WPF.Views.Compras;
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

namespace Dashboard_WPF.Views.Kardex
{
    /// <summary>
    /// Interaction logic for SubVKardex1.xaml
    /// </summary>
    public partial class SubVKardex1 : Page
    {
        Frame Main;
        private string connectionString = "Server= (LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true; TrustServerCertificate=True";
        public SubVKardex1(Frame main)
        {
            InitializeComponent();
            Main = main;    
        }
        public class KardexItem
        {
            public int Number { get; set; }
            public long CodigoBarraProducto { get; set; }
            public int Anio { get; set; }
            public int Mes { get; set; }
            public string Producto { get; set; }
            public int Entrada { get; set; }
            public string TotalCompras { get; set; }
            public int Salida { get; set; }
            public string TotalVentas { get; set; }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<KardexItem> kardexItems = new List<KardexItem>();

            string yourQuery = "-- Kardex de Compras y Ventas por Mes para un Producto (Solo productos con entrada o salida)\r\nSELECT\r\n    P.CodigoBarra AS CodigoBarraProducto,\r\n    YEAR(Mes) AS Anio,\r\n    MONTH(Mes) AS Mes,\r\n    P.Nombre AS Producto,\r\n    SUM(CASE WHEN Tipo = 'Compra' THEN Cantidad ELSE 0 END) AS Entrada,\r\n    SUM(CASE WHEN Tipo = 'Compra' THEN Total ELSE 0 END) AS TotalCompras,\r\n    SUM(CASE WHEN Tipo = 'Venta' THEN Cantidad ELSE 0 END) AS Salida,\r\n    SUM(CASE WHEN Tipo = 'Venta' THEN Total ELSE 0 END) AS TotalVentas\r\nFROM Producto AS P\r\nLEFT JOIN (\r\n    SELECT PC.idProducto, DC.Fecha AS Mes, 'Compra' AS Tipo, PC.StockEntrada AS Cantidad, PC.PrecioCompra * PC.StockEntrada AS Total\r\n    FROM ProductosCompra AS PC\r\n    JOIN DetallesCompra AS DC ON PC.idDetallesCompra = DC.idDetallesCompra\r\n    UNION ALL\r\n    SELECT PV.idProducto, DV.Fecha AS Mes, 'Venta' AS Tipo, PV.StockSalida AS Cantidad, PV.PrecioVenta * PV.StockSalida AS Total\r\n    FROM ProductosVenta AS PV\r\n    JOIN DetallesVenta AS DV ON PV.idDetallesVenta = DV.idDetallesVenta\r\n) AS Movimientos ON P.CodigoBarra = Movimientos.idProducto\r\nGROUP BY P.CodigoBarra, YEAR(Mes), MONTH(Mes), P.Nombre\r\nHAVING SUM(CASE WHEN Tipo = 'Compra' THEN Cantidad ELSE 0 END) > 0 OR SUM(CASE WHEN Tipo = 'Venta' THEN Cantidad ELSE 0 END) > 0\r\nORDER BY CodigoBarraProducto, Anio, Mes;"; // Reemplaza con tu consulta SQL

            int number = 1; // Inicializa el contador

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(yourQuery, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        KardexItem item = new KardexItem
                        {
                            Number = number,
                            CodigoBarraProducto = Convert.ToInt64(reader["CodigoBarraProducto"]),
                            Anio = Convert.ToInt32(reader["Anio"]),
                            Mes = Convert.ToInt32(reader["Mes"]),
                            Producto = reader["Producto"].ToString(),
                            Entrada = Convert.ToInt32(reader["Entrada"]),
                            TotalCompras = reader["TotalCompras"].ToString()+" $",
                            Salida = Convert.ToInt32(reader["Salida"]),
                            TotalVentas = reader["TotalVentas"].ToString() + " $"
                        };
                        kardexItems.Add(item);
                        number++; // Incrementa el contador
                    }
                }
            }

            Tablakardex.ItemsSource = kardexItems;
        }

        
        

        private void btnDetalles_Click_1(object sender, RoutedEventArgs e)
        {
            string codigo, mes,año,nombre;

            // Obtén el botón que se hizo clic
            Button button = (Button)sender;

            // Obtén el objeto KardexItem correspondiente a la fila
            KardexItem selectedItem = (KardexItem)Tablakardex.SelectedItem;

            if (selectedItem != null)
            {
                nombre = selectedItem.Producto.ToString();
                codigo = selectedItem.CodigoBarraProducto.ToString();
                mes = selectedItem.Mes.ToString();
                año = selectedItem.Anio.ToString();

                Main.NavigationService.Navigate(new DetallesKardex(Main, codigo, mes, año,nombre));

            }
        }
        
    }
}

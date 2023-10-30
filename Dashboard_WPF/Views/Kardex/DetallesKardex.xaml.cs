using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para DetallesKardex.xaml
    /// </summary>
    public partial class DetallesKardex : Page
    {
        Frame Main;
        string Codigo, Mes,Año,Nombre;
        private string connectionString = "Server= (LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true; TrustServerCertificate=True";

        public DetallesKardex(Frame main,string codigo,string mes, string año,string nombre)
        {
            InitializeComponent();
            Main = main;
            Codigo = codigo;
            Mes = mes;
            Año = año;
            Nombre = nombre;
            txbTitulo.Text = "Detalles Kardes " + Nombre + " " + Mes + "/" + Año;
        }

        public class DetallesKardexItem
        {
            public int Number { get; set; }
            public string Fecha { get; set; }
            public string Tipo { get; set; }
            public int Unidades { get; set; }
            public string Precio { get; set; }
            public string Total { get; set; }
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatosTabla();
        }

        public void CargarDatosTabla()
        {
            List<DetallesKardexItem> detallesKardexItems = new List<DetallesKardexItem>();

            // Consulta SQL parametrizada
            string query = @"
                SELECT 'Entrada' AS Tipo, DC.Fecha AS Fecha, PC.StockEntrada AS Unidades, 
                       PC.PrecioCompra AS Precio, PC.StockEntrada * PC.PrecioCompra AS Total
                FROM Producto AS P
                JOIN ProductosCompra AS PC ON P.CodigoBarra = PC.idProducto
                JOIN DetallesCompra AS DC ON PC.idDetallesCompra = DC.idDetallesCompra
                WHERE P.CodigoBarra = @Codigo AND YEAR(DC.Fecha) = @Año AND MONTH(DC.Fecha) = @Mes

                UNION ALL

                SELECT 'Salida' AS Tipo, DV.Fecha AS Fecha, PV.StockSalida AS Unidades, 
                       PV.PrecioVenta AS Precio, PV.StockSalida * PV.PrecioVenta AS Total
                FROM Producto AS P
                JOIN ProductosVenta AS PV ON P.CodigoBarra = PV.idProducto
                JOIN DetallesVenta AS DV ON PV.idDetallesVenta = DV.idDetallesVenta
                WHERE P.CodigoBarra = @Codigo AND YEAR(DV.Fecha) = @Año AND MONTH(DV.Fecha) = @Mes
                ORDER BY Fecha, Tipo;
            ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Codigo", Codigo);
                    command.Parameters.AddWithValue("@Mes", Mes);
                    command.Parameters.AddWithValue("@Año", Año);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int number = 1; // Inicializa el contador

                        while (reader.Read())
                        {
                            DetallesKardexItem item = new DetallesKardexItem
                            {
                                Number = number,
                                Fecha = reader["Fecha"].ToString(),
                                Tipo = reader["Tipo"].ToString(),
                                Unidades = Convert.ToInt32(reader["Unidades"]),
                                Precio = reader["Precio"].ToString() +" $",
                                Total = reader["Total"].ToString() + " $"
                            };

                            detallesKardexItems.Add(item);
                            number++; // Incrementa el contador
                        }
                    }
                }
            }

            // Enlaza la lista de objetos al DataGrid
            TablaDetallesKardex.ItemsSource = detallesKardexItems;
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Main.NavigationService.Navigate(new SubVKardex1(Main));
        }
    }
}

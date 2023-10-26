using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace Dashboard_WPF.Views.Compras
{
    /// <summary>
    /// Lógica de interacción para VDetalles.xaml
    /// </summary>
    public partial class VDetalles : Page
    {
        Frame Main;
        string idDetallesCompra;
        SqlConnection conexion = new SqlConnection("Server= (LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true; TrustServerCertificate=True");

        public VDetalles(Frame main, string id)
        {
            InitializeComponent();
            Main = main;
            idDetallesCompra = id;
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Main.NavigationService.Navigate(new SubVCompras2(Main));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatos();
        }
        private void CargarDatos()
        {
            using (SqlConnection connection = new SqlConnection("Server= (LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true; TrustServerCertificate=True"))
            {
                connection.Open();

                string query = "SELECT PC.idProductosCompra, " +
                               "P.Nombre, " +
                               "PC.StockEntrada, " +
                               "PC.PrecioCompra, " +
                               "PC.StockEntrada * PC.PrecioCompra AS Total " +
                               "FROM ProductosCompra PC " +
                               "INNER JOIN Producto P ON PC.idProducto = P.CodigoBarra " +
                               "WHERE PC.idDetallesCompra = @IdDetallesCompra"; // Filtrar por idDetallesCompra

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@IdDetallesCompra", idDetallesCompra); // Parámetro para idDetallesCompra
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Agrega una columna "Number" para mostrar un número de fila
                dataTable.Columns.Add("Number", typeof(int));
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    dataTable.Rows[i]["Number"] = i + 1;
                }

                TablaDetallesCompra.ItemsSource = dataTable.DefaultView;
            }
        }
    }
}

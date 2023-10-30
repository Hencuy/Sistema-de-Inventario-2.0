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
using Dashboard_WPF.Views.Proveedores;

namespace Dashboard_WPF.Views.Compras
{
    /// <summary>
    /// Lógica de interacción para SubVCompras2.xaml
    /// </summary>
    public partial class SubVCompras2 : Page
    {
        Frame Main;
        private string connectionString = "Server= (LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true; TrustServerCertificate=True";
        public SubVCompras2(Frame main)
        {
            InitializeComponent();
            CargarDatos();
            Main = main;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatos();
        }
        private void CargarDatos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT DC.idDetallesCompra, DC.Fecha, DC.Total, P.NombreCompañia " +
                               "FROM DetallesCompra DC " +
                               "INNER JOIN Proveedor P ON DC.idProveedor = P.NIT";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                TablaDetallesCompra.ItemsSource = dataTable.DefaultView;
            }
        }

        private void TablaDetallesCompra_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }

        private void btnDetalles_Click(object sender, RoutedEventArgs e)
        {
            string id;

            // Obtén el botón que se hizo clic
            Button button = (Button)sender;

            // Obtén la fila que contiene el botón
            DataGridRow dataGridRow = FindParent<DataGridRow>(button);

            // Verifica si la fila no es nula
            if (dataGridRow != null)
            {
                // Obtén el objeto de datos de la fila seleccionada
                DataRowView rowView = (DataRowView)dataGridRow.Item;

                // Accede al valor del campo "CODIGO HOJA DE RUTA" (ID_Tramites)
                id = rowView["idDetallesCompra"].ToString();
               
                Main.NavigationService.Navigate(new VDetalles(Main,id));
            }
        }
        private T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parent = VisualTreeHelper.GetParent(child);

            while (parent != null && !(parent is T))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            return parent as T;
        }
    }
}

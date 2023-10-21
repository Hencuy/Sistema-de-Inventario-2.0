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
using System.Collections.ObjectModel;

namespace Dashboard_WPF.Views.Clientes
{
    /// <summary>
    /// Interaction logic for SubVClientes2.xaml
    /// </summary>
    public partial class SubVClientes2 : Page
    {
        SubVClientes4 subVClientes4 = new SubVClientes4();
        public Frame FrameClientes;
        private string connectionString = "Server=(LocalDB)\\MSSQLLocalDB; Database=BDInventarioVenta; Integrated Security=true; TrustServerCertificate=true";

        public SubVClientes2()
        {
            InitializeComponent();
            //FrameClientes.NavigationService.Navigate(subVClientes4);

            Loaded += SubVClientes2_Load;
        }

        private void SubVClientes2_Load(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT CI, Nombres, Apellidos FROM Cliente";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridClientes.ItemsSource = dataTable.DefaultView;
                }
            }
        }

        private void ActualizarButton_Click(object sender, RoutedEventArgs e)
        {
            // Obtén la fila seleccionada desde el DataGrid
            DataRowView selectedRow = (DataRowView)dataGridClientes.SelectedItem;

            if (selectedRow != null)
            {
                // Accede a los valores de las columnas de la fila seleccionada
                string ci = selectedRow["CI"].ToString();
                string nombres = selectedRow["Nombres"].ToString();
                string apellidos = selectedRow["Apellidos"].ToString();

                // Asigna los valores a los TextBox en la página subVClientes4
                subVClientes4.txtidCliente.Text = ci;
                subVClientes4.txtNombreCliente.Text = nombres;
                subVClientes4.txtApellidosCliente.Text = apellidos;

                // Navega a la página subVClientes4
                FrameClientes.NavigationService.Navigate(subVClientes4);
            }
        }



        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridClientes.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente de la lista para eliminar.");
                return;
            }

            DataRowView selectedRow = (DataRowView)dataGridClientes.SelectedItem;
            string ciCliente = selectedRow["CI"].ToString(); // Suponemos que "CI" es el nombre de la columna CI en el DataGrid

            string connectionString = "Server=(LocalDB)\\MSSQLLocalDB; database=BDInventarioVenta; integrated security=true; TrustServerCertificate=true";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string cadena = "DELETE FROM Cliente WHERE CI = @CI";
                SqlCommand comando = new SqlCommand(cadena, conexion);

                // Agregar el parámetro para evitar la inyección SQL
                comando.Parameters.AddWithValue("@CI", ciCliente);

                int rowsAffected = comando.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Los datos del cliente se eliminaron correctamente.");

                    // Actualiza la lista de clientes en el DataGrid
                    using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT CI, Nombres, Apellidos FROM Cliente", conexion))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridClientes.ItemsSource = dataTable.DefaultView;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró ningún cliente con el número de cédula seleccionado.");
                }
            }
        }

    }
}

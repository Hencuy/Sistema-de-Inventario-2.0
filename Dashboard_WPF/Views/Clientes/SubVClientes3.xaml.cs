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

namespace Dashboard_WPF.Views.Clientes
{
    /// <summary>
    /// Interaction logic for SubVClientes3.xaml
    /// </summary>
    public partial class SubVClientes3 : Page
    {
        SubVClientes4 subVClientes4 = new SubVClientes4();
        public Frame FrameClientes;
        public SubVClientes3()
        {
            InitializeComponent();
        }
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            RealizarBusqueda();
        }

        private void txtClienteBus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RealizarBusqueda();
            }
        }

        private void RealizarBusqueda()
        {
            string searchTerm = txtClienteBus.Text.Trim();
            string connectionString = "Server=(LocalDB)\\MSSQLLocalDB; database=BDInventarioVenta; integrated security=true; TrustServerCertificate=true";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string consulta = "SELECT CI, Nombres, Apellidos FROM Cliente WHERE Nombres LIKE @searchTerm OR CI = TRY_CAST(@searchTerm AS bigint)";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(dataTable);

                dataGridClientesBusqueda.ItemsSource = dataTable.DefaultView;

                dataGridClientesBusqueda.Visibility = dataTable.Rows.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void btnActualizarClientes_Click(object sender, RoutedEventArgs e)
        {
            // Obtén la fila seleccionada desde el DataGrid
            DataRowView selectedRow = (DataRowView)dataGridClientesBusqueda.SelectedItem;

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
            if (dataGridClientesBusqueda.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente de la lista para eliminar.");
                return;
            }

            DataRowView selectedRow = (DataRowView)dataGridClientesBusqueda.SelectedItem;
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
                        dataGridClientesBusqueda.ItemsSource = dataTable.DefaultView;
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

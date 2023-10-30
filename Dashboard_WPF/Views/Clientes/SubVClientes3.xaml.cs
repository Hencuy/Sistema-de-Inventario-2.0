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
        //SubVClientes4 subVClientes4 = new SubVClientes4();
        public Frame mainFrame;
        private string connectionString = "Server=(LocalDB)\\MSSQLLocalDB; Database=BDInventarioVenta; Integrated Security=true; TrustServerCertificate=true";

        public SubVClientes3(Frame framemain)
        {
            InitializeComponent();
            mainFrame = framemain;
            Loaded += SubVClientes3_Load;
        }

        private void SubVClientes3_Load(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT CI, Nombres, Apellidos FROM Cliente";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    // Llena el dataTable con datos de la base de datos
                    adapter.Fill(dataTable);

                    // Crea una nueva columna "Number" y la rellena
                    dataTable.Columns.Add("Number", typeof(int));
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        dataTable.Rows[i]["Number"] = i + 1;
                    }

                    dataGridClientes.ItemsSource = dataTable.DefaultView;
                }
            }
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
                string consulta = "SELECT CI, Nombres, Apellidos FROM Cliente WHERE CI = TRY_CAST(@searchTerm AS bigint) " +
                                 "OR Nombres LIKE @searchTerm";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(dataTable);

                // Agregar una nueva columna "Number"
                dataTable.Columns.Add("Number", typeof(int));
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    dataTable.Rows[i]["Number"] = i + 1;
                }

                if (dataTable.Rows.Count > 0)
                {
                    // Mostrar resultados en el data grid
                    dataGridClientes.ItemsSource = dataTable.DefaultView;
                    dataGridClientes.Visibility = Visibility.Visible;

                    // Restablecer mensajes anteriores
                    MessageBox.Show("Búsqueda completada. Se encontraron resultados.");
                }
                else
                {
                    // No se encontraron resultados, mostrar un mensaje
                    dataGridClientes.Visibility = Visibility.Collapsed;

                    if (searchTerm.Length > 0)
                    {
                        MessageBox.Show("No se encontraron resultados para la búsqueda.");
                    }
                    else
                    {
                        MessageBox.Show("Ingresa un nombre o CI para buscar.");
                    }
                }
            }
        }

        private void btnActualizarClientes_Click(object sender, RoutedEventArgs e)
        {
            string ciCliente, nombres, apellidos;

            // Obtén el botón que se hizo clic
            Button button = (Button)sender;

            // Obtén la fila que contiene el botón
            DataGridRow dataGridRow = FindParent<DataGridRow>(button);


            // Verifica si la fila no es nula
            if (dataGridRow != null)
            {
                // Obtén el objeto de datos de la fila seleccionada
                DataRowView rowView = (DataRowView)dataGridRow.Item;

                // Accede al valor del campo "CI"
                ciCliente = rowView["CI"].ToString();
                nombres = rowView["Nombres"].ToString();
                apellidos = rowView["Apellidos"].ToString();

                // Ahora puedes navegar a la página "ActualizarProvee" pasando los valores "nit" y "ventana" como argumentos
                mainFrame.NavigationService.Navigate(new SubVClientes4(mainFrame, ciCliente, nombres, apellidos));
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

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            // Verifica si se ha seleccionado una fila
            if (dataGridClientes.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente para eliminar.");
                return;
            }

            DataRowView selectedRow = (DataRowView)dataGridClientes.SelectedItem;
            string ciCliente = selectedRow["CI"].ToString(); // Suponiendo que "CI" es el nombre de la columna

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string cadena = "DELETE FROM Cliente WHERE CI = @CI";
                SqlCommand comando = new SqlCommand(cadena, conexion);

                // Agrega el parámetro para prevenir la inyección SQL
                comando.Parameters.AddWithValue("@CI", ciCliente);

                try
                {
                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Los datos del cliente se eliminaron correctamente.");

                        // Actualiza la lista de clientes en el DataGrid
                        SubVClientes3_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún cliente con el número de cédula seleccionado.");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al eliminar el cliente: " + ex.Message);
                    // Puedes registrar la excepción o tomar acciones adicionales según sea necesario.
                }
            }
        }
    }
}

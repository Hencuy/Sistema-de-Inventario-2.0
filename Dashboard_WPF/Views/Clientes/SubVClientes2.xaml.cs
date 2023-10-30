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
using Dashboard_WPF.Views.Proveedores;
using Dashboard_WPF.Modelos;

namespace Dashboard_WPF.Views.Clientes
{
    /// <summary>
    /// Interaction logic for SubVClientes2.xaml
    /// </summary>
    public partial class SubVClientes2 : Page
    {
        public Frame mainFrame;
        private string connectionString = "Server=(LocalDB)\\MSSQLLocalDB; Database=BDInventarioVenta; Integrated Security=true; TrustServerCertificate=true";

        public SubVClientes2(Frame framemain)
        {
            InitializeComponent();
            mainFrame = framemain;

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



        private void ActualizarButton_Click(object sender, RoutedEventArgs e)
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
                        SubVClientes2_Load(sender, e);
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

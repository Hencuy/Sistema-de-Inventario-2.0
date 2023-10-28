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
using Dashboard_WPF.Views.Clientes;

namespace Dashboard_WPF.Views.Usuarios
{
    /// <summary>
    /// Lógica de interacción para SubVUsuario2.xaml
    /// </summary>
    public partial class SubVUsuario2 : Page
    {
        public Frame mainFrame;
        private string connectionString = "Server=(LocalDB)\\MSSQLLocalDB; Database=BDInventarioVenta; Integrated Security=true; TrustServerCertificate=true";

        public SubVUsuario2(Frame framemain)
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
                string query = "SELECT CI, Nombre, Apellidos, Cargo, UserName, Contraseña, Estado FROM Usuario";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridUsuarios.ItemsSource = dataTable.DefaultView;
                }
            }
        }

        private void ActualizarButton_Click(object sender, RoutedEventArgs e)
        {
            string ciUsuario, nombres, apellidos, cargos, usernames, contraseñas, estados;

            Button button = (Button)sender;

            // Obtén la fila que contiene el botón
            DataGridRow dataGridRow = FindParent<DataGridRow>(button);


            // Verifica si la fila no es nula
            if (dataGridRow != null)
            {
                // Obtén el objeto de datos de la fila seleccionada
                DataRowView rowView = (DataRowView)dataGridRow.Item;

                // Accede al valor del campo "CI"
                ciUsuario = rowView["CI"].ToString();
                nombres = rowView["Nombre"].ToString();
                apellidos = rowView["Apellidos"].ToString();
                cargos = rowView["Cargo"].ToString();
                usernames = rowView["UserName"].ToString();
                contraseñas = rowView["Contraseña"].ToString();
                estados = rowView["Estado"].ToString();

                // Ahora puedes navegar a la página "ActualizarProvee" pasando los valores "nit" y "ventana" como argumentos
                mainFrame.NavigationService.Navigate(new SubVUsuario4(mainFrame, ciUsuario, nombres, apellidos, cargos, usernames,contraseñas,estados));
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
            if (dataGridUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un usuario para eliminar.");
                return;
            }

            DataRowView selectedRow = (DataRowView)dataGridUsuarios.SelectedItem;
            string ciUsuario = selectedRow["CI"].ToString(); // Suponiendo que "CI" es el nombre de la columna

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string cadena = "DELETE FROM Usuario WHERE CI = @CI";
                SqlCommand comando = new SqlCommand(cadena, conexion);

                // Agrega el parámetro para prevenir la inyección SQL
                comando.Parameters.AddWithValue("@CI", ciUsuario);

                try
                {
                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Los datos del usuario se eliminaron correctamente.");

                        // Actualiza la lista de usuarios en el DataGrid
                        SubVClientes2_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún usuario con el número de cédula seleccionado.");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al eliminar el usuario: " + ex.Message);
                    // Puedes registrar la excepción o tomar acciones adicionales según sea necesario.
                }
            }
        }
    }
}

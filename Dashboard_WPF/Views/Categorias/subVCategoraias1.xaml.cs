using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Dashboard_WPF.Views.Categorias
{
    public partial class subVCategoraias1 : Page
    {
        int v;
        string Nombre = "";
        string Ubicacion = "";
        int Estado = 0;
        SqlConnection conexion = new SqlConnection("Server= (LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true; TrustServerCertificate=True");

        public subVCategoraias1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            // Verifica si los campos están vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtUbicacion.Text) || ComboEstado.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // Sale del método sin guardar los datos
            }

            // Si todos los campos están llenos, continúa con el proceso de guardar los datos
            SacarDatos();

            // Verifica si ya existe un registro con el mismo nombre o ubicación
            if (ExisteRegistroDuplicado(Nombre, Ubicacion))
            {
                MessageBox.Show("Ya existe un registro con el mismo nombre o ubicación.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // Sale del método sin guardar los datos
            }

            conexion.Open();
            string sqlQuery = "INSERT INTO Categoria (Nombre, Ubicacion, Estado) VALUES (@Nombre, @Ubicacion, @Estado);";

            SqlCommand command = new SqlCommand(sqlQuery, conexion);
            command.Parameters.AddWithValue("@Nombre", Nombre);
            command.Parameters.AddWithValue("@Ubicacion", Ubicacion);
            command.Parameters.AddWithValue("@Estado", Estado);
            command.ExecuteNonQuery();
            conexion.Close();

            LimpiarXD();
            MessageBox.Show("Se ha añadido la categoría con éxito");
        }

        // Método para verificar si ya existe un registro con el mismo nombre o ubicación
        private bool ExisteRegistroDuplicado(string nombre, string ubicacion)
        {
            conexion.Open();
            string sqlQuery = "SELECT COUNT(*) FROM Categoria WHERE Nombre = @Nombre OR Ubicacion = @Ubicacion;";
            SqlCommand command = new SqlCommand(sqlQuery, conexion);
            command.Parameters.AddWithValue("@Nombre", nombre);
            command.Parameters.AddWithValue("@Ubicacion", ubicacion);
            int count = (int)command.ExecuteScalar();
            conexion.Close();

            return count > 0;
        }

        private void SacarDatos()
        {
            Nombre = txtNombre.Text;
            Ubicacion = txtUbicacion.Text;

            ComboBoxItem selectedItemEstado = (ComboBoxItem)ComboEstado.SelectedItem;
            if (selectedItemEstado != null)
            {
                string seleccion = selectedItemEstado.Content.ToString();
                if (seleccion == "Habilitado")
                {
                    Estado = 1;
                }
                else if (seleccion == "Deshabilitado")
                {
                    Estado = 0;
                }
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarXD();
        }

        private void LimpiarXD()
        {
            txtNombre.Text = "";
            txtUbicacion.Text = "";
            ComboEstado.SelectedIndex = 0;
        }

        private void txtNombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Usa una expresión regular para permitir solo letras en el campo de texto
            Regex regex = new Regex("[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
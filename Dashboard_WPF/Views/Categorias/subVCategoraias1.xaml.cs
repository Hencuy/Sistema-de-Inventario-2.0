using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Dashboard_WPF.Views.Categorias
{
    public partial class subVCategoraias1 : Page
    {
        //kjhhjkhk
        //hjihhoj
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

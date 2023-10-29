using Dashboard_WPF.Views.Proveedores;
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

namespace Dashboard_WPF.Views.Categorias
{
    /// <summary>
    /// Lógica de interacción para ActualizarCategoria.xaml
    /// </summary>
    public partial class ActualizarCategoria : Page
    {
        public Frame Main;
        string Idcat, Ventanas;
        SqlConnection conexion = new SqlConnection("Server= (LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true; TrustServerCertificate=True");
        public ActualizarCategoria(Frame main, string idcat, string ventanas)
        {
            InitializeComponent();
            Main = main;
            Idcat = idcat;
            Ventanas = ventanas;
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Obtén los valores de los campos de texto y ComboBox
                string idcat = Idcat;
                string nombre = txtNombre.Text;
                string ubicacion = txtUbicacion.Text;
                int estado = ComboEstado.SelectedIndex; // Debes asegurarte de que el ComboBox tenga los valores correctos.

                // Abre la conexión a la base de datos
                conexion.Open();

                // Crea una consulta SQL para actualizar los datos del proveedor
                string consulta = "UPDATE Categoria SET Nombre = @Nombre, Ubicacion = @Ubicacion, Estado = @Estado WHERE idcategoria = @id";
                SqlCommand command = new SqlCommand(consulta, conexion);
                command.Parameters.AddWithValue("@id", idcat);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Ubicacion", ubicacion);
                command.Parameters.AddWithValue("@Estado", estado);

                // Ejecuta la consulta para actualizar los datos
                int filasActualizadas = command.ExecuteNonQuery();

                // Cierra la conexión a la base de datos
                conexion.Close();

                if (filasActualizadas > 0)
                {
                    MessageBox.Show("Los datos de la Categoria se actualizaron con éxito.");
                    if (Ventanas == "Lista")
                    {
                        Main.NavigationService.Navigate(new subVCategoraias2(Main));
                    }
                    else
                    {
                        Main.NavigationService.Navigate(new subVCategoraias3());
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar los datos de la Categoria.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos de la Categoria: " + ex.Message);
            }
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Main.NavigationService.Navigate(new subVCategoraias2(Main));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string idcategoria = Idcat;

            // Abre la conexión a la base de datos
            conexion.Open();
            string consulta = "SELECT * FROM Categoria WHERE idCategoria = @id";

            SqlCommand command = new SqlCommand(consulta, conexion);
            command.Parameters.AddWithValue("@id", idcategoria);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {

                txtNombre.Text = reader["Nombre"].ToString();
                txtUbicacion.Text = reader["Ubicacion"].ToString();
                int estado = (int)reader["Estado"];
                ComboEstado.SelectedIndex = estado;
            }

            reader.Close();
            conexion.Close();
        }
    }
}


using Dashboard_WPF.Views.Proveedores;
using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

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
                string nombre = txtNombre.Text.Trim();
                string ubicacion = txtUbicacion.Text.Trim();
                int estado = ComboEstado.SelectedIndex; // Asegúrate de que el ComboBox tenga los valores correctos.

                // Validación: El campo 'Nombre' solo puede contener letras
                if (!System.Text.RegularExpressions.Regex.IsMatch(nombre, "^[a-zA-Z]+$"))
                {
                    MessageBox.Show("El campo 'Nombre' solo puede contener letras.");
                    return;
                }

                // Validate inputs (prevenir valores vacíos o nulos)
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(ubicacion))
                {
                    MessageBox.Show("Por favor, completa todos los campos.");
                    return;
                }

                // Abre la conexión a la base de datos
                conexion.Open();

                // Check for duplicate category names
                string duplicateCategoryQuery = "SELECT COUNT(*) FROM Categoria WHERE Nombre = @Nombre AND idCategoria != @id";
                SqlCommand duplicateCategoryCommand = new SqlCommand(duplicateCategoryQuery, conexion);
                duplicateCategoryCommand.Parameters.AddWithValue("@id", idcat);
                duplicateCategoryCommand.Parameters.AddWithValue("@Nombre", nombre);

                int duplicateCategoryCount = (int)duplicateCategoryCommand.ExecuteScalar();

                if (duplicateCategoryCount > 0)
                {
                    MessageBox.Show("Ya existe una categoría con ese nombre. Por favor, elige un nombre diferente.");
                    conexion.Close();
                    return;
                }

                // Check for duplicate aisle names
                string duplicateAisleQuery = "SELECT COUNT(*) FROM Categoria WHERE Ubicacion = @Ubicacion AND idCategoria != @id";
                SqlCommand duplicateAisleCommand = new SqlCommand(duplicateAisleQuery, conexion);
                duplicateAisleCommand.Parameters.AddWithValue("@id", idcat);
                duplicateAisleCommand.Parameters.AddWithValue("@Ubicacion", ubicacion);

                int duplicateAisleCount = (int)duplicateAisleCommand.ExecuteScalar();

                if (duplicateAisleCount > 0)
                {
                    MessageBox.Show("Ya existe un pasillo con esa ubicación. Por favor, elige una ubicación diferente.");
                    conexion.Close();
                    return;
                }

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

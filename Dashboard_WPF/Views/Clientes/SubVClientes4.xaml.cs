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

namespace Dashboard_WPF.Views.Clientes
{
    /// <summary>
    /// Lógica de interacción para SubVClientes4.xaml
    /// </summary>
    public partial class SubVClientes4 : Page
    {
        public Frame FrameClientes;
        public SubVClientes2 subVClientes2;

        public SubVClientes4()
        {
            InitializeComponent();
            FrameClientes = new Frame();
            //subVClientes2 = new SubVClientes2();
        }

        private void btnActualizarClientes_Click(object sender, RoutedEventArgs e)
        {
            // Obtén los nuevos valores de los TextBox en la página subVClientes4
            string nuevoCI = txtidCliente.Text;
            string nuevosNombres = txtNombreCliente.Text;
            string nuevosApellidos = txtApellidosCliente.Text;

            string connectionString = "server=(LocalDB)\\MSSQLLocalDB; database=BDInventarioVenta; integrated security=true; TrustServerCertificate=true";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                // Construye la consulta SQL de actualización
                string consulta = "UPDATE Cliente SET Nombres = @Nombres, Apellidos = @Apellidos WHERE CI = @CI";
                SqlCommand comando = new SqlCommand(consulta, conexion);

                // Asigna los nuevos valores como parámetros
                comando.Parameters.AddWithValue("@Nombres", nuevosNombres);
                comando.Parameters.AddWithValue("@Apellidos", nuevosApellidos);
                comando.Parameters.AddWithValue("@CI", nuevoCI);

                int filasActualizadas = comando.ExecuteNonQuery();

                if (filasActualizadas > 0)
                {
                    MessageBox.Show("Los datos se actualizaron correctamente");
                }
                else
                {
                    MessageBox.Show("No se encontró ningún cliente con el número de cédula (CI) proporcionado");
                }
            }
        }

        private void txtIdCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BuscarClientePorID();
            }
        }

        private void BuscarClientePorID()
        {
            string idCliente = txtidCliente.Text.Trim(); // Obtener el ID del cliente
            if (string.IsNullOrEmpty(idCliente))
            {
                MessageBox.Show("Por favor, ingrese un número de cédula para buscar.");
                return;
            }

            // Realizar la búsqueda en la base de datos utilizando el ID ingresado

            string connectionString = "Server=(LocalDB)\\MSSQLLocalDB; database=BDInventarioVenta; integrated security=true; TrustServerCertificate=true";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string consulta = "SELECT Nombres, Apellidos FROM Cliente WHERE CI = @CI";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CI", idCliente);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    // Rellenar los campos con los datos encontrados
                    txtNombreCliente.Text = reader["Nombres"].ToString();
                    txtApellidosCliente.Text = reader["Apellidos"].ToString();
                }
                else
                {
                    // Mostrar mensaje si no se encuentra el cliente
                    MessageBox.Show("El número de cédula no está registrado.");
                    txtNombreCliente.Text = "";
                    txtApellidosCliente.Text = "";
                }
            }
        }

        private void btnlimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtidCliente.Text = "";
            txtNombreCliente.Text = "";
            txtApellidosCliente.Text = "";
        }

        private void txtIdCliente_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Verificar si el carácter ingresado no es un número
            if (!IsNumeric(e.Text))
            {
                e.Handled = true; // Detener la entrada del carácter
                //MessageBox.Show("Solo se permiten números en este campo.");
            }
        }

        // Función auxiliar para verificar si un carácter es un número
        private bool IsNumeric(string text)
        {
            return int.TryParse(text, out _);
        }


        private void txtNombreCliente_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Verificar si el carácter ingresado no es una letra
            if (!IsLetter(e.Text))
            {
                e.Handled = true; // Detener la entrada del carácter
                MessageBox.Show("Solo se permiten letras en este campo.");
            }
        }

        private void txtNombreCliente_LostFocus(object sender, RoutedEventArgs e)
        {
            // Convertir el texto a formato "Palabra Capital" (mayúscula al principio de cada palabra)
            txtNombreCliente.Text = ToTitleCase(txtNombreCliente.Text);
        }

        // Función auxiliar para verificar si un carácter es una letra
        private bool IsLetter(string text)
        {
            return char.IsLetter(text[0]);
        }

        // Función auxiliar para convertir texto a "Palabra Capital"
        private string ToTitleCase(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            string[] words = text.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (!string.IsNullOrEmpty(words[i]))
                {
                    char[] letters = words[i].ToCharArray();
                    if (letters.Length > 0)
                    {
                        letters[0] = char.ToUpper(letters[0]);
                        words[i] = new string(letters);
                    }
                }
            }
            return string.Join(" ", words);
        }

    }
}

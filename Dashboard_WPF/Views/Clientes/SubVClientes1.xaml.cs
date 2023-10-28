using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Dashboard_WPF.Views.Clientes
{
    public partial class SubVClientes1 : Page
    {
        public Frame FrameClientes;
        public SubVClientes2 subVClientes2;

        public SubVClientes1()
        {
            InitializeComponent();
            FrameClientes = new Frame();
        }

        private void btnGuardarClientes_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtidCliente.Text) || string.IsNullOrWhiteSpace(txtNombreCliente.Text) || string.IsNullOrWhiteSpace(txtApellidosCliente.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de guardar.");
                return;
            }

            string ci = txtidCliente.Text.Trim();

            if (ClienteExists(ci))
            {
                MessageBox.Show("El número de cédula ya está registrado.");
                return;
            }

            SqlConnection conexion = new SqlConnection("server=(LocalDB)\\MSSQLLocalDB; database=BDInventarioVenta; integrated security=true; TrustServerCertificate=true");
            conexion.Open();
            string cadena = "INSERT INTO Cliente (CI, Nombres, Apellidos) " +
                            "VALUES ('" + ci + "', '" + txtNombreCliente.Text + "', '" + txtApellidosCliente.Text + "')";

            SqlCommand comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();

            MessageBox.Show("Los datos se guardaron correctamente");
            txtidCliente.Text = "";
            txtNombreCliente.Text = "";
            txtApellidosCliente.Text = "";
            conexion.Close();

            // Redirige al usuario a la página subVClientes2
            FrameClientes.NavigationService.Navigate(subVClientes2);
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
            string idCliente = txtidCliente.Text.Trim();
            if (string.IsNullOrEmpty(idCliente))
            {
                MessageBox.Show("Por favor, ingrese un número de cédula para buscar.");
                return;
            }

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
                    txtNombreCliente.Text = reader["Nombres"].ToString();
                    txtApellidosCliente.Text = reader["Apellidos"].ToString();
                }
                else
                {
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
            if (!IsNumeric(e.Text))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten Numeros en este campo.");
            }
        }

        private void txtNombreCliente_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!IsLetter(e.Text))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras en este campo.");
            }
        }

        private void txtNombreCliente_LostFocus(object sender, RoutedEventArgs e)
        {
            txtNombreCliente.Text = ToTitleCase(txtNombreCliente.Text);
        }

        private void txtApellidoCliente_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!IsLetter(e.Text))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras en este campo.");
            }
        }

        private bool IsNumeric(string text)
        {
            return int.TryParse(text, out _);
        }

        private bool IsLetter(string text)
        {
            return char.IsLetter(text[0]);
        }

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

        private bool ClienteExists(string ci)
        {
            string connectionString = "Server=(LocalDB)\\MSSQLLocalDB; database=BDInventarioVenta; integrated security=true; TrustServerCertificate=true";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string consulta = "SELECT COUNT(*) FROM Cliente WHERE CI = @CI";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CI", ci);

                int count = (int)comando.ExecuteScalar();

                return count > 0;
            }
        }
    }
}

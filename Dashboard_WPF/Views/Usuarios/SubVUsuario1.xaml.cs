using Dashboard_WPF.Views.Clientes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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

namespace Dashboard_WPF.Views.Usuarios
{
    /// <summary>
    /// Lógica de interacción para SubVUsuario1.xaml
    /// </summary>
    public partial class SubVUsuario1 : Page
    {
      
        public Frame FrameClientes;
        public SubVClientes2 subVClientes2;

        public SubVUsuario1()
        {
            InitializeComponent();
            FrameClientes = new Frame();
        }

        private string CalcularHash(string contraseña)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertir la contraseña en un array de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contraseña));

                // Convertir el array de bytes en una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void btnGuardarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtidCliente.Text) || string.IsNullOrWhiteSpace(txtNombreCliente.Text) || string.IsNullOrWhiteSpace(txtApellidosCliente.Text) ||
                cbxCargo.SelectedItem == null || cbxEstado.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de guardar.");
                return;
            }

            string ci = txtidCliente.Text.Trim();

            if (UsuarioExists(ci))
            {
                MessageBox.Show("El número de cédula ya está registrado.");
                return;
            }

            SqlConnection conexion = new SqlConnection("Server=(LocalDB)\\MSSQLLocalDB; database=BDInventarioVenta; integrated security=true; TrustServerCertificate=true");
            conexion.Open();

            string contraseñaEncriptada = CalcularHash(txtContraseña.Text); // Encripta la contraseña

            string cadena = "INSERT INTO Usuario (CI, Nombre, Apellidos, Cargo, UserName, Contraseña, Estado) " +
                            "VALUES (@CI, @Nombre, @Apellidos, @Cargo, @UserName, @Contraseña, @Estado)";

            SqlCommand comando = new SqlCommand(cadena, conexion);
            comando.Parameters.AddWithValue("@CI", ci);
            comando.Parameters.AddWithValue("@Nombre", txtNombreCliente.Text);
            comando.Parameters.AddWithValue("@Apellidos", txtApellidosCliente.Text);

            string cargo = cbxCargo.SelectedItem.ToString();
            if (cbxCargo.SelectedItem is ComboBoxItem selectedItem)
            {
                cargo = selectedItem.Content.ToString();
            }
            comando.Parameters.AddWithValue("@Cargo", cargo);

            comando.Parameters.AddWithValue("@UserName", txtUserName.Text);
            comando.Parameters.AddWithValue("@Contraseña", contraseñaEncriptada); // Almacena la contraseña encriptada
            int estado = 1; // Valor predeterminado (por ejemplo, "Activo")
            if (cbxEstado.SelectedItem.ToString() == "Inactivo")
            {
                estado = 2;
            }
            else if (cbxEstado.SelectedItem.ToString() == "Ausente")
            {
                estado = 3;
            }
            comando.Parameters.AddWithValue("@Estado", estado);

            comando.ExecuteNonQuery();

            MessageBox.Show("Los datos se guardaron correctamente");
            LimpiarCampos();

            conexion.Close();

            // Redirige al usuario a la página subVClientes2
            FrameClientes.NavigationService.Navigate(subVClientes2);
        }

        private bool UsuarioExists(string ci)
        {
            // Realiza una consulta a la base de datos para verificar si el usuario con la CI especificada ya existe.
            // Debes implementar esta consulta de acuerdo a tu base de datos.
            SqlConnection conexion = new SqlConnection("Server=(LocalDB)\\MSSQLLocalDB; database=BDInventarioVenta; integrated security=true; TrustServerCertificate=true");
            conexion.Open();

            string consulta = "SELECT COUNT(*) FROM Usuario WHERE CI = @CI";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@CI", ci);

            int count = (int)comando.ExecuteScalar();

            conexion.Close();

            return count > 0; // Retorna true si existe al menos un usuario con la CI especificada.
        }

        private void txtIdCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BuscarUsuarioPorCI();
            }
        }

        private void BuscarUsuarioPorCI()
        {
            string ci = txtidCliente.Text.Trim();
            if (string.IsNullOrEmpty(ci))
            {
                MessageBox.Show("Por favor, ingrese un número de cédula para buscar.");
                return;
            }

            string connectionString = "Server=(LocalDB)\\MSSQLLocalDB; database=BDInventarioVenta; integrated security=true; TrustServerCertificate=true";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string consulta = "SELECT Nombre, Apellidos FROM Usuario WHERE CI = @CI";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CI", ci);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    txtNombreCliente.Text = reader["Nombre"].ToString();
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
        private void LimpiarCampos()
        {
            txtidCliente.Text = "";
            txtNombreCliente.Text = "";
            txtApellidosCliente.Text = "";
            cbxCargo.SelectedIndex = -1;
            txtUserName.Text = "";
            txtContraseña.Text = "";
            cbxEstado.SelectedIndex = -1;
        }


        private void btnlimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();   
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

    }
}

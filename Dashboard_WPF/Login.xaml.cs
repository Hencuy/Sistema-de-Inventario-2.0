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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Dashboard_WPF
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private string cargoUsuario;
        private string nombreUsuario;
        private string apellidosUsuario;
        int cont = 0;
        public Login()
        {
            InitializeComponent();

        }

        private void MOVER(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnminimizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnclose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
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

        private bool VerificarContraseña(string contraseña, string hash)
        {
            // Calcular el hash de la contraseña ingresada
            string contraseñaIngresadaHash = CalcularHash(contraseña);

            // Comparar los hashes
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(contraseñaIngresadaHash, hash) == 0;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conexion = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=BDInventarioVenta; Integrated Security=True;");

            conexion.Open();
            string username = txtusuario.Text;
            string password = txtPass.Password;
            string pass = txtPass2.Text;
            string query = "SELECT Nombre, Apellidos, Cargo, UserName, Contraseña FROM Usuario WHERE UserName = @UserName";
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@UserName", username);
            SqlDataReader registros = comando.ExecuteReader();
            if (registros.Read())
            {
                string contraseñaHash = registros["Contraseña"].ToString();

                if (VerificarContraseña(password, contraseñaHash) || VerificarContraseña(pass, contraseñaHash))
                {
                    nombreUsuario = registros["Nombre"].ToString();
                    cargoUsuario = registros["Cargo"].ToString();
                    apellidosUsuario = registros["Apellidos"].ToString();
                    MessageBox.Show("Bienvenido, " + nombreUsuario + ". Cargo: " + cargoUsuario);

                    // Oculta la ventana de inicio de sesión
                    Hide();

                    // Abre el formulario de bienvenida
                    VentanaDeCarga formBienvenida = new VentanaDeCarga(nombreUsuario, apellidosUsuario, cargoUsuario);
                    formBienvenida.Show();

                    // Configura un temporizador para cerrar la ventana de bienvenida después de 30 segundos
                    DispatcherTimer timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromSeconds(0.7); // 30 segundos
                    timer.Tick += (s, args) =>
                    {
                        timer.Stop();
                        // Abre la ventana principal
                        MainWindow mainWindow = new MainWindow(nombreUsuario, cargoUsuario);
                        mainWindow.Show();
                        formBienvenida.Close(); // Cierra la ventana de bienvenida después de abrir la principal
                    };
                    timer.Start();

                }
                else
                {
                    cont++;
                    MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
                    if (cont == 3)
                    {
                        Application.Current.Shutdown();
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("No ingresó ningún dato.");
                }
            }
            conexion.Close();
        }


        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SqlConnection conexion = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=BDInventarioVenta; Integrated Security=True;");

                conexion.Open();
                string username = txtusuario.Text;
                string password = txtPass.Password;
                string pass = txtPass2.Text;
                string query = "SELECT Nombre,Apellidos, Cargo, UserName, Contraseña FROM Usuario WHERE UserName = @UserName";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@UserName", username);
                SqlDataReader registros = comando.ExecuteReader();
                if (registros.Read())
                {
                    string contraseñaHash = registros["Contraseña"].ToString();

                    if (VerificarContraseña(password, contraseñaHash) || VerificarContraseña(pass, contraseñaHash))
                    {
                        string nombreUsuario = registros["Nombre"].ToString();
                        string cargoUsuario = registros["Cargo"].ToString();
                        apellidosUsuario = registros["Apellidos"].ToString();

                        MessageBox.Show("Bienvenido, " + nombreUsuario + ". Cargo: " + cargoUsuario);
                        // Oculta la ventana de inicio de sesión
                        Hide();

                        // Abre el formulario de bienvenida
                        VentanaDeCarga formBienvenida = new VentanaDeCarga(nombreUsuario, apellidosUsuario, cargoUsuario);
                        formBienvenida.Show();

                        // Configura un temporizador para cerrar la ventana de bienvenida después de 30 segundos
                        DispatcherTimer timer = new DispatcherTimer();
                        timer.Interval = TimeSpan.FromSeconds(0.7); // 30 segundos
                        timer.Tick += (s, args) =>
                        {
                            timer.Stop();
                            formBienvenida.Close(); // Cierra la ventana de bienvenida
                                                    // Abre la ventana principal
                            MainWindow mainWindow = new MainWindow(nombreUsuario, cargoUsuario);
                            mainWindow.Show();
                        };
                        timer.Start();
                    }
                    else
                    {
                        cont++;
                        MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
                        if (cont == 3)
                        {
                            Application.Current.Shutdown();
                        }
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(username))
                    {
                        MessageBox.Show("No ingresó ningún dato.");
                    }
                }
                conexion.Close();
            }
        }
        private void chkMostrarContrasena_Checked(object sender, RoutedEventArgs e)
        {
            txtPass.Visibility = Visibility.Collapsed;
            txtPass2.Text = txtPass.Password;
            txtPass2.Visibility = Visibility.Visible;
        }

        private void chkMostrarContrasena_Unchecked(object sender, RoutedEventArgs e)
        {
            txtPass.Visibility = Visibility.Visible;
            txtPass.Password = txtPass2.Text;
            txtPass2.Visibility = Visibility.Collapsed;
        }

    }
}

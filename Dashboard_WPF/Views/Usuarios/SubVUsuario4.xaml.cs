using Dashboard_WPF.Views.Clientes;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
    /// Lógica de interacción para SubVUsuario4.xaml
    /// </summary>
    public partial class SubVUsuario4 : Page
    {
        public Frame mainFrame;
        string ciUsuario, nombres, apellidos, cargos, usernames, actualcontraseña, nuevacontraseñas, estados;

        public SubVUsuario4(Frame framemain, string ciusuario, string nombre, string apellido, string cargo, string username, string contraseña, string estado)
        {
            InitializeComponent();
            mainFrame = framemain;
            ciUsuario = ciusuario;
            nombres = nombre;
            apellidos = apellido;
            cargos = cargo;
            usernames = username;
            actualcontraseña = "";
            nuevacontraseñas = "";
            estados = estado;
            this.Loaded += SubVClientes4_Loaded;
        }

        private void SubVClientes4_Loaded(object sender, RoutedEventArgs e)
        {
            // Resto de la carga de datos
            txtidUsuarios.Text = ciUsuario;
            txtNombreUsuarios.Text = nombres;
            txtApellidosUsuarios.Text = apellidos;
            txtUserNameUsuarios.Text = usernames;
            PassContraseñaActualUsuarios.Password = actualcontraseña;
            PassContraseñaNuevaUsuarios.Password = nuevacontraseñas;
            cbxCargoUsuarios.SelectedItem = cargos;
            cbxEstado.SelectedItem = estados;
            // Llenar el ComboBox de Cargo
            cbxCargoUsuarios.ItemsSource = ObtenerListaDeCargos(); // Reemplaza ObtenerListaDeCargos() con tu lógica para obtener la lista de cargos.
            cbxCargoUsuarios.SelectedItem = cargos; // Establece el valor seleccionado

            // Llenar el ComboBox de Estado
            cbxEstado.ItemsSource = ObtenerListaDeEstados(); // Reemplaza ObtenerListaDeEstados() con tu lógica para obtener la lista de estados.
            cbxEstado.SelectedItem = estados; // Establece el valor seleccionado
        }

        private List<string> ObtenerListaDeCargos()
        {            
            List<string> cargos = new List<string> { "Administrador", "Cajero", "Cajera" };
            return cargos;
        }

        private List<string> ObtenerListaDeEstados()
        {            
            List<string> estados = new List<string> { "Activo", "Inactivo", "Ausente" };
            return estados;
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


        private void btnActualizarUsuario_Click(object sender, RoutedEventArgs e)
        {
            // Obtén los nuevos valores de los TextBox y ComboBox en la página SubVClientes4
            string nuevoCI = txtidUsuarios.Text;
            string nuevosNombres = txtNombreUsuarios.Text;
            string nuevosApellidos = txtApellidosUsuarios.Text;
            string nuevoUserName = txtUserNameUsuarios.Text;
            string nuevaContraseña = PassContraseñaNuevaUsuarios.Password; // Nueva contraseña ingresada por el usuario
            string nuevosCargo = cbxCargoUsuarios.Text;
            string nuevosEstado = cbxEstado.Text;

            int estado = 0; // Valor predeterminado, debes definir tus propios valores numéricos

            // Asignar el valor numérico correspondiente al ComboBox de Estado
            if (nuevosEstado == "Activo")
            {
                estado = 1;
            }
            else if (nuevosEstado == "Inactivo")
            {
                estado = 2;
            }
            else if (nuevosEstado == "Ausente")
            {
                estado = 3;
            }

            string connectionString = "Server=(LocalDB)\\MSSQLLocalDB; database=BDInventarioVenta; integrated security=true; TrustServerCertificate=true";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                // Verificar si la contraseña actual es correcta antes de continuar
                if (!VerificarContraseñaActual(nuevoCI, PassContraseñaActualUsuarios.Password))
                {
                    MessageBox.Show("Es necesario la contraseña actual. No se puede realizar la actualización.");
                    return; // Detener la actualización si la contraseña actual es incorrecta
                }

                // Construye la consulta SQL de actualización para los datos del usuario (nombres, apellidos, cargo, estado)
                string consulta = "UPDATE Usuario SET Nombre = @Nombres, Apellidos = @Apellidos, Cargo = @Cargo, Estado = @Estado, UserName = @UserName WHERE CI = @CI";
                SqlCommand comando = new SqlCommand(consulta, conexion);

                // Asigna los nuevos valores como parámetros
                comando.Parameters.AddWithValue("@Nombres", nuevosNombres);
                comando.Parameters.AddWithValue("@Apellidos", nuevosApellidos);
                comando.Parameters.AddWithValue("@Cargo", nuevosCargo);
                comando.Parameters.AddWithValue("@Estado", estado);
                comando.Parameters.AddWithValue("@UserName", nuevoUserName);
                comando.Parameters.AddWithValue("@CI", nuevoCI);

                int filasActualizadas = comando.ExecuteNonQuery();

                if (filasActualizadas > 0)
                {
                    MessageBox.Show("Los datos se actualizaron correctamente");
                    LimpiarCampos();
                    mainFrame.NavigationService.Navigate(new SubVUsuario2(mainFrame));

                }
                else
                {
                    MessageBox.Show("No se encontró ningún usuario con el número de cédula (CI) proporcionado");
                }

                // Si se proporciona una nueva contraseña, actualiza la contraseña también
                if (!string.IsNullOrEmpty(nuevaContraseña))
                {
                    // Calcula el hash de la nueva contraseña
                    string nuevaContraseñaHash = CalcularHash(nuevaContraseña);

                    // Construye una consulta SQL para actualizar la contraseña
                    string consultaContraseña = "UPDATE Usuario SET Contraseña = @Contraseña WHERE CI = @CI";
                    SqlCommand comandoContraseña = new SqlCommand(consultaContraseña, conexion);

                    // Asigna la nueva contraseña hasheada como parámetro
                    comandoContraseña.Parameters.AddWithValue("@Contraseña", nuevaContraseñaHash);
                    comandoContraseña.Parameters.AddWithValue("@CI", nuevoCI);

                    int filasActualizadasContraseña = comandoContraseña.ExecuteNonQuery();

                    if (filasActualizadasContraseña > 0)
                    {
                        MessageBox.Show("La contraseña se actualizó correctamente");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún usuario con el número de cédula (CI) proporcionado");
                    }
                }
            }
        }
        private bool VerificarContraseñaActual(string ci, string contraseñaActual)
        {
            string connectionString = "Server=(LocalDB)\\MSSQLLocalDB; database=BDInventarioVenta; integrated security=true; TrustServerCertificate=true";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string consulta = "SELECT Contraseña FROM Usuario WHERE CI = @CI";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CI", ci);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    string contraseñaAlmacenada = reader["Contraseña"].ToString();
                    // Verificar si la contraseña actual coincide con la contraseña almacenada
                    return VerificarContraseña(contraseñaActual, contraseñaAlmacenada);
                }

                // Si no se encontró un usuario con el CI proporcionado, devuelve falso
                return false;
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



        private void txtIdCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BuscarUsuarioPorCI();
            }
        }

        private void BuscarUsuarioPorCI()
        {
            string ci = txtidUsuarios.Text.Trim();
            if (string.IsNullOrEmpty(ci))
            {
                MessageBox.Show("Por favor, ingrese un número de cédula para buscar.");
                return;
            }

            string connectionString = "Server=(LocalDB)\\MSSQLLocalDB; database=BDInventarioVenta; integrated security=true; TrustServerCertificate=true";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open(); 
                string consulta = "SELECT CI, Nombre, Apellidos, Cargo, UserName, Estado FROM Usuario WHERE CI = @CI";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CI", ci);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    txtNombreUsuarios.Text = reader["Nombre"].ToString();
                    txtApellidosUsuarios.Text = reader["Apellidos"].ToString();
                    txtUserNameUsuarios.Text = reader["Nombre"].ToString();
                    //PassContraseñaActualUsuarios.Password = reader["Contraseña"].ToString();
                    cbxCargoUsuarios.SelectedItem = reader["Cargo"].ToString();
                    cbxEstado.SelectedItem = reader["Estado"].ToString();
                }
                else
                {
                    MessageBox.Show("El número de cédula no está registrado.");
                    LimpiarCampos();
                }
            }
        }


        private void LimpiarCampos()
        {
            txtNombreUsuarios.Text = "";
            txtApellidosUsuarios.Text = "";
            cbxCargoUsuarios.SelectedIndex = -1;
            txtUserNameUsuarios.Text = "";
            PassContraseñaActualUsuarios.Password = "";
            PassContraseñaNuevaUsuarios.Password = "";
            cbxEstado.SelectedIndex = -1;
        }


        private void btnlimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            if (mainFrame != null)
            {
                // Navega a la página SubVClientes2 utilizando el objeto mainFrame
                mainFrame.NavigationService.Navigate(new SubVUsuario2(mainFrame));
            }
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
            txtNombreUsuarios.Text = ToTitleCase(txtNombreUsuarios.Text);
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

using Dashboard_WPF.Modelos;
using Dashboard_WPF.Views.Categorias;
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

namespace Dashboard_WPF.Views.Proveedores
{
    /// <summary>
    /// Lógica de interacción para ActualizarProvee.xaml
    /// </summary>
    public partial class ActualizarProvee : Page
    {
        public Frame Mainframe;
        string Nit,Ventana;
        SqlConnection conexion = new SqlConnection("Server= (LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true; TrustServerCertificate=True");


        public ActualizarProvee(Frame framemain,string nit,string ventana)
        {
            InitializeComponent();
            Mainframe = framemain;
            Nit = nit;
            Ventana = ventana;
        }

        private void btnGuardarProveedor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Obtén los valores de los campos de texto y ComboBox
                long nit = long.Parse(txtNIT.Text);
                string nombreCompañia = txtNombreCompañia.Text;
                string nombreEncargado = txtNombreEncargado.Text;
                int estado = comboBoxEstado.SelectedIndex; // Debes asegurarte de que el ComboBox tenga los valores correctos.
                long telefonoEncargado = long.Parse(txtTelefonoEncargado.Text);
                string direccion = txtDireccion.Text;
                string email = txtEmail.Text;

                // Abre la conexión a la base de datos
                conexion.Open();

                // Crea una consulta SQL para actualizar los datos del proveedor
                string consulta = "UPDATE Proveedor SET NombreCompañia = @NombreCompañia, NombreEncargado = @NombreEncargado, Estado = @Estado, TelefonoEncargado = @TelefonoEncargado, Direccion = @Direccion, Email = @Email WHERE NIT = @NIT";

                SqlCommand command = new SqlCommand(consulta, conexion);
                command.Parameters.AddWithValue("@NIT", nit);
                command.Parameters.AddWithValue("@NombreCompañia", nombreCompañia);
                command.Parameters.AddWithValue("@NombreEncargado", nombreEncargado);
                command.Parameters.AddWithValue("@Estado", estado);
                command.Parameters.AddWithValue("@TelefonoEncargado", telefonoEncargado);
                command.Parameters.AddWithValue("@Direccion", direccion);
                command.Parameters.AddWithValue("@Email", email);

                // Ejecuta la consulta para actualizar los datos
                int filasActualizadas = command.ExecuteNonQuery();

                // Cierra la conexión a la base de datos
                conexion.Close();

                if (filasActualizadas > 0)
                {
                    MessageBox.Show("Los datos del proveedor se actualizaron con éxito.");
                    if (Ventana == "Lista")
                    {
                        Mainframe.NavigationService.Navigate(new SubVProveedores2(Mainframe));
                    }
                    else
                    {
                        Mainframe.NavigationService.Navigate(new SubVProveedores3());
                    }

                }
                else
                {
                    MessageBox.Show("No se pudo actualizar los datos del proveedor.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos del proveedor: " + ex.Message);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Aquí debes obtener el NIT del proveedor cuyos datos deseas cargar
            // Puedes pasar este valor como parámetro al cargar la página o de alguna otra manera.
            string nitProveedor = Nit; // Reemplaza esto con la forma de obtener el NIT del proveedor.

            // Ahora, debes obtener los datos del proveedor desde tu base de datos.
            // Realiza una consulta SQL para obtener los datos del proveedor con el NIT especificado.
            conexion.Open();
            string consulta = "SELECT * FROM Proveedor WHERE NIT = @NIT";

            SqlCommand command = new SqlCommand(consulta, conexion);
            command.Parameters.AddWithValue("@NIT", nitProveedor);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                // Rellenar los campos de texto y ComboBox con los datos del proveedor.
                txtNIT.Text = reader["NIT"].ToString();
                txtNombreCompañia.Text = reader["NombreCompañia"].ToString();
                txtNombreEncargado.Text = reader["NombreEncargado"].ToString();
                txtTelefonoEncargado.Text = reader["TelefonoEncargado"].ToString();
                txtDireccion.Text = reader["Direccion"].ToString();
                txtEmail.Text = reader["Email"].ToString();

                // Ahora, establece el estado del ComboBox según el valor leído de la base de datos.
                int estado = (int)reader["Estado"];
               
                comboBoxEstado.SelectedIndex = estado; // Asegúrate de que esta asignación sea correcta.
            }

            reader.Close();
            conexion.Close();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            if(Ventana == "Lista")
            {
                Mainframe.NavigationService.Navigate(new SubVProveedores2(Mainframe));
            }
            else
            {
                Mainframe.NavigationService.Navigate(new SubVProveedores3());
            }
           
        }
    }
}

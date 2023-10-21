using Dashboard_WPF.Modelos;
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
    /// Lógica de interacción para SubVProveedores1.xaml
    /// </summary>
    public partial class SubVProveedores1 : Page
    {
        SqlConnection conexion = new SqlConnection("Server= (LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true; TrustServerCertificate=True");
        public SubVProveedores1()
        {
            InitializeComponent();
        }

        private void btnGuardarProveedor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Abre la conexión a la base de datos
                conexion.Open();

                // Prepara la consulta SQL para insertar los datos en la tabla Proveedor
                string query = "INSERT INTO Proveedor (NIT, NombreCompañia, NombreEncargado, Estado, TelefonoEncargado, Direccion, Email) " +
                               "VALUES (@NIT, @NombreCompañia, @NombreEncargado, @Estado, @TelefonoEncargado, @Direccion, @Email)";

                SqlCommand cmd = new SqlCommand(query, conexion);

                // Reemplaza estos valores con los datos de tus TextBox y ComboBox
                cmd.Parameters.AddWithValue("@NIT", Convert.ToInt64(txtNIT.Text));
                cmd.Parameters.AddWithValue("@NombreCompañia", txtNombreCompañia.Text);
                cmd.Parameters.AddWithValue("@NombreEncargado", txtNombreEncargado.Text);

                // Convierte el valor del ComboBox a 1 o 0 según la selección
                if (comboBoxEstado.SelectedIndex == 0)
                {
                    cmd.Parameters.AddWithValue("@Estado", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Estado", 0);
                }

                cmd.Parameters.AddWithValue("@TelefonoEncargado", Convert.ToInt64(txtTelefonoEncargado.Text));
                cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                // Ejecuta la consulta
                cmd.ExecuteNonQuery();

                // Cierra la conexión
                conexion.Close();
                // Limpia los campos de TextBox
                txtNIT.Clear();
                txtNombreCompañia.Clear();
                txtNombreEncargado.Clear();
                txtTelefonoEncargado.Clear();
                txtDireccion.Clear();
                txtEmail.Clear();

                // Establece el ComboBox en "Habilitado" (asumiendo que "Habilitado" es el primer elemento en el ComboBox)
                comboBoxEstado.SelectedIndex = 0;

                MessageBox.Show("Proveedor insertado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception ex) {
                MessageBox.Show("Error al insertar proveedor: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void btnLimpiarCampos_Click(object sender, RoutedEventArgs e)
        {
            // Limpia los campos de TextBox
            txtNIT.Clear();
            txtNombreCompañia.Clear();
            txtNombreEncargado.Clear();
            txtTelefonoEncargado.Clear();
            txtDireccion.Clear();
            txtEmail.Clear();

            // Establece el ComboBox en "Habilitado" (asumiendo que "Habilitado" es el primer elemento en el ComboBox)
            comboBoxEstado.SelectedIndex = 0;
        }
    }
}

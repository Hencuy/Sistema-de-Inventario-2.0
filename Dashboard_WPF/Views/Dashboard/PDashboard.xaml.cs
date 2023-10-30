using Dashboard_WPF.Modelos;
using Dashboard_WPF.Views.Categorias;
using Dashboard_WPF.Views.Clientes;
using Dashboard_WPF.Views.Compras;
using Dashboard_WPF.Views.Kardex;
using Dashboard_WPF.Views.Productos;
using Dashboard_WPF.Views.Proveedores;
using Dashboard_WPF.Views.Reportes;
using Dashboard_WPF.Views.Usuarios;
using Dashboard_WPF.Views.Ventas;
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

namespace Dashboard_WPF.Views.Dashboard
{
    /// <summary>
    /// Lógica de interacción para PDashboard.xaml
    /// </summary>
    public partial class PDashboard : Page
    {
        //WIIIII
        public Frame mainFrame;

        VPCategoria vpCategorias = new VPCategoria();
        VPClientes vpClientes = new VPClientes();
        VPCompras vpCompras = new VPCompras();
        VPKardex vpKardex = new VPKardex();
        VPProductos vpProductos = new VPProductos();
        VPProveedores vpProveedores = new VPProveedores();
        VPReportes vpReportes = new VPReportes();
        VPUsuarios vpUsuarios = new VPUsuarios();
        VPVentas vpVentas = new VPVentas();

        SqlConnection conexion = new SqlConnection("Server= (LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true; TrustServerCertificate=True");


        public PDashboard(Frame myframe, string nombreUsuario, string cargoUsuario)
        {
            InitializeComponent();
            mainFrame = myframe;
            // Llama a la función para actualizar el número de registros
            ActualizarNumeroRegistros();
            txtUsuario.Text = nombreUsuario;
            txtCargo.Text = cargoUsuario;
            // Supongamos que obtienes el cargo del usuario de alguna manera, por ejemplo, desde un parámetro
            //string cargoUsuario = "Cajero, Cajera"; // Cambia esto según el cargo del usuario

            if (cargoUsuario == "Cajero" || cargoUsuario == "Cajera")
            {
                // Ocultar los botones para "Cajero" o "Cajera"
                btnDashCategoria.Visibility = Visibility.Collapsed;
                btnDashProve.Visibility = Visibility.Collapsed;
                btnDashCompras.Visibility = Visibility.Visible; // Cambia según tus necesidades
                btnDashUsuarios.Visibility = Visibility.Collapsed;
                btnDashClientes.Visibility = Visibility.Visible; // Cambia según tus necesidades
                btnDashProductos.Visibility = Visibility.Visible;
                btnDashVentas.Visibility = Visibility.Visible; // Cambia según tus necesidades
                btnDashKardex.Visibility = Visibility.Collapsed;
                btnDashReportes.Visibility = Visibility.Visible; // Cambia según tus necesidades

                
            }
            else
            {
                btnDashCategoria.Visibility = Visibility.Visible;
                btnDashProve.Visibility = Visibility.Visible;
                btnDashCompras.Visibility = Visibility.Visible;
                btnDashUsuarios.Visibility = Visibility.Visible;
                btnDashClientes.Visibility = Visibility.Visible;
                btnDashProductos.Visibility = Visibility.Visible;
                btnDashVentas.Visibility = Visibility.Visible;
                btnDashKardex.Visibility = Visibility.Visible;
                btnDashReportes.Visibility = Visibility.Visible;
            }
        }

        // Agrega esta función para actualizar el número de registros en cada tabla
        private void ActualizarNumeroRegistros()
        {
            
            string consultaCategoria = "SELECT COUNT(*) FROM Categoria ;";
            string consultaProveedor = "SELECT COUNT(*) FROM Proveedor;";
            string consultaCompras = "SELECT COUNT(*) FROM DetallesCompra;";
            string consultaUsuario = "SELECT COUNT(*) FROM Usuario;";
            string consultaClientes = "SELECT COUNT(*) FROM Cliente;";
            string consultaProductos = "SELECT COUNT(*) FROM Producto;";
            string consultaVentas = "SELECT COUNT(*) FROM DetallesVenta;";
            //string consultaKardex = "SELECT COUNT(*) FROM ???;";  // Aquí debes reemplazar "???" con la tabla de Kardex
            //string consultaReportes = "SELECT COUNT(*) FROM ???;";  // Aquí debes reemplazar "???" con la tabla de Reportes
            
            conexion.Open();

            // Consulta y obtiene el número de registros en cada tabla
            int numRegistrosCategoria = EjecutarConsultaScalar(consultaCategoria);
            int numRegistrosProveedor = EjecutarConsultaScalar(consultaProveedor);
            int numRegistrosCompras = EjecutarConsultaScalar(consultaCompras);
            int numRegistrosUsuario = EjecutarConsultaScalar(consultaUsuario);
            int numRegistrosClientes = EjecutarConsultaScalar(consultaClientes);
            int numRegistrosProductos = EjecutarConsultaScalar(consultaProductos);
            int numRegistrosVentas = EjecutarConsultaScalar(consultaVentas);
            //int numRegistrosKardex = EjecutarConsultaScalar(consultaKardex);
            //int numRegistrosReportes = EjecutarConsultaScalar(consultaReportes);

            conexion.Close();

            // Actualiza los TextBlocks con el número de registros
            TxtNumCategorias.Text = numRegistrosCategoria + " Registrados";
            TxtNumProveedores.Text = numRegistrosProveedor + " Registrados";
            TxtNumCompras.Text = numRegistrosCompras + " Registrados";
            TxtNumUsuario.Text = numRegistrosUsuario + " Registrados";
            TxtNumClientes.Text = numRegistrosClientes + " Registrados";
            TxtNumProductos.Text = numRegistrosProductos + " Registrados";
            TxtNumVentas.Text = numRegistrosVentas + " Registrados";
            //TxtNumKardex.Text = numRegistrosKardex + " Registrados";
            //TxtNumReportes.Text = numRegistrosReportes + " Registrados";
        }

        // Función para ejecutar una consulta escalar y obtener un valor único
        private int EjecutarConsultaScalar(string consulta)
        {
            SqlCommand command = new SqlCommand(consulta, conexion);
            int numRegistros = (int)command.ExecuteScalar();
            return numRegistros;
        }
        private void btnDashCategoria_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(vpCategorias);
        }

        private void btnDashProve_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(vpProveedores);
        }

        private void btnDashCompras_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(vpCompras);
        }

        private void btnDashUsuarios_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(vpUsuarios);
        }

        private void btnDashClientes_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(vpClientes);
        }

        private void btnDashProductos_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(vpProductos);
        }

        private void btnDashVentas_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(vpVentas);
        }

        private void btnDashKardex_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(vpKardex);
        }

        private void btnDashReportes_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(vpReportes);
        }
    }
}

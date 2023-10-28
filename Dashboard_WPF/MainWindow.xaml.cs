using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
using Dashboard_WPF.Views;
using Dashboard_WPF.Views.Categorias;
using Dashboard_WPF.Views.Clientes;
using Dashboard_WPF.Views.Compras;
using Dashboard_WPF.Views.Dashboard;
using Dashboard_WPF.Views.Kardex;
using Dashboard_WPF.Views.Productos;
using Dashboard_WPF.Views.Proveedores;
using Dashboard_WPF.Views.Reportes;
using Dashboard_WPF.Views.Usuarios;
using Dashboard_WPF.Views.Ventas;


namespace Dashboard_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        VPCategoria vpCategorias = new VPCategoria();
        VPClientes vpClientes = new VPClientes();
        VPCompras vpCompras = new VPCompras();
        VPKardex vpKardex = new VPKardex();
        VPProductos vpProductos = new VPProductos();
        VPProveedores vpProveedores = new VPProveedores();
        VPReportes vpReportes = new VPReportes();
        VPUsuarios vpUsuarios = new VPUsuarios();
        VPVentas vpVentas = new VPVentas();

        public MainWindow(string nombreUsuario, string cargoUsuario)
        {
            InitializeComponent();
            txtUsuario.Text = nombreUsuario;
            txtCargo.Text = cargoUsuario;
            MyFrame.NavigationService.Navigate(new PDashboard(MyFrame));
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnDash_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new PDashboard(MyFrame));
        }

        private void btnCategorias_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(vpCategorias);
        }

        private void btnProvee_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(vpProveedores);
        }

        private void btnCompras_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(vpCompras);
        }

        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(vpUsuarios);
        }

        private void btnClientes_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(vpClientes);
        }

        private void btnProductos_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(vpProductos);
        }

        private void btnVentas_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(vpVentas);
        }

        private void btnKardex_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(vpKardex);
        }

        private void btnReportes_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(vpReportes);
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            // Establecer el ancho de la primera columna en 65*
            ColumnDefinition column0 = PaginaPrincipal.ColumnDefinitions[0];
            column0.Width = new GridLength(200, GridUnitType.Star);

            // Establecer el ancho de la segunda columna en 65*
            ColumnDefinition column1 = PaginaPrincipal.ColumnDefinitions[1];
            column1.Width = new GridLength(1050, GridUnitType.Star);
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            // Establecer el ancho de la primera columna en 230*
            ColumnDefinition column0 = PaginaPrincipal.ColumnDefinitions[0];
            column0.Width = new GridLength(99, GridUnitType.Star);

            // Establecer el ancho de la segunda columna en 800*
            ColumnDefinition column1 = PaginaPrincipal.ColumnDefinitions[1];
            column1.Width = new GridLength(1050, GridUnitType.Star);
        }

        private void btnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            // Obtiene el nombre de usuario y cargo
            string nombreUsuario = txtUsuario.Text;
            string cargoUsuario = txtCargo.Text;

            // Mensaje de despedida
            MessageBox.Show("Hasta luego, " + nombreUsuario + ". Cargo: " + cargoUsuario);

            // Cierra la ventana actual
            this.Close();

            // Crea una nueva instancia de la ventana de inicio de sesión
            Login ventanaLogin = new Login(); // Reemplaza "Login" con el nombre de tu ventana de inicio de sesión.

            // Muestra la ventana de inicio de sesión
            ventanaLogin.Show();
        }


    }
}

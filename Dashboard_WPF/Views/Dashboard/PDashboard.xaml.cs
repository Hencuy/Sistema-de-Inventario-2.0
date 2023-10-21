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
        public PDashboard(Frame myframe)
        {
            InitializeComponent();
            mainFrame = myframe;
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

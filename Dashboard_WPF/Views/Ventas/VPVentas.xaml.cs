using Dashboard_WPF.Views.Proveedores;
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

namespace Dashboard_WPF.Views.Ventas
{
    /// <summary>
    /// Lógica de interacción para VPVentas.xaml
    /// </summary>
    public partial class VPVentas : Page
    {
        SubVVentas1 subVVentas1 = new SubVVentas1();
        SubVVentas2 subVVentas2 = new SubVVentas2();
        SubVVentas3 subVVentas3 = new SubVVentas3();
        SubVVentas4 subVVentas4 = new SubVVentas4();
        public VPVentas()
        {
            InitializeComponent();
            FrameProveedores.NavigationService.Navigate(subVVentas1);
        }

        private void btnRegistrarVenta_Click(object sender, RoutedEventArgs e)
        {
            FrameProveedores.NavigationService.Navigate(subVVentas1);
        }

        private void btnListaVenta_Click(object sender, RoutedEventArgs e)
        {
            FrameProveedores.NavigationService.Navigate(subVVentas2);
        }

        private void btnBuscarVentaFe_Click(object sender, RoutedEventArgs e)
        {
            FrameProveedores.NavigationService.Navigate(subVVentas3);
        }

        private void btnBuscarVentaCo_Click(object sender, RoutedEventArgs e)
        {
            FrameProveedores.NavigationService.Navigate(subVVentas4);
        }
    }
}

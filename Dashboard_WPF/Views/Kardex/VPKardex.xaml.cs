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

namespace Dashboard_WPF.Views.Kardex
{
    /// <summary>
    /// Lógica de interacción para VPKardex.xaml
    /// </summary>
    public partial class VPKardex : Page
    {
        SubVKardex1 subVKardex1 = new SubVKardex1();
        SubVKardex2 subVKardex2 = new SubVKardex2();
        SubVKardex3 subVKardex3 = new SubVKardex3();
        public VPKardex()
        {
            InitializeComponent();
            FrameProveedores.NavigationService.Navigate(subVKardex1);
        }

        private void btnKardexGeneral_Click(object sender, RoutedEventArgs e)
        {
            FrameProveedores.NavigationService.Navigate(subVKardex1);
        }

        private void btnBuscarKardex_Click(object sender, RoutedEventArgs e)
        {
            FrameProveedores.NavigationService.Navigate(subVKardex2);
        }

        private void btnKardexProducto_Click(object sender, RoutedEventArgs e)
        {
            FrameProveedores.NavigationService.Navigate(subVKardex3);
        }
    }
}

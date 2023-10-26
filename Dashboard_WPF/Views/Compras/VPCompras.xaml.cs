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

namespace Dashboard_WPF.Views.Compras
{
    /// <summary>
    /// Lógica de interacción para VPCompras.xaml
    /// </summary>
    public partial class VPCompras : Page
    {
        SubVCompras1 subVCompras1 = new SubVCompras1 ();
       
        SubVCompras3 subVCompras3 = new SubVCompras3 ();
        public VPCompras()
        {
            InitializeComponent();
            FrameCompras.NavigationService.Navigate(subVCompras1);
        }

        private void btnRegistrarCompra_Click(object sender, RoutedEventArgs e)
        {
            Titulo.Text = "NUEVA COMPRA";
            Icono.Kind = MaterialDesignThemes.Wpf.PackIconKind.Shopping;
            FrameCompras.NavigationService.Navigate(subVCompras1);
        }

        private void btnListaCompras_Click(object sender, RoutedEventArgs e)
        {
            Titulo.Text = "COMPRAS REALIZADAS";
            Icono.Kind = MaterialDesignThemes.Wpf.PackIconKind.ListBox;
            FrameCompras.NavigationService.Navigate(new SubVCompras2(FrameCompras));
        }

        private void btnBuscarCompra_Click(object sender, RoutedEventArgs e)
        {
            Titulo.Text = "BUSCAR COMPRA";
            Icono.Kind = MaterialDesignThemes.Wpf.PackIconKind.Magnify;
            FrameCompras.NavigationService.Navigate(subVCompras3);
        }
    }
}

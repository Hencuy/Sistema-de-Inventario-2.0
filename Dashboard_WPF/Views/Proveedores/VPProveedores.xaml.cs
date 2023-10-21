using Dashboard_WPF.Views.Categorias;
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

namespace Dashboard_WPF.Views.Proveedores
{
    /// <summary>
    /// Lógica de interacción para VPProveedores.xaml
    /// </summary>
    public partial class VPProveedores : Page
    {
        SubVProveedores1 subVProveedores1 = new SubVProveedores1();
       
        SubVProveedores3 subVProveedores3 = new SubVProveedores3();
        public VPProveedores()
        {
            InitializeComponent();
            FrameProveedores.NavigationService.Navigate(subVProveedores1);
        }

        private void btnRegistrarProvee_Click(object sender, RoutedEventArgs e)
        {
            FrameProveedores.NavigationService.Navigate(subVProveedores1);
        }

        private void btnListaProvee_Click(object sender, RoutedEventArgs e)
        {
            FrameProveedores.NavigationService.Navigate(new SubVProveedores2(FrameProveedores));
        }

        private void btnBuscarProvee_Click(object sender, RoutedEventArgs e)
        {
            FrameProveedores.NavigationService.Navigate(subVProveedores3);
        }
    }
}

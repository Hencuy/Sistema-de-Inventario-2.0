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

namespace Dashboard_WPF.Views.Clientes
{
    /// <summary>
    /// Lógica de interacción para VPClientes.xaml
    /// </summary>
    public partial class VPClientes : Page
    {
        SubVClientes1 subVClientes1 = new SubVClientes1();
        //SubVClientes2 subVClientes2 = new SubVClientes2();
        //SubVClientes3 subVClientes3 = new SubVClientes3();
        public VPClientes()
        {
            InitializeComponent();
            FrameClientes.NavigationService.Navigate(subVClientes1);
        }

        private void CL1_Click(object sender, RoutedEventArgs e)
        {
            FrameClientes.NavigationService.Navigate(subVClientes1);
        }

        private void CL2_Click(object sender, RoutedEventArgs e)
        {
            FrameClientes.NavigationService.Navigate(new SubVClientes2(FrameClientes));
        }

        private void CL3_Click(object sender, RoutedEventArgs e)
        {
            FrameClientes.NavigationService.Navigate(new SubVClientes3(FrameClientes));

        }
    }
}

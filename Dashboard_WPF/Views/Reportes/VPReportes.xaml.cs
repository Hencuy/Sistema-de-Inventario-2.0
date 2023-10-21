using Dashboard_WPF.Views.Kardex;
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

namespace Dashboard_WPF.Views.Reportes
{
    /// <summary>
    /// Lógica de interacción para VPReportes.xaml
    /// </summary>
    public partial class VPReportes : Page
    {
        SubVReportes1 subVReportes1 = new SubVReportes1();
        SubVReportes2 subVReportes2 = new SubVReportes2();
        SubVReportes3 subVReportes3 = new SubVReportes3();
        public VPReportes()
        {
            InitializeComponent();
            FrameProveedores.NavigationService.Navigate(subVReportes1);
        }

        private void btnReporteGeneral_Click(object sender, RoutedEventArgs e)
        {
            FrameProveedores.NavigationService.Navigate(subVReportes1);
        }

        private void btnReporteInven_Click(object sender, RoutedEventArgs e)
        {
            FrameProveedores.NavigationService.Navigate(subVReportes2);
        }

        private void btnReporteCosto_Click(object sender, RoutedEventArgs e)
        {
            FrameProveedores.NavigationService.Navigate(subVReportes3);
        }
    }
}

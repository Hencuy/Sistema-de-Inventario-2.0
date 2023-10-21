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

namespace Dashboard_WPF.Views.Categorias
{
    /// <summary>
    /// Lógica de interacción para VPCategoria.xaml
    /// </summary>
    public partial class VPCategoria : Page
    {
        subVCategoraias1 subVCategoraias1 = new subVCategoraias1();
        subVCategoraias2 subVCategoraias2 = new subVCategoraias2();
        subVCategoraias3 subVCategoraias3 = new subVCategoraias3();
        public VPCategoria()
        {
            InitializeComponent();
            FrameCategorias.NavigationService.Navigate(subVCategoraias1);
        }

        private void C1_Click(object sender, RoutedEventArgs e)
        {
            FrameCategorias.NavigationService.Navigate(subVCategoraias1);
        }

        private void C2_Click(object sender, RoutedEventArgs e)
        {
            FrameCategorias.NavigationService.Navigate(subVCategoraias2);
        }

        private void C3_Click(object sender, RoutedEventArgs e)
        {
            FrameCategorias.NavigationService.Navigate(subVCategoraias3);
        }
    }
}

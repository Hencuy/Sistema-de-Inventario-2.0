using Dashboard_WPF.Views.Clientes;
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

namespace Dashboard_WPF.Views.Usuarios
{
    /// <summary>
    /// Lógica de interacción para VPUsuarios.xaml
    /// </summary>
    public partial class VPUsuarios : Page
    {
        SubVUsuario1 subVUsuario1 = new SubVUsuario1();
        //SubVClientes2 subVClientes2 = new SubVClientes2();
        //SubVClientes3 subVClientes3 = new SubVClientes3();
        public VPUsuarios()
        {
            InitializeComponent();
            FrameUsuario.NavigationService.Navigate(subVUsuario1);
        }

        private void CL1_Click(object sender, RoutedEventArgs e)
        {
            FrameUsuario.NavigationService.Navigate(subVUsuario1);
        }

        private void CL2_Click(object sender, RoutedEventArgs e)
        {
            FrameUsuario.NavigationService.Navigate(new SubVUsuario2(FrameUsuario));
        }

        private void CL3_Click(object sender, RoutedEventArgs e)
        {
            FrameUsuario.NavigationService.Navigate(new SubVUsuario3(FrameUsuario));

        }
    }
}

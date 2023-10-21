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
    /// Lógica de interacción para SubVCompras1.xaml
    /// </summary>
    public partial class SubVCompras1 : Page
    {
       
        public SubVCompras1()
        {
            InitializeComponent();
        }

        private void btnVerificarProducto_Click(object sender, RoutedEventArgs e)
        {
            VEmergente vEmergente = new VEmergente();
            vEmergente.Show();
        }
    }
}

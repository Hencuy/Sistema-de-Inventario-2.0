using Dashboard_WPF.Views.Categorias;
using Dashboard_WPF.Views.Dashboard;
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

namespace Dashboard_WPF.Views.Productos
{
    /// <summary>
    /// Lógica de interacción para VPProductos.xaml
    /// </summary>
    public partial class VPProductos : Page
    {
        Sub_BuscarProducto buscarProducto = new Sub_BuscarProducto();
        
        Sub_MasVendido masVendido = new Sub_MasVendido();
        Sub_NuevoProducto nuevoProducto = new Sub_NuevoProducto();
        Sub_PorCategorias porCategorias = new Sub_PorCategorias();
        Sub_PorVencimiento porVencimiento = new Sub_PorVencimiento();
        Sub_StockMinimo stockMinimo = new Sub_StockMinimo();
        public VPProductos()
        {
            InitializeComponent();
        }

        private void btnNuevoProducto_Click(object sender, RoutedEventArgs e)
        {
            FrameProductos.NavigationService.Navigate(nuevoProducto);
        }

        private void btnEnAlmacen_Click(object sender, RoutedEventArgs e)
        {
            Sub_EnAlmacen enAlmacen = new Sub_EnAlmacen();
            FrameProductos.NavigationService.Navigate(enAlmacen);
        }

        private void btnMasVendidos_Click(object sender, RoutedEventArgs e)
        {
            FrameProductos.NavigationService.Navigate(masVendido);
        }

        private void btnPorCategoria_Click(object sender, RoutedEventArgs e)
        {
            FrameProductos.NavigationService.Navigate(porCategorias);
        }

        private void btnPorVencimiento_Click(object sender, RoutedEventArgs e)
        {
            FrameProductos.NavigationService.Navigate(porVencimiento);
        }

        private void btnStockMinimo_Click(object sender, RoutedEventArgs e)
        {
            FrameProductos.NavigationService.Navigate(stockMinimo);
        }
    }
}

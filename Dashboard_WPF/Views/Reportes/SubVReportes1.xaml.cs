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
    /// Interaction logic for SubVReportes1.xaml
    /// </summary>
    public partial class SubVReportes1 : Page
    {
        private generarPDF generadorPDF;
        public SubVReportes1()
        {
            InitializeComponent();
            generadorPDF = new generarPDF();
        }

        private void btnGenerarPDF_Click(object sender, RoutedEventArgs e)
        {
            string defaultFileName = "Informe.pdf";
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.FileName = defaultFileName;
            saveFileDialog.Filter = "Archivos PDF|*.pdf";
            saveFileDialog.DefaultExt = "pdf";
            bool? result = saveFileDialog.ShowDialog();

            if (result == true)
            {
                string filePath = saveFileDialog.FileName;
                generadorPDF.GenerarPDF(filePath, "valor1", "valor2", "valor3", "valor4", "valor5", "valor6", "valor7", "valor8", "valor9", "valor10", "valor11");
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public class Reporte
    {
        public long CodigoBarra { get; set; }
        public string Nombre { get; set; }
        public int StockExistencia { get; set; }
        public long CostoInventario { get; set; }
    }
    public partial class SubVReportes3 : Page
    {
        public SubVReportes3()
        {
            InitializeComponent();
        }

        private void pdfGenerar_Click(object sender, RoutedEventArgs e)
        {
            string ugu = "";
            List<Reporte> inventarios = new List<Reporte>();

            string connectionString = "Server=(LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true;TrustServerCertificate=True";

            int indiceSeleccionado = ComboEstado.SelectedIndex;
            switch (indiceSeleccionado)
            {
                case 0:
                    ugu = "Nombre";
                    break;
                case 1:
                    ugu = "StockExistencia";
                    break;
            }
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                string consulta = @"
                SELECT CodigoBarra, Nombre, StockExistencia,
                  (StockExistencia * PrecioCompra) AS [Costo Inventario]
                FROM Producto
                ORDER BY " + ugu + ";";

                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Reporte inventario = new Reporte();
                            inventario.CodigoBarra = reader["CodigoBarra"] != DBNull.Value ? (long)reader["CodigoBarra"] : 0;
                            inventario.Nombre = reader["Nombre"] != DBNull.Value ? reader["Nombre"].ToString() : string.Empty;
                            inventario.StockExistencia = reader["StockExistencia"] != DBNull.Value ? (int)reader["StockExistencia"] : 0;
                            inventario.CostoInventario = reader["Costo Inventario"] != DBNull.Value ? (long)reader["Costo Inventario"] : 0;
                            inventarios.Add(inventario);
                        }
                    }
                }
            }

            if (inventarios.Count > 0)
            {
                // Mostrar el cuadro de diálogo para seleccionar la ubicación y el nombre del archivo PDF
                Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
                saveFileDialog.FileName = "Informe.pdf";
                saveFileDialog.Filter = "Archivos PDF|*.pdf";
                saveFileDialog.DefaultExt = "pdf";
                bool? result = saveFileDialog.ShowDialog();

                if (result == true)
                {
                    string filePath = saveFileDialog.FileName;
                    generarPDF3 generadorPDF = new generarPDF3();
                    generadorPDF.GenerarPDF(filePath, inventarios);
                }
            }
            else
            {

            }
        }
    }
}

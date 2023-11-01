using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Dashboard_WPF.Views.Reportes
{
    public class ReporteInventario
    {
        public long CodigoBarra { get; set; }
        public string Nombre { get; set; }
        public long PrecioVenta { get; set; }
        public int StockExistencia { get; set; }
        public string Unidad { get; set; }
    }
    public partial class SubVReportes2 : Page
    {
        public SubVReportes2()
        {
            InitializeComponent();
        }

        private void BtnReporte_Click(object sender, RoutedEventArgs e)
        {
            string ugu = "";
            List<ReporteInventario> inventarios = new List<ReporteInventario>();

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
                case 2:
                    ugu = "PrecioVenta";
                    break;
                case 3:
                    ugu = "PrecioMayoreo";
                    break;
            }
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                string consulta = @"
                SELECT
                    CodigoBarra,
                    Nombre,
                    PrecioVenta,
                    StockExistencia,
                    Presentacion
                FROM Producto
                ORDER BY " + ugu + ";";

                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ReporteInventario inventario = new ReporteInventario();
                            inventario.CodigoBarra = reader["CodigoBarra"] != DBNull.Value ? (long)reader["CodigoBarra"] : 0;
                            inventario.Nombre = reader["Nombre"] != DBNull.Value ? reader["Nombre"].ToString() : string.Empty;
                            inventario.PrecioVenta = reader["PrecioVenta"] != DBNull.Value ? (long)reader["PrecioVenta"] : 0;
                            inventario.StockExistencia = reader["StockExistencia"] != DBNull.Value ? (int)reader["StockExistencia"] : 0;
                            inventario.Unidad = reader["Presentacion"] != DBNull.Value ? reader["Presentacion"].ToString() : string.Empty;
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
                    generarPDF2 generadorPDF = new generarPDF2();
                    generadorPDF.GenerarPDF(filePath, inventarios);
                }
            }
            else
            {
                
            }
        }
    }
}

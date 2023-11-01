using Dashboard_WPF.Views.Ventas;
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
    public class VentaDetalle
    {
        public string IDVenta { get; set; }
        public string FechaCompra { get; set; }
        public string HoraCompra { get; set; }
        public int TotalEnVentas { get; set; }
        public int CostoEnVentas { get; set; }
        public int Ganancias { get; set; }

    }

    public partial class SubVReportes1 : Page
    {
        private generarPDF generadorPDF;
        private List<VentaDetalle> ventas = new List<VentaDetalle>();
        SqlConnection conexion = new SqlConnection("Server=(LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true;TrustServerCertificate=True");
        public SubVReportes1()
        {
            InitializeComponent();
            generadorPDF = new generarPDF();
            CargarDatos();
            EnAlmacen.ItemsSource = ventas;
            buenDia.Text = "";
        }

        private void CargarDatos()
        {
            conexion.Open();
            string consulta = @"
            WITH VentasDetalle AS (
                SELECT
                    DV.idDetallesVenta AS IDVenta,
                    PV.PrecioVenta,
                    PV.PrecioCompra AS CostoEnVentas,
                    PV.StockSalida,
                    DV.Fecha AS FechaCompra
                FROM DetallesVenta AS DV
                JOIN ProductosVenta AS PV ON DV.idDetallesVenta = PV.idDetallesVenta
                WHERE CONVERT(DATE, DV.Fecha) = CONVERT(DATE, GETDATE())
            ),
            VentasTotales AS (
                SELECT
                    VT.IDVenta,
                    SUM(VT.PrecioVenta * VT.StockSalida) AS TotalEnVentas,
                    SUM(VT.CostoEnVentas * VT.StockSalida) AS CostoEnVentas,
                    SUM(VT.PrecioVenta * VT.StockSalida - VT.CostoEnVentas * VT.StockSalida) AS Ganancias
                FROM VentasDetalle AS VT
                GROUP BY VT.IDVenta
            )
            SELECT
                VT.IDVenta AS 'IDVenta',
                CONVERT(VARCHAR, DV.FechaCompra, 101) AS 'FechaCompra',
                CONVERT(VARCHAR, DV.FechaCompra, 108) AS 'HoraCompra',
                VT.TotalEnVentas,
                VT.CostoEnVentas,
                VT.Ganancias
            FROM VentasTotales AS VT, VentasDetalle AS DV;
            ";

            using (SqlCommand command = new SqlCommand(consulta, conexion))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VentaDetalle venta = new VentaDetalle();
                        venta.IDVenta = reader["IDVenta"] != DBNull.Value ? reader["IDVenta"].ToString() : string.Empty;
                        venta.FechaCompra = reader["FechaCompra"] != DBNull.Value ? reader["FechaCompra"].ToString() : string.Empty;
                        venta.HoraCompra = reader["HoraCompra"] != DBNull.Value ? reader["HoraCompra"].ToString() : string.Empty;
                        venta.TotalEnVentas = reader["TotalEnVentas"] != DBNull.Value? (int.TryParse(reader["TotalEnVentas"].ToString(), out int totalEnVentas) ? totalEnVentas : 0) : 0;
                        venta.CostoEnVentas = reader["CostoEnVentas"] != DBNull.Value ?(int.TryParse(reader["CostoEnVentas"].ToString(), out int costoEnVentas) ? costoEnVentas : 0) : 0;
                        venta.Ganancias = reader["Ganancias"] != DBNull.Value ?(int.TryParse(reader["Ganancias"].ToString(), out int ganancias) ? ganancias : 0) : 0;
                        ventas.Add(venta);
                    }
                }
            }
        }

        private void GenerarReporte_Click(object sender, RoutedEventArgs e)
        {
            DateTime? fechaInicial = FechaInicial.SelectedDate;
            DateTime? fechaFinal = FechaFinal.SelectedDate;

            if (fechaInicial != null && fechaFinal != null)
            {
                string formato = "yyyy-MM-dd HH:mm:ss";
                string fechaInicioSQL = fechaInicial.Value.ToString(formato);
                string fechaFinSQL = fechaFinal.Value.ToString(formato);

                // Crear la lista de ventas
                List<VentaDetalle> ventas = new List<VentaDetalle>();

                using (SqlConnection conexion = new SqlConnection("Server= (LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true; TrustServerCertificate=True"))
                {
                    conexion.Open();
                    string consulta = @"
WITH VentasDetalle AS (
    SELECT
        DV.idDetallesVenta,
        PV.PrecioVenta,
        PV.PrecioCompra,
        PV.StockSalida,
        DV.Fecha
    FROM DetallesVenta AS DV
    JOIN ProductosVenta AS PV ON DV.idDetallesVenta = PV.idDetallesVenta
    WHERE DV.Fecha >= @FechaInicio AND DV.Fecha <= @FechaFin
),
VentasTotales AS (
    SELECT
        VT.idDetallesVenta,
        SUM(VT.PrecioVenta * VT.StockSalida) AS TotalVenta,
        SUM(VT.PrecioCompra * VT.StockSalida) AS CostoVenta
    FROM VentasDetalle AS VT
    GROUP BY VT.idDetallesVenta
)
SELECT
    VT.idDetallesVenta AS 'ID Venta',
    VT.TotalVenta AS 'Total en Ventas',
    VT.CostoVenta AS 'Costo en Ventas',
    VT.TotalVenta - VT.CostoVenta AS 'Ganancias',
    CONVERT(VARCHAR, DV.Fecha, 101) AS 'Fecha de Compra',
    CONVERT(VARCHAR, DV.Fecha, 108) AS 'Hora de Compra'
FROM VentasTotales AS VT, DetallesVenta as DV
ORDER BY DV.Fecha;
        ";
                    using (SqlCommand command = new SqlCommand(consulta, conexion))
                    {
                        command.Parameters.AddWithValue("@FechaInicio", fechaInicioSQL);
                        command.Parameters.AddWithValue("@FechaFin", fechaFinSQL);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VentaDetalle venta = new VentaDetalle();
                                venta.IDVenta = reader["ID Venta"] != DBNull.Value ? reader["ID Venta"].ToString() : string.Empty;
                                venta.FechaCompra = reader["Fecha de Compra"] != DBNull.Value ? reader["Fecha de Compra"].ToString() : string.Empty;
                                venta.HoraCompra = reader["Hora de Compra"] != DBNull.Value ? reader["Hora de Compra"].ToString() : string.Empty;
                                venta.TotalEnVentas = reader["Total en Ventas"] != DBNull.Value ? (int.TryParse(reader["Total en Ventas"].ToString(), out int totalEnVentas) ? totalEnVentas : 0) : 0;
                                venta.CostoEnVentas = reader["Costo en Ventas"] != DBNull.Value ? (int.TryParse(reader["Costo en Ventas"].ToString(), out int costoEnVentas) ? costoEnVentas : 0) : 0;
                                venta.Ganancias = reader["Ganancias"] != DBNull.Value ? (int.TryParse(reader["Ganancias"].ToString(), out int ganancias) ? ganancias : 0) : 0;
                                ventas.Add(venta);
                            }
                        }
                    }
                }

                if (ventas.Count > 0)
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
                        generarPDF generadorPDF = new generarPDF();
                        generadorPDF.GenerarPDF(filePath, ventas);
                    }
                }
                else
                {
                    // Manejo de error si no hay datos para mostrar
                }
            }
            else
            {
                // Manejo de error si las fechas son nulas
            }
        }



        private void CargarDatosFecha(string fechaInicio, string fechaFin)
        {
            EnAlmacen.ItemsSource = null;
            conexion.Close();
            conexion.Open();
            string consulta = @"
            WITH VentasDetalle AS (
                SELECT
                    DV.idDetallesVenta,
                    PV.PrecioVenta,
                    PV.PrecioCompra,
                    PV.StockSalida,
                    DV.Fecha
                FROM DetallesVenta AS DV
                JOIN ProductosVenta AS PV ON DV.idDetallesVenta = PV.idDetallesVenta
                WHERE DV.Fecha >= @FechaInicio AND DV.Fecha <= @FechaFin
            ),
            VentasTotales AS (
                SELECT
                    VT.idDetallesVenta,
                    SUM(VT.PrecioVenta * VT.StockSalida) AS TotalVenta,
                    SUM(VT.PrecioCompra * VT.StockSalida) AS CostoVenta
                FROM VentasDetalle AS VT
                GROUP BY VT.idDetallesVenta
            )
            SELECT
                VT.idDetallesVenta AS 'ID Venta',
                VT.TotalVenta AS 'Total en Ventas',
                VT.CostoVenta AS 'Costo en Ventas',
                VT.TotalVenta - VT.CostoVenta AS 'Ganancias',
                CONVERT(VARCHAR, DV.Fecha, 101) AS 'Fecha de Compra',
                CONVERT(VARCHAR, DV.Fecha, 108) AS 'Hora de Compra'
            FROM VentasTotales AS VT, DetallesVenta as DV;
            ";

            using (SqlCommand command = new SqlCommand(consulta, conexion))
            {
                command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                command.Parameters.AddWithValue("@FechaFin", fechaFin);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VentaDetalle venta = new VentaDetalle();
                        venta.IDVenta = reader["ID Venta"] != DBNull.Value ? reader["ID Venta"].ToString() : string.Empty;
                        venta.FechaCompra = reader["Fecha de Compra"] != DBNull.Value ? reader["Fecha de Compra"].ToString() : string.Empty;
                        venta.HoraCompra = reader["Hora de Compra"] != DBNull.Value ? reader["Hora de Compra"].ToString() : string.Empty;
                        venta.TotalEnVentas = reader["Total en Ventas"] != DBNull.Value ? (int.TryParse(reader["Total en Ventas"].ToString(), out int totalEnVentas) ? totalEnVentas : 0) : 0;
                        venta.CostoEnVentas = reader["Costo en Ventas"] != DBNull.Value ? (int.TryParse(reader["Costo en Ventas"].ToString(), out int costoEnVentas) ? costoEnVentas : 0) : 0;
                        venta.Ganancias = reader["Ganancias"] != DBNull.Value ? (int.TryParse(reader["Ganancias"].ToString(), out int ganancias) ? ganancias : 0) : 0;
                        ventas.Add(venta);
                    }
                }
            }
        }

        private void btnGenerarPDF_Click(object sender, RoutedEventArgs e)
        {
            string defaultFileName = "Informe.pdf";
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.FileName = defaultFileName;
            saveFileDialog.Filter = "Archivos PDF|*.pdf";
            saveFileDialog.DefaultExt = "pdf";
            bool? result = saveFileDialog.ShowDialog();

            /*if (result == true)
            {
                string filePath = saveFileDialog.FileName;
                generadorPDF.GenerarPDF(filePath, "valor1", "valor2", "valor3", "valor4", "valor5", "valor6", "valor7", "valor8", "valor9", "valor10", "valor11");
            }*/
        }
    }
}

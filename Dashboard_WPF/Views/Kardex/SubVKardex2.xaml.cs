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

namespace Dashboard_WPF.Views.Kardex
{
    /// <summary>
    /// Interaction logic for SubVKardex2.xaml
    /// </summary>
    public partial class SubVKardex2 : Page
    {
        private string connectionString = "Server= (LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true; TrustServerCertificate=True";

        public SubVKardex2()
        {
            InitializeComponent();
        }

        public class KardexItem
        {
            public int Number { get; set; }
            public long CodigoBarraProducto { get; set; }
            public int Anio { get; set; }
            public int Mes { get; set; }
            public string Producto { get; set; }
            public int Entrada { get; set; }
            public string TotalCompras { get; set; }
            public int Salida { get; set; }
            public string TotalVentas { get; set; }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtMes.Text, out int mes) && int.TryParse(txtAño.Text, out int anio))
            {
                List<KardexItem> kardexItems = new List<KardexItem>();

                string query = @"
                    -- Tu consulta aquí
                    -- Declaración de variables
                    DECLARE @Anio INT = @AnioParam; -- Aquí debes proporcionar el año deseado
                    DECLARE @Mes INT = @MesParam; -- Aquí debes proporcionar el mes deseado

                    -- Kardex de Compras y Ventas por Mes y Año (Para todos los productos con entrada o salida)
                    SELECT
                        P.CodigoBarra AS CodigoBarraProducto,
                        YEAR(Mes) AS Anio,
                        MONTH(Mes) AS Mes,
                        P.Nombre AS Producto,
                        SUM(CASE WHEN Tipo = 'Compra' THEN Cantidad ELSE 0 END) AS Entrada,
                        SUM(CASE WHEN Tipo = 'Compra' THEN Total ELSE 0 END) AS TotalCompras,
                        SUM(CASE WHEN Tipo = 'Venta' THEN Cantidad ELSE 0 END) AS Salida,
                        SUM(CASE WHEN Tipo = 'Venta' THEN Total ELSE 0 END) AS TotalVentas
                    FROM Producto AS P
                    LEFT JOIN (
                        SELECT PC.idProducto, DC.Fecha AS Mes, 'Compra' AS Tipo, PC.StockEntrada AS Cantidad, PC.PrecioCompra * PC.StockEntrada AS Total
                        FROM ProductosCompra AS PC
                        JOIN DetallesCompra AS DC ON PC.idDetallesCompra = DC.idDetallesCompra
                        UNION ALL
                        SELECT PV.idProducto, DV.Fecha AS Mes, 'Venta' AS Tipo, PV.StockSalida AS Cantidad, PV.PrecioVenta * PV.StockSalida AS Total
                        FROM ProductosVenta AS PV
                        JOIN DetallesVenta AS DV ON PV.idDetallesVenta = DV.idDetallesVenta
                    ) AS Movimientos ON P.CodigoBarra = Movimientos.idProducto
                    WHERE YEAR(Mes) = @AnioParam
                        AND MONTH(Mes) = @MesParam
                    GROUP BY P.CodigoBarra, YEAR(Mes), MONTH(Mes), P.Nombre
                    HAVING SUM(CASE WHEN Tipo = 'Compra' THEN Cantidad ELSE 0 END) > 0 OR SUM(CASE WHEN Tipo = 'Venta' THEN Cantidad ELSE 0 END) > 0
                    ORDER BY CodigoBarraProducto, Anio, Mes;
                ";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AnioParam", anio);
                        command.Parameters.AddWithValue("@MesParam", mes);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int number = 1;
                            while (reader.Read())
                            {
                                KardexItem item = new KardexItem
                                {
                                    Number = number,
                                    CodigoBarraProducto = Convert.ToInt64(reader["CodigoBarraProducto"]),
                                    Anio = Convert.ToInt32(reader["Anio"]),
                                    Mes = Convert.ToInt32(reader["Mes"]),
                                    Producto = reader["Producto"].ToString(),
                                    Entrada = Convert.ToInt32(reader["Entrada"]),
                                    TotalCompras = reader["TotalCompras"].ToString() + " $",
                                    Salida = Convert.ToInt32(reader["Salida"]),
                                    TotalVentas = reader["TotalVentas"].ToString() + " $"
                                };
                                kardexItems.Add(item);
                                number++;
                            }
                        }
                    }
                }

                TablaBuscador1.ItemsSource = kardexItems;
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un mes y un año válidos.");
            }
        }
    }
}

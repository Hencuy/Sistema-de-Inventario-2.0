using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;

namespace Dashboard_WPF.Views.Ventas
{
    public partial class SubVVentas3 : Page
    {
        public SubVVentas3()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            // Obtener las fechas seleccionadas en los DatePicker
            DateTime fechaInicial = FechaInicialPicker.SelectedDate ?? DateTime.MinValue;
            DateTime fechaFinal = FechaFinalPicker.SelectedDate ?? DateTime.MaxValue;

            // Realizar una consulta a la base de datos para obtener datos de ProductosVenta con la fecha correspondiente de DetallesVenta
            string consulta = @"
                SELECT PV.idProductosVenta, PV.PrecioCompra, PV.PrecioVenta, PV.PrecioMayoreo, PV.idProducto, DV.Fecha, PV.StockSalida
                FROM ProductosVenta AS PV
                INNER JOIN DetallesVenta AS DV ON PV.idDetallesVenta = DV.idDetallesVenta
                WHERE DV.Fecha BETWEEN @FechaInicial AND @FechaFinal
            ";

            using (SqlConnection conexion = new SqlConnection("Server=(LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true; TrustServerCertificate=True"))
            {
                conexion.Open();
                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@FechaInicial", fechaInicial);
                    command.Parameters.AddWithValue("@FechaFinal", fechaFinal);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Limpiar el DataGrid
                        VentasDataGrid.Items.Clear();
                        while (reader.Read())
                        {
                            // Agregar datos al DataGrid
                            VentasDataGrid.Items.Add(new
                            {
                                idProductosVenta = reader["idProductosVenta"],
                                PrecioCompra = reader["PrecioCompra"],
                                PrecioVenta = reader["PrecioVenta"],
                                PrecioMayoreo = reader["PrecioMayoreo"],
                                idProducto = reader["idProducto"],
                                Fecha = reader["Fecha"],
                                StockSalida = reader["StockSalida"]
                            });
                        }
                    }
                }
            }
        }
    }
}

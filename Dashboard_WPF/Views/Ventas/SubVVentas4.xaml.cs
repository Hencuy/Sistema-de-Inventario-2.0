using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Dashboard_WPF.Views.Ventas
{
    public partial class SubVVentas4 : Page
    {
        public SubVVentas4()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            string codigoVenta = ugu.Text;

            if (string.IsNullOrEmpty(codigoVenta))
            {
                MessageBox.Show("Por favor, ingrese un código de venta.");
                return;
            }

            // Realizar una consulta a la base de datos utilizando el código de venta
            string consulta = "SELECT * FROM DetallesVenta INNER JOIN ProductosVenta ON DetallesVenta.idDetallesVenta = ProductosVenta.idDetallesVenta WHERE ProductosVenta.idProductosVenta = @CodigoVenta";

            using (SqlConnection conexion = new SqlConnection("Server=(LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true; TrustServerCertificate=True"))
            {
                conexion.Open();
                using (SqlCommand command = new SqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@CodigoVenta", codigoVenta);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Limpiar el DataGrid
                        VentasDataGrid.Items.Clear();

                        while (reader.Read())
                        {
                            // Agregar los resultados al DataGrid
                            VentasDataGrid.Items.Add(new
                            {
                                idProductosVenta = reader["idProductosVenta"],
                                PrecioCompra = reader["PrecioCompra"],
                                PrecioVenta = reader["PrecioVenta"],
                                PrecioMayoreo = reader["PrecioMayoreo"],
                                idProducto = reader["idProducto"],
                                idDetallesVenta = reader["idDetallesVenta"],
                                StockSalida = reader["StockSalida"],
                                Fecha = reader["Fecha"]
                            });
                        }
                    }
                }
            }
        }
    }
}

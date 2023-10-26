using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace Dashboard_WPF.Views.Ventas
{
    public partial class SubVVentas2 : Page
    {
        public SubVVentas2()
        {
            InitializeComponent();
            CargarDatosVentas();
        }

        private void CargarDatosVentas()
        {
            // Utiliza tu cadena de conexión existente.
            string connectionString = "Server=(LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true;TrustServerCertificate=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string consulta = "SELECT idProductosVenta, PrecioCompra, PrecioVenta, PrecioMayoreo, idProducto, idDetallesVenta, StockSalida FROM ProductosVenta";

                using (SqlCommand command = new SqlCommand(consulta, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        VentasDataGrid.ItemsSource = dataTable.DefaultView;
                    }
                }
            }
        }
    }
}

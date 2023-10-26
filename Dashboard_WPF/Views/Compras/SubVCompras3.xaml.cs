using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Lógica de interacción para SubVCompras3.xaml
    /// </summary>
    public partial class SubVCompras3 : Page
    {
        public SubVCompras3()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (dtpFechaInicio.SelectedDate.HasValue && dtpFechaFinal.SelectedDate.HasValue)
            {
                DateTime fechaInicio = dtpFechaInicio.SelectedDate.Value;
                DateTime fechaFinal = dtpFechaFinal.SelectedDate.Value;

                using (SqlConnection connection = new SqlConnection("Server= (LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true; TrustServerCertificate=True"))
                {
                    connection.Open();

                    string query = "SELECT dc.idDetallesCompra, dc.Fecha, dc.Total, p.NombreCompañia " +
                                   "FROM DetallesCompra dc " +
                                   "INNER JOIN Proveedor p ON dc.idProveedor = p.NIT " +
                                   "WHERE dc.Fecha BETWEEN @FechaInicio AND @FechaFinal";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFinal", fechaFinal);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    TablaBuscarCompra.ItemsSource = dataTable.DefaultView;
                }
            }
            else
            {
                MessageBox.Show("Es obligatorio que ingrese una fecha inicial y final.");
            }
        }
    }
}

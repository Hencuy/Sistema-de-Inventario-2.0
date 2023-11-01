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

namespace Dashboard_WPF.Views.Categorias
{
    /// <summary>
    /// Lógica de interacción para subVCategoraias3.xaml
    /// </summary>
    public partial class subVCategoraias3 : Page
    {
        SqlConnection conexion = new SqlConnection("Server= (LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true; TrustServerCertificate=True");

        public subVCategoraias3()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombreCat.Text;
            string consulta;

            if (nombre != "")
            {

                consulta = "Select Nombre,Ubicacion,Estado from Categoria Where Nombre = '"+nombre+"'";
                conexion.Open();
                SqlCommand command = new SqlCommand(consulta, conexion);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                System.Data.DataTable dataTable = new System.Data.DataTable();
                dataAdapter.Fill(dataTable);
                dataTable.Columns.Add("Number", typeof(int));
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    dataTable.Rows[i]["Number"] = i + 1;

                }
                // Agregar columna de enumeración


                tablaCategoriasBuscar.ItemsSource = dataTable.DefaultView;
                conexion.Close();
            }
            else
            {
                MessageBox.Show("Introduzca algo");
            }

            txtNombreCat.Clear();
        }


    }
}

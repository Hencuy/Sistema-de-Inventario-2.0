using Dashboard_WPF.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Dashboard_WPF.Views.Productos
{
    public partial class Sub_MasVendido : Page
    {
        public class ProductoMasVendido
        {
            public long CodigoBarra { get; set; }
            public string Nombre { get; set; }
            public string Presentacion { get; set; }
            public string Marca { get; set; }
            public string Modelo { get; set; }
            public int StockExistencia { get; set; }
            public int StockMinimo { get; set; }
            public long PrecioCompra { get; set; }
            public long PrecioVenta { get; set; }
            public long PrecioMayoreo { get; set; }
            public long Descuento { get; set; }
            public bool TieneVencimiento { get; set; }
            public DateTime? FechaVencimiento { get; set; }
            public int Estado { get; set; }
            public byte[] Foto { get; set; }
            public long idProveedor { get; set; }
            public int idCategoria { get; set; }
            public int TotalVendido { get; set; }
        }

        SqlConnection conexion = new SqlConnection("Server=(LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true; TrustServerCertificate=True");

        public Sub_MasVendido()
        {
            InitializeComponent();
            LoadTopSellingProducts();
        }

        private void LoadTopSellingProducts()
        {
            Categorias.Items.Clear();
            try
            {
                conexion.Open();

                string consulta = @"SELECT
                                    P.*,
                                    SUM(PV.StockSalida) AS TotalVendido
                                FROM
                                    Producto AS P
                                JOIN
                                    ProductosVenta AS PV
                                ON
                                    P.CodigoBarra = PV.idProducto
                                GROUP BY
                                    P.CodigoBarra, P.Nombre, P.Presentacion, P.Marca, P.Modelo, P.StockExistencia, P.StockMinimo, P.PrecioCompra, P.PrecioVenta, P.PrecioMayoreo, P.Descuento, P.TieneVencimiento, P.FechaVencimiento, P.Estado, P.Foto, P.idProveedor, P.idCategoria
                                ORDER BY
                                    TotalVendido DESC;";

                SqlCommand command = new SqlCommand(consulta, conexion);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ProductoMasVendido producto = new ProductoMasVendido
                    {
                        CodigoBarra = (long)reader["CodigoBarra"],
                        Nombre = reader["Nombre"].ToString(),
                        Presentacion = reader["Presentacion"].ToString(),
                        Marca = reader["Marca"].ToString(),
                        Modelo = reader["Modelo"].ToString(),
                        StockExistencia = (int)reader["StockExistencia"],
                        StockMinimo = (int)reader["StockMinimo"],
                        PrecioCompra = (long)reader["PrecioCompra"],
                        PrecioVenta = (long)reader["PrecioVenta"],
                        PrecioMayoreo = (long)reader["PrecioMayoreo"],
                        Descuento = (long)reader["Descuento"],
                        TieneVencimiento = (bool)reader["TieneVencimiento"],
                        FechaVencimiento = reader["FechaVencimiento"] as DateTime?,
                        Estado = (int)reader["Estado"],
                        Foto = reader["Foto"] as byte[],
                        idProveedor = (long)reader["idProveedor"],
                        idCategoria = (int)reader["idCategoria"],
                        TotalVendido = (int)reader["TotalVendido"]
                    };

                    Categorias.Items.Add(producto);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :c: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}

using Dashboard_WPF.Views.Categorias;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Dashboard_WPF.Views.Productos
{
    public partial class Sub_NuevoProducto : Page
    {
        long CodigoDeBarras = 0;
        string Nombre = "";
        string Presentacion = "";
        string Marca = "";
        string Modelo = "";
        int StockExistencia = 0;
        int StockMinimo = 0;
        long PrecioCompra = 0;
        long PrecioVenta = 0;
        long PrecioMayoreo = 0;
        long Descuento = 0;
        bool TieneVencimiento = false;
        DateTime? fechaVencimiento = null;
        int Estado = 0;
        byte[] fileBytes = new byte[0];
        long IdProveedor = 0;
        int IdCategoria = 0;

        SqlConnection conexion = new SqlConnection("Server= (LocalDB)\\MSSQLLocalDB;Database=BDInventarioVenta;Integrated Security=true; TrustServerCertificate=True");
        public Sub_NuevoProducto()
        {
            InitializeComponent(); 
            siVenceCheckBox.IsChecked = true;

            try
            {
                conexion.Open();

                string consulta = "SELECT NIT, NombreCompañia FROM Proveedor";
                SqlCommand command = new SqlCommand(consulta, conexion);
                SqlDataReader reader = command.ExecuteReader();

                ComboboxProveedor.Items.Clear();

                while (reader.Read())
                {
                    long nitProveedor = reader.GetInt64(0);
                    string nombreProveedor = reader.GetString(1);
                    ComboboxProveedor.Items.Add(new ComboBoxItem { Content = nombreProveedor, Tag = nitProveedor });
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los proveedores: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            try
            {
                conexion.Open();

                string consulta = "SELECT idCategoria, Nombre FROM Categoria";
                SqlCommand command = new SqlCommand(consulta, conexion);
                SqlDataReader reader = command.ExecuteReader();

                ComboboxCategoria.Items.Clear();

                while (reader.Read())
                {
                    int idCategoria = reader.GetInt32(0);
                    string nombreCategoria = reader.GetString(1);
                    ComboboxCategoria.Items.Add(new ComboBoxItem { Content = nombreCategoria, Tag = idCategoria });
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las categorías: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            SacarDatos();

            conexion.Open();
            string sqlQuery = "INSERT INTO Producto VALUES (@CodigoBarra, @Nombre, @Presentacion, @Marca, @Modelo, @StockExistencia, @StockMinimo, @PrecioCompra, @PrecioVenta, @PrecioMayoreo, @Descuento, @TieneVencimiento, @FechaVencimiento, @Estado, @fileBytes, @IdProveedor, @IdCategoria);";

            SqlCommand command = new SqlCommand(sqlQuery, conexion);
            command.Parameters.AddWithValue("@CodigoBarra", CodigoDeBarras);
            command.Parameters.AddWithValue("@Nombre", Nombre);
            command.Parameters.AddWithValue("@Presentacion", Presentacion);
            command.Parameters.AddWithValue("@Marca", Marca);
            command.Parameters.AddWithValue("@Modelo", Modelo);
            command.Parameters.AddWithValue("@StockExistencia", StockExistencia);
            command.Parameters.AddWithValue("@StockMinimo", StockMinimo);
            command.Parameters.AddWithValue("@PrecioCompra", PrecioCompra);
            command.Parameters.AddWithValue("@PrecioVenta", PrecioVenta);
            command.Parameters.AddWithValue("@PrecioMayoreo", PrecioMayoreo);
            command.Parameters.AddWithValue("@Descuento", Descuento);
            command.Parameters.AddWithValue("@TieneVencimiento", TieneVencimiento);
            command.Parameters.Add("@FechaVencimiento", SqlDbType.DateTime).Value = (object)fechaVencimiento ?? DBNull.Value;
            command.Parameters.AddWithValue("@Estado", Estado);

            if (fileBytes == null || fileBytes.Length == 0)
            {
                fileBytes = new byte[0];
            }

            command.Parameters.AddWithValue("@fileBytes", fileBytes);
            command.Parameters.AddWithValue("@IdProveedor", IdProveedor);
            command.Parameters.AddWithValue("@IdCategoria", IdCategoria);
            command.ExecuteNonQuery();
            conexion.Close();

            MessageBox.Show("Se ha guardado el producto");

            LimpiarXD();
        }

        private void SacarDatos()
        {
            CodigoDeBarras = Convert.ToInt64(txtCodigoBarras.Text);
            Nombre = txtNombre.Text;

            ComboBoxItem selectedItemPresentacion = (ComboBoxItem)ComboboxPresentacion.SelectedItem;
            if (selectedItemPresentacion != null)
            {
                Presentacion = selectedItemPresentacion.Content.ToString();
            }

            Marca = txtMarca.Text;
            Modelo = txtModelo.Text;
            StockExistencia = Convert.ToInt32(txtStockExistencia.Text);
            StockMinimo = Convert.ToInt32(txtStockMinimo.Text);
            PrecioCompra = Convert.ToInt32(txtPrecioCompra.Text);
            PrecioVenta = Convert.ToInt32(txtPrecioVenta.Text);
            PrecioMayoreo = Convert.ToInt32(txtPrecioMayoreo.Text);
            Descuento = Convert.ToInt32(txtDescuento.Text);

            if (siVenceCheckBox.IsChecked == true)
            {
                TieneVencimiento = true;
                fechaVencimiento = dpFechaVencimiento.SelectedDate;
            }
            else if (noVenceCheckBox.IsChecked == true)
            {
                TieneVencimiento = false;
                fechaVencimiento = null;
            }

            ComboBoxItem selectedItemEstado = (ComboBoxItem)ComboEstado.SelectedItem;
            if (selectedItemEstado != null)
            {
                string seleccion = selectedItemEstado.Content.ToString();
                if (seleccion == "Habilitado")
                {
                    Estado = 1;
                }
                else if (seleccion == "Deshabilitado")
                {
                    Estado = 0;
                }
            }

            if (ComboboxProveedor.SelectedItem != null)
            {
                ComboBoxItem selectedProveedor = (ComboBoxItem)ComboboxProveedor.SelectedItem;
                if (selectedProveedor != null)
                {
                    string nombreProveedor = selectedProveedor.Content.ToString();
                    long nitProveedor = (long)selectedProveedor.Tag;
                    IdProveedor = nitProveedor;
                }
            }

            if (ComboboxCategoria.SelectedItem != null)
            {
                ComboBoxItem selectedCategoria = (ComboBoxItem)ComboboxCategoria.SelectedItem;
                if (selectedCategoria != null)
                {
                    int idCategoria = (int)selectedCategoria.Tag;
                    IdCategoria = idCategoria;
                }
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarXD();
        }

        private void LimpiarXD()
        {
            txtCodigoBarras.Text = "";
            txtNombre.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtStockExistencia.Text = "";
            txtStockMinimo.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtPrecioMayoreo.Text = "";
            txtDescuento.Text = "";
        }

        private void btnSelecImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(filePath);

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    fileBytes = new byte[fileStream.Length];
                    fileStream.Read(fileBytes, 0, fileBytes.Length);
                }

                nombreArchivo.Text = fileName;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;

            if (checkBox.Name == "siVenceCheckBox" && siVenceCheckBox.IsChecked == true)
            {
                dpFechaVencimiento.IsEnabled = true;
                noVenceCheckBox.IsChecked = false;
            }
            else if (checkBox.Name == "noVenceCheckBox" && noVenceCheckBox.IsChecked == true)
            {
                dpFechaVencimiento.IsEnabled = false;
                siVenceCheckBox.IsChecked = false;
            }
        }
    }
}

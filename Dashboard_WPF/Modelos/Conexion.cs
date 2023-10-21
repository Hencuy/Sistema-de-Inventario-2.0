using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard_WPF.Modelos
{
    internal class Conexion
    {
        //Nombre y la base de datos que me conecto
        private string Base;
        //Cual es el servidor donde esta alojado mi servidor
        private string Servidor;
        //Usuario para acceder a la base de datos
        private string Usuario;
        //Contraseña
        private string Clave;
        //De que manera se trabaja la seguridad Autentificacion windows o SQL
        private bool Seguridad;

        private static Conexion Con = null;
        public Conexion()
        {
            this.Base = "BDInventarioVenta";
            this.Servidor = "(localdb)\\mssqllocaldb";
            this.Usuario = "";
            this.Clave = "";
            this.Seguridad = true;
        }
        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                //@"Server=; Database=; integrated security=true; TrustServerCertificate=Yes;"
                Cadena.ConnectionString = @"Server=" + this.Servidor + "; Database=" + this.Base + ";";
                if (this.Seguridad)
                {
                    Cadena.ConnectionString = Cadena.ConnectionString + "integrated security=true; TrustServerCertificate=Yes;";
                }
                else
                {
                    Cadena.ConnectionString = Cadena.ConnectionString + "User Id=" + this.Usuario + ";Password=" + this.Clave;
                }
            }
            catch (Exception ex)
            {
                Cadena = null;
                //throw ex;
            }
            return Cadena;
        }
        public static Conexion getInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }
    }
}

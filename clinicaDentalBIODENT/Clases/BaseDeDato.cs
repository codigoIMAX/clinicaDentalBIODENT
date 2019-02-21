using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using clinicaDentalBIODENT.Properties;

namespace clinicaDentalBIODENT.Clases
{
    public class BaseDeDato
    {
        public static SqlConnection obtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(Settings.Default.Conexion);
            conexion.Open();
            return conexion;
        }
        public static void cerrarConexion(SqlConnection conexion)
        {
            conexion.Close();
        }
    }
}

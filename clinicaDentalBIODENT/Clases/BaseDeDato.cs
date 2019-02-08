using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace clinicaDentalBIODENT.Clases
{
    public class BaseDeDato
    {
        public static SqlConnection obtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=ALEJANDRO-VAIO;Initial Catalog=dbBIODENT;Integrated Security=True");
            conexion.Open();
            return conexion;
        }
        public void cerrarConexion(SqlConnection conexion)
        {
            conexion.Close();
        }
    }
}

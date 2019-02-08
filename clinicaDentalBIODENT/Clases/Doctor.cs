using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace clinicaDentalBIODENT.Clases
{
    class Doctor
    {
        private string usuario;
        private string contrasenia;

        public Doctor(string usuario, string contrasenia)
        {
            this.Usuario = usuario;
            this.Contrasenia = contrasenia;
        }

        public string Usuario { get => usuario; set => usuario = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
        public bool validarDoctor()
        {
            SqlConnection conexion = BaseDeDato.obtenerConexion();
            string query = "SELECT * FROM tblDoctor WHERE usuario = '" + Usuario + "' AND contrasenia = '" + Contrasenia + "'";
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if(reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

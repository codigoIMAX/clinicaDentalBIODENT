using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Data;

namespace CapaDatos
{
    /// <summary>
    /// Esta clase permite conectarse con la base de datos, y a su vez realizar el CRUD respectivo en base a los requerimientos.
    /// </summary>
    public class BaseDeDato
    {
        /// <summary>
        /// Establece y abre una conexión a una base de datos.
        /// </summary>
        /// <returns>La conexión a la base de datos.</returns>
        /// <exception cref="SqlException">Lanzada cuando no se puede abrir la conexión a la base de datos.</exception>
        public static SqlConnection obtenerConexion()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["CapaAplicacion.Properties.Settings.Conexion"].ConnectionString);
                if (conexion.State == System.Data.ConnectionState.Closed)
                    conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }
        /// <summary>
        /// Cierra la conexión a una base de datos.
        /// </summary>
        /// <param name="conexion">Conexion a la base de datos del tipo <c>SqlConnection</c>.</param>
        /// <exception cref="SqlException">Lanzada cuando no se puede cerrar la conexión a la base de datos.</exception>
        public static void cerrarConexion(SqlConnection conexion)
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        /// <summary>
        /// Recupera todos los pacientes registrados en la base de datos.
        /// </summary>
        /// <returns>La lista de pacientes en un <c>DataTable</c>.</returns>
        public static DataTable listarPacientes()
        {
            int id = 1;
            int edad;
            DataTable tbl = new DataTable();
            tbl.Columns.Add("N°");
            tbl.Columns.Add("Cédula");
            tbl.Columns.Add("Apellidos");
            tbl.Columns.Add("Nombres");
            tbl.Columns.Add("Edad");
            tbl.Columns.Add("Teléfono");
            tbl.Columns.Add("Celular");
            tbl.Columns.Add("Correo Electrónico");
            SqlConnection conexion = obtenerConexion();
            string query = "SELECT * FROM tblPaciente ORDER BY apellidos";
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    edad = calcularEdad(reader.GetDateTime(3));
                    tbl.Rows.Add(id++, reader.GetString(0), reader.GetString(2), reader.GetString(1), edad, reader.GetString(8), reader.GetString(9), reader.GetString(10));
                }
            }
            reader.Close();
            cerrarConexion(conexion);
            return tbl;
        }
        /// <summary>
        /// Calcula la edad de un paciente en base a su fecha de nacimiento.
        /// </summary>
        /// <param name="fechaNacimiento">Fecha de nacimiento del paciente del tipo <c>DateTime</c>.</param>
        /// <returns>La edad del paciente.</returns>
        public static int calcularEdad(DateTime fechaNacimiento)
        {
            int edad;
            if (DateTime.Today.Month < fechaNacimiento.Month)
                edad = Convert.ToInt16(DateTime.Today.Year) - Convert.ToInt16(fechaNacimiento.Year) - 1;
            else
                edad = Convert.ToInt16(DateTime.Today.Year) - Convert.ToInt16(fechaNacimiento.Year);
            return edad;
        }
        /// <summary>
        /// Elimina un paciente de la base de datos en base a cédula.
        /// </summary>
        /// <param name="cedula">Cédula del paciente del tipo <c>string</c>.</param>
        /// <returns>Valor booleano de confirmación.</returns>
        public static bool eliminarPaciente(string cedula)
        {
            SqlConnection conexion = obtenerConexion();
            string query = "DELETE FROM tblPaciente WHERE cedula = '" + cedula + "'";
            SqlCommand comando = new SqlCommand(query, conexion);
            if (comando.ExecuteNonQuery() > 0)
            {
                cerrarConexion(conexion);
                return true;
            }
            else
            {
                cerrarConexion(conexion);
                return false;
            }

        }
        /// <summary>
        /// Recupera todos los planes de tratamiento definidos para una historia clínica en base a su número.
        /// </summary>
        /// <param name="numeroHistoriaClinica">Valor entero del número de historia clínica.</param>
        /// <returns>Los planes de tratamiento en un <c>DataTable</c>.</returns>
        public static DataTable listarPlanesTratamiento(int numeroHistoriaClinica)
        {
            int numero = 1;
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Id");
            tbl.Columns.Add("N°");
            tbl.Columns.Add("Descripcion");
            tbl.Columns.Add("Estado");
            tbl.Columns.Add("Fecha del Plan de Tratamiento");
            tbl.Columns.Add("Subtotal");
            tbl.Columns.Add("Total");
            SqlConnection conexion = obtenerConexion();
            string query = "SELECT * FROM tblPlanTratamiento WHERE numeroHistoriaClinica = " + numeroHistoriaClinica;
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader.GetBoolean(3))
                        tbl.Rows.Add(reader.GetInt32(0), numero++, reader.GetString(2), "Activo", reader.GetDateTime(4).ToString("dd/MM/yyyy"), Convert.ToString(reader.GetSqlMoney(5)), Convert.ToString(reader.GetSqlMoney(6)));
                    else
                        tbl.Rows.Add(reader.GetInt32(0), numero++, reader.GetString(2), "Terminado", reader.GetDateTime(4).ToString("dd/MM/yyyy"), Convert.ToString(reader.GetSqlMoney(5)), Convert.ToString(reader.GetSqlMoney(6)));
                }
            }
            reader.Close();
            cerrarConexion(conexion);
            return tbl;
        }
        /// <summary>
        /// Recupera los detalles definidos para un plan de tratamiento específico.
        /// </summary>
        /// <param name="idPlanTratamiento">Identificador del plan de tratamiento de tipo entero.</param>
        /// <returns>Los detalles del plan de tratamiento en un <c>DataTable</c>.</returns>
        public static DataTable listarDetalles(int idPlanTratamiento)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("N°");
            tbl.Columns.Add("Actividad");
            tbl.Columns.Add("Cantidad");
            tbl.Columns.Add("Precio Unitario");
            tbl.Columns.Add("Sub Total");
            SqlConnection conexion = obtenerConexion();
            string query = "SELECT * FROM tblDetalle WHERE idPlanTratamiento = " + idPlanTratamiento;
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tbl.Rows.Add(reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3), Convert.ToString(reader.GetSqlMoney(4)), reader.GetInt32(3) * Convert.ToDouble(Convert.ToString(reader.GetSqlMoney(4))));
                }
            }
            reader.Close();
            cerrarConexion(conexion);
            return tbl;
        }
        /// <summary>
        /// Elimina un plan de tratamiento en base a su identificador.
        /// </summary>
        /// <param name="idPlanTratamiento">Identificador del plan de tratamiento de tipo entero.</param>
        /// <returns>Valor booleano de confirmación.</returns>
        public static bool eliminarPlanTratamiento(int idPlanTratamiento)
        {
            SqlConnection conexion = obtenerConexion();
            string query = "DELETE FROM tblPlanTratamiento WHERE idPlanTratamiento = " + idPlanTratamiento;
            SqlCommand comando = new SqlCommand(query, conexion);
            if (comando.ExecuteNonQuery() > 0)
            {
                cerrarConexion(conexion);
                return true;
            }
            else
            {
                cerrarConexion(conexion);
                return false;
            }
        }
        /// <summary>
        /// Modifica el nombre de usuario de login mediante un procedimiento almacenado.
        /// </summary>
        /// <param name="usuarioActual">Usuario actual de tipo <c>string</c>.</param>
        /// <param name="nuevoNombre">Nuevo nombre de usuario de tipo <c>string</c>.</param>
        /// <returns>Un mensaje desde la base de datos mediante el procedimiento almacenado.</returns>
        public static string modificarNombreUsuario(string usuarioActual, string nuevoNombre)
        {
            string mensajeSalida;
            SqlConnection conexion = obtenerConexion();
            SqlCommand comando = new SqlCommand("spCambiarNombreUsuario", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuarioActual", usuarioActual);
            comando.Parameters.AddWithValue("@nuevoUsuario", nuevoNombre);
            SqlParameter salida = new SqlParameter("@mensajeSalida", SqlDbType.VarChar, 80);
            salida.Direction = ParameterDirection.Output;
            comando.Parameters.Add(salida);
            comando.ExecuteNonQuery();
            mensajeSalida = comando.Parameters["@mensajeSalida"].Value.ToString();
            BaseDeDato.cerrarConexion(conexion);
            return mensajeSalida;
        }
        /// <summary>
        /// Modifica la contraseña de login mediante un procedimiento almacenado.
        /// </summary>
        /// <param name="contraseniaActual">Contraseña actual de login de tipo <c>string</c>.</param>
        /// <param name="nuevaContrasenia">Nueva contraseña de tipo <c>string</c>.</param>
        /// <param name="usuario">Nombre de usuario de tipo <c>string</c> al que se modificará la contraseña.</param>
        /// <returns>Un mensaje desde la base de datos mediante el procedimiento almacenado.</returns>
        public static string modificarContrasenia(string contraseniaActual, string nuevaContrasenia, string usuario)
        {
            string mensajeSalida;
            SqlConnection conexion = obtenerConexion();
            SqlCommand comando = new SqlCommand("spCambiarContrasenia", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@contraseniaActual", contraseniaActual);
            comando.Parameters.AddWithValue("@nuevaContrasenia", nuevaContrasenia);
            comando.Parameters.AddWithValue("@usuario", usuario);
            SqlParameter salida = new SqlParameter("@mensajeSalida", SqlDbType.VarChar, 80);
            salida.Direction = ParameterDirection.Output;
            comando.Parameters.Add(salida);
            comando.ExecuteNonQuery();
            mensajeSalida = comando.Parameters["@mensajeSalida"].Value.ToString();
            BaseDeDato.cerrarConexion(conexion);
            return mensajeSalida;
        }
    }
}

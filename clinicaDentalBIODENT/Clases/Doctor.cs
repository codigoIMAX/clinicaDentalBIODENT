using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

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
                reader.Close();
                BaseDeDato.cerrarConexion(conexion);
                return true;
            }
            else
            {
                reader.Close();
                BaseDeDato.cerrarConexion(conexion);
                return false;
            }
        }
        public DataTable obtenerPacientes()
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
            SqlConnection conexion = BaseDeDato.obtenerConexion();
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
            BaseDeDato.cerrarConexion(conexion);
            return tbl;
        }
        public Paciente buscarPaciente(string cedula)
        {
            Paciente paciente = new Paciente();
            SqlConnection conexion = BaseDeDato.obtenerConexion();
            string query = "SELECT * FROM tblPaciente WHERE cedula = '" + cedula + "'";
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                paciente.Cedula = reader.GetString(0);
                paciente.Nombres = reader.GetString(1);
                paciente.Apellidos = reader.GetString(2);
                paciente.FechaNacimiento = reader.GetDateTime(3);
                paciente.Sexo = reader.GetBoolean(4);
                paciente.Ocupacion = reader.GetString(5);
                paciente.EstadoCivil = reader.GetString(6);
                paciente.Direccion = reader.GetString(7);
                paciente.Telefono = reader.GetString(8);
                paciente.Celular = reader.GetString(9);
                paciente.CorreoElectronico = reader.GetString(10);
                paciente.setEdad();
            }
            return paciente;
        }
        public bool ingresarPaciente(Paciente paciente, HistoriaClinica historiaClinica)
        {
            bool estado;
            SqlConnection conexion = BaseDeDato.obtenerConexion();
            SqlCommand comando = new SqlCommand("spIngresarPaciente", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cedula", paciente.Cedula);
            comando.Parameters.AddWithValue("@nombres", paciente.Nombres);
            comando.Parameters.AddWithValue("@apellidos", paciente.Apellidos);
            comando.Parameters.AddWithValue("@fechaNacimiento", paciente.FechaNacimiento);
            comando.Parameters.AddWithValue("@sexo", paciente.Sexo);
            comando.Parameters.AddWithValue("@ocupacion", paciente.Ocupacion);
            comando.Parameters.AddWithValue("@estadoCivil", paciente.EstadoCivil);
            comando.Parameters.AddWithValue("@direccion", paciente.Direccion);
            comando.Parameters.AddWithValue("@telefono", paciente.Telefono);
            comando.Parameters.AddWithValue("@celular", paciente.Celular);
            comando.Parameters.AddWithValue("@correoElectronico", paciente.CorreoElectronico);
            comando.Parameters.AddWithValue("@tratamientoMedicoActual", historiaClinica.TratamientoMedicoActual);
            comando.Parameters.AddWithValue("@tomaMedicamentoActual", historiaClinica.TomaMedicamentoActual);
            comando.Parameters.AddWithValue("@observacionesH", historiaClinica.Observaciones);
            comando.Parameters.AddWithValue("@alergiaAntibiotico", historiaClinica.Antecedentes.AlergiaAntibiotico);
            comando.Parameters.AddWithValue("@alergiaAnestesia", historiaClinica.Antecedentes.AlergiaAnestesia);
            comando.Parameters.AddWithValue("@hemorragia", historiaClinica.Antecedentes.Hemorragia);
            comando.Parameters.AddWithValue("@sida", historiaClinica.Antecedentes.Sida);
            comando.Parameters.AddWithValue("@tuberculosis", historiaClinica.Antecedentes.Tuberculosis);
            comando.Parameters.AddWithValue("@diabetes", historiaClinica.Antecedentes.Diabetes);
            comando.Parameters.AddWithValue("@asma", historiaClinica.Antecedentes.Asma);
            comando.Parameters.AddWithValue("@hipertension", historiaClinica.Antecedentes.Hipertension);
            comando.Parameters.AddWithValue("@enfermedadCardiaca", historiaClinica.Antecedentes.EnfermedadCardiaca);
            comando.Parameters.AddWithValue("@bebidasAlcoholicas", historiaClinica.Antecedentes.BebidasAlcoholicas);
            comando.Parameters.AddWithValue("@frecuencia", historiaClinica.Antecedentes.Frecuencia);
            comando.Parameters.AddWithValue("@fuma", historiaClinica.Antecedentes.Fuma);
            comando.Parameters.AddWithValue("@numeroCigarros", historiaClinica.Antecedentes.NumeroCigarros);
            comando.Parameters.AddWithValue("@observacionesA", historiaClinica.Antecedentes.Observaciones);
            SqlParameter salida = new SqlParameter("@salida", SqlDbType.Bit);
            salida.Direction = ParameterDirection.Output;
            comando.Parameters.Add(salida);
            if(comando.ExecuteNonQuery() > 0)
            {
                estado = Convert.ToBoolean(comando.Parameters["@salida"].Value.ToString());
                BaseDeDato.cerrarConexion(conexion);
                return estado;
            }
            return false;
        }
        public int calcularEdad(DateTime fechaNacimiento)
        {
            int edad;
            if (DateTime.Today.Month < fechaNacimiento.Month)
                edad = Convert.ToInt16(DateTime.Today.Year) - Convert.ToInt16(fechaNacimiento.Year) + 1;
            else
            {
                if (DateTime.Today.Day < fechaNacimiento.Day)
                    edad = Convert.ToInt16(DateTime.Today.Year) - Convert.ToInt16(fechaNacimiento.Year) + 1;
                else
                    edad = Convert.ToInt16(DateTime.Today.Year) - Convert.ToInt16(fechaNacimiento.Year);
            }
            return edad;
        }
    }
}

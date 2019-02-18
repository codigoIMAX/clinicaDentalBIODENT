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
            reader.Close();
            BaseDeDato.cerrarConexion(conexion);
            return paciente;
        }
        public bool eliminarPaciente(string cedula)
        {
            SqlConnection conexion = BaseDeDato.obtenerConexion();
            string query = "DELETE FROM tblPaciente WHERE cedula = '" + cedula + "'";
            SqlCommand comando = new SqlCommand(query, conexion);
            if (comando.ExecuteNonQuery() > 0)
            {
                BaseDeDato.cerrarConexion(conexion);
                return true;
            }
            else
            {
                BaseDeDato.cerrarConexion(conexion);
                return false;
            }
                
        }
        public bool actualizarPaciente(HistoriaClinica historiaClinica, string cedulaAnterior)
        {
            bool estado;
            SqlConnection conexion = BaseDeDato.obtenerConexion();
            SqlCommand comando = new SqlCommand("spActualizarPaciente", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cedulaAnterior", cedulaAnterior);
            comando.Parameters.AddWithValue("@cedula", historiaClinica.Paciente.Cedula);
            comando.Parameters.AddWithValue("@nombres", historiaClinica.Paciente.Nombres);
            comando.Parameters.AddWithValue("@apellidos", historiaClinica.Paciente.Apellidos);
            comando.Parameters.AddWithValue("@fechaNacimiento", historiaClinica.Paciente.FechaNacimiento);
            comando.Parameters.AddWithValue("@sexo", historiaClinica.Paciente.Sexo);
            comando.Parameters.AddWithValue("@ocupacion", historiaClinica.Paciente.Ocupacion);
            comando.Parameters.AddWithValue("@estadoCivil", historiaClinica.Paciente.EstadoCivil);
            comando.Parameters.AddWithValue("@direccion", historiaClinica.Paciente.Direccion);
            comando.Parameters.AddWithValue("@telefono", historiaClinica.Paciente.Telefono);
            comando.Parameters.AddWithValue("@celular", historiaClinica.Paciente.Celular);
            comando.Parameters.AddWithValue("@correoElectronico", historiaClinica.Paciente.CorreoElectronico);
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
            if (comando.ExecuteNonQuery() > 0)
            {
                estado = Convert.ToBoolean(comando.Parameters["@salida"].Value.ToString());
                BaseDeDato.cerrarConexion(conexion);
                return estado;
            }
            BaseDeDato.cerrarConexion(conexion);
            return false;
        }
        public HistoriaClinica buscarHistoriaClinica(string cedula)
        {
            HistoriaClinica historiaClinica = new HistoriaClinica();
            AntecedentePF antecedentePF = new AntecedentePF();
            SqlConnection conexion = BaseDeDato.obtenerConexion();
            string query = "SELECT * FROM tblHistoriaClinica INNER JOIN tblAntecedentePF ON tblHistoriaClinica.numeroHistoriaClinica = tblAntecedentePF.numeroHistoriaClinica WHERE tblHistoriaClinica.cedulaPaciente = '" + cedula + "'";
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                historiaClinica.NumeroHistoriaClinica = reader.GetInt32(0);
                historiaClinica.TratamientoMedicoActual = reader.GetString(2);
                historiaClinica.TomaMedicamentoActual = reader.GetString(3);
                historiaClinica.Observaciones = reader.GetString(4);
                antecedentePF.AlergiaAntibiotico = reader.GetBoolean(6);
                antecedentePF.AlergiaAnestesia = reader.GetBoolean(7);
                antecedentePF.Hemorragia = reader.GetBoolean(8);
                antecedentePF.Sida = reader.GetBoolean(9);
                antecedentePF.Tuberculosis = reader.GetBoolean(10);
                antecedentePF.Diabetes = reader.GetBoolean(11);
                antecedentePF.Asma = reader.GetBoolean(12);
                antecedentePF.Hipertension = reader.GetBoolean(13);
                antecedentePF.EnfermedadCardiaca = reader.GetBoolean(14);
                antecedentePF.BebidasAlcoholicas = reader.GetBoolean(15);
                antecedentePF.Frecuencia = reader.GetString(16);
                antecedentePF.Fuma = reader.GetBoolean(17);
                antecedentePF.NumeroCigarros = reader.GetString(18);
                antecedentePF.Observaciones = reader.GetString(19);
                historiaClinica.Antecedentes = antecedentePF;
            }
            reader.Close();
            BaseDeDato.cerrarConexion(conexion);
            return historiaClinica;
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
            BaseDeDato.cerrarConexion(conexion);
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

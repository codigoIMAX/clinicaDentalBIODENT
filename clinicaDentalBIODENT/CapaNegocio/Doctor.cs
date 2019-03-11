﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    /// <summary>
    /// Esta clase permite realizar el control del sistema y el CRUD hacia la base de datos mediante el uso de la clase <c>BaseDeDato</c>.
    /// </summary>
    public class Doctor
    {
        /// <summary>
        /// Constructor con parámetros de la clase <c>Doctor</c>.
        /// </summary>
        /// <param name="usuario">Nombre de usuario del tipo <c>string</c>.</param>
        /// <param name="contrasenia">Contraseña del tipo <c>string</c>.</param>
        public Doctor(string usuario, string contrasenia)
        {
            this.Usuario = usuario;
            this.Contrasenia = contrasenia;
        }
        /// <summary>
        /// Método get y set del atributo <c>Usuario</c>.
        /// </summary>
        public string Usuario { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Constrasenia</c>.
        /// </summary>
        public string Contrasenia { get; set; }
        /// <summary>
        /// Autentica al doctor para el acceso al menú principal.
        /// </summary>
        /// <returns>Valor booleano para la autenticación.</returns>
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
        /// <summary>
        /// Modifica el nombre de usuario de acceso al sistema.
        /// </summary>
        /// <param name="usuarioActual">Nombre de usuario actual del tipo <c>string</c>.</param>
        /// <param name="nuevoNombre">Nuevo nombre de usuario del tipo <c>string</c>.</param>
        /// <returns>Un mensaje de confirmación.</returns>
        public string cambiarNombreUsuario(string usuarioActual, string nuevoNombre)
        {
            return BaseDeDato.modificarNombreUsuario(usuarioActual, nuevoNombre);
        }
        /// <summary>
        /// Modifica la contraseña de acceso al sistema.
        /// </summary>
        /// <param name="contraseniaActual">Contraseña actual del tipo <c>string</c>.</param>
        /// <param name="nuevaContrasenia">Nueva contraseña del tipo <c>string</c>.</param>
        /// <param name="usuario">Nombre de usuario del tipo <c>string</c>.</param>
        /// <returns>Un mensaje de confirmación</returns>
        public string cambiarContrasenia(string contraseniaActual, string nuevaContrasenia, string usuario)
        {
            return BaseDeDato.modificarContrasenia(contraseniaActual, nuevaContrasenia, usuario);
        }
        /// <summary>
        /// Recupera todos los pacientes registrados en la base de datos.
        /// </summary>
        /// <returns>La lista de pacientes en un <c>DataTable</c>.</returns>
        public DataTable obtenerPacientes()
        {
            return BaseDeDato.listarPacientes();
        }
        /// <summary>
        /// Busca un paciente junto con sus datos en base a la cédula del mismo.
        /// </summary>
        /// <param name="cedula">Cédula del paciente del tipo <c>string</c> para buscarlo en la base de datos.</param>
        /// <returns>Un paciente junto con sus datos personales en base a la clase <c>Paciente</c>.</returns>
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
        /// <summary>
        /// Elimina un paciente de acuerdo a su número de cédula.
        /// </summary>
        /// <param name="cedula">Cédula del paciente del tipo <c>string</c> para eliminarlo de la base de datos.</param>
        /// <returns>Un valor booleano para la confirmación.</returns>
        public bool eliminarPaciente(string cedula)
        {
            return BaseDeDato.eliminarPaciente(cedula);    
        }
        /// <summary>
        /// Actualiza los datos de un paciente en base a su número de cédula
        /// Se ejecuta mediante un procedimiento almacenado.
        /// </summary>
        /// <remarks>Si el número de cédula se modifica, se tiene un parámetro con la cédula anterior para buscar al paciente y posteriormente modificar su número de cédula.</remarks>
        /// <param name="historiaClinica">Historia clínica del paciente que contiene todos los datos a actualizar.</param>
        /// <param name="cedulaAnterior">Cédula del paciente antes de ser modificada en caso de que se requiera.</param>
        /// <returns>Un valor booleano para la confirmación.</returns>
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
        /// <summary>
        /// Obtiene la historia clínica de un paciente en particular en base a su número de cédula.
        /// </summary>
        /// <param name="cedula">Número de cédula del paciente del tipo <c>string</c>.</param>
        /// <returns>La historia clínica del paciente.</returns>
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
        /// <summary>
        /// Permite registrar un paciente en la base de datos mediante un procedimiento almacenado.
        /// </summary>
        /// <param name="paciente">Contiene los datos personales del paciente en base a la clase <c>Paciente</c>.</param>
        /// <param name="historiaClinica">Contiene los datos de la historia clínica del paciente en base a la clase <c>HistoriaClinica</c>.</param>
        /// <returns>Un valor booleano de confirmación de la transacción.</returns>
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
        /// <summary>
        /// Recupera todos los planes de tratamiento definidos para una historia clínica en base a su número.
        /// </summary>
        /// <param name="numeroHistoriaClinica">Valor entero del número de historia clínica.</param>
        /// <returns>Los planes de tratamiento en un <c>DataTable</c>.</returns>
        public DataTable obtenerPlanesTratamiento(int numeroHistoriaClinica)
        {
            return BaseDeDato.listarPlanesTratamiento(numeroHistoriaClinica);
        }
        /// <summary>
        /// Recupera los detalles definidos para un plan de tratamiento específico.
        /// </summary>
        /// <param name="idPlanTratamiento">Identificador del plan de tratamiento de tipo entero.</param>
        /// <returns>Los detalles del plan de tratamiento en un <c>DataTable</c>.</returns>
        public DataTable obtenerDetalles(int idPlanTratamiento)
        {
            return BaseDeDato.listarDetalles(idPlanTratamiento);
        }
        /// <summary>
        /// Recupera los detalles de un plan de tratamiento.
        /// </summary>
        /// <param name="idPlanTratamiento">Identificador del plan de tratamiento.</param>
        /// <returns>Una lista de los detalles en base a la clase <c>Detalle</c>.</returns>
        public List<Detalle> llenarDetalles(int idPlanTratamiento)
        {
            Detalle detalle;
            List<Detalle> detalles = new List<Detalle>();
            SqlConnection conexion = BaseDeDato.obtenerConexion();
            string query = "SELECT * FROM tblDetalle WHERE idPlanTratamiento = " + idPlanTratamiento;
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    detalle = new Detalle();
                    detalle.IdDetalle = reader.GetInt32(1);
                    detalle.Actividad = reader.GetString(2);
                    detalle.Cantidad = reader.GetInt32(3);
                    detalle.PrecioUnitario = Convert.ToDouble(Convert.ToString(reader.GetSqlMoney(4)));
                    detalles.Add(detalle);
                }
            }
            reader.Close();
            BaseDeDato.cerrarConexion(conexion);
            return detalles;
        }
        /// <summary>
        /// Ingresa un plan de tratamiento a la base de datos.
        /// </summary>
        /// <param name="planTratamiento">Detalle del plan de tratamiento en base a la clase <c>PlanTratamiento</c>.</param>
        /// <param name="numeroHistoriaClinica">Número de historia clínica para el plan de tratamiento.</param>
        /// <returns>Un valor booleano de confirmación.</returns>
        public bool ingresarPlanTratamiento(PlanTratamiento planTratamiento, int numeroHistoriaClinica)
        {
            SqlConnection conexion = BaseDeDato.obtenerConexion();
            string query = "INSERT INTO tblPlanTratamiento VALUES (" + numeroHistoriaClinica + ", '" + planTratamiento.Descripcion + "', '" + planTratamiento.Estado + 
                "', '" + planTratamiento.FechaPlanTratamiento + "', " + planTratamiento.Subtotal + ", " + planTratamiento.Total + ")";
            SqlCommand comando = new SqlCommand(query, conexion);
            if(comando.ExecuteNonQuery() > 0)
            {
                query = "SELECT TOP 1 idPlanTratamiento FROM tblPlanTratamiento ORDER BY idPlanTratamiento DESC";
                comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    planTratamiento.IdPlanTratamiento = reader.GetInt32(0);
                    reader.Close();
                    foreach (var aux in planTratamiento.Detalles)
                    {
                        query = "INSERT INTO tblDetalle VALUES (" + planTratamiento.IdPlanTratamiento + ", " + aux.IdDetalle + ", '" + aux.Actividad + "', " +
                            aux.Cantidad + ", " + aux.PrecioUnitario + ")";
                        comando = new SqlCommand(query, conexion);
                        if (comando.ExecuteNonQuery() > 0)
                            continue;
                    }
                    BaseDeDato.cerrarConexion(conexion);
                    return true;
                }
                BaseDeDato.cerrarConexion(conexion);
                return false;
            }
            else
            {
                BaseDeDato.cerrarConexion(conexion);
                return false;
            }
                
        }
        /// <summary>
        /// Modifica un plan de tratamiento en base a su identificador.
        /// </summary>
        /// <param name="planTratamiento">Detalle del plan de tratamiento en base a la clase <c>PlanTratamiento</c>.</param>
        /// <returns>Un valor booleano de confirmación.</returns>
        public bool modificarPlanTratamiento(PlanTratamiento planTratamiento)
        {
            SqlConnection conexion = BaseDeDato.obtenerConexion();
            string query = "UPDATE tblPlanTratamiento SET descripcion = '" + planTratamiento.Descripcion + "', estado = '" + planTratamiento.Estado + "', fechaPlanTratamiento = '" +
                planTratamiento.FechaPlanTratamiento + "', subtotal = " + planTratamiento.Subtotal + ", total = " + planTratamiento.Total + " WHERE idPlanTratamiento = " + planTratamiento.IdPlanTratamiento;
            SqlCommand comando = new SqlCommand(query, conexion);
            if (comando.ExecuteNonQuery() > 0)
            {
                query = "DELETE FROM tblDetalle WHERE idPlanTratamiento = " + planTratamiento.IdPlanTratamiento;
                comando = new SqlCommand(query, conexion);
                if (comando.ExecuteNonQuery() > 0)
                {
                    foreach (var aux in planTratamiento.Detalles)
                    {
                        query = "INSERT INTO tblDetalle VALUES (" + planTratamiento.IdPlanTratamiento + ", " + aux.IdDetalle + ", '" + aux.Actividad + "', " +
                            aux.Cantidad + ", " + aux.PrecioUnitario + ")";
                        comando = new SqlCommand(query, conexion);
                        if (comando.ExecuteNonQuery() > 0)
                            continue;
                    }
                    BaseDeDato.cerrarConexion(conexion);
                    return true;
                }
                BaseDeDato.cerrarConexion(conexion);
                return false;
            }
            else
            {
                BaseDeDato.cerrarConexion(conexion);
                return false;
            }
        }
        /// <summary>
        /// Elimina un plan de tratamiento.
        /// </summary>
        /// <param name="idPlanTratamiento">Identificador de tipo entero para eliminar el plan de tratamiento.</param>
        /// <returns>Un valor booleano de confirmación.</returns>
        public bool eliminarPlanTratamiento(int idPlanTratamiento)
        {
            return BaseDeDato.eliminarPlanTratamiento(idPlanTratamiento);
        }
        /// <summary>
        /// Recupera las actividades realizadas a un plan de tratamiento.
        /// </summary>
        /// <param name="idPlanTratamiento">Identificador del plan de tratamiento de tipo entero.</param>
        /// <returns>Una lista de actividades del plan de tratamiento en base a la clase <c>Actividad</c>.</returns>
        public List<Actividad> llenarActividades(int idPlanTratamiento)
        {
            Actividad actividad;
            List<Actividad> actividades = new List<Actividad>();
            SqlConnection conexion = BaseDeDato.obtenerConexion();
            string query = "SELECT * FROM tblActividad WHERE idPlanTratamiento = " + idPlanTratamiento;
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    actividad = new Actividad();
                    actividad.IdActividad = reader.GetInt32(1);
                    actividad.FechaActividad = reader.GetDateTime(2);
                    actividad.NumeroPieza = reader.GetInt32(3);
                    actividad.Detalle = reader.GetString(4);
                    actividades.Add(actividad);
                }
            }
            reader.Close();
            BaseDeDato.cerrarConexion(conexion);
            return actividades;
        }
        /// <summary>
        /// Recupera los abonos realizados a un plan de tratamiento.
        /// </summary>
        /// <param name="idPlanTratamiento">Identificador del plan de tratamiento de tipo entero.</param>
        /// <returns>Una lista de abonos del plan de tratamiento en base a la clase <c>Abono</c>.</returns>
        public List<Abono> llenarAbonos(int idPlanTratamiento)
        {
            Abono abono;
            List<Abono> abonos = new List<Abono>();
            SqlConnection conexion = BaseDeDato.obtenerConexion();
            string query = "SELECT * FROM tblAbono WHERE idPlanTratamiento = " + idPlanTratamiento;
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    abono = new Abono();
                    abono.IdAbono= reader.GetInt32(1);
                    abono.FechaAbono = reader.GetDateTime(2);
                    abono.Cantidad = Convert.ToDouble(Convert.ToString(reader.GetSqlMoney(3)));
                    abonos.Add(abono);
                }
            }
            reader.Close();
            BaseDeDato.cerrarConexion(conexion);
            return abonos;
        }
        /// <summary>
        /// Ingresa las actividades realizadas en un plan de tratamiento.
        /// </summary>
        /// <param name="actividades">Lista de actividades correspondientes a un plan de tratamiento.</param>
        /// <param name="idPlanTratamiento">Identificador de tipo entero para el plan de tratamiento.</param>
        /// <returns>Un valor booleano de confirmación.</returns>
        public bool ingresarActividades(List<Actividad> actividades, int idPlanTratamiento)
        {
            SqlConnection conexion = BaseDeDato.obtenerConexion();
            string query = "DELETE FROM tblActividad WHERE idPlanTratamiento = " + idPlanTratamiento;
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.ExecuteNonQuery();
            comando = new SqlCommand("INSERT INTO tblActividad VALUES (@idPlanTratamiento, @idActividad, @fechaActividad, @numeroPieza, @actividad)", conexion);
            try
            {
                foreach (var aux in actividades)
                {
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@idPlanTratamiento", idPlanTratamiento);
                    comando.Parameters.AddWithValue("@idActividad", aux.IdActividad);
                    comando.Parameters.AddWithValue("@fechaActividad", aux.FechaActividad);
                    comando.Parameters.AddWithValue("@numeroPieza", aux.NumeroPieza);
                    comando.Parameters.AddWithValue("@actividad", aux.Detalle);
                    comando.ExecuteNonQuery();
                }
                BaseDeDato.cerrarConexion(conexion);
                return true;
            }
            catch
            {
                BaseDeDato.cerrarConexion(conexion);
                return false;
            }
        }
        /// <summary>
        /// Ingresa los abonos realizados en un plan de tratamiento.
        /// </summary>
        /// <param name="abonos">Lista de abonoms correspondientes a un plan de tratamiento.</param>
        /// <param name="idPlanTratamiento">Identificador de tipo entero para el plan de tratamiento.</param>
        /// <returns>Un valor booleano de confirmación.</returns>
        public bool ingresarAbonos(List<Abono> abonos, int idPlanTratamiento)
        {
            SqlConnection conexion = BaseDeDato.obtenerConexion();
            string query = "DELETE FROM tblAbono WHERE idPlanTratamiento = " + idPlanTratamiento;
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.ExecuteNonQuery();
            comando = new SqlCommand("INSERT INTO tblAbono VALUES (@idPlanTratamiento, @idAbono, @fechaAbono, @abono)", conexion);
            try
            {
                foreach (var aux in abonos)
                {
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@idPlanTratamiento", idPlanTratamiento);
                    comando.Parameters.AddWithValue("@idAbono", aux.IdAbono);
                    comando.Parameters.AddWithValue("@fechaAbono", aux.FechaAbono);
                    comando.Parameters.AddWithValue("@abono", aux.Cantidad);
                    comando.ExecuteNonQuery();
                }
                BaseDeDato.cerrarConexion(conexion);
                return true;
            }
            catch
            {
                BaseDeDato.cerrarConexion(conexion);
                return false;
            }
        }
        /// <summary>
        /// Recupera las piezas dentales de una historia clínica en particular.
        /// </summary>
        /// <param name="numeroHistoriaClinica">Número de historia clínica para llenar su odontograma.</param>
        /// <returns>Una lista con las piezas dentales de la historia clínica en base a la clase <c>PiezaDental</c>.</returns>
        public List<PiezaDental> buscarPiezasDentales(int numeroHistoriaClinica)
        {
            PiezaDental piezaDental;
            List<PiezaDental> piezasDentales = new List<PiezaDental>();
            SqlConnection conexion = BaseDeDato.obtenerConexion();
            string query = "SELECT * FROM tblPiezaDental WHERE numeroHistoriaClinica = " + numeroHistoriaClinica;
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    piezaDental = new PiezaDental();
                    piezaDental.NumeroPieza = reader.GetInt32(1);
                    piezaDental.ColorArriba = reader.GetString(2);
                    piezaDental.ColorDerecha = reader.GetString(3);
                    piezaDental.ColorAbajo = reader.GetString(4);
                    piezaDental.ColorIzquierda = reader.GetString(5);
                    piezaDental.ColorCentro = reader.GetString(6);
                    piezasDentales.Add(piezaDental);
                }
            }
            reader.Close();
            BaseDeDato.cerrarConexion(conexion);
            return piezasDentales;
        }
        /// <summary>
        /// Actualiza los datos de una historia clínica en particular.
        /// </summary>
        /// <param name="historiaClinica">Historia Clínica a ser actualizada.</param>
        /// <returns>Un valor booleano de confirmación.</returns>
        public bool actualizarHistoriaClinica(HistoriaClinica historiaClinica)
        {
            SqlConnection conexion = BaseDeDato.obtenerConexion();
            string query = "UPDATE tblHistoriaClinica SET tratamientoMedicoActual = '" + historiaClinica.TratamientoMedicoActual + "', tomaMedicamentoActual = '" + 
                historiaClinica.TomaMedicamentoActual + "', observaciones = '" + historiaClinica.Observaciones + "' WHERE numeroHistoriaClinica = " + historiaClinica.NumeroHistoriaClinica;
            SqlCommand comando = new SqlCommand(query, conexion);
            if(comando.ExecuteNonQuery() > 0)
            {
                query = "UPDATE tblAntecedentePF SET alergiaAntibiotico = " + Convert.ToByte(historiaClinica.Antecedentes.AlergiaAntibiotico) + ", alergiaAnestesia = " + Convert.ToByte(historiaClinica.Antecedentes.AlergiaAnestesia) +
                    ", hemorragia = " + Convert.ToByte(historiaClinica.Antecedentes.Hemorragia) + ", sida = " + Convert.ToByte(historiaClinica.Antecedentes.Sida) + ", tuberculosis = " + Convert.ToByte(historiaClinica.Antecedentes.Tuberculosis) +
                    ", diabetes = " + Convert.ToByte(historiaClinica.Antecedentes.Diabetes) + ", asma = " + Convert.ToByte(historiaClinica.Antecedentes.Asma) + ", hipertension = " + Convert.ToByte(historiaClinica.Antecedentes.Hipertension) +
                    ", enfermedadCardiaca = " + Convert.ToByte(historiaClinica.Antecedentes.EnfermedadCardiaca) + ", bebidasAlcoholicas = " + Convert.ToByte(historiaClinica.Antecedentes.BebidasAlcoholicas) + ", frecuencia = '" +
                    historiaClinica.Antecedentes.Frecuencia + "', fuma = " + Convert.ToByte(historiaClinica.Antecedentes.Fuma) + ", numeroCigarros = '" + historiaClinica.Antecedentes.NumeroCigarros + "', observaciones = '" +
                    historiaClinica.Antecedentes.Observaciones + "' WHERE numeroHistoriaClinica = " + historiaClinica.NumeroHistoriaClinica;
                comando = new SqlCommand(query, conexion);
                if(comando.ExecuteNonQuery() > 0)
                {
                    foreach(var aux in historiaClinica.PiezasDentales)
                    {
                        query = "UPDATE tblPiezaDental SET colorArriba = '" + aux.ColorArriba + "', colorDerecha = '" + aux.ColorDerecha + "', colorAbajo = '" + aux.ColorAbajo + "', colorIzquierda = '" + 
                            aux.ColorIzquierda + "', colorCentro = '" + aux.ColorCentro + "' WHERE numeroHistoriaClinica = " + historiaClinica.NumeroHistoriaClinica + " AND numeroPieza = " + aux.NumeroPieza;
                        comando = new SqlCommand(query, conexion);
                        comando.ExecuteNonQuery();
                    }
                    return true;
                }
                else
                {
                    BaseDeDato.cerrarConexion(conexion);
                    return false;
                }
            }
            else
            {
                BaseDeDato.cerrarConexion(conexion);
                return false;
            }
        }
        /// <summary>
        /// Calcula la edad de los pacientes registrados en base a su fecha de nacimiento.
        /// </summary>
        /// <param name="fechaNacimiento">Fecha de nacimiento del paciente del tipo <c>DateTime</c>.</param>
        /// <returns>La edad del paciente de tipo entero.</returns>
        public int calcularEdad(DateTime fechaNacimiento)
        {
            int edad;
            if (DateTime.Today.Month < fechaNacimiento.Month)
                edad = Convert.ToInt16(DateTime.Today.Year) - Convert.ToInt16(fechaNacimiento.Year) - 1;
            else
                edad = Convert.ToInt16(DateTime.Today.Year) - Convert.ToInt16(fechaNacimiento.Year);
            return edad;
        }
    }
}

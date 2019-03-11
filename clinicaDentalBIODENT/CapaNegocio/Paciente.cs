using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    /// <summary>
    /// Esta clase define un paciente con sus datos personales importantes.
    /// </summary>
    public class Paciente
    {
        /*
         *Atributo de tipo entero que almacena la edad del paciente.
         *Este atributo tiene su método set definido en base a un cálculo.
        */
        private int edad;
        /// <summary>
        /// Constructor por defecto de la clase <c>Paciente</c>.
        /// </summary>
        public Paciente()
        {

        }
        /// <summary>
        /// Constructor con parámetros de la clase <c>Paciente</c>
        /// </summary>
        /// <param name="cedula">Valor <c>string</c> de la cédula del paciente.</param>
        /// <param name="nombres">Valor <c>string</c> de los nombres del paciente.</param>
        /// <param name="apellidos">Valor <c>string</c> de los apellidos del paciente.</param>
        /// <param name="fechaNacimiento">Valor <c>DateTime</c> de la fecha de nacimiento del paciente.</param>
        /// <param name="sexo">Valor booleano que define el sexo del paciente.</param>
        /// <param name="ocupacion">Valor <c>string</c> usado para definir la ocupación del paciente.</param>
        /// <param name="estadoCivil">Valor <c>string</c> para definir el estado civil del paciente.</param>
        /// <param name="direccion">Valor <c>string</c> usado para la dirección domiciliaria del paciente.</param>
        /// <param name="telefono">Valor <c>string</c> que contiene el teléfono convencional del paciente.</param>
        /// <param name="celular">Valor <c>string</c> que contiene el teléfono celular del paciente.</param>
        /// <param name="correoElectronico">Valor <c>string</c> que contiene el correo electrónico del paciente.</param>
        public Paciente(string cedula, string nombres, string apellidos, DateTime fechaNacimiento, bool sexo, string ocupacion, string estadoCivil, string direccion, string telefono, string celular, string correoElectronico)
        {
            this.Cedula = cedula;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.FechaNacimiento = fechaNacimiento;
            setEdad();
            this.Sexo = sexo;
            this.Ocupacion = ocupacion;
            this.EstadoCivil = estadoCivil;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Celular = celular;
            this.CorreoElectronico = correoElectronico;
        }
        /// <summary>
        /// Método get y set del atributo <c>Cedula</c>.
        /// </summary>
        public string Cedula { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Nombres</c>.
        /// </summary>
        public string Nombres { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Apellidos</c>.
        /// </summary>
        public string Apellidos { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>FechaNacimiento</c>.
        /// </summary>
        public DateTime FechaNacimiento { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Sexo</c>.
        /// </summary>
        public bool Sexo { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Ocupacion</c>.
        /// </summary>
        public string Ocupacion { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>EstadoCivil</c>.
        /// </summary>
        public string EstadoCivil { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Direccion</c>.
        /// </summary>
        public string Direccion { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Telefono</c>.
        /// </summary>
        public string Telefono { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Celular</c>.
        /// </summary>
        public string Celular { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>CorreoElectronico</c>.
        /// </summary>
        public string CorreoElectronico { get; set; }
        /// <summary>
        /// Método get de la edad del paciente.
        /// </summary>
        /// <returns>La edad del paciente.</returns>
        public int Edad()
        {
            return edad;
        }
        /// <summary>
        /// Permite calcular la edad del paciente en base a su Fecha de Nacimiento.
        /// </summary>
        public void setEdad()
        {
            if (DateTime.Today.Month < FechaNacimiento.Month)
                edad = Convert.ToInt16(DateTime.Today.Year) - Convert.ToInt16(FechaNacimiento.Year) - 1;
            else
                edad = Convert.ToInt16(DateTime.Today.Year) - Convert.ToInt16(FechaNacimiento.Year);
        }
    }
}
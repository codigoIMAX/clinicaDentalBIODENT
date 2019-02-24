using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Paciente
    {
        private int edad;
        public Paciente()
        {

        }
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
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Sexo { get; set; }
        public string Ocupacion { get; set; }
        public string EstadoCivil { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string CorreoElectronico { get; set; }
        public int Edad()
        {
            return edad;
        }
        public void setEdad()
        {
            if (DateTime.Today.Month < FechaNacimiento.Month)
                edad = Convert.ToInt16(DateTime.Today.Year) - Convert.ToInt16(FechaNacimiento.Year) + 1;
            else
            {
                if (DateTime.Today.Day < FechaNacimiento.Day)
                    edad = Convert.ToInt16(DateTime.Today.Year) - Convert.ToInt16(FechaNacimiento.Year) + 1;
                else
                    edad = Convert.ToInt16(DateTime.Today.Year) - Convert.ToInt16(FechaNacimiento.Year);
            }
        }
    }
}
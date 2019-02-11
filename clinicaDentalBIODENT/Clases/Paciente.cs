using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicaDentalBIODENT.Clases
{
    class Paciente
    {
        private string cedula;
        private string nombres;
        private string apellidos;
        private DateTime fechaNacimiento;
        private int edad;
        private bool sexo;
        private string ocupacion;
        private string estadoCivil;
        private string direccion;
        private string telefono;
        private string celular;
        private string correoElectronico;
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
        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public bool Sexo { get => sexo; set => sexo = value; }
        public string Ocupacion { get => ocupacion; set => ocupacion = value; }
        public string EstadoCivil { get => estadoCivil; set => estadoCivil = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Celular { get => celular; set => celular = value; }
        public string CorreoElectronico { get => correoElectronico; set => correoElectronico = value; }
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
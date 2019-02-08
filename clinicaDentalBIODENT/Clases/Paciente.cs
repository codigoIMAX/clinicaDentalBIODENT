using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicaDentalBIODENT.Clases
{
    class Paciente
    {
        private string cedulaPaciente;
        private string nombres;
        private string apellidoPaterno;
        private string apellidoMaterno;
        private DateTime fechaNacimiento;
        private string ocupacion;
        private string direccion;
        private string telefono;
        private string correoElectronico;
        public Paciente()
        {

        }
        public Paciente(string cedulaPaciente, string nombres, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, string ocupacion, string direccion, string telefono, string correoElectronico)
        {
            this.CedulaPaciente = cedulaPaciente;
            this.Nombres = nombres;
            this.ApellidoPaterno = apellidoPaterno;
            this.ApellidoMaterno = apellidoMaterno;
            this.FechaNacimiento = fechaNacimiento;
            this.Ocupacion = ocupacion;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.CorreoElectronico = correoElectronico;
        }

        public string CedulaPaciente { get => cedulaPaciente; set => cedulaPaciente = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string ApellidoPaterno { get => apellidoPaterno; set => apellidoPaterno = value; }
        public string ApellidoMaterno { get => apellidoMaterno; set => apellidoMaterno = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Ocupacion { get => ocupacion; set => ocupacion = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string CorreoElectronico { get => correoElectronico; set => correoElectronico = value; }
    }
}

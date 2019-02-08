using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicaDentalBIODENT.Clases
{
    class Tratamiento
    {
        private int idTratamiento;
        private DateTime fechaNacimiento;
        private int numeroPieza;
        private string descripcion;
        private DateTime fechaAbono;
        private double abono;
        public Tratamiento()
        {

        }
        public Tratamiento(int idTratamiento, DateTime fechaNacimiento, int numeroPieza, string descripcion, DateTime fechaAbono, double abono)
        {
            this.IdTratamiento = idTratamiento;
            this.FechaNacimiento = fechaNacimiento;
            this.NumeroPieza = numeroPieza;
            this.Descripcion = descripcion;
            this.FechaAbono = fechaAbono;
            this.Abono = abono;
        }

        public int IdTratamiento { get => idTratamiento; set => idTratamiento = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public int NumeroPieza { get => numeroPieza; set => numeroPieza = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime FechaAbono { get => fechaAbono; set => fechaAbono = value; }
        public double Abono { get => abono; set => abono = value; }
    }
}

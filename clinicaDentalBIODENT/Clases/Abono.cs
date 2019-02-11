using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicaDentalBIODENT.Clases
{
    class Abono
    {
        private DateTime fechaAbono;
        private double cantidad;
        public Abono()
        {

        }
        public Abono(DateTime fechaAbono, double cantidad)
        {
            this.FechaAbono = fechaAbono;
            this.Cantidad = cantidad;
        }
        public DateTime FechaAbono { get => fechaAbono; set => fechaAbono = value; }
        public double Cantidad { get => cantidad; set => cantidad = value; }
    }
}

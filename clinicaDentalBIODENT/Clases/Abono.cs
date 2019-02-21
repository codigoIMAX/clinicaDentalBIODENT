using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicaDentalBIODENT.Clases
{
    class Abono
    {
        public Abono()
        {

        }
        public Abono(DateTime fechaAbono, double cantidad)
        {
            this.FechaAbono = fechaAbono;
            this.Cantidad = cantidad;
        }
        public DateTime FechaAbono { get; set; }
        public double Cantidad { get; set; }
    }
}

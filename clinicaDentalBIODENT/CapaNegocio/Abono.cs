using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Abono
    {
        public Abono()
        {

        }
        public Abono(int idAbono, DateTime fechaAbono, double cantidad)
        {
            this.IdAbono = idAbono;
            this.FechaAbono = fechaAbono;
            this.Cantidad = cantidad;
        }
        public int IdAbono { get; set; }
        public DateTime FechaAbono { get; set; }
        public double Cantidad { get; set; }
    }
}

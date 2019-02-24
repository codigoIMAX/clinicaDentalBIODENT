using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class PiezaDental
    {
        public PiezaDental()
        {

        }
        public PiezaDental(int numeroPieza, string colorArriba, string colorDerecha, string colorAbajo, string colorIzquierda, string colorCentro)
        {
            this.NumeroPieza = numeroPieza;
            this.ColorArriba = colorArriba;
            this.ColorDerecha = colorDerecha;
            this.ColorAbajo = colorAbajo;
            this.ColorIzquierda = colorIzquierda;
            this.ColorCentro = colorCentro;
        }
        public int NumeroPieza { get; set; }
        public string ColorArriba { get; set; }
        public string ColorDerecha { get; set; }
        public string ColorAbajo { get; set; }
        public string ColorIzquierda { get; set; }
        public string ColorCentro { get; set; }
    }
}

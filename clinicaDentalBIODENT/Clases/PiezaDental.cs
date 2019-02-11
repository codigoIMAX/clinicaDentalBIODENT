using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicaDentalBIODENT.Clases
{
    class PiezaDental
    {
        private int numeroPieza;
        private string colorArriba;
        private string colorDerecha;
        private string colorAbajo;
        private string colorIzquierda;
        private string colorCentro;
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
        public int NumeroPieza { get => numeroPieza; set => numeroPieza = value; }
        public string ColorArriba { get => colorArriba; set => colorArriba = value; }
        public string ColorDerecha { get => colorDerecha; set => colorDerecha = value; }
        public string ColorAbajo { get => colorAbajo; set => colorAbajo = value; }
        public string ColorIzquierda { get => colorIzquierda; set => colorIzquierda = value; }
        public string ColorCentro { get => colorCentro; set => colorCentro = value; }
    }
}

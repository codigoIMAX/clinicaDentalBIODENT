using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Actividad
    {
        public Actividad()
        {

        }
        public Actividad(int idActividad, DateTime fechaActividad, int numeroPieza, string detalle)
        {
            this.IdActividad = idActividad;
            this.FechaActividad = fechaActividad;
            this.NumeroPieza = numeroPieza;
            this.Detalle = detalle;
        }
        public int IdActividad { get; set; }
        public DateTime FechaActividad { get; set; }
        public int NumeroPieza { get; set; }
        public string Detalle { get; set; }
    }
}

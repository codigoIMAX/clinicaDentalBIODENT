using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicaDentalBIODENT.Clases
{
    class Actividad
    {
        private int idActividad;
        private DateTime fechaActividad;
        private int numeroPieza;
        private string detalle;
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
        public int IdActividad { get => idActividad; set => idActividad = value; }
        public DateTime FechaActividad { get => fechaActividad; set => fechaActividad = value; }
        public int NumeroPieza { get => numeroPieza; set => numeroPieza = value; }
        public string Detalle { get => detalle; set => detalle = value; }
    }
}

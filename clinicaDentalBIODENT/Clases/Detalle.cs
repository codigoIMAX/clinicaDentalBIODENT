using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicaDentalBIODENT.Clases
{
    class Detalle
    {
        private int idDetalle;
        private string actividad;
        private int cantidad;
        private double precioUnitario;
        public Detalle()
        {

        }
        public Detalle(int idDetalle, string actividad, int cantidad, double precioUnitario)
        {
            this.IdDetalle = idDetalle;
            this.Actividad = actividad;
            this.Cantidad = cantidad;
            this.PrecioUnitario = precioUnitario;
        }
        public int IdDetalle { get => idDetalle; set => idDetalle = value; }
        public string Actividad { get => actividad; set => actividad = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
    }
}

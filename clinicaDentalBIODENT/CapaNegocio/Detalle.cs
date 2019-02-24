using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Detalle
    {
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
        public int IdDetalle { get; set; }
        public string Actividad { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
    }
}

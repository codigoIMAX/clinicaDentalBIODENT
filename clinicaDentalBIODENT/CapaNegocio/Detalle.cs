using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    /// <summary>
    /// Esta clase define el Detalle a realizarse en un plan de tratamiento definido.
    /// </summary>
    public class Detalle
    {
        /// <summary>
        /// Constructor por defecto de la clase <c>Detalle</c>.
        /// </summary>
        public Detalle()
        {

        }
        /// <summary>
        /// Constructor con parámetros de la clase <c>Detalle</c>.
        /// </summary>
        /// <param name="idDetalle">Entero que define el identificador del detalle.</param>
        /// <param name="actividad"><c>String</c> que describe la actividad del detalle.</param>
        /// <param name="cantidad">Valor entero para definir la cantidad a realizarse del detalle establecido.</param>
        /// <param name="precioUnitario">Valor <c>double</c> del precio unitario correspondiente al detalle.</param>
        public Detalle(int idDetalle, string actividad, int cantidad, double precioUnitario)
        {
            this.IdDetalle = idDetalle;
            this.Actividad = actividad;
            this.Cantidad = cantidad;
            this.PrecioUnitario = precioUnitario;
        }
        /// <summary>
        /// Método get y set del atributo <c>IdDetalle</c>.
        /// </summary>
        public int IdDetalle { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Actividad</c>.
        /// </summary>
        public string Actividad { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Cantidad</c>.
        /// </summary>
        public int Cantidad { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>PrecioUnitario</c>.
        /// </summary>
        public double PrecioUnitario { get; set; }
    }
}

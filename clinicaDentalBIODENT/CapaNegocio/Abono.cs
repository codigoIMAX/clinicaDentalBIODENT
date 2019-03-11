using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    /// <summary>
    /// Esta clase permite instanciar un Abono recuperado de la base de datos.
    /// </summary>
    public class Abono
    {
        /// <summary>
        /// Constructor de <c>Abono</c>por defecto.
        /// </summary>
        public Abono()
        {

        }
        /// <summary>
        /// Constructor de <c>Abono</c> con parámetros iniciales.
        /// </summary>
        /// <param name="idAbono">Identificador del abono.</param>
        /// <param name="fechaAbono">Fecha de realización del abono.</param>
        /// <param name="cantidad">Cantidad abonada.</param>
        public Abono(int idAbono, DateTime fechaAbono, double cantidad)
        {
            this.IdAbono = idAbono;
            this.FechaAbono = fechaAbono;
            this.Cantidad = cantidad;
        }
        /// <summary>
        /// Método get y set del atributo <c>IdAbono</c>.
        /// </summary>
        public int IdAbono { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>FechaAbono</c>.
        /// </summary>
        public DateTime FechaAbono { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Cantidad</c>.
        /// </summary>
        public double Cantidad { get; set; }
    }
}

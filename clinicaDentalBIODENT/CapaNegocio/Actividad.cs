using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    /// <summary>
    /// Esta clase permite instanciar una Actividad realizada en base al Plan de Tratamiento definido.
    /// </summary>
    public class Actividad
    {
        /// <summary>
        /// Contructor por defecto de la clase <c>Actividad</c>.
        /// </summary>
        public Actividad()
        {

        }
        /// <summary>
        /// Construtor con parámetros de la clase <c>Actividad</c>.
        /// </summary>
        /// <param name="idActividad">Identificador de la actividad realizada.</param>
        /// <param name="fechaActividad">Fecha de realización de la actividad.</param>
        /// <param name="numeroPieza">Número de pieza tratada.</param>
        /// <param name="detalle">Descripción de la actividad realizada.</param>
        public Actividad(int idActividad, DateTime fechaActividad, int numeroPieza, string detalle)
        {
            this.IdActividad = idActividad;
            this.FechaActividad = fechaActividad;
            this.NumeroPieza = numeroPieza;
            this.Detalle = detalle;
        }
        /// <summary>
        /// Método get y set del atributo <c>IdActividad</c>.
        /// </summary>
        public int IdActividad { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>FechaActividad</c>.
        /// </summary>
        public DateTime FechaActividad { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>NumeroPieza</c>.
        /// </summary>
        public int NumeroPieza { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Detalle</c>.
        /// </summary>
        public string Detalle { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    /// <summary>
    /// Esta clase define un plan de tratamiento para el paciente, el cual consta de los detalles a realizar, las actividades realizadas paso a paso y los abonos del mismo.
    /// </summary>
    public class PlanTratamiento
    {
        /// <summary>
        /// Constructor por defecto de la clase <c>PlanTratamiento</c>.
        /// Se instancian listas vacías de Detalles, Actividades y Abonos.
        /// </summary>
        public PlanTratamiento()
        {
            Detalles = new List<Detalle>();
            Actividades = new List<Actividad>();
            Abonos = new List<Abono>();
        }
        /// <summary>
        /// Constructor con parámetros de la clase <c>PlanTratamiento</c>.
        /// </summary>
        /// <param name="idPlanTratamiento">Identificador de tipo entero para el Plan de Tratamiento.</param>
        /// <param name="descripcion"><c>String</c> que define la descripcion del tratamiento a realizar.</param>
        /// <param name="estado">Valor booleano para determinar si el tratamiento a finalizado o no.</param>
        /// <param name="fechaPlanTratamiento"><c>DateTime</c> que indica cuando fue creado el tratamiento.</param>
        /// <param name="detalles">Lista de detalles que se realizarán en el tratamiento en base a la clase <c>Detalle</c></param>
        /// <param name="actividades">Lista de actividades realizadas en el tratamiento en base a la clase <c>Actividad</c></param>
        /// <param name="abonos">Lista de abonos realizados durante el tratamiento en base a la clase <c>Abono</c></param>
        /// <param name="subtotal">Valor <c>double</c> que contiene el subtotal del tratamiento en base al cálculo de los detalles.</param>
        /// <param name="total">Valor <c>double</c> que define el valor total del tratamiento puesto por el doctor.</param>
        public PlanTratamiento(int idPlanTratamiento, string descripcion, bool estado, DateTime fechaPlanTratamiento, List<Detalle> detalles, List<Actividad> actividades, List<Abono> abonos, double subtotal, double total)
        {
            this.IdPlanTratamiento = idPlanTratamiento;
            this.Descripcion = descripcion;
            this.Estado = estado;
            this.FechaPlanTratamiento = fechaPlanTratamiento;
            this.Detalles = detalles;
            this.Actividades = actividades;
            this.Abonos = abonos;
            this.Subtotal = subtotal;
            this.Total = total;
        }
        /// <summary>
        /// Método get y set del atributo <c>IdPlanTratamiento</c>.
        /// </summary>
        public int IdPlanTratamiento { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Descripcion</c>.
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Estado</c>.
        /// </summary>
        public bool Estado { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>FechaPlanTratamiento</c>.
        /// </summary>
        public DateTime FechaPlanTratamiento { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Detalles</c>.
        /// </summary>
        public List<Detalle> Detalles { get; set; } = new List<Detalle>();
        /// <summary>
        /// Método get y set del atributo <c>Actividades</c>.
        /// </summary>
        public List<Actividad> Actividades { get; set; } = new List<Actividad>();
        /// <summary>
        /// Método get y set del atributo <c>Abonos</c>.
        /// </summary>
        public List<Abono> Abonos { get; set; } = new List<Abono>();
        /// <summary>
        /// Método get y set del atributo <c>Subtotal</c>.
        /// </summary>
        public double Subtotal { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Total</c>.
        /// </summary>
        public double Total { get; set; }
    }
}

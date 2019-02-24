using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class PlanTratamiento
    {
        public PlanTratamiento()
        {
            Detalles = new List<Detalle>();
            Actividades = new List<Actividad>();
            Abonos = new List<Abono>();
        }
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
        public int IdPlanTratamiento { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaPlanTratamiento { get; set; }
        public List<Detalle> Detalles { get; set; } = new List<Detalle>();
        public List<Actividad> Actividades { get; set; } = new List<Actividad>();
        public List<Abono> Abonos { get; set; } = new List<Abono>();
        public double Subtotal { get; set; }
        public double Total { get; set; }
    }
}

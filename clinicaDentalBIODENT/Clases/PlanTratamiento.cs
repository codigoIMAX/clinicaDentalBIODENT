using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicaDentalBIODENT.Clases
{
    class PlanTratamiento
    {
        private int idPlanTratamiento;
        private string descripcion;
        private bool estado;
        private DateTime fechaPlanTratamiento;
        private List<Detalle> detalles;
        private List<Actividad> actividades;
        private List<Abono> abonos;
        private double subtotal;
        private double total;
        public PlanTratamiento()
        {

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
        public int IdPlanTratamiento { get => idPlanTratamiento; set => idPlanTratamiento = value; }
        public bool Estado { get => estado; set => estado = value; }
        public DateTime FechaPlanTratamiento { get => fechaPlanTratamiento; set => fechaPlanTratamiento = value; }
        public double Subtotal { get => subtotal; set => subtotal = value; }
        public double Total { get => total; set => total = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        internal List<Detalle> Detalles { get => detalles; set => detalles = value; }
        internal List<Actividad> Actividades { get => actividades; set => actividades = value; }
        internal List<Abono> Abonos { get => abonos; set => abonos = value; }
    }
}

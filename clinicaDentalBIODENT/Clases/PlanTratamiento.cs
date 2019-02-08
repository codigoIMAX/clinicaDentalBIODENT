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
        private int estado;
        private DateTime fechaPlanTratamiento;
        private List<Detalle> detalles;
        private List<Tratamiento> tratamientos;
        private double subtotal;
        private double descuento;
        private double total;
        public PlanTratamiento()
        {

        }
        public PlanTratamiento(int idPlanTratamiento, int estado, DateTime fechaPlanTratamiento, List<Detalle> detalles, List<Tratamiento> tratamientos, double subtotal, double descuento, double total)
        {
            this.IdPlanTratamiento = idPlanTratamiento;
            this.Estado = estado;
            this.FechaPlanTratamiento = fechaPlanTratamiento;
            this.Detalles = detalles;
            this.Tratamientos = tratamientos;
            this.Subtotal = subtotal;
            this.Descuento = descuento;
            this.Total = total;
        }

        public int IdPlanTratamiento { get => idPlanTratamiento; set => idPlanTratamiento = value; }
        public int Estado { get => estado; set => estado = value; }
        public DateTime FechaPlanTratamiento { get => fechaPlanTratamiento; set => fechaPlanTratamiento = value; }
        public double Subtotal { get => subtotal; set => subtotal = value; }
        public double Descuento { get => descuento; set => descuento = value; }
        public double Total { get => total; set => total = value; }
        internal List<Detalle> Detalles { get => detalles; set => detalles = value; }
        internal List<Tratamiento> Tratamientos { get => tratamientos; set => tratamientos = value; }
    }
}

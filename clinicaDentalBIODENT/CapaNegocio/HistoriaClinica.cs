using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class HistoriaClinica
    {
        public HistoriaClinica()
        {
            PiezasDentales = new List<PiezaDental>();
            PlanesTratamientos = new List<PlanTratamiento>();
        }
        public HistoriaClinica(int numeroHistoriaClinica, Paciente paciente, string tratamientoMedicoActual, string tomaMedicamentoActual, AntecedentePF antecedentes, string observaciones, List<PiezaDental> piezasDentales, List<PlanTratamiento> planesTratamientos)
        {
            this.NumeroHistoriaClinica = numeroHistoriaClinica;
            this.Paciente = paciente;
            this.TratamientoMedicoActual = tratamientoMedicoActual;
            this.TomaMedicamentoActual = tomaMedicamentoActual;
            this.Antecedentes = antecedentes;
            this.Observaciones = observaciones;
            this.PiezasDentales = piezasDentales;
            this.PlanesTratamientos = planesTratamientos;
        }

        public int NumeroHistoriaClinica { get; set; }
        public Paciente Paciente { get; set; }
        public string TratamientoMedicoActual { get; set; }
        public string TomaMedicamentoActual { get; set; }
        public AntecedentePF Antecedentes { get; set; }
        public string Observaciones { get; set; }
        public List<PiezaDental> PiezasDentales { get; set; }
        public List<PlanTratamiento> PlanesTratamientos { get; set; }
    }
}

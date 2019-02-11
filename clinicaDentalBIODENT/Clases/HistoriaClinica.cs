using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicaDentalBIODENT.Clases
{
    class HistoriaClinica
    {
        private int numeroHistoriaClinica;
        private Paciente paciente;
        private string tratamientoMedicoActual;
        private string tomaMedicamentoActual;
        private AntecedentePF antecedentes;
        private string observaciones;
        private List<PiezaDental> piezasDentales;
        private List<PlanTratamiento> planesTratamientos;
        public HistoriaClinica()
        {
            piezasDentales = new List<PiezaDental>();
            planesTratamientos = new List<PlanTratamiento>();
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
        public int NumeroHistoriaClinica { get => numeroHistoriaClinica; set => numeroHistoriaClinica = value; }
        public string TratamientoMedicoActual { get => tratamientoMedicoActual; set => tratamientoMedicoActual = value; }
        public string TomaMedicamentoActual { get => tomaMedicamentoActual; set => tomaMedicamentoActual = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        internal Paciente Paciente { get => paciente; set => paciente = value; }
        internal AntecedentePF Antecedentes { get => antecedentes; set => antecedentes = value; }
        internal List<PiezaDental> PiezasDentales { get => piezasDentales; set => piezasDentales = value; }
        internal List<PlanTratamiento> PlanesTratamientos { get => planesTratamientos; set => planesTratamientos = value; }
    }
}

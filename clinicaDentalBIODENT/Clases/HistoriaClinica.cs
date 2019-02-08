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
        private string cedulaPaciente;
        private string antecedentesPersonales;
        private string antecedentesPersonalesFamiliares;
        private string observaciones;
        private DateTime fechaIngreso;
        private List<PlanTratamiento> planesTratamiento;
        private List<PiezaDental> piezasDentales;
        public HistoriaClinica()
        {

        }
        public HistoriaClinica(int numeroHistoriaClinica, string cedulaPaciente, string antecedentesPersonales, string antecedentesPersonalesFamiliares, string observaciones, DateTime fechaIngreso, List<PlanTratamiento> planesTratamiento, List<PiezaDental> piezasDentales)
        {
            this.NumeroHistoriaClinica = numeroHistoriaClinica;
            this.CedulaPaciente = cedulaPaciente;
            this.AntecedentesPersonales = antecedentesPersonales;
            this.AntecedentesPersonalesFamiliares = antecedentesPersonalesFamiliares;
            this.Observaciones = observaciones;
            this.FechaIngreso = fechaIngreso;
            this.PlanesTratamiento = planesTratamiento;
            this.PiezasDentales = piezasDentales;
        }

        public int NumeroHistoriaClinica { get => numeroHistoriaClinica; set => numeroHistoriaClinica = value; }
        public string CedulaPaciente { get => cedulaPaciente; set => cedulaPaciente = value; }
        public string AntecedentesPersonales { get => antecedentesPersonales; set => antecedentesPersonales = value; }
        public string AntecedentesPersonalesFamiliares { get => antecedentesPersonalesFamiliares; set => antecedentesPersonalesFamiliares = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        internal List<PlanTratamiento> PlanesTratamiento { get => planesTratamiento; set => planesTratamiento = value; }
        internal List<PiezaDental> PiezasDentales { get => piezasDentales; set => piezasDentales = value; }
    }
}

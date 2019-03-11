using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    /// <summary>
    /// Clase que define la Historia Clínica del paciente.
    /// </summary>
    public class HistoriaClinica
    {
        /// <summary>
        /// Constructor por defecto de la clase <c>HistoriaClinica</c>.
        /// </summary>
        /// <remarks>
        /// Instancia las listas vacías de Piezas Dentales y Planes de Tratamientos.
        /// </remarks>
        public HistoriaClinica()
        {
            PiezasDentales = new List<PiezaDental>();
            PlanesTratamientos = new List<PlanTratamiento>();
        }
        /// <summary>
        /// Constructor con parámetros de la clase <c>HistoriaClinica</c>.
        /// </summary>
        /// <param name="numeroHistoriaClinica">Valor entero que especifica el número de Historia Clínica.</param>
        /// <param name="paciente">Paciente al que pertenece la Historia Clínica.</param>
        /// <param name="tratamientoMedicoActual">Valor <c>string</c> que describe si el paciente se encuentra en algún tratamiento.</param>
        /// <param name="tomaMedicamentoActual">Valor <c>string</c> que describe si el paciente está tomando algún medicamento actualmente.</param>
        /// <param name="antecedentes">Antecedentes Personales Familiares especificados en la clase <c>AntecedentePF</c>.</param>
        /// <param name="observaciones">Valor <c>string</c> que especifica otros datos opcionales referentes al paciente.</param>
        /// <param name="piezasDentales">Lista de piezas dentales del tipo <c>PiezaDental</c>.</param>
        /// <param name="planesTratamientos">Lista de planes de tratamiento del tipo <c>PlanTratamiento</c>.</param>
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
        /// <summary>
        /// Método get y set del atributo <c>NumeroHistoriaClinica</c>.
        /// </summary>
        public int NumeroHistoriaClinica { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Paciente</c>.
        /// </summary>
        public Paciente Paciente { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>TratamientoMedicoActual</c>.
        /// </summary>
        public string TratamientoMedicoActual { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>TomaMedicamentoActual</c>.
        /// </summary>
        public string TomaMedicamentoActual { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Antecedentes</c>.
        /// </summary>
        public AntecedentePF Antecedentes { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Observaciones</c>.
        /// </summary>
        public string Observaciones { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>PiezasDentales</c>.
        /// </summary>
        public List<PiezaDental> PiezasDentales { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>PlanesTratamientos</c>.
        /// </summary>
        public List<PlanTratamiento> PlanesTratamientos { get; set; }
    }
}

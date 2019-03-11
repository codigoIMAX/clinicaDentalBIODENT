using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    /// <summary>
    /// Esta clase permite definir los antecendetes personales familiares asociados a un paciente.
    /// Esta clase está relacionada con la historia clínica del paciente.
    /// </summary>
    public class AntecedentePF
    {
        /// <summary>
        /// Constructor por defecto la clase <c>AntecedentePF</c>.
        /// </summary>
        public AntecedentePF()
        {

        }
        /// <summary>
        /// Constructor con parámetros de la clase <c>AntecedentePF</c>.
        /// </summary>
        /// <param name="alergiaAntibiotico">Valor booleano que determina si el paciente es alérgico a un antibiótico.</param>
        /// <param name="alergiaAnestesia">Valor booleano que determina si el paciente es alérgico a la anestesia.</param>
        /// <param name="hemorragia">Valor booleano que determina si el paciente tiene hemorragia.</param>
        /// <param name="sida">Valor booleano que determina si el paciente tiene SIDA.</param>
        /// <param name="tuberculosis">Valor booleano que determina si el paciente tiene tuberculosis.</param>
        /// <param name="diabetes">Valor booleano que determina si el paciente tiene diabetes.</param>
        /// <param name="asma">Valor booleano que determina si el paciente tiene asma.</param>
        /// <param name="hipertension">Valor booleano que determina si el paciente tiene hipertensión.</param>
        /// <param name="enfermedadCardiaca">Valor booleano que determina si el paciente posee una enfermedad cardíaca.</param>
        /// <param name="bebidasAlcoholicas">Valor booleano que determina si el paciente toma bebidas alcohólicas.</param>
        /// <param name="frecuencia">String que especifica con que frecuencia el paciente toma bebidas alcohólicas.</param>
        /// <param name="fuma">Valor booleano que determina si el paciente fuma.</param>
        /// <param name="numeroCigarros">String que especifica la cantidad de cigarrillos que fuma el paciente.</param>
        /// <param name="observaciones">String para agregar información adicional a los antecedentes personales del paciente.</param>
        public AntecedentePF(bool alergiaAntibiotico, bool alergiaAnestesia, bool hemorragia, bool sida, bool tuberculosis, bool diabetes, bool asma, bool hipertension, bool enfermedadCardiaca, bool bebidasAlcoholicas, string frecuencia, bool fuma, string numeroCigarros, string observaciones)
        {
            this.AlergiaAntibiotico = alergiaAntibiotico;
            this.AlergiaAnestesia = alergiaAnestesia;
            this.Hemorragia = hemorragia;
            this.Sida = sida;
            this.Tuberculosis = tuberculosis;
            this.Diabetes = diabetes;
            this.Asma = asma;
            this.Hipertension = hipertension;
            this.EnfermedadCardiaca = enfermedadCardiaca;
            this.BebidasAlcoholicas = bebidasAlcoholicas;
            this.Frecuencia = frecuencia;
            this.Fuma = fuma;
            this.NumeroCigarros = numeroCigarros;
            this.Observaciones = observaciones;
        }
        /// <summary>
        /// Método get y set del atributo <c>AlergiaAntibiotico</c>.
        /// </summary>
        public bool AlergiaAntibiotico { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>AlergiaAnestesia</c>.
        /// </summary>
        public bool AlergiaAnestesia { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Hemorragia</c>.
        /// </summary>
        public bool Hemorragia { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Sida</c>.
        /// </summary>
        public bool Sida { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Tuberculosis</c>.
        /// </summary>
        public bool Tuberculosis { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Diabetes</c>.
        /// </summary>
        public bool Diabetes { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Asma</c>.
        /// </summary>
        public bool Asma { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Hipertension</c>.
        /// </summary>
        public bool Hipertension { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>EnfermedadCardiaca</c>.
        /// </summary>
        public bool EnfermedadCardiaca { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>BebidasAlcoholicas</c>.
        /// </summary>
        public bool BebidasAlcoholicas { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Frecuencia</c>.
        /// </summary>
        public string Frecuencia { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Fuma</c>.
        /// </summary>
        public bool Fuma { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>NumeroCigarros</c>.
        /// </summary>
        public string NumeroCigarros { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>Observaciones</c>.
        /// </summary>
        public string Observaciones { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class AntecedentePF
    {
        public AntecedentePF()
        {

        }
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
        public bool AlergiaAntibiotico { get; set; }
        public bool AlergiaAnestesia { get; set; }
        public bool Hemorragia { get; set; }
        public bool Sida { get; set; }
        public bool Tuberculosis { get; set; }
        public bool Diabetes { get; set; }
        public bool Asma { get; set; }
        public bool Hipertension { get; set; }
        public bool EnfermedadCardiaca { get; set; }
        public bool BebidasAlcoholicas { get; set; }
        public string Frecuencia { get; set; }
        public bool Fuma { get; set; }
        public string NumeroCigarros { get; set; }
        public string Observaciones { get; set; }
    }
}

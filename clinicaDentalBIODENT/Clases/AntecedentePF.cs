using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicaDentalBIODENT.Clases
{
    class AntecedentePF
    {
        private bool alergiaAntibiotico;
        private bool alergiaAnestesia;
        private bool hemorragia;
        private bool sida;
        private bool tuberculosis;
        private bool diabetes;
        private bool asma;
        private bool hipertension;
        private bool enfermedadCardiaca;
        private bool bebidasAlcoholicas;
        private string frecuencia;
        private bool fuma;
        private string numeroCigarros;
        private string observaciones;
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
        public bool AlergiaAntibiotico { get => alergiaAntibiotico; set => alergiaAntibiotico = value; }
        public bool AlergiaAnestesia { get => alergiaAnestesia; set => alergiaAnestesia = value; }
        public bool Hemorragia { get => hemorragia; set => hemorragia = value; }
        public bool Sida { get => sida; set => sida = value; }
        public bool Tuberculosis { get => tuberculosis; set => tuberculosis = value; }
        public bool Diabetes { get => diabetes; set => diabetes = value; }
        public bool Asma { get => asma; set => asma = value; }
        public bool Hipertension { get => hipertension; set => hipertension = value; }
        public bool EnfermedadCardiaca { get => enfermedadCardiaca; set => enfermedadCardiaca = value; }
        public bool BebidasAlcoholicas { get => bebidasAlcoholicas; set => bebidasAlcoholicas = value; }
        public string Frecuencia { get => frecuencia; set => frecuencia = value; }
        public bool Fuma { get => fuma; set => fuma = value; }
        public string NumeroCigarros { get => numeroCigarros; set => numeroCigarros = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
    }
}

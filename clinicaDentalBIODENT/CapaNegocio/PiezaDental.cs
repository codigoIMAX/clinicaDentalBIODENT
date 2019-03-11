using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    /// <summary>
    /// Esta clase permite definir una pieza dental que será utlizada para mostrar los colores en la gráfica correspondiente a dicha pieza.
    /// </summary>
    public class PiezaDental
    {
        /// <summary>
        /// Constructor por defecto de la clase <c>PiezaDental</c>.
        /// </summary>
        public PiezaDental()
        {

        }
        /// <summary>
        /// Constructor con parámetros de la clase <c>PiezaDental</c>.
        /// </summary>
        /// <param name="numeroPieza">Valor entero que identifica a la pieza dental.</param>
        /// <param name="colorArriba"><c>String</c> que almacena el color en la parte superior del gráfico de la pieza dental.</param>
        /// <param name="colorDerecha"><c>String</c> que almacena el color en la parte derecha del gráfico de la pieza dental.</param>
        /// <param name="colorAbajo"><c>String</c> que almacena el color en la parte inferior del gráfico de la pieza dental.</param>
        /// <param name="colorIzquierda"><c>String</c> que almacena el color en la parte izquierda del gráfico de la pieza dental.</param>
        /// <param name="colorCentro"><c>String</c> que almacena el color en la parte central del gráfico de la pieza dental.</param>
        public PiezaDental(int numeroPieza, string colorArriba, string colorDerecha, string colorAbajo, string colorIzquierda, string colorCentro)
        {
            this.NumeroPieza = numeroPieza;
            this.ColorArriba = colorArriba;
            this.ColorDerecha = colorDerecha;
            this.ColorAbajo = colorAbajo;
            this.ColorIzquierda = colorIzquierda;
            this.ColorCentro = colorCentro;
        }
        /// <summary>
        /// Método get y set del atributo <c>NumeroPieza</c>.
        /// </summary>
        public int NumeroPieza { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>ColorArriba</c>.
        /// </summary>
        public string ColorArriba { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>ColorDerecha</c>.
        /// </summary>
        public string ColorDerecha { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>ColorAbajo</c>.
        /// </summary>
        public string ColorAbajo { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>ColorIzquierda</c>.
        /// </summary>
        public string ColorIzquierda { get; set; }
        /// <summary>
        /// Método get y set del atributo <c>ColorCentro</c>.
        /// </summary>
        public string ColorCentro { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;
        public string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        /// <summary>
        /// Constructor por defecto de operando
        /// </summary>
        public Operando()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor parametrizado de operando
        /// </summary>
        /// <param name="numero">Numero con el que se va a inicializar el campo "numero"</param>
        public Operando(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Segundo constructor parametrizado de operando
        /// </summary>
        /// <param name="numero">Numero con el que se va a inicializar la propiedad "Numero"</param>
        public Operando(string numero)
        {
            this.Numero = numero;
        }

        /// <summary>
        /// Valida que el operando ingresado por el usuario sea un numero
        /// </summary>
        /// <param name="strNumero">Operando ingresado por el usuario</param>
        /// <returns>Numero validado y parseado</returns>
        private double ValidarOperando(string strNumero)
        {
            double numeroRetorno = 0;
            double numero;
            if (double.TryParse(strNumero, out numero))
            {
                numeroRetorno = numero;
            }
            return numeroRetorno;
        }

        /// <summary>
        /// Valida si el numero pasado como parametro es binario
        /// </summary>
        /// <param name="binario">numero a validar si es binario</param>
        /// <returns>true si es binario, false si no</returns>
        private bool EsBinario(string binario)
        {
            bool confirmacion = false;// = true;
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] == '0' || binario[i] == '1')
                {
                    confirmacion = true;
                    continue;
                }
                confirmacion = false;
                break;
            }
            return confirmacion;
        }

        /// <summary>
        /// Convierte de decimal a binario
        /// </summary>
        /// <param name="numero">numero a convertir de tipo double</param>
        /// <returns>Numero convertido a binario</returns>
        public string DecimalBinario(double numero)
        {
            string numBinario = "Valor inválido";
            int numeroEntero = (int)(double.Parse((numero.ToString()).Replace("-", "")));
            numBinario = null;
            do
            {
                numBinario = (numeroEntero % 2) + numBinario;
                numeroEntero = numeroEntero / 2;
            } while (numeroEntero != 0);


            return numBinario;
        }

        /// <summary>
        /// Convierte de decimal a binario
        /// </summary>
        /// <param name="numero">numero a convertir de tipo string</param>
        /// <returns>Numero convertido a binario</returns>
        public string DecimalBinario(string numero)
        {
            double numeroParseado = -1;
            double.TryParse(numero, out numeroParseado);
            return DecimalBinario(numeroParseado);
        }

        /// <summary>
        /// Convierte de binario a decimal
        /// </summary>
        /// <param name="binario">nuemro binario a convertir en decimal</param>
        /// <returns>Numero convertido en decimal</returns>
        public string BinarioDecimal(string binario)
        {
            double resultado = 0;
            int multiplicador = 1;
            string retorno = "Valor inválido";
            if (EsBinario(binario))
            {
                for (int i = binario.Length - 1; i >= 0; i--)
                {
                    if (binario[i] == '1')
                    {
                        resultado += multiplicador;
                    }
                    multiplicador = multiplicador * 2;
                }
                retorno = "" + resultado;
            }
            return retorno; ;
        }

        /// <summary>
        /// Realiza la resta entre 2 operandos
        /// </summary>
        /// <param name="n1">primer operando</param>
        /// <param name="n2">segundo operando</param>
        /// <returns>resultado de la resta</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Realiza la suma entre 2 operandos
        /// </summary>
        /// <param name="n1">Primer operando</param>
        /// <param name="n2">Segundo operando</param>
        /// <returns>resultado de la suma</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Realiza la divición entre 2 operadores
        /// </summary>
        /// <param name="n1">primer operando</param>
        /// <param name="n2">segundo operando</param>
        /// <returns>resultado de la divición</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            double retorno = n1.numero / n2.numero;
            if (n2.numero == 0)
            {
                retorno = double.MinValue;
            }
            return retorno;
        }

        /// <summary>
        /// Realiza la multiplicación entre 2 operandos
        /// </summary>
        /// <param name="n1">Primer operando</param>
        /// <param name="n2">Segundo operando</param>
        /// <returns></returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
    }
}

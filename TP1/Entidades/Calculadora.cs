using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Es la encargada de realizar todas las operaciones
        /// </summary>
        /// <param name="num1">Primer operando</param>
        /// <param name="num2">Segundo operando</param>
        /// <param name="operador">Operador elegido por el usuario</param>
        /// <returns></returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;
            char operadorValidado = ValidarOperador(operador);
            switch (operadorValidado)
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
            }
            return resultado;
        }
        /// <summary>
        /// Valida los operadores, en caso de no ser un operador válido, lo reemplaza por '+'
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns>Operador validado</returns>
        private static char ValidarOperador(char operador)
        {
            char operadorValidado = '+';
            if (operador == '/' || operador == '*' || operador == '-')
            {
                operadorValidado = operador;
            }
            return operadorValidado;
        }
    }
}

using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida si el operador recibido es valido.
        /// Si no devuelve '+'
        /// </summary>
        /// <param name="operador">Operador "+ - * /"</param>
        /// <returns>Operador valido</returns>

        private static string ValidarOperador(string operador)
        {
            if (operador != "-" && operador != "*" && operador != "/")
            {
                return "+";
            }

            return operador;
        }


        /// <summary>
        /// Realiza la operacion entre dos numeros.
        /// </summary>
        /// <param name="num1">Operando 1</param>
        /// <param name="num2">Operando 2</param>
        /// <param name="operador">"+ - * /"</param>
        /// <returns>Resultado</returns>

        public static double Operar(Operando num1, Operando num2, string operador)
        {

            double resultado = 0;

            switch (ValidarOperador(operador))
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }

            return resultado;
        }

    }
}

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

        /// <summary>
        /// Constructor del tipo Operando por defecto.
        /// Inicializa el atributo numero en 0
        /// </summary>

        public Operando()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor del tipo Operando que inicializa con el valor pasado por parametro
        /// </summary>
        /// <param name="numero">Recibe un double</param>

        public Operando(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor del tipo Operando que inicializa con el valor pasado por parametro
        /// </summary>
        /// <param name="strNumero">Recibe un string</param>

        public Operando(string strNumero)
        {
            Numero = strNumero;
        }


        /// <summary>
        /// Propiedad para modificar el parametro numero
        /// </summary>

        private string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        /// <summary>
        /// Valida que el operando ingresado sea valido.
        /// Si no devuelve 0
        /// </summary>
        /// <param name="strNumero"> Operando de tipo string</param>
        /// <returns>Operando valido o 0</returns>

        private double ValidarOperando(string strNumero)
        {
            if (double.TryParse(strNumero, out numero))
            {
                return numero;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Valida si el dato ingresado es binario.
        /// </summary>
        /// <param name="binario">String binario</param>
        /// <returns>true si es binario; false si no</returns>

        private bool EsBinario(string binario)
        {
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '1' && binario[i] != '0')
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// Convierte un string binario en un string decimal
        /// </summary>
        /// <param name="binario">string binario</param>
        /// <returns>resultado decimal o "Valor invalido"</returns>

        public string BinarioDecimal(string binario)
        {
            if (EsBinario(binario))
            {
                int modulo;
                int exponente = 0;
                double resultado = 0;
                int numero;

                int.TryParse(binario, out numero);

                do
                {
                    modulo = numero % 10;
                    numero = numero / 10;
                    resultado += modulo * Math.Pow(2, exponente);
                    exponente++;
                } while (numero != 0);

                resultado = (int)resultado;

                return resultado.ToString();
            }
            return "Valor inválido";
        }

        /// <summary>
        /// Convierte un numero decimal a binario
        /// </summary>
        /// <param name="numero">decimal a convertir</param>
        /// <returns>string resultado</returns>

        public string DecimalBinario(double numero)
        {
            string aux = numero.ToString();
            return DecimalBinario(aux);
        }

        /// <summary>
        /// Convierte un string decimal a binario
        /// </summary>
        /// <param name="numero">string a convertir</param>
        /// <returns>string resultado</returns>

        public string DecimalBinario(string numero)
        {
            int modulo;
            int numeroAux;
            int calculo;

            int.TryParse(numero, out numeroAux);

            calculo = numeroAux;

            StringBuilder sbResultado = new StringBuilder();

            do
            {
                modulo = calculo % 2;
                calculo = calculo / 2;
                sbResultado.Append(modulo.ToString());
            } while (calculo > 0);

            StringBuilder sb = new StringBuilder();

            for (int i = sbResultado.Length-1; i >= 0; i--)
            {
                sb.Append(sbResultado[i]);
            }

            return sb.ToString();
        }


        /// <summary>
        /// Sobrecarga del operador '+' para operar con objetos del tipo Operando.
        /// </summary>
        /// <param name="operando1">Operando numero 1</param>
        /// <param name="operando2">Operando numero 2</param>
        /// <returns>Resultado de la operacion</returns>

        public static double operator + (Operando operando1, Operando operando2)
        {
            return operando1.numero + operando2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador '-' para operar con objetos del tipo Operando.
        /// </summary>
        /// <param name="operando1">Operando numero 1</param>
        /// <param name="operando2">Operando numero 2</param>
        /// <returns>Resultado de la operacion</returns>

        public static double operator - (Operando operando1, Operando operando2)
        {
            return operando1.numero - operando2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador '*' para operar con objetos del tipo Operando.
        /// </summary>
        /// <param name="operando1">Operando numero 1</param>
        /// <param name="operando2">Operando numero 2</param>
        /// <returns>Resultado de la operacion</returns>

        public static double operator * (Operando operando1, Operando operando2)
        {
            return operando1.numero * operando2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador '/' para operar con objetos del tipo Operando.
        /// </summary>
        /// <param name="operando1">Operando numero 1</param>
        /// <param name="operando2">Operando numero 2</param>
        /// <returns>Resultado de la operacion o double.MinValue si se divide por 0</returns>

        public static double operator / (Operando operando1, Operando operando2)
        {
            if (operando2.numero != 0)
            {
                return operando1.numero / operando2.numero;
            }
            else
            {
                return double.MinValue;
            }
   
        }

    }
}


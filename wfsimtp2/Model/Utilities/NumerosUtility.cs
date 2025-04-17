using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfsimtp2
{
    public static class NumerosUtility
    {
        private static readonly Random Random = new Random();

        /// <summary>
        /// Trunca un número a 4 decimales
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static double Truncar4Decimales(double num)
            => Math.Truncate(num * 10000) / 10000;

        /// <summary>
        /// Devuelve un número aleatorio de tipo double en el
        /// intervalo[0, 1), es decir, incluye 0 pero excluye 1.
        /// </summary>
        /// <returns></returns>
        public static double GetAleatorio()
        {
            return Random.NextDouble();
        }
    }
}

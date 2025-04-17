using System;
using System.Collections.Generic;
using System.Linq;

namespace wfsimtp2.Model
{
    public class ExponencialDistribution
    {
        public List<double> VariablesAleatorias { get; private set; }
        public List<IntervaloFrecuencia> Intervalos { get; private set; }

        public void Generar(int tamMuestra, int cantIntervalos, double lambda)
        {
            VariablesAleatorias = GenerarAleatorios(lambda, tamMuestra);
            Intervalos = CalcularFrecuencias(VariablesAleatorias, cantIntervalos, tamMuestra, lambda);
        }

        private List<double> GenerarAleatorios(double lambda, int cantidadMuestras)
        {
            var aleatorios = new List<double>();
            for (int i = 0; i < cantidadMuestras; i++)
            {
                double u = NumerosUtility.GetAleatorio();
                double valor = -1.0 / lambda * Math.Log(1 - u);
                aleatorios.Add(NumerosUtility.Truncar4Decimales(valor));
            }
            return aleatorios;
        }

        private List<IntervaloFrecuencia> CalcularFrecuencias(List<double> datos, int cantIntervalos, int tamMuestra, double lambda)
        {
            var lista = new List<IntervaloFrecuencia>();
            double min = datos.Min(), max = datos.Max();
            double ancho = (max - min) / cantIntervalos + 0.0001;
            double inf = min;

            double foAcumulada = 0, feAcumulada = 0;

            for (int i = 0; i < cantIntervalos; i++)
            {
                double sup = inf + ancho;

                int fo = datos.Count(x => x >= inf && x < sup);
                double fe = CalcularFrecuenciaEsperada(inf, sup, lambda, tamMuestra);

                foAcumulada += fo;
                feAcumulada += fe;

                lista.Add(new IntervaloFrecuencia
                {
                    LimiteInferior = NumerosUtility.Truncar4Decimales(inf),
                    LimiteSuperior = NumerosUtility.Truncar4Decimales(sup),
                    FrecuenciaObservada = NumerosUtility.Truncar4Decimales(fo),
                    FrecuenciaEsperada = NumerosUtility.Truncar4Decimales(fe),
                    FOAcumulada = NumerosUtility.Truncar4Decimales(foAcumulada),
                    FEAcumulada = NumerosUtility.Truncar4Decimales(feAcumulada)
                });

                inf = sup;
            }

            return lista;
        }

        private double CalcularFrecuenciaEsperada(double li, double ls, double lambda, int n)
        {
            return (Math.Exp(-lambda * li) - Math.Exp(-lambda * ls)) * n;
        }
    }
}

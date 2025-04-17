using System;
using System.Collections.Generic;
using System.Linq;

namespace wfsimtp2.Model
{
    public class UniformDistribution
    {
        public List<double> VariablesAleatorias { get; private set; }
        public List<IntervaloFrecuencia> Intervalos { get; private set; }

        public void Generar(int tamMuestra, int cantIntervalos, double limInferior, double limSuperior)
        {
            VariablesAleatorias = GenerarAleatoriosUniforme(tamMuestra, limInferior, limSuperior);
            Intervalos = CalcularFrecuencias(VariablesAleatorias, cantIntervalos, tamMuestra, limInferior, limSuperior);
        }

        private List<double> GenerarAleatoriosUniforme(int cantidadMuestras, double a, double b)
        {
            var aleatorios = new List<double>();
            for (int i = 0; i < cantidadMuestras; i++)
            {
                double u = NumerosUtility.GetAleatorio();
                double x = a + (u * (b - a));
                aleatorios.Add(NumerosUtility.Truncar4Decimales(x));
            }
            return aleatorios;
        }

        private List<IntervaloFrecuencia> CalcularFrecuencias(List<double> datos, int cantIntervalos, int tamMuestra, double a, double b)
        {
            var lista = new List<IntervaloFrecuencia>();
            double min = datos.Min(), max = datos.Max();
            double ancho = (max - min) / cantIntervalos + 0.0001;
            double inf = min;

            double fe = (double)tamMuestra / cantIntervalos;
            double foAcumulada = 0, feAcumulada = 0;

            for (int i = 0; i < cantIntervalos; i++)
            {
                double sup = inf + ancho;
                int fo = datos.Count(x => x >= inf && x < sup);

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
    }
}

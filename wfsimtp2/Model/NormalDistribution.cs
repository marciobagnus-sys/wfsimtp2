using System;
using System.Collections.Generic;
using System.Linq;

namespace wfsimtp2.Model
{
    public class NormalDistribution
    {
        public List<double> VariablesAleatorias { get; private set; }
        public List<IntervaloFrecuencia> Intervalos { get; private set; }

        public void Generar(int tamMuestra, int cantIntervalos, double media, double desviacion)
        {
            VariablesAleatorias = GenerarAleatoriosBoxMuller(media, desviacion, tamMuestra);
            Intervalos = CalcularFrecuencias(VariablesAleatorias, cantIntervalos, tamMuestra, media, desviacion);
        }
        private List<double> GenerarAleatoriosBoxMuller(double media, double desviacion, int cantidadMuestras)
        {
            var aleatorios = new List<double>();
            for (int i = 0; i < cantidadMuestras; i += 2)
            {
                double u1 = NumerosUtility.GetAleatorio();
                double u2 = NumerosUtility.GetAleatorio();
                double z1 = Math.Sqrt(-2 * Math.Log(u1)) * Math.Cos(2 * Math.PI * u2);
                double z2 = Math.Sqrt(-2 * Math.Log(u1)) * Math.Sin(2 * Math.PI * u2);

                aleatorios.Add(NumerosUtility.Truncar4Decimales(z1 * desviacion + media));
                if (i + 1 < cantidadMuestras)
                    aleatorios.Add(NumerosUtility.Truncar4Decimales(z2 * desviacion + media));
            }
            return aleatorios;
        }
        private List<IntervaloFrecuencia> CalcularFrecuencias(List<double> datos, int cantIntervalos, int tamMuestra, double media, double desviacion)
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
                double fe = CalcularFrecuenciaEsperada(inf, sup, media, desviacion, tamMuestra);

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
        private double CalcularFrecuenciaEsperada(double li, double ls, double media, double desviacion, int n)
        {
            double mc = (li + ls) / 2;
            double exponente = -0.5 * Math.Pow((mc - media) / desviacion, 2);
            double f = (1 / (desviacion * Math.Sqrt(2 * Math.PI))) * Math.Exp(exponente);
            return f * (ls - li) * n;
        }

    }
}

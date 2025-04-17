using System.Collections.Generic;
using System.Threading.Tasks;
using wfsimtp2.Model;

namespace wfsimtp2.Controller
{
    public class ExponentialController
    {
        private ExponencialDistribution _modelo;

        public ExponentialController()
        {
            _modelo = new ExponencialDistribution();
        }

        public void Calcular(int muestra, int intervalos, double lambda)
        {
            _modelo.Generar(muestra, intervalos, lambda);
        }

        public async Task CalcularAsync(int muestra, int intervalos, double lambda)
        {
            await Task.Run(() =>
            {
                _modelo.Generar(muestra, intervalos, lambda);
            });
        }

        public List<double> GetVariables() => _modelo?.VariablesAleatorias;
        public List<IntervaloFrecuencia> GetIntervalos() => _modelo?.Intervalos;
    }
}

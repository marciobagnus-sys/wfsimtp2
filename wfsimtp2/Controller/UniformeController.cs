using System.Collections.Generic;
using System.Threading.Tasks;
using wfsimtp2.Model;

namespace wfsimtp2.Controller
{
    public class UniformController
    {
        private UniformDistribution _modelo;

        public UniformController()
        {
            _modelo = new UniformDistribution();
        }

        public async Task CalcularAsync(int muestra, int intervalos, double minimo, double maximo)
        {
            await Task.Run(() =>
            {
                _modelo.Generar(muestra, intervalos, minimo, maximo);
            });
        }

        public List<double> GetVariables() => _modelo?.VariablesAleatorias;
        public List<IntervaloFrecuencia> GetIntervalos() => _modelo?.Intervalos;
    }
}

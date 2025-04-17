using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wfsimtp2.Model;

namespace wfsimtp2.Controller
{
    public class NormalController
    {
        private NormalDistribution _modelo;

        public NormalController()
        {
            this._modelo = new NormalDistribution();
        }


        public async Task CalcularAsync(int muestra, int intervalos, double media, double desviacion)
        {
            await Task.Run(() =>
            {
                _modelo.Generar(muestra, intervalos, media, desviacion);
            });
        }

        public List<double> GetVariables() => _modelo?.VariablesAleatorias;
        public List<IntervaloFrecuencia> GetIntervalos() => _modelo?.Intervalos;

    }

}

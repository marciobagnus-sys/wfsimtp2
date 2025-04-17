using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfsimtp2.Model
{
    public class IntervaloFrecuencia
    {
        public double LimiteInferior { get; set; }
        public double LimiteSuperior { get; set; }
        public double FrecuenciaObservada { get; set; }
        public double FrecuenciaEsperada { get; set; }
        public double FOAcumulada { get; set; }
        public double FEAcumulada { get; set; }
    }
}

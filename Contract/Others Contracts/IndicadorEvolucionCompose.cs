using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{

    [Serializable]
    public abstract class IndicadoresEvolucionCompose
    {
        //public int IdIndicador { get; set; }

        private List<IndicadorEvolucionResult> evoluciones;
        public List<IndicadorEvolucionResult> Evoluciones
        {
            get
            {
                if (evoluciones == null)
                    evoluciones = new List<IndicadorEvolucionResult>();
                return evoluciones;
            }
            set { evoluciones = value; }
        }
    }

    [Serializable]
    public class ProyectoBeneficiarioIndicadorCompose : IndicadoresEvolucionCompose
    {
        public ProyectoBeneficiarioIndicadorResult Indicador { get; set; }
    }

    [Serializable]
    public class ProyectoBeneficioIndicadorCompose : IndicadoresEvolucionCompose
    {
        public ProyectoBeneficioIndicadorResult Indicador { get; set; }
    }

    [Serializable]
    public class ProyectoEvaluacionSectorialIndicadorCompose : IndicadoresEvolucionCompose
    {
        public ProyectoEvaluacionSectorialIndicadorResult Indicador { get; set; }
    }

}

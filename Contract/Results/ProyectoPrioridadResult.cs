using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class ProyectoPrioridadResult : _ProyectoPrioridadResult
    {
        public string Periodo
        {
            get
            {
                //Matias 20161005 - Mejora texto de plan
                //return String.Format("Plan {0} - {1} ", PlanPeriodo_AnioInicial, PlanPeriodo_AnioFinal );
                return String.Format("{0} ", PlanPeriodo_Nombre);
                //Matias 20161005 - Mejora texto de plan
            }
        }
        public string Resultado 
        {
            get
            {
                return String.Format("{0} {1}", Prioridad_Nombre, Puntaje);
            }
        }

        public bool AplicarPrioridad { get; set; }
        public Int32 IdPrioridadCalculadoOriginal { get; set; }
        public string PrioridadCalculadoOriginal { get; set; }
        public Int32 IdPrioridadCalculadoAsignada { get; set; }
        public string PrioridadCalculadoAsignada { get; set; }
        public Decimal? PuntajeCalculado { get; set; } 
    }
}

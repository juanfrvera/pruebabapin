using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    [Serializable]
    public class ProyectoEvaluacionCompose
    {
        public ProyectoResult Proyecto { get; set; }
        public Int32 IdProyecto
        {
            get { return Proyecto != null ? Proyecto.IdProyecto : 0; }
        }

        public ProyectoEvaluacionResult Evaluacion { get; set; }
        
        private List<ProyectoIndicadorEconomicoResult> indicadoresEconomico;
        public List<ProyectoIndicadorEconomicoResult> IndicadoresEconomico
        {
            get
            {
                if (indicadoresEconomico == null)
                    indicadoresEconomico = new List<ProyectoIndicadorEconomicoResult>();
                return indicadoresEconomico;
            }
            set { indicadoresEconomico = value; }
        }

        private List<ProyectoIndicadorPriorizacionResult> indicadoresPriorizacion;
        public List<ProyectoIndicadorPriorizacionResult>IndicadoresPriorizacion
        {
            get
            {
                if (indicadoresPriorizacion == null)
                    indicadoresPriorizacion = new List<ProyectoIndicadorPriorizacionResult>();
                return indicadoresPriorizacion;
            }
            set { indicadoresPriorizacion = value; }
        }

        private List<ProyectoBeneficioIndicadorCompose> indicadoresBeneficio;
        public List<ProyectoBeneficioIndicadorCompose> IndicadoresBeneficio
        {
            get
            {
                if (indicadoresBeneficio == null)
                    indicadoresBeneficio = new List<ProyectoBeneficioIndicadorCompose>();
                return indicadoresBeneficio;
            }
            set { indicadoresBeneficio = value; }
        }

        private List<ProyectoBeneficiarioIndicadorCompose> indicadoresBeneficiario;
        public List<ProyectoBeneficiarioIndicadorCompose> IndicadoresBeneficiario

        {
            get
            {
                if (indicadoresBeneficiario == null)
                    indicadoresBeneficiario = new List<ProyectoBeneficiarioIndicadorCompose>();
                return indicadoresBeneficiario;
            }
            set { indicadoresBeneficiario = value; }
        }
        
    }

}

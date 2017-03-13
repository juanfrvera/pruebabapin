using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class ProyectoBeneficioIndicadorResult : _ProyectoBeneficioIndicadorResult
    {
        public string Indicador_MedioVerificacion { get; set; }
        public string IndicadorClase_Unidad { get; set; }
        //German 20140511 - Tarea 124
        //public int IdIndicadorRubro { get; set; }
        public int IdIndicadorRubro { get; set; }
        //German 20140511 - Tarea 124
    }
}

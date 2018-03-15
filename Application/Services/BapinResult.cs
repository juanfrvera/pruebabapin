using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
using System.Runtime.Serialization;

namespace UI.Web.Services
{
	[Serializable]
    [DataContract]
    public class BapinResult
    {
        [DataMember]
        public long bapin { get; set; }
        [DataMember]
        public string denominacion { get; set; }
        [DataMember]
        public long jurisdiccion { get; set; }
        [DataMember]
        public long saf { get; set; }
        [DataMember]
        public long programa { get; set; }
        [DataMember]
        public long subprograma { get; set; }
        [DataMember]
        public DateTime? fecha_inicio { get; set; }
        [DataMember]
        public DateTime? fecha_fin { get; set; }
        [DataMember]
        public decimal costo_total { get; set; }
        [DataMember]
        public EstadoDictamen estado_dictamen { get; set; }
        [DataMember]
        public long ultimo_anio_demanda{ get; set; }
        [DataMember]
        public long ultimo_anio_plan { get; set; }
        [DataMember]
        public long ultimo_anio_plan_segun_ejecucion { get; set; }

    }
}

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
        [DataMember(Order=1)]
        public long bapin { get; set; }
        [DataMember(Order = 2)]
        public string denominacion { get; set; }
        [DataMember(Order = 3)]
        public long jurisdiccion { get; set; }
        [DataMember(Order = 4)]
        public long saf { get; set; }
        [DataMember(Order = 5)]
        public long programa { get; set; }
        [DataMember(Order = 6)]
        public long subprograma { get; set; }
        [DataMember(Order = 7, EmitDefaultValue = false)]
        public DateTime? fecha_inicio { get; set; }
        [DataMember(Order = 8, EmitDefaultValue = false)]
        public DateTime? fecha_fin { get; set; }
        [DataMember(Order = 9)]
        public decimal costo_total { get; set; }
        [DataMember(Order = 10)]
        public EstadoDictamen estado_dictamen { get; set; }
        [DataMember(Order = 11, EmitDefaultValue = false)]
        public long? ultimo_anio_demanda{ get; set; }
        [DataMember(Order = 12, EmitDefaultValue = false)]
        public long? ultimo_anio_plan { get; set; }
        [DataMember(Order = 13, EmitDefaultValue = false)]
        public long? ultimo_anio_plan_segun_ejecucion { get; set; }

    }
}

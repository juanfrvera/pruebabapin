using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace UI.Web.Services
{
    [DataContract]
    public enum EstadoDictamen
    {
        /*
        ASO("ASO", "Aprobado sin observaciones"),
        ACO("ACO", "Aprobado con observaciones"),
        SDF("SDF", "Sin dictamen firme"),
        NND("NND", "No necesita dictamen")
        */
        [EnumMember]
        NND,
        [EnumMember]
        SDF,
        [EnumMember]
        ACO,
        [EnumMember]
        ASO
    }
}
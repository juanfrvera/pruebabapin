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
            NND	No necesita dictamen
            SDF	Requiere dictamen
            AOP	Aprobado con observaciones
            ADO 	Aprobado definitivo con observaciones
            ASO	Aprobado sin observaciones
         */
        [EnumMember]
        NND,
        [EnumMember]
        SDF,
        [EnumMember]
        AOP,
        [EnumMember]
        ADO,
        [EnumMember]
        ASO
    }
}
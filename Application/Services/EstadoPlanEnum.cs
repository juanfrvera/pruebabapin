using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace UI.Web.Services
{
    [DataContract]
    public enum estadoBapinType
    {
        [EnumMember]
        DEMANDA,
        [EnumMember]
        PLAN,
        [EnumMember]
        PLAN_SEGUN_EJECUCION
    }
}
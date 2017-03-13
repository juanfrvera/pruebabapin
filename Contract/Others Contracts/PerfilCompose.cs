using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Xml.Serialization;

namespace Contract
{   
    [Serializable]
    public class PerfilCompose
    {       
        public PerfilResult Perfil {get;set;}
        public List<PerfilActividadResult> Actividades { get; set; }
    }
}

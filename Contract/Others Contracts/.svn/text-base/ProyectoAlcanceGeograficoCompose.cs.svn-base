using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Xml.Serialization;

namespace Contract
{
    [Serializable]
    public class ProyectoAlcanceGeograficoCompose
    {

        public ProyectoResult Proyecto { get; set; }
        public Int32 IdProyecto
        {
            get { return Proyecto != null ? Proyecto.IdProyecto : 0; }
        }
        public List<ProyectoLocalizacionResult> Localizaciones = new List<ProyectoLocalizacionResult>();
        public List<ProyectoAlcanceGeograficoResult> Alcances = new List<ProyectoAlcanceGeograficoResult>();
        public List<ProyectoGeoreferenciacionResult> Georeferenciaciones = new List<ProyectoGeoreferenciacionResult>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Xml.Serialization;

namespace Contract
{
    [Serializable]
    public class ProyectoSeguimientoFilesCompose
    {
        public ProyectoSeguimientoResult ProyectoSeguimiento { get; set; }
        public Int32 IdProyectoSeguimiento
        {
            get { return ProyectoSeguimiento != null ? ProyectoSeguimiento.IdProyectoSeguimiento : 0; }
        }

        public List<ProyectoSeguimientoFileResult> ProyectoSeguimientoFiles = new List<ProyectoSeguimientoFileResult>();
    }
}
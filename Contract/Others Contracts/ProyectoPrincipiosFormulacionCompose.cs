using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    [Serializable]
    public class ProyectoPrincipiosFormulacionCompose
    {
        public ProyectoResult Proyecto { get; set; }
        public Int32 IdProyecto
        {
            get { return Proyecto != null ? Proyecto.IdProyecto : 0; }
        }

        public ProyectoPrincipiosFormulacionResult PrincipiosFormulacion { get; set; }
        
    }

}

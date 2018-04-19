using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class ProyectoEtapaInformacionPresupuestariaFilter : _ProyectoEtapaInformacionPresupuestariaFilter
    {
        public Int32? IdProyecto { get; set; } 
    }
}

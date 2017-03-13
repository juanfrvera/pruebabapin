using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class ProyectoSeguimientoEstadoFilter : _ProyectoSeguimientoEstadoFilter
    {
        public int IdProyectoDictamen { get; set; }
        public int? IdProyecto { get; set; } 
    }
}

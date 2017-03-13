using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class ActividadPermisoFilter : _ActividadPermisoFilter
    {
        public bool? Activo { get; set; }
    }
}

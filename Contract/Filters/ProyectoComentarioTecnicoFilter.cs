using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class ProyectoComentarioTecnicoFilter : _ProyectoComentarioTecnicoFilter
    {
        public int? Numero { get; set; }
    }
}

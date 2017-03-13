using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class EstadoFilter : _EstadoFilter
    {
        //public int? IdEstadoTipo { get; set; }
        public int? IdSistemaEntidad { get; set; }
        public string EntidadTipo { get; set; }
        public string EntidadClase { get; set; }
    }
}

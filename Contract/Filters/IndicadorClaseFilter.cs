using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class IndicadorClaseFilter : _IndicadorClaseFilter
    {
        public int? IdIndicadorRubro { get; set; }
        public string BusquedaIndicador{ get; set; }
    }
}

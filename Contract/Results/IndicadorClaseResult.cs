using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class IndicadorClaseResult : _IndicadorClaseResult
    {
        public int? IdIndicadorRubro { get; set; }
        public bool IndicadorTipo_SectorRequerido { get; set; }
    }
}

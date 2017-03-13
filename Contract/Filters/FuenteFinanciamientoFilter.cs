using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class FuenteFinanciamientoFilter : _FuenteFinanciamientoFilter
    {
        public bool? IncluirSubFuenteFinanciamiento { get; set; }
    }
}

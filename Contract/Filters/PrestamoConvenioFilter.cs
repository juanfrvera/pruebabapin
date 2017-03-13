using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class PrestamoConvenioFilter : _PrestamoConvenioFilter
    {
        public bool ConSigla { get; set; }
    }
}

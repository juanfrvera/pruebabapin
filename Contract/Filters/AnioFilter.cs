using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class AnioFilter : _AnioFilter
    {
        public int? Anio_From { get; set; }
        public int? Anio_To { get; set; }
    }

}

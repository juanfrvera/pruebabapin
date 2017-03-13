using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class PrestamoDesembolsoResult : _PrestamoDesembolsoResult
    {
        public DateTime? Orden
        {
            get { return Fecha; } 
        }
        public string PTotal
        {
            get;
            set;
        }
    }
}

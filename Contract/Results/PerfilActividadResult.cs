using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class PerfilActividadResult : _PerfilActividadResult
    {
        public bool Selected { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class ProgramaObjetivoResult : _ProgramaObjetivoResult
    {
        public bool TieneProyectoFin { get; set; }	
    }
}

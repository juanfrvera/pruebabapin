using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class PrestamoProductoResult : _PrestamoProductoResult
    { 	
        public string Componente {get; set;}
        public string SubComponente {get; set;}
        public string MContraparte {get; set;}
        public string MPrestamo {get; set;}
        public string StrIGestion {get; set;}
        public string StrANegociar { get; set; }
        public string StrEjecucion { get; set; }
        public string BAPIN { get; set; }
        public string ProyectoEstado { get; set; } //Matias 20170222 - Ticket #REQ217514
    }
}

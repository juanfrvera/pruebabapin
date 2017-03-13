using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class ProgramaObjetivoFilter : _ProgramaObjetivoFilter
    {

        private string _Denominacion;
        public string Denominacion
        {
            get
            {
                if (_Denominacion == null) _Denominacion = string.Empty;
                return _Denominacion;
            }
            set { _Denominacion = value; }
        }
        public int? IdSaf { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
    }
}

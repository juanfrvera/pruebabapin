using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class PrestamoDictamenFilter : _PrestamoDictamenFilter
    {
        public int IdProyecto { get; set; }
        public int? IdPrestamoDictamen_From { get; set; }
        public int? IdPrestamoDictamen_To { get; set; }
        private List<int> idsEstado;
        public List<int> IdsEstado
        {
            get
            {
                if (idsEstado == null) idsEstado = new List<int>();
                return idsEstado;
            }
            set { idsEstado = value; }
        }
        public int? Prestamo_Numero { get; set; }
    }
}

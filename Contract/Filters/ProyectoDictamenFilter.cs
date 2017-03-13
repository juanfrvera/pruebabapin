using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class ProyectoDictamenFilter : _ProyectoDictamenFilter
    {
        public int IdProyecto { get; set; }
        
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

        public Int32? NroBapin { get; set; }
        public int? IdSaf { get; set; }
        public int? IdAnalista { get; set; }
        private string _Malla;
        private string _Ruta;

        public string Malla
        {
            get
            {
                if (_Malla == null) _Malla = string.Empty;
                return _Malla;
            }
            set { _Malla = value; }
        }
        public string Ruta
        {
            get
            {
                if (_Ruta == null) _Ruta = string.Empty;
                return _Ruta;
            }
            set { _Ruta = value; }
        }
    }
}

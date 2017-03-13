using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class JurisdiccionFilter : _JurisdiccionFilter
    {
        public Int32? IdUsuarioSaf { get; set; }

        private List<Int32> idsOficinaByUsuario { get; set; }
        public List<Int32> IdsOficinaByUsuario
        {
            get {

                if (idsOficinaByUsuario == null) idsOficinaByUsuario = new List<int>();
                return idsOficinaByUsuario;
            }
            set {
                idsOficinaByUsuario = value; 
            }
        
        }
    }
}

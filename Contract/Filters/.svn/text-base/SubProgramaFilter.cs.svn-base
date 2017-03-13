using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class SubProgramaFilter : _SubProgramaFilter
    {
        private List<Int32> idsOficinaByUsuario { get; set; }
        public List<Int32> IdsOficinaByUsuario
        {
            get
            {

                if (idsOficinaByUsuario == null) idsOficinaByUsuario = new List<int>();
                return idsOficinaByUsuario;
            }
            set
            {
                idsOficinaByUsuario = value;
            }

        }
    }
}

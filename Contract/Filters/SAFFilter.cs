using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class SafFilter : _SafFilter
    {
        public int? IdUsusario { get; set; }
        public int? IdUsuarioOficinasRelacionadasProyecto { get; set; }
        public int? IdSectorialistaPrograma { get; set; }


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

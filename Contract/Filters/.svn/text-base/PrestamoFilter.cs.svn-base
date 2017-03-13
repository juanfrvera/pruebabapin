using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class PrestamoFilter : _PrestamoFilter
    {
        private List<int> idsOficinaByUsuario;
        public List<int> IdsOficinaByUsuario
        {
            get
            {
                if (idsOficinaByUsuario == null) idsOficinaByUsuario = new List<int>();
                return idsOficinaByUsuario;
            }
            set { idsOficinaByUsuario = value; }
        }
        public int? IdOficina { get; set; }

        public int? IdSaf { get; set; }
        public int? IdJurisdiccion { get; set; }
        public int? IdOrganismoFinanciero{ get; set; }
        public int? IdFinalidadFuncion { get; set; }
        public int? IdOficinaResponsable { get; set; }
        public int? CodBapinAsociado;
        public bool? IncluirOficinasInteriores { get; set; }
        public bool? IncluirFinalidadFuncionInteriores { get; set; }
        public bool? UnicamentePorCodigo { get; set; }

    }
}

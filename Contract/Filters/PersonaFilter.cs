using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class PersonaFilter : _PersonaFilter
    {

        public bool? EsUsuarioContacto { get; set; }
        public bool? IncluirOficinasInteriores { get; set; }
        #region Private
        private string _Usuario_Nombre;
        
        

        #endregion
        #region Properties
        public int? IdSaf { get; set; }
        public int? IdJurisdiccion { get; set; }
        public string Usuario_Nombre
        {
            get
            {
                if (_Usuario_Nombre == null) _Usuario_Nombre = string.Empty;
                return _Usuario_Nombre;
            }
            set { _Usuario_Nombre = value; }
        }
        private int[] idsOficina;
        public int[] IdsOficina
        {
            get
            {
                if (idsOficina == null)
                    idsOficina = new int[0];
                return idsOficina;
            }
            set { idsOficina = value; }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class ProyectoOficinaPerfilFilter : _ProyectoOficinaPerfilFilter
    {
        #region Private
        private string _CodigoPerfil;
        private List<int> idsProyecto;
        #endregion

        #region Properties
        public string CodigoPerfil
        {
            get
            {
                if (_CodigoPerfil == null) _CodigoPerfil = string.Empty;
                return _CodigoPerfil;
            }
            set { _CodigoPerfil = value; }
        }
        public List<int> IdsProyecto
        {
            get {
                if (idsProyecto == null)
                    idsProyecto = new List<int>();
                return idsProyecto; }
            set { idsProyecto = value; }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class PrestamoOficinaPerfilFilter : _PrestamoOficinaPerfilFilter
    {
        private List<int> idsPrestamo;
        public List<int> IdsPrestamo
        {
            get
            {
                if (idsPrestamo == null)
                    idsPrestamo = new List<int>();
                return idsPrestamo;
            }
            set { idsPrestamo = value; }
        }

        private string _CodigoPerfil;
        public string CodigoPerfil
        {
            get
            {
                if (_CodigoPerfil == null) _CodigoPerfil = string.Empty;
                return _CodigoPerfil;
            }
            set { _CodigoPerfil = value; }
        }	

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class UsuarioFilter : _UsuarioFilter
    {	
        #region Private
        private string _Nombre;
        private string _Apellido;
        private string _NombreCompleto;
        #endregion
        #region Properties
        public string Nombre
        {
            get
            {
                if (_Nombre == null) _Nombre = string.Empty;
                return _Nombre;
            }
            set { _Nombre = value; }
        }
        public string Apellido
        {
            get
            {
                if (_Apellido == null) _Apellido = string.Empty;
                return _Apellido;
            }
            set { _Apellido = value; }
        }
        public string NombreCompleto
        {
            get
            {
                if (_NombreCompleto == null) _NombreCompleto = string.Empty;
                return _NombreCompleto;
            }
            set { _NombreCompleto = value; }
        } 
        #endregion
		
    }
}

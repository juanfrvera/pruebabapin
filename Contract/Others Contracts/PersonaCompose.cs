using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Xml.Serialization;

namespace Contract
{   
    [Serializable]
    public class PersonaCompose
    {       
        public PersonaResult Persona {get;set;}
        public UsuarioResult Usuario {get;set;}
        private List<UsuarioOficinaPerfilResult> _UsuarioOficinaPerfiles;

        public List<UsuarioOficinaPerfilResult> UsuarioOficinaPerfiles
        {
            get {
                if (_UsuarioOficinaPerfiles == null) _UsuarioOficinaPerfiles = new List<UsuarioOficinaPerfilResult>();
                return _UsuarioOficinaPerfiles; 
            }
            set { _UsuarioOficinaPerfiles = value; }
        }
        private List<UsuarioPerfilResult> _UsuarioPerfiles;

        public List<UsuarioPerfilResult> UsuarioPerfiles
        {
            get {
                if (_UsuarioPerfiles == null) _UsuarioPerfiles = new List<UsuarioPerfilResult>();
                return _UsuarioPerfiles; 
            }
            set { _UsuarioPerfiles = value; }
        }
    }
}

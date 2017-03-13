using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;

namespace Contract
{
    [Serializable]
    public class FormContext
    {
        public string ApplicationName { get; set; }
        public string FromName { get; set; }
        public string FromPath { get; set; }
        public string UserControlName { get; set; }
        public string UserControlPath { get; set; } 
    }
    public interface IContextUser
    {
        UsuarioResult User { get; set; }        
        AuditSessionResult AuditSession { get; set; }
        FormContext FormContext { get; set; }
        List<PerfilResult> Perfiles { get; set; }        
        List<UsuarioOficinaPerfilSimpleResult> PerfilesPorOficina { get; set; }        
    }
}

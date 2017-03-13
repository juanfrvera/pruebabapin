using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Xml.Serialization;

namespace Contract
{
    [Serializable]
    public class RoleResult:IResult<string>,ISelectable
    {
        [XmlIgnore]
        public string ID{get{return RoleName;}}        
        public RoleResult OLD { get; set; }
        public string RoleName { get; set; }
        public bool Selected { get; set; }
        
        public virtual RoleResult Clone()
        {
            RoleResult result = new RoleResult();
            result.RoleName = this.RoleName;
            result.Selected = this.Selected;
            return result; 
        }

        public virtual DataTableMapping ToMapping()
        {
            throw new NotImplementedException();
        }
    }
    [Serializable]
    public class UsuarioMembershipCompose
    {
        public string NewPassword { get; set; }
        public UsuarioResult Usuario {get;set;}
        public MembershipUser MembershipUser { get; set; }
        public List<RoleResult> Roles { get; set; }
    }


    [Serializable]
    public class UsuarioCompose
    {
        public UsuarioResult Usuario { get; set; }
        public List<UsuarioOficinaPerfilResult> UsuarioOficinaPerfiles;
    }   
}

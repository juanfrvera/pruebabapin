using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Service;
using System.Configuration;

namespace Service
{
   
    public class OficinaPermiso
    {
        public int IdOficina {get;set;}
        public int IdPermission {get;set;}
    }


    public class AuthorizationManager : IAuthorizationManager 
    {
        #region singleton
        private static readonly object padlock = new object();
        private static AuthorizationManager current;
        public static AuthorizationManager Current
        {
            get
            {
                if (current == null)
                    lock (padlock)
                    {
                        if (current == null)
                            current = new AuthorizationManager();
                    }
                return current;
            }
        }
        #endregion

        #region Properties
        private Dictionary<int, List<PermisoSimpleResult>> perfilPermisions;
        public Dictionary<int, List<PermisoSimpleResult>> PerfilPermisions
        {
            get {
                if (perfilPermisions == null)
                {
                    perfilPermisions = SolutionContext.Current.CacheByApplicationManager["SLTN_PERFIL_PERMISIONS"] as Dictionary<int, List<PermisoSimpleResult>>;
                    if (perfilPermisions == null)
                    {

                        perfilPermisions = new Dictionary<int, List<PermisoSimpleResult>>();
                        List<Perfil> perfiles = PerfilService.Current.GetList(new PerfilFilter() { Activo = true });
                        foreach (Perfil perfil in perfiles)
                            perfilPermisions.Add(perfil.IdPerfil, PermisoService.Current.GetSimpleResult(new PermisoPerfilFilter() { IdPerfil = perfil.IdPerfil }));

                        SolutionContext.Current.CacheByApplicationManager["SLTN_PERFIL_PERMISIONS"] = perfilPermisions;
                    }
                }
                return perfilPermisions; 
            }
            set { 
                    perfilPermisions = value;
                    SolutionContext.Current.CacheByApplicationManager["SLTN_PERFIL_PERMISIONS"] = perfilPermisions;    
                }
        }
        private List<SistemaAccion> actions;
        public List<SistemaAccion> Actions
        {
            get {
                if (actions == null)
                    actions = SistemaAccionService.Current.GetList();
                return actions; }
            set { actions = value; }
        }
        
        private bool? enable;
        public bool Enable
        {
            get {
                if (!enable.HasValue)
                    enable = SolutionContext.Current.ParameterManager.GetBooleanValue("SECURITY_ENABLE");
                return enable.Value;
                }
        }
        private bool? enableOffice;
        public bool EnableOffice
        {
            get {                
                if (!enableOffice.HasValue)
                    enableOffice = SolutionContext.Current.ParameterManager.GetBooleanValue("OFFICE_FILTER_ENABLE");
                return enableOffice.Value;
                }
        }

        protected SecurityRuleContainerSection containerSection;
        protected SecurityRuleContainerSection ContainerSection
        {
            get
            {
                if (containerSection == null)
                {
                    containerSection = ConfigurationManager.GetSection("SecurityRuleConfiguration") as SecurityRuleContainerSection;
                }
                return containerSection;
            }
            set { containerSection = value; }
        }


        #endregion
        public void Refresh()
        {
            perfilPermisions = null;
            enable = null;
            enableOffice = null;
            actions = null;
            SolutionContext.Current.CacheByApplicationManager["SLTN_PERFIL_PERMISIONS"] = null;
        }

        #region Authorize
        public bool Authorize(IContextUser contextUser, string permisionCode)
        {
            if (contextUser == null || contextUser.User == null) return false;
            if (!Enable || contextUser.User.AccesoTotal) return true;
            List<List<PermisoSimpleResult>> permisosByPerfiles = GetPermisosByPerfiles(contextUser);
            return Authorize(permisosByPerfiles, permisionCode);
        }
        public bool Authorize(List<List<PermisoSimpleResult>> permisosByPerfiles, string permisionCode)
        {
            if (!Enable) return true;
            foreach (List<PermisoSimpleResult> permisosByPerfil in permisosByPerfiles)
                if ((from o in permisosByPerfil
                     where o.Codigo != null && o.Codigo.ToUpper() == permisionCode.ToUpper()
                     select 1).Count() > 0)
                    return true;
            return false;
        }
        #endregion

        #region AuthorizeByType
        public bool AuthorizeByType(IContextUser contextUser, string typeName)
        {            
            return AuthorizeByType(contextUser, typeName, null);
        }
        public bool AuthorizeByType(IContextUser contextUser, string typeName, string actionName)
        {
            return AuthorizeByType(contextUser, typeName, actionName, null);
        }
        public bool AuthorizeByType(IContextUser contextUser, string typeName, string actionName, int? idEstado)
        {
            if (contextUser == null || contextUser.User == null) return false;
            if (!Enable || contextUser.User.AccesoTotal) return true;
            List<List<PermisoSimpleResult>> permisosByPerfiles = GetPermisosByPerfiles(contextUser);
            return AuthorizeByType(permisosByPerfiles, typeName, actionName, idEstado);
        }
        public bool AuthorizeByType(List<List<PermisoSimpleResult>> permisosByPerfiles, string typeName, string actionName, int? idEstado)
        {
            if (!Enable) return true;
            foreach (List<PermisoSimpleResult> permisosByPerfil in permisosByPerfiles)
                if (AuthorizeByType(permisosByPerfil,typeName,actionName,idEstado))return true;
            return false;
        }
        public bool AuthorizeByType(List<PermisoSimpleResult> permisosByPerfil, string typeName, string actionName, int? idEstado)
        {
            var a = permisosByPerfil.Where(x => x.IdSistemaEstado == 50).Count();
            if ((from o in permisosByPerfil
                 where o.SistemaEntidad_Codigo != null && o.SistemaEntidad_Codigo.ToUpper() == typeName.ToUpper()
                     && (actionName == string.Empty || o.IdSistemaAccion.HasValue == true || o.Codigo.ToUpper() == actionName.ToUpper())
                     && (actionName == string.Empty || o.IdSistemaAccion.HasValue == false || o.SistemaAccion_Codigo.ToUpper() == actionName.ToUpper())
                     && (idEstado == null || idEstado == 0 || o.IdSistemaEstado == null || o.IdSistemaEstado == 0 || o.IdSistemaEstado == idEstado)
                 select 1).Count() > 0)
                return true;
            return false;
        }
        #endregion

        #region AuthorizeByOffice
        public bool AuthorizeByOffice(IContextUser contextUser, string typeName, int idOficina)
        {
            return AuthorizeByOffice(contextUser, typeName, idOficina, null);
        }
        public bool AuthorizeByOffice(IContextUser contextUser, string typeName, int idOficina, string actionName)
        {
            return AuthorizeByOffice(contextUser, typeName, idOficina, actionName, null);
        }
        public bool AuthorizeByOffice(IContextUser contextUser, string typeName, int idOficina, string actionName, int? idEstado)
        {
            if (!Enable || !EnableOffice) return true;
            List<List<PermisoSimpleResult>> permisosByPerfiles = GetPermisosByOficinaPerfiles(contextUser, idOficina, actionName);
            return AuthorizeByType(permisosByPerfiles, typeName, actionName, idEstado);
        }
        public bool AuthorizeByOffice(IContextUser contextUser, string typeName, List<PerfilOficina> perfilOficinas)
        {
            return AuthorizeByOffice(contextUser, typeName, perfilOficinas, null);
        }
        public bool AuthorizeByOffice(IContextUser contextUser, string typeName, List<PerfilOficina> perfilOficinas, string actionName)
        {
            return AuthorizeByOffice(contextUser, typeName, perfilOficinas, actionName, null);
        }
        public bool AuthorizeByOffice(IContextUser contextUser, string typeName, List<PerfilOficina> perfilOficinas, string actionName, int? idEstado)
        {
            if (contextUser == null || contextUser.User == null) return false;
            if (!Enable || !EnableOffice || contextUser.User.AccesoTotal) return true;

            //si tiene permisos por sistema ya no evalua por oficina
            if (AuthorizeByType(contextUser, typeName, actionName, idEstado)) return true;
            
            SistemaAccion action = (from o in Actions where o.Codigo.Equals(actionName,StringComparison.InvariantCultureIgnoreCase) select o).FirstOrDefault();
            bool esConsulta =(action !=null)?action.EsLectura:false;

            //obtiene los perfiles que el Usuario tiene sobre las oficinas 
            List<UsuarioPerfilOficina> usuarioPerfilOficinas = new List<UsuarioPerfilOficina>();
            foreach (PerfilOficina perfilOficina in perfilOficinas)
            {
                usuarioPerfilOficinas.AddRange(
                    (from o in contextUser.PerfilesPorOficina
                     where
                      //si hereda la oficina pregunta por si esta contenida 
                      //(((o.HeredaConsulta == true && esConsulta == true) || o.HeredaEdicion == true) && o.Oficina_BreadcrumbId.Contains("." + perfilOficina .IdOficina + "."))
                      (((o.HeredaConsulta == true && esConsulta == true) || o.HeredaEdicion == true) &&  perfilOficina.Oficina_BreadcrumbId.Contains("." + o.IdOficina + "."))
                      // si no hereda debe ser igual
                      || o.IdOficina == perfilOficina.IdOficina
                     select new UsuarioPerfilOficina() { IdOficina = perfilOficina.IdOficina, IdPerfil = perfilOficina.IdPerfil, IdUsuarioPerfil = o.IdPerfil, UsuarioAccesoTotal=o.AccesoTotal }
                     ).ToArray());
            }

            //Si en alguna de las oficinas relacionadas a la entidad el usuario tiene acceso total lo habilita a todo.
            foreach (UsuarioPerfilOficina usuarioPerfilOficina in usuarioPerfilOficinas)
                if (usuarioPerfilOficina.UsuarioAccesoTotal) return true;
            
            //busca en las oficinas segun los permisos del perfil de la oficina y los del usuario 
            foreach (UsuarioPerfilOficina usuarioPerfilOficina in usuarioPerfilOficinas)
            {                
                if (usuarioPerfilOficina.IdPerfil == usuarioPerfilOficina.IdUsuarioPerfil)
                {//si es el mismo perfil , pasa a evaluar todos los permisos del perfil de la oficina                    
                    List<List<PermisoSimpleResult>> permisosByPerfiles = (from o in PerfilPermisions where o.Key == usuarioPerfilOficina.IdPerfil select o.Value).ToList();
                    if (AuthorizeByType(permisosByPerfiles, typeName, actionName, idEstado)) return true;
                }
                else
                {//si los perfiles son diferentes , solo pasa los permisos que coinciden en los perfiles
                    List<PermisoSimpleResult> permisosByOficinaPerfiles = (from o in PerfilPermisions where o.Key == usuarioPerfilOficina.IdPerfil select o.Value).FirstOrDefault();
                    List<PermisoSimpleResult> permisosByUsuarioPerfiles = (from o in PerfilPermisions where o.Key == usuarioPerfilOficina.IdUsuarioPerfil select o.Value).FirstOrDefault();
                    if (permisosByOficinaPerfiles == null || permisosByUsuarioPerfiles == null ) return false; 
                    List<PermisoSimpleResult> permisosEnComun =
                    (from o in permisosByOficinaPerfiles
                     where (from u in permisosByUsuarioPerfiles select u.IdPermiso).Contains(o.IdPermiso)
                     select o).ToList();
                    
                    if (AuthorizeByType(permisosEnComun, typeName, actionName, idEstado)) return true;
                }
            }
            return false;
        }
        #endregion
        
        public string[] GetOptions(IContextUser contextUser, string containerName)
        {
            List<List<PermisoSimpleResult>> permisosByPerfiles = GetPermisosByPerfiles(contextUser);
            return GetOptions(permisosByPerfiles, containerName);
        }
        public string[] GetOptions(List<List<PermisoSimpleResult>> permisosByPerfiles, string containerName)
        {            
            List<string> options = new List<string>();            
            SecurityRuleContainer container = (from o in ContainerSection.Containers where o.Name == containerName select o).FirstOrDefault();
            foreach (SecurityRuleItem item in container.Items)
            {
                if (item.PermisoCode != null && item.PermisoCode != string.Empty)
                {
                    if ( !Enable || Authorize(permisosByPerfiles,item.PermisoCode))
                        options.Add(item.Name);
                }
                else
                {
                    if (!Enable || AuthorizeByType(permisosByPerfiles, item.TypeName, item.ActionName, null))
                        options.Add(item.Name);
                }
            }
            return options.ToArray();
        }
        public List<List<PermisoSimpleResult>> GetPermisosByPerfiles(IContextUser contextUser)
        {
            List<int> idPerfiles = (from o in contextUser.Perfiles select o.IdPerfil).ToList();
            return (from o in PerfilPermisions where idPerfiles.Contains(o.Key) select o.Value).ToList();          
        }
        //public List<List<PermisoSimpleResult>> GetPermisosByOficinaPerfiles(IContextUser contextUser, List<PerfilOficina> perfilOficinas, string actionName)
        //{
        //    if (perfilOficinas == null) return new List<List<PermisoSimpleResult>>();
        //    bool isConsulta = (actionName == null || actionName == ActionConfig.READ);
        //    List<int> idPerfiles = (from o in contextUser.PerfilesPorOficina
        //                            //si el perfil no hereda busca que el usuario tenga ese perfil para la oficina de la entidad
        //                            where (o.HeredaConsulta || o.HeredaEdicion || (from po in perfilOficinas where po.IdOficina == o.IdOficina select po.IdPerfil).Contains(o.IdPerfil) ) 
        //                            //si el perfil hereda busca que el usuario en todas las oficinas hijas
        //                            && (((o.HeredaConsulta && isConsulta) || o.HeredaEdicion) && (from po in perfilOficinas where po.Oficina_BreadcrumbId.Contains("." + o.IdOficina + ".") select po.IdPerfil).Contains(o.IdPerfil))
        //                            select o.IdPerfil).ToList(); 
        //    return (from o in PerfilPermisions where idPerfiles.Contains(o.Key) select o.Value).ToList();
        //}
        public List<List<PermisoSimpleResult>> GetPermisosByOficinaPerfiles(IContextUser contextUser, int idOficina, string actionName)
        {
            string likeIdOficina = "." + idOficina.ToString() + ".";
            bool isConsulta = (actionName == null || actionName == Command.READ || actionName == Command.VIEW);
            List<int> idPerfiles = (from o in contextUser.PerfilesPorOficina
                                    where o.IdOficina == idOficina
                                    && (o.HeredaConsulta || o.HeredaEdicion || o.IdOficina == idOficina)
                                    && (((o.HeredaConsulta && isConsulta) || o.HeredaEdicion) && (o.Oficina_BreadcrumbId.Contains(likeIdOficina)))
                                    select o.IdPerfil).ToList();
            return (from o in PerfilPermisions where idPerfiles.Contains(o.Key) select o.Value).ToList();
        }
      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contract;
using nc=Contract;
using System.Web.Security;
using Service;
using System.Security.Principal;
using System.IO;

namespace UI.Web
{
    public class UIWebCacheBySessionManager : ICacheBySessionManager
    {
        #region Singleton
        private static volatile UIWebCacheBySessionManager current;
        private static object syncRoot = new Object();

        //private PublicidadService() {}
        public static UIWebCacheBySessionManager Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new UIWebCacheBySessionManager();
                    }
                }
                return current;
            }
        }
        #endregion

        public object this[string name]
        {
            get { 
                    return HttpContext.Current.Session[name];
                }
            set { HttpContext.Current.Session[name] = value; }
        }    
    }
    public class UIWebCacheByApplicationManager : ICacheByApplicationManager
    {
        #region Singleton
        private static volatile UIWebCacheByApplicationManager current;
        private static object syncRoot = new Object();
        public static UIWebCacheByApplicationManager Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new UIWebCacheByApplicationManager();
                    }
                }
                return current;
            }
        }
        #endregion

        public object this[string name]
        {
            get
            {
                return HttpContext.Current.Application[name];
            }
            set { HttpContext.Current.Application[name] = value; }
        }
    }


    #region ContextUser
    public class ContextUser : IContextUser
    {
        private FormContext formContext;
        private List<PerfilResult> perfiles;
        private List<UsuarioOficinaPerfilSimpleResult> perfilesPorOficina;

        public UsuarioResult User { get; set; }
        public AuditSessionResult AuditSession { get; set; }
        public FormContext FormContext
        {
            get
            {
                if (formContext == null)
                    formContext = new FormContext();
                return formContext;
            }
            set { formContext = value; }
        }
        public List<PerfilResult> Perfiles
        {
            get
            {
                if (perfiles == null) perfiles = new List<PerfilResult>();
                return perfiles;
            }
            set { perfiles = value; }
        }
        public List<UsuarioOficinaPerfilSimpleResult> PerfilesPorOficina
        {
            get
            {
                if (perfilesPorOficina == null) perfilesPorOficina = new List<UsuarioOficinaPerfilSimpleResult>();
                return perfilesPorOficina;
            }
            set { perfilesPorOficina = value; }
        }
        public List<int> IdsOficina { get; set; } 
    }
    public class MembershipContextUser : ContextUser
    {
        public IPrincipal Principal { get; set; }        
    }
    
    #endregion

    public class UIContext
    {
        #region Singleton
        private static volatile UIContext current;
        private static object syncRoot = new Object();

        //private PublicidadService() {}
        public static UIContext Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new UIContext();
                    }
                }
                return current;
            }
        }
        #endregion
        //#region Instance by Session
        //private static volatile UIContext current;
        //private const string UICONTEXT_KEY= "UIContext";
        //public static UIContext Current
        //{
        //    get
        //    {
        //        if (HttpContext.Current != null && HttpContext.Current.Session != null && HttpContext.Current.Session[UICONTEXT_KEY] == null)
        //            HttpContext.Current.Session[UICONTEXT_KEY] = new UIContext();
        //        return HttpContext.Current.Session[UICONTEXT_KEY] as UIContext;
        //    }
        //}
        //#endregion

        private const string PAGE_PARAMERTERS = "PageParameters";
        public readonly string PARAMETER_ERROR_MESSAGE = "ErrorMessage";
        public readonly string PageError = @"~/frmError.aspx";
        public readonly string ApplicationName = "ProjecBase.Site";

        public void LoadManagers()
        {
            SolutionContext.Current.CacheBySessionManager = UIWebCacheBySessionManager.Current;
            SolutionContext.Current.CacheByApplicationManager = UIWebCacheByApplicationManager.Current;
            SolutionContext.Current.TextManager = TextManager.Current;
            SolutionContext.Current.NotificationManager = EmailNotificationManager.Current;
            SolutionContext.Current.AuditManager = AuditManager.Current;
            SolutionContext.Current.ParameterManager = ParameterManager.Current;           
            SolutionContext.Current.AuthorizationManager = AuthorizationManager.Current;
            SolutionContext.Current.MessageManager = MessageManager.Current;
            SolutionContext.Current.FileManager = DatabaseFileManager.Current;           
            //poner en parametros el nombre de usuario del sistema
            SolutionContext.Current.SystemUser = UsuarioService.Current.FirstOrDefault(new Contract.UsuarioFilter(){ NombreUsuario = "Admin"});
            SolutionContext.Current.EstadosCache = EstadosCache.Current;
            SolutionContext.Current.AccionesCache = AccionesCache.Current;
            SolutionContext.Current.PerfilCache = PerfilCache.Current;
            SolutionContext.Current.EstadoDeDesicionCache = EstadoDeDesicionCache.Current;
        }
        //private IContextUser contextUser;
        public IContextUser ContextUser
        {
            get {
                IContextUser contextUser = null;
                if (HttpContext.Current != null  
                &&  (  HttpContext.Current.Session["contextUser"] != null)
                && ((HttpContext.Current.Session["contextUser"] as IContextUser) != null)
                && ((HttpContext.Current.Session["contextUser"] as IContextUser).User != null))
                {
                    contextUser = HttpContext.Current.Session["contextUser"] as IContextUser;
                }
                if(contextUser != null)
                {
                    contextUser.FormContext.FromName = Path.GetFileNameWithoutExtension(HttpContext.Current.Request.Path);
                    if (HttpContext.Current.Request.ApplicationPath !=@"/")
                        contextUser.FormContext.FromPath = HttpContext.Current.Request.Path.Replace(HttpContext.Current.Request.ApplicationPath,string.Empty);
                    else
                        contextUser.FormContext.FromPath = HttpContext.Current.Request.Path;
                    contextUser.FormContext.ApplicationName = ApplicationName;
                }
                return contextUser;
            }
            set { HttpContext.Current.Session["contextUser"] = value; }
        }        
        public bool HadTranslate
        {//solo debe traducir si el lenguiaje es distinto al lenguaje del sistema
            get { return LanguageCode != SolutionContext.Current.SystemLanguage; }
        }
        public string LanguageCode
        {
            get
            {
                return IsLogin ? ContextUser.User.Language_Code : SolutionContext.Current.DefaultLanguage;                
            }
        }
        private LanguageResult defaultLanguage;
        public LanguageResult DefaultLanguage
        {
            get
            {
                if ( defaultLanguage == null ) 
                    defaultLanguage = LanguageService.Current.GetResult(new nc.LanguageFilter() { Code = SolutionContext.Current.DefaultLanguage }).SingleOrDefault();
                return defaultLanguage;
            }
        }

        #region Parameters
        public PageParameters GetParameters(string page)
        {
            if (HttpContext.Current.Session[page] == null)
                HttpContext.Current.Session[page] = new PageParameters(page, new Parameters());
            return HttpContext.Current.Session[page] as PageParameters;
        }
        public void SetParameters(string page, PageParameters value)
        {
            HttpContext.Current.Session[page] = value;
        }
        public object GetValue(string page, string parameter)
        {
            PageParameters pageParameters = GetParameters(page);
            if (!pageParameters.Parameters.ContainsKey(parameter)) return null;
            return pageParameters.Parameters[parameter];
        }        
        public void SetValue(string page, string parameter, object value)
        {
            PageParameters pageParameters = GetParameters(page);
            pageParameters.Parameters[parameter] = value;
            SetParameters(page, pageParameters);
        }
        public object GetGeneralValue(string parameter)
        {
            if (parameter == null) return null;
            return HttpContext.Current.Session[parameter];
        }
        public void SetGeneralValue(string parameter, object value)
        {
            if (parameter != null)
                HttpContext.Current.Session[parameter] = value;
        }
        #endregion

        #region ActiveSessions
        Dictionary<string, string> activeSessions;
        public Dictionary<string, string> ActiveSessions
        {
            get
            {
                if (activeSessions == null)
                {
                    activeSessions = SolutionContext.Current.CacheByApplicationManager["ActiveSessions"] as Dictionary<string, string>;
                    if (activeSessions == null)
                    {
                        activeSessions = new Dictionary<string, string>();
                        SolutionContext.Current.CacheByApplicationManager["ActiveSessions"] = activeSessions;
                    }
                }
                return activeSessions;
            }
            set
            {
                activeSessions = value;
                SolutionContext.Current.CacheByApplicationManager["ActiveSessions"] = value;
            }
        }
        #endregion
        
        #region Login
        
        public void Login(string userName, string password)
        {
            ContextUser userContext = new ContextUser();
            UsuarioResult usuario = UsuarioService.Current.GetResult(new nc.UsuarioFilter() { NombreUsuario = userName, Clave = password }).FirstOrDefault();
            DataHelper.Validate(usuario != null, "Usuario o Clave inválida");
            DataHelper.Validate(usuario.Activo == true , "El usuario no esta activo");
            userContext.User = usuario;
            userContext.Perfiles = PerfilService.Current.GetResult(new nc.PerfilFilter() { IdUsuario = userContext.User.IdUsuario });
            userContext.PerfilesPorOficina = UsuarioOficinaPerfilService.Current.GetResultSimple(new nc.UsuarioOficinaPerfilFilter() { IdUsuario = userContext.User.IdUsuario });
            Audit(userContext);
            UIContext.Current.ContextUser = userContext;

        }
        public void LoginWS(string userName, string password)
        {
            ContextUser userContext = new ContextUser();
            UsuarioResult usuario = UsuarioService.Current.GetResult(new nc.UsuarioFilter() { NombreUsuario = userName, Clave = password }).FirstOrDefault();
            DataHelper.Validate(usuario != null, "Usuario o Clave inválida");
            DataHelper.Validate(usuario.Activo == true, "El usuario no esta activo");
            userContext.User = usuario;
            userContext.Perfiles = PerfilService.Current.GetResult(new nc.PerfilFilter() { IdUsuario = userContext.User.IdUsuario });
            userContext.PerfilesPorOficina = UsuarioOficinaPerfilService.Current.GetResultSimple(new nc.UsuarioOficinaPerfilFilter() { IdUsuario = userContext.User.IdUsuario });
            Audit(userContext);
        }
        public void Logout()
        {
            if (IsLogin)
                UnRegisterUser();
        }
        public bool IsLogin
        {
            get
            {
                IContextUser contextUser = UIContext.Current.ContextUser;
                return !(contextUser == null || contextUser.User == null);
            }
        }
        #endregion

        #region UnRegisterUser
        public void UnRegisterUser()
        {
            UnRegisterUser(AuditMandateEnum.LogoutNormal);
        }
        public void UnRegisterUser(AuditMandateEnum manate)
        { 
            UnRegisterUser(manate, "");
        }
        public void UnRegisterUser(AuditMandateEnum manate, string message)
        {
            if (UIContext.Current.ContextUser == null
            || UIContext.Current.ContextUser.AuditSession == null
            || UIContext.Current.ContextUser.AuditSession.IdAuditSession <= 0) return;
            CloseAudit(UIContext.Current.ContextUser.AuditSession.IdAuditSession, manate, message);

            RemoveSession(HttpContext.Current.Session.SessionID);
            UIContext.Current.ContextUser = null;
            HttpContext.Current.Session.Clear();
            FormsAuthentication.SignOut();
        }
        #endregion 

        #region manager Sessions
        public static void AddSession(string sessionId, string userName)
        {
            if (UIContext.Current.ActiveSessions.ContainsKey(sessionId))
                UIContext.Current.ActiveSessions[sessionId] = userName;
            else
                UIContext.Current.ActiveSessions.Add(sessionId, userName);
        }
        public static void RemoveSession(string sessionId)
        {
            if (UIContext.Current.ActiveSessions.ContainsKey(sessionId))
                UIContext.Current.ActiveSessions.Remove(sessionId);
        }
        public static int SessionActives(string userName)
        {
            return (from o in UIContext.Current.ActiveSessions where o.Value == userName select o.Key).Count();
        }
        #endregion

        #region Audit
        public void Audit(IContextUser userContext)
        {
            AuditSession audit = AuditSessionService.Current.GetNew();
            audit.UserName = userContext.User.NombreUsuario;
            audit.StartDate = DateTime.Now;
            if (HttpContext.Current.Session != null)
            {
                audit.SessionId = HttpContext.Current.Session.SessionID;
            }
            else
            {
                //Web services
                audit.SessionId = "NONSESSION";
            }
            audit.Login = userContext.User.NombreUsuario;
            audit.Rols = string.Join(", ", (from o in userContext.Perfiles select o.Nombre).ToArray());
            audit.Area = "";
            audit.IP = HttpContext.Current.Request.UserHostAddress;
            audit.BrowserVersion = string.Format("{0} {1}", HttpContext.Current.Request.Browser.Browser, HttpContext.Current.Request.Browser.Version);
            audit.OperatingSystem = HttpContext.Current.Request.Browser.Platform;
            audit.Comments = string.Format("JavaScript Version:{0} Screen:{1}-{2}", HttpContext.Current.Request.Browser.JScriptVersion, HttpContext.Current.Request.Browser.ScreenPixelsWidth, HttpContext.Current.Request.Browser.ScreenPixelsHeight);
            SolutionContext.Current.AuditManager.Save(audit);
            AuditSessionResult result = new AuditSessionResult();
            result.Set(audit);
            userContext.AuditSession=result;
        }       
        public static void CloseAudit(int IdAuditSession, AuditMandateEnum manate, string message)
        {
            AuditSession audit = AuditSessionService.Current.GetById(IdAuditSession);
            audit.EndDate = DateTime.Now;
            audit.Mandate = AuditMandateConfig.GetConst(manate);
            audit.Message = message;
            SolutionContext.Current.AuditManager.Save(audit);
        }
        #endregion

        #region CanByUser       
        public bool CanByUser(string typeName, string actionName)
        {
            return SolutionContext.Current.AuthorizationManager.AuthorizeByType(ContextUser, typeName, actionName);
        }        
        public virtual bool CanByUser(string typeName, string actionName, int? idEstado)
        {
            return SolutionContext.Current.AuthorizationManager.AuthorizeByType(ContextUser, typeName, actionName, idEstado);
        }
        #endregion
    }



    public class PagesParameters: Dictionary<string, PageParameters>
    {
        
    }
    public class Parameters: Dictionary<string,object>
    {
    }
    public class PageParameters
    {

        public PageParameters(string page, Parameters parameters)
        {
            this.Page = page;
            this.Parameters = parameters;
        }
        public string Page { get; set; }
        public Parameters Parameters { get; set;} 
    }


}

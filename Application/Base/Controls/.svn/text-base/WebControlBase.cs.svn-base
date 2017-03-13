using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Contract;

namespace UI.Web
{

    public abstract class WebControlBase : System.Web.UI.UserControl, IWebControlBase
    {

        protected PageBase PageBase
        {
            get { return this.Page as PageBase; }
        }
        protected string Name
        {
            get { return this.UniqueID; }
        }
        string confirmDeleteMessage;
        public string ConfirmDeleteMessage
        {
           get{
               if (confirmDeleteMessage == null)
                   confirmDeleteMessage = Translate("ConfirmDelete");
               return confirmDeleteMessage;
            }   
        }

        #region Page Methods

        protected override void OnInit(EventArgs e)
        {
            _SetControls();
            base.OnInit(e);
            if (!this.IsPostBack)
                this._Initialize();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this._Load();
        }
        protected virtual void _SetControls()
        {
        }
        protected virtual void _Load()
        {
        }
        protected virtual void _Initialize()
        {
        }
        #endregion

        #region Commands
        private string commandValue;
        public virtual string CommandValue
        {
            get
            {
                if (commandValue == null)
                {
                    if (ViewState["commandValue"] != null)
                        commandValue = ViewState["commandValue"].ToString();
                }
                return commandValue;
            }
            set
            {
                commandValue = value;
                ViewState["commandValue"] = value;
            }
        }
        private string commandName;
        public virtual string CommandName
        {
            get
            {
                if (commandName == null)
                {
                    if (ViewState["commandName"] != null)
                        commandName = ViewState["commandName"].ToString();
                }
                return commandName;
            }
            set
            {
                commandName = value;
                ViewState["commandName"] = value;
            }
        }        
        
        #region Events Controls
        public event ControlCommandHandler ControlCommand;
        public virtual void RaiseControlCommand(string commandName)
        {
            this.RaiseControlCommand(commandName, null);
        }
        public virtual void RaiseControlCommand(string commandName, object value)
        {
            if (this.ControlCommand != null)
                this.ControlCommand(this, new ControlCommandEventArgs(commandName, value));
        }
        #endregion

        #endregion
        
        #region ViewState
        public void SetViewState(string key,object value)
        {
            if (this.PageBase == null) return;
            this.PageBase.SetViewState(this.Name+"_"+key,value);
        }
        public object GetViewState(string key)
        {
            if (this.PageBase == null) return null;
            return this.PageBase.GetViewState(this.Name+"_"+key);
        }
        public T GetViewState<T>(string key) where T:class
        {
            if (this.PageBase == null) return null;
            return this.PageBase.GetViewState<T>(this.Name+"_"+key);
        }
        public CrudActionEnum CrudAction
        {
            get {
                if (this.PageBase == null) return CrudActionEnum.Unknown;
                return this.PageBase.CrudAction; 
                }
        }
        #endregion

        #region Methods
        public void CallTryMethod(TryMethodDelegate method)
        {
            UIHelper.CallTryMethod(method,(ShowExceptionDelegate)AddException);               
        }
        public void AddException(Exception exception)
        {
            if (this.PageBase == null) return;
            this.PageBase.Exceptions.Add(exception);
        }        
        public string Translate(string textCode)
        {
            return UIHelper.Translate(textCode);
        }
        public string TranslateFormat(string format,params string[] args)
        {
            return UIHelper.TranslateFormat(format, args);          
        }
        public void ShowDownLoadExport() {
            if (this.PageBase != null) 
                PageBase.ShowDownLoadExport();
        }
        #endregion
        
        #region Parameters
        public T GetParameter<T>(string parameter) where T : class
        {
            return GetParameter(parameter) as T;
        }
        public object GetParameter(string parameter)
        {
            if (this.PageBase == null) return null;
            return PageBase.GetParameter(this.Name + "_" + parameter);
        }        
        public void SetParameter(string parameter, object value)
        {
            if (this.PageBase == null)return;
            this.PageBase.SetParameter(this.Name + "_" + parameter, value);
        }
        public T GetGeneralParameter<T>(string parameter) where T : class
        {
            return GetGeneralParameter(parameter) as T;
        }
        public object GetGeneralParameter(string parameter)
        {
            if (this.PageBase == null) return null;
            return PageBase.GetGeneralParameter(parameter);
        }
        public void SetGeneralParameter(string parameter, object value)
        {
            if (this.PageBase == null) return;
            this.PageBase.SetGeneralParameter(parameter, value);
        }
        #endregion

        #region Persist
        public void SetPersist(string key, object value)
        {
            if (this.PageBase == null) return;
            PageBase.SetPersist(key, value);
        }
        public bool ExistsPersist(string key)
        {
            if (this.PageBase == null) return false;
            return PageBase.ExistsPersist(key);
        }
        public object GetPersist(string key)
        {
            if (this.PageBase == null) return null;
            return PageBase.GetPersist(key);
        }
        #endregion
        
        #region Can
        #region CanByUser
        public virtual bool CanByUser(string actionName)
        {
            if (this.PageBase == null) return false;
            return PageBase.CanByUser(actionName);
        }
        public virtual bool CanByUser(string typeName, string actionName)
        {
            return CanByUser(typeName, actionName, null);
        }
        public virtual bool CanByUser(string typeName, string actionName, int? idEstado)
        {
            if (this.PageBase == null) return false;
            return PageBase.CanByUser(typeName, actionName, idEstado);
        }
        #endregion
        #region CanByOffice
        public virtual bool CanByOffice(List<PerfilOficina> perfilOficinas)
        {
            return CanByOffice(perfilOficinas, null);
        }
        public virtual bool CanByOffice(List<PerfilOficina> perfilOficinas, string actionName)
        {
            return CanByOffice(perfilOficinas, actionName, null);
        }
        public virtual bool CanByOffice(List<PerfilOficina> perfilOficinas, string actionName, int? idEstado)
        {
            if (this.PageBase == null) return false;
            return PageBase.CanByOffice(perfilOficinas,actionName,idEstado);
        }
        public virtual bool CanByOffice(string typeName, List<PerfilOficina> perfilOficinas, string actionName, int? idEstado)
        {
            if (this.PageBase == null) return false;
            return PageBase.CanByOffice(typeName,perfilOficinas, actionName, idEstado);
        }
        #endregion
        #region Can
        public virtual bool Can(string actionName)
        {
            return Can(null, actionName, null);
        }
        public virtual bool Can(object entity, string actionName)
        {
            return Can(entity, actionName, null);
        }
        public virtual bool Can(object entity, string actionName, int? idEstado)
        {
            if (this.PageBase == null) return false;
            return PageBase.Can(entity, actionName, idEstado);
        }
        #endregion
        #region CanById
        public virtual bool CanById(object id, string actionName)
        {
            if (this.PageBase == null) return false;
            return PageBase.CanById(id, actionName);
        }
        public virtual bool CanByResult(object result, string actionName)
        {
            return CanByResult(result, actionName, null);
        }
        public virtual bool CanByResult(object result, string actionName, int? idEstado)
        {
            if (this.PageBase == null) return false;
            return PageBase.CanByResult(result, actionName, idEstado);
        }
        #endregion
        #endregion
    }
}
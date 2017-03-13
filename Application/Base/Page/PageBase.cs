using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Linq;
using Contract;
using nc = Contract;
using Service;
using ns = Service;
using AjaxControlToolkit;
using System.Security.Principal;
using Application.Controls;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.Threading;
using System.IO;
using System.IO.Compression;

namespace UI.Web
{
    public class PageBehaviour
    {
        public PageBehaviour()
        {
            ReloadAlways = false;
            GetTotaRowsCount = true;
            ConfirmOnPageChange = false;
            PersistUse = true;
            PersistInViewState = false;
            PersistCompression = true;
            HadSerializeEntity = true;
        }
        public bool ReloadAlways { get; set; }
        public bool GetTotaRowsCount { get; set; }
        public bool ConfirmOnPageChange { get; set; }
        public bool PersistInViewState { get; set; }
        public bool PersistCompression { get; set; }
        public bool PersistUse { get; set; }
        public bool HadSerializeEntity { get; set; }
    }

    public abstract class PageBase : System.Web.UI.Page
    {
        public const string PARAMETER_ACTION = "Action";
        public const string PARAMETER_VALUE = "Value";
        public const string PARAMETER_FILTER = "Filter";
        public const string PARAMETER_TABINDEX = "TabIndex";

        public const string PathReportPage = "../Reportes/PageReport.aspx";

        #region Properties
        protected IAuthorizationManager AuthorizationManager
        {
            get { return SolutionContext.Current.AuthorizationManager; }
        }
        protected IContextUser ContextUser
        {
            get { return UIContext.Current.ContextUser; }
        }
        protected PageBehaviour pageBehaviour;
        public virtual PageBehaviour PageBehaviour
        {
            get
            {
                if (pageBehaviour == null) pageBehaviour = new PageBehaviour();
                return pageBehaviour;
            }
        }
        public CrudActionEnum CrudAction
        {
            get
            {
                if (ViewState["CrudAction"] != null)
                    return (CrudActionEnum)ViewState["CrudAction"];
                return CrudActionEnum.Unknown;
            }
            set
            {
                ViewState["CrudAction"] = value;
            }
        }
        private List<PermisoByTypeNameResult> canActionsByUser;
        protected virtual List<PermisoByTypeNameResult> CanActionsByUser
        {
            get
            {
                if (canActionsByUser == null)
                {
                    if (ViewState["canActionsByUser"] != null)
                        canActionsByUser = ViewState["canActionsByUser"] as List<PermisoByTypeNameResult>;
                    else
                        canActionsByUser = new List<PermisoByTypeNameResult>();
                }
                return canActionsByUser;
            }
            set
            {
                canActionsByUser = value;
                ViewState["canActionsByUser"] = value;
            }
        }
        #endregion

        #region Persist
        public void SetPersist(string key, object value)
        {
            //if(PageBehaviour.PersistInViewState)
            ViewState[key] = value;
            //else
            //    Session[PageName + "_" + key] = value;             
        }
        public bool ExistsPersist(string key)
        {
            object obj = GetPersist(key);
            return obj != null;
        }
        public object GetPersist(string key)
        {
            //if (PageBehaviour.PersistInViewState)
            return ViewState[key];
            //else
            //    return Session[PageName+"_"+key];
        }
        #region ViewState
        public void SetViewState(string key, object value)
        {
            ViewState[key] = value;
        }
        public object GetViewState(string key)
        {
            return ViewState[key];
        }
        public T GetViewState<T>(string key) where T : class
        {
            if (ViewState[key] == null) return null;
            return ViewState[key] as T;
        }
        #endregion
        #endregion

        #region Parameters

        #region PageParameters
        private PageParameters pageParameters;
        protected virtual PageParameters PageParameters
        {
            get
            {
                if (pageParameters == null)
                    pageParameters = UIContext.Current.GetParameters(PageName);
                return pageParameters;
            }
            set
            {
                pageParameters = value;
                UIContext.Current.SetParameters(PageName, value);
            }
        }
        protected Parameters Parameters
        {
            get { return PageParameters.Parameters; }
        }
        public PageParameters GetParameters(string page)
        {
            return UIContext.Current.GetParameters(System.IO.Path.GetFileName(page));
        }

        public T GetParameter<T>(string parameter) where T : class
        {
            return GetParameter(parameter) as T;
        }
        public object GetParameter(string parameter)
        {
            return GetParameter(PageName, parameter);
        }
        public object GetParameter(string page, string parameter)
        {
            return UIContext.Current.GetValue(System.IO.Path.GetFileName(page), parameter);
        }
        public void SetParameter(string parameter, object value)
        {
            SetParameter(PageName, parameter, value);
        }
        public void SetParameter(string page, string parameter, object value)
        {
            UIContext.Current.SetValue(System.IO.Path.GetFileName(page), parameter, value);
        }
        #endregion
        #region General parameters
        public object GetGeneralParameter(string parameter)
        {
            return UIContext.Current.GetGeneralValue(parameter);
        }
        public void SetGeneralParameter(string parameter, object value)
        {
            UIContext.Current.SetGeneralValue(parameter, value);
        }
        #endregion

        #endregion

        #region Protected Members
        protected string pagePrevious;
        protected string pageName;
        #endregion

        #region Protected Properties
        protected virtual string PagePrevious
        {
            get
            {
                if (this.pagePrevious == null && ViewState["PagePrevious"] != null)
                    this.pagePrevious = ViewState["PagePrevious"].ToString();
                return pagePrevious;
            }
            set
            {
                pagePrevious = value;
                ViewState["PagePrevious"] = value;
            }
        }
        protected string PageName
        {
            get { return System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath); }
        }

        #endregion

        #region Page Methods
        protected void Page_Load(object sender, EventArgs e)
        {
            this._SetParameters();
            this._Load();
            if (!this.IsPostBack)
                this._Initialize();
        }
        protected override void OnPreRender(EventArgs e)
        {
            _SetPermissions();
            CanActionsByUser = CanActionsByUser;

            if (this.HadException)
                this.ShowExceptions();
            base.OnPreRender(e);
        }
        protected override void OnError(EventArgs e)
        {
            base.OnError(e);
            Response.Redirect("~/frmError.aspx", false);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //Yahoo
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/yui/build/yahoo/yahoo-min.js", Page.ResolveClientUrl("~/App_Scripts/yui/build/yahoo/yahoo-min.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/yui/build/event/event-min.js", Page.ResolveClientUrl("~/App_Scripts/yui/build/event/event-min.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/yui/build/dom/dom-min.js", Page.ResolveClientUrl("~/App_Scripts/yui/build/dom/dom-min.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/yui/build/json/json-min.js", Page.ResolveClientUrl("~/App_Scripts/yui/build/json/json-min.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/yui/build/animation/animation-min.js", Page.ResolveClientUrl("~/App_Scripts/yui/build/animation/animation-min.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/yui/build/yuiloader/yuiloader-min.js", Page.ResolveClientUrl("~/App_Scripts/yui/build/yuiloader/yuiloader-min.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/yui/build/logger/logger-min.js", Page.ResolveClientUrl("~/App_Scripts/yui/build/logger/logger-min.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/yui/build/element/element-min.js", Page.ResolveClientUrl("~/App_Scripts/yui/build/element/element-min.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/yui/build/button/button-min.js", Page.ResolveClientUrl("~/App_Scripts/yui/build/button/button-min.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/yui/build/yahoo-dom-event/yahoo-dom-event.js", Page.ResolveClientUrl("~/App_Scripts/yui/build/yahoo-dom-event/yahoo-dom-event.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/yui/build/connection/connection-min.js", Page.ResolveClientUrl("~/App_Scripts/yui/build/connection/connection-min.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/yui/build/treeview/treeview-min.js", Page.ResolveClientUrl("~/App_Scripts/yui/build/treeview/treeview-min.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/yui/build/dragdrop/dragdrop-min.js", Page.ResolveClientUrl("~/App_Scripts/yui/build/dragdrop/dragdrop-min.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/yui/build/container/container-min.js", Page.ResolveClientUrl("~/App_Scripts/yui/build/container/container-min.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/yui/build/datasource/datasource-debug.js", Page.ResolveClientUrl("~/App_Scripts/yui/build/datasource/datasource-debug.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/yui/build/autocomplete/autocomplete-debug.js", Page.ResolveClientUrl("~/App_Scripts/yui/build/autocomplete/autocomplete-debug.js"));
            //Jquery
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/jquery-1.3.2.min.js", Page.ResolveClientUrl("~/App_Scripts/jquery-1.3.2.min.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/jquery-ui-1.7.2.custom.min.js", Page.ResolveClientUrl("~/App_Scripts/jquery-ui-1.7.2.custom.min.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/jquery-json.js", Page.ResolveClientUrl("~/App_Scripts/jquery-json.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/shadowbox.js", Page.ResolveClientUrl("~/App_Scripts/shadowbox.js"));
            //Personal
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/HtmlDecode.js", Page.ResolveClientUrl("~/App_Scripts/HtmlDecode.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/Pagina.js", Page.ResolveClientUrl("~/App_Scripts/Pagina.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/Validar.js", Page.ResolveClientUrl("~/App_Scripts/Validar.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/UIHelper.js", Page.ResolveClientUrl("~/App_Scripts/UIHelper.js"));
            Page.ClientScript.RegisterClientScriptInclude("/App_Scripts/TreeSelect.js", Page.ResolveClientUrl("~/App_Scripts/TreeSelect.js"));

        }

        private void AddStyleRange(List<Literal> cssFiles)
        {
            foreach (Literal item in cssFiles)
            {
                this.Header.Controls.Add(item);
            }
        }

        protected override object LoadPageStateFromPersistenceMedium()
        {
            if (!PageBehaviour.PersistUse)
            {
                return base.LoadPageStateFromPersistenceMedium();
            }


            string viewState = PageBehaviour.PersistInViewState ? Request.Form["__VSTATE"]
                                                                : (string)Session[PageName + "_" + Session.SessionID];
            if (PageBehaviour.PersistCompression)
            {
                if (viewState == null) return null;
                byte[] bytes = Convert.FromBase64String(viewState);
                bytes = Compressor.Decompress(bytes);
                LosFormatter formatter = new LosFormatter();
                return formatter.Deserialize(Convert.ToBase64String(bytes));
            }
            else
            {
                return viewState;
            }
        }
        protected override void SavePageStateToPersistenceMedium(object state)
        {
            if (!PageBehaviour.PersistUse)
            {
                base.SavePageStateToPersistenceMedium(state);
                return;
            }

            string viewState = "";
            if (PageBehaviour.PersistCompression)
            {
                LosFormatter formatter = new LosFormatter();
                StringWriter writer = new StringWriter();
                formatter.Serialize(writer, state);
                string viewStateString = writer.ToString();
                byte[] bytes = Convert.FromBase64String(viewStateString);
                bytes = Compressor.Compress(bytes);
                viewState = Convert.ToBase64String(bytes);
            }
            else
            {
                viewState = state.ToString();
            }
            if (PageBehaviour.PersistInViewState)
                ClientScript.RegisterHiddenField("__VSTATE", viewState);
            else
                Session[PageName + "_" + Session.SessionID] = viewState;
        }


        #region Personals
        // <summary>
        /// Se ejecuta una vez al Cargar pro primera vez la pagina
        /// </summary>
        protected virtual void _SetParameters()
        {

        }
        /// <summary>
        /// se ejecuta en cada Postback
        /// </summary>
        protected virtual void _Load()
        {
        }
        /// <summary>
        /// Se ejecuta una vez al Cargar pro primera vez la pagina
        /// </summary>
        protected virtual void _Initialize()
        {
            if (Request["action"] != null)
            {
                if (Request["value"] != null)
                    ControlCommand(Request["action"].ToString(), Request["value"].ToString());
                else
                    ControlCommand(Request["action"].ToString());
            }
            else
            {
                if (Parameters.ContainsKey(PARAMETER_ACTION) && Parameters[PARAMETER_ACTION] != null)
                {
                    if (Parameters.ContainsKey(PARAMETER_VALUE) && Parameters[PARAMETER_VALUE] != null)
                        ControlCommand(Parameters[PARAMETER_ACTION].ToString(), Parameters[PARAMETER_VALUE]);
                    else ControlCommand(Parameters[PARAMETER_ACTION].ToString());
                }
                else
                {
                    DefaultCommand();
                }
            }
            this.PagePrevious = Request.UrlReferrer != null ? Request.UrlReferrer.ToString() : null;
        }
        protected virtual void DefaultCommand()
        {
        }

        protected virtual void _SetPermissions() { }

        #endregion
        #endregion

        #region Translate
        public string Translate(string textCode)
        {
            return UIHelper.Translate(textCode);
        }
        #endregion

        #region Commands
        protected string CommandName;
        protected object CommandValue;
        protected object CommandSender;

        protected void ControlCommand(object sender, ControlCommandEventArgs args)
        {
            ControlCommand(sender, args.CommandName, args.Value);
        }
        protected void ControlCommand(string name)
        {
            ControlCommand(this, name, null);
        }
        protected void ControlCommand(string name, object value)
        {
            ControlCommand(this, name, value);
        }
        protected virtual void ControlCommand(object sender, string name, object value)
        {
            CommandName = name;
            CommandValue = value;
            CommandSender = sender;
            try
            {
                switch (CommandName)
                {
                    case Command.SHOW_ERROR:
                        CommandShowError();
                        break;
                }
                //este Switch no debe tener default para poder permitir ejecutar los comandos de las paginas hijas 
                //a travez de override de ControlCommand
            }
            catch (Exception exception)
            {
                this.Manage(exception);
            }
        }
        protected virtual void CommandShowError()
        {
            if (CommandValue != null)
                throw new ValidationException(CommandValue.ToString());
        }

        #endregion

        #region Exceptions
        public virtual IUserInterfaceMessage MessageDisplay
        {
            get { return null; }
        }
        private List<Exception> exceptions;
        public List<Exception> Exceptions
        {
            get
            {
                if (exceptions == null)
                    this.exceptions = new List<Exception>();
                return exceptions;
            }
            set { exceptions = value; }
        }
        public void Manage(Exception exception)
        {
            try
            {
                if (exception.InnerException != null && exception.InnerException.GetType().Name == "ValidationException" && this.CommandName == Command.CONFIRM_PAGE_GO && ((ValidationException)exception.InnerException).ErrorCode == 9001)
                {
                    UIHelper.ShowAlert("Llegó al final de la lista.", this);
                    return;
                }
                ExceptionPolicy.HandleException(exception, "Application Policy");
            }
            catch (Exception exp)
            {
                this.Exceptions.Add(exp);
            }
        }
        public virtual bool HadException
        {
            get
            {
                if (this.exceptions == null) return false;
                if (this.exceptions.Count == 0) return false;
                return true;
            }
        }
        public virtual void ShowExceptions()
        {
            ShowAlert(this.GetExceptions());
            //if(MessageDisplay!=null)
            //   MessageDisplay.DisplayError(this.GetExceptions());
        }
        public virtual void ShowAlert(string message)
        {
            UIHelper.ShowAlert(message, Page);
        }
        public virtual void ShowInfo(string message)
        {
            if (MessageDisplay != null)
                MessageDisplay.DisplayInfo(message);
        }
        public virtual string GetExceptions()
        {
            return GetExceptions(false);
        }
        public virtual string GetExceptions(string separator)
        {
            return GetExceptions(separator, false);
        }
        public virtual string GetExceptions(bool includeInnerExceptions)
        {
            return GetExceptions(" ", includeInnerExceptions);
        }
        public virtual string GetExceptions(string separator, bool includeInnerExceptions)
        {
            Exception aux;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}", separator);
            foreach (Exception exception in this.Exceptions)
            {
                sb.AppendFormat("{0} {1}", ExceptionFormat(exception), separator);
                if (includeInnerExceptions)
                {
                    aux = exception;
                    while (aux != null)
                    {
                        sb.AppendFormat("{0} {1}", ExceptionFormat(aux), separator);
                        aux = aux.InnerException;
                    }
                }
            }
            return sb.ToString();
        }
        protected virtual string ExceptionFormat(Exception exception)
        {
            return exception.Message;
        }
        #endregion

        #region Methods
        protected virtual void Return()
        {
            if ((this.PagePrevious != null) && (this.PagePrevious.Trim() != string.Empty))
                Response.Redirect(this.PagePrevious, false);
        }
        protected virtual void InicializarPopup(HiddenField X, HiddenField Y, ModalPopupExtender ModalPopup, Panel PanelPopup, System.Web.UI.Page Pagina, Type Type)
        {
            var strb = new StringBuilder();
            strb.Append("Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);");
            strb.Append("Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);");
            strb.Append("function BeginRequestHandler(sender, args) {");
            strb.Append("obtenerPosPopup('" + X.ClientID + "','" + Y.ClientID + "','" + ModalPopup.ClientID + "','" + PanelPopup.ClientID + "')}");
            strb.Append("function EndRequestHandler(sender, args) {");
            strb.Append("setearPosPopup('" + X.ClientID + "','" + Y.ClientID + "','" + ModalPopup.ClientID + "','" + PanelPopup.ClientID + "')}");

            ScriptManager.RegisterStartupScript(Page, Type, "SetearPos", strb.ToString(), true);
        }
        #endregion

        #region Events

        #endregion

        #region Can
        #region CanByUser
        public virtual bool CanByUser(string actionName)
        {
            throw new NotImplementedException();
        }
        public virtual bool CanByUser(string typeName, string actionName)
        {
            return CanByUser(typeName, actionName, null);
        }
        public virtual bool CanByUser(string typeName, string actionName, int? idEstado)
        {
            PermisoByTypeNameResult permiso = (from o in CanActionsByUser where o.TypeName.ToUpper() == typeName.ToUpper() && o.ActionName.ToUpper() == actionName.ToUpper() && o.IdEstado == idEstado select o).FirstOrDefault();
            if (permiso == null)
            {
                permiso = new PermisoByTypeNameResult(typeName, actionName, idEstado);
                permiso.Permiso = AuthorizationManager.AuthorizeByType(ContextUser, typeName, actionName, idEstado);
                CanActionsByUser.Add(permiso);
            }
            return permiso.Permiso;
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
            throw new NotImplementedException();
        }
        public virtual bool CanByOffice(string typeName, List<PerfilOficina> perfilOficinas, string actionName, int? idEstado)
        {
            return AuthorizationManager.AuthorizeByOffice(ContextUser, typeName, perfilOficinas, actionName, idEstado);
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
            throw new NotImplementedException();
        }
        #endregion
        #region CanById
        public virtual bool CanById(object id, string actionName)
        {
            throw new NotImplementedException();
        }
        public virtual string VerificarEstadoDecision(object id, string actionName, string actionNameCurrent)
        {
            throw new NotImplementedException();
        }

        public virtual bool HideButtonStates(object id, string actionName)
        {
            throw new NotImplementedException();
        }
        public virtual bool CanByResult(object result, string actionName)
        {
            return CanByResult(result, actionName, null);
        }
        public virtual bool CanByResult(object result, string actionName, int? idEstado)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion

        #region Export
        public virtual void ShowDownLoadExport()
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "OpenFile", "window.open( '../Controls/OpenFileFromSession.aspx', null, 'height=1,width=1,status=yes,toolbar=no,menubar=no,location=no' );", true);
        }
        public virtual void ShowPrintExport()
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "print", "window.open( '../Reportes/PageReport.aspx', null,'location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes' );", true);
        }
        #endregion
    }

    public abstract class CrudPage<TEntity, TFilter, TResult, TIdType> : PageBase
        where TEntity : class, new()
        where TFilter : nc.Filter, new()
        where TResult : class,nc.IResult<TIdType>, new()
        where TIdType : IComparable
    {
        public const string FilterKey = "Filter";

        #region Service
        protected virtual IViewService<TEntity, TFilter, TResult, TIdType> ViewService
        {
            get { throw new NotImplementedException(); }
        }
        protected virtual IEntityService<TEntity, TFilter, TResult, TIdType> EntityService
        {
            get { throw new NotImplementedException(); }
        }
        #endregion

        #region Controls
        protected WebControlEdit<TEntity> webControlEdit;
        protected WebControlList<TResult, TIdType> webControlList;
        protected WebControlFilter<TFilter> webControlFilter;
        public IEditionButtons webControlEditionButtons;
        public IListButtons webControlListButtons;
        #endregion

        protected abstract TIdType ConvertId(object value);
        protected bool EntityHadChanges()
        {
            return EntityService.Equals(Entity, EntityOld);
        }

        #region Properties
        int? maxRowsByPage;
        protected virtual int MaxRowsByPage
        {
            get
            {
                if (maxRowsByPage.HasValue == false)
                {
                    if (ViewState["maxRowsByPage"] == null)
                    {
                        nc.Parameter parameter = ns.ParameterService.Current.FirstOrDefault(new nc.ParameterFilter() { Code = "MAX_SIZE_PAGE" });
                        maxRowsByPage = (parameter != null) ? (int)parameter.NumberValue : 100;
                        ViewState["maxRowsByPage"] = maxRowsByPage;
                    }
                    else
                    {
                        int value;
                        if (int.TryParse(ViewState["maxRowsByPage"].ToString(), out value))
                            maxRowsByPage = value;
                        else
                            value = 100;
                    }
                }
                return maxRowsByPage.Value;
            }
        }
        protected TEntity entity;
        public virtual TEntity Entity
        {
            get
            {
                if (entity == null && EntityService != null)
                {
                    object obj = ViewState["entity"];
                    if (obj == null)
                    {
                        entity = new TEntity();
                        if (PageBehaviour.HadSerializeEntity)
                            ViewState["entity"] = EntityService.Serialize(entity);
                        else
                            ViewState["entity"] = entity;
                    }
                    else
                    {
                        if (PageBehaviour.HadSerializeEntity)
                            entity = EntityService.Deserialize(obj.ToString());
                        else
                            entity = obj as TEntity;
                    }
                }
                return entity;
            }
            set
            {
                entity = value;
                if (EntityService != null)
                {
                    if (PageBehaviour.HadSerializeEntity)
                        ViewState["entity"] = EntityService.Serialize(value);
                    else
                        ViewState["entity"] = value;
                }
            }
        }
        protected TEntity entityOld;
        public virtual TEntity EntityOld
        {
            get
            {
                if (entityOld == null && EntityService != null)
                {
                    object obj = ViewState["entityOld"];
                    if (obj == null)
                    {
                        entityOld = new TEntity();
                        if (PageBehaviour.HadSerializeEntity)
                            ViewState["entityOld"] = EntityService.Serialize(entityOld);
                        else
                            ViewState["entityOld"] = entityOld;
                    }
                    else
                    {
                        if (PageBehaviour.HadSerializeEntity)
                            entityOld = EntityService.Deserialize(obj.ToString());
                        else
                            entityOld = obj as TEntity;
                    }
                }
                return entityOld;
            }
            set
            {
                entityOld = value;
                if (EntityService != null)
                    if (PageBehaviour.HadSerializeEntity)
                        ViewState["entityOld"] = EntityService.Serialize(entityOld);
                    else
                        ViewState["entityOld"] = entityOld;
            }
        }
        protected TFilter filter;
        protected virtual TFilter Filter
        {
            get
            {
                if (filter == null)
                {
                    object obj = ViewState["filter"];
                    if (obj != null)
                    {
                        filter = obj as TFilter;
                    }
                    else if (filter == null)
                    {
                        filter = GetParameter<TFilter>(FilterKey);
                        if (filter == null) filter = new TFilter();
                    }
                }
                return filter;
            }
            set
            {
                filter = value;
                ViewState["filter"] = value;
            }
        }
        protected ListPaged<TResult> list;
        protected virtual ListPaged<TResult> List
        {
            get
            {
                if (list == null)
                {
                    object obj = ViewState["list"];
                    if (obj != null)
                        list = obj as ListPaged<TResult>;
                    if (list == null)
                        list = new ListPaged<TResult>();
                }
                return list;
            }
            set
            {
                list = value;
                ViewState["list"] = value;
            }
        }
        protected string pathEditPage;
        protected virtual string PathEditPage
        {
            get
            {
                if (pathEditPage == null)
                {
                    if (ViewState["pathEditPage"] == null)
                        pathEditPage = ViewState["pathEditPage"].ToString();
                }
                return pathEditPage;
            }
            set
            {
                pathEditPage = value;
                ViewState["pathEditPage"] = value;
            }
        }
        protected string pathListPage;
        protected virtual string PathListPage
        {
            get
            {
                if (pathListPage == null)
                {
                    if (ViewState["pathListPage"] != null)
                        pathListPage = ViewState["pathListPage"].ToString();
                }
                return pathListPage;
            }
            set
            {
                pathListPage = value;
                ViewState["pathListPage"] = value;
            }
        }
        protected string editFilter;
        public virtual string EditFilter
        {
            get
            {
                if (editFilter == null)
                {
                    if (ViewState["editFilter"] != null)
                        editFilter = ViewState["editFilter"].ToString();
                }
                return editFilter;
            }
            set
            {
                editFilter = value;
                ViewState["editFilter"] = value;
            }
        }
        protected string actualPopupId;
        protected virtual string ActualPopupId
        {
            get
            {
                if (actualPopupId == null)
                {
                    if (ViewState["actualPopupId"] != null)
                        actualPopupId = ViewState["actualPopupId"].ToString();
                }
                return actualPopupId;
            }
            set
            {
                actualPopupId = value;
                ViewState["actualPopupId"] = value;
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            Entity = Entity;
            EntityOld = EntityOld;
            List = List;
            Filter = Filter;
            //MaxRowsByPage = MaxRowsByPage;
            base.OnPreRender(e);
        }
        #endregion

        #region Can
        #region CanByUser
        public override bool CanByUser(string actionName)
        {
            return CanByUser(typeof(TEntity).Name, actionName, null);
        }
        public virtual bool CanByUser(TEntity entity, string actionName)
        {
            return CanByUser(entity, actionName, null);
        }
        public virtual bool CanByUser(TEntity entity, string actionName, int? idEstado)
        {
            string typeName = entity == null ? typeof(TEntity).Name : this.EntityService.GetInfoEntity(entity).TypeName;
            return CanByUser(typeName, actionName, idEstado);
        }
        #endregion
        #region CanByOffice
        public override bool CanByOffice(List<PerfilOficina> perfilOficinas, string actionName, int? idEstado)
        {
            return CanByOffice(typeof(TEntity).Name, perfilOficinas, actionName, idEstado);
        }
        #endregion
        #region Can
        public virtual bool Can(TEntity entity, string actionName)
        {
            return Can(entity, actionName, null);
        }
        public override bool Can(object entity, string actionName, int? idEstado)
        {
            return Can(entity as TEntity, actionName, idEstado);
        }
        public virtual bool Can(TEntity entity, string actionName, int? idEstado)
        {
            if (EntityService == null) return true;
            if (!CanByUser(entity, actionName, idEstado)) return false;
            return this.EntityService.Can(entity, actionName, UIContext.Current.ContextUser);
        }
        #endregion
        #region CanById
        public override bool CanById(object id, string actionName)
        {
            return CanById(ConvertId(id), actionName);
        }
        public virtual bool CanById(TIdType id, string actionName)
        {
            if (!CanByUser(actionName)) return false;
            return this.EntityService.Can(id, actionName, UIContext.Current.ContextUser);
        }
        #endregion
        #region CanByResult
        public virtual bool CanByResult(TResult result, string actionName)
        {
            return CanByResult(result, actionName, null);
        }
        public override bool CanByResult(object result, string actionName, int? idEstado)
        {
            return CanByResult(result as TResult, actionName, idEstado);
        }
        public virtual bool CanByResult(TResult result, string actionName, int? idEstado)
        {
            if (EntityService == null) return true;
            if (!CanByUser(EntityService.ToEntity(result), actionName, idEstado)) return false;
            return this.EntityService.Can(result, actionName, UIContext.Current.ContextUser);
        }
        #endregion
        #endregion

        #region Commands
        protected override void ControlCommand(object sender, string name, object value)
        {
            //se debe llamar si o si al metodo de la clase base para poder manejar los comandos a nivel del PageBase
            base.ControlCommand(sender, name, value);
            try
            {
                switch (CommandName)
                {
                    case Command.SORT:
                        CommandSort();
                        break;
                    case Command.APPLY:
                        CommandApply();
                        break;
                    case Command.RELOAD:
                        if (!PageBehaviour.ReloadAlways)
                            CommandReload();
                        break;
                    case Command.CONFIRM_PAGE_GO:
                        CommandConfirmPageGo();
                        break;
                    case Command.PAGE_GO:
                        CommandPageGo();
                        break;
                    case Command.REFRESH:
                        CommandRefresh();
                        break;
                    case Command.SEARCH:
                        CommandSearch();
                        break;
                    case Command.CLEAR_SEARCH:
                        CommandClearSearch();
                        break;
                    case Command.EXPORT_EXCEL:
                        CommandExportExcel();
                        break;
                    case Command.EXPORT_PDF:
                        CommandExportPdf();
                        break;
                    case Command.SHOW_STORE_REPORT:
                        CommandShowStoreReport();
                        break;
                    case Command.SHOW_REPORT:
                        CommandShowReport();
                        break;
                    case Command.SHOW_EXCEL_REPORT:
                        CommandShowExcelFromReport();
                        break;
                    case Command.ADD_NEW:
                        CommandAddNew();
                        break;
                    case Command.DELETE:
                        CommandDelete();
                        break;
                    case Command.READ:
                    case Command.VIEW:
                        CommandView();
                        break;
                    case Command.EDIT:
                        CommandEdit();
                        break;
                    case Command.COPY:
                        CommandCopy();
                        break;
                    case Command.COPY_AND_SAVE:
                        CommandCopyAndSave();
                        break;
                    case Command.CANCEL:
                        CommandCancel();
                        break;
                    case Command.SAVE:
                        CommandSave();
                        break;
                    case Command.SAVE_AND_NEW:
                        CommandSaveAndNew();
                        break;
                    case Command.LIST_LOG:
                        CommandListLog();
                        break;
                    case Command.VIEW_LOG:
                        CommandViewLog();
                        break;
                    case Command.CANCEL_POPUP:
                        CommandHidePopup();
                        break;
                    default:
                        CommandOthers();
                        break;
                }
            }
            catch (Exception exception)
            {
                this.Manage(exception);
            }
        }
        protected virtual void CommandHidePopup()
        {
            WebControlPopup popup = GetPopup(ActualPopupId);
            if (popup != null)
            {
                popup.HidePopup();
                popup.Visible = false;
            }
        }
        protected virtual void CommandReload()
        {
            this.ReloadFilter();
            this.RefreshFilter();
            this.RefreshList();
            this.ShowList();
        }
        protected virtual void CommandSort()
        {
            this.RefreshOrder();
            this.RefreshFilter();
            this.RefreshList();
            this.ShowList();
        }
        protected virtual void CommandConfirmPageGo()
        {
        }
        protected virtual void CommandCancelPageGo()
        {
        }
        protected virtual void CommandPageGo()
        {
            this.RefreshFilter();
            this.RefreshList();
            this.ShowList();
        }
        protected virtual void CommandRefresh()
        {
            this.RefreshFilter();
            this.RefreshList();
            this.ShowList();
        }
        protected virtual void CommandSearch()
        {
            this.Search();
            this.RefreshList();
            this.ShowList();
        }
        protected virtual void CommandClearSearch()
        {
            this.ClearSearch();
        }
        protected virtual void CommandExportExcel()
        {
            this.Search();
            this.GenerateExcel();
            this.ShowDownLoadExport();
        }
        protected virtual void CommandExportPdf()
        {
            this.Search();
            this.GeneratePdf();
            this.ShowDownLoadExport();
        }
        protected virtual void CommandShowStoreReport()
        {
            this.Search();
            this.GenerateStoreReport();
            this.ShowDownLoadExport();
        }
        protected virtual void CommandShowReport()
        {
            this.Search();
            this.ShowReport();
        }
        protected virtual void CommandShowExcelFromReport()
        {
            this.Search();
            this.ShowExcelFromReport();
        }

        protected virtual void CommandApply()
        {
            Save();
            if (CrudAction == CrudActionEnum.Create) CrudAction = CrudActionEnum.Update;
            ShowEdit();
        }
        protected virtual void CommandAddNew()
        {
            CrudAction = CrudActionEnum.Create;
            AddNew();
            ShowEdit();
        }
        protected virtual void CommandEdit()
        {
            CrudAction = CrudActionEnum.Update;
            Edit();
            ShowEdit();
        }
        protected virtual void CommandView()
        {
            CrudAction = CrudActionEnum.Read;
            View();
            ShowView();
            DisableEdit();
        }
        protected virtual void CommandCopy()
        {
            Copy();
            ShowEdit();
        }
        protected virtual void CommandCopyAndSave()
        {
            CopyAndSave();
            HideEdit();
            RefreshList();
            ShowList();
        }
        protected virtual void CommandDelete()
        {
            //CrudAction = CrudActionEnum.Delete;
            Delete();
            HideEdit();
            RefreshList();
            ShowList();
        }
        protected virtual void CommandCancel()
        {
            Cancel();
            HideEdit();
            RefreshList();
            ShowList();
        }
        protected virtual void CommandSave()
        {
            Save();
            HideEdit();
            HideEdit();
            RefreshList();
            ShowList();
        }
        protected virtual void CommandSaveAndNew()
        {
            Save();
            CrudAction = CrudActionEnum.Create;
            AddNew();
            ShowEdit();
        }
        protected virtual void CommandListLog()
        {
            ListLog();
        }
        protected virtual void CommandViewLog()
        {
            CrudAction = CrudActionEnum.Read;
            ViewLog();
            ShowView();
            DisableEdit();
        }


        protected virtual void CommandOthers() { }
        #endregion

        #region Commands Methods
        protected virtual void Edit() { }
        protected virtual void View() { }
        protected virtual void ListLog() { }
        protected virtual void ViewLog() { }
        protected virtual void Copy() { }
        protected virtual void CopyAndSave() { }
        protected virtual void Delete() { }
        protected virtual void AddNew() { }
        protected virtual void ReloadFilter() { }
        protected virtual void RefreshOrder() { }
        protected virtual void RefreshFilter() { }
        protected virtual void Search() { }
        protected virtual void ClearSearch() { }
        protected virtual void RefreshList() { }
        protected virtual void Save() { }
        protected virtual void ShowView() { }
        protected virtual void ShowEdit() { }
        protected virtual void DisableEdit() { }
        protected virtual void Cancel() { }
        protected virtual void HideEdit() { }
        protected virtual void ShowList() { }
        protected virtual void HideList() { }
        //protected virtual void CloseEdit(){}  
        protected virtual WebControlPopup GetPopup(string controlId)
        {
            for (int i = 0, count = this.Controls.Count; i < count; i++)
                if (this.Controls[i].ID != null && this.Controls[i].ID.Equals(controlId, StringComparison.InvariantCultureIgnoreCase))
                    return Controls[i] as WebControlPopup;
            return null;
        }

        protected virtual void GenerateExcel() { }
        protected virtual void GenerateStoreReport() { }
        protected virtual void GeneratePdf() { }

        protected virtual void ShowReport() { }
        protected virtual void ShowExcelFromReport() { }

        #endregion

        #region Functions

        #endregion

        #region Action
        protected void Execute(TEntity entity, string actionName)
        {
            Execute(entity, actionName, true);
        }
        protected void Execute(TEntity entity, string actionName, bool showFinalization)
        {
            EntityService.Execute(entity, actionName, ContextUser);
            if (showFinalization) ShowAlert(Translate("Ejecución Finalizada"));
        }
        protected void Execute(TFilter filter, string actionName)
        {
            Execute(filter, actionName, true);
        }
        protected void Execute(TFilter filter, string actionName, bool showFinalization)
        {
            EntityService.Execute(filter, actionName, ContextUser);
            if (showFinalization) ShowAlert(Translate("Ejecución Finalizada"));
        }
        protected void Execute(TIdType id, string actionName)
        {
            Execute(id, actionName, true);
        }
        protected void Execute(TIdType id, string actionName, bool showFinalization)
        {
            EntityService.Execute(id, actionName, ContextUser);
            if (showFinalization) ShowAlert(Translate("Ejecución Finalizada"));
        }
        protected void Execute(TResult result, string actionName)
        {
            Execute(result, actionName, true);
        }
        protected void Execute(TResult result, string actionName, bool showFinalization)
        {
            EntityService.Execute(EntityService.ToEntity(result), actionName, ContextUser);
            if (showFinalization) ShowAlert(Translate("Ejecución Finalizada"));
        }
        protected void Execute(TResult result, string actionName, bool showFinalization, Hashtable args)
        {
            EntityService.Execute(EntityService.ToEntity(result), actionName, ContextUser, args);
            if (showFinalization) ShowAlert(Translate("Ejecución Finalizada"));
        }
        #endregion



    }
}

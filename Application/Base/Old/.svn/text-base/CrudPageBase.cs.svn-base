using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Service;
using Contract;
using AjaxControlToolkit;
using Ingematica.Librerias.Helpers;
using System.Text;
using System.Web.UI.HtmlControls;
using Application.Controls;

namespace UI.Web
{
    public abstract class CrudPageBase<TEntity,TIdType> : PageBaseOLD
        where TEntity : class
    {
        #region Properties
        /// <summary>
        /// Entidad
        /// </summary>
        private TEntity entity;
        protected virtual TEntity Entity
        {
            get
            {
                if (entity == null)
                {
                    if (ViewState["entity"] == null)
                        ViewState["entity"] = Service.GetNew();
                    entity = ViewState["entity"] as TEntity;
                }
                return entity;
            }
            set {
                entity = value;
                ViewState["entity"] = value; 
                }
        }
        protected override void OnPreRender(EventArgs e)
        {
            Entity = Entity;
            base.OnPreRender(e);
        }
        /// <summary>
        /// Accion actual
        /// </summary>
        protected ActionEnum Action
        {
            get
            {
                return (ActionEnum)ViewState["Action"];
            }
            set
            {
                ViewState["Action"] = value;
            }
        }

        protected IEntityService<TEntity, TIdType> service;
        protected IEntityService<TEntity, TIdType> Service
        {
            get
            {
                if (service == null)
                    service = GetService();
                return service;
            }
            set { service = value; }
        }
        protected abstract IEntityService<TEntity, TIdType> GetService();
        /// <summary>
        /// Panel de edicion
        /// </summary>
        protected abstract ModalPopupExtender EditPopup { get; }
        protected abstract UpdatePanel EditUpdatePanel { get; }
        public abstract IUserInterfaceMessage MessageDisplay { get; }
        public abstract IUserInterfaceMessage MessagePanelDisplay { get; }
        /// <summary>
        /// Panel de edicion
        /// </summary>
        protected abstract GridView Grid { get; }
        #endregion
        #region Base Events
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Grid.PageSize = SystemConfig.DisplayRows;
                SortDirection = SortDirection.Ascending;
                LoadControlText();
            }
        }
        protected virtual void Grid_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                SortExpression = e.SortExpression;
                //SortDirection = e.SortDirection ;
                Grid.PageIndex = 0;
                Refresh();
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }
        protected virtual void Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                Grid.PageIndex = e.NewPageIndex;
                Refresh();
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        protected virtual void btEdit_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(_btEdit_Click,DisplayError);
        }
        protected virtual void btAdd_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(_btAdd_Click,DisplayError);
        }
        protected virtual void btCancel_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(_btCancel_Click,DisplayError);
            Hide();
        }
        protected virtual void btOk_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(_btOk_Click,DisplayPanelError);
            UIHelper.CallTryMethod(SetValues, DisplayPanelError);       //Si da excepcion es necesario, sino lo limpia el clear controls
            Refresh();
        }
        protected virtual void btApply_Click(object sender, EventArgs e)
        {
            if (IsValid)
                UIHelper.CallTryMethod(_btApply_Click,DisplayPanelError);
            UIHelper.CallTryMethod(SetValues, DisplayPanelError);
            Refresh();
        }
        protected virtual void btNew_Click(object sender, EventArgs e)
        {
            if (IsValid)
                UIHelper.CallTryMethod(_btNew_Click, DisplayPanelError);
            UIHelper.CallTryMethod(SetValues, DisplayPanelError);
            Refresh();
        }

        protected virtual void btSearch_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(_btSearch_Click, DisplayError);
        }
        protected virtual void btDelete_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(_btDelete_Click,DisplayError);
        }
        protected virtual void btCopy_Click(object sender, EventArgs e)
        {
            InitializeEdition();
            UIHelper.CallTryMethod(Copy,DisplayPanelError);
            Refresh();
        }       
        protected virtual void _btEdit_Click()
        {
            InitializeEdition();
            Edit();
            Show();
        }
        protected virtual void _btAdd_Click()
        {
            InitializeEdition();
            Clear();
            SetValues();  
            Show();
        }
        protected virtual void _btCancel_Click()
        {
            Clear();
            Hide();
        }
        protected virtual void _btOk_Click()
        {
            Save();
            Hide();
        }
        protected virtual void _btApply_Click()
        {
            Save();
            SetDefaultFocus();
            SetAction(ActionEnum.Update);            
            //DisplayPanelInfo(GetUIMessage(PageCode.Master, SuccessMessage, Contract.Context.IdLanguage));
        }
        protected virtual void _btNew_Click()
        {
            Save();
            Clear();
            SetValues();
            SetDefaultFocus();
            SetAction(ActionEnum.Create);          
        }
        protected virtual void _btSearch_Click()
        {
            Refresh();
        }
        protected virtual void _btDelete_Click()
        {
            Delete();
            Refresh();
        }

        #endregion Base Events
        #region Abstract Methods
        protected virtual void Delete()
        {
            var entities = GetSelectedEntities();

            Action = ActionEnum.Undefined;

            foreach (object e in entities)
            {
              TEntity entity = e as TEntity;
              if (entity != null && Service.Can(entity, ActionEnum.Delete, this.ContextUser))
                  Service.Delete(entity,this.ContextUser);
            }
        }
        protected abstract void SetDefaultFocus();
        protected virtual void Clear()
        {
            Action = ActionEnum.Undefined;
            Entity = Service.GetNew();
            ClearControls();            
        }
        protected virtual void Save()
        {            
            GetValues();
            switch (Action)
            {
                case ActionEnum.Create:
                case ActionEnum.Update:
                    Service.Save(Entity, this.ContextUser);
                    break;
                default:
                    break;
            }            
        }
        protected virtual void Edit()
        {
            Action = ActionEnum.Update;
            Entity = GetSelectedEntity();
            if (Service.Can(Entity, ActionEnum.Update,this.ContextUser))
            {
                SetValues();               
            }
        }
        protected virtual void Copy()
        {
            Entity = Service.Copy(GetSelectedEntity(), this.ContextUser) as TEntity;
            Action = ActionEnum.Update;
            SetValues();
            Show();
        }
        protected virtual void Show()
        {
            Action = Action == ActionEnum.Undefined ? ActionEnum.Create : Action;
            EditUpdatePanel.Update();
            EditPopup.Show();
            SetDefaultFocus();
        }
        protected virtual void Hide()
        {
            EditPopup.Hide();
        }
        protected virtual void Refresh()
        {           
            Grid.DataSource = GetGridData();
            Grid.DataBind();
            // base.PersistObject(Service.GetNewObject());
        }
        protected virtual void LoadControlText()
        {
            //ITextProvider textProvider = TextProviderFactory.CreateTextProvider((int)TextProviders.DatabaseTextProvider);
            //var text = textProvider.GetText((short)GetPageCode(), Contract.Context.IdLanguage);

            //SetControlsText(this.Controls, text);
        }
        protected abstract List<object> GetGridData();
        /// <summary>
        /// Trae el item seleccionado
        /// </summary>
        protected abstract List<object> GetSelectedEntities();
        protected virtual TEntity GetSelectedEntity()
        {
            return GetSelectedEntities().FirstOrDefault() as TEntity;
        }
        protected override void DisplayError(string message)
        {
            MessageDisplay.DisplayError(message);
        }
        protected override void DisplayInfo(string message)
        {
            MessageDisplay.DisplayInfo(message);
        }
        protected void DisplayPanelInfo(string message)
        {
            MessagePanelDisplay.DisplayInfo(message);
        }
        protected void DisplayPanelError(string message)
        {
            MessagePanelDisplay.DisplayError(message);
        }
        protected virtual void InitializeEdition(){ } 
        //protected void DisplayError(Exception ex)
        //{
        //    MessageDisplay.DisplayError(ProcessException(ex));
        //}
        //protected void DisplayInfo(Exception ex)
        //{
        //    MessageDisplay.DisplayInfo(ProcessException(ex));
        //}
        //protected void DisplayPanelInfo(Exception ex)
        //{
        //    MessagePanelDisplay.DisplayInfo(ProcessException(ex));
        //}
        //protected void DisplayPanelError(Exception ex)
        //{
        //    MessagePanelDisplay.DisplayError(ProcessException(ex));
        //}

        /// <summary>
        /// Metodo a Sobreescribir donde setean los valores de los controles de edicion
        /// </summary>
        protected abstract void SetValues();
        /// <summary>
        /// Metodo a Sobreescribir donde se leen los valores de los controles de edicion
        /// </summary>
        protected abstract void GetValues();

        /// <summary>
        /// Metodo a Sobreescribir donde se debe limpiar los controles
        /// </summary>
        protected abstract void ClearControls();



        protected void SetAction(ActionEnum action)
        {
            Action = action;
        }
        #endregion Abstract Methods
        #region Private Methods
       
        protected void InicializarPopup(HiddenField X, HiddenField Y, ModalPopupExtender ModalPopup, Panel PanelPopup, System.Web.UI.Page Pagina, Type Type)
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
        //protected string GetUIMessage(PageCode pageCode, string field, short idLanguage)
        //{
        //    //ITextProvider provider = TextProviderFactory.CreateTextProvider((int)TextProviders.DatabaseTextProvider);
        //    //return provider.GetFieldText((short)pageCode, field, idLanguage);
        //}
        private const string SuccessMessage = "msgSuccess";
        //private const string DuplicateKeyMessage = "DuplicateKey";
        //private const string FKDeleteConstraint = "FKDeleteConstraint";
        //private const string FKUpdateConstraint = "FKUpdateConstraint";
        //private const string FKEditConstraint = "FKEditConstraint";
        //private const string DuplicateFieldMessage = "DuplicateField";
        //private string ProcessException(Exception ex)
        //{
        //    List<string> Messages = new List<string>() { DuplicateKeyMessage, FKDeleteConstraint, FKEditConstraint, FKUpdateConstraint };
        //    string msg = ex.Message;
        //    // PENDIENTE VER ESTO
        //    //string msg = ExceptionHelper.Process(ex);
        //    //Solucion por ahora, ya que la creacion de usuarios en membership devuelve errores como "DuplicateEmail"
        //    if (msg.StartsWith("Duplicate") && !msg.Equals(DuplicateKeyMessage))
        //    {
        //        ITextProvider provider = TextProviderFactory.CreateTextProvider((int)TextProviders.DatabaseTextProvider);
        //        msg = provider.GetFieldText((short)PageCode.Master, DuplicateFieldMessage, Contract.Context.IdLanguage) + msg.Substring(9);
        //    }
        //    else if (Messages.Contains(msg))
        //    {
        //        ITextProvider provider = TextProviderFactory.CreateTextProvider((int)TextProviders.DatabaseTextProvider);
        //        msg = provider.GetFieldText((short)PageCode.Master, msg, Contract.Context.IdLanguage);
        //    }
        //    else
        //    {//falta probar
        //        if (ex is ValidationException)
        //            msg = UIHelper.TaslateMessage((short)PageCode.Master,(ex as ValidationException), Contract.Context.IdLanguage);
        //        else
        //            msg=UIHelper.TaslateMessage((short)PageCode.Master,ex.Message,Contract.Context.IdLanguage);
        //    }
        //    return msg;
        //}

        protected static bool EvalIdNullBool(object valor)
        {
            return (valor != null) ? false : true;
        }

        #endregion
    }

   
}

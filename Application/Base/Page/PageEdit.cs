using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using Service;
using nc = Contract;
using Contract;
using Application.Controls;
using Business;
namespace UI.Web
{
    /// <summary>
    /// Summary description for PageList
    /// </summary>
    public abstract class PageEdit<TEntity, TFilter, TResult, TIdType> : CrudPage<TEntity, TFilter, TResult, TIdType>
        where TEntity : class, new()
        where TFilter : nc.Filter, new()
        where TResult : class, nc.IResult<TIdType>, new()
        where TIdType : IComparable
    {
        #region Properties
        public override IUserInterfaceMessage MessageDisplay
        {
            get { return Master.FindControl("MessageBarForm") as IUserInterfaceMessage; }
        }
        #endregion

        #region Controls
        protected WebControlConfirm webControlConfirm;
        protected WebControlPaggingInPage webControlPaggingInPage;
        #endregion

        #region page Methods
        protected override void _Initialize()
        {
            base._Initialize();
            _SetFilter();
        }
        protected virtual void _SetFilter()
        {
            if (EditFilter != string.Empty)
            {
                Filter = GetGeneralParameter(EditFilter) as TFilter;
                if (Filter != null && webControlPaggingInPage != null)
                {
                    webControlPaggingInPage.Pagging = Filter.Paged;
                    webControlPaggingInPage.LoadPagging();
                }
            }
        }
        protected override void _Load()
        {
            base._Load();
            if (webControlEdit != null)
            {
                webControlEdit.ControlCommand += new ControlCommandHandler(ControlCommand);
                webControlEdit.Entity = Entity;
            }
            if (webControlEditionButtons != null) webControlEditionButtons.ControlCommand += new ControlCommandHandler(ControlCommand);
            if (webControlPaggingInPage != null) webControlPaggingInPage.ControlCommand += new ControlCommandHandler(ControlCommand);
            if (webControlConfirm != null) webControlConfirm.ControlCommand += new ControlCommandHandler(ControlCommand);

        }
        protected override void OnPreRender(EventArgs e)
        {
            if (webControlEditionButtons != null)
            {
                webControlEditionButtons.EnableDelete = EntityService.Can(Entity, ActionConfig.DELETE, this.ContextUser);
            }
            base.OnPreRender(e);
        }
        #endregion



        //public void Reload(TEntity entityToSave,TFilter newFilter)
        //{
        //    EntityService.Update(entityToSave);
        //    this.Entity= EntityService.FirstOrDefault(newFilter);
        //    this.EntityOld = this.Entity;
        //    if(this.webControlEdit!=null)this.webControlEdit.Entity = this.Entity; 
        //}



        #region Commands

        protected override void CommandConfirmPageGo()
        {
            webControlEdit.Entity = Entity;
            webControlEdit.GetValue();
            if (PageBehaviour.ConfirmOnPageChange && CrudAction == CrudActionEnum.Update && !EntityService.Equals(Entity, EntityOld) && webControlConfirm != null && webControlPaggingInPage != null)
            {
                //Muestra la pagina
                webControlPaggingInPage.SetOldPage();
                Filter.Paged = webControlPaggingInPage.GetPagging();
                SetGeneralParameter(EditFilter, Filter);
                //Muestra el mensaje
                webControlConfirm.SetTitulo(SolutionContext.Current.TextManager.Translate("MSG_CONFIRMCHANGE_TITLE"));
                webControlConfirm.SetMensaje(SolutionContext.Current.TextManager.Translate("MSG_CONFIRMCHANGE"));
                webControlConfirm.CommandName = Command.PAGE_GO;
                webControlConfirm.CommandValue = (string)CommandValue;
                webControlConfirm.Show();
                return;
            }
            else
            {
                CommandPageGo();
            }
        }
        protected override void CommandPageGo()
        {
            this.RefreshPage();
            this.RefreshEntity();

            if (CrudAction == CrudActionEnum.Read)
            {
                ShowView();
            }
            else
            {
                EntityOld = Entity;
                ShowEdit();
            }
        }
        protected virtual void RefreshPage()
        {
            if (webControlPaggingInPage != null)
            {
                webControlPaggingInPage.SetPendingConmfirmPage();
                Filter.Paged = webControlPaggingInPage.GetPagging();
            }
        }
        protected virtual void RefreshEntity()
        {
            SetGeneralParameter(EditFilter, Filter);
            Entity = EntityService.FirstOrDefaultUsingResult(Filter);
        }
        protected override void DefaultCommand()
        {
            ControlCommand(Command.ADD_NEW);
        }
        protected override void AddNew()
        {
            Entity = EntityService.GetNew();
            CrudAction = CrudActionEnum.Create;
        }
        protected override void Edit()
        {
            TIdType id = ConvertId(ConvertId(CommandValue));
            Entity = EntityService.GetById(id);
            if (Entity != null)
            {
                string serializeEntityOld = EntityService.Serialize(Entity);
                EntityOld = EntityService.Deserialize(serializeEntityOld);
            }
        }
        protected override void View()
        {
            TIdType id = ConvertId(ConvertId(CommandValue));
            Entity = EntityService.GetById(id);
        }
        protected override void ViewLog()
        {
            int idLog;
            if (int.TryParse(CommandValue.ToString(), out idLog))
            {
                Entity = EntityService.GetLog(idLog);
            }
            else
            {
                Entity = null;
            }
        }
        protected override void Copy()
        {
            TIdType id = ConvertId(ConvertId(CommandValue));
            Entity = EntityService.Copy(id, this.ContextUser);
        }
        protected override void Save()
        {
            webControlEdit.Entity = Entity;
            webControlEdit.GetValue();
            string aux = null;
            try
            {
                EntityOld = Entity; //Matias 20170201 - Lo puse antes del "Save"
                if (EntityService.Behaviour.EntityIsSerializable) aux = EntityService.Serialize(Entity);
                EntityService.Save(Entity, this.ContextUser);
                //EntityOld = Entity; //Matias 20170201 

                //Matias 20140123 - Tarea 112
                //En caso que sea una CREACION EXITOSA de un PROYECTO ==> Muestra el mensaje con el CODIGO BAPIN generado.
                Type a = entity.GetType();
                Type tPro = typeof(Contract.ProyectoGeneralCompose);
                Type tPre = typeof(Contract.PrestamoGeneralCompose);

                if ((CrudAction == CrudActionEnum.Create) && (a.Equals(tPro)))
                {        
                    //Nuevo Proyecto creado!
                    Object ob = (Object)entity;
                    string cb = ((Contract.ProyectoGeneralCompose)ob).proyecto.CodigoString;
                    UIHelper.ShowAlert(SolutionContext.Current.TextManager.Translate("MSG_NEWPROJECT") + " " + cb, this.Page);
                    //return;
                }
                //FinMatias 20140123 - Tarea 112
                //Matias 20140424 - Tarea 137
                else
                    if ((CrudAction == CrudActionEnum.Create) && (a.Equals(tPre)))
                    {
                        //Nuevo Prestamo creado!
                        Object ob = (Object)entity;
                        string cb = ((Contract.PrestamoGeneralCompose)ob).Prestamo.CodigoString;
                        UIHelper.ShowAlert(SolutionContext.Current.TextManager.Translate("MSG_NEWPRESTAMO") + " " + cb, this.Page);
                        //return;
                    }
                    else
                    {
                        //Matias 20170201- Ticket #REQ571729
                        if ((CrudAction == CrudActionEnum.Update) && (a.Equals(tPro)))
                        {
                            //Cambio de estado del Proyecto (Solapa General >> Estado "En Ejecucion"
                            Object ob = (Object)entity;
                            ProyectoResult proyecto = ((Contract.ProyectoGeneralCompose)ob).proyecto;
                            if ((proyecto.OldIdEstado != (int)EstadoEnum.En_Ejecucion) && (proyecto.IdEstado == (int)EstadoEnum.En_Ejecucion))
                            {
                                UIHelper.ShowAlert("Se generó una copia histórica del Proyecto debido al nuevo Estado Financiero del mismo ('En Ejecución').", this.Page);
                                //return;
                            }
                        }
                        //FinMatias 20170201- Ticket #REQ571729
                    }


                ////FinMatias 20140424 - Tarea 137
                //if (CrudAction == CrudActionEnum.Update)
                //{
                //    if (SingletonsBusiness.COUNT_CHANGES > 0)
                //        UIHelper.ShowAlert("Modificacion realizada con éxito", this.Page);
                //    else
                //        UIHelper.ShowAlert("No se realizaron cambios", this.Page);
                //}

                SingletonsBusiness.COUNT_CHANGES = 0;
            }
            catch (Exception exception)
            {
                if (aux != null && aux != string.Empty) Entity = EntityService.Deserialize(aux);
                SingletonsBusiness.COUNT_CHANGES = 0;
                throw exception;
            }
        }
        protected override void Delete()
        {
            string aux = null;
            try
            {
                if (EntityService.Behaviour.EntityIsSerializable) aux = EntityService.Serialize(Entity);
                EntityService.Delete(Entity, this.ContextUser);
            }
            catch (Exception exception)
            {
                if (aux != null && aux != string.Empty) Entity = EntityService.Deserialize(aux);
                throw exception;
            }
        }
        protected override void ShowEdit()
        {
            webControlEdit.Entity = Entity;
            webControlEdit.Clear();
            webControlEdit.SetValue();
        }
        protected override void ShowView()
        {
            webControlEdit.Entity = Entity;
            webControlEdit.Clear();
            webControlEdit.SetValue();
        }
        protected override void DisableEdit()
        {
            if (webControlEditionButtons != null)
            {
                webControlEditionButtons.EnableCancel = true;
                webControlEditionButtons.EnableDelete = false;
                webControlEditionButtons.EnableAplicate = false;
                webControlEditionButtons.EnableSave = false;
                webControlEditionButtons.EnableSaveAndNew = false;
            }
        }
        protected override void HideEdit()
        {
            SetParameter(PagePrevious, PARAMETER_ACTION, Command.RELOAD);
            if (pagePrevious == null)
                Response.Redirect("~/Default.aspx", false);
            else
                Response.Redirect(PagePrevious, false);
        }
        protected override void ReloadFilter()
        {
        }
        protected override void RefreshList()
        {
        }
        #endregion
    }
}
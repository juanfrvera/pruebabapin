using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Service;
using nc=Contract;
using Contract;
using AjaxControlToolkit;
using Application.Controls;

namespace UI.Web
{
    public partial class AdministracionCalidadPriorizacionPageEdit : PageEditTabPanel<nc.ProyectoCalidadCompose, nc.ProyectoFilter, nc.ProyectoResult, int>
    {	
		#region Override
        
       
        protected override void _SetParameters()
        {
            PathListPage = "AdministracionCalidadPageList.aspx";
            EditFilter = "ProyectoCalidadFilter";
            base._SetParameters();
        }
		protected override void _Load()
        {
            webControlEdit = this.editAdministracionCalidad;
            webControlConfirm = this.confirmarAccion;
            webControlEditionButtons = this.editButtons;
            webControlPaggingInPage = this.paggingInPage;
            webControlHead = this.proyectoCalidadHead as WebControlHead<nc.ProyectoResult>;
            base._Load();
            ProyectoCalidadFilter pcf = GetGeneralParameter(EditFilter) as ProyectoCalidadFilter;
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.upHeader.Update();
            ProyectoCalidadFilter pcf = GetGeneralParameter(EditFilter) as ProyectoCalidadFilter;
        }
        protected ProyectoCalidadComposeService Service
		{
            get { return ProyectoCalidadComposeService.Current; }
		}
        protected override IEntityService<nc.ProyectoCalidadCompose, nc.ProyectoFilter, nc.ProyectoResult, int> EntityService
		{
            get { return ProyectoCalidadComposeService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
        protected override void CommandOthers()
        {
            string pageChange = "";
            switch (CommandName)
            {
                case Command.CONFIRM_CHANGE_PAGE:
                    if (PageBehaviour.ConfirmOnPageChange)
                    {
                        webControlEdit.Entity = Entity;
                        webControlEdit.GetValue();
                        if (TabCommandName == Command.EDIT && !EntityService.Equals(Entity, EntityOld) && webControlConfirm != null)
                        {
                            webControlConfirm.SetTitulo(SolutionContext.Current.TextManager.Translate("MSG_CONFIRMCHANGE_TITLE"));
                            webControlConfirm.SetMensaje(SolutionContext.Current.TextManager.Translate("MSG_CONFIRMCHANGE"));
                            webControlConfirm.CommandName = Command.CHANGE_PAGE;
                            webControlConfirm.CommandValue = (string)CommandValue;
                            webControlConfirm.Show();
                            return;
                        }
                        else
                        {
                            int id = EntityService.GetId(Entity);
                            pageChange = (string)CommandValue;
                            SetParameter(pageChange, PARAMETER_ACTION, TabCommandName);
                            SetParameter(pageChange, PARAMETER_VALUE, id.ToString());
                            Response.Redirect(pageChange, false);
                        }
                    }
                    else
                    {
                        int id = EntityService.GetId(Entity);
                        pageChange = (string)CommandValue;
                        SetParameter(pageChange, PARAMETER_ACTION, TabCommandName);
                        SetParameter(pageChange, PARAMETER_VALUE, id.ToString());
                        Response.Redirect(pageChange, false);
                    }
                    break;
                case Command.CHANGE_PAGE:

                    int Eid = EntityService.GetId(Entity);
                    pageChange = (string)CommandValue;
                    SetParameter(pageChange, PARAMETER_ACTION, TabCommandName);
                    SetParameter(pageChange, PARAMETER_VALUE, Eid.ToString());
                    Response.Redirect(pageChange, false);
                    break;

                default:
                    break;
            }
        }
        protected override void ShowList()
        {
            base.ShowList();
            Response.Redirect(PathListPage, false);
        }
        protected override ProyectoResult GetHeadResult()
        {
            return Entity.Proyecto;
        }
        #region Pagination
        protected ProyectoCalidadFilter filterPagination;
        protected virtual ProyectoCalidadFilter FilterPagination
        {
            get
            {
                if (filterPagination == null)
                {
                    object obj = ViewState["filterPagination"];
                    if (obj != null)
                    {
                        filterPagination = obj as ProyectoCalidadFilter;
                    }
                    else if (filterPagination == null)
                    {
                        filterPagination = GetParameter<ProyectoCalidadFilter>("filterPagination");
                        if (filterPagination == null) filterPagination = new ProyectoCalidadFilter();
                    }
                }
                return filterPagination;
            }
            set
            {
                filterPagination = value;
                ViewState["filterPagination"] = value;
            }
        }
        protected override void _SetFilter()
        {
            if (EditFilter != string.Empty)
            {
                FilterPagination = GetGeneralParameter(EditFilter) as ProyectoCalidadFilter;
                if (FilterPagination != null && webControlPaggingInPage != null)
                {
                    webControlPaggingInPage.Pagging = FilterPagination.Paged;
                    webControlPaggingInPage.LoadPagging();
                }
            }
        }
        protected override void RefreshPage()
        {
            FilterPagination.Paged = this.webControlPaggingInPage.GetPagging();
        }
        protected override void RefreshEntity()
        {
            SetGeneralParameter(EditFilter, FilterPagination);
            ProyectoCalidad proyectoCalidad = ProyectoCalidadService.Current.FirstOrDefaultUsingResult(FilterPagination);
            Entity = EntityService.GetById(proyectoCalidad.IdProyecto);
        }
        #endregion
		#endregion
        
	}
}
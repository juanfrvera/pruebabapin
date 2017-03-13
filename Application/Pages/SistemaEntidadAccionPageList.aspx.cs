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
	public partial class SistemaEntidadAccionPageList : PageList<nc.SistemaEntidadAccion ,nc.SistemaEntidadAccionFilter, nc.SistemaEntidadAccionResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            SortExpression = "Nombre";
        }	
		protected override void _Load()
        {
            webControlList = this.lstSistemaEntidadAccion;
            webControlFilter = this.ftSistemaEntidadAccion;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "SistemaEntidadAccionPageEdit.aspx";            
            base._Load();
        }
		protected SistemaEntidadAccionService Service
		{
			get { return SistemaEntidadAccionService.Current; }
		}
		protected override IEntityService<nc.SistemaEntidadAccion, nc.SistemaEntidadAccionFilter, nc.SistemaEntidadAccionResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.SistemaEntidadAccion ,nc.SistemaEntidadAccionFilter,SistemaEntidadAccionResult, int> ViewService
        {
            get { return Service; }
        }
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		protected void btNew_OnClick(object sender, EventArgs e)
        {
            ControlCommand(Command.ADD_NEW);
        }
	}
}

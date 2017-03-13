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
	public partial class SistemaAccionPageList : PageList<nc.SistemaAccion ,nc.SistemaAccionFilter, nc.SistemaAccionResult, int>
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
            webControlList = this.lstSistemaAccion;
            webControlFilter = this.ftSistemaAccion;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "SistemaAccionPageEdit.aspx";            
            base._Load();
        }
		protected SistemaAccionService Service
		{
			get { return SistemaAccionService.Current; }
		}
		protected override IEntityService<nc.SistemaAccion, nc.SistemaAccionFilter, nc.SistemaAccionResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.SistemaAccion ,nc.SistemaAccionFilter,SistemaAccionResult, int> ViewService
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

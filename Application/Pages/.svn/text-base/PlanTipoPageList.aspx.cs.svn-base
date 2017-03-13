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
	public partial class PlanTipoPageList : PageList<nc.PlanTipo ,nc.PlanTipoFilter, nc.PlanTipoResult, int>
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
            webControlList = this.lstPlanTipo;
            webControlFilter = this.ftPlanTipo;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "PlanTipoPageEdit.aspx";            
            base._Load();
        }
		protected PlanTipoService Service
		{
			get { return PlanTipoService.Current; }
		}
		protected override IEntityService<nc.PlanTipo, nc.PlanTipoFilter, nc.PlanTipoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.PlanTipo ,nc.PlanTipoFilter,PlanTipoResult, int> ViewService
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
        protected void btExportExcel_OnClick(object sender, EventArgs e)
        {
            ControlCommand(Command.EXPORT_EXCEL);
        }
	}
}

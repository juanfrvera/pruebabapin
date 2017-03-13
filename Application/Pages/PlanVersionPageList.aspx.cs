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
	public partial class PlanVersionPageList : PageList<nc.PlanVersion ,nc.PlanVersionFilter, nc.PlanVersionResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            OrderBys.Add(new FilterOrderBy("PlanTipo_Nombre"));
            OrderBys.Add(new FilterOrderBy("Orden"));
        }	
		protected override void _Load()
        {
            webControlList = this.lstPlanVersion;
            webControlFilter = this.ftPlanVersion;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "PlanVersionPageEdit.aspx";            
            base._Load();
        }
		protected PlanVersionService Service
		{
			get { return PlanVersionService.Current; }
		}
		protected override IEntityService<nc.PlanVersion, nc.PlanVersionFilter, nc.PlanVersionResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.PlanVersion ,nc.PlanVersionFilter,PlanVersionResult, int> ViewService
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

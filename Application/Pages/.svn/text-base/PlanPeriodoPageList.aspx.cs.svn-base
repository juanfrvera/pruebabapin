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
	public partial class PlanPeriodoPageList : PageList<nc.PlanPeriodo ,nc.PlanPeriodoFilter, nc.PlanPeriodoResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            OrderBys.Add(new FilterOrderBy("PlanTipo_Nombre"));
            OrderBys.Add(new FilterOrderBy("Nombre"));
        }	
		protected override void _Load()
        {
            webControlList = this.lstPlanPeriodo;
            webControlFilter = this.ftPlanPeriodo;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "PlanPeriodoPageEdit.aspx";            
            base._Load();
        }
		protected PlanPeriodoService Service
		{
			get { return PlanPeriodoService.Current; }
		}
		protected override IEntityService<nc.PlanPeriodo, nc.PlanPeriodoFilter, nc.PlanPeriodoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.PlanPeriodo ,nc.PlanPeriodoFilter,PlanPeriodoResult, int> ViewService
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

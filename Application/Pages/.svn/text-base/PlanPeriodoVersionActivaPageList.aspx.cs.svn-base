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
	public partial class PlanPeriodoVersionActivaPageList : PageList<nc.PlanPeriodoVersionActiva ,nc.PlanPeriodoVersionActivaFilter, nc.PlanPeriodoVersionActivaResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            OrderBys.Add(new FilterOrderBy("PlanTipo_Orden"));
            OrderBys.Add(new FilterOrderBy("PlanPeriodo_AnioInicial",true));
            OrderBys.Add(new FilterOrderBy("PlanVersion_Orden"));
        }	
		protected override void _Load()
        {
            webControlList = this.lstPlanPeriodoVersionActiva;
            webControlFilter = this.ftPlanPeriodoVersionActiva;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "PlanPeriodoVersionActivaPageEdit.aspx";            
            base._Load();
        }
		protected PlanPeriodoVersionActivaService Service
		{
			get { return PlanPeriodoVersionActivaService.Current; }
		}
		protected override IEntityService<nc.PlanPeriodoVersionActiva, nc.PlanPeriodoVersionActivaFilter, nc.PlanPeriodoVersionActivaResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.PlanPeriodoVersionActiva ,nc.PlanPeriodoVersionActivaFilter,PlanPeriodoVersionActivaResult, int> ViewService
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

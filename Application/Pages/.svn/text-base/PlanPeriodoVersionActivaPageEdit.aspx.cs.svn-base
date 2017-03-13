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
	public partial class PlanPeriodoVersionActivaPageEdit : PageEdit<nc.PlanPeriodoVersionActiva ,nc.PlanPeriodoVersionActivaFilter, nc.PlanPeriodoVersionActivaResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editPlanPeriodoVersionActiva;
            webControlEditionButtons = this.editButtons;
            PathListPage = "PlanPeriodoVersionActivaPageList.aspx";            
            base._Load();
        }
		protected PlanPeriodoVersionActivaService Service
		{
			get { return PlanPeriodoVersionActivaService.Current; }
		}
		protected override IEntityService<nc.PlanPeriodoVersionActiva, nc.PlanPeriodoVersionActivaFilter, nc.PlanPeriodoVersionActivaResult, int> EntityService
		{
			get { return PlanPeriodoVersionActivaService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

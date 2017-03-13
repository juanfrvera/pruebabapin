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
	public partial class PlanPeriodoPageEdit : PageEdit<nc.PlanPeriodo ,nc.PlanPeriodoFilter, nc.PlanPeriodoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editPlanPeriodo;
            webControlEditionButtons = this.editButtons;
            PathListPage = "PlanPeriodoPageList.aspx";            
            base._Load();
        }
		protected PlanPeriodoService Service
		{
			get { return PlanPeriodoService.Current; }
		}
		protected override IEntityService<nc.PlanPeriodo, nc.PlanPeriodoFilter, nc.PlanPeriodoResult, int> EntityService
		{
			get { return PlanPeriodoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

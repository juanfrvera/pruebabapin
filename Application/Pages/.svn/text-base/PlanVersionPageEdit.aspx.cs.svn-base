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
	public partial class PlanVersionPageEdit : PageEdit<nc.PlanVersion ,nc.PlanVersionFilter, nc.PlanVersionResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editPlanVersion;
            webControlEditionButtons = this.editButtons;
            PathListPage = "PlanVersionPageList.aspx";            
            base._Load();
        }
		protected PlanVersionService Service
		{
			get { return PlanVersionService.Current; }
		}
		protected override IEntityService<nc.PlanVersion, nc.PlanVersionFilter, nc.PlanVersionResult, int> EntityService
		{
			get { return PlanVersionService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

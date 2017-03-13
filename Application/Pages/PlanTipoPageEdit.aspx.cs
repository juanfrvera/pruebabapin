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
	public partial class PlanTipoPageEdit : PageEdit<nc.PlanTipo ,nc.PlanTipoFilter, nc.PlanTipoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editPlanTipo;
            webControlEditionButtons = this.editButtons;
            PathListPage = "PlanTipoPageList.aspx";            
            base._Load();
        }
		protected PlanTipoService Service
		{
			get { return PlanTipoService.Current; }
		}
		protected override IEntityService<nc.PlanTipo, nc.PlanTipoFilter, nc.PlanTipoResult, int> EntityService
		{
			get { return PlanTipoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

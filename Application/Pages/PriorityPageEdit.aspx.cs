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
	public partial class PriorityPageEdit : PageEdit<nc.Priority ,nc.PriorityFilter, nc.PriorityResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editPriority;
            webControlEditionButtons = this.editButtons;
            PathListPage = "PriorityPageList.aspx";            
            base._Load();
        }
		protected PriorityService Service
		{
			get { return PriorityService.Current; }
		}
		protected override IEntityService<nc.Priority, nc.PriorityFilter, nc.PriorityResult, int> EntityService
		{
			get { return PriorityService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

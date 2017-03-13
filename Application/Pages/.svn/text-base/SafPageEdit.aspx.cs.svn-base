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
	public partial class SafPageEdit : PageEdit<nc.Saf ,nc.SafFilter, nc.SafResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editSaf;
            webControlEditionButtons = this.editButtons;
            PathListPage = "SafPageList.aspx";            
            base._Load();
        }
		protected SafService Service
		{
			get { return SafService.Current; }
		}
		protected override IEntityService<nc.Saf, nc.SafFilter, nc.SafResult, int> EntityService
		{
			get { return SafService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

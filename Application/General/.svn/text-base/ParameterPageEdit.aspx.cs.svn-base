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
	public partial class ParameterPageEdit : PageEdit<nc.Parameter ,nc.ParameterFilter, nc.ParameterResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editParameter;
            webControlEditionButtons = this.editButtons;
            PathListPage = "ParameterPageList.aspx";            
            base._Load();
        }
		protected ParameterService Service
		{
			get { return ParameterService.Current; }
		}
		protected override IEntityService<nc.Parameter, nc.ParameterFilter, nc.ParameterResult, int> EntityService
		{
			get { return ParameterService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

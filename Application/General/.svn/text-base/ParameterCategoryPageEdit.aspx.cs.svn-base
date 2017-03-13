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
	public partial class ParameterCategoryPageEdit : PageEdit<nc.ParameterCategory ,nc.ParameterCategoryFilter, nc.ParameterCategoryResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editParameterCategory;
            webControlEditionButtons = this.editButtons;
            PathListPage = "ParameterCategoryPageList.aspx";            
            base._Load();
        }
		protected ParameterCategoryService Service
		{
			get { return ParameterCategoryService.Current; }
		}
		protected override IEntityService<nc.ParameterCategory, nc.ParameterCategoryFilter, nc.ParameterCategoryResult, int> EntityService
		{
			get { return ParameterCategoryService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

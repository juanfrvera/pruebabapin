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
	public partial class ConfigurationCategoryPageEdit : PageEdit<nc.ConfigurationCategory ,nc.ConfigurationCategoryFilter, nc.ConfigurationCategoryResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editConfigurationCategory;
            webControlEditionButtons = this.editButtons;
            PathListPage = "ConfigurationCategoryPageList.aspx";            
            base._Load();
        }
		protected ConfigurationCategoryService Service
		{
			get { return ConfigurationCategoryService.Current; }
		}
		protected override IEntityService<nc.ConfigurationCategory, nc.ConfigurationCategoryFilter, nc.ConfigurationCategoryResult, int> EntityService
		{
			get { return ConfigurationCategoryService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

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
	public partial class ConfigurationPageEdit : PageEdit<nc.Configuration ,nc.ConfigurationFilter, nc.ConfigurationResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editConfiguration;
            webControlEditionButtons = this.editButtons;
            PathListPage = "ConfigurationPageList.aspx";            
            base._Load();
        }
		protected ConfigurationService Service
		{
			get { return ConfigurationService.Current; }
		}
		protected override IEntityService<nc.Configuration, nc.ConfigurationFilter, nc.ConfigurationResult, int> EntityService
		{
			get { return ConfigurationService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

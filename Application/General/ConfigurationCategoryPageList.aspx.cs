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
	public partial class ConfigurationCategoryPageList : PageList<nc.ConfigurationCategory ,nc.ConfigurationCategoryFilter, nc.ConfigurationCategoryResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            SortExpression = "Nombre";
        }	
		protected override void _Load()
        {
            webControlList = this.lstConfigurationCategory;
            webControlFilter = this.ftConfigurationCategory;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "ConfigurationCategoryPageEdit.aspx";            
            base._Load();
        }
		protected ConfigurationCategoryService Service
		{
			get { return ConfigurationCategoryService.Current; }
		}
		protected override IEntityService<nc.ConfigurationCategory, nc.ConfigurationCategoryFilter, nc.ConfigurationCategoryResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.ConfigurationCategory ,nc.ConfigurationCategoryFilter,ConfigurationCategoryResult, int> ViewService
        {
            get { return Service; }
        }
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		protected void btNew_OnClick(object sender, EventArgs e)
        {
            ControlCommand(Command.ADD_NEW);
        }
	}
}

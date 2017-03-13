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
	public partial class ConfigurationPageList : PageList<nc.Configuration ,nc.ConfigurationFilter, nc.ConfigurationResult, int>
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
            webControlList = this.lstConfiguration;
            webControlFilter = this.ftConfiguration;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "ConfigurationPageEdit.aspx";            
            base._Load();
        }
		protected ConfigurationService Service
		{
			get { return ConfigurationService.Current; }
		}
		protected override IEntityService<nc.Configuration, nc.ConfigurationFilter, nc.ConfigurationResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.Configuration ,nc.ConfigurationFilter,ConfigurationResult, int> ViewService
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

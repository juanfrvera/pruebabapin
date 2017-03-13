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
	public partial class ParameterCategoryPageList : PageList<nc.ParameterCategory ,nc.ParameterCategoryFilter, nc.ParameterCategoryResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            SortExpression = "Name";
        }	
		protected override void _Load()
        {
            webControlList = this.lstParameterCategory;
            webControlFilter = this.ftParameterCategory;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "ParameterCategoryPageEdit.aspx";            
            base._Load();
        }
		protected ParameterCategoryService Service
		{
			get { return ParameterCategoryService.Current; }
		}
		protected override IEntityService<nc.ParameterCategory, nc.ParameterCategoryFilter, nc.ParameterCategoryResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.ParameterCategory ,nc.ParameterCategoryFilter,ParameterCategoryResult, int> ViewService
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

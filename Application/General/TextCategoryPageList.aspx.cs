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
	public partial class TextCategoryPageList : PageList<nc.TextCategory ,nc.TextCategoryFilter, nc.TextCategoryResult, int>
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
            webControlList = this.lstTextCategory;
            webControlFilter = this.ftTextCategory;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "TextCategoryPageEdit.aspx";            
            base._Load();
        }
		protected TextCategoryService Service
		{
			get { return TextCategoryService.Current; }
		}
		protected override IEntityService<nc.TextCategory, nc.TextCategoryFilter, nc.TextCategoryResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.TextCategory ,nc.TextCategoryFilter,TextCategoryResult, int> ViewService
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

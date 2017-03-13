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
	public partial class TextLanguagePageList : PageList<nc.TextLanguage ,nc.TextLanguageFilter, nc.TextLanguageResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            SortExpression = "Language_Name";
        }	
		protected override void _Load()
        {
            webControlList = this.lstTextLanguage;
            webControlFilter = this.ftTextLanguage;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "TextLanguagePageEdit.aspx";            
            base._Load();
        }
		protected TextLanguageService Service
		{
			get { return TextLanguageService.Current; }
		}
		protected override IEntityService<nc.TextLanguage, nc.TextLanguageFilter, nc.TextLanguageResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.TextLanguage ,nc.TextLanguageFilter,TextLanguageResult, int> ViewService
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

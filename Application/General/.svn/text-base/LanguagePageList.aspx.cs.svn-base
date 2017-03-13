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
	public partial class LanguagePageList : PageList<nc.Language ,nc.LanguageFilter, nc.LanguageResult, int>
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
            webControlList = this.lstLanguage;
            webControlFilter = this.ftLanguage;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "LanguagePageEdit.aspx";            
            base._Load();
        }
		protected LanguageService Service
		{
			get { return LanguageService.Current; }
		}
		protected override IEntityService<nc.Language, nc.LanguageFilter, nc.LanguageResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.Language ,nc.LanguageFilter,LanguageResult, int> ViewService
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

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
	public partial class TextLanguagePageEdit : PageEdit<nc.TextLanguage ,nc.TextLanguageFilter, nc.TextLanguageResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editTextLanguage;
            webControlEditionButtons = this.editButtons;
            PathListPage = "TextLanguagePageList.aspx";            
            base._Load();
        }
		protected TextLanguageService Service
		{
			get { return TextLanguageService.Current; }
		}
		protected override IEntityService<nc.TextLanguage, nc.TextLanguageFilter, nc.TextLanguageResult, int> EntityService
		{
			get { return TextLanguageService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

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
	public partial class TextCategoryPageEdit : PageEdit<nc.TextCategory ,nc.TextCategoryFilter, nc.TextCategoryResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editTextCategory;
            webControlEditionButtons = this.editButtons;
            PathListPage = "TextCategoryPageList.aspx";            
            base._Load();
        }
		protected TextCategoryService Service
		{
			get { return TextCategoryService.Current; }
		}
		protected override IEntityService<nc.TextCategory, nc.TextCategoryFilter, nc.TextCategoryResult, int> EntityService
		{
			get { return TextCategoryService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

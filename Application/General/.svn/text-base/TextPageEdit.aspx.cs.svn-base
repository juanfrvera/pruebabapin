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
	public partial class TextPageEdit : PageEdit<nc.Text ,nc.TextFilter, nc.TextResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editText;
            webControlEditionButtons = this.editButtons;
            PathListPage = "TextPageList.aspx";            
            base._Load();
        }
		protected TextService Service
		{
			get { return TextService.Current; }
		}
		protected override IEntityService<nc.Text, nc.TextFilter, nc.TextResult, int> EntityService
		{
			get { return TextService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

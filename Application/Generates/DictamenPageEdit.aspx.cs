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
	public partial class DictamenPageEdit : PageEdit<nc.Dictamen ,nc.DictamenFilter, nc.DictamenResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editDictamen;
            webControlEditionButtons = this.editButtons;
            PathListPage = "DictamenPageList.aspx";            
            base._Load();
        }
		protected DictamenService Service
		{
			get { return DictamenService.Current; }
		}
		protected override IEntityService<nc.Dictamen, nc.DictamenFilter, nc.DictamenResult, int> EntityService
		{
			get { return DictamenService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

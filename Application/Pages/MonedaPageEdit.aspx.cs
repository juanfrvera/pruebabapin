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
	public partial class MonedaPageEdit : PageEdit<nc.Moneda ,nc.MonedaFilter, nc.MonedaResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editMoneda;
            webControlEditionButtons = this.editButtons;
            PathListPage = "MonedaPageList.aspx";            
            base._Load();
        }
		protected MonedaService Service
		{
			get { return MonedaService.Current; }
		}
		protected override IEntityService<nc.Moneda, nc.MonedaFilter, nc.MonedaResult, int> EntityService
		{
			get { return MonedaService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

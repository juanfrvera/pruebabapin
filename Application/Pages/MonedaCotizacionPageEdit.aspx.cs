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
	public partial class MonedaCotizacionPageEdit : PageEdit<nc.MonedaCotizacion ,nc.MonedaCotizacionFilter, nc.MonedaCotizacionResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editMonedaCotizacion;
            webControlEditionButtons = this.editButtons;
            PathListPage = "MonedaCotizacionPageList.aspx";            
            base._Load();
        }
		protected MonedaCotizacionService Service
		{
			get { return MonedaCotizacionService.Current; }
		}
		protected override IEntityService<nc.MonedaCotizacion, nc.MonedaCotizacionFilter, nc.MonedaCotizacionResult, int> EntityService
		{
			get { return MonedaCotizacionService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

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
	public partial class GeoreferenciacionPuntoPageEdit : PageEdit<nc.GeoreferenciacionPunto ,nc.GeoreferenciacionPuntoFilter, nc.GeoreferenciacionPuntoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editGeoreferenciacionPunto;
            webControlEditionButtons = this.editButtons;
            PathListPage = "GeoreferenciacionPuntoPageList.aspx";            
            base._Load();
        }
		protected GeoreferenciacionPuntoService Service
		{
			get { return GeoreferenciacionPuntoService.Current; }
		}
		protected override IEntityService<nc.GeoreferenciacionPunto, nc.GeoreferenciacionPuntoFilter, nc.GeoreferenciacionPuntoResult, int> EntityService
		{
			get { return GeoreferenciacionPuntoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

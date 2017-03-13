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
	public partial class ClasificacionGastoPageEdit : PageEdit<nc.ClasificacionGasto ,nc.ClasificacionGastoFilter, nc.ClasificacionGastoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editClasificacionGasto;
            webControlEditionButtons = this.editButtons;
            PathListPage = "ClasificacionGastoPageList.aspx";            
            base._Load();
        }
		protected ClasificacionGastoService Service
		{
			get { return ClasificacionGastoService.Current; }
		}
		protected override IEntityService<nc.ClasificacionGasto, nc.ClasificacionGastoFilter, nc.ClasificacionGastoResult, int> EntityService
		{
			get { return ClasificacionGastoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

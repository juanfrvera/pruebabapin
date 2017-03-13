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
	public partial class FuenteFinanciamientoPageEdit : PageEdit<nc.FuenteFinanciamiento ,nc.FuenteFinanciamientoFilter, nc.FuenteFinanciamientoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editFuenteFinanciamiento;
            webControlEditionButtons = this.editButtons;
            PathListPage = "FuenteFinanciamientoPageList.aspx";            
            base._Load();
        }
		protected FuenteFinanciamientoService Service
		{
			get { return FuenteFinanciamientoService.Current; }
		}
		protected override IEntityService<nc.FuenteFinanciamiento, nc.FuenteFinanciamientoFilter, nc.FuenteFinanciamientoResult, int> EntityService
		{
			get { return FuenteFinanciamientoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

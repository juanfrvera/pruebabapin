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
	public partial class FuenteFinanciamientoTipoPageEdit : PageEdit<nc.FuenteFinanciamientoTipo ,nc.FuenteFinanciamientoTipoFilter, nc.FuenteFinanciamientoTipoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editFuenteFinanciamientoTipo;
            webControlEditionButtons = this.editButtons;
            PathListPage = "FuenteFinanciamientoTipoPageList.aspx";            
            base._Load();
        }
		protected FuenteFinanciamientoTipoService Service
		{
			get { return FuenteFinanciamientoTipoService.Current; }
		}
		protected override IEntityService<nc.FuenteFinanciamientoTipo, nc.FuenteFinanciamientoTipoFilter, nc.FuenteFinanciamientoTipoResult, int> EntityService
		{
			get { return FuenteFinanciamientoTipoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

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
	public partial class ClasificacionGastoTipoPageEdit : PageEdit<nc.ClasificacionGastoTipo ,nc.ClasificacionGastoTipoFilter, nc.ClasificacionGastoTipoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editClasificacionGastoTipo;
            webControlEditionButtons = this.editButtons;
            PathListPage = "ClasificacionGastoTipoPageList.aspx";            
            base._Load();
        }
		protected ClasificacionGastoTipoService Service
		{
			get { return ClasificacionGastoTipoService.Current; }
		}
		protected override IEntityService<nc.ClasificacionGastoTipo, nc.ClasificacionGastoTipoFilter, nc.ClasificacionGastoTipoResult, int> EntityService
		{
			get { return ClasificacionGastoTipoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

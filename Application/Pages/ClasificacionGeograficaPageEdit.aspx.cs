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
	public partial class ClasificacionGeograficaPageEdit : PageEdit<nc.ClasificacionGeografica ,nc.ClasificacionGeograficaFilter, nc.ClasificacionGeograficaResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editClasificacionGeografica;
            webControlEditionButtons = this.editButtons;
            PathListPage = "ClasificacionGeograficaPageList.aspx";            
            base._Load();
        }
		protected ClasificacionGeograficaService Service
		{
			get { return ClasificacionGeograficaService.Current; }
		}
		protected override IEntityService<nc.ClasificacionGeografica, nc.ClasificacionGeograficaFilter, nc.ClasificacionGeograficaResult, int> EntityService
		{
			get { return ClasificacionGeograficaService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

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
	public partial class ClasificacionPageEdit : PageEdit<nc.Clasificacion ,nc.ClasificacionFilter, nc.ClasificacionResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editClasificacion;
            webControlEditionButtons = this.editButtons;
            PathListPage = "ClasificacionPageList.aspx";            
            base._Load();
        }
		protected ClasificacionService Service
		{
			get { return ClasificacionService.Current; }
		}
		protected override IEntityService<nc.Clasificacion, nc.ClasificacionFilter, nc.ClasificacionResult, int> EntityService
		{
			get { return ClasificacionService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

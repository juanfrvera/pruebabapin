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
	public partial class ClasificacionGeograficaTipoPageEdit : PageEdit<nc.ClasificacionGeograficaTipo ,nc.ClasificacionGeograficaTipoFilter, nc.ClasificacionGeograficaTipoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editClasificacionGeograficaTipo;
            webControlEditionButtons = this.editButtons;
            PathListPage = "ClasificacionGeograficaTipoPageList.aspx";            
            base._Load();
        }
		protected ClasificacionGeograficaTipoService Service
		{
			get { return ClasificacionGeograficaTipoService.Current; }
		}
		protected override IEntityService<nc.ClasificacionGeograficaTipo, nc.ClasificacionGeograficaTipoFilter, nc.ClasificacionGeograficaTipoResult, int> EntityService
		{
			get { return ClasificacionGeograficaTipoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

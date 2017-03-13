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
	public partial class PerfilActividadPageEdit : PageEdit<nc.PerfilActividad ,nc.PerfilActividadFilter, nc.PerfilActividadResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editPerfilActividad;
            webControlEditionButtons = this.editButtons;
            PathListPage = "PerfilActividadPageList.aspx";            
            base._Load();
        }
		protected PerfilActividadService Service
		{
			get { return PerfilActividadService.Current; }
		}
		protected override IEntityService<nc.PerfilActividad, nc.PerfilActividadFilter, nc.PerfilActividadResult, int> EntityService
		{
			get { return PerfilActividadService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

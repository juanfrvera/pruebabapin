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
	public partial class ProyectoCalificacionPageEdit : PageEdit<nc.ProyectoCalificacion ,nc.ProyectoCalificacionFilter, nc.ProyectoCalificacionResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editProyectoCalificacion;
            webControlEditionButtons = this.editButtons;
            PathListPage = "ProyectoPageList.aspx";            
            base._Load();
        }
		protected ProyectoCalificacionService Service
		{
			get { return ProyectoCalificacionService.Current; }
		}
		protected override IEntityService<nc.ProyectoCalificacion, nc.ProyectoCalificacionFilter, nc.ProyectoCalificacionResult, int> EntityService
		{
			get { return ProyectoCalificacionService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

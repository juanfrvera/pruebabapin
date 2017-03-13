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
	public partial class ProyectoGeoreferenciacionPageEdit : PageEdit<nc.ProyectoGeoreferenciacion ,nc.ProyectoGeoreferenciacionFilter, nc.ProyectoGeoreferenciacionResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editProyectoGeoreferenciacion;
            webControlEditionButtons = this.editButtons;
            PathListPage = "ProyectoGeoreferenciacionPageList.aspx";            
            base._Load();
        }
		protected ProyectoGeoreferenciacionService Service
		{
			get { return ProyectoGeoreferenciacionService.Current; }
		}
		protected override IEntityService<nc.ProyectoGeoreferenciacion, nc.ProyectoGeoreferenciacionFilter, nc.ProyectoGeoreferenciacionResult, int> EntityService
		{
			get { return ProyectoGeoreferenciacionService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

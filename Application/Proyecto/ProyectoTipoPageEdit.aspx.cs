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
	public partial class ProyectoTipoPageEdit : PageEdit<nc.ProyectoTipo ,nc.ProyectoTipoFilter, nc.ProyectoTipoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editProyectoTipo;
            webControlEditionButtons = this.editButtons;
            PathListPage = "ProyectoPageList.aspx";           
            base._Load();
        }
		protected ProyectoTipoService Service
		{
			get { return ProyectoTipoService.Current; }
		}
		protected override IEntityService<nc.ProyectoTipo, nc.ProyectoTipoFilter, nc.ProyectoTipoResult, int> EntityService
		{
			get { return ProyectoTipoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

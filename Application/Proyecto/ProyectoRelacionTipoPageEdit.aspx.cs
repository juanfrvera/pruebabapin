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
	public partial class ProyectoRelacionTipoPageEdit : PageEdit<nc.ProyectoRelacionTipo ,nc.ProyectoRelacionTipoFilter, nc.ProyectoRelacionTipoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editProyectoRelacionTipo;
            webControlEditionButtons = this.editButtons;
            PathListPage = "ProyectoPageList.aspx";           
            base._Load();
        }
		protected ProyectoRelacionTipoService Service
		{
			get { return ProyectoRelacionTipoService.Current; }
		}
		protected override IEntityService<nc.ProyectoRelacionTipo, nc.ProyectoRelacionTipoFilter, nc.ProyectoRelacionTipoResult, int> EntityService
		{
			get { return ProyectoRelacionTipoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

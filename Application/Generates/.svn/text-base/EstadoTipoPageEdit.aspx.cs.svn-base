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
	public partial class EstadoTipoPageEdit : PageEdit<nc.EstadoTipo ,nc.EstadoTipoFilter, nc.EstadoTipoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editEstadoTipo;
            webControlEditionButtons = this.editButtons;
            PathListPage = "EstadoTipoPageList.aspx";            
            base._Load();
        }
		protected EstadoTipoService Service
		{
			get { return EstadoTipoService.Current; }
		}
		protected override IEntityService<nc.EstadoTipo, nc.EstadoTipoFilter, nc.EstadoTipoResult, int> EntityService
		{
			get { return EstadoTipoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

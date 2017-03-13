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
	public partial class SistemaEntidadEstadoPageEdit : PageEdit<nc.SistemaEntidadEstado ,nc.SistemaEntidadEstadoFilter, nc.SistemaEntidadEstadoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editSistemaEntidadEstado;
            webControlEditionButtons = this.editButtons;
            PathListPage = "SistemaEntidadEstadoPageList.aspx";            
            base._Load();
        }
		protected SistemaEntidadEstadoService Service
		{
			get { return SistemaEntidadEstadoService.Current; }
		}
		protected override IEntityService<nc.SistemaEntidadEstado, nc.SistemaEntidadEstadoFilter, nc.SistemaEntidadEstadoResult, int> EntityService
		{
			get { return SistemaEntidadEstadoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

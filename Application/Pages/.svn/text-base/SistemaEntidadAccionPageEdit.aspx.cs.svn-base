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
	public partial class SistemaEntidadAccionPageEdit : PageEdit<nc.SistemaEntidadAccion ,nc.SistemaEntidadAccionFilter, nc.SistemaEntidadAccionResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editSistemaEntidadAccion;
            webControlEditionButtons = this.editButtons;
            PathListPage = "SistemaEntidadAccionPageList.aspx";            
            base._Load();
        }
		protected SistemaEntidadAccionService Service
		{
			get { return SistemaEntidadAccionService.Current; }
		}
		protected override IEntityService<nc.SistemaEntidadAccion, nc.SistemaEntidadAccionFilter, nc.SistemaEntidadAccionResult, int> EntityService
		{
			get { return SistemaEntidadAccionService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

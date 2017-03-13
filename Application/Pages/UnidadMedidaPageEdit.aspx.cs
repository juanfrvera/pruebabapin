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
	public partial class UnidadMedidaPageEdit : PageEdit<nc.UnidadMedida ,nc.UnidadMedidaFilter, nc.UnidadMedidaResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editUnidadMedida;
            webControlEditionButtons = this.editButtons;
            PathListPage = "UnidadMedidaPageList.aspx";            
            base._Load();
        }
		protected UnidadMedidaService Service
		{
			get { return UnidadMedidaService.Current; }
		}
		protected override IEntityService<nc.UnidadMedida, nc.UnidadMedidaFilter, nc.UnidadMedidaResult, int> EntityService
		{
			get { return UnidadMedidaService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

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
	public partial class SistemaAccionPageEdit : PageEdit<nc.SistemaAccion ,nc.SistemaAccionFilter, nc.SistemaAccionResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editSistemaAccion;
            webControlEditionButtons = this.editButtons;
            PathListPage = "SistemaAccionPageList.aspx";            
            base._Load();
        }
		protected SistemaAccionService Service
		{
			get { return SistemaAccionService.Current; }
		}
		protected override IEntityService<nc.SistemaAccion, nc.SistemaAccionFilter, nc.SistemaAccionResult, int> EntityService
		{
			get { return SistemaAccionService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

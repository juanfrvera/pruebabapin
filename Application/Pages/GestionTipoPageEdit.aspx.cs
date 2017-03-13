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
	public partial class GestionTipoPageEdit : PageEdit<nc.GestionTipo ,nc.GestionTipoFilter, nc.GestionTipoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editGestionTipo;
            webControlEditionButtons = this.editButtons;
            PathListPage = "GestionTipoPageList.aspx";            
            base._Load();
        }
		protected GestionTipoService Service
		{
			get { return GestionTipoService.Current; }
		}
		protected override IEntityService<nc.GestionTipo, nc.GestionTipoFilter, nc.GestionTipoResult, int> EntityService
		{
			get { return GestionTipoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

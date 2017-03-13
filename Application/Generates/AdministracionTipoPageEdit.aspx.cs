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
	public partial class AdministracionTipoPageEdit : PageEdit<nc.AdministracionTipo ,nc.AdministracionTipoFilter, nc.AdministracionTipoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editAdministracionTipo;
            webControlEditionButtons = this.editButtons;
            PathListPage = "AdministracionTipoPageList.aspx";            
            base._Load();
        }
		protected AdministracionTipoService Service
		{
			get { return AdministracionTipoService.Current; }
		}
		protected override IEntityService<nc.AdministracionTipo, nc.AdministracionTipoFilter, nc.AdministracionTipoResult, int> EntityService
		{
			get { return AdministracionTipoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

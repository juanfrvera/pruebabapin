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
	public partial class PermisoPageEdit : PageEdit<nc.Permiso ,nc.PermisoFilter, nc.PermisoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editPermiso;
            webControlEditionButtons = this.editButtons;
            PathListPage = "PermisoPageList.aspx";            
            base._Load();
        }
		protected PermisoService Service
		{
			get { return PermisoService.Current; }
		}
		protected override IEntityService<nc.Permiso, nc.PermisoFilter, nc.PermisoResult, int> EntityService
		{
			get { return PermisoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

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
	public partial class PerfilTipoPageEdit : PageEdit<nc.PerfilTipo ,nc.PerfilTipoFilter, nc.PerfilTipoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editPerfilTipo;
            webControlEditionButtons = this.editButtons;
            PathListPage = "PerfilTipoPageList.aspx";            
            base._Load();
        }
		protected PerfilTipoService Service
		{
			get { return PerfilTipoService.Current; }
		}
		protected override IEntityService<nc.PerfilTipo, nc.PerfilTipoFilter, nc.PerfilTipoResult, int> EntityService
		{
			get { return PerfilTipoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

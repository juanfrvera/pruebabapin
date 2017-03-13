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
	public partial class UsuarioPageEdit : PageEdit<nc.Usuario ,nc.UsuarioFilter, nc.UsuarioResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editUsuario;
            webControlEditionButtons = this.editButtons;
            PathListPage = "UsuarioPageList.aspx";            
            base._Load();
        }
		protected UsuarioService Service
		{
			get { return UsuarioService.Current; }
		}
		protected override IEntityService<nc.Usuario, nc.UsuarioFilter, nc.UsuarioResult, int> EntityService
		{
			get { return UsuarioService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

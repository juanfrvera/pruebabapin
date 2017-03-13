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
	public partial class PerfilPageEdit : PageEdit<nc.PerfilCompose ,nc.PerfilFilter, nc.PerfilResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editPerfil;
            webControlEditionButtons = this.editButtons;
            PathListPage = "PerfilPageList.aspx";            
            base._Load();
        }
        protected PerfilComposeService Service
		{
            get { return PerfilComposeService.Current; }
		}
        protected override IEntityService<nc.PerfilCompose, nc.PerfilFilter, nc.PerfilResult, int> EntityService
		{
            get { return PerfilComposeService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

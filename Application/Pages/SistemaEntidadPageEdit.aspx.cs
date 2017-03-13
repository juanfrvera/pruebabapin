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
	public partial class SistemaEntidadPageEdit : PageEdit<nc.SistemaEntidadCompose ,nc.SistemaEntidadFilter, nc.SistemaEntidadResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editSistemaEntidad;
            webControlEditionButtons = this.editButtons;
            PathListPage = "SistemaEntidadPageList.aspx";            
            base._Load();
        }
		protected SistemaEntidadComposeService Service
		{
            get { return SistemaEntidadComposeService.Current; }
		}
        protected override IEntityService<nc.SistemaEntidadCompose, nc.SistemaEntidadFilter, nc.SistemaEntidadResult, int> EntityService
		{
            get { return SistemaEntidadComposeService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

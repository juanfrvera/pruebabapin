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
	public partial class EntidadTipoPageEdit : PageEdit<nc.EntidadTipo ,nc.EntidadTipoFilter, nc.EntidadTipoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editEntidadTipo;
            webControlEditionButtons = this.editButtons;
            PathListPage = "EntidadTipoPageList.aspx";            
            base._Load();
        }
		protected EntidadTipoService Service
		{
			get { return EntidadTipoService.Current; }
		}
		protected override IEntityService<nc.EntidadTipo, nc.EntidadTipoFilter, nc.EntidadTipoResult, int> EntityService
		{
			get { return EntidadTipoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

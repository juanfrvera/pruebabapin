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
	public partial class ProcesoTipoPageEdit : PageEdit<nc.ProcesoTipo ,nc.ProcesoTipoFilter, nc.ProcesoTipoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editProcesoTipo;
            webControlEditionButtons = this.editButtons;
            PathListPage = "ProcesoTipoPageList.aspx";            
            base._Load();
        }
		protected ProcesoTipoService Service
		{
			get { return ProcesoTipoService.Current; }
		}
		protected override IEntityService<nc.ProcesoTipo, nc.ProcesoTipoFilter, nc.ProcesoTipoResult, int> EntityService
		{
			get { return ProcesoTipoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

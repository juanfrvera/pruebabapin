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
	public partial class ProcesoPageEdit : PageEdit<nc.Proceso ,nc.ProcesoFilter, nc.ProcesoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editProceso;
            webControlEditionButtons = this.editButtons;
            PathListPage = "ProcesoPageList.aspx";            
            base._Load();
        }
		protected ProcesoService Service
		{
			get { return ProcesoService.Current; }
		}
		protected override IEntityService<nc.Proceso, nc.ProcesoFilter, nc.ProcesoResult, int> EntityService
		{
			get { return ProcesoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

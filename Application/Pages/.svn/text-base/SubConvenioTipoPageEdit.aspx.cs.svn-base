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
	public partial class SubConvenioTipoPageEdit : PageEdit<nc.SubConvenioTipo ,nc.SubConvenioTipoFilter, nc.SubConvenioTipoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editSubConvenioTipo;
            webControlEditionButtons = this.editButtons;
            PathListPage = "SubConvenioTipoPageList.aspx";            
            base._Load();
        }
		protected SubConvenioTipoService Service
		{
			get { return SubConvenioTipoService.Current; }
		}
		protected override IEntityService<nc.SubConvenioTipo, nc.SubConvenioTipoFilter, nc.SubConvenioTipoResult, int> EntityService
		{
			get { return SubConvenioTipoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

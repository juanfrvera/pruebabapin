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
	public partial class OrganismoTipoPageEdit : PageEdit<nc.OrganismoTipo ,nc.OrganismoTipoFilter, nc.OrganismoTipoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editOrganismoTipo;
            webControlEditionButtons = this.editButtons;
            PathListPage = "OrganismoTipoPageList.aspx";            
            base._Load();
        }
		protected OrganismoTipoService Service
		{
			get { return OrganismoTipoService.Current; }
		}
		protected override IEntityService<nc.OrganismoTipo, nc.OrganismoTipoFilter, nc.OrganismoTipoResult, int> EntityService
		{
			get { return OrganismoTipoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

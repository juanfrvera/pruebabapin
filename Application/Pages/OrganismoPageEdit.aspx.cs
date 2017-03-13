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
	public partial class OrganismoPageEdit : PageEdit<nc.Organismo ,nc.OrganismoFilter, nc.OrganismoResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editOrganismo;
            webControlEditionButtons = this.editButtons;
            PathListPage = "OrganismoPageList.aspx";            
            base._Load();
        }
		protected OrganismoService Service
		{
			get { return OrganismoService.Current; }
		}
		protected override IEntityService<nc.Organismo, nc.OrganismoFilter, nc.OrganismoResult, int> EntityService
		{
			get { return OrganismoService.Current; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

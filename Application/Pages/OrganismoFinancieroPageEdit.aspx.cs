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
	public partial class OrganismoFinancieroPageEdit : PageEdit<nc.OrganismoFinanciero ,nc.OrganismoFinancieroFilter, nc.OrganismoFinancieroResult, int>
    {	
		#region Override        
		protected override void _Load()
        {
            webControlEdit = this.editOrganismoFinanciero;
            webControlEditionButtons = this.editButtons;
            PathListPage = "OrganismoFinancieroPageList.aspx";            
            base._Load();
        }
		protected OrganismoFinancieroService Service
		{
			get { return OrganismoFinancieroService.Current; }
		}
		protected override IEntityService<nc.OrganismoFinanciero, nc.OrganismoFinancieroFilter, nc.OrganismoFinancieroResult, int> EntityService
		{
			get { return OrganismoFinancieroService.Current; }
		}
		public override IUserInterfaceMessage MessageDisplay
		{
			get { return Master.FindControl("MessageBarForm") as IUserInterfaceMessage; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		#endregion
	}
}

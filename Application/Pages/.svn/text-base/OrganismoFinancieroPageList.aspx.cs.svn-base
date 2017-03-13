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
	public partial class OrganismoFinancieroPageList : PageList<nc.OrganismoFinanciero ,nc.OrganismoFinancieroFilter, nc.OrganismoFinancieroResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            SortExpression = "Nombre";
        }	
		protected override void _Load()
        {
            webControlList = this.lstOrganismoFinanciero;
            webControlFilter = this.ftOrganismoFinanciero;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "OrganismoFinancieroPageEdit.aspx";            
            base._Load();
        }
		protected OrganismoFinancieroService Service
		{
			get { return OrganismoFinancieroService.Current; }
		}
		protected override IEntityService<nc.OrganismoFinanciero, nc.OrganismoFinancieroFilter, nc.OrganismoFinancieroResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.OrganismoFinanciero ,nc.OrganismoFinancieroFilter,OrganismoFinancieroResult, int> ViewService
        {
            get { return Service; }
        }
		public override IUserInterfaceMessage MessageDisplay
		{
			get { return Master.FindControl("MessageBarForm") as IUserInterfaceMessage; }
		}
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
		protected void btNew_OnClick(object sender, EventArgs e)
        {
            ControlCommand(Command.ADD_NEW);
        }
        protected void btExportExcel_OnClick(object sender, EventArgs e)
        {
            ControlCommand(Command.EXPORT_EXCEL);
        }
	}
}

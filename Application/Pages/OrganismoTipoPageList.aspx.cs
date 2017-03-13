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
	public partial class OrganismoTipoPageList : PageList<nc.OrganismoTipo ,nc.OrganismoTipoFilter, nc.OrganismoTipoResult, int>
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
            webControlList = this.lstOrganismoTipo;
            webControlFilter = this.ftOrganismoTipo;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "OrganismoTipoPageEdit.aspx";            
            base._Load();
        }
		protected OrganismoTipoService Service
		{
			get { return OrganismoTipoService.Current; }
		}
		protected override IEntityService<nc.OrganismoTipo, nc.OrganismoTipoFilter, nc.OrganismoTipoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.OrganismoTipo ,nc.OrganismoTipoFilter,OrganismoTipoResult, int> ViewService
        {
            get { return Service; }
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

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
	public partial class OrganismoPrioridadPageList : PageList<nc.OrganismoPrioridad ,nc.OrganismoPrioridadFilter, nc.OrganismoPrioridadResult, int>
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
            webControlList = this.lstOrganismoPrioridad;
            webControlFilter = this.ftOrganismoPrioridad;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "OrganismoPrioridadPageEdit.aspx";            
            base._Load();
        }
		protected OrganismoPrioridadService Service
		{
			get { return OrganismoPrioridadService.Current; }
		}
		protected override IEntityService<nc.OrganismoPrioridad, nc.OrganismoPrioridadFilter, nc.OrganismoPrioridadResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.OrganismoPrioridad ,nc.OrganismoPrioridadFilter,OrganismoPrioridadResult, int> ViewService
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

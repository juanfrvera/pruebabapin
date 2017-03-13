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
	public partial class GestionTipoPageList : PageList<nc.GestionTipo ,nc.GestionTipoFilter, nc.GestionTipoResult, int>
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
            webControlList = this.lstGestionTipo;
            webControlFilter = this.ftGestionTipo;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "GestionTipoPageEdit.aspx";            
            base._Load();
        }
		protected GestionTipoService Service
		{
			get { return GestionTipoService.Current; }
		}
		protected override IEntityService<nc.GestionTipo, nc.GestionTipoFilter, nc.GestionTipoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.GestionTipo ,nc.GestionTipoFilter,GestionTipoResult, int> ViewService
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

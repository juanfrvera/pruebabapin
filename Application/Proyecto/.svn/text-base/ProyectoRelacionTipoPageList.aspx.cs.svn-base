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
	public partial class ProyectoRelacionTipoPageList : PageList<nc.ProyectoRelacionTipo ,nc.ProyectoRelacionTipoFilter, nc.ProyectoRelacionTipoResult, int>
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
            webControlList = this.lstProyectoRelacionTipo;
            webControlFilter = this.ftProyectoRelacionTipo;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "ProyectoRelacionTipoPageEdit.aspx";            
            base._Load();
        }
		protected ProyectoRelacionTipoService Service
		{
			get { return ProyectoRelacionTipoService.Current; }
		}
		protected override IEntityService<nc.ProyectoRelacionTipo, nc.ProyectoRelacionTipoFilter, nc.ProyectoRelacionTipoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.ProyectoRelacionTipo ,nc.ProyectoRelacionTipoFilter,ProyectoRelacionTipoResult, int> ViewService
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

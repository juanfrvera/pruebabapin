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
	public partial class SistemaEntidadEstadoPageList : PageList<nc.SistemaEntidadEstado ,nc.SistemaEntidadEstadoFilter, nc.SistemaEntidadEstadoResult, int>
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
            webControlList = this.lstSistemaEntidadEstado;
            webControlFilter = this.ftSistemaEntidadEstado;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "SistemaEntidadEstadoPageEdit.aspx";            
            base._Load();
        }
		protected SistemaEntidadEstadoService Service
		{
			get { return SistemaEntidadEstadoService.Current; }
		}
		protected override IEntityService<nc.SistemaEntidadEstado, nc.SistemaEntidadEstadoFilter, nc.SistemaEntidadEstadoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.SistemaEntidadEstado ,nc.SistemaEntidadEstadoFilter,SistemaEntidadEstadoResult, int> ViewService
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

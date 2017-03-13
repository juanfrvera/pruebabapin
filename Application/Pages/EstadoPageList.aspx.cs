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
	public partial class EstadoPageList : PageList<nc.Estado ,nc.EstadoFilter, nc.EstadoResult, int>
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
            webControlList = this.lstEstado;
            webControlFilter = this.ftEstado;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "EstadoPageEdit.aspx";            
            base._Load();
        }
		protected EstadoService Service
		{
			get { return EstadoService.Current; }
		}
		protected override IEntityService<nc.Estado, nc.EstadoFilter, nc.EstadoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.Estado ,nc.EstadoFilter,EstadoResult, int> ViewService
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

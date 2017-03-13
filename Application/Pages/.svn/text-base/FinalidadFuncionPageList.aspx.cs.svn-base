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
	public partial class FinalidadFuncionPageList : PageList<nc.FinalidadFuncion ,nc.FinalidadFuncionFilter, nc.FinalidadFuncionResult, int>
    {
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            OrderBys.Add(new FilterOrderBy("FinalidadFuncionPadre_BreadcrumbCodeOrden"));
            OrderBys.Add(new FilterOrderBy("Codigo"));
        }	
		protected override void _Load()
        {
            webControlList = this.lstFinalidadFuncion;
            webControlFilter = this.ftFinalidadFuncion;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            PathEditPage = "FinalidadFuncionPageEdit.aspx";            
            base._Load();
        }
		protected FinalidadFuncionService Service
		{
			get { return FinalidadFuncionService.Current; }
		}
		protected override IEntityService<nc.FinalidadFuncion, nc.FinalidadFuncionFilter, nc.FinalidadFuncionResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.FinalidadFuncion ,nc.FinalidadFuncionFilter,FinalidadFuncionResult, int> ViewService
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

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
using System.IO;

namespace UI.Web
{    
	public partial class ProyectoSeguimientoPageList : PageList<nc.ProyectoSeguimiento ,nc.ProyectoSeguimientoFilter, nc.ProyectoSeguimientoResult, int>
    {
        protected override void _SetParameters()
        {
            base._SetParameters();
            EditFilter = "ProyectoSeguimientoFilter";
            PathEditPage = "ProyectoSeguimientoPageEdit.aspx";
            SortExpression = "IdProyectoSeguimiento";
        }
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            UIHelper.Load<SistemaCommand>(ddlStoreReport, SistemaCommandService.Current.GetList(new nc.SistemaCommandFilter() { IdsistemaEntidad = (int)SistemaEntidadEnum.Proyecto_Seguimiento , Activo = true }), "Nombre", "IdSistemaCommand", new SistemaCommand() { IdSistemaCommand = 0, Nombre = "Seleccione Comando" });

        }	
		protected override void _Load()
        {
            webControlList = this.lstProyectoSeguimiento;
            webControlFilter = this.ftProyectoSeguimiento;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;                     
            base._Load();
        }
		protected ProyectoSeguimientoService Service
		{
			get { return ProyectoSeguimientoService.Current; }
		}
		protected override IEntityService<nc.ProyectoSeguimiento, nc.ProyectoSeguimientoFilter, nc.ProyectoSeguimientoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.ProyectoSeguimiento ,nc.ProyectoSeguimientoFilter,ProyectoSeguimientoResult, int> ViewService
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
        protected void btStoreReport_OnClick(object sender, EventArgs e)
        {
            int idStoreReport = UIHelper.GetInt(ddlStoreReport);
            if (idStoreReport > 0)
                ControlCommand(Command.SHOW_STORE_REPORT, idStoreReport);
        }
	}
}

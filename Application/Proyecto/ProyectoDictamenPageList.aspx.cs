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
	public partial class ProyectoDictamenPageList : PageList<nc.ProyectoDictamen ,nc.ProyectoDictamenFilter, nc.ProyectoDictamenResult, int>
    {
        protected override void _SetParameters()
        {
            base._SetParameters();
            PathEditPage = "ProyectoDictamenFactibilidadPageEdit.aspx"; 
            EditFilter = "ProyectoDictamenFilter";
            SortExpression = "Numero";
            SortDirection = SortDirection.Descending;
        }
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            UIHelper.Load<SistemaCommand>(ddlStoreReport, SistemaCommandService.Current.GetList(new nc.SistemaCommandFilter() { IdsistemaEntidad = (int)SistemaEntidadEnum.Proyecto_Dictamen, Activo = true }), "Nombre", "IdSistemaCommand", new SistemaCommand() { IdSistemaCommand = 0, Nombre = "Seleccione Comando" });

        }	
		protected override void _Load()
        {
            webControlList = this.lstProyectoDictamen;
            webControlFilter = this.ftProyectoDictamen;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;                       
            base._Load();
        }
		protected ProyectoDictamenService Service
		{
			get { return ProyectoDictamenService.Current; }
		}
		protected override IEntityService<nc.ProyectoDictamen, nc.ProyectoDictamenFilter, nc.ProyectoDictamenResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.ProyectoDictamen ,nc.ProyectoDictamenFilter,ProyectoDictamenResult, int> ViewService
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
        protected override void CommandOthers()
        {
            switch (CommandName)
            {
                case Command.PRINT:
                    Export();
                    break;
                case Command.EXPORT:
                    Export();
                    break;         
            }
        }
        protected void Print()
        {
            SistemaReporte Report = SistemaReporteService.Current.FirstOrDefault(new nc.SistemaReporteFilter() { Codigo = "ProyectoDictamen", Activo = true });
            if (Report != null)
            {
                Int32 IdProyectoDictamen = 0;
                if ( Int32.TryParse ( CommandValue.ToString (), out IdProyectoDictamen ))
                {
                    Filter.IdProyectoDictamen = IdProyectoDictamen;
                    ReportInfo reportInfo = EntityService.GetReport(Report.IdSistemaReporte, Filter);
                    
                    //ReportViewerManager.SaveReportExcel(reportInfo);

                    //ShowDownLoadExport();         
                    SetParameter(PathReportPage, PARAMETER_ACTION, CommandName);
                    SetParameter(PathReportPage, PARAMETER_VALUE, reportInfo);
                    //Response.Redirect(PathReportPage, false);
                    ShowPrintExport();
                }
            }
        }

        protected void Export()
        {
            SistemaReporte Report = SistemaReporteService.Current.FirstOrDefault(new nc.SistemaReporteFilter() { Codigo = "ProyectoDictamen", Activo = true });
            if (Report != null)
            {
                Int32 IdProyectoDictamen = 0;
                if (Int32.TryParse(CommandValue.ToString(), out IdProyectoDictamen))
                {
                    Filter.IdProyectoDictamen = IdProyectoDictamen;
                    ReportInfo reportInfo = EntityService.GetReport(Report.IdSistemaReporte, Filter);

                    ReportViewerManager.SaveReportPDF(reportInfo);
                    ShowDownLoadExport();
                }
            }

        }
	}
}

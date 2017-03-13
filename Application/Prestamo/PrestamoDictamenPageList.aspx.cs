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
	public partial class PrestamoDictamenPageList : PageList<nc.PrestamoDictamen ,nc.PrestamoDictamenFilter, nc.PrestamoDictamenResult, int>
    {

        protected override void _SetParameters()
        {
            base._SetParameters();
            EditFilter = "PrestamoDictamenFilter";
            PathEditPage = "PrestamoDictamenPageEdit.aspx";
            SortExpression = "Expediente";
        }
		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            UIHelper.Load<SistemaCommand>(ddlStoreReport, SistemaCommandService.Current.GetList(new nc.SistemaCommandFilter() { IdsistemaEntidad = (int)SistemaEntidadEnum.Prestamo_Dictamen, Activo = true }), "Nombre", "IdSistemaCommand", new SistemaCommand() { IdSistemaCommand = 0, Nombre = "Seleccione Comando" });
        }	
		protected override void _Load()
        {
            webControlList = this.lstPrestamoDictamen;
            webControlFilter = this.ftPrestamoDictamen;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;                       
            base._Load();
        }
		protected PrestamoDictamenService Service
		{
			get { return PrestamoDictamenService.Current; }
		}
		protected override IEntityService<nc.PrestamoDictamen, nc.PrestamoDictamenFilter, nc.PrestamoDictamenResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.PrestamoDictamen ,nc.PrestamoDictamenFilter,PrestamoDictamenResult, int> ViewService
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

        protected override void GenerateExcel()
        {
            int auxPageSize = Filter.PageSize;
            int auxPageNumber = Filter.PageNumber;
            bool auxGetTotaRowsCount = Filter.GetTotaRowsCount;
            Filter.PageSize = 0;
            Filter.PageNumber = 1;
            List<PrestamoDictamenResult> pdr = PrestamoDictamenService.Current.QueryResultExcel(Filter);
            DataTableMapping mapping = GetDataTableMapping();
            MemoryStream stream = new MemoryStream();
            DataHelper.Write<PrestamoDictamenResult >(stream, pdr, mapping, ReportEnum.Excel);
            HttpContext.Current.Session["OpenXmlStreamInput"] = stream;
            HttpContext.Current.Session["OpenXmlFileContentType"] = "application/vnd.ms-excel";
            HttpContext.Current.Session["OpenXmlFileName"] = mapping.Title + ".xls";
            Filter.PageSize = auxPageSize;
            Filter.PageNumber = auxPageNumber;
            Filter.GetTotaRowsCount = auxGetTotaRowsCount;
            int rows = List.Count();
            Filter.Rows = rows;
            this.webControlPaggingButtons.RefreshPagging(rows);
            SetParameter(FilterKey, Filter);
        }
        protected void btStoreReport_OnClick(object sender, EventArgs e)
        {
            int idStoreReport = UIHelper.GetInt(ddlStoreReport);
            if (idStoreReport > 0)
                ControlCommand(Command.SHOW_STORE_REPORT, idStoreReport);
        }
	}
}

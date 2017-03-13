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
	public partial class PrestamoPageList : PageList<nc.Prestamo ,nc.PrestamoFilter, nc.PrestamoResult, int>
    {
        protected override void _SetParameters()
        {
            base._SetParameters();
            EditFilter = "PrestamoFilter";
            PathEditPage = "PrestamoPageEdit.aspx";
        }

        private void CreateOrderBys()
        {
            OrderBys.Add(new FilterOrderBy("Saf_Jurisdiccion"));
            OrderBys.Add(new FilterOrderBy("Saf_Codigo"));
            OrderBys.Add(new FilterOrderBy("Programa_Codigo"));
            OrderBys.Add(new FilterOrderBy("Numero"));
        }



		protected override void _Initialize()
        {
			base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;
            ucImprimirPrestamo.Attributes.CssStyle.Add("display", "none");
            CreateOrderBys();
        }	
		protected override void _Load()
        {
            webControlList = this.lstPrestamo;
            webControlFilter = this.ftPrestamo;
			//webControlListButtons = this.listButtons;
			webControlPaggingButtons = this.pgButtons;
            ucImprimirPrestamo.ControlCommand += new ControlCommandHandler(ControlCommand);      
            base._Load();
        }
		protected PrestamoService Service
		{
			get { return PrestamoService.Current; }
		}
		protected override IEntityService<nc.Prestamo, nc.PrestamoFilter, nc.PrestamoResult, int> EntityService
		{
			get { return Service; }
		}
		protected override IViewService<nc.Prestamo ,nc.PrestamoFilter,PrestamoResult, int> ViewService
        {
            get { return Service; }
        }
		protected override int ConvertId(object value)
		{
			return  Convert.ToInt32(value.ToString());
		}
        protected void btNew_OnClick(object sender, EventArgs e)
        {
            ControlCommand(Command.ADD_NEW, GetExample());
        }
        PrestamoResult GetExample()
        {
            PrestamoResult example = new PrestamoResult();
            example.IdUsuario = ContextUser.User.IdUsuario;
            example.IdOficina_Usuario = ContextUser.User.Persona_IdOficina;
            return example;
        }
        protected void btExportExcel_OnClick(object sender, EventArgs e)
        {
            ControlCommand(Command.EXPORT_EXCEL);
        }
        protected override void RefreshList()
        {
            bool enableFilterOffice = SolutionContext.Current.ParameterManager.GetBooleanValue("OFFICE_FILTER_ENABLE");
            SetParameter(FilterKey, Filter);
            if (enableFilterOffice && UIContext.Current.ContextUser.User.AccesoTotal == false)
            {
                Filter.IdsOficinaByUsuario = OficinaService.Current.GetIdsOficinaPorUsuario(UIContext.Current.ContextUser.User.IdUsuario);
                List = PrestamoService.Current.GetResultWithOfficePerfil(filter);
            }
            else
            {
                Filter.IdOficina = null;
                Filter.IdsOficinaByUsuario = null;
                List = PrestamoService.Current.GetResult(Filter);
            }
            if (List.TotalRows.HasValue) this.webControlPaggingButtons.RefreshPagging(List.TotalRows.Value);
            webControlList.DataSource = List;
            webControlList.DataBind();
        }

        protected override void CommandOthers()
        {
            switch (CommandName)
            {
                case Command.SHOW_POPUP_PRINT:
                    ShowPrint(CommandValue);
                    break;
                case Command.PRINT:
                    Print();
                    break;
                case Command.EXPORT:
                    Export();
                    break;
                
            }
        }
        protected void Print()
        {
            SistemaReporte Report = SistemaReporteService.Current.FirstOrDefault(new nc.SistemaReporteFilter() { Codigo = "Prestamo", Activo = true });
            if (Report != null)
            {
                PrestamoReportInfo pri = ucImprimirPrestamo.ReportInfo ;
                ReportInfo reportInfo = PrestamoService.Current.GetReport(Report.IdSistemaReporte, pri);
                
                //ReportViewerManager.SaveReportExcel(reportInfo);

                //ShowDownLoadExport();         
                SetParameter(PathReportPage, PARAMETER_ACTION, CommandName);
                SetParameter(PathReportPage, PARAMETER_VALUE, reportInfo);
                //Response.Redirect(PathReportPage, false);
                ShowPrintExport();
            }
        }

        protected void Export()
        {
            SistemaReporte Report = SistemaReporteService.Current.FirstOrDefault(new nc.SistemaReporteFilter() { Codigo = "Prestamo", Activo = true });
            if (Report != null)
            {
                PrestamoReportInfo pri = ucImprimirPrestamo.ReportInfo;
                ReportInfo reportInfo = PrestamoService.Current.GetReport(Report.IdSistemaReporte, pri);
                ReportViewerManager.SaveReportExcel(reportInfo);
                ShowDownLoadExport();
            }
        }

        void ShowPrint(object CommandValue)
        {
            ActualPopupId = "ucImprimirPrestamo";
            ucImprimirPrestamo.Visible = true;
            ucImprimirPrestamo.CommandValue = CommandValue == null ? "" : CommandValue.ToString();
            ucImprimirPrestamo.CommandName = Command.PRINT;
            ucImprimirPrestamo.ShowPopup();
        }





        protected override void RefreshOrder()
        {



            GridViewSortEventArgs e = CommandValue as GridViewSortEventArgs;
            if (e != null)
            {

                OrderBys.Clear();
                CreateOrderBys();

                foreach (FilterOrderBy field in orderBys)
                {
                    if (field.OrderByProperty == e.SortExpression)
                    {
                        orderBys.Remove(field);
                        break;
                    }
                }


                if(SortExpressionForMultipleOrderBy != e.SortExpression)
                {
                    SortDirectionForMultipleOrderBy = System.Web.UI.WebControls.SortDirection.Ascending;
                }
                else
                {
                    if (SortDirectionForMultipleOrderBy == System.Web.UI.WebControls.SortDirection.Ascending)
                        SortDirectionForMultipleOrderBy =  System.Web.UI.WebControls.SortDirection.Descending;
                    else
                        SortDirectionForMultipleOrderBy =  System.Web.UI.WebControls.SortDirection.Ascending;
                }

                SortExpressionForMultipleOrderBy = e.SortExpression;
                OrderBys.Insert(0, new FilterOrderBy(SortExpressionForMultipleOrderBy, SortDirectionForMultipleOrderBy == System.Web.UI.WebControls.SortDirection.Descending));

            }
        }

        protected string SortExpressionForMultipleOrderBy
        {
            get { return (ViewState["SortExpression"] == null ? string.Empty : ViewState["SortExpression"].ToString()); }
            set { ViewState["SortExpression"] = value; }
        }

        protected SortDirection SortDirectionForMultipleOrderBy
        {
            get
            {
                if (ViewState["SortDirection"] == null)
                {
                    ViewState["SortDirection"] = SortDirection.Ascending;
                }
                try
                {
                    return (SortDirection)ViewState["SortDirection"]; ;
                }
                catch (Exception exception)
                {
                    return SortDirection.Ascending;
                }
            }
            set
            {
                ViewState["SortDirection"] = value;
            }
        }


        protected override void ClearSearch()
        {
            webControlFilter.ClearFilter();
            SortExpression = string.Empty;
            SortExpressionForMultipleOrderBy = string.Empty;
            SortDirectionForMultipleOrderBy = System.Web.UI.WebControls.SortDirection.Ascending;
            OrderBys.Clear();
            CreateOrderBys();
        }
	}
}

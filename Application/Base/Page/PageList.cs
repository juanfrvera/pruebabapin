using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using Service;
using System.Linq;
using System.Data.Linq;
using nc = Contract;
using Contract;
using Application.Controls;
using System.IO;
namespace UI.Web
{
    /// <summary>
    /// Summary description for PageList
    /// </summary>
    public abstract class PageList<TEntity, TFilter, TResult, TIdType> : CrudPage<TEntity, TFilter, TResult, TIdType>
        where TEntity : class, new()
        where TFilter : nc.Filter,new()
        where TResult : class,nc.IResult<TIdType>,new()
        where TIdType : IComparable
    {
        #region Properties
        protected virtual string SortExpression
        {
            get { return (ViewState["SortExpression"] == null ? string.Empty : ViewState["SortExpression"].ToString()); }
            set{  ViewState["SortExpression"] = value; }
        }
        protected virtual SortDirection SortDirection
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
        
        protected List<FilterOrderBy> orderBys;
        protected virtual List<FilterOrderBy> OrderBys
        {
            get
            {
                if (orderBys == null)
                {
                    if (ViewState["orderBys"] == null)
                    {
                        orderBys = new List<FilterOrderBy>();
                        ViewState["orderBys"] = orderBys;
                    }
                    else
                    { 
                       orderBys = ViewState["orderBys"] as List<FilterOrderBy>; 
                    }
                }
                return orderBys;
            }
            set
            {
                orderBys = value;
                ViewState["orderBys"] = value;
            }
        }
        public override IUserInterfaceMessage MessageDisplay
        {
            get { return Master.FindControl("MessageBarForm") as IUserInterfaceMessage; }
        }
        #endregion

        #region Controls
        public WebControlPaggingButtons webControlPaggingButtons;
        public WebControl_ReportPopup webControlReportPopup;
        #endregion

        #region Page Methods
        protected override void _Load()
        {
            base._Load();
            if (webControlList != null) webControlList.ControlCommand += new ControlCommandHandler(ControlCommand);
            if (webControlFilter != null) webControlFilter.ControlCommand += new ControlCommandHandler(ControlCommand);
            if (webControlListButtons != null) webControlListButtons.ControlCommand += new ControlCommandHandler(ControlCommand);
            if (webControlPaggingButtons != null) webControlPaggingButtons.ControlCommand += new ControlCommandHandler(ControlCommand);
            if (webControlReportPopup != null) webControlReportPopup.ControlCommand += new ControlCommandHandler(ControlCommand);
        }
        protected override void _Initialize()
        {
            if (PageBehaviour.ReloadAlways)
                CommandReload();

            if (!this.Can(ActionConfig.LIST))
                Response.Redirect("~/Default.aspx", false);

            base._Initialize();
        }        
        #endregion

        protected virtual void Execute(string actionName)
        {
            RefreshFilter();
            Execute(Filter,actionName);            
        }
        public virtual TResult GetSelected(TIdType id)
        {
            return (from o in List where o.ID.Equals(id) select o).FirstOrDefault();
        }
        public virtual int? GetSelectedRowIndex(TIdType id)
        {
            for (int i = 0, count = List.Count; i < count; i++)
                if (List[i].ID.Equals(id)) return i+1;
            return null;
        }
        #region Commands
        protected override void AddNew()
        {
            SetParameter(pathEditPage, PARAMETER_ACTION, Command.ADD_NEW);
            if (CommandValue != null) SetParameter(pathEditPage, PARAMETER_VALUE, CommandValue);
            SetGeneralParameter(EditFilter, Filter);
            Response.Redirect(pathEditPage,false);
        }
        protected override void Edit()
        { 
            TIdType id = ConvertId(ConvertId(CommandValue));
            SetParameter(pathEditPage, PARAMETER_ACTION, Command.EDIT);
            SetParameter(pathEditPage, PARAMETER_VALUE, id.ToString());
            //Esta solucion se acomoda a este proyecto para resolver el tema generico se deberia enviar toda la info ed seleccion desde el control de Grilla 
            Filter.RowIndex = GetSelectedRowIndex(id);
            SetGeneralParameter(EditFilter, Filter);
            Response.Redirect(pathEditPage,false);           
        }
        protected override void View()
        {
            TIdType id = ConvertId(ConvertId(CommandValue));
            SetParameter(pathEditPage, PARAMETER_ACTION, Command.VIEW);
            SetParameter(pathEditPage, PARAMETER_VALUE, id.ToString());
            //Esta solucion se acomoda a este proyecto para resolver el tema generico se deberia enviar toda la info ed seleccion desde el control de Grilla 
            Filter.RowIndex = GetSelectedRowIndex(id);
            SetGeneralParameter(EditFilter, Filter);
            Response.Redirect(pathEditPage, false);
        }
        protected override void Copy()
        {
            TIdType id = ConvertId(ConvertId(CommandValue));
            SetParameter(pathEditPage, PARAMETER_ACTION, Command.COPY);
            SetParameter(pathEditPage, PARAMETER_VALUE, id.ToString());
            //Esta solucion se acomoda a este proyecto para resolver el tema generico se deberia enviar toda la info ed seleccion desde el control de Grilla 
            Filter.RowIndex = GetSelectedRowIndex(id);
            SetGeneralParameter(EditFilter, Filter);
            Response.Redirect(pathEditPage, false);
        }
        protected override void CopyAndSave()
        {
            TIdType id = ConvertId(ConvertId(CommandValue));
            EntityService.CopyAndSave(id, this.ContextUser);
        }
        protected override void Delete()
        {
            TIdType id = ConvertId(ConvertId(CommandValue));
            EntityService.Delete(id, this.ContextUser);
        }
        protected override void ShowEdit()
        {            
        }
        protected override void RefreshOrder()
        {
            GridViewSortEventArgs e = CommandValue as GridViewSortEventArgs;
            if (e != null)
            { 
                //SortExpression = e.SortExpression;
                //SortDirection = SortDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending;
                SortExpression = string.Empty;
                OrderBys.Clear();
                SortDirection = SortDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending;
                OrderBys.Add(new FilterOrderBy(e.SortExpression, SortDirection == SortDirection.Descending));
            }
        }
        protected override void ReloadFilter()
        {              
            //Filter = GetParameter<TFilter>(FilterKey);
            Filter.Paged.SetListPaging();
            webControlFilter.Filter = Filter;
            webControlFilter.LoadFilter();
            webControlPaggingButtons.Pagging = Filter.Paged;
            webControlPaggingButtons.LoadPagging();
            if (Filter.OrderBys.Count == 1)
            {
                SortExpression = Filter.OrderByProperty;
                SortDirection = filter.OrderByDesc ? SortDirection.Descending : SortDirection.Ascending;  
                
            }
            else if (Filter.OrderBys.Count > 1)
            {
                OrderBys = Filter.OrderBys; 
            }                      
        }
        protected override void RefreshFilter()
        {
            Filter = webControlFilter.GetFilter();
            Filter.Paged = this.webControlPaggingButtons.GetPagging();
            if (SortExpression ==string.Empty && OrderBys.Count > 0)
            {
                Filter.OrderBys = OrderBys;
            }
            else
            {
                Filter.OrderByProperty = SortExpression;
                Filter.OrderByDesc = (SortDirection == SortDirection.Descending);
            }
            Filter.GetTotaRowsCount = PageBehaviour.GetTotaRowsCount;
        }
        protected override void Search()
        {
            //webControlFilter.Filter = Filter;
            Filter = webControlFilter.GetFilter();
            this.webControlPaggingButtons.ResetPagging();
            Filter.Paged = this.webControlPaggingButtons.GetPagging();
            if (SortExpression == string.Empty && OrderBys.Count > 0)
            {
                Filter.OrderBys = OrderBys;
            }
            else
            {
                Filter.OrderByProperty = SortExpression;
                Filter.OrderByDesc = (SortDirection == SortDirection.Descending);
            }
            Filter.GetTotaRowsCount = PageBehaviour.GetTotaRowsCount;
        }
        protected override void RefreshList()
        {            
            List = EntityService.GetResult(Filter);
            if (List.TotalRows.HasValue)
            {
                Filter.Rows = List.TotalRows.Value;
                this.webControlPaggingButtons.RefreshPagging(List.TotalRows.Value);
            }
            SetParameter(FilterKey, Filter);
            webControlList.DataSource = List;
            webControlList.DataBind();
        }
        protected override void ClearSearch()
        {            
            webControlFilter.ClearFilter();
            SortExpression = string.Empty;            
        }

        #region Export
        protected override void GenerateExcel()
        {
            //Filter = webControlFilter.GetFilter();
            int auxPageSize =Filter.PageSize;
            int auxPageNumber = Filter.PageNumber;
            bool auxGetTotaRowsCount = Filter.GetTotaRowsCount;
            Filter.PageSize = 0;
            Filter.PageNumber = 1;
            if (SortExpression == string.Empty && OrderBys.Count > 0)
            {
                Filter.OrderBys = OrderBys;
            }
            else
            {
                Filter.OrderByProperty = SortExpression;
                Filter.OrderByDesc = (SortDirection == SortDirection.Descending);
            }
            List = EntityService.GetResult(Filter);            
            DataTableMapping mapping= GetDataTableMapping();
            MemoryStream stream = new MemoryStream();
            DataHelper.Write<TResult>(stream,List, mapping, ReportEnum.Excel);
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
        protected override void GeneratePdf()
        {
            int auxPageSize = Filter.PageSize;
            int auxPageNumber = Filter.PageNumber;
            bool auxGetTotaRowsCount = Filter.GetTotaRowsCount;
            Filter.PageSize = 0;
            Filter.PageNumber = 1;
            Filter.GetTotaRowsCount = false;
            List = EntityService.GetResult(Filter);
            DataTableMapping mapping = GetDataTableMapping();
            MemoryStream stream = new MemoryStream();            
            DataHelper.Write<TResult>(stream, List, mapping, ReportEnum.Pdf);
            HttpContext.Current.Session["OpenXmlStreamInput"] = stream;
            HttpContext.Current.Session["OpenXmlFileContentType"] = "application/pdf";
            HttpContext.Current.Session["OpenXmlFileName"] = mapping.Title + ".pdf";
            Filter.PageSize = auxPageSize;
            Filter.PageNumber = auxPageNumber;
            Filter.GetTotaRowsCount = auxGetTotaRowsCount;
            int rows = List.Count();
            Filter.Rows = rows;
            this.webControlPaggingButtons.RefreshPagging(rows);
            SetParameter(FilterKey, Filter);
        }
        protected override void GenerateStoreReport()
        {
            int idStoreReport;
            if (!int.TryParse(CommandValue.ToString(), out idStoreReport)) return;
            SistemaCommand sistemaCommand = SistemaCommandService.Current.GetById(idStoreReport);
            if (sistemaCommand == null) return;
            DataTable dataTable = EntityService.GetFromStoreProcedure(sistemaCommand.CommandText, Filter);
            
            DataHelper.Validate(dataTable != null, "No se encontro el Procedimiento: {0} en la base de Datos", sistemaCommand.CommandText);
            
            MemoryStream stream = new MemoryStream();
            DataHelper.Write(stream, dataTable, ReportEnum.Excel);
            HttpContext.Current.Session["OpenXmlStreamInput"] = stream;
            HttpContext.Current.Session["OpenXmlFileContentType"] = "application/vnd.ms-excel";
            HttpContext.Current.Session["OpenXmlFileName"] = sistemaCommand.Nombre + ".xls";            
        }        
        protected virtual DataTableMapping GetDataTableMapping()
        {
            return (new TResult().ToMapping());
        }
        #endregion

        protected override void ShowReport()
        {
            int IdReport;
            if(int.TryParse(CommandValue.ToString(),out IdReport))
            {
                ReportInfo reportInfo = EntityService.GetReport(IdReport, Filter);
                SetParameter(PathReportPage, PARAMETER_ACTION,CommandName);
                SetParameter(PathReportPage, PARAMETER_VALUE, reportInfo);
                //Response.Redirect(PathReportPage, false);
                ShowPrintExport();
            }            
        }
        protected override void ShowExcelFromReport()
        {
            int IdReport;
            if (int.TryParse(CommandValue.ToString(), out IdReport))
            {
                ReportInfo reportInfo = EntityService.GetReport(IdReport, Filter);
                ReportViewerManager.SaveReportExcel (reportInfo);
                
            }
        } 
        protected override void Save()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
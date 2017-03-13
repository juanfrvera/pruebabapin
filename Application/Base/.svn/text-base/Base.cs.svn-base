using System;
using System.Web.UI.WebControls;
using UI.Web;

public class Command
{
    #region Constants
    public const string ADD_NEW = "_AddNew";
    public const string COPY = "_Copy";
    public const string EDIT = "_Edit";
    public const string READ = "_Read";
    public const string DELETE = "_Delete";
    public const string DELETES = "_Deletes";
    public const string CANCEL = "_Cancel";
    public const string CANCEL_POPUP = "_CancelPopup";
    public const string APPLY = "_Apply";
    public const string SAVE = "_Save";
    public const string SAVE_AND_NEW = "_SaveAndNew";
    public const string DOWNLOAD = "_Download";
    public const string CLOSE = "_Close";
    public const string COMPLETE = "_Complete";
    public const string VIEW = "_View";
    public const string OK = "_Ok";
    public const string REFUSE = "_Refuse";
    public const string APPROVE = "_Approve";
    public const string REVISE = "_Revise";

    public const string POSTULAR = "_Postular";
    public const string CONFORMAR = "_Conformar";
    public const string ACEPTAR = "_Aceptar";
    public const string OBSERVAR = "_Observar";
    public const string REINICIAR = "_Reiniciar";

    public const string SHOW_POSTULAR = "_ShowPostular";
    public const string SHOW_CONFORMAR = "_ShowConformar";
    public const string SHOW_ACEPTAR = "_ShowAceptar";
    public const string SHOW_OBSERVAR = "_ShowObservar";
    public const string SHOW_REINICIAR = "_ShowReiniciar";
    public const string SHOW_ESTADO_DESICION_HISTORY = "_EstadoDesicionHistory";

    public const string CHANGE_STRUCTURE = "_ChangeStructure";

    public const string SHOW_STATISTICS = "_ShowStatistics";
    public const string VIEW_PRESUPUESTO = "_ViewPresupuesto";

    public const string CREATE_REQUERIMIENTO = "_CreateRequerimiento";
    public const string SHOW_CREATE_REQUERIMIENTO = "_ShowCreateRequerimiento";

    public const string ACCEPT = "_Accept";
    public const string SHOW_ACCEPT = "_ShowAccept";

    public const string SHOW_APPROVE = "_ShowApprove";
    public const string SHOW_REFUSE = "_ShowRefuse";
    public const string SHOW_REVISE = "_ShowRevise";
    public const string SHOW_CANCEL = "_ShowCancel";
    public const string SHOW_ERROR = "_ShowError";

    public const string SHOW_REPORT = "_ShowReport";
    public const string SHOW_EXCEL_REPORT = "ShowExcelReport";
    public const string SHOW_STORE_REPORT = "_ShowStoreReport";

    public const string COPY_AND_SAVE = "_CopyAndSave";
    public const string SHOW_POPUP_COPY = "_ShowPopupCopy";  
    public const string COPY_BY_POPUP = "_CopyByPopup";
    public const string SHOW_POPUP_COPY_AND_SAVE = "_ShowPopupCopyAndSave";
    public const string SHOW_POPUP_PRINT = "_SHOW_POPUP_PRINT";
    public const string SHOW_POPUP_HISTORY_PRINT = "_ShowPopupHistoryPrint";
    public const string SAVE_HISTORY_PRINT = "_SaveHistoryPrint";
    public const string SHOW_HISTORY_PRINT = "_ShowHistoryPrint";
    public const string DELETE_HISTORY_PRINT = "_DeleteHistoryPrint";  
 
    public const string COPY_AND_SAVE_BY_POPUP = "_CopyAndSaveByPopup"; 

    public const string LIST_LOG = "_ListLog";
    public const string VIEW_LOG = "_ViewLog";

    public const string VIEW_FACTURA = "_ViewFactura";
    public const string ACCEPT_FACTURA = "_AcceptFactura";
    public const string SHOW_ACCEPT_FACTURA = "_ShowAcceptFactura";
    public const string REVISE_FACTURA = "_ReviseFactura";
    public const string SHOW_REVISE_FACTURA = "_ShowReviseFactura";

    public const string RELOAD = "_Reload";
    public const string REFRESH = "_Refresh";
    public const string RESET = "_Reset";
    public const string RESET_FILTER = "_ResetFilter";
    public const string RESET_ORDER = "_ResetOrder";

    public const string REFRESH_LAST_ACTIONS = "_RefreshLastActions";
    public const string REFRESH_FACTURAS_AUTORIZAR = "_RefreshFacturasAutorizar";
    public const string REFRESH_FACTURA_LAST_ACTIONS = "_RefreshFacturaLastActions";    
    public const string SORT = "_Sort";
    public const string SEARCH = "_Search";
    public const string CLEAR_SEARCH = "_ClearSearch";
    //public const string SEARCH_CONSULTA = "_SearchConsulta";

    public const string REPORT = "_Report";
    public const string PRINT = "_Print";
    public const string HISTORY_PRINT = "_HistoryPrint"; 
    public const string EXPORT = "_Export";
    public const string EXPORT_PDF = "_ExportPdf";
    public const string EXPORT_EXCEL = "_ExportExcel";

    public const string PAGE_NEXT = "_PageNext";
    public const string PAGE_PREVIUOS = "_PagePrevious";
    public const string PAGE_LAST = "_PageLast";
    public const string PAGE_FIRST = "_PageFirst";
    public const string PAGE_GO = "_PageGo";
    public const string CONFIRM_PAGE_GO = "_ConfirmPageGo";

    public const string SHOW_FILTER = "_ShowFilter";
    public const string HIDE_FILTER = "_HideFilter";
    public const string SHOW_EDIT = "_ShowEdit";
    public const string HIDE_EDIT = "_HideEdit";

    public const string SHOW_LOG = "_ShowLog";
    public const string CLOSE_POPUP = "_ClosePopup";
    public const string SHOW_DETAILS = "_ShowDetails";
    public const string CONFIRM_CHANGE_PAGE = "_ConfirmChangePage";
    public const string CHANGE_PAGE = "_ChangePage";

    public const string HISTORY_PLAN = "_HistoryPlan";

    //public const string GENERATE_HISTORYCOPY = "_GenerateHistoryCopy"; //20170201
    #endregion
}




public delegate void DisplayExceptionDelegate(Exception exception);
public class ControlCommandEventArgs : EventArgs
{
    private string commandName;
    private object value;

    public ControlCommandEventArgs(string commandName, object value)
    {
        this.commandName = commandName;
        this.value = value;
    }
    public string CommandName
    {
        get { return commandName; }
        set { commandName = value; }
    }
    public object Value
    {
        get { return this.value; }
        set { this.value = value; }
    }
}
public delegate void ControlCommandHandler(object sender, ControlCommandEventArgs args);


public interface UIControlBase
{
    event ControlCommandHandler ControlCommand;
}
public interface IControlExport
{
}
//View 
public interface IControlFilter<TFilter> : UIControlBase
{
    TFilter GetFilter();
    void ResetFilter();
}
public interface IControlQuickSearch : UIControlBase
{
    string QuickSearch { get; }
    string ServicePath { get; set; }
    string ServiceMethod { get; set; }
}
public interface IControlOrder : UIControlBase
{
}
public interface IControlPagined : UIControlBase
{
    int PageCurrent { get; set; }
    int PageSize { get; set; }
    int PageCount { get; set; }
    int RowCount { get; set; }

    bool FirstPageEnable { get; set; }
    bool PreviousPageEnable { get; set; }
    bool NextPageEnable { get; set; }
    bool LastPageEnable { get; set; }

}
public interface IControlEdition<TEntity> : UIControlBase
{
    TEntity Entity { get; set; }
    void SetValue();
    void GetValue();
    void Clear();
    void SetEnable(bool enable);
    void SetEnable(bool enable, bool enableDelete);
}
public interface IControlGrid<TIdType> : UIControlBase
{
    object DataSource { get; set; }
    void DataBind();
    TIdType GetSelectedId();
    TIdType[] GetSelectedIds();    
}
public interface IControlConfirm
{
    void SetMensaje(string Mensaje);
    void SetTitulo(string Titulo);
    string GetMensaje();
    string GetTitulo();
    void Show();
    void Hide();
}
//Model 
public interface IEntityContext<T>
{
    T Entity { get; set; }
}


public interface IEditionButtons : IWebControlBase
{
    bool EnableCancel { get; set; }
    bool EnableDelete { get; set; }
    bool EnableAplicate { get; set; }
    bool EnableSave { get; set; }
    bool EnableSaveAndNew { get; set; }

    bool VisibleCancel { get; set; }
    bool VisibleDelete { get; set; }
    bool VisibleAplicate { get; set; }
    bool VisibleSave { get; set; }
    bool VisibleSaveAndNew { get; set; }
}

public interface IListButtons : IWebControlBase
{
    //bool EnableSearch { get; set; }
    bool EnableAddNew { get; set; }
}

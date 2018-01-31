using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Service;
using nc = Contract;
using Contract;
using AjaxControlToolkit;
using Application.Controls;
using System.Collections;
using System.Data; //Matias - Tarea 133 - example google-charts
using System.Text; //Matias - Tarea 133 - example google-charts
using System.Web.Script.Serialization; //Matias - Tarea 133


namespace UI.Web
{
    public partial class ProyectoPageList : PageList<nc.Proyecto, nc.ProyectoFilter, nc.ProyectoResult, int>
    {

        #region Override
        protected override void _SetParameters()
        {
            base._SetParameters();
            EditFilter = "ProyectoFilter";
            PathEditPage = "ProyectoPageEdit.aspx";


        }
        protected override void _Initialize()
        {
            base._Initialize();
            bool canCreate = this.Can(ActionConfig.CREATE);
            btNew.Visible = canCreate;

            UIHelper.Load<SistemaReporte>(ddlReport, SistemaReporteService.Current.GetList(new SistemaReporteFilter() { IdSistemaEntidad = (int)SistemaEntidadEnum.Proyecto, Activo = true, EsListado = true }), "Nombre", "IdSistemaReporte", new SistemaReporte() { IdSistemaReporte = 0, Nombre = "Seleccione Reporte" });
            UIHelper.Load<SistemaCommand>(ddlStoreReport, SistemaCommandService.Current.GetList(new nc.SistemaCommandFilter() { IdsistemaEntidad = (int)SistemaEntidadEnum.Proyecto, Activo = true }), "Nombre", "IdSistemaCommand", new SistemaCommand() { IdSistemaCommand = 0, Nombre = "Seleccione Listado" });
            CreateOrderBys();
            ucConfirm.Attributes.CssStyle.Add("display", "none");
            ucProjectHistoricoReporte.Attributes.CssStyle.Add("display", "none");
            ucImprimirProyecto.Attributes.CssStyle.Add("display", "none");
            ucVerReporte.Attributes.CssStyle.Add("display", "none");
            ucCopy.Attributes.CssStyle.Add("display", "none");
        }
        protected override void _Load()
        {
            webControlList = this.lstProyecto;
            webControlFilter = this.ftProyecto;
            //webControlListButtons = this.listButtons;
            webControlPaggingButtons = this.pgButtons;
            ucCopy.ControlCommand += new ControlCommandHandler(ControlCommand);
            ucVerReporte.ControlCommand += new ControlCommandHandler(ControlCommand);
            ucImprimirProyecto.ControlCommand += new ControlCommandHandler(ControlCommand);
            ucProjectHistoricoReporte.ControlCommand += new ControlCommandHandler(ControlCommand);
            ucConfirm.ControlCommand += new ControlCommandHandler(ControlCommand);
            base._Load();
        }
        protected override void Search()
        {
            base.Search();
            SetearUsuarioLogueado();
            Filter.reportFilter = ucVerReporte.Filtro;
        }
        private void SetearUsuarioLogueado()
        {
            bool enableFilterOffice = SolutionContext.Current.ParameterManager.GetBooleanValue("OFFICE_FILTER_ENABLE");

            if (enableFilterOffice && UIContext.Current.ContextUser.User.AccesoTotal == false)
            {
                Filter.IdsOficinaByUsuario = OficinaService.Current.GetIdsOficinaPorUsuario(UIContext.Current.ContextUser.User.IdUsuario);
                Filter.IdsOficinaPropiaByUsuario = (from o in UIContext.Current.ContextUser.PerfilesPorOficina select o.IdOficina).ToList();
            }
            else
            {
                Filter.IdsOficinaByUsuario = null;
            }

        }
        protected ProyectoService Service
        {
            get { return ProyectoService.Current; }
        }
        protected override IEntityService<nc.Proyecto, nc.ProyectoFilter, nc.ProyectoResult, int> EntityService
        {
            get { return Service; }
        }
        protected override IViewService<nc.Proyecto, nc.ProyectoFilter, ProyectoResult, int> ViewService
        {
            get { return Service; }
        }
        protected override int ConvertId(object value)
        {
            return Convert.ToInt32(value.ToString());
        }
        protected override void RefreshList()
        {
            bool enableFilterOffice = SolutionContext.Current.ParameterManager.GetBooleanValue("OFFICE_FILTER_ENABLE");
            SetParameter(FilterKey, Filter);
            bool proyectoPeriodoStress = SolutionContext.Current.Filtrar_Busqueda_Proyecto_Periodo_Stress;
            if (proyectoPeriodoStress)
            {
                Filter.IdsOficinaByUsuario = OficinaService.Current.GetIdsOficinaPorUsuario(UIContext.Current.ContextUser.User.IdUsuario);
                Filter.IdsOficinaPropiaByUsuario = (from o in UIContext.Current.ContextUser.PerfilesPorOficina select o.IdOficina).ToList();
                List = ProyectoService.Current.GetResultSP(Filter);
            }
            else 
                if (enableFilterOffice && UIContext.Current.ContextUser.User.AccesoTotal == false)
                {
                    Filter.IdsOficinaByUsuario = OficinaService.Current.GetIdsOficinaPorUsuario(UIContext.Current.ContextUser.User.IdUsuario);
                    Filter.IdsOficinaPropiaByUsuario = (from o in UIContext.Current.ContextUser.PerfilesPorOficina select o.IdOficina).ToList();
                    List = ProyectoService.Current.GetResultWithOfficePerfil(Filter);
                }
                else
                {
                    // Filter.IdOficina = null;
                    Filter.IdsOficinaByUsuario = null;
                    Filter.IdsOficinaPropiaByUsuario = null;
                    List = ProyectoService.Current.GetResult(Filter);
                }
            if (List.TotalRows.HasValue) this.webControlPaggingButtons.RefreshPagging(List.TotalRows.Value);
            webControlList.DataSource = List;
            webControlList.DataBind();
        }

        protected override void GenerateExcel()
        {

            SetearUsuarioLogueado();
            base.GenerateExcel();

        }

        protected override void CommandOthers()
        {
            Hashtable args = new Hashtable();
            switch (CommandName)
            {
                case Command.SHOW_POPUP_COPY_AND_SAVE:
                    ShowCopyAndSave(CommandValue);
                    break;
                case Command.SHOW_POPUP_PRINT:
                    ShowPrint(CommandValue);
                    break;
                case Command.SHOW_POPUP_HISTORY_PRINT:
                    ShowHistoryPrint(CommandValue);
                    break;
                case Command.HISTORY_PLAN:
                    Execute(ActionConfig.HISTORY_PLAN);
                    break;
                case Command.PRINT:
                    Print();
                    break;
                case Command.EXPORT:
                    Export();
                    break;
                case Command.SAVE_HISTORY_PRINT:
                    SaveHistoryPrint();
                    //ucProjectHistoricoReporte.HidePopup();
                    //ucProjectHistoricoReporte.Visible = false;
                    break;
                case Command.SHOW_HISTORY_PRINT:
                    ShowHistoryPrint();
                    break;
                case Command.DELETE_HISTORY_PRINT:
                    DeleteHistoryPrint();
                    break;
                case Command.SHOW_POSTULAR:
                    ShowConfirm(Translate("Postular"), Command.POSTULAR, CommandValue);
                    break;
                case Command.SHOW_CONFORMAR:
                    ShowConfirm(Translate("Conformar"), Command.CONFORMAR, CommandValue);
                    break;
                case Command.SHOW_ACEPTAR:
                    ShowConfirm(Translate("Aceptar"), Command.ACEPTAR, CommandValue);
                    break;
                case Command.SHOW_OBSERVAR:
                    ShowConfirm(Translate("Observar"), Command.OBSERVAR, CommandValue);
                    break;
                case Command.SHOW_REINICIAR:
                    ShowConfirm(Translate("Reiniciar"), Command.REINICIAR, CommandValue);
                    break;
                case Command.SHOW_ESTADO_DESICION_HISTORY:
                    ShowEstadoDesicionHistory(CommandValue);
                    break;
                case Command.POSTULAR:
                    args.Add("Observacion", ucConfirm.Observaciones);
                    Execute(GetSelected(ConvertId(CommandValue)), ActionConfig.POSTULAR, false, args);
                    HideConfirm();
                    RefreshList();
                    break;
                case Command.CONFORMAR:
                    args.Add("Observacion", ucConfirm.Observaciones);
                    Execute(GetSelected(ConvertId(CommandValue)), ActionConfig.CONFORMAR, false, args);
                    HideConfirm();
                    RefreshList();
                    break;
                case Command.ACEPTAR:
                    args.Add("Observacion", ucConfirm.Observaciones);
                    Execute(GetSelected(ConvertId(CommandValue)), ActionConfig.ACEPTAR, false, args);
                    HideConfirm();
                    RefreshList();
                    break;
                case Command.OBSERVAR:
                    args.Add("Observacion", ucConfirm.Observaciones);
                    Execute(GetSelected(ConvertId(CommandValue)), ActionConfig.OBSERVAR, false, args);
                    HideConfirm();
                    RefreshList();
                    break;
                case Command.REINICIAR:
                    args.Add("Observacion", ucConfirm.Observaciones);
                    Execute(GetSelected(ConvertId(CommandValue)), ActionConfig.REINICIAR, false, args);
                    HideConfirm();
                    RefreshList();
                    break;
            }
        }
        #endregion

        #region Events
        protected void btNew_OnClick(object sender, EventArgs e)
        {
            ControlCommand(Command.ADD_NEW, GetExample());
        }
        protected void btExportExcel_OnClick(object sender, EventArgs e)
        {
            ControlCommand(Command.EXPORT_EXCEL);
        }
        //Matias 20140512 - Tarea 133
        protected void btVisualizarGraficos_OnClick(object sender, EventArgs e)
        {

            if (List.Count > 0)
            {
                ListPaged<ProyectoResult> ListaProyectos = ProyectoService.Current.GetResultGraficos(Filter);
                ListPaged<ProyectoResult> ListaProyectosLocalizaciones = ProyectoService.Current.GetResultGraficosLocalizaciones(Filter);

                ListPaged<ProyectoResult> ListaProyectosPrestamos = ProyectoService.Current.GetResultGraficosPrestamos(Filter);
                JavaScriptSerializer jss = new JavaScriptSerializer();
                List<DataItem> dataList = new List<DataItem>();

                Session.Add("CantidadProyectos", ListaProyectos.Count);
                Session.Add("Filtros", Filter.VisualizacionToString());
                Session.Add("FiltrosSinFormato", Filter.VisualizacionSinFormatoToString()); //Matias - levanta el filtro sin tags html
                ListPaged<ProyectoResult> ListaProyectosLocalizacionesPartido = ProyectoService.Current.GetResultGraficosLocalizacionesPartido(Filter);


                //Grafico 1 -- Partido
                //Matias 20141014 - Tarea 158
                ListPaged<ProyectoResult> ListaProyectosProvincia = ProyectoService.Current.GetResultGraficosProvincia(Filter);
                /*
                var proyectosAgrupadosLocalizacionesPartidos =
                from proy in ListaProyectosLocalizacionesPartido
                group proy by proy.Localizacion into grouping
                select new
                {
                    grouping.Key,
                    Cantidad = grouping.Count()
                };

                foreach (var grp in proyectosAgrupadosLocalizacionesPartidos)
                {
                    dataList.Add(new DataItem(grp.Key.ToString(), grp.Cantidad, "", 0));

                }
                Session.Add("Grafico1", jss.Serialize(dataList));
                dataList.Clear();
                 */

                var proyectosAgrupadosProvincia =
                from proy in ListaProyectosProvincia
                group proy by proy.Localizacion into grouping
                select new
                {
                    grouping.Key,
                    Cantidad = grouping.Count()
                };

                foreach (var grp in proyectosAgrupadosProvincia)
                {
                    dataList.Add(new DataItem(grp.Key.ToString(), grp.Cantidad, "", 0));

                }
                Session.Add("Grafico1", jss.Serialize(dataList));
                dataList.Clear();
                //FinMatias 20141014 - Tarea 158

                //Grafico 2 -- localizacion
                var proyectosAgrupadosLocalizaciones =
                from proy in ListaProyectosLocalizaciones
                group proy by proy.Localizacion into grouping
                select new
                {
                    grouping.Key,
                    Cantidad = grouping.Count()
                };

                foreach (var grp in proyectosAgrupadosLocalizaciones)
                {
                    dataList.Add(new DataItem(grp.Key.ToString(), grp.Cantidad, "", 0));

                }
                Session.Add("Grafico2", jss.Serialize(dataList));
                dataList.Clear();

                //Grafico 3 --estado 
                var proyectosAgrupados =
                from proy in ListaProyectos
                group proy by proy.Estado_Nombre into grouping
                select new
                {
                    grouping.Key,
                    Cantidad = grouping.Count()
                };

                foreach (var grp in proyectosAgrupados)
                {
                    dataList.Add(new DataItem(grp.Key.ToString(), grp.Cantidad, "", 0));

                }
                Session.Add("Grafico3", jss.Serialize(dataList));
                dataList.Clear();

                //Grafico 4  -- finalidad - funcion
                proyectosAgrupados =
                from proy in ListaProyectos
                group proy by proy.FinalidadFuncion into grouping
                select new
                {
                    grouping.Key,
                    Cantidad = grouping.Count()
                };

                foreach (var grp in proyectosAgrupados)
                {
                    dataList.Add(new DataItem(grp.Key.ToString(), grp.Cantidad, "", 0));

                }
                Session.Add("Grafico4", jss.Serialize(dataList));
                dataList.Clear();

                //Grafico 5 -- proceso
                proyectosAgrupados =
                from proy in ListaProyectos
                group proy by proy.Proceso into grouping
                select new
                {
                    grouping.Key,
                    Cantidad = grouping.Count()
                };

                foreach (var grp in proyectosAgrupados)
                {
                    dataList.Add(new DataItem(grp.Key.ToString(), grp.Cantidad, "", 0));

                }
                Session.Add("Grafico5", jss.Serialize(dataList));
                dataList.Clear();

                //Grafico 6 -- modalidad de contratacion
                proyectosAgrupados =
                from proy in ListaProyectos
                group proy by proy.ModalidadContratacion into grouping
                select new
                {
                    grouping.Key,
                    Cantidad = grouping.Count()
                };

                foreach (var grp in proyectosAgrupados)
                {
                    dataList.Add(new DataItem(grp.Key.ToString(), grp.Cantidad, "", 0));

                }
                Session.Add("Grafico6", jss.Serialize(dataList));
                dataList.Clear();

                //Grafico 7 -- plan
                proyectosAgrupados =
                from proy in ListaProyectos
                group proy by proy.Plan into grouping
                select new
                {
                    grouping.Key,
                    Cantidad = grouping.Count()
                };

                foreach (var grp in proyectosAgrupados)
                {
                    dataList.Add(new DataItem(grp.Key.ToString(), grp.Cantidad, "", 0));

                }
                Session.Add("Grafico7", jss.Serialize(dataList));
                dataList.Clear();

                //Grafico 8 -- financiacion
                var proyectosAgrupadosPrestamos =
                from proy in ListaProyectosPrestamos
                group proy by proy.Prestamo into grouping
                select new
                {
                    grouping.Key,
                    Cantidad = grouping.Count()
                };

                foreach (var grp in proyectosAgrupadosPrestamos)
                {
                    dataList.Add(new DataItem(grp.Key.ToString(), grp.Cantidad, "", 0));

                }
                Session.Add("Grafico8", jss.Serialize(dataList));
                dataList.Clear();

                //Abre los graficos en una ventana.
                ResponseHelper.Redirect(ResolveUrl("~/Graficos/ProyectoGraficos.aspx"), "_blank", "toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=1330,height=665,top=10,left=10");
            }

        }
        //FinMatias 20140512 - Tarea 133
        protected void btOpenReport_OnClick(object sender, EventArgs e)
        {

            int idReport = UIHelper.GetInt(ddlReport);
            if (idReport > 0)
            {
                ucVerReporte.Filtro.IdReport = idReport;
                ucVerReporte.ShowPopup();
            }
        }
        protected void btStoreReport_OnClick(object sender, EventArgs e)
        {
            int idStoreReport = UIHelper.GetInt(ddlStoreReport);
            if (idStoreReport > 0)
                ControlCommand(Command.SHOW_STORE_REPORT, idStoreReport);
        }
        #endregion

        #region Methods
        ProyectoResult GetExample()
        {
            ProyectoResult example = new ProyectoResult();
            example.IdOficina_Usuario = ContextUser.User.Persona_IdOficina;
            example.IdUsuario = ContextUser.User.IdUsuario;
            return example;
        }
        protected override void CopyAndSave()
        {
            ProyectCopy result = CommandValue as ProyectCopy;
            if (result == null) return;
            ProyectoService.Current.CopyAndSave(result.IdProject, result, ContextUser);
            ucCopy.HidePopup();
        }
        void ShowConfirm(string titulo, string commandName, object CommandValue)
        {
            ActualPopupId = "ucConfirm";
            ucConfirm.Visible = true;
            ucConfirm.Titulo = titulo;
            ucConfirm.CommandValue = CommandValue == null ? "" : CommandValue.ToString();
            ucConfirm.CommandName = commandName;
            ucConfirm.ShowPopup();
        }
        void HideConfirm()
        {
            ucConfirm.HidePopup();
        }
        void ShowCopyAndSave(object CommandValue)
        {
            ProyectoResult proyectoResult = (from o in List where o.ID == ConvertId(CommandValue) select o).FirstOrDefault();
            if (proyectoResult == null) return;
            ActualPopupId = "ucCopy";
            ucCopy.Visible = true;
            ucCopy.Clear();
            ucCopy.Nombre = proyectoResult.ProyectoDenominacion;
            ucCopy.CommandValue = CommandValue == null ? "" : CommandValue.ToString();
            ucCopy.CommandName = Command.COPY_AND_SAVE;
            ucCopy.ShowPopup();
        }
        void ShowPrint(object CommandValue)
        {
            ActualPopupId = "ucImprimirProyecto";
            ucImprimirProyecto.Visible = true;
            ucImprimirProyecto.CommandValue = CommandValue == null ? "" : CommandValue.ToString();
            ucImprimirProyecto.CommandName = Command.PRINT;
            ucImprimirProyecto.ShowPopup();
        }
        void ShowHistoryPrint(object CommandValue)
        {
            if (CommandValue == null) return;
            int id;
            if (int.TryParse(CommandValue.ToString(), out id))
            {
                ActualPopupId = "ucProjectHistoricoReporte";
                ucProjectHistoricoReporte.Visible = true;
                ucProjectHistoricoReporte.Result = GetSelected(id);
                ucProjectHistoricoReporte.CommandValue = CommandValue == null ? "" : CommandValue.ToString();
                ucProjectHistoricoReporte.CommandName = Command.SAVE_HISTORY_PRINT;
                ucProjectHistoricoReporte.ShowPopup();
            }
        }
        void ShowEstadoDesicionHistory(object CommandValue)
        {
            if (CommandValue == null) return;
            int id;
            if (int.TryParse(CommandValue.ToString(), out id))
            {
                ActualPopupId = "ucProjectEstadoDesicionHistorico";
                ucProjectEstadoDesicionHistorico.Visible = true;
                ucProjectEstadoDesicionHistorico.IdProyecto = id;
                ucProjectEstadoDesicionHistorico.CommandValue = CommandValue == null ? "" : CommandValue.ToString();
                ucProjectEstadoDesicionHistorico.ShowPopup();
            }
        }
        protected void Print()
        {
            SistemaReporte Report = SistemaReporteService.Current.FirstOrDefault(new nc.SistemaReporteFilter() { Codigo = "Proyecto", Activo = true });
            if (Report != null)
            {
                Filter.printFilter = ucImprimirProyecto.Filtro;

                ReportInfo reportInfo = EntityService.GetReport(Report.IdSistemaReporte, Filter);
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
            SistemaReporte Report = SistemaReporteService.Current.FirstOrDefault(new nc.SistemaReporteFilter() { Codigo = "Proyecto", Activo = true });
            if (Report != null)
            {
                Filter.printFilter = ucImprimirProyecto.Filtro;

                ReportInfo reportInfo = EntityService.GetReport(Report.IdSistemaReporte, Filter);
                ReportViewerManager.SaveReportExcel(reportInfo);
                ShowDownLoadExport();

            }
        }
        protected void SaveHistoryPrint()
        {
            SistemaReporte Report = SistemaReporteService.Current.FirstOrDefault(new nc.SistemaReporteFilter() { Codigo = "Proyecto", Activo = true });
            if (Report != null)
            {
                Filter.printFilter = new ProyectoPrintFilter();
                Filter.printFilter.IdProyecto = ucProjectHistoricoReporte.Result.IdProyecto;
                Filter.printFilter.SetAll(true);
                EntityService.SaveHistoryReport(Report, ucProjectHistoricoReporte.Info, Filter, ContextUser);
            }
        }
        protected void ShowHistoryPrint()
        {
            int id;
            if (CommandValue == null) return;
            if (!int.TryParse(CommandValue.ToString(), out id)) return;

            ReportInfo reportInfo = EntityService.GetHistoryReport(id);
            if (reportInfo == null) return;

            SetParameter(PathReportPage, PARAMETER_ACTION, Command.PRINT);
            SetParameter(PathReportPage, PARAMETER_VALUE, reportInfo);
            //Response.Redirect(PathReportPage, false);
            ShowPrintExport();
        }
        protected void DeleteHistoryPrint()
        {
            int id;
            if (CommandValue == null) return;
            if (!int.TryParse(CommandValue.ToString(), out id)) return;
            string perfil = UsuarioComposeService.GetPerfilUser(this.User.Identity.Name);

            if (string.Compare(perfil, "admin", true) != 0)
            {
                UIHelper.ShowAlert("No posee autorización para ejecutar esta acción", ucProjectHistoricoReporte.Page);
                return;
            }
            SistemaReporteHistoricoService.Current.Delete(id, ContextUser);
        }
        #endregion


        private void CreateOrderBys()
        {
            OrderBys.Add(new FilterOrderBy("Jurisdiccion_Codigo"));
            OrderBys.Add(new FilterOrderBy("Saf_Codigo"));
            OrderBys.Add(new FilterOrderBy("Programa_Codigo"));
            OrderBys.Add(new FilterOrderBy("SubPrograma_Codigo"));
            OrderBys.Add(new FilterOrderBy("Codigo"));
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


                if (SortExpressionForMultipleOrderBy != e.SortExpression)
                {
                    SortDirectionForMultipleOrderBy = System.Web.UI.WebControls.SortDirection.Ascending;
                }
                else
                {
                    if (SortDirectionForMultipleOrderBy == System.Web.UI.WebControls.SortDirection.Ascending)
                        SortDirectionForMultipleOrderBy = System.Web.UI.WebControls.SortDirection.Descending;
                    else
                        SortDirectionForMultipleOrderBy = System.Web.UI.WebControls.SortDirection.Ascending;
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

    //Matias 20140512 - Tarea 133 - Abrir en nueva ventana
    public class DataItem
    {
        #region Internal Members

        private string _ColumnName = "";
        private double _Value1 = 0;
        private string _Value2 = null;
        private int _Value3 = 0;

        #endregion

        #region Public Properties

        public string ColumnName
        {
            get { return _ColumnName; }
            set { _ColumnName = value; }
        }
        public double Value1
        {
            get { return _Value1; }
            set { _Value1 = value; }
        }
        public string Value2
        {
            get { return _Value2; }
            set { _Value2 = value; }
        }
        public int Value3
        {
            get { return _Value3; }
            set { _Value3 = value; }
        }

        #endregion

        #region Constructors

        public DataItem(string columnName, double value1, string value2, int value3)
        {
            _ColumnName = columnName;
            _Value1 = value1;
            _Value2 = value2;
            _Value3 = value3;
        }

        #endregion
    }
    //FinMatias 20140512 - Tarea 133 - Abrir en nueva ventana
}

//Matias 20140512 - Tarea 133 - Abrir en nueva ventana
public class DataItem
{
    #region Internal Members

    private string _ColumnName = "";
    private double _Value1 = 0;
    private string _Value2 = null;
    private int _Value3 = 0;

    #endregion

    #region Public Properties

    public string ColumnName
    {
        get { return _ColumnName; }
        set { _ColumnName = value; }
    }
    public double Value1
    {
        get { return _Value1; }
        set { _Value1 = value; }
    }
    public string Value2
    {
        get { return _Value2; }
        set { _Value2 = value; }
    }
    public int Value3
    {
        get { return _Value3; }
        set { _Value3 = value; }
    }

    #endregion

    #region Constructors

    public DataItem(string columnName, double value1, string value2, int value3)
    {
        _ColumnName = columnName;
        _Value1 = value1;
        _Value2 = value2;
        _Value3 = value3;
    }

    #endregion
}

//Matias - Abrir en nueva ventana
public static class ResponseHelper
{
    public static void Redirect(string url, string target, string windowFeatures)
    {
        HttpContext context = HttpContext.Current;

        if ((String.IsNullOrEmpty(target) ||
            target.Equals("_self", StringComparison.OrdinalIgnoreCase)) &&
            String.IsNullOrEmpty(windowFeatures))
        {

            context.Response.Redirect(url);
        }
        else
        {
            Page page = (Page)context.Handler;
            if (page == null)
            {
                throw new InvalidOperationException(
                    "Cannot redirect to new window outside Page context.");
            }
            url = page.ResolveClientUrl(url);

            string script;
            if (!String.IsNullOrEmpty(windowFeatures))
            {
                script = @"window.open(""{0}"", ""{1}"", ""{2}"");";
            }
            else
            {
                script = @"window.open(""{0}"", ""{1}"");";
            }

            script = String.Format(script, url, target, windowFeatures);
            ScriptManager.RegisterStartupScript(page,
                typeof(Page),
                "Redirect",
                script,
                true);
        }
    }
}
//FinMatias 20140512 - Tarea 133 - Abrir en nueva ventana
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc = Contract;
using Service;
using Business;
using System.Data;
using System.Collections;
using System.Drawing;
using Core.Utils;

namespace UI.Web
{
    #region GridView
    public class GridViewButtonsTemplate : ITemplate
    {
        public GridViewButtonsTemplate()
        {
        }
        
        void ITemplate.InstantiateIn(System.Web.UI.Control container)
        {
            ImageButton imEdit = new ImageButton();
            imEdit.ID = "imgEdit";
            imEdit.ImageUrl = "../Images/edit.png";
            imEdit.ToolTip = "Editar";
            imEdit.CommandName = Command.EDIT;
            //imEdit.CommandArgument = idRefered;
            imEdit.CausesValidation = false;
            Literal literal = new Literal();
            literal.Text = "&nbsp;";
            container.Controls.Add(literal);
            container.Controls.Add(imEdit);

            ImageButton imDel = new ImageButton();
            imDel.ID = "imgDelete";
            imDel.ImageUrl = "../Images/delete.jpg";
            imDel.ToolTip = "Eliminar";
            imDel.CommandName = Command.DELETE;
            //imEdit.CommandArgument = idRefered;
            imDel.CausesValidation = false;
            imDel.OnClientClick = "return confirm('Está seguro de eliminar?');";
            container.Controls.Add(imDel);
        }
    }
    public class ColumnGenerator : IAutoFieldGenerator
    {
        //private int mode = 0;
        //List<PlanPeriodo> planPeriodosBloqueados = new List<PlanPeriodo>();
        //List<OrganismoTipo> organismoTipoBloqueados = new List<OrganismoTipo>();
        //int? tipoOrganismoProyecto = 0;
        private DataColumnCollection DataColumns;
        private bool ShowEditionButtons;

        public ColumnGenerator(DataColumnCollection dataColumns, bool showEditionButtons)
        {
            this.DataColumns = dataColumns;
            //Matias 20170301 - Ticket #ER682004
            //Esta linea define la visibilidad de los botones edit y delete de cada gasto (la DNIP solicita que esta siempre visible).
            //this.ShowEditionButtons = showEditionButtons; 
            this.ShowEditionButtons = true;
            //FinMatias 20170301 - Ticket #ER682004
        }
        public ICollection GenerateFields(Control control)
        {
            int mode = this.DataColumns.Count > 2 && this.DataColumns[1].ColumnName == "Fecha" ? 2 : 1;

            DataControlFieldCollection columns = new DataControlFieldCollection();

            //FinModificado por ALO 2018-02-07

            //var disableDelete = false;
            foreach (DataColumn dataColumn in this.DataColumns)
            {
                if (dataColumn.ColumnName == "ID") continue;

                Int32 t = 0;
                BoundField bf = new BoundField() { DataField = dataColumn.ColumnName, HeaderText = dataColumn.ColumnName };
                if (Int32.TryParse(dataColumn.ColumnName, out t))
                    bf.ItemStyle.HorizontalAlign = HorizontalAlign.Right;

                if (mode == 2)
                {
                    #region MODO DOS
                    if (columns.Count > 3)
                        bf.ItemStyle.Width = 45;    /*Matias 20170215 - Ticket #REQ318684 - ant: 50*/
                    else if (columns.Count == 3)
                        bf.ItemStyle.Width = 140;   /*Matias 20170215 - Ticket #REQ318684 - ant: 190*/
                    else if (columns.Count == 2)
                        bf.ItemStyle.Width = 280;
                    else if (columns.Count == 1)
                        bf.ItemStyle.Width = 50;
                    else if (columns.Count == 0)
                        bf.ItemStyle.Width = 50;
                    #endregion                    
                }
                else
                {
                    #region MODO UNO: sin columna fecha
                    if (columns.Count > 2)
                        bf.ItemStyle.Width = 45;    /*Matias 20170215 - Ticket #REQ318684 - ant: 50*/
                    else if (columns.Count == 2)
                        bf.ItemStyle.Width = 140;   /*Matias 20170215 - Ticket #REQ318684 - ant: 190*/
                    else if (columns.Count == 1)
                        bf.ItemStyle.Width = 280;   /*Matias 20170215 - Ticket #REQ318684 - ant: 330*/
                    else if (columns.Count == 0)
                        bf.ItemStyle.Width = 50;
                    #endregion
                }
                columns.Add(bf);
            }
            if (ShowEditionButtons)
            {
                columns.Add(GetTemplateButtons());
            }
            return columns;
        }
        TemplateField GetTemplateButtons()
        {
            TemplateField template = new TemplateField();
            template.ItemTemplate = new GridViewButtonsTemplate();

            //Matias 20170215 - Ticket #REQ318684
            template.ItemStyle.Width = 50;
            //FinMatias 20170215 - Ticket #REQ318684
            return template;
        }
    }
    #endregion

    public partial class ProyectoCronogramaEdit : WebControlEdit<nc.ProyectoCronogramaCompose>
    {
        #region Propiedades
        protected const string ID_FUENTE_F_TESORO_NACIONAL = "ID_FUENTE_F_TESORO_NACIONAL";
        protected const string ID_PLAN_TIPO_PNIP = "ID_PLAN_TIPO_PNIP";
        protected const string ID_PROCESO_EQ_BASICO = "ID_PROCESO_EQ_BASICO";
        protected const string BLOQUEAR_GASTOS_ESTIMADOS = "BLOQUEAR_GASTOS_ESTIMADOS";
        protected const string BLOQUEAR_GASTOS_ESTIMADOS_PLANES = "BLOQUEAR_GASTOS_ESTIMADOS_PLANES";
        protected const string BLOQUEAR_GASTOS_ESTIMADOS_TIPO_ORGANISMOS = "BLOQUEAR_GASTOS_ESTIMADOS_TIPO_ORGANISMOS";
        protected const string INFORMACION_PRESUPUESTARIA_CRONOGRAMA_TITULO = "INFORMACION_PRESUPUESTARIA_CRONOGRAMA_TITULO";
        protected const string INFORMACION_PRESUPUESTARIA_ANIO_VISIBLE = "INFORMACION_PRESUPUESTARIA_ANIO_VISIBLE";
        protected const string VALIDAR_PROYECTO_ACT_ESPECIF = "VALIDAR_PROYECTO_ACT_ESPECIF";

        #endregion Propiedades

        #region Override WebControlEdit
        protected override void _Initialize()
        {
            base._Initialize();

            acGastosEstimada.RequiredMessage = TranslateFormat("FieldIsNull", "Obj. del Gasto");
            // Etapas
            PopUpEtapas.Attributes.CssStyle.Add("display", "none");
            UIHelper.Load<nc.Fase>(ddlFase, FaseService.Current.GetList(new nc.FaseFilter() { Activo = true }), "Nombre", "IdFase", "Orden", SortDirection.Ascending);
            UIHelper.Load<nc.Estado>(ddlEstado, EstadoService.Current.GetList(new nc.EstadoFilter() { IdSistemaEntidad = (int)SistemaEntidadEnum.Proyecto_Etapa, Activo = true, OrderByProperty = "Orden" }), "Nombre", "IdEstado", false);
            UIHelper.SetValue(ddlEstado, (int)EstadoEnum.Pendiente);

            //Matias 20161205 - Bug Cronograma doble click
            diFIE.RangeErrorMessage = TranslateFormat("InvalidField", "Fecha Inicio Estimada"); //"Fecha inválida";
            diFFE.RangeErrorMessage = TranslateFormat("InvalidField", "Fecha Fin Estimada"); //"Fecha inválida";
            diFIR.RangeErrorMessage = TranslateFormat("InvalidField", "Fecha Inicio Realizada"); //"Fecha inválida";
            diFFR.RangeErrorMessage = TranslateFormat("InvalidField", "Fecha Fin Realizada"); //"Fecha inválida";
            //FinMatias 20161205 - Bug Cronograma doble click

            // Estimados
            PopUpEtapasEstimadas.Attributes.CssStyle.Add("display", "none");
            UIHelper.Load<nc.Moneda>(ddlMonedaEstimada, MonedaService.Current.GetList(new nc.MonedaFilter() { Activo = true }), "Nombre", "IdMoneda");

            // Realizados
            diFechaRealizada.RangeErrorMessage = TranslateFormat("InvalidField", "Fecha Inválida"); //Matias 20170220 - Ticket #ER730336
            PopUpEtapasRealizadas.Attributes.CssStyle.Add("display", "none");
            PopUpTotales.Attributes.CssStyle.Add("display", "none");
            UIHelper.Load<nc.Moneda>(ddlMonedaRealizada, MonedaService.Current.GetList(new nc.MonedaFilter() { Activo = true }), "Nombre", "IdMoneda");
            //UIHelper.Load<nc.FuenteFinanciamientoResult>(ddlFFinanciamientoRealizada, FuenteFinanciamientoService.Current.GetResult(new nc.FuenteFinanciamientoFilter() { Activo = true }), "Descripcion2", "IdFuenteFinanciamiento");
            //diFechaRealizada.Width = 80;
            //rbPorCodigoRealizada.Checked = true;

            int anioVisible = DateTime.Now.Year;
            if(SolutionContext.Current.ParameterManager.GetNumberValue(INFORMACION_PRESUPUESTARIA_ANIO_VISIBLE).HasValue && SolutionContext.Current.ParameterManager.GetNumberValue(INFORMACION_PRESUPUESTARIA_ANIO_VISIBLE).Value > 0)
            {
                anioVisible = (int)SolutionContext.Current.ParameterManager.GetNumberValue(INFORMACION_PRESUPUESTARIA_ANIO_VISIBLE).Value;
            }
            btVerInfoPresupuestaria.Text = "Ver Inicial / Vigente / Devengado " + anioVisible.ToString();
            lblAnioPresupuestario.Text = anioVisible.ToString();

            //xxx.ToolTip = Translate("TooltipCronogramasAgregar");
            pnlInformacionPresupuestaria.ToolTip = Translate("TooltipEjecucionPresupuestaria");
            pnlEtapaEstimada.ToolTip = Translate("TooltipGastosEstimados");
            pnlEtapaRealizada.ToolTip = Translate("TooltipGastosRealizados");
        }
        public override void Clear() { }
        public override void GetValue()
        {
            Int32 AnioCorrienteEstimado;
            if (Int32.TryParse(UIHelper.GetString(ddlAnioCorrienteEstimado), out AnioCorrienteEstimado))
                Entity.ProyectoAnioCorrienteEstimado = AnioCorrienteEstimado;
            else
                Entity.ProyectoAnioCorrienteEstimado = null;

            Int32 AnioCorrienteRealizado;
            if (Int32.TryParse(UIHelper.GetString(ddlAnioCorrienteRealizado), out AnioCorrienteRealizado))
                Entity.ProyectoAnioCorrienteRealizado = AnioCorrienteRealizado;
            else
                Entity.ProyectoAnioCorrienteRealizado = null;

            CalcularTEP();
        }
        public override void SetValue()
        {
            //btVerTotales.Enabled = CrudAction != CrudActionEnum.Create; //Matias 20170126 - #REQ575961

            //get saf ejecucion sino saf actual
            var saf = string.Empty;
            var programa = string.Empty;
            var subPrograma = string.Empty;
            if (Entity.Proyecto.IdSubProgramaEjecucion.HasValue && Entity.Proyecto.IdSubProgramaEjecucion.Value > 0)
            {
                SubPrograma subProgramaResult = SubProgramaService.Current.GetById(Entity.Proyecto.IdSubProgramaEjecucion.Value);
                subPrograma = subProgramaResult.Nombre;
                programa = subProgramaResult.Programa.Nombre;
                saf = subProgramaResult.Programa.Saf.Denominacion;
            }
            else if (Entity.Proyecto.IdSubPrograma > 0)
            {
                //Entity.Proyecto.IdSubPrograma
                SubPrograma subProgramaResult = SubProgramaService.Current.GetById(Entity.Proyecto.IdSubPrograma);
                subPrograma = subProgramaResult.Nombre;
                programa = subProgramaResult.Programa.Nombre;
                saf = subProgramaResult.Programa.Saf.Denominacion;
            }


            UIHelper.SetValue(txtSAF, saf);
            UIHelper.SetValue(txtPrograma, programa);
            UIHelper.SetValue(txtSubPrograma, subPrograma);
            UIHelper.SetValue(txtNroProyecto, String.Format("{0:00}", Entity.Proyecto.NroProyectoEjecucion));
            UIHelper.SetValue(txtNroActividad, String.Format("{0:00}", Entity.Proyecto.NroActividadEjecucion));
            UIHelper.SetValue(txtNroObra, String.Format("{0:00}", Entity.Proyecto.NroObraEjecucion));

            SetPermissions();
            CargarComboAnio();
            ActualProyectoEtapa = null;
            SetPeriodosTipoOrganismoBloqueos(); //ALO
            ProyectoEtapaRefresh();
            ProyectoEtapaEstimadaRefresh();
            ProyectoEtapaRealizadaRefresh();
        }
        protected override void _Load()
        {
            base._Load();

            //ConfigurarAutocompletes();
            if (EnableEtapaEstimadaUpdate)
            {
                btAgregarEtapaEstimada.Enabled = btAgregarEtapaEstimada.Enabled && Entity.Etapas.Count > 0;
            }
            if (EnableEtapaRealizadaUpdate)
            {
                btAgregarEtapaRealizada.Enabled = btAgregarEtapaRealizada.Enabled && Entity.Etapas.Count > 0;
            }
            AddGroupToGrid();

            ActualizarVerTotales(); //Matias 20170126 - #REQ575961
        }

        #endregion Override

        #region Otros Metodos

        private void CalcularTEP()
        {
            //Solo se calcula la Imputacion Presupuetaria en la fase de ejecución
            if (Entity.IdFase == (int)FaseEnum.Ejecucion)
            {
                var listProyectoTipo = ProyectoTipoService.Current.GetList();
                Entity.Proyecto.IdTipoProyecto = listProyectoTipo.Where(x => x.Nombre == EnumUtilities.GetEnumDescription(ProyectoTipoEnum.SinGastosImputados)).FirstOrDefault().IdProyectoTipo;

                List<string> incisos = new List<string>();

                //var proyectoEtapas = ProyectoEtapaService.Current.GetResultFromList(new nc.ProyectoEtapaFilter() { IdProyecto = Entity.Proyecto.IdProyecto });
                var proyectoEtapas = Entity.Etapas;
                foreach (var proyectoEtapa in proyectoEtapas)
                {
                    //var proyectoEtapaInformacionPresupuestarias = ProyectoEtapaInformacionPresupuestariaService.Current.GetResultFromList(new nc.ProyectoEtapaInformacionPresupuestariaFilter() { IdProyectoEtapa = proyectoEtapa.IdProyectoEtapa });
                    foreach (var proyectoEtapaInformacionPresupuestaria in Entity.EtapasInformacionPresupuestarias)
                    {
                        ClasificacionGasto cg = ClasificacionGastoService.Current.GetById(proyectoEtapaInformacionPresupuestaria.IdClasificacionGasto);
                        if (!incisos.Where(x => x.Equals(cg.BreadcrumbCode.Substring(1, 2))).Any())
                        {
                            incisos.Add(cg.BreadcrumbCode.Substring(1, 2));
                        }
                    }
                    //var proyectoEtapaEstimados = ProyectoEtapaEstimadoService.Current.GetResultFromList(new nc.ProyectoEtapaEstimadoFilter() { IdProyectoEtapa = proyectoEtapa.IdProyectoEtapa });
                    foreach (var proyectoEtapaEstimado in Entity.EtapasEstimadas)
                    {
                        ClasificacionGasto cg = ClasificacionGastoService.Current.GetById(proyectoEtapaEstimado.IdClasificacionGasto);
                        if (!incisos.Where(x => x.Equals(cg.BreadcrumbCode.Substring(1, 2))).Any())
                        {
                            incisos.Add(cg.BreadcrumbCode.Substring(1, 2));
                        }
                    }
                    //var proyectoEtapaRealizados = ProyectoEtapaRealizadoService.Current.GetResultFromList(new nc.ProyectoEtapaRealizadoFilter() { IdProyectoEtapa = proyectoEtapa.IdProyectoEtapa });
                    foreach (var proyectoEtapaRealizado in Entity.EtapasRealizadas)
                    {
                        ClasificacionGasto cg = ClasificacionGastoService.Current.GetById(proyectoEtapaRealizado.IdClasificacionGasto);
                        if (!incisos.Where(x => x.Equals(cg.BreadcrumbCode.Substring(1, 2))).Any())
                        {
                            incisos.Add(cg.BreadcrumbCode.Substring(1, 2));
                        }
                    }
                }
                //string.Join("|", incisos)

                if (incisos == null || incisos.Count == 0)
                {
                    return;
                }
                else if (
                    (
                        incisos.Where(x => x.Equals("04")).Any() &&
                        !incisos.Where(x => x.Equals("05")).Any() &&
                        !incisos.Where(x => x.Equals("06")).Any()
                    )
                    /*||
                    (
                        Entity.Proyecto.NroProyecto != null && Entity.Proyecto.NroProyecto != 0 && incisos.Where(x => Int32.Parse(x) < 4).Any()
                    )*/
                    )
                {
                    //Condición Obligatoria
                    //Inc 4 y no inc. 5 ni inc 6
                    //O (Cód. de Proy <> de vacío ) y (inc 1 y/o 2 y/o  3 -  cualquier combinación de incisos menor a 4)
                    //Otra Condicion Posible
                    //Inc 4 + inc. 1 y/o 2 y/o 3 
                    Entity.Proyecto.IdTipoProyecto = listProyectoTipo.Where(x => x.Nombre == EnumUtilities.GetEnumDescription(ProyectoTipoEnum.IRDInvRealDirecta)).FirstOrDefault().IdProyectoTipo;
                }
                else if (
                    (!incisos.Where(x => x.Equals("04")).Any() &&
                    incisos.Where(x => x.Equals("05")).Any() &&
                    !incisos.Where(x => x.Equals("06")).Any())
                    // || Por el momento no considerar
                    //incisos.Where(x => x.Equals("05")).Any() && incisos.Where(x => x.Equals("01")).Any()
                    //||
                    //incisos.Where(x => x.Equals("05")).Any() && incisos.Where(x => x.Equals("02")).Any()
                    //||
                    //incisos.Where(x => x.Equals("05")).Any() && incisos.Where(x => x.Equals("03")).Any()
                    )
                {
                    //Condición Obligatoria
                    //Inc 5 y no inc. 4 ni inc 6
                    //Otra Condición Posible
                    //Inc 5 + inc. 1 y/o 2 y/o 3
                    Entity.Proyecto.IdTipoProyecto = listProyectoTipo.Where(x => x.Nombre == EnumUtilities.GetEnumDescription(ProyectoTipoEnum.Transferencia)).FirstOrDefault().IdProyectoTipo;
                }
                else if (
                   (incisos.Where(x => x.Equals("04")).Any() && (incisos.Where(x => x.Equals("05")).Any() || incisos.Where(x => x.Equals("06")).Any()))
                    ||
                    (incisos.Where(x => x.Equals("05")).Any() && incisos.Where(x => x.Equals("06")).Any())
                    ||
                    (incisos.Where(x => x.Equals("06")).Any() && incisos.Where(x => x.Equals("07")).Any() && incisos.Where(x => x.Equals("08")).Any())
                   )
                {
                    //Condición Obligatoria                             Otra Condición Posible (*1)
                    //Inc 4 y (5 ó 6)                                   inc 4 y (5 ó 6) + inc. 1 y/o 2 y/o 3
                    //O Inc 5 y 6                                       Ó Inc 5 y 6 + inc. 1 y/o 2 y/o 3
                    //O Inc. 6.8.7 y cualquier otro inc. 6              O Inc. 6.8.7 y cualquier otro inc. 6 + inc. 1 y/o 2 y/o 3
                    Entity.Proyecto.IdTipoProyecto = listProyectoTipo.Where(x => x.Nombre == EnumUtilities.GetEnumDescription(ProyectoTipoEnum.Combinados)).FirstOrDefault().IdProyectoTipo;
                }
                else if (
                    (incisos.Where(x => x.Equals("06")).Any() && (!(incisos.Where(x => x.Equals("07")).Any() && incisos.Where(x => x.Equals("08")).Any())))
                    &&
                    !incisos.Where(x => x.Equals("05")).Any() &&
                    !incisos.Where(x => x.Equals("04")).Any()
                    )
                {
                    //Condición Obligatoria
                    //Solo Inc. 6 (con excepción de 6.8.7) y no inc. 4 ni inc 5.
                    Entity.Proyecto.IdTipoProyecto = listProyectoTipo.Where(x => x.Nombre == EnumUtilities.GetEnumDescription(ProyectoTipoEnum.InversionesFinancieras)).FirstOrDefault().IdProyectoTipo;
                }
                else if (
                    (incisos.Where(x => x.Equals("06")).Any() && incisos.Where(x => x.Equals("07")).Any() && incisos.Where(x => x.Equals("08")).Any())
                    )
                {
                    //Condición Obligatoria
                    //Únicamente inciso 6.8.7
                    Entity.Proyecto.IdTipoProyecto = listProyectoTipo.Where(x => x.Nombre == EnumUtilities.GetEnumDescription(ProyectoTipoEnum.AdelantoProveedores)).FirstOrDefault().IdProyectoTipo;
                }
                else if (
                    ((Entity.Proyecto.NroProyecto == null || Entity.Proyecto.NroProyecto == 0) && !incisos.Where(x => Int32.Parse(x) >= 4).Any())
                    )
                {
                    //Condición Obligatoria
                    //Cód. de Proy= 00 y (inc 1 y/o 2 y/o  3 -cualquier combinación de incisos menor a 4) (*2)
                    //Cualquier combinación de incisos menor a 4: (estos No son proyectos o no tienen cód. presupuestario asignado) 
                    Entity.Proyecto.IdTipoProyecto = listProyectoTipo.Where(x => x.Nombre == EnumUtilities.GetEnumDescription(ProyectoTipoEnum.GastoCorriente)).FirstOrDefault().IdProyectoTipo;
                }
                else
                {
                    Entity.Proyecto.IdTipoProyecto = listProyectoTipo.Where(x => x.Nombre == EnumUtilities.GetEnumDescription(ProyectoTipoEnum.Indefinido)).FirstOrDefault().IdProyectoTipo;
                }
            }
        }
        private Int32 GetParameterIDFFTesoroNacional()
        {
            return (Int32)SolutionContext.Current.ParameterManager.GetNumberValue(ID_FUENTE_F_TESORO_NACIONAL);
        }
        private Int32 GetParameterIDPlanTipoPNIP()
        {
            return (Int32)SolutionContext.Current.ParameterManager.GetNumberValue(ID_PLAN_TIPO_PNIP);
        }
        private Int32 GetParameterIDProcesoEquipamientoBasico()
        {
            return (Int32)SolutionContext.Current.ParameterManager.GetNumberValue(ID_PROCESO_EQ_BASICO);
        }
        private void CargarComboAnio()
        {
            #region Old
            //if (Entity != null)
            //    for (Int32 anio = Entity.ProyectoAnioReferencia; anio <= DateTime.Now.Year; anio++)
            //        ddlAnioCorriente.Items.Add(new ListItem(anio.ToString(), anio.ToString()));

            //if(ddlAnioCorriente.Items.Count == 0)
            //    ddlAnioCorriente.Items.Add(new ListItem(DateTime.Now.Year.ToString(), DateTime.Now.Year.ToString()));
            #endregion
            UIHelper.Load<nc.Anio>((DropDownList)ddlAnioCorrienteEstimado, AnioService.Current.GetList(new nc.AnioFilter() { Activo = true }).OrderByDescending(i => i.Nombre).ToList(), "Nombre", "Nombre", new Anio() { Nombre = "Seleccione Año" }, false);
            UIHelper.Load<nc.Anio>((DropDownList)ddlAnioCorrienteRealizado, AnioService.Current.GetList(new nc.AnioFilter() { Activo = true }).OrderByDescending(i => i.Nombre).ToList(), "Nombre", "Nombre", new Anio() { Nombre = "Seleccione Año" }, false);
            UIHelper.SetValue(ddlAnioCorrienteEstimado, DateTime.Now.Year);
            UIHelper.SetValue(ddlAnioCorrienteRealizado, DateTime.Now.Year);
        }
        private void AddGroupToGrid()
        {
            GridViewHelper helper = new GridViewHelper(this.gvTotales);
            helper.RegisterGroup("NombreFase", true, true);
            helper.RegisterSummary("Estimado", SummaryOperation.Sum, "NombreFase");
            helper.RegisterSummary("Realizado", SummaryOperation.Sum, "NombreFase");
            helper.GroupSummary += new GroupEvent(helper_Bug);
            helper.ApplyGroupSort();
        }
        private void helper_Bug(string groupName, object[] values, GridViewRow row)
        {
            if (groupName == null) return;

            row.ForeColor = Color.Blue;
            //row.Font.Bold  = true;
            row.Cells[0].Text = String.Format("{0} {1}", UIHelper.Translate("SubTotal"), values[0].ToString());

        }
        
        //Matias 20170215 - Ticket #REQ318684
        public void RefreshEtapas()
        {
            Int32 AnioCorrienteEstimado;
            if (Int32.TryParse(UIHelper.GetString(ddlAnioCorrienteEstimado), out AnioCorrienteEstimado))
                Entity.ProyectoAnioCorrienteEstimado = AnioCorrienteEstimado;
            else
                Entity.ProyectoAnioCorrienteEstimado = DateTime.Now.Year;

            Int32 AnioCorrienteRealizado;
            if (Int32.TryParse(UIHelper.GetString(ddlAnioCorrienteRealizado), out AnioCorrienteRealizado))
                Entity.ProyectoAnioCorrienteRealizado = AnioCorrienteRealizado;
            else
                Entity.ProyectoAnioCorrienteRealizado = DateTime.Now.Year;

            ProyectoEtapaEstimadaRefresh();
            ProyectoEtapaRealizadaRefresh();
        }
        //FinMatias 20170215 - Ticket #REQ318684

        #region Old
        //public void ConfigurarAutocompletes()
        //{
        //    //acGastosRealizada.WebServiceName = "~/Services/wsProyectoCronograma.asmx";
        //    //acGastosRealizada.ServiceMethod = "GetCalificacionGastoPorCodigo";
        //    //acGastosRealizada.MinimumPrefixLength = 2;
        //    //acGastosRealizada.AutoPostback = true;
        //    //acGastosRealizada.ValueChanged += new EventHandler(this.AutocompletePostBackRealizada);
        //    //acGastosRealizada.Tag = "";

        //    //acGastosEstimada.WebServiceName = "~/Services/wsProyectoCronograma.asmx";
        //    //acGastosEstimada.ServiceMethod = "GetCalificacionGastoPorCodigo";
        //    //acGastosEstimada.MinimumPrefixLength = 2;
        //    //acGastosEstimada.AutoPostback = true;
        //    //acGastosEstimada.ValueChanged += new EventHandler(this.AutocompletePostBackEstimada);
        //    //acGastosEstimada.Tag = "";
        //}
        #endregion
        #endregion

        #region Sobre Etapas

        private ProyectoEtapaResult actualProyectoEtapa;
        protected ProyectoEtapaResult ActualProyectoEtapa
        {
            get
            {
                if (actualProyectoEtapa == null)
                {
                    if (ViewState["actualProyectoEtapa"] != null)
                        actualProyectoEtapa = ViewState["actualProyectoEtapa"] as ProyectoEtapaResult;
                    else
                    {
                        if (Entity.Etapas.Count != 0)
                        {
                            actualProyectoEtapa = Entity.Etapas.First();
                            ViewState["actualProyectoEtapa"] = actualProyectoEtapa;

                            if (EnableEtapaRealizadaUpdate)
                            {
                                btAgregarEtapaRealizada.Enabled = actualProyectoEtapa.FechaInicioRealizada != null;
                                pnlAgregarEtapaRealizada.Update();
                            }
                            if (EnableEtapaEstimadaUpdate)
                            {
                                btAgregarEtapaEstimada.Enabled = actualProyectoEtapa.FechaInicioEstimada != null;
                                pnlAgregarEtapaEstimada.Update();
                            }
                        }
                        else
                            actualProyectoEtapa = new ProyectoEtapaResult();
                    }
                }
                return actualProyectoEtapa;
            }
            set
            {
                actualProyectoEtapa = value;
                ViewState["actualProyectoEtapa"] = actualProyectoEtapa;
            }
        }

        protected bool ChangeFaseSuccess
        {
            get;
            set;
        }

        #region Methods
        private void ChangeFase()
        {
            // Guardar informacion de la fase anterior
            GetValue();
            ProyectoCronogramaComposeService.Current.Update(Entity, UIContext.Current.ContextUser);
            ChangeFaseSuccess = true;

            #region Old

            // Obtener la informacion de la nueva fase            
            // ACTUALIZA LOS OBJETOS DE LA PAGINA Y EL CONTROL
            PageEdit<ProyectoCronogramaCompose, nc.ProyectoFilter, nc.ProyectoResult, int> pageEdit = this.PageBase as PageEdit<ProyectoCronogramaCompose, nc.ProyectoFilter, nc.ProyectoResult, int>;
            pageEdit.Entity = ProyectoCronogramaComposeService.Current.GetByIdFase(Entity.IdProyecto, UIHelper.GetInt(ddlFase));
            pageEdit.EntityOld = pageEdit.Entity;
            this.Entity = pageEdit.Entity;
            // ACTUALIZA LOS OBJETOS DE LA PAGINA Y EL CONTROL

            #endregion
            //Entity = ProyectoCronogramaComposeService.Current.GetByIdFase(Entity.IdProyecto, UIHelper.GetInt(ddlFase));
            // Actualiza la pantalla
            //ActualizarLabelsEtapas();
            ProyectoEtapaClear();
            ProyectoEtapaEstimadaClear();
            ProyectoEtapaRealizadaClear();
            ProyectoEtapaRefresh();
            ProyectoEtapaEstimadaRefresh();
            ProyectoEtapaRealizadaRefresh();
        }
        void HidePopUpEtapas()
        {
            ModalPopupExtenderEtapas.Hide();
        }
        void ProyectoEtapaClear()
        {
            ActualProyectoEtapa = null;
        }
        void ProyectoEtapaSetValue()
        {
            UIHelper.SetValue(lblErrorEtapa, "");
            UIHelper.SetValue(lblEtapa, ActualProyectoEtapa.Descripcion);
            if (ActualProyectoEtapa.IdEstado.HasValue)
                UIHelper.SetValue<Estado, int>(ddlEstado, ActualProyectoEtapa.IdEstado.Value, EstadoService.Current.GetById);
            UIHelper.SetValue(diFIE, ActualProyectoEtapa.FechaInicioEstimada);
            UIHelper.SetValue(diFFE, ActualProyectoEtapa.FechaFinEstimada);
            UIHelper.SetValue(diFIR, ActualProyectoEtapa.FechaInicioRealizada);
            UIHelper.SetValue(diFFR, ActualProyectoEtapa.FechaFinRealizada);

            bool noEditar = (Entity.ProyectoIdTipoPlan != null && Entity.ProyectoIdTipoPlan == GetParameterIDPlanTipoPNIP() && Entity.Proyecto.IdProceso == GetParameterIDProcesoEquipamientoBasico());
            diFIE.ReadOnly = noEditar && diFIE.Fecha != null;
            diFFE.ReadOnly = noEditar && diFFE.Fecha != null;
        }
        void ProyectoEtapaGetValue()
        {
            ActualProyectoEtapa.IdEstado = UIHelper.GetInt(ddlEstado);
            ActualProyectoEtapa.Estado_Nombre = UIHelper.GetString(ddlEstado);
            ActualProyectoEtapa.FechaInicioEstimada = UIHelper.GetDateTimeNullable(diFIE);
            ActualProyectoEtapa.FechaFinEstimada = UIHelper.GetDateTimeNullable(diFFE);
            ActualProyectoEtapa.FechaInicioRealizada = UIHelper.GetDateTimeNullable(diFIR);
            ActualProyectoEtapa.FechaFinRealizada = UIHelper.GetDateTimeNullable(diFFR);
        }
        void ProyectoEtapaRefresh()
        {
            UIHelper.SetValue<Fase, int>(ddlFase, Entity.IdFase, FaseService.Current.GetById);

            /*if (Entity.ProyectoAnioCorriente.HasValue)
                UIHelper.SetValue(ddlAnioCorriente, Entity.ProyectoAnioCorriente.Value);
            else*/
            if (ActualProyectoEtapa == null && Entity.Etapas.Count > 0)
                ActualProyectoEtapa = Entity.Etapas[0];

            ActualizarTotalesEtapas();
            //ActualizarLabelsEtapas();
            UIHelper.Load(gridEtapas, Entity.Etapas, "Etapa_Orden");

            InicioDeCarga();

            if (ActualProyectoEtapa != null)
                MarcarProyectoEtapa(ActualProyectoEtapa.ID);

            ddlFase.Enabled = false;
            string error = "";
            if(ProyectoCronogramaComposeBusiness.Current.ValidateEtapa(ActualProyectoEtapa,Entity,ref error))
            {
                ddlFase.Enabled = true;
            }
            upGridEtapas.Update();
        }

        private void InicioDeCarga()
        {
            if (
                Entity.Etapas.Count == 1 &&
                Entity.Etapas[0].FechaInicioEstimada == null &&
                Entity.Etapas[0].FechaFinEstimada == null &&
                Entity.Etapas[0].FechaInicioRealizada == null &&
                Entity.Etapas[0].FechaFinRealizada == null)
            {
                var btnEdit = gridEtapas.Rows[0].Cells[gridEtapas.Columns.Count - 1].FindControl("imgEdit") as ImageButton;
                btnEdit.Visible = false;
                btInicioDeCarga.Visible = true;
            }
            else if (Entity.Etapas.Count == 0 && Convert.ToInt32(ddlFase.SelectedValue) != (int)FaseEnum.Ejecucion)
            {
                btInicioDeCarga.Visible = true;
            }
            else
            {
                btInicioDeCarga.Visible = false;
            }
        }

        protected void btInicioDeCarga_Click(object sender, EventArgs e)
        {
            if (gridEtapas.Rows.Count == 0)
            {
                ActualProyectoEtapa = GetNewEtapa();
                ActualProyectoEtapa.IdProyectoEtapa = -1; //NUEVA
                ActualProyectoEtapa.Nombre = Entity.Proyecto.ProyectoDenominacion;
                ActualProyectoEtapa.ProyectoDenominacion = Entity.Proyecto.ProyectoDenominacion;
                ActualProyectoEtapa.IdProyecto = Entity.Proyecto.IdProyecto;
                var etapa = EtapaService.Current.GetList(new nc.EtapaFilter()
                {
                    IdFase = Convert.ToInt32(ddlFase.SelectedValue),
                    Activo = true,
                    OrderByProperty = "Orden"
                }).FirstOrDefault();
                ActualProyectoEtapa.IdEtapa = etapa.IdEtapa;
                ActualProyectoEtapa.IdEstado = (int)EstadoEnum.Iniciado; //A iniciar para estado etapa

                Entity.Etapas.Add(ActualProyectoEtapa);
                ProyectoEtapaRefresh();
            }
            var btnEdit = gridEtapas.Rows[0].Cells[gridEtapas.Columns.Count - 1].FindControl("imgEdit") as ImageButton;
            CommandProyectoEtapaEdit();
        }

        protected void btActividadEspecifica_Click(object sender, EventArgs e)
        {
            ActualProyectoEtapa = GetNewEtapa();
            ActualProyectoEtapa.IdProyectoEtapa = -1; //NUEVA
            ActualProyectoEtapa.Nombre = Entity.Proyecto.ProyectoDenominacion;
            ActualProyectoEtapa.ProyectoDenominacion = Entity.Proyecto.ProyectoDenominacion;
            ActualProyectoEtapa.IdProyecto = Entity.Proyecto.IdProyecto;
            ActualProyectoEtapa.IdEtapa = (int)EtapaEnum.ActividadEspecifica;
            ActualProyectoEtapa.IdEstado = (int)EstadoEnum.Iniciado; //A iniciar para estado etapa
               
            CommandProyectoEtapaSave();
        }

        void MarcarProyectoEtapa(Int32 idProyectoEtapa)
        {
            var tengoActividadEspecifica = Entity.Etapas.Where(x => x.IdEtapa == (int)EtapaEnum.ActividadEspecifica).Any();

            foreach (ProyectoEtapaResult pe in Entity.Etapas)
            {
                if (pe.IdProyectoEtapa == idProyectoEtapa)
                {
                    ActualProyectoEtapa = pe;
                    ProyectoEtapaEstimadaRefresh();
                    ProyectoEtapaRealizadaRefresh();
                }
            }

            btActividadEspecifica.Enabled = false;
            if (SolutionContext.Current.ParameterManager.GetStringValue(VALIDAR_PROYECTO_ACT_ESPECIF) == "S"
                && (Entity.Proyecto.NroObra > 0 || Entity.Proyecto.NroObraEjecucion > 0)
                && !tengoActividadEspecifica
                )
            {
                //btActividadEspecifica.Enabled = true; POR EL MOMENTO NO SE MUESTRA
            } else if (SolutionContext.Current.ParameterManager.GetStringValue(VALIDAR_PROYECTO_ACT_ESPECIF) == "N"
                && !tengoActividadEspecifica)
            {
                //btActividadEspecifica.Enabled = true; POR EL MOMENTO NO SE MUESTRA
            }

            foreach (GridViewRow row in gridEtapas.Rows)
            {
                Int32 idRowAux = Int32.Parse(gridEtapas.DataKeys[row.RowIndex].Value.ToString());
                RadioButton rb = ((RadioButton)row.Cells[0].FindControl("rbEtapa"));
                rb.Checked = idRowAux == idProyectoEtapa;
            }

            if (EnableEtapaRealizadaUpdate)
            {
                //Matias 20170131 - Ticket #REQ571729
                //btAgregarEtapaRealizada.Enabled = ActualProyectoEtapa.FechaInicioRealizada != null;
                btAgregarEtapaRealizada.Enabled = (ActualProyectoEtapa.FechaInicioRealizada != null)
                    && ((ActualProyectoEtapa.IdEstado == (int)EstadoEnum.En_Ejecucion)) ;
                    //&& ( (Entity.Proyecto.IdEstado == (int)EstadoEnum.En_Ejecucion) || (Entity.Proyecto.IdEstado == (int)EstadoEnum.En_EjecOper));
                //FinMatias 20170131 - Ticket #REQ571729
                pnlAgregarEtapaRealizada.Update();
            }
            if (EnableEtapaEstimadaUpdate)
            {
                btAgregarEtapaEstimada.Enabled = ActualProyectoEtapa.FechaInicioEstimada != null;
                pnlAgregarEtapaEstimada.Update();
            }
        }
        void ActualizarTotalesEtapas()
        {
            foreach (ProyectoEtapaResult pe in Entity.Etapas)
            {
                pe.TotalEstimado = (from ee in Entity.EtapasEstimadas where ee.IdProyectoEtapa == pe.IdProyectoEtapa select ee.TotalEstimado).Sum();
                pe.TotalRealizado = (from ee in Entity.EtapasRealizadas where ee.IdProyectoEtapa == pe.IdProyectoEtapa select ee.TotalRealizado).Sum();
            }
        }
        /*
        void ActualizarLabelsEtapas()
        {
            if (Entity.Etapas.Count == 0)
            {
                UIHelper.Clear(lblMfie);
                UIHelper.Clear(lblMffe);
                UIHelper.Clear(lblMfir);
                UIHelper.Clear(lblMffr);
                UIHelper.Clear(lblMte);
                UIHelper.Clear(lblMtr);

                return;
            }

            if ((from e in Entity.Etapas where e.FechaInicioEstimada != null select e).Count() > 0)
                UIHelper.SetValue(lblMfie, ((DateTime)(from e in Entity.Etapas select e.FechaInicioEstimada).Min()).ToShortDateString());
            else
                UIHelper.Clear(lblMfie);
            if ((from e in Entity.Etapas where e.FechaFinEstimada != null select e).Count() > 0)
                UIHelper.SetValue(lblMffe, ((DateTime)(from e in Entity.Etapas select e.FechaFinEstimada).Max()).ToShortDateString());
            else
                UIHelper.Clear(lblMffe);
            if ((from e in Entity.Etapas where e.FechaInicioRealizada != null select e).Count() > 0)
                UIHelper.SetValue(lblMfir, ((DateTime)(from e in Entity.Etapas select e.FechaInicioRealizada).Min()).ToShortDateString());
            else
                UIHelper.Clear(lblMfir);
            if ((from e in Entity.Etapas where e.FechaFinRealizada != null select e).Count() > 0)
                UIHelper.SetValue(lblMffr, ((DateTime)(from e in Entity.Etapas select e.FechaFinRealizada).Max()).ToShortDateString());
            else
                UIHelper.Clear(lblMffr);

            UIHelper.SetValue(lblMte, (from ee in Entity.EtapasEstimadas select ee.TotalEstimado).Sum().ToString("N0"));
            UIHelper.SetValue(lblMtr, (from ee in Entity.EtapasRealizadas select ee.TotalRealizado).Sum().ToString("N0"));
        }*/

        #endregion Methods

        #region Commands
        void CommandProyectoEtapaEdit()
        {
            //ProyectoEtapaClear();
            ProyectoEtapaSetValue();
            ModalPopupExtenderEtapas.Show();
            upEtapasPopUp.Update();
        }
        void CommandProyectoEtapaSave()
        {
            ProyectoEtapaGetValue();
            ProyectoEtapaResult result = (from l in Entity.Etapas
                                          where l.IdProyectoEtapa == ActualProyectoEtapa.ID
                                          select l).FirstOrDefault();

            string error = "";
            if (ProyectoCronogramaComposeService.ValidateEtapa(ActualProyectoEtapa, Entity, ref error))
            {
                if (result != null)
                {
                    result.IdProyecto = ActualProyectoEtapa.IdProyecto;
                    result.IdEtapa = ActualProyectoEtapa.IdEtapa;
                    result.IdProyectoEtapa = ActualProyectoEtapa.IdProyectoEtapa;
                    result.Nombre = ActualProyectoEtapa.Nombre;
                    result.CodigoVinculacion = ActualProyectoEtapa.CodigoVinculacion;
                    result.IdEstado = ActualProyectoEtapa.IdEstado;
                    result.Estado_Nombre = ActualProyectoEtapa.Estado_Nombre;
                    result.FechaInicioEstimada = ActualProyectoEtapa.FechaInicioEstimada;
                    result.FechaFinEstimada = ActualProyectoEtapa.FechaFinEstimada;
                    result.FechaInicioRealizada = ActualProyectoEtapa.FechaInicioRealizada;
                    result.FechaFinRealizada = ActualProyectoEtapa.FechaFinRealizada;
                }
                else
                {
                    Entity.Etapas.Add(ActualProyectoEtapa);
                }
                ProyectoEtapaClear();
                ProyectoEtapaRefresh();
                HidePopUpEtapas();
            }
            else
            {
                UIHelper.SetValue(lblErrorEtapa, error);
                UIHelper.ShowAlert(error, upEtapasPopUp);
                upEtapasPopUp.Update();
            }
            InicioDeCarga();
        }
        void CommandProyectoEtapaDelete()
        {
            ProyectoEtapaResult result = (from l in Entity.Etapas where l.IdProyectoEtapa == ActualProyectoEtapa.ID select l).FirstOrDefault();
            Entity.Etapas.Remove(result);
            ProyectoEtapaClear();
            ProyectoEtapaRefresh();
        }
        #endregion

        #region Eventos

        protected void btSaveEtapa_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(CommandProyectoEtapaSave);
        }
        protected void btCancelEtapa_Click(object sender, EventArgs e)
        {
            ProyectoEtapaClear();
            HidePopUpEtapas();
        }

        public void rbEtapa_OnCheckedChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = ((GridViewRow)((WebControl)sender).NamingContainer);
            Int32 idRow = Int32.Parse(gridEtapas.DataKeys[gvr.RowIndex].Value.ToString());
            MarcarProyectoEtapa(idRow);
        }
        protected void GridEtapas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex == 0)
                ((RadioButton)e.Row.Cells[0].FindControl("rbEtapa")).Checked = true;

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[7].ToolTip = Translate("TooltipTotalEstimadoActual");
                e.Row.Cells[8].ToolTip = Translate("TooltipTotalRealizado");
            }
        }

        protected void GridPeriodoEstimado_OnDataBound(object sender, EventArgs e)
        {
            /*GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell = new TableHeaderCell();
            cell.Text = "";
            cell.ColumnSpan = 4;
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 4;
            cell.Text = "Información Presupuestaria " + SolutionContext.Current.ParameterManager.GetStringValue(INFORMACION_PRESUPUESTARIA_CRONOGRAMA_TITULO);
            cell.Attributes.Add("style", "text-align:center !important;");
            row.Controls.Add(cell);

            GridPeriodoEstimado.HeaderRow.Parent.Controls.AddAt(0, row);*/
        }

        public void ddlFase_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            CallTryMethod(ChangeFase);
        }

        protected void ddlAnioCorrienteEstimado_IndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(RefreshEtapas);
        }
        protected void ddlAnioCorrienteRealizado_IndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(RefreshEtapas);
        }
        //FinMatias 20170215 - Ticket #REQ318684

        #endregion

        #region EventosGrillas
        protected void GridEtapas_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualProyectoEtapa = (from l in Entity.Etapas where l.IdProyectoEtapa == id select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandProyectoEtapaEdit();
                    break;
                case Command.DELETE:
                    CommandProyectoEtapaDelete();
                    break;
            }
        }
        protected virtual void GridEtapas_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridEtapas.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridEtapas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridEtapas.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        #endregion

        #endregion Etapa


        //private List<PlanPeriodo> planPeriodosBloqueados;
        protected List<PlanPeriodo> PlanPeriodosBloqueados{get;set;}        
        //private List<PlanPeriodo> organismoTipoBloqueados;
        protected List<OrganismoTipo> OrganismoTipoBloqueados{get;set;}
        protected int TipoOrganismoProyecto { get; set; } 

        #region Sobre EtapaEstimada

        private ProyectoEtapaEstimadoResult actualProyectoEtapaEstimada;
        protected ProyectoEtapaEstimadoResult ActualProyectoEtapaEstimada
        {
            get
            {
                if (actualProyectoEtapaEstimada == null)
                {
                    if (ViewState["actualProyectoEtapaEstimada"] != null)
                        actualProyectoEtapaEstimada = ((ProyectoEtapaEstimadoResult)ViewState["actualProyectoEtapaEstimada"]);
                    else
                    {
                        actualProyectoEtapaEstimada = GetNewEtapaEstimada();
                        ViewState["actualProyectoEtapaEstimada"] = actualProyectoEtapaEstimada;
                    }
                }
                return actualProyectoEtapaEstimada;
            }
            set
            {
                actualProyectoEtapaEstimada = value;
                ViewState["actualProyectoEtapaEstimada"] = value;
            }
        }
        void SetearBloqueos(ActionEnum action)
        {
            //Modificado por ALO 2018-02-07
            if (PlanPeriodosBloqueados == null || OrganismoTipoBloqueados == null) SetPeriodosTipoOrganismoBloqueos();

            //Solo opera el bloqueo si tengo los dos bloqueos
            if (PlanPeriodosBloqueados == null || OrganismoTipoBloqueados == null) return;

            if (PlanPeriodosBloqueados.Count > 0 && OrganismoTipoBloqueados.Count > 0)
            {
                var tieneBloqueo = false;
                acGastosEstimada.Enabled = true;
                tsFuenteFinanciamientoEstimada.Enabled = true;
                ddlMonedaEstimada.Enabled = true;
                foreach (var proyectoEtapaEstimadaValue in ActualProyectoEtapaEstimada.Periodos)
                {

                    if ((PlanPeriodosBloqueados.Count <= 0 || PlanPeriodosBloqueados.Where(x => x.AnioInicial.Equals(proyectoEtapaEstimadaValue.Periodo)).Any())
                        && (OrganismoTipoBloqueados.Count <= 0 || OrganismoTipoBloqueados.Where(x => x.IdOrganismoTipo == TipoOrganismoProyecto).Any()))
                    {
                        //El nombre de la columna coincide con un año inicial de los planes bloqueados y a un id de tipo de organismo
                        //dataColumn.ColumnName == "2018"
                        proyectoEtapaEstimadaValue.Bloqueado = true;
                        tieneBloqueo = true;
                    } 

                    //Condicion de bloqueo adicional
                    /*if (proyectoEtapaEstimadaValue.MontoInicial > 0 || proyectoEtapaEstimadaValue.MontoVigente > 0 || proyectoEtapaEstimadaValue.MontoDevengado > 0)
                    {
                        tieneBloqueo = true;
                    }*/

                }
                if (tieneBloqueo && action == ActionEnum.Update)
                {
                    //deshabilita - oculta botones y trees
                    acGastosEstimada.Enabled = false;
                    tsFuenteFinanciamientoEstimada.Enabled = false;
                    ddlMonedaEstimada.Enabled = false;
                }
            }
            //FinModificado por ALO 2018-02-07
        }

        ProyectoEtapaResult GetNewEtapa()
        {
            int id = -1;
            ProyectoEtapaResult plResult = new ProyectoEtapaResult();
            plResult.IdProyectoEtapa = id;
            plResult.IdProyecto = 0;

            return plResult;
        }

        ProyectoEtapaEstimadoResult GetNewEtapaEstimada()
        {
            int id = 0;
            if (Entity.EtapasEstimadas.Count > 0) id = Entity.EtapasEstimadas.Min(l => l.IdProyectoEtapaEstimado);
            if (id > 0) id = 0;
            id--;
            ProyectoEtapaEstimadoResult plResult = new ProyectoEtapaEstimadoResult();
            plResult.IdProyectoEtapaEstimado = id;
            plResult.IdProyectoEtapa = 0;
            plResult.IdMoneda = SolutionContext.Current.BaseCurrencyId;
            return plResult;
        }

        ProyectoEtapaEstimadoPeriodoResult GetNewEtapaEstimadaPeriodo(ProyectoEtapaEstimadoResult proyectoEtapaEstimadoResult)
        {
            int id = 0;
            if (proyectoEtapaEstimadoResult.Periodos.Count > 0) id = proyectoEtapaEstimadoResult.Periodos.Min(l => l.IdProyectoEtapaEstimadoPeriodo);
            if (id > 0) id = 0;
            id--;
            ProyectoEtapaEstimadoPeriodoResult plResult = new ProyectoEtapaEstimadoPeriodoResult();
            plResult.IdProyectoEtapaEstimadoPeriodo = id;
            //plResult.IdProyectoEtapa = 0;
            //plResult.IdMoneda = SolutionContext.Current.BaseCurrencyId;
            return plResult;
        }

        #region Methods
        public static string scrollDivEstimadas = "";
        void HidePopUpEtapasEstimadas()
        {
            ProyectoEtapaEstimadaRefresh();
            ProyectoEtapaRefresh();
            ModalPopupExtenderEtapasEstimadas.Hide();
        }
        void ProyectoEtapaEstimadaClear()
        {
            UIHelper.Clear(acGastosEstimada as IWebControlTreeSelect);
            UIHelper.Clear(tsFuenteFinanciamientoEstimada);
            UIHelper.Clear(ddlMonedaEstimada);
            ActualProyectoEtapaEstimada = GetNewEtapaEstimada();
        }
        void ProyectoEtapaEstimadaSetValue()
        {
            UIHelper.SetValue(tsFuenteFinanciamientoEstimada, ActualProyectoEtapaEstimada.IdFuenteFinanciamiento);
            UIHelper.SetValue<Moneda, int>(ddlMonedaEstimada, ActualProyectoEtapaEstimada.IdMoneda, MonedaService.Current.GetById);
            UIHelper.SetValue(acGastosEstimada as IWebControlTreeSelect, ActualProyectoEtapaEstimada.IdClasificacionGasto);
            CompletarPeriodosEstimados();
            SetearBloqueos(ActionEnum.Update);
            LoadGridPeriodosEstimados();            
        }
        void ProyectoEtapaEstimadaGetValue()
        {
            ActualProyectoEtapaEstimada.IdProyectoEtapa = ActualProyectoEtapa.IdProyectoEtapa;
            ActualProyectoEtapaEstimada.IdMoneda = UIHelper.GetInt(ddlMonedaEstimada);
            ActualProyectoEtapaEstimada.IdFuenteFinanciamiento = UIHelper.GetInt(tsFuenteFinanciamientoEstimada);
            if (tsFuenteFinanciamientoEstimada.Value != null)
            {
                ActualProyectoEtapaEstimada.FuenteFinanciamiento_Nombre = tsFuenteFinanciamientoEstimada.Value.BreadcrumbCodigo + " - " + UIHelper.GetString(tsFuenteFinanciamientoEstimada);
            }
            ActualProyectoEtapaEstimada.IdClasificacionGasto = UIHelper.GetInt(acGastosEstimada as IWebControlTreeSelect);
            ClasificacionGasto cg = ClasificacionGastoService.Current.GetById(ActualProyectoEtapaEstimada.IdClasificacionGasto);

            if (cg != null)
            {
                ActualProyectoEtapaEstimada.ClasificacionGasto_CodigoCompleto = cg.BreadcrumbCode;
                ActualProyectoEtapaEstimada.ClasificacionGasto_Nombre = cg.Nombre;
            }
        }
        void ProyectoEtapaEstimadaRefresh()
        {
            if (ActualProyectoEtapa == null)
            {
                UIHelper.Load(gridEtapasEstimadas, new List<ProyectoEtapaEstimadoResult>(), "Fecha");
                upGridEtapasEstimadas.Update();
                return;
            }

            if (Entity.ProyectoAnioCorrienteEstimado.HasValue)
                UIHelper.SetValue(ddlAnioCorrienteEstimado, Entity.ProyectoAnioCorrienteEstimado.Value);

            //Matias 20170214 - Ticket #REQ318684
            //DataTable dataTable = Entity.ToDatatableEtapasEstimadas(ActualProyectoEtapa.IdProyectoEtapa);
            Int32 t, filterAnio;
            if (Int32.TryParse(UIHelper.GetString(ddlAnioCorrienteEstimado), out t))
                filterAnio = t;
            else
                filterAnio = DateTime.Now.Year;
            DataTable dataTable = Entity.ToDatatableEtapasEstimadasDinamico(ActualProyectoEtapa.IdProyectoEtapa, filterAnio);
            //FinMatias 20170214 - Ticket #REQ318684  

            if (PlanPeriodosBloqueados == null || OrganismoTipoBloqueados == null) SetPeriodosTipoOrganismoBloqueos();
            gridEtapasEstimadas.ColumnsGenerator = new ColumnGenerator(dataTable.Columns, EnableEtapaEstimadaUpdate);

            //Matias - #REQ318684            
            //if (dataTable.Columns.Count > 6)
            //{
            //    gridEtapasEstimadas.Width = new Unit(620 + ((dataTable.Columns.Count - 2) * 52 /*Matias - #REQ318684 - orig: 80 - Matias: 52*/), UnitType.Pixel);
            //    scrollDivEstimadas = "scroll";
            //}
            //else
            //{
            //    gridEtapasEstimadas.Width = new Unit(100, UnitType.Percentage);
            //    scrollDivEstimadas = "scrollAuto";
            //}
            // Nunca va a haber mas de 6 columnas, por eso siempre va "scrollAuto" (con esta modificacion que muestra gastos dinámicamente de acuerdo al año seleccionado.
            gridEtapasEstimadas.Width = new Unit(100, UnitType.Percentage);
            scrollDivEstimadas = "scrollAuto";

            if (dataTable.Rows.Count > 20)
            {
                scrollDivEstimadas = "scrollHeight";
            }
            //FinMatias - #REQ318684


            UIHelper.Load(gridEtapasEstimadas, dataTable);

            litEtapasEstimadasTotal.Visible = false;
            if (dataTable.Rows.Count > 0)
            {
                //var totalesPorAnio = Business.ProyectoCronogramaComposeBusiness.Current.GetTotalPorAnio(new nc.ProyectoFilter() { IdProyecto = Entity.IdProyecto });
                /*var estimadoAnioActual = totalesPorAnio.Where(x => x.Anio == DateTime.Now.Year).Sum(x => x.Estimado);
                var estimadoAnioFuturo = totalesPorAnio.Where(x => x.Anio >= DateTime.Now.Year + 1).Sum(x => x.Estimado);
                var realizadoAnioAnterior = totalesPorAnio.Where(x => x.Anio <= DateTime.Now.Year - 1).Sum(x => x.Realizado);

                litEtapasEstimadasTotal.Text = "Total: " + (realizadoAnioAnterior + estimadoAnioActual + estimadoAnioFuturo).ToString("N0");*/
                litEtapasEstimadasTotal.Text = "Total: " + (from ee in Entity.EtapasEstimadas select ee.TotalEstimado).Sum().ToString("N0");
                litEtapasEstimadasTotal.Visible = true;

                if (dataTable.Columns.Count > 4)
                {
                    gridEtapasEstimadas.FooterRow.Cells[0].Text = "";
                    gridEtapasEstimadas.FooterRow.Cells[1].CssClass = "footer";
                    gridEtapasEstimadas.FooterRow.Cells[2].CssClass = "footer";
                    gridEtapasEstimadas.FooterRow.Cells[3].CssClass = "footer";
                    gridEtapasEstimadas.FooterRow.Cells[1].Text = "";
                    gridEtapasEstimadas.FooterRow.Cells[2].Text = "";
                    gridEtapasEstimadas.FooterRow.Cells[3].Text = "Totales por año";
                    gridEtapasEstimadas.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                    gridEtapasEstimadas.FooterRow.Visible = true;
                    var i = 0;
                    for (i = 4; i < dataTable.Columns.Count; i++)
                    {
                        long totalColumn = 0;
                        //for (var r = 0; r < dataTable.Rows.Count; r++)
                        foreach (GridViewRow row in gridEtapasEstimadas.Rows)
                        {
                            totalColumn += Convert.ToInt64(row.Cells[i].Text.Replace(".", string.Empty));
                        }

                        //var total = totalesPorAnio.Where(x => x.Anio == Convert.ToInt32(dataTable.Columns[i].ColumnName) ).Sum(x => x.Estimado);
                        gridEtapasEstimadas.FooterRow.Cells[i].Text = totalColumn.ToString("N0");
                        gridEtapasEstimadas.FooterRow.Cells[i].HorizontalAlign = HorizontalAlign.Right;
                        gridEtapasEstimadas.FooterRow.Cells[i].CssClass = "footer";
                    }
                    gridEtapasEstimadas.FooterRow.Cells[i].CssClass = "footer";
                    gridEtapasEstimadas.FooterRow.Cells[i].Text = "";
                }
            }

            //debo tener ambos parametros para considerarlos
            if (TipoOrganismoProyecto > 0 && PlanPeriodosBloqueados != null && OrganismoTipoBloqueados != null
                && PlanPeriodosBloqueados.Count > 0 && OrganismoTipoBloqueados.Count > 0)
            {
            
                foreach (GridViewRow row in gridEtapasEstimadas.Rows)
                {
                    foreach (TableCell cell in row.Cells)
                    {
                        var totalMount = 0.00;
                        Control controlABloquear = null;
                        if ((PlanPeriodosBloqueados.Where(x => x.AnioInicial.ToString().Equals(gridEtapasEstimadas.HeaderRow.Cells[row.Cells.GetCellIndex(cell)].Text)).Any())
                            && (OrganismoTipoBloqueados.Where(x => x.IdOrganismoTipo == TipoOrganismoProyecto).Any()))
                        {
                            //El nombre de la columna coincide con un año inicial de los planes bloqueados y a un id de tipo de organismo
                            //dataColumn.ColumnName == "2018"
                            totalMount = Double.Parse(cell.Text);
                            //deshabilita - oculta boton delete
                            foreach (Control control in row.Cells[row.Cells.Count - 1].Controls)
                            {
                                //gridEtapasEstimadas.Rows[0].Cells[6].Controls[2]
                                if (control.ID != null && control.ID.Equals("imgDelete"))
                                {
                                    //bloquear o no bloquear, esa es la cuestión
                                    control.Visible = false;
                                    controlABloquear = control;
                                }
                            }
                        }
                        if (totalMount <= 0.00 && controlABloquear != null)
                        {
                            controlABloquear.Visible = true;
                        }
                    }

                }
            }

            /*foreach (GridViewRow row in gridEtapasEstimadas.Rows)
            {
                int rowID = Int32.Parse(gridEtapasEstimadas.DataKeys[row.RowIndex][0].ToString());
                
                //Condicion de bloqueo adicional
                if (Entity.EtapasInformacionPresupuestarias.Where(e => e.ID == rowID).FirstOrDefault().Periodos.Where(x => x.MontoInicial > 0 || x.MontoVigente > 0 || x.MontoDevengado > 0).Any())
                {
                    foreach (Control control in row.Cells[row.Cells.Count - 1].Controls)
                    {
                        if (control.ID != null && control.ID.Equals("imgDelete"))
                        {
                            //bloquear o no bloquear, esa es la cuestión
                            control.Visible = false;
                        }
                    }
                }
            }*/

            upGridEtapasEstimadas.Update();
        }

        bool GridEstimadasContieneColumna(int anio)
        {
            bool retval = false;
            foreach (DataControlField dcf in gridEtapasEstimadas.Columns)
            {
                if (dcf.HeaderText == anio.ToString())
                {
                    retval = true;
                    break;
                }
            }
            return retval;

        }
        void LoadGridPeriodosEstimados()
        {
            UIHelper.Load(GridPeriodoEstimado, ActualProyectoEtapaEstimada.Periodos, "Periodo", SortDirection.Ascending, Type.GetType("System.Int32"));
            upEtapasEstimadasPopUp.Update();
        }
        void CompletarPeriodosEstimados()
        {
            Int32 anioHasta = 0;
            Int32 anioDesde = 0;
            ObtenerRangoAniosEstimadosEtapa(ref anioDesde, ref anioHasta);

            for (Int32 anio = anioDesde; anio <= anioHasta; anio++)
            {
                if (ActualProyectoEtapaEstimada.Periodos.Where(p => p.Periodo == anio).Count() == 0)
                {

                    ProyectoEtapaEstimadoPeriodoResult r = GetNewEtapaEstimadaPeriodo(ActualProyectoEtapaEstimada);
                    r.Periodo = anio;
                    ActualProyectoEtapaEstimada.Periodos.Add(r);
                }
            }
            foreach (ProyectoEtapaEstimadoPeriodoResult d in ActualProyectoEtapaEstimada.Periodos)
                d.IdMonedaProyectoEtapaEstimado = ActualProyectoEtapaEstimada.IdMoneda;
        }
        void ObtenerRangoAniosEstimadosEtapa(ref int Desde, ref int Hasta)
        {
            Desde = ActualProyectoEtapa.FechaInicioEstimada != null ? ((DateTime)ActualProyectoEtapa.FechaInicioEstimada).Year :
                   DateTime.Now.Year;
            Hasta = ActualProyectoEtapa.FechaFinEstimada != null ? ((DateTime)ActualProyectoEtapa.FechaFinEstimada).Year :
                   DateTime.Now.Year;
        }

        #endregion Methods

        #region Commands
        void CommandProyectoEtapaEstimadaEdit()
        {
            ProyectoEtapaEstimadaSetValue();
            VisibleNavigatorEstimadas(true);
            RefreshNavigatorEstimadas();
            ModalPopupExtenderEtapasEstimadas.Show();
            upEtapasEstimadasPopUp.Update();
        }

        bool ValidateEtapasEstimadas()
        {
            ProyectoEtapaEstimadaGetValue();
            GetValueGridPeriodoEstimados();
            ProyectoEtapaEstimadoResult result = (from l in Entity.EtapasEstimadas
                                                  where l.IdProyectoEtapaEstimado == ActualProyectoEtapaEstimada.ID
                                                  select l).FirstOrDefault();

            if (!ProyectoEtapaEstimadoService.Current.ValidarEtapasEstimadas(ActualProyectoEtapaEstimada, Entity, result == null ? 0 : result.IdProyectoEtapaEstimado))
            {
                UIHelper.ShowAlert(UIHelper.Translate("Datos Faltantes, Inválidos o Repetidos"), upEtapasEstimadasPopUp);
                upEtapasEstimadasPopUp.Update();
                return false;
            }

            return true;
        }

        void CommandProyectoEtapaEstimadaSave()
        {

            ProyectoEtapaEstimadoResult result = (from l in Entity.EtapasEstimadas
                                                  where l.IdProyectoEtapaEstimado == ActualProyectoEtapaEstimada.ID
                                                  select l).FirstOrDefault();

            ActualProyectoEtapaEstimada.Periodos = ActualProyectoEtapaEstimada.PeriodosUtilizados;

            if (result != null)
            {
                result.IdProyectoEtapaEstimado = ActualProyectoEtapaEstimada.IdProyectoEtapaEstimado;
                result.IdMoneda = ActualProyectoEtapaEstimada.IdMoneda;
                result.IdClasificacionGasto = ActualProyectoEtapaEstimada.IdClasificacionGasto;
                result.IdFuenteFinanciamiento = ActualProyectoEtapaEstimada.IdFuenteFinanciamiento;
                result.Periodos = ActualProyectoEtapaEstimada.Periodos;
                result.ClasificacionGasto_Codigo = ActualProyectoEtapaEstimada.ClasificacionGasto_Codigo;
                result.ClasificacionGasto_Nombre = ActualProyectoEtapaEstimada.ClasificacionGasto_Nombre;
                result.FuenteFinanciamiento_Nombre = ActualProyectoEtapaEstimada.FuenteFinanciamiento_Nombre;
                result.OrigenFinanciemiento = ActualProyectoEtapaEstimada.OrigenFinanciemiento;

                result.CodigoCompletoGasto = ActualProyectoEtapaEstimada.CodigoCompletoGasto;
                result.ObjetoGasto = ActualProyectoEtapaEstimada.ObjetoGasto;
                result.FuenteFinanciemiento = ActualProyectoEtapaEstimada.FuenteFinanciemiento;
            }
            else
            {
                Entity.EtapasEstimadas.Add(ActualProyectoEtapaEstimada);
            }
            ProyectoEtapaEstimadaClear();

        }
        void CommandProyectoEtapaEstimadaDelete()
        {
            ProyectoEtapaEstimadoResult result = (from l in Entity.EtapasEstimadas where l.IdProyectoEtapaEstimado == ActualProyectoEtapaEstimada.ID select l).FirstOrDefault();
            Entity.EtapasEstimadas.Remove(result);
            ProyectoEtapaEstimadaClear();
            ProyectoEtapaEstimadaRefresh();
            ProyectoEtapaRefresh();
        }
        #endregion

        

        #region Eventos
        protected void btSaveEtapaEstimada_Click(object sender, EventArgs e)
        {
            if (ValidateNumericFieldsEstimados() && ValidateEtapasEstimadas())
            {
                UIHelper.CallTryMethod(CommandProyectoEtapaEstimadaSave);
                HidePopUpEtapasEstimadas();
            }
        }
        protected void btNewEtapaEstimada_Click(object sender, EventArgs e)
        {
            if (ValidateNumericFieldsEstimados() && ValidateEtapasEstimadas())
            {
                UIHelper.CallTryMethod(CommandProyectoEtapaEstimadaSave);
                ProyectoEtapaEstimadaSetValue();
                RefreshNavigatorEstimadas();
            }
        }
        protected void btCancelEtapaEstimada_Click(object sender, EventArgs e)
        {
            ProyectoEtapaEstimadaClear();
            HidePopUpEtapasEstimadas();
        }
        protected void btAgregarEtapaEstimada_Click(object sender, EventArgs e)
        {

            UIHelper.SetValue(tsFuenteFinanciamientoEstimada, GetParameterIDFFTesoroNacional());
            UIHelper.SetValue<Moneda, int>(ddlMonedaEstimada, SolutionContext.Current.BaseCurrencyId, MonedaService.Current.GetById);
            CompletarPeriodosEstimados();
            SetearBloqueos(ActionEnum.Create);
            LoadGridPeriodosEstimados();
            VisibleNavigatorEstimadas(false);
            upEtapasEstimadasPopUp.Update();
            ModalPopupExtenderEtapasEstimadas.Show();
            acGastosEstimada.Focus();
        }

        protected void ddlMonedaEstimada_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ActualProyectoEtapaEstimada.IdMoneda = UIHelper.GetInt(ddlMonedaEstimada);
            foreach (ProyectoEtapaEstimadoPeriodoResult d in ActualProyectoEtapaEstimada.Periodos)
                d.IdMonedaProyectoEtapaEstimado = ActualProyectoEtapaEstimada.IdMoneda;

            if (UIHelper.GetInt(ddlMonedaEstimada) == SolutionContext.Current.BaseCurrencyId)
            {
                foreach (ProyectoEtapaEstimadoPeriodoResult d in ActualProyectoEtapaEstimada.Periodos)
                {
                    d.Cotizacion = (decimal)0;
                    d.Monto = (decimal)0;
                }
            }
            UIHelper.Clear(GridPeriodoEstimado);
            LoadGridPeriodosEstimados();
        }



        private bool ValidateNumericFieldsEstimados()
        {
            foreach (GridViewRow gvr in GridPeriodoEstimado.Rows)
            {

                Int32 idRow = Int32.Parse(GridPeriodoEstimado.DataKeys[gvr.RowIndex].Value.ToString());

                foreach (Control control in gvr.Controls)
                {
                    if (control.Controls.Count > 0 && control.Controls[1].GetType() == typeof(NumericTextBox))
                    {
                        TextBox textWC = ((TextBox)control.Controls[1]);
                        decimal valor = 0;
                        if (!decimal.TryParse(textWC.Text, out valor))
                        {
                            textWC.Focus();

                            if (textWC.ID != "txtMontoDevengado")
                            {
                                switch (textWC.ID)
                                {
                                    case "txtMonedaEstimado":
                                        {
                                            UIHelper.ShowAlert(UIHelper.Translate("Los campos de Moneda Externa contienen datos inválidos."), upEtapasEstimadasPopUp);
                                            break;
                                        }
                                    case "txtTipoCambioEstimado":
                                        {
                                            UIHelper.ShowAlert(UIHelper.Translate("Los campos de Tipo de Cambio contienen datos inválidos."), upEtapasEstimadasPopUp);
                                            break;
                                        }
                                    case "txtMontoEstimado":
                                        {
                                            UIHelper.ShowAlert(UIHelper.Translate("Los campos de Montos contienen datos inválidos."), upEtapasEstimadasPopUp);
                                            break;
                                        }
                                }
                                return false;
                            }
                        }

                    }
                }
            }
            return true;
        }

        private void GetValueGridPeriodoEstimados()
        {
            foreach (GridViewRow gvr in GridPeriodoEstimado.Rows)
            {

                Int32 idRow = Int32.Parse(GridPeriodoEstimado.DataKeys[gvr.RowIndex].Value.ToString());

                foreach (Control control in gvr.Controls)
                {
                    if (control.Controls.Count > 0 && control.Controls[1].GetType() == typeof(NumericTextBox))
                    {
                        TextBox textWC = ((TextBox)control.Controls[1]);
                        decimal valor = 0;
                        if (!decimal.TryParse(textWC.Text, out valor))
                        {
                            textWC.Focus();
                            return;
                        }
                        foreach (ProyectoEtapaEstimadoPeriodoResult d in ActualProyectoEtapaEstimada.Periodos)
                        {
                            if (d.IdProyectoEtapaEstimadoPeriodo == idRow)
                            {
                                switch (textWC.ID)
                                {
                                    case "txtMonedaEstimado":
                                        {
                                            d.Monto = valor;
                                            break;
                                        }
                                    case "txtTipoCambioEstimado":
                                        {
                                            d.Cotizacion = valor;
                                            break;
                                        }
                                    case "txtMontoEstimado":
                                        {
                                            if (d.UsaMonedaBase)
                                                d.MontoCalculado = valor;
                                            else
                                                d.MontoCalculado = d.MontoCalculadoPeriodo;
                                            break;
                                        }
                                }
                                break;
                            }
                        }
                    }
                }
            }
            UIHelper.Clear(GridPeriodoEstimado);
            LoadGridPeriodosEstimados();
        }

        #endregion

        #region EventosGrillas
        protected void GridEtapasEstimadas_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualProyectoEtapaEstimada = (from l in Entity.EtapasEstimadas where l.IdProyectoEtapaEstimado == id select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandProyectoEtapaEstimadaEdit();
                    break;
                case Command.DELETE:
                    CommandProyectoEtapaEstimadaDelete();
                    break;
            }
            RefreshNavigatorEstimadas();
        }

        /*
        protected void GridEtapasEstimadas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decimal rowTotal = Convert.ToDecimal
                            (DataBinder.Eval(e.Row.DataItem, "Amount"));
                grdTotal = grdTotal + rowTotal;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lbl = (Label)e.Row.FindControl("lblTotal");
                lbl.Text = grdTotal.ToString("c");
            }
        }*/
        #endregion

        #region Navigator
        protected void btNextEtapaEstimada_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(NextEtapaEstimada);
        }

        protected void btBackEtapaEstimada_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(BackEtapaEstimada);
        }

        protected void btVerInfoPresupuestaria_Click(object sender, EventArgs e)
        {
            //gvInfoPresupuestaria
            UIHelper.Load(gvInfoPresupuestaria, Entity.ToDatatableEtapasInformacionPresupuestariasPeriodos(ActualProyectoEtapa.IdProyectoEtapa));
            ModalPopupExtenderInfoPresupuestaria.Show();
            upInfoPresupuestariaPopUp.Update();
        }
        protected void btCerrarInfoPresupuestaria_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderInfoPresupuestaria.Hide();
        }

        protected void btLastEtapaEstimada_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(LastEtapaEstimada);
        }

        protected void btFirstEtapaEstimada_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(FirstEtapaEstimada);
        }

        private void NextEtapaEstimada()
        {
            NavigateEstapaEstimada(NavigatorAction.NextRegister);
        }
        private void BackEtapaEstimada()
        {
            NavigateEstapaEstimada(NavigatorAction.PriorRegister);
        }

        private void FirstEtapaEstimada()
        {
            NavigateEstapaEstimada(NavigatorAction.FirstRegister);
        }
        private void LastEtapaEstimada()
        {
            NavigateEstapaEstimada(NavigatorAction.LastRegister);
        }

        private void NavigateEstapaEstimada(NavigatorAction navigatorAction)
        {

            List<ProyectoEtapaEstimadoResult> peer = Entity.EtapasEstimadas.Where(i => i.IdProyectoEtapa == ActualProyectoEtapa.IdProyectoEtapa).ToList();
            Int32 idx = peer.FindIndex(i => i.IdProyectoEtapaEstimado == ActualProyectoEtapaEstimada.IdProyectoEtapaEstimado);
            if (peer.Count == 0) return;



            switch (navigatorAction)
            {

                case NavigatorAction.NextRegister:
                    ActualProyectoEtapaEstimada = peer[idx + 1];
                    break;
                case NavigatorAction.LastRegister:
                    ActualProyectoEtapaEstimada = peer.Last();
                    break;
                case NavigatorAction.PriorRegister:
                    ActualProyectoEtapaEstimada = peer[idx - 1];
                    break;
                case NavigatorAction.FirstRegister:
                    ActualProyectoEtapaEstimada = peer.First();
                    break;
                default:
                    break;
            }

            ProyectoEtapaEstimadaSetValue();
            RefreshNavigatorEstimadas();



        }

        private void RefreshNavigatorEstimadas()
        {

            List<ProyectoEtapaEstimadoResult> peer = Entity.EtapasEstimadas.Where(i => i.IdProyectoEtapa == ActualProyectoEtapa.IdProyectoEtapa).ToList();
            Int32 idx = peer.FindIndex(i => i.IdProyectoEtapaEstimado == ActualProyectoEtapaEstimada.IdProyectoEtapaEstimado);
            btFirstEtapaEstimada.Enabled = ((idx > 0) && (peer.Count > 0));
            btBackEtapaEstimada.Enabled = ((idx > 0) && (peer.Count > 0));
            btLastEtapaEstimada.Enabled = ((idx < peer.Count - 1) && (peer.Count > 0));
            btNextEtapaEstimada.Enabled = ((idx < peer.Count - 1) && (peer.Count > 0));

        }

        private void VisibleNavigatorEstimadas(bool visible)
        {
            btFirstEtapaEstimada.Visible = visible;
            btBackEtapaEstimada.Visible = visible;
            btLastEtapaEstimada.Visible = visible;
            btNextEtapaEstimada.Visible = visible;
            btNewEtapasEstimadas.Visible = !visible;
        }


        #endregion


        #endregion

        #region Sobre EtapaRealizada

        private ProyectoEtapaRealizadoResult actualProyectoEtapaRealizada;
        protected ProyectoEtapaRealizadoResult ActualProyectoEtapaRealizada
        {
            get
            {
                if (actualProyectoEtapaRealizada == null)
                {
                    if (ExistsPersist("actualProyectoEtapaRealizada"))
                        actualProyectoEtapaRealizada = ((ProyectoEtapaRealizadoResult)GetPersist("actualProyectoEtapaRealizada"));
                    else
                    {
                        actualProyectoEtapaRealizada = GetNewEtapaRealizada();
                        SetPersist("actualProyectoEtapaRealizada", actualProyectoEtapaRealizada);
                    }
                }
                return actualProyectoEtapaRealizada;
            }
            set
            {
                actualProyectoEtapaRealizada = value;
                SetPersist("actualProyectoEtapaRealizada", value);
            }
        }
        ProyectoEtapaRealizadoResult GetNewEtapaRealizada()
        {
            int id = 0;
            if (Entity.EtapasRealizadas.Count > 0) id = Entity.EtapasRealizadas.Min(l => l.IdProyectoEtapaRealizado);
            if (id > 0) id = 0;
            id--;
            ProyectoEtapaRealizadoResult plResult = new ProyectoEtapaRealizadoResult();
            plResult.IdProyectoEtapaRealizado = id;
            plResult.IdProyectoEtapa = 0;
            plResult.IdMoneda = SolutionContext.Current.BaseCurrencyId;
            return plResult;
        }

        #region Methods
        public static string scrollDivRealizadas = "";
        void HidePopUpEtapasRealizadas()
        {
            ModalPopupExtenderEtapasRealizadas.Hide();
        }
        void ProyectoEtapaRealizadaClear()
        {
            UIHelper.Clear(acGastosRealizada as IWebControlTreeSelect);
            UIHelper.Clear(tsFuenteFinanciamientoRealizada);
            UIHelper.Clear(ddlMonedaRealizada);
            //UIHelper.Clear(ddlOFinanciamientoRealizada);
            UIHelper.Clear(ddlPeriodoRealizada);
            UIHelper.Clear(tbMonedaExternaRealizada);
            UIHelper.Clear(tbMontoRealizda);
            UIHelper.Clear(tbTipoDeCambioRealizada);
            UIHelper.Clear(diFechaRealizada);
            ActualProyectoEtapaRealizada = GetNewEtapaRealizada();
        }
        void ProyectoEtapaRealizadaSetValue()
        {
            UIHelper.Clear(lblErrorEtapaRealizada);
            UIHelper.SetValue(tsFuenteFinanciamientoRealizada, ActualProyectoEtapaRealizada.IdFuenteFinanciamiento);
            //UIHelper.SetValue(ddlOFinanciamientoRealizada, ActualProyectoEtapaRealizada.IdProyectoOrigenFinanciamiento);
            if (ActualProyectoEtapaRealizada.IdMoneda.HasValue)
                UIHelper.SetValue<Moneda, int>(ddlMonedaRealizada, ActualProyectoEtapaRealizada.IdMoneda.Value, MonedaService.Current.GetById);
            UIHelper.SetValue(acGastosRealizada as IWebControlTreeSelect, ActualProyectoEtapaRealizada.IdClasificacionGasto);
            if (ActualProyectoEtapaRealizada.Periodos.Count == 1)
            {
                UIHelper.SetValue(ddlPeriodoRealizada, ActualProyectoEtapaRealizada.Periodos[0].Periodo);
                UIHelper.SetValue(diFechaRealizada, ActualProyectoEtapaRealizada.Periodos[0].Fecha);

                string monedaEx = string.Format("{0:0.#}", ActualProyectoEtapaRealizada.Periodos[0].Monto);
                UIHelper.SetValue(tbMonedaExternaRealizada, monedaEx);
                UIHelper.SetValue(tbTipoDeCambioRealizada, ActualProyectoEtapaRealizada.Periodos[0].Cotizacion, true);
                string monto = string.Format("{0:0.#}", ActualProyectoEtapaRealizada.Periodos[0].MontoCalculado);
                UIHelper.SetValue(tbMontoRealizda, monto);
            }
            ActualizarControlesMoneda(ActualProyectoEtapaRealizada.IdMoneda.Value);
        }

        private void SetPeriodosTipoOrganismoBloqueos()
        {
            //Bloquear gastos estimados ActualProyectoEtapa.IdProyecto
            var proyecto = Business.ProyectoBusiness.Current.GetList(new nc.ProyectoFilter() { IdProyecto = Entity.IdProyecto }).FirstOrDefault();
            TipoOrganismoProyecto = proyecto.SubPrograma.Programa.Saf.IdTipoOrganismo;
            if (SolutionContext.Current.ParameterManager.GetBooleanValue(BLOQUEAR_GASTOS_ESTIMADOS))
            {
                //Planes bloqueados config
                var bloquear_gastos_estimados_planes = SolutionContext.Current.ParameterManager.GetStringValue(BLOQUEAR_GASTOS_ESTIMADOS_PLANES);
                //Todos los planes
                var allPlanPeriodos = PlanPeriodoService.Current.GetList();
                var bloquear_gastos_estimados_planes_list = bloquear_gastos_estimados_planes.Replace(" ", string.Empty).Split(',').ToList();
                //Los planes bloqueados filtrando por los del config
                PlanPeriodosBloqueados = allPlanPeriodos.Where(x => bloquear_gastos_estimados_planes_list.Any(n => n.Equals(x.Nombre))).ToList();

                //Tipo organismos bloqueados config
                var bloquear_gastos_estimados_tipo_organismos = SolutionContext.Current.ParameterManager.GetStringValue(BLOQUEAR_GASTOS_ESTIMADOS_TIPO_ORGANISMOS);
                //Todos los tipos organismo
                var allOrganismoTipo = OrganismoTipoService.Current.GetList();
                var bloquear_gastos_estimados_tipo_organismos_list = bloquear_gastos_estimados_tipo_organismos.Replace(" ", string.Empty).Split(',').ToList();
                //Los tipos organismo bloqueados filtrando por los del config
                OrganismoTipoBloqueados = allOrganismoTipo.Where(x => bloquear_gastos_estimados_tipo_organismos_list.Any(n => n.Equals(x.IdOrganismoTipo.ToString()))).ToList();
            }
        }

        //Matias 20170126 - #REQ575961
        private void ActualizarVerTotales()
        {
            //List<CronogramaTotalPorAnio> listaTotalPorAnio = ProyectoCronogramaComposeService.Current.GetTotalPorAnio(new nc.ProyectoFilter() { IdProyecto = Entity.IdProyecto });

            //if (Entity.EtapasEstimadas.Count > 0 || Entity.EtapasRealizadas.Count > 0)
            //{
            //    btVerTotales.Enabled = true;
            //    //return;
            //}

            btVerTotales.Enabled = (Entity.EtapasEstimadas.Count > 0 || Entity.EtapasRealizadas.Count > 0) ? true : false;

            //btVerTotales.Enabled = (listaTotalPorAnio.Count == 0) ? false : true;            
        }
        //FinMatias 20170126 - #REQ575961

        private void ActualizarControlesMoneda(int idMoneda)
        {
            if (idMoneda == SolutionContext.Current.BaseCurrencyId)
            {
                tbMonedaExternaRealizada.Enabled = false;
                tbTipoDeCambioRealizada.Enabled = false;
                tbMontoRealizda.Enabled = true;

                UIHelper.SetValue(tbMonedaExternaRealizada, (decimal)0, true);
                UIHelper.SetValue(tbTipoDeCambioRealizada, (decimal)0, true);
            }
            else
            {
                tbMonedaExternaRealizada.Enabled = true;
                tbTipoDeCambioRealizada.Enabled = true;
                tbMontoRealizda.Enabled = false;

                CalcularMonto();
            }
        }
        void ProyectoEtapaRealizadaGetValue()
        {
            ActualProyectoEtapaRealizada.IdProyectoEtapa = ActualProyectoEtapa.IdProyectoEtapa;
            ActualProyectoEtapaRealizada.IdMoneda = UIHelper.GetInt(ddlMonedaRealizada);
            ActualProyectoEtapaRealizada.IdFuenteFinanciamiento = UIHelper.GetInt(tsFuenteFinanciamientoRealizada);

            //Matias 20170220 - Ticket #ER730336
            //ActualProyectoEtapaRealizada.FuenteFinanciamiento_Nombre = tsFuenteFinanciamientoRealizada.Value.BreadcrumbCodigo + " - " + UIHelper.GetString(tsFuenteFinanciamientoRealizada);
            ActualProyectoEtapaRealizada.FuenteFinanciamiento_Nombre = ((tsFuenteFinanciamientoRealizada.Value != null) ? tsFuenteFinanciamientoRealizada.Value.BreadcrumbCodigo : "") + " - " + UIHelper.GetString(tsFuenteFinanciamientoRealizada);
            //FinMatias 20170220 - Ticket #ER730336
            
            //Int32? OF = UIHelper.GetInt(ddlOFinanciamientoRealizada);
            //ActualProyectoEtapaRealizada.IdProyectoOrigenFinanciamiento = OF==0?null:OF;
            //if (ActualProyectoEtapaRealizada.IdProyectoOrigenFinanciamiento != null && ActualProyectoEtapaRealizada.IdProyectoOrigenFinanciamiento>0)
            //    ActualProyectoEtapaRealizada.OrigenFinanciemiento = UIHelper.GetString(ddlOFinanciamientoRealizada);

            if (ActualProyectoEtapaRealizada.Periodos.Count == 0)
            {
                ProyectoEtapaRealizadoPeriodoResult result = new ProyectoEtapaRealizadoPeriodoResult();
                result.IdProyectoEtapaRealizadoPeriodo = 0;
                result.IdProyectoEtapaRealizado = ActualProyectoEtapaRealizada.IdProyectoEtapaRealizado;
                ActualProyectoEtapaRealizada.Periodos.Add(result);
            }
            ActualProyectoEtapaRealizada.Periodos[0].Periodo = UIHelper.GetInt(ddlPeriodoRealizada);
            ActualProyectoEtapaRealizada.Periodos[0].Monto = UIHelper.GetDecimal(tbMonedaExternaRealizada);
            ActualProyectoEtapaRealizada.Periodos[0].Cotizacion = UIHelper.GetDecimal(tbTipoDeCambioRealizada);
            ActualProyectoEtapaRealizada.Periodos[0].MontoCalculado = UIHelper.GetDecimal(tbMontoRealizda);
            DateTime? dtn = UIHelper.GetDateTimeNullable(diFechaRealizada);
            ActualProyectoEtapaRealizada.Periodos[0].Fecha = dtn == null ? DateTime.MinValue : (DateTime)dtn;

            ActualProyectoEtapaRealizada.IdClasificacionGasto = UIHelper.GetInt(acGastosRealizada as IWebControlTreeSelect);

            ClasificacionGasto cg = ClasificacionGastoService.Current.GetById(ActualProyectoEtapaRealizada.IdClasificacionGasto);
            if (cg != null)
            {
                ActualProyectoEtapaRealizada.ClasificacionGasto_CodigoCompleto = cg.BreadcrumbCode;
                ActualProyectoEtapaRealizada.ClasificacionGasto_Nombre = cg.Nombre;
            }
            //ActualProyectoEtapaRealizada.OrigenFinanciemiento = ddlOFinanciamientoRealizada.SelectedValue != "" ? ddlOFinanciamientoRealizada.Text : "";
        }
        void ProyectoEtapaRealizadaRefresh()
        {
            if (ActualProyectoEtapa == null)
            {
                UIHelper.Load(gridEtapasRealizadas, new List<ProyectoEtapaRealizadoResult>(), "Fecha");
                upGridEtapasRealizadas.Update();
                return;
            }

            if (Entity.ProyectoAnioCorrienteRealizado.HasValue)
                UIHelper.SetValue(ddlAnioCorrienteRealizado, Entity.ProyectoAnioCorrienteRealizado.Value);

            //Matias 20170214 - Ticket #REQ318684
            //DataTable dataTable = Entity.ToDatatableEtapasRealizadas(ActualProyectoEtapa.IdProyectoEtapa);
            Int32 t, filterAnio;
            if (Int32.TryParse(UIHelper.GetString(ddlAnioCorrienteRealizado), out t))
                filterAnio = t;
            else
                filterAnio = DateTime.Now.Year;
            DataTable dataTable = Entity.ToDatatableEtapasRealizadasDinamico(ActualProyectoEtapa.IdProyectoEtapa, filterAnio);
            //FinMatias 20170214 - Ticket #REQ318684

            if (dataTable.Columns.Count > 6)
            {
                gridEtapasRealizadas.Width = new Unit(620 + ((dataTable.Columns.Count - 3) * 55 /*Matias - #REQ318684 - orig: 80 - Matias: 55*/), UnitType.Pixel);
                scrollDivRealizadas = "scroll";
            }
            else
            {
                gridEtapasRealizadas.Width = new Unit(100, UnitType.Percentage);
                scrollDivRealizadas = "scrollAuto";
            }
            //Matias - #REQ318684
            if (dataTable.Rows.Count > 20)
            {
                scrollDivRealizadas = "scrollHeight";
            }
            //FinMatias - #REQ318684

            gridEtapasRealizadas.ColumnsGenerator = new ColumnGenerator(dataTable.Columns, EnableEtapaRealizadaUpdate);

            //List<ProyectoOrigenFinanciamientoResult> origenesResult = ProyectoOrigenFinanciamientoService.Current.GetOrigenes(new nc.ProyectoOrigenFinanciamientoFilter() { IdProyecto = Entity.IdProyecto });
            //if (origenesResult.Count > 0)
            //    UIHelper.Load<nc.ProyectoOrigenFinanciamientoResult>(ddlOFinanciamientoRealizada, origenesResult, "Descripcion", "IdProyectoOrigenFinanciamiento", new ProyectoOrigenFinanciamientoResult() { IdProyectoOrigenFinanciamiento = 0, Prestamo_Denominacion = SolutionContext.Current.TextManager.Translate("Ninguno") });
            //else
            //    ddlOFinanciamientoRealizada.Enabled = false;

            Int32 anioHasta = 0;
            Int32 anioDesde = 0;
            ObtenerRangoAniosRealizadosEtapa(ref anioDesde, ref anioHasta);

            ddlPeriodoRealizada.Items.Clear();
            for (Int32 j = anioDesde; j <= anioHasta; j++)
                ddlPeriodoRealizada.Items.Add(new ListItem() { Value = j.ToString(), Text = j.ToString() });

            UIHelper.Load(gridEtapasRealizadas, dataTable);

            litEtapasRealizadasTotal.Visible = false;
            if (dataTable.Rows.Count > 0)
            {
                litEtapasRealizadasTotal.Text = "Total: " + (from ee in Entity.EtapasRealizadas select ee.TotalRealizado).Sum().ToString("N0");
                litEtapasRealizadasTotal.Visible = true;
            }

            if (dataTable.Rows.Count > 0)
            {
                if (dataTable.Columns.Count > 5)
                {
                    var totalesPorAnio = Business.ProyectoCronogramaComposeBusiness.Current.GetTotalPorAnio(new nc.ProyectoFilter() { IdProyecto = Entity.IdProyecto });
                    gridEtapasRealizadas.FooterRow.Cells[0].Text = "";
                    gridEtapasRealizadas.FooterRow.Cells[1].Text = "";
                    gridEtapasRealizadas.FooterRow.Cells[2].Text = "";
                    gridEtapasRealizadas.FooterRow.Cells[3].Text = "";
                    gridEtapasRealizadas.FooterRow.Cells[1].CssClass = "footer";
                    gridEtapasRealizadas.FooterRow.Cells[2].CssClass = "footer";
                    gridEtapasRealizadas.FooterRow.Cells[3].CssClass = "footer";
                    gridEtapasRealizadas.FooterRow.Cells[4].CssClass = "footer";
                    gridEtapasRealizadas.FooterRow.Cells[4].Text = "Totales por año";
                    gridEtapasRealizadas.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                    gridEtapasRealizadas.FooterRow.Visible = true;
                    var i = 0;
                    for (i = 5; i < dataTable.Columns.Count; i++)
                    {
                        long totalColumn = 0;
                        //for (var r = 0; r < dataTable.Rows.Count; r++)
                        foreach (GridViewRow row in gridEtapasRealizadas.Rows)
                        {
                            totalColumn += Convert.ToInt64(row.Cells[i].Text.Replace(".", string.Empty));
                        }
                        //var total = totalesPorAnio.Where(x => x.Anio == Convert.ToInt32(dataTable.Columns[i].ColumnName)).Sum(x => x.Realizado);
                        gridEtapasRealizadas.FooterRow.Cells[i].Text = totalColumn.ToString("N0");
                        gridEtapasRealizadas.FooterRow.Cells[i].HorizontalAlign = HorizontalAlign.Right;
                        gridEtapasRealizadas.FooterRow.Cells[i].CssClass = "footer";
                    }
                    gridEtapasRealizadas.FooterRow.Cells[i].CssClass = "footer";
                    gridEtapasRealizadas.FooterRow.Cells[i].Text = "";
                }
            }

            upGridEtapasRealizadas.Update();
        }

        void ObtenerRangoAniosRealizadosEtapa(ref int Desde, ref int Hasta)
        {
            Desde = ActualProyectoEtapa.FechaInicioRealizada != null ? ((DateTime)ActualProyectoEtapa.FechaInicioRealizada).Year :
                   ActualProyectoEtapa.FechaInicioRealizada != null ? ((DateTime)ActualProyectoEtapa.FechaInicioRealizada).Year :
                   DateTime.Now.Year;
            Hasta = ActualProyectoEtapa.FechaFinRealizada != null ? ((DateTime)ActualProyectoEtapa.FechaFinRealizada).Year :
                   ActualProyectoEtapa.FechaFinRealizada != null ? ((DateTime)ActualProyectoEtapa.FechaFinRealizada).Year :
                   DateTime.Now.Year;
        }
        private void CalcularMonto()
        {
            decimal monto = UIHelper.GetDecimal(tbMonedaExternaRealizada);
            decimal cotizacion = UIHelper.GetDecimal(tbTipoDeCambioRealizada);
            UIHelper.SetValue(tbMontoRealizda, monto * cotizacion);
            if (monto == 0) tbMonedaExternaRealizada.Focus();
            else if (cotizacion == 0) tbTipoDeCambioRealizada.Focus();
        }
        #endregion Methods

        #region Commands
        void CommandProyectoEtapaRealizadaEdit()
        {
            ProyectoEtapaRealizadaSetValue();
            ModalPopupExtenderEtapasRealizadas.Show();
            upEtapasRealizadasPopUp.Update();
        }
        void CommandProyectoEtapaRealizadaSave()
        {
            ProyectoEtapaRealizadaGetValue();
            ProyectoEtapaRealizadoResult result = (from l in Entity.EtapasRealizadas
                                                   where l.IdProyectoEtapaRealizado == ActualProyectoEtapaRealizada.ID
                                                   select l).FirstOrDefault();

            if (ProyectoEtapaRealizadoService.Current.ValidarEtapasRealizadas(ActualProyectoEtapaRealizada, Entity, result == null ? 0 : result.IdProyectoEtapaRealizado))
            {
                if (result != null)
                {
                    result.IdProyectoEtapaRealizado = ActualProyectoEtapaRealizada.IdProyectoEtapaRealizado;
                    result.IdMoneda = ActualProyectoEtapaRealizada.IdMoneda;
                    result.IdClasificacionGasto = ActualProyectoEtapaRealizada.IdClasificacionGasto;
                    //result.IdProyectoOrigenFinanciamiento = ActualProyectoEtapaRealizada.IdProyectoOrigenFinanciamiento;
                    result.IdFuenteFinanciamiento = ActualProyectoEtapaRealizada.IdFuenteFinanciamiento;
                    result.Periodos = ActualProyectoEtapaRealizada.Periodos;
                    result.ClasificacionGasto_Codigo = ActualProyectoEtapaRealizada.ClasificacionGasto_Codigo;
                    result.ClasificacionGasto_Nombre = ActualProyectoEtapaRealizada.ClasificacionGasto_Nombre;
                    result.FuenteFinanciamiento_Nombre = ActualProyectoEtapaRealizada.FuenteFinanciamiento_Nombre;
                    result.OrigenFinanciemiento = ActualProyectoEtapaRealizada.OrigenFinanciemiento;

                    result.CodigoCompletoGasto = ActualProyectoEtapaRealizada.CodigoCompletoGasto;
                    result.ObjetoGasto = ActualProyectoEtapaRealizada.ObjetoGasto;
                    result.FuenteFinanciemiento = ActualProyectoEtapaRealizada.FuenteFinanciemiento;
                }
                else
                {
                    Entity.EtapasRealizadas.Add(ActualProyectoEtapaRealizada);
                }
                ProyectoEtapaRealizadaClear();
                ProyectoEtapaRealizadaRefresh();
                ProyectoEtapaRefresh();
            }
            else
            {
                string error = "Datos Faltantes, Inválidos o la fecha no concuerda con el periodo";
                UIHelper.SetValue(lblErrorEtapaRealizada, SolutionContext.Current.TextManager.Translate(error));
                UIHelper.ShowAlert(error, upEtapasRealizadasPopUp);
            }
        }
        void CommandProyectoEtapaRealizadaDelete()
        {
            ProyectoEtapaRealizadoResult result = (from l in Entity.EtapasRealizadas where l.IdProyectoEtapaRealizado == ActualProyectoEtapaRealizada.ID select l).FirstOrDefault();
            Entity.EtapasRealizadas.Remove(result);
            ProyectoEtapaRealizadaClear();
            ProyectoEtapaRealizadaRefresh();
            ProyectoEtapaRefresh();
        }
        #endregion

        #region Eventos
        protected void btSaveEtapaRealizada_Click(object sender, EventArgs e)
        {
            UIHelper.SetValue(lblErrorEtapaRealizada, "");
            UIHelper.CallTryMethod(CommandProyectoEtapaRealizadaSave);
            if (UIHelper.GetString(lblErrorEtapaRealizada) == String.Empty)
            { 
                HidePopUpEtapasRealizadas();
            }
        }
        protected void btNewEtapaRealizada_Click(object sender, EventArgs e)
        {
            UIHelper.SetValue(lblErrorEtapaRealizada, "");
            UIHelper.CallTryMethod(CommandProyectoEtapaRealizadaSave);
            if (UIHelper.GetString(lblErrorEtapaRealizada) == String.Empty)
            {
                UIHelper.Clear(lblErrorEtapaRealizada);

                //GetParameterIDFFTesoroNacional();
                //FuenteFinanciamientoService.Current.GetById();
                UIHelper.SetValue(tsFuenteFinanciamientoRealizada, GetParameterIDFFTesoroNacional());
                UIHelper.SetValue<Moneda, int>(ddlMonedaRealizada, SolutionContext.Current.BaseCurrencyId, MonedaService.Current.GetById);

                ActualizarControlesMoneda(UIHelper.GetInt(ddlMonedaRealizada)); //Matias 20140121 - Tarea 107
            }
        }
        protected void btCancelEtapaRealizada_Click(object sender, EventArgs e)
        {
            ProyectoEtapaRealizadaClear();
            ProyectoEtapaRealizadaRefresh();
            ProyectoEtapaRefresh();
            HidePopUpEtapasRealizadas();
        }
        protected void btAgregarEtapaRealizada_Click(object sender, EventArgs e)
        {
            UIHelper.SetValue(lblErrorEtapaRealizada, "");

            UIHelper.SetValue(tsFuenteFinanciamientoRealizada, GetParameterIDFFTesoroNacional());
            //UIHelper.SetValue<FuenteFinanciamiento,int>(ddlFFinanciamientoRealizada, GetParameterIDFFTesoroNacional(),FuenteFinanciamientoService.Current.GetById);
            UIHelper.SetValue<Moneda, int>(ddlMonedaRealizada, SolutionContext.Current.BaseCurrencyId, MonedaService.Current.GetById);
            upEtapasRealizadasPopUp.Update();
            ModalPopupExtenderEtapasRealizadas.Show();
            acGastosRealizada.Focus();

            //Matias 20140121 - Tarea 107
            ActualizarControlesMoneda(UIHelper.GetInt(ddlMonedaRealizada));
            //FinMatias 20140121 - Tarea 107
        }
        

        protected void ddlMonedaRealizada_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarControlesMoneda(UIHelper.GetInt(ddlMonedaRealizada));
        }
        protected void tbTipoDeCambioRealizada_OnTextChanged(object sender, EventArgs e)
        {
            CalcularMonto();
        }
        #region Old
        //protected void rbPorCodigoRealizada_OnCheckedChanged(object sender, EventArgs e)
        //{
        //    //if (rbPorCodigoRealizada.Checked)
        //    //{
        //    //    acGastosRealizada.ServiceMethod = "GetCalificacionGastoPorCodigo";
        //    //    acGastosRealizada.MinimumPrefixLength= 2;
        //    //}
        //    //else
        //    //{
        //    //    acGastosRealizada.ServiceMethod = "GetCalificacionGastoPorDescripcion";
        //    //    acGastosRealizada.MinimumPrefixLength = 4;
        //    //}

        //    //acGastosRealizada.ValueText = "";
        //    //acGastosRealizada.Focus();
        //}

        //private void AutocompletePostBackRealizada(object sender, EventArgs e)
        //{
        //    //ActualProyectoEtapaRealizada.IdClasificacionGasto = ((acGastosRealizada.IsSelectionItemPostBack) ? (int)acGastosRealizada.SelecttedValue.ID : 0);

        //    //ClasificacionGasto cg = ClasificacionGastoService.Current.GetById(ActualProyectoEtapaRealizada.IdClasificacionGasto);
        //    //ActualProyectoEtapaRealizada.ClasificacionGasto_Codigo = cg.Codigo;
        //    //ActualProyectoEtapaRealizada.ClasificacionGasto_Nombre = cg.Nombre;
        //    //ActualProyectoEtapaRealizada.OrigenFinanciemiento = ddlOFinanciamientoRealizada.SelectedValue != "" ? ddlOFinanciamientoRealizada.Text : "";
        //}
        #endregion
        #endregion

        #region EventosGrillas

        protected void GridEtapasRealizadas_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualProyectoEtapaRealizada = (from l in Entity.EtapasRealizadas where l.IdProyectoEtapaRealizado == id select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandProyectoEtapaRealizadaEdit();
                    break;
                case Command.DELETE:
                    CommandProyectoEtapaRealizadaDelete();
                    break;
            }
        }

        protected virtual void GridEtapasRealizadas_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridEtapasRealizadas.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridEtapasRealizadas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridEtapasRealizadas.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }

        #endregion

        #endregion EtapaRealizada






        #region Permissions


        #region Properties
        private bool? enableEtapaEstimadaUpdate;
        public bool EnableEtapaEstimadaUpdate
        {
            get
            {
                if (enableEtapaEstimadaUpdate.HasValue == false)
                {
                    if (ViewState["enableEtapaEstimadaUpdate"] != null)
                        enableEtapaEstimadaUpdate = (bool)ViewState["enableEtapaEstimadaUpdate"];
                    else
                        enableEtapaEstimadaUpdate = false;
                }
                return enableEtapaEstimadaUpdate.Value;
            }
            set
            {
                enableEtapaEstimadaUpdate = value;
                ViewState["enableEtapaEstimadaUpdate"] = enableEtapaEstimadaUpdate;
            }
        }
        private bool? enableEtapaRealizadaUpdate;
        public bool EnableEtapaRealizadaUpdate
        {
            get
            {
                if (enableEtapaRealizadaUpdate.HasValue == false)
                {
                    if (ViewState["enableEtapaRealizadaUpdate"] != null)
                        enableEtapaRealizadaUpdate = (bool)ViewState["enableEtapaRealizadaUpdate"];
                    else
                        enableEtapaRealizadaUpdate = false;
                }
                return enableEtapaRealizadaUpdate.Value;
            }
            set
            {
                enableEtapaRealizadaUpdate = value;
                ViewState["enableEtapaRealizadaUpdate"] = enableEtapaRealizadaUpdate;
            }
        }
        #endregion


        protected void SetPermissions()
        {
            if (CrudAction == CrudActionEnum.Create)
            {
                EnableEtapaEstimadaUpdate = true;
                EnableEtapaRealizadaUpdate = true;
            }
            else if (CrudAction == CrudActionEnum.Read)
            {
                EnableEtapaEstimadaUpdate = false;
                EnableEtapaRealizadaUpdate = false;
            }
            else
            {
                EnableEtapaEstimadaUpdate = CanByOffice(SistemaEntidadConfig.PROYECTO_ETAPA_ESTIMADO, Entity.Proyecto.PerfilOficinas, ActionConfig.UPDATE, Entity.Proyecto.IdEstado);
                EnableEtapaRealizadaUpdate = CanByOffice(SistemaEntidadConfig.PROYECTO_ETAPA_REALIZADO, Entity.Proyecto.PerfilOficinas, ActionConfig.UPDATE, Entity.Proyecto.IdEstado);
            }

            //this.gridEtapas.Enabled = EnableEtapaEstimadaUpdate; //Matias 20170210 - Ticket #REQ768159 - Creado y comentado por Matias - Rollback de tarea

            this.btAgregarEtapaEstimada.Enabled = this.btAgregarEtapaEstimada.Enabled && EnableEtapaEstimadaUpdate;
            this.btSaveEtapasEstimadas.Enabled = EnableEtapaEstimadaUpdate;
            this.btNewEtapasEstimadas.Enabled = EnableEtapaEstimadaUpdate;

            this.btAgregarEtapaRealizada.Enabled = this.btAgregarEtapaRealizada.Enabled && EnableEtapaRealizadaUpdate;
            this.btSaveEtapasRealizadas.Enabled = EnableEtapaRealizadaUpdate;
            this.btNewEtapasRealizadas.Enabled = EnableEtapaRealizadaUpdate;

        }
        #endregion

        #region Eventos Totales
        protected void btVerTotales_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderTotales.Show();
            UIHelper.Load(gvTotales, ProyectoCronogramaComposeService.Current.GetTotalPorAnio(new nc.ProyectoFilter() { IdProyecto = Entity.IdProyecto }));

            upTotalesPopUp.Update();
        }

        protected void btCancelTotales_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderTotales.Hide();
        }

        protected void gvTotales_Sorting(object sender, EventArgs e)
        {

        }
        #endregion


        private enum NavigatorAction
        {
            NextRegister,
            LastRegister,
            PriorRegister,
            FirstRegister

        }





    }
}
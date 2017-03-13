using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc = Contract;
using Service;
using System.Data;
using System.Collections;

namespace UI.Web
{
    #region GridView
    public class ColumnGeneratorCalidad : IAutoFieldGenerator
    {
        private DataColumnCollection DataColumns;
        public ColumnGeneratorCalidad(DataColumnCollection dataColumns)
        {
            this.DataColumns = dataColumns;
        }
        public ICollection GenerateFields(Control control)
        {
            DataControlFieldCollection columns = new DataControlFieldCollection();
            foreach (DataColumn dataColumn in this.DataColumns)
            {
                if (dataColumn.ColumnName == "ID") continue;

                Int32 t = 0;
                BoundField bf = new BoundField() { DataField = dataColumn.ColumnName, HeaderText = dataColumn.ColumnName };
                if (Int32.TryParse(dataColumn.ColumnName, out t))
                    bf.ItemStyle.HorizontalAlign = HorizontalAlign.Right;

                if (columns.Count == 0)
                {
                    double ancho = Math.Max(30, 100 - (this.DataColumns.Count * 10));
                    bf.ItemStyle.Width = new Unit(ancho, UnitType.Percentage);
                }
                if (columns.Count == 1)
                    bf.ItemStyle.Width = new Unit(5, UnitType.Percentage);
                if (columns.Count > 1)
                    bf.ItemStyle.Width = new Unit(10, UnitType.Percentage);

                columns.Add(bf);
            }
            return columns;
        }
    }
    #endregion

    public partial class AdministracionCalidadEdit : WebControlEdit<nc.ProyectoCalidadCompose>
    {
        #region Override WebControlEdit
        protected override void _Initialize()
        {
            base._Initialize();

            ddlTipoProyectoActual.Width = 310;
            ddlTipoProyectoSugerido.Width = 310;

            ddlEstadoActual.Width = 310;
            ddlEstadoSugerido.Width = 310;

            ddlProcesoActual.Width = 310;
            ddlProcesoSugerido.Width = 310;

            toFinalidadActual.Width = 310;
            toFinalidadSugerido.Width = 400;

            toFinalidadSugerido.RequiredMessage = TranslateFormat("FieldIsNull", "Finalidad Función Padre");
            UIHelper.Load<nc.ProyectoTipo>(ddlTipoProyectoSugerido, ProyectoTipoService.Current.GetList(new nc.ProyectoTipoFilter() { Activo = true, }), "Nombre", "IdProyectoTipo", new ProyectoTipo() { IdProyectoTipo = 0, Nombre = "Seleccione Uno" });
            UIHelper.Load<nc.Estado>(ddlEstadoSugerido, EstadoService.Current.GetList(new nc.EstadoFilter() { Activo = true, IdSistemaEntidad = (int)SistemaEntidadEnum.Proyecto }), "Nombre", "IdEstado", new Estado() { IdEstado = 0, Nombre = "Seleccione Uno" }, true, "Orden");
            toFinalidadActual.PnControl = pnlFinalidadActual;
        }

        public override void Clear()
        {
            UIHelper.Clear(tbDenominacionSugerido);
            UIHelper.Clear(tbDenominacionOriginalSugerido);
            UIHelper.Clear(ddlTipoProyectoSugerido);
            UIHelper.Clear(ddlEstadoSugerido);
            UIHelper.Clear(toFinalidadSugerido);
            UIHelper.Clear(dlProvinciasC);
            UIHelper.Clear(dlProvinciasD);
            UIHelper.Clear(ddlEstadoCalidad);
            UIHelper.Clear(diFecha);
            UIHelper.Clear(tbComentario);
            UIHelper.ClearItems(ddlProcesoSugerido);
        }
        public override void GetValue()
        {
            Entity.AdministrandoCalidad = true;

            Entity.CalidadSugerida.DenominacionOK = UIHelper.GetBoolean(cbAceptadoDenominacion);
            Entity.CalidadSugerida.ProyectoTipoOk = UIHelper.GetBoolean(cbAceptadoTipoProyecto);
            Entity.CalidadSugerida.EstadoSugeridoOK = UIHelper.GetBoolean(cbAceptadoEstado);
            Entity.CalidadSugerida.ProcesoOk = UIHelper.GetBoolean(cbAceptadoProceso);
            Entity.CalidadSugerida.FinalidadFuncionOk = UIHelper.GetBoolean(cbAceptadoFinalidad);
            Entity.CalidadSugerida.LocalizacionOK = UIHelper.GetBoolean(cbAceptadoLocalizacion);

            // Aceptar los valores Sugeridos
            Entity.CalidadSugerida.IdProyectoTipo = UIHelper.GetIntNullable(ddlTipoProyectoSugerido);
            if (((Entity.CalidadSugerida.IdProyectoTipo.HasValue && Entity.CalidadSugerida.IdProyectoTipo.Value == 0) || !Entity.CalidadSugerida.IdProyectoTipo.HasValue) && Entity.CalidadSugerida.ProyectoTipoOk)
                Entity.CalidadSugerida.IdProyectoTipo = Entity.CalidadActual.IdProyectoTipo;

            Entity.CalidadSugerida.IdEstadoSugerido = UIHelper.GetIntNullable(ddlEstadoSugerido);
            if (((Entity.CalidadSugerida.IdEstadoSugerido.HasValue && Entity.CalidadSugerida.IdEstadoSugerido.Value == 0) || !Entity.CalidadSugerida.IdEstadoSugerido.HasValue) && Entity.CalidadSugerida.EstadoSugeridoOK)
                Entity.CalidadSugerida.IdEstadoSugerido = Entity.CalidadActual.IdEstadoSugerido;

            Entity.CalidadSugerida.IdProceso = UIHelper.GetIntNullable(ddlProcesoSugerido);
            if (((Entity.CalidadSugerida.IdProceso.HasValue && Entity.CalidadSugerida.IdProceso == 0) || !Entity.CalidadSugerida.IdProceso.HasValue) && Entity.CalidadSugerida.ProcesoOk)
                Entity.CalidadSugerida.IdProceso = Entity.CalidadActual.IdProceso;

            Entity.CalidadSugerida.IdClasificacionFuncional = UIHelper.GetIntNullable(toFinalidadSugerido);
            if ((Entity.CalidadSugerida.IdClasificacionFuncional == null ||
                 Entity.CalidadSugerida.IdClasificacionFuncional == 0) && Entity.CalidadSugerida.FinalidadFuncionOk)
                Entity.CalidadSugerida.IdClasificacionFuncional = Entity.CalidadActual.IdClasificacionFuncional;

            Entity.CalidadSugerida.DenominacionSugerida = UIHelper.GetString(tbDenominacionSugerido);
            if ((Entity.CalidadSugerida.DenominacionSugerida == null ||
                 Entity.CalidadSugerida.DenominacionSugerida == "") && Entity.CalidadSugerida.DenominacionOK)
                Entity.CalidadSugerida.DenominacionSugerida = Entity.CalidadActual.DenominacionSugerida;

            if (Entity.CalidadSugerida.IdProyectoCalidad == 0)
                Entity.CalidadSugerida.DenominacionOriginal = UIHelper.GetString(tbDenominacionOriginalSugerido);

            Entity.CalidadSugerida.IdEstado = UIHelper.GetInt(ddlEstadoCalidad);
            Entity.CalidadSugerida.FechaEstado = UIHelper.GetDateTimeNullable(diFecha);
            if (Entity.CalidadSugerida.FechaEstado == null)
                Entity.CalidadSugerida.FechaEstado = DateTime.Now;
            Entity.CalidadSugerida.Comenatrio = UIHelper.GetString(tbComentario);
            Entity.CalidadSugerida.ReqDictamen = UIHelper.GetBoolean(cbRequiereDictamen);

            #region TOMAR INFO PROVINCIAS

            List<ProyectoCalidadLocalizacionResult> auxList = new List<ProyectoCalidadLocalizacionResult>();
            foreach (DataListItem dli in dlProvinciasC.Items)
            {
                CheckBox a = ((CheckBox)dli.FindControl("chkC"));
                if (a.Checked)
                {
                    ProyectoCalidadLocalizacionResult pclNew = new ProyectoCalidadLocalizacionResult();
                    pclNew.IdClasificacionGeografica = Int32.Parse(((HiddenField)dli.FindControl("hdValueC")).Value);
                    pclNew.IdProyectoCalidadLocalizacion = (from l in Entity.localizacionesSugerida where l.IdClasificacionGeografica == pclNew.IdClasificacionGeografica select l.IdProyectoCalidadLocalizacion).SingleOrDefault();
                    pclNew.IdProyectoCalidad = Entity.CalidadSugerida.IdProyectoCalidad;
                    auxList.Add(pclNew);
                }
            }
            foreach (DataListItem dli in dlProvinciasD.Items)
            {
                CheckBox a = ((CheckBox)dli.FindControl("chkD"));
                if (a.Checked)
                {
                    ProyectoCalidadLocalizacionResult pclNew = new ProyectoCalidadLocalizacionResult();
                    pclNew.IdClasificacionGeografica = Int32.Parse(((HiddenField)dli.FindControl("hdValueD")).Value);
                    pclNew.IdProyectoCalidadLocalizacion = (from l in Entity.localizacionesSugerida where l.IdClasificacionGeografica == pclNew.IdClasificacionGeografica select l.IdProyectoCalidadLocalizacion).SingleOrDefault();
                    pclNew.IdProyectoCalidad = Entity.CalidadSugerida.IdProyectoCalidad;
                    auxList.Add(pclNew);
                }
            }

            if (auxList.Count == 0 && Entity.CalidadSugerida.LocalizacionOK)
            {
                // Si no marco ninguna provincia, pero puso OK localización, copia los originales
                foreach (DataListItem dli in dlProvinciasA.Items)
                {
                    CheckBox a = ((CheckBox)dli.FindControl("chkA"));
                    if (a.Checked)
                    {
                        ProyectoCalidadLocalizacionResult pclNew = new ProyectoCalidadLocalizacionResult();
                        pclNew.IdClasificacionGeografica = Int32.Parse(((HiddenField)dli.FindControl("hdValueA")).Value);
                        pclNew.IdProyectoCalidadLocalizacion = 0;
                        pclNew.IdProyectoCalidad = Entity.CalidadSugerida.IdProyectoCalidad;
                        auxList.Add(pclNew);
                    }
                }
                foreach (DataListItem dli in dlProvinciasB.Items)
                {
                    CheckBox a = ((CheckBox)dli.FindControl("chkB"));
                    if (a.Checked)
                    {
                        ProyectoCalidadLocalizacionResult pclNew = new ProyectoCalidadLocalizacionResult();
                        pclNew.IdClasificacionGeografica = Int32.Parse(((HiddenField)dli.FindControl("hdValueB")).Value);
                        pclNew.IdProyectoCalidadLocalizacion = 0;
                        pclNew.IdProyectoCalidad = Entity.CalidadSugerida.IdProyectoCalidad;
                        auxList.Add(pclNew);
                    }
                }
            }

            Entity.localizacionesSugerida = auxList;

            #endregion
        }
        public override void SetValue()
        {
            #region Detalle Final
            // CARGA LAS GRILLAS FINALES
            decimal MTE = 0;
            decimal MTR = 0;
            DetalleCalidadCompose datos = ProyectoCalidadComposeService.Current.GetDetalleCalidad(Entity.IdProyecto);
            DataTable dataTableEST = Entity.ToDatatableResumenEtapasEstimadas(Entity.IdProyecto, datos, ref MTE);
            DataTable dataTableREA = Entity.ToDatatableResumenEtapasRealizadas(Entity.IdProyecto, datos, ref MTR);
            gridEtapasEstimadas.ColumnsGenerator = new ColumnGeneratorCalidad(dataTableEST.Columns);
            gridEtapasRealizadas.ColumnsGenerator = new ColumnGeneratorCalidad(dataTableREA.Columns);
            //UIHelper.Load(gridProyectoPrioridad, datos.Prioridades);
            UIHelper.Load(gridEtapasEstimadas, dataTableEST);
            UIHelper.Load(gridEtapasRealizadas, dataTableREA);
            Decimal MontoEstimado = Math.Round(MTE, 0);
            UIHelper.SetValue(lbMontoEstimado, MontoEstimado.ToString("N0"));
            Decimal MontoRealizado = Math.Round(MTR, 0);
            UIHelper.SetValue(lbMontoRealizado, MontoRealizado.ToString("N0"));

            UIHelper.SetValue(tbUltPlan, datos.UltimoPlan);
            UIHelper.SetValue(tbDictamen, datos.Dictamen);
            UIHelper.SetValue(tbPrioOrganismo, datos.PrioridadOrganismo);
            UIHelper.SetValue(tbPrioOrganismoNro, datos.SubPrioridad);
            UIHelper.SetValue(cbArt15, datos.Art15);
            UIHelper.SetValue(tbUltPriorizacion, datos.UltPriorizacion);
            UIHelper.SetValue(tbPrioPeriodo, datos.UltPrioPeriodo);

            #endregion

            #region General

            if (Entity.CalidadSugerida.IdProyectoCalidad == 0)
            {
                Entity.CalidadSugerida.DenominacionOriginal = Entity.CalidadActual.DenominacionSugerida;
                //UIHelper.Load<nc.ProyectoTipoResult>(ddlTipoProyectoSugerido, ProyectoTipoService.Current.GetResult(new nc.ProyectoTipoFilter() { Activo = true, }), "Nombre", "IdProyectoTipo", new ProyectoTipoResult() { IdProyectoTipo = 0, Nombre = "Seleccione Uno"});
                //UIHelper.Load<nc.EstadoResult>(ddlEstadoSugerido, EstadoService.Current.GetResult(new nc.EstadoFilter() { Activo = true, IdSistemaEntidad = (int)SistemaEntidadEnum.Proyecto }), "Nombre", "IdEstado", new EstadoResult() { IdEstado = 0, Nombre = "Seleccione Uno" },true,"Orden");
                //UIHelper.Load<nc.ProcesoResult>(ddlProcesoSugerido, ProcesoService.Current.GetResult(new nc.ProcesoFilter() { Activo = true }), "Nombre", "IdProceso", new ProcesoResult() { IdProceso = 0, Nombre = "Seleccione Uno" });
            }
            //else
            //{
            //    UIHelper.Load<nc.ProyectoTipoResult>(ddlTipoProyectoSugerido, ProyectoTipoService.Current.GetResult(new nc.ProyectoTipoFilter() { Activo = true, }), "Nombre", "IdProyectoTipo");
            //    UIHelper.Load<nc.EstadoResult>(ddlEstadoSugerido, EstadoService.Current.GetResult(new nc.EstadoFilter() { Activo = true, IdSistemaEntidad = (int)SistemaEntidadEnum.Proyecto }), "Nombre", "IdEstado");
            //    UIHelper.Load<nc.ProcesoResult>(ddlProcesoSugerido, ProcesoService.Current.GetResult(new nc.ProcesoFilter() { Activo = true }), "Nombre", "IdProceso");
            //}

            // Combos de Tipos de Proyecto

            UIHelper.Load<nc.ProyectoTipo>(ddlTipoProyectoActual, ProyectoTipoService.Current.GetList(new nc.ProyectoTipoFilter() { Activo = true, IdProyectoTipo = Entity.CalidadActual.IdProyectoTipo }), "Nombre", "IdProyectoTipo");
            CargarTipoProcesoSugerido();


            // Combos de Estados de Proyecto
            UIHelper.Load<nc.Estado>(ddlEstadoActual, EstadoService.Current.GetList(new nc.EstadoFilter() { Activo = true, IdSistemaEntidad = (int)SistemaEntidadEnum.Proyecto, IdEstado = Entity.CalidadActual.IdEstadoSugerido }), "Nombre", "IdEstado", "Orden", SortDirection.Ascending);
            CargarEstadoSugerido();

            // Combos de proceso
            CargarProceso();
            UIHelper.Load<nc.Proceso>(ddlProcesoActual, ProcesoService.Current.GetList(new nc.ProcesoFilter() { Activo = true, IdProceso = Entity.CalidadActual.IdProceso }), "Nombre", "IdProceso");
            CargarProcesoSugerido();

            // Combos de Finalidad Funcion

            UIHelper.SetValue(toFinalidadActual, Entity.CalidadActual.IdClasificacionFuncional);
            CargarFinalidadSugerida();


            // Text Denominacion
            UIHelper.SetValue(tbDenominacionActual, Entity.CalidadActual.DenominacionSugerida);
            CargarDenominacionSugerida();

            // Estado            
            UIHelper.Load<nc.Estado>(ddlEstadoCalidad, EstadoService.Current.GetList(new nc.EstadoFilter() { Activo = true, IdSistemaEntidad = (int)SistemaEntidadEnum.Proyecto_Calidad, OrderByProperty = "Orden" }), "Nombre", "IdEstado", SortDirection.Ascending);

            UIHelper.SetValue(diFecha, Entity.CalidadSugerida.FechaEstado);

            if (Entity.CalidadSugerida.IdEstado > 0)
                UIHelper.SetValue<Estado, int>(ddlEstadoCalidad, Entity.CalidadSugerida.IdEstado, EstadoService.Current.GetById);
            else
            {
                UIHelper.SetValue<Estado, int>(ddlEstadoCalidad, (Int32)EstadoEnum.Pendiente, EstadoService.Current.GetById);
                UIHelper.SetValue(diFecha, DateTime.Now);
            }

            //Req
            UIHelper.SetValue(cbRequiereDictamen, Entity.CalidadSugerida.ReqDictamen);
            //Fecha


            //Comentario
            UIHelper.SetValue(tbComentario, Entity.CalidadSugerida.Comenatrio);
            #endregion

            #region Checks Ok
            cbAceptadoDenominacion.Checked = Entity.CalidadSugerida.DenominacionOK;
            cbAceptadoEstado.Checked = Entity.CalidadSugerida.EstadoSugeridoOK;
            cbAceptadoFinalidad.Checked = Entity.CalidadSugerida.FinalidadFuncionOk;
            cbAceptadoProceso.Checked = Entity.CalidadSugerida.ProcesoOk;
            cbAceptadoTipoProyecto.Checked = Entity.CalidadSugerida.ProyectoTipoOk;
            cbAceptadoLocalizacion.Checked = Entity.CalidadSugerida.LocalizacionOK;
            #endregion

            CargarLocalizacion();


            tbDenominacionSugerido.Focus();
            upCalidad.Update();
            //Matias 20140218 - Tarea 115
            upHojaDeCalidad.Update();
            upEtapaEstimada.Update();
            upEtapaRealizada.Update();
            //upPriorizacion.Update();
            //FinMatias 20140218 - Tarea 115
        }
        #endregion Override

        #region Eventos
        protected void lnk_Command(object sender, CommandEventArgs e)
        {
            RaiseControlCommand(Command.CONFIRM_CHANGE_PAGE, e.CommandArgument);
        }
        protected void ddlEstadoCalidad_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            UIHelper.SetValue(diFecha, DateTime.Now.Date);
        }
        protected void ddlTipoProyectoSugerido_SelectedIndexChanged(object sender, EventArgs e)
        {
            CallTryMethod(CargarProceso);
        }
        protected void cbAceptadoDenominacion_CheckedChanged(object sender, EventArgs e)
        {
            CallTryMethod(ChangeAceptadoDenominacion);
        }
        protected void cbAceptadoTipoProyecto_CheckedChanged(object sender, EventArgs e)
        {
            ChangeAceptadoTipoProyecto();
        }
        protected void cbAceptadoEstado_CheckedChanged(object sender, EventArgs e)
        {
            ChangeAceptadoEstado();
        }
        protected void cbAceptadoProceso_CheckedChanged(object sender, EventArgs e)
        {
            ChangeAceptadoProceso();
        }
        protected void cbAceptadoFinalidad_CheckedChanged(object sender, EventArgs e)
        {
            ChangeAceptadoFinalidad();
        }
        protected void cbAceptadoLocalizacion_CheckedChanged(object sender, EventArgs e)
        {
            ChangeAceptadoLocalizacion();
            bool enable = !UIHelper.GetBoolean(cbAceptadoLocalizacion);
        }
        #endregion

        #region Methods
        private void CargarProceso()
        {
            Int32 idTipoProyecto = UIHelper.GetInt(ddlTipoProyectoSugerido);
            if (idTipoProyecto == 0)
            {
                UIHelper.ClearItems(ddlProcesoSugerido);
            }
            else
            {
                UIHelper.Load<nc.Proceso>(ddlProcesoSugerido, ProcesoService.Current.GetList(new nc.ProcesoFilter() { Activo = true, IdProyectoTipo = idTipoProyecto }), "Nombre", "IdProceso", new Proceso() { IdProceso = 0, Nombre = "Seleccione Proceso" });
            }
            ddlProcesoSugerido.Enabled = ddlProcesoSugerido.Items.Count > 0;
        }
        private void ChangeAceptadoDenominacion()
        {
            bool selected = UIHelper.GetBoolean(cbAceptadoDenominacion);
            tbDenominacionSugerido.Enabled = !selected;
            if (selected)
                CargarDenominacionSugerida();
            else
                UIHelper.Clear(tbDenominacionSugerido);
        }
        private void CargarDenominacionSugerida()
        {
            UIHelper.SetValue(tbDenominacionOriginalSugerido, Entity.CalidadSugerida.DenominacionOriginal);
            UIHelper.SetValue(tbDenominacionSugerido, Entity.CalidadSugerida.DenominacionSugerida);
        }
        private void ChangeAceptadoTipoProyecto()
        {
            bool selected = UIHelper.GetBoolean(cbAceptadoTipoProyecto);
            ddlTipoProyectoSugerido.Enabled = !selected;
            if (selected)
                CargarTipoProcesoSugerido();
            else
                UIHelper.Clear(ddlTipoProyectoSugerido);
        }
        private void CargarTipoProcesoSugerido()
        {
            if (Entity.CalidadSugerida.IdProyectoTipo.HasValue)
                UIHelper.SetValue<ProyectoTipo, int>(ddlTipoProyectoSugerido, Entity.CalidadSugerida.IdProyectoTipo.Value, ProyectoTipoService.Current.GetById);
        }
        private void ChangeAceptadoEstado()
        {
            bool selected = UIHelper.GetBoolean(cbAceptadoEstado); ;
            ddlEstadoSugerido.Enabled = !selected;
            if (selected)
                CargarEstadoSugerido();
            else
                UIHelper.Clear(ddlEstadoSugerido);
        }
        private void CargarEstadoSugerido()
        {
            if (Entity.CalidadSugerida.IdEstadoSugerido.HasValue)
                UIHelper.SetValue<Estado, int>(ddlEstadoSugerido, Entity.CalidadSugerida.IdEstadoSugerido.Value, EstadoService.Current.GetById);
        }
        private void ChangeAceptadoProceso()
        {
            bool selected = UIHelper.GetBoolean(cbAceptadoProceso); ;
            ddlProcesoSugerido.Enabled = !selected;
            if (selected)
                CargarProcesoSugerido();
            else
                UIHelper.Clear(ddlProcesoSugerido);
        }
        private void CargarProcesoSugerido()
        {
            if (Entity.CalidadSugerida.IdProceso.HasValue)
                UIHelper.SetValue<Proceso, int>(ddlProcesoSugerido, Entity.CalidadSugerida.IdProceso.Value, ProcesoService.Current.GetById);
        }
        private void ChangeAceptadoFinalidad()
        {
            bool selected = UIHelper.GetBoolean(cbAceptadoFinalidad); ;
            toFinalidadSugerido.Enabled = !selected;
            if (selected)
                CargarFinalidadSugerida();
            else
                UIHelper.Clear(toFinalidadSugerido);
        }
        private void CargarFinalidadSugerida()
        {
            UIHelper.SetValue(toFinalidadSugerido, Entity.CalidadSugerida.IdClasificacionFuncional);
        }
        private void ChangeAceptadoLocalizacion()
        {
            bool selected = UIHelper.GetBoolean(cbAceptadoLocalizacion); ;
            dlProvinciasC.Enabled = !selected;
            dlProvinciasD.Enabled = !selected;
            if (selected)
                CargarLocalizacion();
            else
            {
                LimpiarLocalizacion();
            }
        }
        private void CargarLocalizacion()
        {
            #region Marcar Provincias
            List<ClasificacionGeograficaResult> provincias = ClasificacionGeograficaService.Current.GetResult(new nc.ClasificacionGeograficaFilter() { IdClasificacionGeograficaTipo = (Int32)ClasificacionGeograficaTipoEnum.Provincia, FilterOrderBy = new FilterOrderBy() { OrderByProperty = "Codigo" } });
            List<ClasificacionGeograficaResult> provinciasA = new List<ClasificacionGeograficaResult>();
            List<ClasificacionGeograficaResult> provinciasB = new List<ClasificacionGeograficaResult>();
            List<ClasificacionGeograficaResult> provinciasC = new List<ClasificacionGeograficaResult>();
            List<ClasificacionGeograficaResult> provinciasD = new List<ClasificacionGeograficaResult>();
            for (int i = 0; i < provincias.Count; i++)
            {
                if (i < (provincias.Count + 1) / 2)
                {
                    ClasificacionGeograficaResult provA = new ClasificacionGeograficaResult();
                    provA.IdClasificacionGeografica = provincias[i].ID;
                    provA.Nombre = provincias[i].Nombre;
                    provA.Selected = (from a in Entity.localizacionesActual where a.IdProvincia == provA.ID select a).Count() > 0;
                    provinciasA.Add(provA);

                    ClasificacionGeograficaResult provC = new ClasificacionGeograficaResult();
                    provC.IdClasificacionGeografica = provincias[i].ID;
                    provC.Nombre = provincias[i].Nombre;
                    provC.Selected = (from a in Entity.localizacionesSugerida where a.IdClasificacionGeografica == provC.ID select a).Count() > 0;
                    provinciasC.Add(provC);
                }
                else
                {
                    ClasificacionGeograficaResult provB = new ClasificacionGeograficaResult();
                    provB.IdClasificacionGeografica = provincias[i].ID;
                    provB.Nombre = provincias[i].Nombre;
                    provB.Selected = (from a in Entity.localizacionesActual where a.IdClasificacionGeografica == provB.ID select a).Count() > 0;
                    provinciasB.Add(provB);

                    ClasificacionGeograficaResult provD = new ClasificacionGeograficaResult();
                    provD.IdClasificacionGeografica = provincias[i].ID;
                    provD.Nombre = provincias[i].Nombre;
                    provD.Selected = (from a in Entity.localizacionesSugerida where a.IdClasificacionGeografica == provD.ID select a).Count() > 0;
                    provinciasD.Add(provD);
                }
            }
            UIHelper.SetValue(dlProvinciasA, provinciasA);
            UIHelper.SetValue(dlProvinciasB, provinciasB);
            UIHelper.SetValue(dlProvinciasC, provinciasC);
            UIHelper.SetValue(dlProvinciasD, provinciasD);
            #endregion Marcar Provincias
        }
        private void LimpiarLocalizacion()
        {
            #region Marcar Provincias
            List<ClasificacionGeograficaResult> provincias = ClasificacionGeograficaService.Current.GetResult(new nc.ClasificacionGeograficaFilter() { IdClasificacionGeograficaTipo = (Int32)ClasificacionGeograficaTipoEnum.Provincia, FilterOrderBy = new FilterOrderBy() { OrderByProperty = "Codigo" } });
            List<ClasificacionGeograficaResult> provinciasC = new List<ClasificacionGeograficaResult>();
            List<ClasificacionGeograficaResult> provinciasD = new List<ClasificacionGeograficaResult>();
            for (int i = 0; i < provincias.Count; i++)
            {
                if (i < (provincias.Count + 1) / 2)
                {
                    ClasificacionGeograficaResult provC = new ClasificacionGeograficaResult();
                    provC.IdClasificacionGeografica = provincias[i].ID;
                    provC.Nombre = provincias[i].Nombre;
                    provC.Selected = false;
                    provinciasC.Add(provC);
                }
                else
                {
                    ClasificacionGeograficaResult provD = new ClasificacionGeograficaResult();
                    provD.IdClasificacionGeografica = provincias[i].ID;
                    provD.Nombre = provincias[i].Nombre;
                    provD.Selected = false;
                    provinciasD.Add(provD);
                }
            }
            UIHelper.SetValue(dlProvinciasC, provinciasC);
            UIHelper.SetValue(dlProvinciasD, provinciasD);
            #endregion Marcar Provincias
        }
        #endregion


    }
}
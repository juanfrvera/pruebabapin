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
    public partial class AdministracionCalidadPriorizacionEdit : WebControlEdit<nc.ProyectoCalidadCompose>
    {
        #region Override WebControlEdit
        protected override void _Initialize()
        {
            
            
            base._Initialize();
            ddlTipoProyectoActual.Width = 310;
            ddlEstadoActual.Width = 310;
            ddlProcesoActual.Width = 310;
            ddlFinalidadActual.Width = 310;

            UIHelper.Load<nc.Clasificacion>(ddlClasificacion, ClasificacionService.Current.GetList(new nc.ClasificacionFilter() { Activo = true, OrderByProperty = "Nombre" }), "Nombre", "IdClasificacion", new nc.Clasificacion() { IdClasificacion = 0, Nombre = "Seleccione Clasificación" });
            UIHelper.Load<nc.Prioridad>(ddlPrioridad, PrioridadService.Current.GetList(new nc.PrioridadFilter() { Activo = true }), "Nombre", "IdPrioridad", new nc.Prioridad() { IdPrioridad = 0, Nombre = "Seleccione Prioridad" });
            
        }
        public override void Clear()
        {
            UIHelper.Clear(chkPrioridadAsignada);
            UIHelper.Clear(ddlPrioridad);
            UIHelper.Clear(txtPuntaje);
            UIHelper.Clear(chkConfReq);
            UIHelper.Clear(chkReqArt15);
            UIHelper.Clear(ddlClasificacion);
            UIHelper.Clear(txtComentario);
            HabilitarControles();
        }
        public override void GetValue()
        {
            Entity.AdministrandoPriorizacion = true;

            Entity.ProyectoPrioridad.IdProyecto = Entity.IdProyecto;
            Entity.ProyectoPrioridad.PrioridadAsignada = UIHelper.GetBoolean(chkPrioridadAsignada);
            Entity.ProyectoPrioridad.IdPrioridad = UIHelper.GetIntNullable(ddlPrioridad);
            Entity.ProyectoPrioridad.Puntaje = UIHelper.GetInt(txtPuntaje);
            Entity.ProyectoPrioridad.ConfRequerimientos = UIHelper.GetBoolean(chkConfReq);
            Entity.ProyectoPrioridad.ReqArt15 = UIHelper.GetBoolean(chkReqArt15);
            Entity.ProyectoPrioridad.IdClasificacion = UIHelper.GetInt(ddlClasificacion);
            Entity.ProyectoPrioridad.Comentario = UIHelper.GetString(txtComentario);
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
            UIHelper.Load(gridProyectoPriorizacion, datos.Prioridades);
            UIHelper.Load(gridEtapasEstimadas, dataTableEST);
            UIHelper.Load(gridEtapasRealizadas, dataTableREA);
            lbMontoEstimado.Text =  Math.Round(MTE,0).ToString("N0");
            lbMontoRealizado.Text = Math.Round(MTR, 0).ToString("N0");
            //lblPlan.Text = datos.UltimoPlan;
            //UIHelper.Load(gridProyectoPrioridad, datos.Prioridades);

            SetearUltimoPlan();

            UIHelper.SetValue(tbUltPlan, datos.UltimoPlan);
            UIHelper.SetValue(tbDictamen,datos.Dictamen);
            UIHelper.SetValue(tbPrioOrganismo, datos.PrioridadOrganismo);
            UIHelper.SetValue(tbPrioOrganismoNro,datos.SubPrioridad);
            UIHelper.SetValue(cbArt15,datos.Art15);
            UIHelper.SetValue(tbUltPriorizacion,datos.UltPriorizacion);

            Entity.ProyectoPrioridad.IdPlanPeriodo = datos.IdPeriodoUltimoPlan;

            #endregion

            #region General

            if (Entity.CalidadSugerida.IdProyectoCalidad == 0)
                Entity.CalidadSugerida.DenominacionOriginal = Entity.CalidadActual.DenominacionSugerida;

            UIHelper.Load<nc.ProyectoTipoResult>(ddlTipoProyectoActual, ProyectoTipoService.Current.GetResult(new nc.ProyectoTipoFilter() { Activo = true, IdProyectoTipo = Entity.CalidadActual.IdProyectoTipo }), "Nombre", "IdProyectoTipo");
            UIHelper.Load<nc.EstadoResult>(ddlEstadoActual, EstadoService.Current.GetResult(new nc.EstadoFilter() { Activo = true, IdSistemaEntidad = (int)SistemaEntidadEnum.Proyecto, IdEstado = Entity.CalidadActual.IdEstadoSugerido }), "Nombre", "IdEstado");
            UIHelper.Load<nc.ProcesoResult>(ddlProcesoActual, ProcesoService.Current.GetResult(new nc.ProcesoFilter() { Activo = true, IdProceso = Entity.CalidadActual.IdProceso }), "Nombre", "IdProceso");
            UIHelper.Load<nc.FinalidadFuncionResult>(ddlFinalidadActual, FinalidadFuncionService.Current.GetResult(new nc.FinalidadFuncionFilter() { Activo = true, IdFinalidadFuncion = Entity.CalidadActual.IdClasificacionFuncional }), "Denominacion", "IdFinalidadFuncion");
            UIHelper.SetValue(tbDenominacionActual, Entity.CalidadActual.DenominacionSugerida);
            #endregion

            #region Marcar Provincias
            List<ClasificacionGeograficaResult> provincias = ClasificacionGeograficaService.Current.GetResult(new nc.ClasificacionGeograficaFilter() { IdClasificacionGeograficaTipo = (Int32)ClasificacionGeograficaTipoEnum.Provincia, FilterOrderBy = new FilterOrderBy() { OrderByProperty = "Nombre" } });
            List<ClasificacionGeograficaResult> provinciasA = new List<ClasificacionGeograficaResult>();
            List<ClasificacionGeograficaResult> provinciasB = new List<ClasificacionGeograficaResult>();
            for (int i = 0; i < provincias.Count; i++)
            {
                if (i < (provincias.Count + 1) / 2)
                {
                    ClasificacionGeograficaResult provA = new ClasificacionGeograficaResult();
                    provA.IdClasificacionGeografica = provincias[i].ID;
                    provA.Nombre = provincias[i].Nombre;
                    provA.Selected = (from a in Entity.localizacionesActual where a.IdClasificacionGeografica == provA.ID select a).Count() > 0;
                    provinciasA.Add(provA);
                }
                else
                {
                    ClasificacionGeograficaResult provB = new ClasificacionGeograficaResult();
                    provB.IdClasificacionGeografica = provincias[i].ID;
                    provB.Nombre = provincias[i].Nombre;
                    provB.Selected = (from a in Entity.localizacionesActual where a.IdClasificacionGeografica == provB.ID select a).Count() > 0;
                    provinciasB.Add(provB);
                }
            }
            UIHelper.SetValue(dlProvinciasA, provinciasA);
            UIHelper.SetValue(dlProvinciasB, provinciasB);
            #endregion Marcar Provincias

            #region Prioridad
            UIHelper.SetValue(chkPrioridadAsignada, Entity.ProyectoPrioridad.PrioridadAsignada);
            
            if (Entity.ProyectoPrioridad.IdPrioridad.HasValue)
                UIHelper.SetValue<Prioridad, int>(ddlPrioridad, Entity.ProyectoPrioridad.IdPrioridad.Value, PrioridadService.Current.GetById);
            
            UIHelper.SetValue(txtPuntaje, Entity.ProyectoPrioridad.Puntaje);

            if (chkPrioridadAsignada.Checked)
            {
                
                chkPrioridadAsignada.Enabled = false;
                ddlPrioridad.Enabled = false;
                txtPuntaje.Enabled = false;
            }else if (Entity.ProyectoPrioridad.AplicarPrioridad)
            {
                UIHelper.SetValue<Prioridad, int>(ddlPrioridad, Entity.ProyectoPrioridad.IdPrioridadCalculadoAsignada, PrioridadService.Current.GetById);
                UIHelper.SetValue(txtPuntaje, String.Format("{0:0.#}",Entity.ProyectoPrioridad.PuntajeCalculado));
            }
            
            UIHelper.SetValue(chkConfReq, Entity.ProyectoPrioridad.ConfRequerimientos);
            UIHelper.SetValue(chkReqArt15, Entity.ProyectoPrioridad.ReqArt15);
            if (chkConfReq.Checked)
            {
                chkConfReq.Enabled = false;
                chkReqArt15.Enabled = false;
            }
            if (Entity.ProyectoPrioridad.IdClasificacion.HasValue)
                UIHelper.SetValue<Clasificacion, int>(ddlClasificacion, Entity.ProyectoPrioridad.IdClasificacion.Value, ClasificacionService.Current.GetById);
            UIHelper.SetValue(txtComentario, Entity.ProyectoPrioridad.Comentario);

            // PRIORIDAD CALCULADA
            txtOriginal.Text = Entity.ProyectoPrioridad.PrioridadCalculadoOriginal;
            txtAsignado.Text = Entity.ProyectoPrioridad.PrioridadCalculadoAsignada;
            txtOriginal.Enabled = false;
            txtAsignado.Enabled = false;

            //if (!chkPrioridadAsignada.Checked && txtOriginal.Text == "" && txtAsignado.Text == "")
            //{ 

            //}

            if (!datos.ActivoUltimoPlan)
            {
                ddlClasificacion.Enabled = false;
                txtComentario.Enabled = false;
                chkPrioridadAsignada.Enabled = false;
                ddlPrioridad.Enabled = false;
                txtPuntaje.Enabled = false;
                chkConfReq.Enabled = false;
                chkReqArt15.Enabled = false;
            }
            #endregion Prioridad

            upCalidad.Update();
            upPriorizacion.Update();
        }
        #endregion Override

        #region Eventos
        protected void lnk_Command(object sender, CommandEventArgs e)
        {
            RaiseControlCommand(Command.CONFIRM_CHANGE_PAGE, e.CommandArgument);
        }
        protected void ddlPrioridad_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (((DropDownList)sender).SelectedValue == ((Int32)PrioridadEnum.Prioridad_4).ToString())
            {
                decimal PuntajeCalculado = ProyectoPrioridadService.Current.CalcularPuntaje(Entity.IdProyecto);
                UIHelper.SetValue(txtPuntaje, String.Format("{0:0.#}", PuntajeCalculado));
            }
        }
        #endregion
        #region Private Methods
        private void SetearUltimoPlan()
        {
            ProyectoCalidadFilter pcf = new ProyectoCalidadFilter();
            AdministracionCalidadPriorizacionPageEdit acppe = this.PageBase as AdministracionCalidadPriorizacionPageEdit;
            if (acppe != null)
                pcf = GetGeneralParameter((acppe).EditFilter) as ProyectoCalidadFilter;

            PlanPeriodo pp = PlanPeriodoService.Current.GetNew();
            PlanVersion pv = PlanVersionService.Current.GetNew();
            PlanTipo pt = PlanTipoService.Current.GetNew();
            if (pcf.IdPlanPeriodo.HasValue && pcf.IdPlanPeriodo.Value !=0)
                pp = PlanPeriodoService.Current.GetById(pcf.IdPlanPeriodo.Value);
            if (pcf.IdPlanVersion.HasValue && pcf.IdPlanVersion.Value != 0)
                pv = PlanVersionService.Current.GetById(pcf.IdPlanVersion.Value);
            if (pcf.IdPlanTipo.HasValue && pcf.IdPlanTipo.Value != 0)
                pt = PlanTipoService.Current.GetById(pcf.IdPlanTipo.Value);


            UIHelper.SetValue(lblPlan, String.Format("{0} {1} {2}", pt.Sigla, pp.Nombre, pv.Nombre)); 
        }
        private void HabilitarControles()
        {
            chkPrioridadAsignada.Enabled = true;
            ddlPrioridad.Enabled = true;
            txtPuntaje.Enabled = true;
            chkConfReq.Enabled = true;
            chkReqArt15.Enabled = true;
            ddlClasificacion.Enabled = true;
            txtComentario.Enabled = true;
        }
        #endregion
    }
}
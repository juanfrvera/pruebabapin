using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc = Contract;
using Service;

namespace UI.Web
{
    public partial class ProyectoCalidadEdit : WebControlEdit<nc.ProyectoCalidadCompose>
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

            ddlFinalidadActual.Width = 310;
            ddlFinalidadSugerido.Width = 310;
        }
        public override void Clear()
        {

        }
        public override void GetValue()
        {
            Entity.AceptadoDenominacion = UIHelper.GetBoolean(cbAceptadoDenominacion);
            Entity.AceptadoTipoProyecto = UIHelper.GetBoolean(cbAceptadoTipoProyecto);
            Entity.AceptadoEstado = UIHelper.GetBoolean(cbAceptadoEstado);
            Entity.AceptadoProceso = UIHelper.GetBoolean(cbAceptadoProceso);
            Entity.AceptadoFinalidad = UIHelper.GetBoolean(cbAceptadoFinalidad);
            Entity.AceptadoLocalizacion = UIHelper.GetBoolean(cbAceptadoLocalizacion);
        }
        public override void SetValue()
        {
            if (this.IsPostBack)
            {   //Recarga la entidad, para reflejar los cambios
                Entity = ProyectoCalidadComposeService.Current.GetById(Entity.IdProyecto);
            }

            //SetPermissions(); //Matias 20170210 - Ticket #REQ768159 - Creado y comentado por Matias - Rollback de tarea

            lblEstado.Text = Entity.Estado.Nombre;

            #region Load Combos
            // Combos de Tipos de Proyecto
            UIHelper.Load<nc.ProyectoTipoResult>(ddlTipoProyectoActual, ProyectoTipoService.Current.GetResult(new nc.ProyectoTipoFilter() { Activo = true, IdProyectoTipo = Entity.CalidadActual.IdProyectoTipo }), "Nombre", "IdProyectoTipo");
            UIHelper.Load<nc.ProyectoTipoResult>(ddlTipoProyectoSugerido, ProyectoTipoService.Current.GetResult(new nc.ProyectoTipoFilter() { Activo = true, IdProyectoTipo = Entity.CalidadSugerida.IdProyectoTipo }), "Nombre", "IdProyectoTipo");

            // Combos de Estados de Proyecto
            UIHelper.Load<nc.EstadoResult>(ddlEstadoActual, EstadoService.Current.GetResult(new nc.EstadoFilter() { Activo = true, IdSistemaEntidad = (int)SistemaEntidadEnum.Proyecto, IdEstado = Entity.CalidadActual.IdEstadoSugerido }), "Nombre", "IdEstado");
            UIHelper.Load<nc.EstadoResult>(ddlEstadoSugerido, EstadoService.Current.GetResult(new nc.EstadoFilter() { Activo = true, IdSistemaEntidad = (int)SistemaEntidadEnum.Proyecto, IdEstado = Entity.CalidadSugerida.IdEstadoSugerido }), "Nombre", "IdEstado");

            // Combos de proceso
            UIHelper.Load<nc.ProcesoResult>(ddlProcesoActual, ProcesoService.Current.GetResult(new nc.ProcesoFilter() { Activo = true, IdProceso = Entity.CalidadActual.IdProceso }), "Nombre", "IdProceso");
            UIHelper.Load<nc.ProcesoResult>(ddlProcesoSugerido, ProcesoService.Current.GetResult(new nc.ProcesoFilter() { Activo = true, IdProceso = Entity.CalidadSugerida.IdProceso }), "Nombre", "IdProceso");

            // Combos de Finalidad Funcion
            UIHelper.Load<nc.FinalidadFuncionResult>(ddlFinalidadActual, FinalidadFuncionService.Current.GetResult(new nc.FinalidadFuncionFilter() { Activo = true, IdFinalidadFuncion = Entity.CalidadActual.IdClasificacionFuncional }), "Denominacion", "IdFinalidadFuncion");
            UIHelper.Load<nc.FinalidadFuncionResult>(ddlFinalidadSugerido, FinalidadFuncionService.Current.GetResult(new nc.FinalidadFuncionFilter() { Activo = true, IdFinalidadFuncion = Entity.CalidadSugerida.IdClasificacionFuncional }), "Denominacion", "IdFinalidadFuncion");

            // Text Denominacion
            UIHelper.SetValue(tbDenominacionActual, Entity.CalidadActual.DenominacionSugerida);
            UIHelper.SetValue(tbDenominacionSugerido, Entity.CalidadSugerida.DenominacionSugerida);

            // Text Comentario
            UIHelper.SetValue(tbComentario, Entity.CalidadSugerida.Comenatrio);
            #endregion

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
                    provA.Selected = (from a in Entity.localizacionesActual where a.IdClasificacionGeografica == provA.ID select a).Count() > 0;
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

            #region Manejar Checks
            cbAceptadoDenominacion.Checked = false;
            cbAceptadoTipoProyecto.Checked = false;
            cbAceptadoEstado.Checked = false;
            cbAceptadoProceso.Checked = false;
            cbAceptadoFinalidad.Checked = false;
            cbAceptadoLocalizacion.Checked = false;
            cbAceptadoDenominacion.Focus();

            cbAceptadoDenominacion.Enabled = Entity.HabilitadoParaCambios && !Entity.CalidadSugerida.DenominacionOK;
            cbAceptadoTipoProyecto.Enabled = Entity.HabilitadoParaCambios && !Entity.CalidadSugerida.ProyectoTipoOk;
            cbAceptadoEstado.Enabled = Entity.HabilitadoParaCambios && !Entity.CalidadSugerida.EstadoSugeridoOK;
            cbAceptadoProceso.Enabled = Entity.HabilitadoParaCambios && !Entity.CalidadSugerida.ProcesoOk;
            cbAceptadoFinalidad.Enabled = Entity.HabilitadoParaCambios && !Entity.CalidadSugerida.FinalidadFuncionOk;
            cbAceptadoLocalizacion.Enabled = Entity.HabilitadoParaCambios && (bool)!Entity.CalidadSugerida.LocalizacionOK;
            #endregion 

            upCalidad.Update();
        }

        //Matias 20170210 - Ticket #REQ768159 - Creado y comentado por Matias - Rollback de tarea
        //#region Permissions
        //protected bool EnableSolapa
        //{
        //    get
        //    {
        //        return Convert.ToBoolean(ViewState["EnableSolapa"]);
        //    }
        //    set
        //    {
        //        ViewState["EnableSolapa"] = value;
        //    }
        //}

        //protected void SetPermissions()
        //{
        //    if (CrudAction == CrudActionEnum.Create)
        //    {
        //        //EnableSolapa = false;
        //    }
        //    else if (CrudAction == CrudActionEnum.Read)
        //    {
        //        EnableSolapa = false;
        //        this.pnlHojaDeCalidad.Enabled = false;
        //    }
        //    else
        //    {
        //        //EnableSolapa = CanByOffice(SistemaEntidadConfig.PROYECTO_PLAN, Entity.proyecto.PerfilOficinas, ActionConfig.UPDATE, Entity.proyecto.IdEstado);                
        //    }

        //    //Inhabilito todos los componenetes de la Solapa
        //    //this.pnlPlanEditar.Enabled = EnablePlanCreate || EnablePlanUpdate;            
        //}
        //#endregion
        //FinMatias 20170210 - Ticket #REQ768159

        #endregion Override
         public void OcultarPanel(bool active)
        {
            pnl.Visible = !active;
        }

    }
}
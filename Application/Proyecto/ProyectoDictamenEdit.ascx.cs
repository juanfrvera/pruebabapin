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
    public partial class ProyectoDictamenEdit : WebControlEdit<nc.ProyectoDictamen>
    {

        protected override void _Initialize()
        {
            base._Initialize();

            txtMontoInversionAprobada.Attributes.CssStyle.Add("TEXT-ALIGN", "right");
            txtNumero.Attributes.CssStyle.Add("TEXT-ALIGN", "right");

            UIHelper.Load<nc.ProyectoCalificacion>(ddlProyectoCalificacion, ProyectoCalificacionService.Current.GetList(new nc.ProyectoCalificacionFilter() { Activo = true }), "Nombre", "IdProyectoCalificacion", new nc.ProyectoCalificacion() { IdProyectoCalificacion = 0, Nombre = "Seleccione Calificacion" });
            revMontoInversionAprobada.ValidationExpression = Contract.DataHelper.GetExpRegNumberNullable();
            revMontoInversionAprobada.ErrorMessage = TranslateFormat("InvalidFiled", "Monto de Inversión Aprobada");
            revDuracionMeses.ValidationExpression = Contract.DataHelper.GetExpRegNumberNullable();
            revDuracionMeses.ErrorMessage = TranslateFormat("InvalidFiled", "Duración Meses");
            revInformeTecnico.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(50);
            revInformeTecnico.ErrorMessage = TranslateFormat("InvalidFiled", "Informe Técnico");
            revObservacion.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(2147483647);
            revObservacion.ErrorMessage = TranslateFormat("InvalidFiled", "Observación");
            revRecomendacion.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(2147483647);
            revRecomendacion.ErrorMessage = TranslateFormat("InvalidFiled", "Recomendación");
            revRespuestaOrganismo.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(2147483647);
            revRespuestaOrganismo.ErrorMessage = TranslateFormat("InvalidFiled", "Respuesta Organismo");
            revNumero.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(35); //Matias 20170317 - Ticket REQ170317_1 - Antes (10)
            diFecha.RequiredErrorMessage = TranslateFormat("FieldIsNull", "Fecha");
            Int32 anio_from = DateTime.Now.Year - 3;
            UIHelper.Load<nc.Anio>(ddlEjercicioInicioEjecucion, AnioService.Current.GetList(new nc.AnioFilter() { Activo = true, IdAnio = anio_from, IdAnio_To = DateTime.Now.Year + 4 }).OrderByDescending(i => i.Nombre).ToList(), "Nombre", "Nombre", new nc.Anio() { Nombre = "Seleccione Año" }, false);

            Int32 IdPNIP = GetParameterIDPlanTipoPNIP();
            UIHelper.Load<nc.PlanPeriodo>(ddlMotivoIntervencion, PlanPeriodoService.Current.GetList(new nc.PlanPeriodoFilter() { IdPlanTipo = IdPNIP, Activo = true }), "Nombre", "IdPlanPeriodo", new nc.PlanPeriodo() { IdPlanPeriodo = 0, Nombre = "Seleccione Motivo Intervencion" });

        }
        public override void Clear()
        {
            UIHelper.Clear(ddlProyectoCalificacion);
            ddlProyectoCalificacion.Focus();
            UIHelper.Clear(diFecha);
            UIHelper.Clear(diFechaVencimiento);
            UIHelper.Clear(txtDuracionMeses);
            UIHelper.Clear(txtInformeTecnico);
            UIHelper.Clear(diFechaComiteTecnico);
            UIHelper.Clear(txtObservacion);
            UIHelper.Clear(txtRecomendacion);
            UIHelper.Clear(txtRespuestaOrganismo);
            UIHelper.Clear(diFechaRepuesta);
            UIHelper.Clear(txtNumero);
            UIHelper.Clear(ddlMotivoIntervencion);
            UIHelper.Clear(txtMontoInversionAprobada);
            UIHelper.Clear(ddlEjercicioInicioEjecucion);
            //hlFile.Text = string.Empty;
            //hlFile.NavigateUrl = string.Empty;
        }
        public override void SetValue()
        {
            // Verifico si estoy mostrando esta pagina en la solapa inter dnip de inversion, si es asi, seteo la pagina para solo lectura
            // Excepto el link para descargar el archivo
            if (string.Compare(this.Page.ToString(), "ASP.Proyecto_Proyectodnippageedit_aspx", true) == 0)
            {
                // deshabilito los controles
                this.deshabilitarControlesPagina();

            }

            if (Entity.IdProyectoCalificacion.HasValue)
                UIHelper.SetValue<ProyectoCalificacion, int>(ddlProyectoCalificacion, Entity.IdProyectoCalificacion.Value, ProyectoCalificacionService.Current.GetById);
            ddlProyectoCalificacion.Focus();
            UIHelper.SetValue(diFecha, Entity.Fecha);
            UIHelper.SetValue(diFechaVencimiento, Entity.FechaVencimiento);
            UIHelper.SetValue(txtDuracionMeses, Entity.DuracionMeses);
            UIHelper.SetValue(txtInformeTecnico, Entity.InformeTecnico);
            UIHelper.SetValue(diFechaComiteTecnico, Entity.FechaComiteTecnico);
            UIHelper.SetValue(txtObservacion, Entity.Observacion);
            UIHelper.SetValue(txtRecomendacion, Entity.Recomendacion);
            UIHelper.SetValue(txtRespuestaOrganismo, Entity.RespuestaOrganismo);
            UIHelper.SetValue(diFechaRepuesta, Entity.FechaRepuesta);
            UIHelper.SetValue(txtNumero, Entity.Numero);
            if (Entity.IdPlanPeriodo.HasValue)
                UIHelper.SetValue<PlanPeriodo, int>(ddlMotivoIntervencion, Entity.IdPlanPeriodo.Value, PlanPeriodoService.Current.GetById);
            if (Entity.Monto.HasValue)
                UIHelper.SetValue(txtMontoInversionAprobada, Entity.Monto.Value.ToString("N0"));
            else
                UIHelper.SetValue(txtMontoInversionAprobada, Entity.Monto);
            if (Entity.Ejercicio.HasValue)
            {
                if (Entity.Ejercicio.Value < DateTime.Now.Year) UIHelper.Load<nc.Anio>(ddlEjercicioInicioEjecucion, AnioService.Current.GetList(new nc.AnioFilter() { Activo = true, IdAnio = Entity.Ejercicio.Value - 3, IdAnio_To = DateTime.Now.Year + 4 }).OrderByDescending(i => i.Nombre).ToList(), "Nombre", "Nombre", new nc.Anio() { Nombre = "Seleccione Año" }, false);
                UIHelper.SetValue<Anio, int>(ddlEjercicioInicioEjecucion, Entity.Ejercicio.Value, AnioService.Current.GetById);
            }

            ActivarFile();
            ProyectoDictamenFileRefresh();
        }

        private ProyectoDictamenFileResult actualProyectoDictamenFile;
        protected ProyectoDictamenFileResult ActualProyectoDictamenFile
        {
            get
            {
                if (actualProyectoDictamenFile == null)
                    if (ViewState["actualProyectoDictamenFile"] != null)
                        actualProyectoDictamenFile = ViewState["actualProyectoDictamenFile"] as ProyectoDictamenFileResult;
                    else
                    {
                        actualProyectoDictamenFile = GetNewProyectoDictamenFile();
                        ViewState["actualProyectoDictamenFile"] = actualProyectoDictamenFile;
                    }
                return actualProyectoDictamenFile;
            }
            set
            {
                actualProyectoDictamenFile = value;
                ViewState["actualProyectoDictamenFile"] = value;
            }
        }

        ProyectoDictamenFileResult GetNewProyectoDictamenFile()
        {
            int id = 0;
            if (Entity.ProyectoDictamenFiles.Count > 0) id = Entity.ProyectoDictamenFiles.Min(l => l.IdProyectoDictamenFile);
            if (id > 0) id = 0;
            id--;
            ProyectoDictamenFileResult plResult = new ProyectoDictamenFileResult();
            plResult.IdProyectoDictamenFile = id;
            plResult.IdProyectoDictamen = Entity.IdProyectoDictamen;
            return plResult;
        }

        private void deshabilitarControlesPagina()
        {
            // Calificacion
            this.txtNumero.Enabled = false;
            this.ddlProyectoCalificacion.Enabled = false;
            this.txtInformeTecnico.Enabled = false;
            this.ddlMotivoIntervencion.Enabled = false;
            this.txtMontoInversionAprobada.Enabled = false;
            this.diFecha.Enabled = false;
            this.diFechaVencimiento.Enabled = false;
            this.diFechaComiteTecnico.Enabled = false;
            this.ddlEjercicioInicioEjecucion.Enabled = false;
            this.txtDuracionMeses.Enabled = false;
            this.txtObservacion.Enabled = false;
            this.txtRecomendacion.Enabled = false;

            // Respuesta del organismo
            this.diFechaRepuesta.Enabled = false;
            this.txtRespuestaOrganismo.Enabled = false;
        }
        public override void GetValue()
        {
            Entity.IdProyectoCalificacion = UIHelper.GetIntNullable(ddlProyectoCalificacion);
            Entity.Fecha = UIHelper.GetDateTimeNullable(diFecha);
            Entity.FechaVencimiento = UIHelper.GetDateTimeNullable(diFechaVencimiento);
            Entity.DuracionMeses = UIHelper.GetIntNullable(txtDuracionMeses);
            Entity.InformeTecnico = UIHelper.GetString(txtInformeTecnico);
            Entity.FechaComiteTecnico = UIHelper.GetDateTimeNullable(diFechaComiteTecnico);
            Entity.Observacion = UIHelper.GetString(txtObservacion);
            Entity.Recomendacion = UIHelper.GetString(txtRecomendacion);
            Entity.RespuestaOrganismo = UIHelper.GetString(txtRespuestaOrganismo);
            Entity.FechaRepuesta = UIHelper.GetDateTimeNullable(diFechaRepuesta);
            Entity.Numero = UIHelper.GetString(txtNumero);
            Entity.IdPlanPeriodo = UIHelper.GetIntNullable(ddlMotivoIntervencion);
            Entity.Monto = UIHelper.GetDecimalNullable(txtMontoInversionAprobada);
            Entity.Ejercicio = UIHelper.GetIntNullable(ddlEjercicioInicioEjecucion);

        }
        private Int32 GetParameterIDPlanTipoPNIP()
        {
            return (Int32)SolutionContext.Current.ParameterManager.GetNumberValue("ID_PLAN_TIPO_PNIP");
        }


        #region File

        #region Methods

        void ProyectoDictamenFileRefresh()
        {
            List<ProyectoDictamenFileResult> proyectoDictamenFileResult = ProyectoDictamenFileService.Current.GetResult(new ProyectoDictamenFileFilter() { IdProyectoDictamen = Entity.IdProyectoDictamen }).ToList();

            UIHelper.Load(gridProyectoDictamenFiles, proyectoDictamenFileResult.ToList(), "Order");
            upGridProyectoDictamenFiles.Update();
        }
        #endregion Methods

        #region EventosGrillas
        protected void GridProyectoDictamenFiles_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex >= 0)
                {
                    Int32 idRow = Int32.Parse(gridProyectoDictamenFiles.DataKeys[e.Row.RowIndex].Value.ToString());
                    Int32 idFile = ProyectoDictamenFileService.Current.GetResult(new ProyectoDictamenFileFilter() { IdProyectoDictamenFile = idRow }).FirstOrDefault().IdFile;
                    ((HyperLink)e.Row.Cells[0].FindControl("hlOpen")).NavigateUrl = WebControl_FileUpload.PathQueryOpenFile + idFile.ToString();
                }
            }
        }

        protected virtual void GridProyectoDictamenFiles_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridProyectoDictamenFiles.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridProyectoDictamenFiles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridProyectoDictamenFiles.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        #endregion

        #endregion

        protected void ActivarFile()
        {
            if (string.Compare(this.Page.ToString(), "ASP.Proyecto_Proyectodnippageedit_aspx", true) != 0)
            {
                // TODO ver como hacer esto
                pnlFileInfo.Visible = false;
                //bool HayFile = ActualFileInfo.IdFile > 0;
                ////btAgregarFileInfo.Enabled = !HayFile;
                //btEliminarFileInfo.Enabled = HayFile;
            }
        }
    }
}

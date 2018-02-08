using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc=Contract;
using Service;
using AUI.Web;

namespace UI.Web
{
    public partial class ProyectoFilter : WebControlFilter<nc.ProyectoFilter>
    {
        private OficinaResult oficinaUsuario;
        protected OficinaResult OficinaUsuario
        {
            get
            {
                if (oficinaUsuario == null)
                    if (ViewState["oficinaUsuario"] != null)
                        oficinaUsuario = ViewState["oficinaUsuario"] as OficinaResult;
                    else
                    {
                        oficinaUsuario = OficinaService.Current.GetResult(new nc.OficinaFilter() { IdOficina = UIContext.Current.ContextUser.User.Persona_IdOficina }).SingleOrDefault ();
                        ViewState["oficinaUsuario"] = oficinaUsuario;
                    }
                return oficinaUsuario;
            }
            set
            {
                oficinaUsuario = value;
                ViewState["oficinaUsuario"] = value;
            }
        }

        #region Override
        protected override void _Initialize()
        {
            base._Initialize();
            this.toOficinas.Width = 670;
            this.toFinalidadFuncion.Width = 500;
            this.toLocalizacionGeografica.Width = 500;
            chkActivo.CheckedValue = true;

            rdFechaInicio.ErrorMessageValidator = TranslateFormat("InvalidField", "Rango de Fechas de Inicio");
            rdFechaInicio.RangeErrorMessageFrom = TranslateFormat("InvalidField", "Fecha de Inicio de");
            rdFechaInicio.RangeErrorMessageTo = TranslateFormat("InvalidField", "Fecha de Inicio a");
            rdFechaModificacion.ErrorMessageValidator = TranslateFormat("InvalidField", "Rango de Fechas de Modificación");
            rdFechaModificacion.RangeErrorMessageFrom = TranslateFormat("InvalidField", "Fecha de Modificación de");
            rdFechaModificacion.RangeErrorMessageTo = TranslateFormat("InvalidField", "Fecha de Modificación a");

            revProyectoDenominacion.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(500);
            //UIHelper.Load<nc.Saf>(ddlSAF, SafService.Current.GetList(), "Denominacion", "IdSaf", new nc.Saf() { IdSaf = 0, Denominacion = "Seleccione SAF" });
            //UIHelper.Load<nc.ClasificacionGeografica>(localizacion, ClasificacionGeograficaService.Current.GetList(), "Nombre", "IdClasificacionGeografica", new nc.ClasificacionGeografica() { IdClasificacionGeografica = 0, Nombre = "Seleccione Localización" });
            UIHelper.Load<nc.PlanTipo>(ddlPlanTipo, PlanTipoService.Current.GetList(), "Nombre", "IdPlanTipo", new nc.PlanTipo() { IdPlanTipo = 0, Nombre = "Seleccione Tipo" },true, "Orden");
			revProyectoDescripcion.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(2147483647);
            UIHelper.Load<nc.Estado>(lbxEstado, EstadoService.Current.GetList(new nc.EstadoFilter() { EntidadTipo =  SistemaEntidadConfig.PROYECTO }), "Nombre", "IdEstado","Orden",SortDirection.Ascending);
			//UIHelper.Load<nc.Proceso>( ddlProceso, ProcesoService.Current.GetList(),"Nombre","IdProceso",new nc.Proceso(){IdProceso=0, Nombre= "Seleccione Proceso"});
            revNroProyecto.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(10);
            UIHelper.Load<nc.Prioridad>(ddlPriorizacion, PrioridadService.Current.GetList(), "Nombre", "IdPrioridad", new nc.Prioridad() { IdPrioridad = 0, Nombre = "Seleccione Prioridad" });
            UIHelper.Load<nc.ProyectoCalificacion>(lbxCalificacionDictamen, ProyectoCalificacionService.Current.GetList(), "Nombre", "IdProyectoCalificacion");
			
            UIHelper.Load<nc.AnioResult>(ddlAnio, AnioService.Current.GetResult().OrderByDescending (i=> i.Nombre).ToList (), "Nombre", "IdAnio", new AnioResult() { IdAnio = 0, Nombre = "Seleccione Año" },false );
            UIHelper.Load<nc.UsuarioResult>(ddlSectorialista, UsuarioService.Current.GetResult(new nc.UsuarioFilter() { EsSectioralista = true }), "NombreCompleto", "IdUsuario", new UsuarioResult() { IdUsuario = 0, NombreCompleto = "Seleccione Sectorialista" });
            
            UIHelper.Load<nc.ProyectoTipo>(ddlTipoProyecto, ProyectoTipoService.Current.GetList(new nc.ProyectoTipoFilter() { Activo = true }), "Nombre", "IdProyectoTipo", new ProyectoTipo() { IdProyectoTipo = 0, Nombre = "Seleccione Clasificación" });
            btHistoricoPorPlan.Visible = this.CanByUser("HistoricoPlan");
            CargarJurisdicciones();
            SetearDatosOficina();
            UIHelper.Load<nc.EstadoDeDesicion>(ddlEstadoDeDesicion, EstadoDeDesicionService.Current.GetList(new EstadoDeDesicionFilter() { Activo = true }), "Nombre", "IdEstadoDeDesicion", new EstadoDeDesicion() { IdEstadoDeDesicion = 0, Nombre = "Seleccione Estado de Decisión" });
            if (esPeriodoDeStress())
            {
                ocultarControlesPorPeriodoDeStress();
            }

        }

        private void ocultarControlesPorPeriodoDeStress()
        {
            Panel1.Visible = false;
            btHistoricoPorPlan.Visible = false;
            PnlFechaIngreso.Visible = false;
            PnlProcesos.Visible = false;
            Panel4.Visible = false;
            liRol.Visible = false;
            ddlRol.Visible = false;
            Panel2.Visible = false;
            PnlDescripcionProyecto.Visible = false;


        }

		protected override void Clear()
        {
            ddlSubPrograma.Focus();
            UIHelper.Clear(ddlJurisdiccion);
            UIHelper.Clear(ddlSAF);
            UIHelper.Clear(ddlPrograma);
			UIHelper.Clear(ddlSubPrograma);
            UIHelper.Clear(ddlSectorialista);
            UIHelper.Clear(txtProyectoDenominacion);
            //UIHelper.Clear(ddlLocalizacion);
            UIHelper.Clear(toLocalizacionGeografica);
            UIHelper.Clear(chkIncluirLocalizacionesInteriores);
            lbxEstado.ClearSelection();
            lbxCalificacionDictamen.ClearSelection();
            UIHelper.Clear(toFinalidadFuncion);
            UIHelper.Clear(chkIncluirFinalidadFuncion);
            UIHelper.Clear(chkBorrador);
            UIHelper.Clear(ddlPlanTipo);
            UIHelper.Clear(txtNroProyecto);
            UIHelper.Clear(rdFechaInicio);
            UIHelper.Clear(rdFechaModificacion);
            //UIHelper.Clear(diFechaInicioDesde);
            //UIHelper.Clear(diFechaInicioHasta);
            //UIHelper.Clear(diFechaModificacionDesde);
            //UIHelper.Clear(diFechaModificacionHasta);
            UIHelper.Clear(ddlTipoProyecto);
            UIHelper.Clear(ddlProceso);
            UIHelper.Clear(toOficinas);
            UIHelper.Clear(chkIncluirLocalizacionesInteriores);
            UIHelper.Clear(ddlRol);
            UIHelper.Clear(txtProyectoDescripcion);
            UIHelper.Clear(chkRequiereDictamen);
            UIHelper.Clear(chkRequiereArt15);
            UIHelper.Clear(chkCalidadPendiente);
            UIHelper.Clear(ddlAnio);
            UIHelper.Clear(ddlEstadoDeDesicion);
            chkActivo.CheckedValue = true;
            ClearCombosAnidados();
            CargarJurisdicciones();
            SetearDatosOficina();
            
        }		
		protected override void SetValue()
        {
            ddlSubPrograma.Focus();
            UIHelper.SetValue(ddlJurisdiccion, Filter.IdJurisdiccion);
            BuscarSafs();
            UIHelper.SetValue(ddlSAF, Filter.IdSaf);
            BuscarProgramas();
            UIHelper.SetValue(ddlPrograma, Filter.IdPrograma);
            BuscarSubProgramas();
            UIHelper.SetValue(ddlSubPrograma, Filter.IdSubPrograma);

            UIHelper.SetValueFilter(txtProyectoDenominacion, Filter.ProyectoDenominacion);


            
            UIHelper.SetValue(chkIncluirLocalizacionesInteriores, Filter.IncluirClasificacionGeoInteriores);
            UIHelper.SetValue(toOficinas, Filter.IdOficina);
            UIHelper.SetValue(chkIncluirOficinasInteriores, Filter.IncluirOficinasInteriores);


            UIHelper.SetValue(ddlPlanTipo, Filter.IdPlanTipo);
            BuscarPlan();
            UIHelper.SetValue(ddlPlanPeriodo, Filter.IdPlanPeriodo);
            UIHelper.SetValue(ddlPlanVersion, Filter.IdPlanVersion);

            UIHelper.SetValue(ddlProceso, Filter.IdProceso);


            UIHelper.SetValue(chkBorrador, Filter.EsBorrador);
            UIHelper.SetValue(chkActivo, Filter.Activo);

            
              

            UIHelper.SetValue(txtNroProyecto, Filter.Codigo);
            
            UIHelper.SetValue(lbxEstado, Filter.IdsEstado);

            //UIHelper.SetValue(diFechaInicioDesde, Filter.FechaInicioEjecucionCalculada);
            //UIHelper.SetValue(diFechaInicioHasta, Filter.FechaInicioEjecucionCalculada_To);
            //UIHelper.SetValue(diFechaModificacionDesde, Filter.FechaModificacion);
            //UIHelper.SetValue(diFechaModificacionHasta, Filter.FechaModificacion_To);

            
            UIHelper.SetValue<DateTime?>(rdFechaModificacion, Filter.FechaModificacion, Filter.FechaModificacion_To);



            if (!esPeriodoDeStress())
            {
                UIHelper.SetValue(toLocalizacionGeografica, Filter.IdClasificacionGeografica);
                UIHelper.SetValue<DateTime?>(rdFechaInicio, Filter.FechaAlta, Filter.FechaAlta_To);
                CargarProcesos();
                UIHelper.SetValue(ddlTipoProyecto, Filter.IdTipoProyecto);
                UIHelper.SetValue(ddlRol, Filter.IdRol);
                UIHelper.SetValue(toFinalidadFuncion, Filter.IdFinalidadFuncion);
                UIHelper.SetValue(chkIncluirFinalidadFuncion, Filter.IncluirFinalidadFunInteriores);
                UIHelper.SetValue(ddlEstadoDeDesicion, Filter.IdEstadoDeDesicion);
                UIHelper.SetValueBetweenFilter(txtProyectoDescripcion, Filter.ProyectoDescripcion);
                UIHelper.SetValue(ddlPriorizacion, Filter.IdPrioridad);
                UIHelper.SetValue(lbxCalificacionDictamen, Filter.IdsCalificacionDictamen);
                UIHelper.SetValue(chkRequiereDictamen, Filter.RequiereDictamen);
                UIHelper.SetValue(chkRequiereArt15, Filter.RequiereArt15);
                UIHelper.SetValue(chkCalidadPendiente, Filter.CalidadPendiente);
                string anio = Filter.Anio.ToString();
                if (anio != null && anio != "")
                    UIHelper.SetValue(ddlAnio, AnioService.Current.GetList(new nc.AnioFilter() { Nombre = anio }).First().IdAnio);
                UIHelper.SetValue(ddlSectorialista, Filter.IdSectorialista);
          
            }
        }
        //Matias 20140512 - Tarea 133
        private string GetSelectedTexts(ListBox control)
        {
            string aux = string.Empty;
            foreach (System.Web.UI.WebControls.ListItem li in control.Items)
                if (li.Selected) aux = aux + " - " + li.Text;
            return aux;
        }

        protected void txtNroProyecto_TextChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(BusquedaDirecta);
        }

        /*protected override void GetValueOriginal_Tarea_133()
        {
            Filter.IdJurisdiccion = UIHelper.GetIntNullable(ddlJurisdiccion);
            Filter.IdSaf = UIHelper.GetIntNullable(ddlSAF);
            Filter.IdPrograma = UIHelper.GetIntNullable(ddlPrograma);
            Filter.IdSubPrograma = UIHelper.GetIntNullable(ddlSubPrograma);

            Filter.ProyectoDenominacion = UIHelper.GetStringBetweenFilter(txtProyectoDenominacion);
            Filter.IdClasificacionGeografica = UIHelper.GetIntNullable(toLocalizacionGeografica);
            Filter.IncluirClasificacionGeoInteriores = UIHelper.GetBooleanNullable(chkIncluirLocalizacionesInteriores);
            Filter.IdFinalidadFuncion= UIHelper.GetIntNullable(toFinalidadFuncion);
            Filter.IncluirFinalidadFunInteriores = UIHelper.GetBooleanNullable(chkIncluirFinalidadFuncion);
            Filter.IdOficina = UIHelper.GetIntNullable(toOficinas);
            Filter.IncluirOficinasInteriores = UIHelper.GetBooleanNullable(chkIncluirOficinasInteriores);

            Filter.IdPlanVersion = UIHelper.GetInt(ddlPlanVersion);
            Filter.IdPlanPeriodo = UIHelper.GetInt(ddlPlanPeriodo);
            Filter.IdPlanTipo = UIHelper.GetInt(ddlPlanTipo);

            Filter.IdProceso = UIHelper.GetIntNullable(ddlProceso);
            Filter.IdTipoProyecto = UIHelper.GetInt(ddlTipoProyecto);

            Filter.IdSectorialista = UIHelper.GetInt(ddlSectorialista);
            
            Filter.EsBorrador = UIHelper.GetBooleanNullable(chkBorrador);
            Filter.Activo = UIHelper.GetBooleanNullable(chkActivo);
           
       //     Filter.FechaInicioEjecucionCalculada = UIHelper.GetDateTimeNullable(diFechaInicioDesde);
       //     Filter.FechaInicioEjecucionCalculada_To = UIHelper.GetDateTimeNullable(diFechaInicioHasta);
            Filter.IdRol = UIHelper.GetIntNullable(ddlRol);
            Filter.IdPrioridad = UIHelper.GetIntNullable(ddlPriorizacion);
            Filter.IdsCalificacionDictamen = UIHelper.GetSelectedIntValues(lbxCalificacionDictamen);
            Filter.ProyectoDescripcion = UIHelper.GetStringBetweenFilter(txtProyectoDescripcion);
            Filter.RequiereDictamen = UIHelper.GetBooleanNullable(chkRequiereDictamen);
            Filter.RequiereArt15 = UIHelper.GetBooleanNullable(chkRequiereArt15);
            Filter.CalidadPendiente = UIHelper.GetBooleanNullable(chkCalidadPendiente);
            Filter.Codigo = UIHelper.GetIntNullable(txtNroProyecto);
            Filter.IdsEstado = UIHelper.GetSelectedIntValues(lbxEstado);
            int anio=0;
            int.TryParse(UIHelper.GetString(ddlAnio), out anio);               
            Filter.Anio = anio==0?null:(int?)anio;
            Filter.IdUsusarioLogeado = UIContext.Current.ContextUser.User.IdUsuario;
            Filter.UnicamentePorCodigo = true;

            //Filter.FechaAlta = UIHelper.GetFromDateTimeNullable(diFechaInicioDesde);
            //Filter.FechaAlta_To = UIHelper.GetToDateTimeNullable(diFechaInicioHasta);
            //Filter.FechaModificacion = UIHelper.GetFromDateTimeNullable(diFechaModificacionDesde);
            //Filter.FechaModificacion_To = UIHelper.GetToDateTimeNullable(diFechaModificacionHasta);
            Filter.FechaAlta = UIHelper.GetValueFromDate(rdFechaInicio);
            Filter.FechaAlta_To = UIHelper.GetValueToDate(rdFechaInicio);
            Filter.FechaModificacion = UIHelper.GetValueFromDate(rdFechaModificacion);
            Filter.FechaModificacion_To = UIHelper.GetValueToDate(rdFechaModificacion);

            Filter.IdEstadoDeDesicion = UIHelper.GetIntNullable(ddlEstadoDeDesicion);
             #region old
            //Filter.IdTipoProyecto =UIHelper.GetIntNullable(ddlTipoProyecto);
            
			//Filter.ProyectoSituacionActual =UIHelper.GetStringFilter(txtProyectoSituacionActual);
			//Filter.ProyectoObservacion =UIHelper.GetStringFilter(txtProyectoObservacion);
			//Filter.IdEstado =UIHelper.GetIntNullable(lbxEstado);
			//Filter.IdModalidadContratacion =UIHelper.GetIntNullable(ddlModalidadContratacion);
			//Filter.IdFinalidadFuncion =UIHelper.GetIntNullable(ddlFinalidadFuncion);
			//Filter.IdOrganismoPrioridad =UIHelper.GetIntNullable(ddlOrganismoPrioridad);
			//Filter.SubPrioridad=UIHelper.GetIntNullable(txtSubPrioridad);
			//Filter.AnioCorriente=UIHelper.GetIntNullable(txtAnioCorriente);
            //Filter.FechaInicioEjecucionCalculada = UIHelper.GetValueFrom<DateTime?>(rdFechaInicio);
            //Filter.FechaInicioEjecucionCalculada_To = UIHelper.GetValueTo<DateTime?>(rdFechaInicio);

            //Filter.FechaFinEjecucionCalculada = UIHelper.GetValueFrom<DateTime?>(rdFechaFin);
            //Filter.FechaFinEjecucionCalculada_To = UIHelper.GetValueTo<DateTime?>(rdFechaFin);
			//Filter.FechaAlta =UIHelper.GetValueFrom<DateTime?>(rdFechaAlta);
            //Filter.FechaAlta_To = UIHelper.GetValueTo<DateTime?>(rdFechaAlta);

			//Filter.FechaModificacion =UIHelper.GetValueFrom<DateTime?>(rdFechaModificacion);
            //Filter.FechaModificacion_To = UIHelper.GetValueTo<DateTime?>(rdFechaModificacion);


            //Filter.IdUsuarioModificacion=UIHelper.GetIntNullable(txtIdUsuarioModificacion);
            #endregion
        }*/
        protected override void GetValue()
        {
            Filter.IdJurisdiccion = UIHelper.GetIntNullable(ddlJurisdiccion);
            Filter.Visualizacion.Clear();
            if (Filter.IdJurisdiccion != null && Filter.IdJurisdiccion != 0) Filter.Visualizacion.Add("Jurisdiccion", ddlJurisdiccion.SelectedItem.Text);
            Filter.IdSaf = UIHelper.GetIntNullable(ddlSAF);
            if (Filter.IdSaf != null && Filter.IdSaf != 0) Filter.Visualizacion.Add("SAF", ddlSAF.SelectedItem.Text);
            Filter.IdPrograma = UIHelper.GetIntNullable(ddlPrograma);
            if (Filter.IdPrograma != null && Filter.IdPrograma != 0) Filter.Visualizacion.Add("Programa", ddlPrograma.SelectedItem.Text);
            Filter.IdSubPrograma = UIHelper.GetIntNullable(ddlSubPrograma);
            if (Filter.IdSubPrograma != null && Filter.IdSubPrograma != 0) Filter.Visualizacion.Add("SubPrograma", ddlSubPrograma.SelectedItem.Text);
            Filter.ProyectoDenominacion = UIHelper.GetStringBetweenFilter(txtProyectoDenominacion);
            if (Filter.ProyectoDenominacion != null && Filter.ProyectoDenominacion != string.Empty) Filter.Visualizacion.Add("Denominacion", txtProyectoDenominacion.Text);
            Filter.IdOficina = UIHelper.GetIntNullable(toOficinas);
            if (Filter.IdOficina != null) Filter.Visualizacion.Add("Oficinas", toOficinas.Value.Descripcion.Trim());
            Filter.IncluirOficinasInteriores = UIHelper.GetBooleanNullable(chkIncluirOficinasInteriores);
            if (Filter.IncluirOficinasInteriores != null && chkIncluirOficinasInteriores.Checked) Filter.Visualizacion.Add("Incluir Oficinas Interiores", "Si");
            Filter.IdPlanVersion = UIHelper.GetInt(ddlPlanVersion);
            if (Filter.IdPlanVersion != null && Filter.IdPlanVersion != 0) Filter.Visualizacion.Add("Version Plan", ddlPlanVersion.SelectedItem.Text);
            Filter.IdPlanPeriodo = UIHelper.GetInt(ddlPlanPeriodo);
            if (Filter.IdPlanPeriodo != null && Filter.IdPlanPeriodo != 0) Filter.Visualizacion.Add("Periodo Plan", ddlPlanPeriodo.SelectedItem.Text);
            Filter.IdPlanTipo = UIHelper.GetInt(ddlPlanTipo);
            if (Filter.IdPlanTipo != null && Filter.IdPlanTipo != 0) Filter.Visualizacion.Add("Tipo Plan", ddlPlanTipo.SelectedItem.Text);
            Filter.IdProceso = UIHelper.GetIntNullable(ddlProceso);
            if (Filter.IdProceso != null && Filter.IdProceso != 0) Filter.Visualizacion.Add("Proceso", ddlProceso.SelectedItem.Text);
            
             Filter.EsBorrador = UIHelper.GetBooleanNullable(chkBorrador);
            if (Filter.EsBorrador == null) Filter.Visualizacion.Add("Es Borrador", "Todos");
            else if (Convert.ToBoolean(Filter.EsBorrador)) Filter.Visualizacion.Add("Es Borrador", "SI");
            else Filter.Visualizacion.Add("Es Borrador", "NO");
            Filter.Activo = UIHelper.GetBooleanNullable(chkActivo);
            if (Filter.Activo == null) Filter.Visualizacion.Add("Activo", "Todos");
            else if (Convert.ToBoolean(Filter.Activo)) Filter.Visualizacion.Add("Activo", "SI");
            else Filter.Visualizacion.Add("Activo", "NO");
            Filter.Codigo = UIHelper.GetIntNullable(txtNroProyecto);
            if (Filter.Codigo != null) Filter.Visualizacion.Add("Codigo", txtNroProyecto.Text);
            Filter.IdsEstado = UIHelper.GetSelectedIntValues(lbxEstado);
            if (Filter.IdsEstado != null && Filter.IdsEstado.Count != 0) Filter.Visualizacion.Add("Estados", this.GetSelectedTexts(lbxEstado));
           
            Filter.IdUsusarioLogeado = UIContext.Current.ContextUser.User.IdUsuario;
            Filter.UnicamentePorCodigo = true;
            
            Filter.FechaModificacion = UIHelper.GetValueFromDate(rdFechaModificacion);
            if (Filter.FechaModificacion != null) Filter.Visualizacion.Add("Fecha Modificacion Desde", Filter.FechaModificacion.ToString());
            Filter.FechaModificacion_To = UIHelper.GetValueToDate(rdFechaModificacion);
            if (Filter.FechaModificacion_To != null) Filter.Visualizacion.Add("Fecha Modificacion Hasta", Filter.FechaModificacion_To.ToString());
             #region old
            //Filter.IdTipoProyecto =UIHelper.GetIntNullable(ddlTipoProyecto);

            //Filter.ProyectoSituacionActual =UIHelper.GetStringFilter(txtProyectoSituacionActual);
            //Filter.ProyectoObservacion =UIHelper.GetStringFilter(txtProyectoObservacion);
            //Filter.IdEstado =UIHelper.GetIntNullable(lbxEstado);
            //Filter.IdModalidadContratacion =UIHelper.GetIntNullable(ddlModalidadContratacion);
            //Filter.IdFinalidadFuncion =UIHelper.GetIntNullable(ddlFinalidadFuncion);
            //Filter.IdOrganismoPrioridad =UIHelper.GetIntNullable(ddlOrganismoPrioridad);
            //Filter.SubPrioridad=UIHelper.GetIntNullable(txtSubPrioridad);
            //Filter.AnioCorriente=UIHelper.GetIntNullable(txtAnioCorriente);
            //Filter.FechaInicioEjecucionCalculada = UIHelper.GetValueFrom<DateTime?>(rdFechaInicio);
            //Filter.FechaInicioEjecucionCalculada_To = UIHelper.GetValueTo<DateTime?>(rdFechaInicio);

            //Filter.FechaFinEjecucionCalculada = UIHelper.GetValueFrom<DateTime?>(rdFechaFin);
            //Filter.FechaFinEjecucionCalculada_To = UIHelper.GetValueTo<DateTime?>(rdFechaFin);
            //Filter.FechaAlta =UIHelper.GetValueFrom<DateTime?>(rdFechaAlta);
            //Filter.FechaAlta_To = UIHelper.GetValueTo<DateTime?>(rdFechaAlta);

            //Filter.FechaModificacion =UIHelper.GetValueFrom<DateTime?>(rdFechaModificacion);
            //Filter.FechaModificacion_To = UIHelper.GetValueTo<DateTime?>(rdFechaModificacion);


            //Filter.IdUsuarioModificacion=UIHelper.GetIntNullable(txtIdUsuarioModificacion);
            #endregion


            if (!esPeriodoDeStress())
            {
                Filter.IdClasificacionGeografica = UIHelper.GetIntNullable(toLocalizacionGeografica);
                if (Filter.IdClasificacionGeografica != null) Filter.Visualizacion.Add("Localizacion Geografica", toLocalizacionGeografica.Value.Descripcion.Trim());
                Filter.IncluirClasificacionGeoInteriores = UIHelper.GetBooleanNullable(chkIncluirLocalizacionesInteriores);
                if (Filter.IncluirClasificacionGeoInteriores != null && chkIncluirLocalizacionesInteriores.Checked) Filter.Visualizacion.Add("Incluir Clasificacion Geo Interiores", "Si");

                Filter.FechaAlta = UIHelper.GetValueFromDate(rdFechaInicio);
                if (Filter.FechaAlta != null) Filter.Visualizacion.Add("Fecha Alta Desde", Filter.FechaAlta.ToString());
                Filter.FechaAlta_To = UIHelper.GetValueToDate(rdFechaInicio);
                if (Filter.FechaAlta_To != null) Filter.Visualizacion.Add("Fecha Alta Hasta", Filter.FechaAlta_To.ToString());

                Filter.IdTipoProyecto = UIHelper.GetInt(ddlTipoProyecto);
                if (Filter.IdTipoProyecto != null && Filter.IdTipoProyecto != 0) Filter.Visualizacion.Add("Tipo Proyecto", ddlTipoProyecto.SelectedItem.Text);

                Filter.IdRol = UIHelper.GetIntNullable(ddlRol);
                if (Filter.IdRol != null && Filter.IdPrograma != 0) Filter.Visualizacion.Add("Rol", ddlRol.SelectedItem.Text);

                Filter.IdFinalidadFuncion = UIHelper.GetIntNullable(toFinalidadFuncion);
                if (Filter.IdFinalidadFuncion != null) Filter.Visualizacion.Add("Finalidad Funcion", toFinalidadFuncion.Value.Descripcion.Trim());
                Filter.IncluirFinalidadFunInteriores = UIHelper.GetBooleanNullable(chkIncluirFinalidadFuncion);
                if (Filter.IncluirFinalidadFunInteriores != null && chkIncluirFinalidadFuncion.Checked) Filter.Visualizacion.Add("Incluir Finalidad Func. Interiores", "Si");


                Filter.IdEstadoDeDesicion = UIHelper.GetIntNullable(ddlEstadoDeDesicion);
                if (Filter.IdEstadoDeDesicion != null && Filter.IdEstadoDeDesicion != 0) Filter.Visualizacion.Add("Estado Decision", ddlEstadoDeDesicion.SelectedItem.Text);

                Filter.ProyectoDescripcion = UIHelper.GetStringBetweenFilter(txtProyectoDescripcion);
                if (Filter.ProyectoDescripcion != null && Filter.ProyectoDescripcion.Trim() != string.Empty) Filter.Visualizacion.Add("Descripcion", txtProyectoDescripcion.Text);

                Filter.IdPrioridad = UIHelper.GetIntNullable(ddlPriorizacion);
                if (Filter.IdPrioridad != null && Filter.IdPrioridad != 0) Filter.Visualizacion.Add("Prioridad", ddlPriorizacion.SelectedItem.Text);

                Filter.IdsCalificacionDictamen = UIHelper.GetSelectedIntValues(lbxCalificacionDictamen);
                if (Filter.IdsCalificacionDictamen != null && Filter.IdsCalificacionDictamen.Count != 0) Filter.Visualizacion.Add("Clasificaciones Dictamen", this.GetSelectedTexts(lbxCalificacionDictamen));
                Filter.RequiereDictamen = UIHelper.GetBooleanNullable(chkRequiereDictamen);
                if (Filter.RequiereDictamen != null && chkRequiereDictamen.Checked) Filter.Visualizacion.Add("Requiere Dictamen", "Si");
                Filter.RequiereArt15 = UIHelper.GetBooleanNullable(chkRequiereArt15);
                if (Filter.RequiereArt15 != null && chkRequiereArt15.Checked) Filter.Visualizacion.Add("Requiere Art 15", "Si");
                Filter.CalidadPendiente = UIHelper.GetBooleanNullable(chkCalidadPendiente);
                if (Filter.CalidadPendiente != null && chkCalidadPendiente.Checked) Filter.Visualizacion.Add("Calidad Pendiente", "Si");

                int anio = 0;
                int.TryParse(UIHelper.GetString(ddlAnio), out anio);
                Filter.Anio = anio == 0 ? null : (int?)anio;
                if (Filter.Anio != null) Filter.Visualizacion.Add("Anio", Filter.Anio);

                Filter.IdSectorialista = UIHelper.GetInt(ddlSectorialista);
                if (Filter.IdSectorialista != null && Filter.IdSectorialista != 0) Filter.Visualizacion.Add("Sectorialista", ddlSectorialista.SelectedItem.Text);
           
           
            }
        }
        //FinMatias 20140512 - Tarea 133

        private Boolean esPeriodoDeStress()
        {
            bool esAdministrador = (UIContext.Current.ContextUser.Perfiles.Where(perf => perf.Codigo == "ADMIN").FirstOrDefault() != null) ? true : false;
            bool accesoTotal = UIContext.Current.ContextUser.User.AccesoTotal;
            bool proyectoPeriodoStress = SolutionContext.Current.Filtrar_Busqueda_Proyecto_Periodo_Stress ;

            return proyectoPeriodoStress /*&& (!esAdministrador && !accesoTotal)*/;
        }

        #endregion

        #region Events
        protected void btClear_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.CLEAR_SEARCH); 
        }
		protected void btSearch_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SEARCH);
        }
        protected void ddlJurisdiccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(BuscarSafs);
            ddlJurisdiccion.Focus();
        }
        protected void ddlSAF_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(BuscarProgramas);
            ddlSAF.Focus();
        }
        protected void ddlPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(BuscarSubProgramas);
            ddlPrograma.Focus();
        }
        protected void ddlPlanTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(BuscarPlan);
            ddlPlanTipo.Focus();
        }
        protected void btHistoricoPorPlan_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.HISTORY_PLAN);
        }
        protected void ddlTipoProyecto_IndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(CargarProcesos);
            ddlTipoProyecto.Focus();
        }
        protected void toOficina_OnValueChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(CargarRoles);
        }

        #endregion
        #region Private Functions
         private void BuscarSafs()
        {
            Int32 idJurisdiccion = UIHelper.GetInt(ddlJurisdiccion);
            UIHelper.ClearItems(ddlSAF);
            if (idJurisdiccion == 0)
            {
                ddlSAF.Enabled = false;
            }
            else
            {               
                List<SafResult> safs;
                //if (UIContext.Current.ContextUser.User.AccesoTotal )
                //    safs = SafService.Current.GetResultFromList(new nc.SafFilter() { IdJurisdiccion = idJurisdiccion, IdUsuarioOficinasRelacionadasProyecto = UIContext.Current.ContextUser.User.IdUsuario });
                //else
                //    safs = SafService.Current.GetResultFromList(new nc.SafFilter() { IdUsusario = UIContext.Current.ContextUser.User.ID, IdJurisdiccion = idJurisdiccion, IdUsuarioOficinasRelacionadasProyecto = UIContext.Current.ContextUser.User.IdUsuario });
                safs = SafService.Current.GetResultFromList(new nc.SafFilter() { IdsOficinaByUsuario = SetearOficinaUsuarioLogueado(), IdJurisdiccion = idJurisdiccion });
                UIHelper.Load<nc.SafResult>(ddlSAF, safs , "CodigoDenominacion", "IdSaf", new SafResult() { IdSaf = 0, Codigo = "", Denominacion = "Seleccione Saf" }, true, "CodigoInt", Type.GetType("System.Int32"));
                ddlSAF.Enabled = true;
            }
            BuscarProgramas();
        }
        private void BuscarProgramas()
        {
            Int32 idSaf = UIHelper.GetInt(ddlSAF);
            if (idSaf == 0)
            {
                UIHelper.ClearItems(ddlPrograma);
                ddlPrograma.Enabled = false;
            }
            else
            {
                
                List<ProgramaResult> programas;
                //if (UIContext.Current.ContextUser.User.AccesoTotal || CrudAction != CrudActionEnum.Create)
                //    programa = ProgramaService.Current.GetResult(new nc.ProgramaFilter() { IdSAF = idSaf, Activo = true });
                //else
                //    programa = ProgramaService.Current.GetResult(new nc.ProgramaFilter() { IdSAF = idSaf, Activo = true, IdUsuarioSaf = UIContext.Current.ContextUser.User.ID });
                programas = ProgramaService.Current.GetResultFromList(new nc.ProgramaFilter() { IdsOficinaByUsuario = SetearOficinaUsuarioLogueado(), IdSAF = idSaf });
                UIHelper.Load<nc.ProgramaResult>(ddlPrograma, programas, "CodigoNombre", "IdPrograma", new ProgramaResult() { IdPrograma = 0, Codigo = "", Nombre = "Seleccione Programa" }, true, "CodigoInt", Type.GetType("System.Int32"));
                ddlPrograma.Enabled = true;
            }
            BuscarSubProgramas();
        }
        private void BuscarSubProgramas()
        {
            Int32 idPrograma = UIHelper.GetInt(ddlPrograma);
            if (idPrograma == 0)
            {
                UIHelper.ClearItems(ddlSubPrograma);
                ddlSubPrograma.Enabled = false;
            }
            else
            {
                List<SubProgramaResult> SubProgramas;
                SubProgramas = SubProgramaService.Current.GetResultFromList(new nc.SubProgramaFilter() { IdsOficinaByUsuario = SetearOficinaUsuarioLogueado(), IdPrograma = idPrograma });
                UIHelper.Load<nc.SubProgramaResult>(ddlSubPrograma, SubProgramas, "CodigoNombre", "IdSubPrograma", new SubProgramaResult() { IdSubPrograma = 0, Codigo = "", Nombre = "Seleccione SubPrograma" }, true, "CodigoInt", Type.GetType("System.Int32"));
                ddlSubPrograma.Enabled = true;
            }
        }
        private void BuscarPlan()
        {
            Int32 idPlanTipo = UIHelper.GetInt(ddlPlanTipo );
            if (idPlanTipo  == 0)
            {
                UIHelper.ClearItems(ddlPlanPeriodo);
                ddlPlanPeriodo.Enabled = false;
                UIHelper.ClearItems(ddlPlanVersion);
                ddlPlanVersion.Enabled = false;
            }
            else
            {
                nc.PlanPeriodoFilter planPeriodoFilter = new nc.PlanPeriodoFilter();
                planPeriodoFilter.OrderBys.Add(new FilterOrderBy( "AnioInicial", true));
                planPeriodoFilter.IdPlanTipo = idPlanTipo;

                UIHelper.Load<nc.PlanPeriodo>(ddlPlanPeriodo, PlanPeriodoService.Current.GetList(planPeriodoFilter), "Nombre", "IdPlanPeriodo", new nc.PlanPeriodo() { IdPlanPeriodo = 0, Nombre = "Seleccione Período" }, false);
                UIHelper.Load<nc.PlanVersion>(ddlPlanVersion, PlanVersionService.Current.GetList(new nc.PlanVersionFilter() { IdPlanTipo = idPlanTipo }), "Nombre", "IdPlanVersion", new nc.PlanVersion() { IdPlanVersion = 0, Nombre = "Seleccione Versión" }, true,"Orden");

                ddlPlanPeriodo.Enabled = true;
                ddlPlanVersion.Enabled = true;
            }
        }
        private void ClearCombosAnidados()
        {
            UIHelper.ClearItems(ddlSAF);
            ddlSAF.Enabled = false;
            UIHelper.ClearItems(ddlPrograma);
            ddlPrograma.Enabled = false;
            UIHelper.ClearItems(ddlSubPrograma);
            ddlSubPrograma.Enabled = false;
            UIHelper.ClearItems(ddlPlanPeriodo);
            ddlPlanPeriodo.Enabled = false;
            UIHelper.ClearItems(ddlPlanVersion);
            ddlPlanVersion.Enabled = false;
        }
        private void CargarProcesos()
        {
            Int32 idTipoProyecto = UIHelper.GetInt(ddlTipoProyecto);
            if (idTipoProyecto != 0)
            {
                UIHelper.Load<ProcesoResult>(ddlProceso, ProcesoService.Current.GetResult(new nc.ProcesoFilter() { IdProyectoTipo = idTipoProyecto, Activo = true }), "Nombre", "IdProceso", new ProcesoResult() { IdProceso = 0, Nombre = "Seleccione Proceso" });
                ddlProceso.Enabled = true;
            }
            else
            {
                UIHelper.ClearItems(ddlProceso);
                ddlProceso.Enabled = false;
            }
        }
        private void CargarRoles()
        {
            Int32? IdOficina = UIHelper.GetIntNullable(toOficinas); ;
            if (IdOficina != null)
            {
                UIHelper.Load<nc.PerfilResult>(ddlRol, PerfilService.Current.GetResult(new nc.PerfilFilter() { IdPerfilTipo = (int)PerfilTipoEnum.Proyecto }), "Nombre", "IdPerfil", new PerfilResult() { IdPerfil = 0, Nombre = "Seleccione Rol" });
                ddlRol.Enabled = true;
            }
            else
            {
                UIHelper.ClearItems(ddlRol);
                ddlRol.Enabled = false;
            }
        }
        private void CargarJurisdicciones()
        {

            List<JurisdiccionResult> jurisdicciones;
            //if (UIContext.Current.ContextUser.User.AccesoTotal)
            //    jurisdicciones = JurisdiccionService.Current.GetResultFromList(new nc.JurisdiccionFilter());
            //else
            //    jurisdicciones = JurisdiccionService.Current.GetResultFromList(new nc.JurisdiccionFilter() { IdUsuarioSaf = UIContext.Current.ContextUser.User.ID });
            jurisdicciones = JurisdiccionService.Current.GetResultFromList(new nc.JurisdiccionFilter() { IdsOficinaByUsuario = SetearOficinaUsuarioLogueado() });
            UIHelper.Load<nc.JurisdiccionResult>(ddlJurisdiccion, jurisdicciones, "CodigoNombre", "IdJurisdiccion", new JurisdiccionResult() { IdJurisdiccion = 0, Codigo = "", Nombre = "Seleccione Jurisdicción" }, true, "CodigoInt", Type.GetType("System.Int32"));

        }
        private List<Int32> SetearOficinaUsuarioLogueado()
        {
            bool enableFilterOffice = SolutionContext.Current.ParameterManager.GetBooleanValue("OFFICE_FILTER_ENABLE");
            List<Int32> IdsOficinaByUsuario = new List<int> ();
            if (enableFilterOffice &&  UIContext.Current.ContextUser != null &&  UIContext.Current.ContextUser.User.AccesoTotal == false)
            {
                IdsOficinaByUsuario = OficinaService.Current.GetIdsOficinaPorUsuario(UIContext.Current.ContextUser.User.IdUsuario);
            }
            else
            {
                Filter.IdsOficinaByUsuario = null;
            }
            return IdsOficinaByUsuario;
        }
        private void SetearDatosOficina()
        {
            UIHelper.SetValue(ddlJurisdiccion, OficinaUsuario.Saf_IdJurisdiccion);
            BuscarSafs();
            UIHelper.SetValue(ddlSAF, OficinaUsuario.IdSaf);
            BuscarProgramas();
        }
        private void BusquedaDirecta()
        {
            Int32 CodigoBapin = UIHelper.GetInt(txtNroProyecto);
            RaiseControlCommand(Command.SEARCH, CodigoBapin);
        }

        #endregion

    }
}

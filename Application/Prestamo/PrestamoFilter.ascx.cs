using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc=Contract;
using Service;

namespace UI.Web
{
    public partial class PrestamoFilter : WebControlFilter<nc.PrestamoFilter>
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
                        oficinaUsuario = OficinaService.Current.GetResult(new nc.OficinaFilter() { IdOficina = UIContext.Current.ContextUser.User.Persona_IdOficina }).SingleOrDefault();
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

		protected override void _Initialize()
        {
            base._Initialize();
            toFinalidadFuncion.Width = 500;
            toOficina.Width = 480;

            rdFechaAlta.ErrorMessageValidator = TranslateFormat("InvalidField", "Rango de Fechas de Alta");
            rdFechaAlta.RangeErrorMessageFrom = TranslateFormat("InvalidField", "Fecha de Alta de");
            rdFechaAlta.RangeErrorMessageTo = TranslateFormat("InvalidField", "Fecha de Alta a");
            rdFechaModificacion.ErrorMessageValidator = TranslateFormat("InvalidField", "Rango de Fechas de Modificación");
            rdFechaModificacion.RangeErrorMessageFrom = TranslateFormat("InvalidField", "Fecha de Modificación de");
            rdFechaModificacion.RangeErrorMessageTo = TranslateFormat("InvalidField", "Fecha de Modificación a");

            //CargarJurisdicciones(); //Matias 20170124 - Ticket #ER573599
            //UIHelper.Load<nc.Saf>(ddlSAF, SafService.Current.GetList(), "Denominacion", "IdSaf", new nc.Saf() { IdSaf = 0, Denominacion = "Seleccione SAF" });
            UIHelper.Load<nc.OrganismoFinanciero>(ddlOrganismoFinanciero, OrganismoFinancieroService.Current.GetList(), "Nombre", "IdOrganismoFinanciero", new nc.OrganismoFinanciero() { IdOrganismoFinanciero = 0, Nombre = "Seleccione Organismo Financiero" });
            //UIHelper.Load<nc.Oficina>(ddlOficinaResponsable, OficinaService.Current.GetList(), "Nombre", "IdOficina", new nc.Oficina() { IdOficina = 0, Nombre = "Seleccione Oficina" });
            //UIHelper.Load<nc.Programa>(ddlPrograma, ProgramaService.Current.GetList(), "Nombre", "IdPrograma", new nc.Programa() { IdPrograma = 0, Nombre = "Seleccione Programa" });
            revDenominacion.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(500);
            revNumero.ValidationExpression=Contract.DataHelper.GetExpRegNumberNullable();
            revCodigoVinculado.ValidationExpression = Contract.DataHelper.GetExpRegNumberNullable();
            chkActivo.CheckedValue = true;
            CargarJurisdicciones();
            SetearDatosOficina();
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(ddlJurisdiccion);
			ddlJurisdiccion.Focus();
            UIHelper.Clear(txtDenominacion);
			UIHelper.Clear(ddlOrganismoFinanciero);
			UIHelper.Clear(toFinalidadFuncion);
            UIHelper.Clear(chkIncluirFinalidadFuncionInteriores);
            UIHelper.Clear(chkIncluirOficinasInteriores);
            UIHelper.Clear(txtNumero);
            //UIHelper.Clear(diFechaAltaDesde);
            //UIHelper.Clear(diFechaAltaHasta);
            //UIHelper.Clear(diFechaModificacionDesde);
            //UIHelper.Clear(diFechaModificacionHasta);
            UIHelper.Clear(rdFechaAlta);
            UIHelper.Clear(rdFechaModificacion);
            UIHelper.Clear(toOficina);
			UIHelper.Clear(txtCodigoVinculado);
            chkActivo.CheckedValue = true;
            ClearCombosAnidados();
            CargarJurisdicciones();
            SetearDatosOficina();
        }		
		protected override void SetValue()
        {
            ddlJurisdiccion.Focus();
            UIHelper.SetValue(ddlOrganismoFinanciero, Filter.IdOrganismoFinanciero);
            UIHelper.SetValue(toFinalidadFuncion, Filter.IdFinalidadFuncion);
			UIHelper.SetValueFilter(txtDenominacion, Filter.Denominacion);
            UIHelper.SetValue(chkIncluirFinalidadFuncionInteriores, Filter.IncluirFinalidadFuncionInteriores);
            UIHelper.SetValue(toOficina, Filter.IdOficinaResponsable);
            UIHelper.SetValue(chkIncluirOficinasInteriores, Filter.IncluirOficinasInteriores);
            UIHelper.SetValue(txtNumero, Filter.Numero);
            //UIHelper.SetValue(diFechaAltaDesde, Filter.FechaAlta);
            //UIHelper.SetValue(diFechaAltaHasta, Filter.FechaAlta_To);
            //UIHelper.SetValue(diFechaModificacionDesde, Filter.FechaModificacion);
            //UIHelper.SetValue(diFechaModificacionHasta, Filter.FechaModificacion_To);
            UIHelper.SetValue<DateTime?>(rdFechaAlta, Filter.FechaAlta, Filter.FechaAlta_To);
            UIHelper.SetValue<DateTime?>(rdFechaModificacion, Filter.FechaModificacion, Filter.FechaModificacion_To);
            UIHelper.SetValue(txtCodigoVinculado, Filter.CodBapinAsociado);
            UIHelper.SetValue(ddlJurisdiccion, Filter.IdJurisdiccion);
            BuscarSafs();
            UIHelper.SetValue(ddlSAF, Filter.IdSaf);
            BuscarProgramas();
            UIHelper.SetValue(ddlPrograma, Filter.IdPrograma);
            UIHelper.SetValue(chkActivo, Filter.Activo);

            #region old
            /*UIHelper.SetValueFilter(txtDescripcion, Filter.Descripcion);
			UIHelper.SetValueFilter(txtObservacion, Filter.Observacion);
			UIHelper.SetValue<DateTime?>(rdFechaAlta, Filter.FechaAlta, Filter.FechaAlta_To);
			UIHelper.SetValue<DateTime?>(rdFechaModificacion, Filter.FechaModificacion, Filter.FechaModificacion_To);
			UIHelper.SetValue(txtIdUsuarioModificacion, Filter.IdUsuarioModificacion);
            */
            #endregion
        }	
        protected override void GetValue()
        {
            Filter.IdJurisdiccion = UIHelper.GetIntNullable(ddlJurisdiccion);
            Filter.IdSaf = UIHelper.GetIntNullable(ddlSAF);
			Filter.IdPrograma =UIHelper.GetIntNullable(ddlPrograma);
            Filter.Denominacion = UIHelper.GetStringBetweenFilter(txtDenominacion);
            Filter.IdOrganismoFinanciero = UIHelper.GetIntNullable(ddlOrganismoFinanciero);
            Filter.IdFinalidadFuncion = UIHelper.GetIntNullable(toFinalidadFuncion);
            Filter.Numero = UIHelper.GetIntNullable(txtNumero);
            Filter.IncluirFinalidadFuncionInteriores = UIHelper.GetBooleanNullable(chkIncluirFinalidadFuncionInteriores);
            Filter.IncluirOficinasInteriores = UIHelper.GetBooleanNullable(chkIncluirOficinasInteriores);
            //Filter.FechaAlta = UIHelper.GetFromDateTimeNullable(diFechaAltaDesde);
            //Filter.FechaAlta_To = UIHelper.GetToDateTimeNullable(diFechaAltaHasta);
            //Filter.FechaModificacion = UIHelper.GetFromDateTimeNullable(diFechaModificacionDesde);
            //Filter.FechaModificacion_To = UIHelper.GetToDateTimeNullable(diFechaModificacionHasta);
            Filter.FechaAlta = UIHelper.GetValueFromDate(rdFechaAlta);
            Filter.FechaAlta_To = UIHelper.GetValueToDate(rdFechaAlta);
            Filter.FechaModificacion = UIHelper.GetValueFromDate(rdFechaModificacion);
            Filter.FechaModificacion_To = UIHelper.GetValueToDate(rdFechaModificacion);
            Filter.IdOficinaResponsable = UIHelper.GetIntNullable(toOficina);
            Filter.CodBapinAsociado = UIHelper.GetIntNullable(txtCodigoVinculado);
            Filter.Activo = UIHelper.GetBooleanNullable(chkActivo);
            Filter.UnicamentePorCodigo = true;
            
            #region old
            /* 
            Filter.Descripcion = UIHelper.GetStringFilter(txtDescripcion);
            Filter.Observacion = UIHelper.GetStringFilter(txtObservacion);
            Filter.IdUsuarioModificacion = UIHelper.GetIntNullable(txtIdUsuarioModificacion);*/
			#endregion
        }
        #region Events
        protected void btClear_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.CLEAR_SEARCH);
        }
		protected void btSearch_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SEARCH);
        }
        protected void ddlSAF_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(BuscarProgramas);
        }
        protected void ddlJurisdiccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(BuscarSafs);
        }
        protected void txtNroPrestamo_TextChanged(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(BusquedaDirecta);
        }
        #endregion
        #region Private Functions



        //private void BuscarSAF()
        //{
        //    Int32 idJurisdiccion = UIHelper.GetInt(ddlJurisdiccion);
        //    if (idJurisdiccion == 0)
        //    {
        //        UIHelper.ClearItems(ddlSAF);
        //        ddlSAF.Enabled = false;
        //    }
        //    else
        //    {
        //        UIHelper.Load<nc.SafResult>(ddlSAF, SafService.Current.GetResult(new nc.SafFilter() { IdJurisdiccion = idJurisdiccion,IdUsuarioOficinasRelacionadasProyecto = UIContext.Current.ContextUser.User.IdUsuario }), "CodigoDenominacion", "IdSaf", new SafResult() { IdSaf = 0, Codigo = "", Denominacion = "Seleccione Saf" });
        //        ddlSAF.Enabled = true;
        //    }
        //    BuscarProgramas();
        //}
        //private void BuscarProgramas()
        //{
        //    Int32 idSaf = UIHelper.GetInt(ddlSAF);
        //    if (idSaf == 0)
        //    {
        //        UIHelper.ClearItems(ddlPrograma);
        //        ddlPrograma.Enabled = false;
        //    }
        //    else
        //    {
        //        UIHelper.Load<nc.ProgramaResult>(ddlPrograma, ProgramaService.Current.GetResult(new nc.ProgramaFilter() { IdSAF = idSaf }), "CodigoNombre", "IdPrograma", new ProgramaResult() { IdPrograma = 0, Codigo = "", Nombre = "Seleccione Programa" });
        //        ddlPrograma.Enabled = true;
        //    }
        //}

        private void BuscarSafs()
        {
            Int32 idJurisdiccion = UIHelper.GetInt(ddlJurisdiccion);
            if (idJurisdiccion == 0)
            {
                UIHelper.ClearItems(ddlSAF);
                ddlSAF.Enabled = false;
            }
            else
            {
                List<SafResult> safs;
                if (UIContext.Current.ContextUser.User.AccesoTotal)
                    safs = SafService.Current.GetResultFromList(new nc.SafFilter() { IdJurisdiccion = idJurisdiccion, IdUsuarioOficinasRelacionadasProyecto = UIContext.Current.ContextUser.User.IdUsuario });
                else
                    safs = SafService.Current.GetResultFromList(new nc.SafFilter() { IdUsusario = UIContext.Current.ContextUser.User.ID, IdJurisdiccion = idJurisdiccion, IdUsuarioOficinasRelacionadasProyecto = UIContext.Current.ContextUser.User.IdUsuario });
                UIHelper.Load<nc.SafResult>(ddlSAF, safs, "CodigoDenominacion", "IdSaf", new SafResult() { IdSaf = 0, Codigo = "", Denominacion = "Seleccione Saf" }, true, "CodigoInt", Type.GetType("System.Int32"));
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

                List<ProgramaResult> programa;
                if (UIContext.Current.ContextUser.User.AccesoTotal || CrudAction != CrudActionEnum.Create)
                    programa = ProgramaService.Current.GetResult(new nc.ProgramaFilter() { IdSAF = idSaf, Activo = true });
                else
                    programa = ProgramaService.Current.GetResult(new nc.ProgramaFilter() { IdSAF = idSaf, Activo = true, IdUsuarioSaf = UIContext.Current.ContextUser.User.ID });

                UIHelper.Load<nc.ProgramaResult>(ddlPrograma, programa, "CodigoNombre", "IdPrograma", new ProgramaResult() { IdPrograma = 0, Codigo = "", Nombre = "Seleccione Programa" }, true, "CodigoInt", Type.GetType("System.Int32"));
                ddlPrograma.Enabled = true;
            }           
        }

        private void ClearCombosAnidados()
        {
            UIHelper.ClearItems(ddlSAF);
            ddlSAF.Enabled = false;
            UIHelper.ClearItems(ddlPrograma);
            ddlPrograma.Enabled = false;
        }

        private void CargarJurisdicciones()
        {

            List<JurisdiccionResult> jurisdicciones;
            //Matias 20170124 - Ticket #ER573599
            //if (UIContext.Current.ContextUser.User.AccesoTotal)
            //    jurisdicciones = JurisdiccionService.Current.GetResultFromList(new nc.JurisdiccionFilter());
            //else
            //    jurisdicciones = JurisdiccionService.Current.GetResultFromList(new nc.JurisdiccionFilter() { IdUsuarioSaf = UIContext.Current.ContextUser.User.ID });
            jurisdicciones = JurisdiccionService.Current.GetResultFromList(new nc.JurisdiccionFilter() { IdsOficinaByUsuario = SetearOficinaUsuarioLogueado() });
            //FinMatias 20170124 - Ticket #ER573599
            
            UIHelper.Load<nc.JurisdiccionResult>(ddlJurisdiccion, jurisdicciones, "CodigoNombre", "IdJurisdiccion", new JurisdiccionResult() { IdJurisdiccion = 0, Codigo = "", Nombre = "Seleccione Jurisdicción" }, true, "CodigoInt", Type.GetType("System.Int32"));

        }
        //Matias 20170124 - Ticket #ER573599
        private List<Int32> SetearOficinaUsuarioLogueado()
        {
            bool enableFilterOffice = SolutionContext.Current.ParameterManager.GetBooleanValue("OFFICE_FILTER_ENABLE");
            List<Int32> IdsOficinaByUsuario = new List<int>();
            if (enableFilterOffice && UIContext.Current.ContextUser != null && UIContext.Current.ContextUser.User.AccesoTotal == false)
            {
                IdsOficinaByUsuario = OficinaService.Current.GetIdsOficinaPorUsuario(UIContext.Current.ContextUser.User.IdUsuario);
            }
            else
            {
                Filter.IdsOficinaByUsuario = null;
            }
            return IdsOficinaByUsuario;
        }
        //FinMatias 20170124 - Ticket #ER573599
        private void SetearDatosOficina()
        {
            UIHelper.SetValue(ddlJurisdiccion, OficinaUsuario.Saf_IdJurisdiccion);
            BuscarSafs();
            UIHelper.SetValue(ddlSAF, OficinaUsuario.IdSaf);
            BuscarProgramas();
        }
        private void BusquedaDirecta()
        {
            Int32 Codigo= UIHelper.GetInt(txtNumero);
            RaiseControlCommand(Command.SEARCH, Codigo);
        }

        #endregion

       
    }
}

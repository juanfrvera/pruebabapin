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
    public partial class PrestamoDictamenEdit : WebControlEdit<nc.PrestamoDictamenCompose>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revExpediente.ValidationExpression=Contract.DataHelper.GetExpRegString(50);
            revExpediente.ErrorMessage = TranslateFormat("InvalidField", "Expediente");
            rfvExpediente.ErrorMessage = TranslateFormat("InvalidField", "Expediente");

			revOrganismoDetalle.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(255);
            revOrganismoDetalle.ErrorMessage = TranslateFormat("InvalidField", "Organimo Detalle");
            
            revDenominacion.ValidationExpression = Contract.DataHelper.GetExpRegString(500);
            revDenominacion.ErrorMessage = TranslateFormat("InvalidField", "Denominación");
            rfvDenominacion.ErrorMessage = TranslateFormat("FieldIsNull", "Denominación");

            revMontoContraparteLocal.ValidationExpression = Contract.DataHelper.GetExpRegNumber();
            revMontoContraparteLocal.ErrorMessage = TranslateFormat("InvalidField", "Monto Total");
           
            revMontoOtros.ValidationExpression = Contract.DataHelper.GetExpRegNumber();
            revMontoOtros.ErrorMessage = TranslateFormat("InvalidField", "Monto Otros");
            
            revMontoPrestamo.ValidationExpression = Contract.DataHelper.GetExpRegNumber();
            revMontoPrestamo.ErrorMessage = TranslateFormat("InvalidField", "Monto Préstamo");

            revComentario.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(500);
            revComentario.ErrorMessage = TranslateFormat("InvalidField", "Comentario");

            revCalificacionITecnico.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(50);
            revCalificacionITecnico.ErrorMessage = TranslateFormat("InvalidField", "ITecnico Calificación");
            revCalificacionNotaDNIP.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(50);
            revCalificacionNotaDNIP.ErrorMessage = TranslateFormat("InvalidField", "Nota DNIP Calificación");
            revCalificacionObservacion.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(2147483647);
            revCalificacionObservacion.ErrorMessage = TranslateFormat("InvalidField", "Observación Calificación");
            revCalificacionRecomendacion.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(2147483647);
            revCalificacionRecomendacion.ErrorMessage = TranslateFormat("InvalidField", "Recomendación Calificación");
			//UIHelper.Load<nc.Usuario>(ddlUsuarioModificacion, UsuarioService.Current.GetList(),"NombreUsuario","IdUsuario",new nc.Usuario(){IdUsuario=0, NombreUsuario= "Seleccione Usuario"});
            //diFechaAlta.RequiredErrorMessage = TranslateFormat("FieldIsNull", "Fecha de Alta");
            //diFechaModificacion.RequiredErrorMessage = TranslateFormat("FieldIsNull", "Fecha de Modificación");

            UIHelper.Load<nc.Organismo>(ddlOrganismo, OrganismoService.Current.GetList(new nc.OrganismoFilter() { Activo = true }), "Nombre", "IdOrganismo", new nc.Organismo() { IdOrganismo = 0, Nombre = "Seleccione Organismo" });
            rfvOrganismo.ErrorMessage = TranslateFormat("FieldIsNull", "Organismo");
            UIHelper.Load<nc.GestionTipo>(ddlGestionTipo, GestionTipoService.Current.GetList(new nc.GestionTipoFilter() { Activo = true }), "Nombre", "IdGestionTipo", new nc.GestionTipo() { IdGestionTipo = 0, Nombre = "Seleccione GestionTipo" });
            rfvGestionTipo.ErrorMessage = TranslateFormat("FieldIsNull", "Tipo de Gestión");
            UIHelper.Load<nc.OrganismoFinanciero>(ddlOrganismoFinanciero, OrganismoFinancieroService.Current.GetList(new nc.OrganismoFinancieroFilter() { Activo = true }), "Nombre", "IdOrganismoFinanciero", new nc.OrganismoFinanciero() { IdOrganismoFinanciero = 0, Nombre = "Seleccione OrganismoFinanciero" });
            rfvOrganismoFinanciero.ErrorMessage = TranslateFormat("FieldIsNull", "Organismo Financiero");
            //UIHelper.Load<nc.Prestamo>(ddlPrestamo, PrestamoService.Current.GetList(), "Descripcion", "IdPrestamo", new nc.Prestamo() { IdPrestamo = 0, Descripcion = "Seleccione Prestamo" });
            //UIHelper.Load<nc.PrestamoDictamen>(ddlPrestamoDictamenRelacionado, PrestamoDictamenService.Current.GetList(), "Expediente", "IdPrestamoDictamen", new nc.PrestamoDictamen() { IdPrestamoDictamen = 0, Expediente = "Seleccione PrestamoDictamen" });
            UIHelper.Load<nc.PrestamoCalificacion>(ddlPrestamoCalificacion, PrestamoCalificacionService.Current.GetList(new nc.PrestamoCalificacionFilter() { Activo = true }), "Nombre", "IdPrestamoCalificacion", new nc.PrestamoCalificacion() { IdPrestamoCalificacion = 0, Nombre = "Seleccione PrestamoCalificacion" });

            UIHelper.Load<UsuarioResult>(ddlAnalista, UsuarioService.Current.GetResult(new nc.UsuarioFilter() { Activo = true, EsSectioralista = true }), "ApellidoYNombre", "IdUsuario", new UsuarioResult() { Persona_Nombre = "Seleccione Analista", Persona_Apellido = String.Empty, IdUsuario = 0 });
            rfvAnalista.ErrorMessage = TranslateFormat("FieldIsNull", "Analista");
            UIHelper.Load<EstadoResult>(ddlEstadoPopUpEstado, EstadoService.Current.GetResult(new nc.EstadoFilter() { EntidadTipo = SistemaEntidadConfig.PRESTAMO_DICTAMEN, Activo = true }), "Nombre", "IdEstado", new EstadoResult() { IdEstado = 0, Nombre = "Seleccione Estado" });
            UIHelper.Load<UsuarioResult>(ddlUsuarioPopUpEstado, UsuarioService.Current.GetResult(new nc.UsuarioFilter() { Activo = true, EsSectioralista = true }), "ApellidoYNombre", "IdUsuario", new UsuarioResult() { Persona_Nombre = "Seleccione Analista", Persona_Apellido = String.Empty, IdUsuario = 0 });

            diFechaPopUpEstado.RequiredErrorMessage = TranslateFormat("FieldIsNull", "Fecha Estado");
            rfvEstadoPopUpEstado.ErrorMessage = TranslateFormat("FieldIsNull", "Estado");
            rfvUsuarioPopUpEstado.ErrorMessage = TranslateFormat("FieldIsNull", "Usuario");

            PopUpEstados.Attributes.CssStyle.Add("display", "none");

            RegistrarScriptTotales();
            IsReadOnly = false;
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtExpediente);
			txtExpediente.Focus();
				UIHelper.Clear(ddlOrganismo);
			UIHelper.Clear(txtOrganismoDetalle);
			UIHelper.Clear(txtDenominacion);
			UIHelper.Clear(ddlGestionTipo);
			UIHelper.Clear(ddlOrganismoFinanciero);
			UIHelper.Clear(txtMontoOtros);
			UIHelper.Clear(txtMontoPrestamo);
            UIHelper.Clear(txtMontoContraparteLocal);
            UIHelper.Clear(ddlAnalista);          
			//UIHelper.Clear(ddlPrestamo);
			//UIHelper.Clear(ddlPrestamoDictamenRelacionado);
			UIHelper.Clear(txtComentario);
			UIHelper.Clear(ddlPrestamoCalificacion);
			UIHelper.Clear(diCalificacionFecha);
			UIHelper.Clear(txtCalificacionITecnico);
			UIHelper.Clear(diCalificacionITFecha);
			UIHelper.Clear(txtCalificacionNotaDNIP);
			UIHelper.Clear(txtCalificacionObservacion);
			UIHelper.Clear(txtCalificacionRecomendacion);
            UIHelper.Clear(lblMontoTotal);
            UIHelper.SetValue(diFechaEstado, DateTime.Now);
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtExpediente, Entity.Dictamen.Expediente);
			txtExpediente.Focus();
			UIHelper.SetValue<Organismo,int>(ddlOrganismo, Entity.Dictamen.IDOrganismo, OrganismoService.Current.GetById);
            if (Entity.Dictamen.IdAnalista.HasValue)
            {
                UIHelper.SetValue<UsuarioResult,int>(ddlAnalista, Entity.Dictamen.IdAnalista.Value, UsuarioService.Current.GetResultById);
               // UIHelper.SetValue(ddlAnalista, Entity.Dictamen.Analista_ApellidoYNombre);
            }
			UIHelper.SetValue(txtOrganismoDetalle, Entity.Dictamen.OrganismoDetalle);
			UIHelper.SetValue(txtDenominacion, Entity.Dictamen.Denominacion);
			UIHelper.SetValue<GestionTipo,int>(ddlGestionTipo, Entity.Dictamen.IdGestionTipo, GestionTipoService.Current.GetById);
			UIHelper.SetValue<OrganismoFinanciero,int>(ddlOrganismoFinanciero, Entity.Dictamen.IdOrganismoFinanciero,OrganismoFinancieroService.Current.GetById);
            UIHelper.SetValue(txtMontoContraparteLocal, Entity.Dictamen.MontoContraparteLocal.HasValue ?Entity.Dictamen.MontoContraparteLocal.Value.ToString("N0"):"0");
            UIHelper.SetValue(txtMontoPrestamo, Entity.Dictamen.MontoPrestamo.HasValue ? Entity.Dictamen.MontoPrestamo.Value.ToString("N0") : "0");
            UIHelper.SetValue(txtMontoOtros, Entity.Dictamen.MontoOtros.HasValue ? Entity.Dictamen.MontoOtros.Value.ToString("N0") : "0");
           
			//UIHelper.SetValue(ddlPrestamo, Entity.Dictamen.IdPrestamo);
			//UIHelper.SetValue(ddlPrestamoDictamenRelacionado, Entity.Dictamen.IdPrestamoDictamenRelacionado);
			UIHelper.SetValue(txtComentario, Entity.Dictamen.Comentario);
			if(Entity.Dictamen.IDPrestamoCalificacion.HasValue)
                UIHelper.SetValue<PrestamoCalificacion,int>(ddlPrestamoCalificacion, Entity.Dictamen.IDPrestamoCalificacion.Value,PrestamoCalificacionService.Current.GetById);
			UIHelper.SetValue(diCalificacionFecha, Entity.Dictamen.CalificacionFecha);
			UIHelper.SetValue(txtCalificacionITecnico, Entity.Dictamen.CalificacionITecnico);
			UIHelper.SetValue(diCalificacionITFecha, Entity.Dictamen.CalificacionITFecha);
			UIHelper.SetValue(txtCalificacionNotaDNIP, Entity.Dictamen.CalificacionNotaDNIP);
			UIHelper.SetValue(txtCalificacionObservacion, Entity.Dictamen.CalificacionObservacion);
			UIHelper.SetValue(txtCalificacionRecomendacion, Entity.Dictamen.CalificacionRecomendacion);
            Decimal MontoTotal = Entity.Dictamen.MontoTotal.HasValue?Entity.Dictamen.MontoTotal.Value:0;
            UIHelper.SetValue(lblMontoTotal, MontoTotal.ToString ("N0"));
            UIHelper.SetValue(txtPrestamoNumero, Entity.Dictamen.Prestamo_Numero);
            UIHelper.SetValue(lblPrestamoDenominacion, Entity.Dictamen.Prestamo_Denominacion);

            PrestamoDictamenEstadoRefresh();
	
        }	
        public void SetReadOnly()
        {
            txtExpediente.ReadOnly = true;
            ddlOrganismo.Enabled = false;
            ddlOrganismoFinanciero.Enabled = false;
            txtOrganismoDetalle.ReadOnly = true;
            txtDenominacion.ReadOnly = true;
            ddlGestionTipo.Enabled = false;
            ddlOrganismoFinanciero.Enabled = false;
            txtMontoContraparteLocal.ReadOnly = true;
            txtMontoPrestamo.ReadOnly = true;
            txtMontoOtros.ReadOnly = true;
            txtComentario.ReadOnly = true;
            ddlPrestamoCalificacion.Enabled = false;
            diCalificacionFecha.ReadOnly = true;
            diCalificacionITFecha.ReadOnly = true;
            txtCalificacionITecnico.ReadOnly = true;
            txtCalificacionNotaDNIP.ReadOnly = true;
            txtPrestamoDictamenRelacionado.ReadOnly = true; 
            txtCalificacionObservacion.ReadOnly = true;
            txtCalificacionRecomendacion.ReadOnly = true;
            txtPrestamoNumero.ReadOnly = true;
            btAgregarEstado.Enabled = false;
            txtPrestamoNumero.TextChanged -= txtPrestamoNumero_TextChanged;
            txtPrestamoDictamenRelacionado.TextChanged -= txtPrestamoDictamenRelacionado_TextChanged;
            txtPrestamoNumero.AutoPostBack = false;
            txtPrestamoDictamenRelacionado.AutoPostBack = false;
            IsReadOnly = true;

        }
        public override void GetValue()
        {
			Entity.Dictamen.Expediente =UIHelper.GetString(txtExpediente);
			Entity.Dictamen.IDOrganismo =UIHelper.GetInt(ddlOrganismo);
			Entity.Dictamen.OrganismoDetalle =UIHelper.GetString(txtOrganismoDetalle);
			Entity.Dictamen.Denominacion =UIHelper.GetString(txtDenominacion);
			Entity.Dictamen.IdGestionTipo =UIHelper.GetInt(ddlGestionTipo);
			Entity.Dictamen.IdOrganismoFinanciero =UIHelper.GetInt(ddlOrganismoFinanciero);
			Entity.Dictamen.MontoContraparteLocal=UIHelper.GetDecimalNullable(txtMontoContraparteLocal);
			Entity.Dictamen.MontoOtros=UIHelper.GetDecimalNullable(txtMontoOtros);
            Entity.Dictamen.MontoPrestamo = UIHelper.GetDecimalNullable(txtMontoPrestamo);
            
            //Entity.Dictamen.MontoTotal = UIHelper.GetDecimalNullable(txtMontoPrestamo);
			Entity.Dictamen.IdAnalista =UIHelper.GetIntNullable(ddlAnalista);
            Entity.Dictamen.Analista_ApellidoYNombre = UIHelper.GetString(ddlAnalista);
			//Entity.Dictamen.IdPrestamo =UIHelper.GetIntNullable(ddlPrestamo);
			//Entity.Dictamen.IdPrestamoDictamenRelacionado =UIHelper.GetIntNullable(ddlPrestamoDictamenRelacionado);
			Entity.Dictamen.Comentario =UIHelper.GetString(txtComentario);
			Entity.Dictamen.IDPrestamoCalificacion = UIHelper.GetIntNullable(ddlPrestamoCalificacion);
			Entity.Dictamen.CalificacionFecha = UIHelper.GetDateTimeNullable(diCalificacionFecha);
			Entity.Dictamen.CalificacionITecnico = UIHelper.GetString(txtCalificacionITecnico);
			Entity.Dictamen.CalificacionITFecha = UIHelper.GetDateTimeNullable(diCalificacionITFecha);
			Entity.Dictamen.CalificacionNotaDNIP = UIHelper.GetString(txtCalificacionNotaDNIP);
			Entity.Dictamen.CalificacionObservacion = UIHelper.GetString(txtCalificacionObservacion);
			Entity.Dictamen.CalificacionRecomendacion = UIHelper.GetString(txtCalificacionRecomendacion);
            Entity.Dictamen.MontoTotal = UIHelper.GetDecimal(txtMontoContraparteLocal) +
                UIHelper.GetDecimal(txtMontoOtros) + UIHelper.GetDecimal(txtMontoPrestamo);
            
        }


        private bool IsReadOnly
        {
            get
            {

                return Convert.ToBoolean(ViewState["IsReadOnly"]);
            }
            set
            {
                ViewState["IsReadOnly"] = value;
            }
        }

        #region Estados
        private PrestamoDictamenEstadoResult actualPrestamoDictamenEstado;
        protected PrestamoDictamenEstadoResult ActualPrestamoDictamenEstado
        {
            get
            {
                if (actualPrestamoDictamenEstado == null)
                    if (ViewState["actualPrestamoDictamenEstado"] != null)
                        actualPrestamoDictamenEstado = ViewState["actualPrestamoDictamenEstado"] as PrestamoDictamenEstadoResult;
                    else
                    {
                        actualPrestamoDictamenEstado = GetNewPrestamoDictamenEstado();
                        ViewState["actualPrestamoDictamenEstado"] = actualPrestamoDictamenEstado;
                    }
                return actualPrestamoDictamenEstado;
            }
            set
            {
                actualPrestamoDictamenEstado = value;
                ViewState["actualPrestamoDictamenEstado"] = value;
            }
        }
        PrestamoDictamenEstadoResult GetNewPrestamoDictamenEstado()
        {
            int id = 0;
            if (Entity.Estados.Count > 0) id = Entity.Estados.Min(o => o.IdPrestamoDictamenEstado);
            if (id > 0) id = 0;
            id--;
            PrestamoDictamenEstadoResult uopResult = new PrestamoDictamenEstadoResult();
            PrestamoDictamenEstadoService.Current.Set(PrestamoDictamenEstadoService.Current.GetNew(), uopResult);
            uopResult.IdPrestamoDictamenEstado = id;
            return uopResult;
        }
        void HidePopUpEstados()
        {
            ModalPopupExtenderPrestamoEstado.Hide();
        }
        void ShowPopUpEstados()
        {
            ModalPopupExtenderPrestamoEstado.Show();
            PrestamoDictamenEstadoClear();
            upEstadosPopUp.Update();
        }
        #region EventosGrillas

        protected void GridRoles_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;
            ActualPrestamoDictamenEstado = (from o in Entity.Estados where o.IdPrestamoDictamenEstado == id select o).FirstOrDefault();


            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandPrestamoDictamenEstadoEdit();
                    break;
                case Command.DELETE:
                    CommandPrestamoDictamenEstadoDelete();
                    break;
            }

        }
        protected virtual void Grid_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                //gridRoles.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                //gridRoles.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }

        #endregion
        #region Events
        protected void btSaveEstados_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(CommandPrestamoDictamenEstadoSave);
            HidePopUpEstados();
        }
        protected void btNewEstados_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(CommandPrestamoDictamenEstadoSave);
        }
        protected void btCancelEstados_Click(object sender, EventArgs e)
        {
            PrestamoDictamenEstadoClear();
            HidePopUpEstados();
        }
        protected void btAgregarEstado_Click(object sender, EventArgs e)
        {
            UIHelper.CallTryMethod(ShowPopUpEstados);
        }
        
        #endregion
        #region Commands
        void CommandPrestamoDictamenEstadoEdit()
        {
            PrestamoDictamenEstadoSetValue();
            UIHelper.CallTryMethod(ShowPopUpEstados);
        }
        void CommandPrestamoDictamenEstadoSave()
        {
            PrestamoDictamenEstadoGetValue();
            PrestamoDictamenEstadoResult result = (from o in Entity.Estados where o.IdPrestamoDictamenEstado == ActualPrestamoDictamenEstado.ID select o).FirstOrDefault();
            if (result != null)
            {
                result.IdEstado = ActualPrestamoDictamenEstado.IdEstado;
                result.Estado_Nombre = ActualPrestamoDictamenEstado.Estado_Nombre;
                result.Fecha = ActualPrestamoDictamenEstado.Fecha;
                result.Observacion = ActualPrestamoDictamenEstado.Observacion;
                result.IdUsuario = ActualPrestamoDictamenEstado.IdUsuario;
                result.Usuario_NombreUsuario = ActualPrestamoDictamenEstado.Usuario_NombreUsuario;
            }
            else
            {
                Entity.Estados.Add(ActualPrestamoDictamenEstado);
            }
            PrestamoDictamenEstadoClear();
            PrestamoDictamenEstadoRefresh();
        }
        void CommandPrestamoDictamenEstadoDelete()
        {
            PrestamoDictamenEstadoResult result = (from o in Entity.Estados where o.IdPrestamoDictamenEstado == ActualPrestamoDictamenEstado.ID select o).FirstOrDefault();
            Entity.Estados.Remove(result);
            PrestamoDictamenEstadoClear();
            PrestamoDictamenEstadoRefresh();
        }
        #endregion
        #region Clear SetValue GetValue Refresh
        void PrestamoDictamenEstadoClear()
        {
            UIHelper.Clear(ddlEstadoPopUpEstado);
            UIHelper.Clear(ddlUsuarioPopUpEstado);
            UIHelper.Clear(diFechaPopUpEstado);
            UIHelper.Clear(txtComentarioPopUpEstado);
            UIHelper.SetValue(diFechaPopUpEstado, DateTime.Now);
            //UIHelper.SetValue(ddlAnalista, UIContext.Current.ContextUser.User.IdUsuario);
            //UIHelper.SetValue(ddlUsuarioPopUpEstado, UIContext.Current.ContextUser.User.IdUsuario);
            ActualPrestamoDictamenEstado = GetNewPrestamoDictamenEstado();
        }
        void PrestamoDictamenEstadoSetValue()
        {
            UIHelper.SetValue<Estado, int>(ddlEstadoPopUpEstado, ActualPrestamoDictamenEstado.IdEstado, EstadoService.Current.GetById);
            //UIHelper.SetValue<Usuario, int>(ddlUsuarioPopUpEstado, ActualPrestamoDictamenEstado.IdUsuario, UsuarioService.Current.GetById);
            UIHelper.SetValue(ddlUsuarioPopUpEstado, ActualPrestamoDictamenEstado.IdUsuario);
            UIHelper.SetValue(diFechaPopUpEstado, ActualPrestamoDictamenEstado.Fecha);
            UIHelper.SetValue(txtComentarioPopUpEstado, ActualPrestamoDictamenEstado.Observacion);
        }
        void PrestamoDictamenEstadoGetValue()
        {
            ActualPrestamoDictamenEstado.IdEstado = UIHelper.GetInt(ddlEstadoPopUpEstado);
            ActualPrestamoDictamenEstado.Estado_Nombre = UIHelper.GetString(ddlEstadoPopUpEstado);
            ActualPrestamoDictamenEstado.IdUsuario = UIHelper.GetInt(ddlUsuarioPopUpEstado);
          //  ActualPrestamoDictamenEstado.Usuario_NombreUsuario = UIHelper.GetString(ddlUsuarioPopUpEstado);
            UsuarioResult usu = UsuarioService.Current.GetResult(new nc.UsuarioFilter() { IdUsuario = ActualPrestamoDictamenEstado.IdUsuario }).FirstOrDefault();
            if (usu != null)
            {
                ActualPrestamoDictamenEstado.Persona_ApellidoYNombre = usu.Persona_Apellido + " " + usu.Persona_Nombre;
            }
            ActualPrestamoDictamenEstado.Fecha = UIHelper.GetDateTime(diFechaPopUpEstado);
            ActualPrestamoDictamenEstado.Observacion = UIHelper.GetString(txtComentarioPopUpEstado);
        }
        void PrestamoDictamenEstadoRefresh()
        {

            if(Entity.Estados.Count == 0) return;
            PrestamoDictamenEstadoResult pser = Entity.Estados.Last();
            UIHelper.SetValue(lbUsuario, pser.Persona_ApellidoYNombre);
            UIHelper.SetValue(lbEstadoSituacion, pser.Estado_Nombre);
            UIHelper.SetValue(diFechaEstado, pser.Fecha);
            UIHelper.SetValue(txtObservacionEstado, pser.Observacion);

        }
        #endregion

        #endregion

        protected void txtPrestamoNumero_TextChanged(object sender, EventArgs e)
        {
            if (IsReadOnly) return;
            BuscarPerstamo(false);       
        }

        protected void txtPrestamoDictamenRelacionado_TextChanged(object sender, EventArgs e)
        {
            if (IsReadOnly) return;
            BuscarDictamenRelacionado(false);           
        }


        bool BuscarProyectoPrestamo(int num)
        {
            UIHelper.Clear(lblPrestamoDenominacion);
            PrestamoResult prestamo = PrestamoService.Current.GetResult(new nc.PrestamoFilter() { Numero = num }).FirstOrDefault();
            if (prestamo == null)
            {
                Entity.Dictamen.IdPrestamo = null;
                UIHelper.SetValue (lblPrestamoDenominacion , Translate ("No existe el código de prestamo ingresado"));
                return false;
            }
            Entity.Dictamen.IdPrestamo = prestamo.IdPrestamo;
            Entity.Dictamen.Prestamo_Denominacion = prestamo.Denominacion;
            Entity.Dictamen.Prestamo_Numero = prestamo.Numero;
            UIHelper.SetValue(lblPrestamoDenominacion, prestamo.Denominacion);
            return true;
        }

        void BuscarPerstamo(bool validate)
        {
            string codigo = UIHelper.GetString(txtPrestamoNumero);
            int numero;
            Int32.TryParse(codigo, out numero);
            BuscarProyectoPrestamo(numero);
        }

        bool BuscarDictamenRelacionado(int num)
        {

            PrestamoDictamenResult dictamen = PrestamoDictamenService.Current.GetResult(new nc.PrestamoDictamenFilter() { IdPrestamoDictamen = num }).FirstOrDefault();
            if (dictamen == null)
            {
                Entity.Dictamen.IdPrestamoDictamenRelacionado = null;
                UIHelper.Clear(lblPrestamoDictamenRelacionado);
                return false;
            }
            Entity.Dictamen.IdPrestamoDictamenRelacionado = dictamen.IdPrestamoDictamenRelacionado;
            UIHelper.SetValue(lblPrestamoDictamenRelacionado, dictamen.Denominacion);
            return true;
        }

        void BuscarDictamenRelacionado(bool validate)
        {
            string codigo = UIHelper.GetString(txtPrestamoDictamenRelacionado);
            int numero;
            Int32.TryParse(codigo, out numero);
            BuscarDictamenRelacionado(numero);
        }

        public void RegistrarScriptTotales()
        {
            string totalesScript = "function CalcularTotales()\n" +
                    "{\n" +


                        "var MontoOtros = parseFloat(IsNumeric(document.getElementById('" +
                        txtMontoOtros.ClientID + "').value.replace(',', '.')) ? document.getElementById('" +
                        txtMontoOtros.ClientID + "').value.replace(',', '.') : '0');\n" +

                        "var MontoPrestamo = parseFloat(IsNumeric(document.getElementById('" +
                        txtMontoPrestamo.ClientID + "').value.replace(',', '.')) ? document.getElementById('" +
                        txtMontoPrestamo.ClientID + "').value.replace(',', '.') : '0');\n" +

                        "var MontoContraparteLocal = parseFloat(IsNumeric(document.getElementById('" +
                        txtMontoContraparteLocal.ClientID + "').value.replace(',', '.')) ? document.getElementById('" +
                        txtMontoContraparteLocal.ClientID + "').value.replace(',', '.') : '0');\n" +

                        "var MontoTotal =  parseFloat(MontoOtros +  MontoPrestamo + MontoContraparteLocal).toFixed(2);\n" +


                        "document.getElementById('" + lblMontoTotal.ClientID + "').innerHTML =  MontoTotal.replace('.', ',');\n" +
                        
                    "}";


            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "totalesScript", totalesScript, true);

           // txtMontoOtros.Attributes["onChange"] = "CalcularTotales();";
           // txtMontoPrestamo.Attributes["onChange"] = "CalcularTotales();";
           // txtMontoContraparteLocal.Attributes["onChange"] = "CalcularTotales();";

        }

        protected void Monto_TextChanged(object sender, EventArgs e)
        {
            decimal montoContraparte = UIHelper.GetDecimal( txtMontoContraparteLocal);
            decimal montosOtros = UIHelper.GetDecimal(txtMontoOtros);
            decimal montosPrestamo = UIHelper.GetDecimal(txtMontoPrestamo);

            UIHelper.SetValue(lblMontoTotal, (montoContraparte + montosOtros + montosPrestamo).ToString ("N0"));
        }

    }
}

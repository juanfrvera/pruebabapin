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
    public partial class PrestamoConvenioEdit : WebControlEdit<nc.PrestamoConvenioCompose>
    {
        #region Override WebControlEdit

        protected override void _Initialize()
        {
            base._Initialize();

            
            revMontoPrestamo.ValidationExpression = Contract.DataHelper.GetExpRegNumber();
            revMontoTotal.ValidationExpression = Contract.DataHelper.GetExpRegNumber();
            revNumeroConvenio.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(20);
            revSigla.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(20);
            revObservacion.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(200);
            revDatosModalidadFinanciera.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(150);
            
            revNumeroConvenio.ErrorMessage = TranslateFormat("InvalidField", "Número de Convenio");
            rfvOrganismoFinanciero.ErrorMessage = TranslateFormat("FieldIsNull", "Organismo Financiero");
            revMontoPrestamo.ErrorMessage = TranslateFormat("InvalidField", "Monto Préstamo");
            rfvMontoPrestamo.ErrorMessage = TranslateFormat("FieldIsNull", "Monto Préstamo");
            revMontoTotal.ErrorMessage = TranslateFormat("InvalidField", "Monto Total");
            rfvMontoTotal.ErrorMessage = TranslateFormat("FieldIsNull", "Monto Total");
            revSigla.ErrorMessage = TranslateFormat("InvalidField", "Sigla");
            rfvMoneda.ErrorMessage = TranslateFormat("FieldIsNull", "Moneda");
            revObservacion.ErrorMessage = TranslateFormat("InvalidField", "Observación");
            revDatosModalidadFinanciera.ErrorMessage = TranslateFormat("FieldIsNull", "Datos Modalidad Financiera");

            UIHelper.Load<nc.OrganismoFinanciero>(ddlOrganismoFinanciero, OrganismoFinancieroService.Current.GetList(new nc.OrganismoFinancieroFilter() { Activo = true }), "Nombre", "IdOrganismoFinanciero", new OrganismoFinanciero() { IdOrganismoFinanciero = 0, Nombre = "Seleccione Organismo Financiero" });
            UIHelper.Load<nc.Moneda>(ddlMoneda, MonedaService.Current.GetList(new nc.MonedaFilter() { Activo = true }), "Nombre", "IdMoneda", new nc.Moneda() { IdMoneda = 0, Nombre = "Seleccione Moneda" });
      
            // SubConvenios
            PopUpSubConvenios.Attributes.CssStyle.Add("display", "none");

            UIHelper.Load<nc.SubConvenioTipo>(ddlTipo, SubConvenioTipoService.Current.GetList(new nc.SubConvenioTipoFilter() { Activo = true }), "Nombre", "IdSubconvenioTipo", new nc.SubConvenioTipo() { IdSubconvenioTipo = 0, Nombre = "Seleccione Tipo" });
      
            revCodigo.ValidationExpression = Contract.DataHelper.GetExpRegString(10);
            revDescripcion.ValidationExpression = Contract.DataHelper.GetExpRegString(500);
            revContraparte.ValidationExpression = Contract.DataHelper.GetExpRegString(500);
            revEjecutor.ValidationExpression = Contract.DataHelper.GetExpRegString(500);
            revMontoTotalSubConvenio.ValidationExpression = Contract.DataHelper.GetExpRegNumber();
            revMontoPrestamoSubConvenio.ValidationExpression = Contract.DataHelper.GetExpRegNumber();
            revObservaciones.ValidationExpression = Contract.DataHelper.GetExpRegString(500);

           // rfvModalidad.ErrorMessage = TranslateFormat("FieldIsNull", "Modalidad"); //Matias 20150129 - Tarea relacionada al tag "Matias 20140425 - Tarea 139" en PrestamoConvenioEdit.ascx - Descomente la tarea porque sino erraba al levantar el Popup SubConvenio.
            revCodigo.ErrorMessage = TranslateFormat("InvalidField", "Código");
            rfvCodigo.ErrorMessage = TranslateFormat("FieldIsNull", "Código");
            revDescripcion.ErrorMessage = TranslateFormat("InvalidField", "Descripción");
            rfvDescripcion.ErrorMessage = TranslateFormat("FieldIsNull", "Descripción");
            rfvTipo.ErrorMessage = TranslateFormat("FieldIsNull", "Tipo");
            rfvTipo1.ErrorMessage = TranslateFormat("FieldIsNull", "Tipo");
            diFechaSubConvenio.RequiredErrorMessage = TranslateFormat("FieldIsNull", "Fecha");
            revEjecutor.ErrorMessage = TranslateFormat("InvalidField", "Ejecutor");
            rfvEjecutor.ErrorMessage = TranslateFormat("FieldIsNull", "Ejecutor");
            revContraparte.ErrorMessage = TranslateFormat("InvalidField", "Contraparte");
            rfvContraparte.ErrorMessage = TranslateFormat("FieldIsNull", "Contraparte");
            revMontoTotalSubConvenio.ErrorMessage = TranslateFormat("InvalidField", "Monto Total");
            rfvMontoTotalSubConvenio.ErrorMessage = TranslateFormat("FieldIsNull", "Monto Total");
            revMontoPrestamoSubConvenio.ErrorMessage = TranslateFormat("InvalidField", "Monto Préstamo");
            rfvMontoPrestamoSubConvenio.ErrorMessage = TranslateFormat("FieldIsNull", "Monto Préstamo");
            revObservaciones.ErrorMessage = TranslateFormat("InvalidField", "Observaciones");

            PopUpSubConvenios.Attributes.CssStyle.Add("display", "none");
         }
		public override void Clear()
        {
            ddlOrganismoFinanciero.Focus();
            UIHelper.Clear(ddlOrganismoFinanciero);
            UIHelper.Clear(txtNumeroConvenio);
            UIHelper.Clear(txtMontoPrestamo);
            UIHelper.Clear(ddlModalidad);
            UIHelper.Clear(txtSigla);
            UIHelper.Clear(txtMontoTotal);
            UIHelper.Clear(ddlMoneda);
            UIHelper.Clear(ddlModalidad);
            UIHelper.Clear(txtDatosModalidad);
            UIHelper.Clear(txtObservacion);
        }
        public override void SetValue()
        {
            UIHelper.SetValue<OrganismoFinanciero,int>(ddlOrganismoFinanciero, Entity.Convenio.IdOrganismoFinanciero, OrganismoFinancieroService.Current.GetById);
            UIHelper.SetValue(txtNumeroConvenio, Entity.Convenio.Numero);
            UIHelper.SetValue(txtMontoPrestamo, Entity.Convenio.MontoPrestamo);
            ChangeOrganismoFinanciero();
            if(Entity.Convenio.IdModalidadFinanciera.HasValue)
                UIHelper.SetValue<ModalidadFinanciera,int>(ddlModalidad, Entity.Convenio.IdModalidadFinanciera.Value, ModalidadFinancieraService.Current.GetById);
            UIHelper.SetValue(txtSigla, Entity.Convenio.Sigla);
            UIHelper.SetValue(txtObservacion, Entity.Convenio.Observacion);
            UIHelper.SetValue(txtMontoTotal, Entity.Convenio.MontoTotal);
            UIHelper.SetValue<Moneda,int>(ddlMoneda, Entity.Convenio.IdMoneda,MonedaService.Current.GetById);
            UIHelper.SetValue(txtDatosModalidad, Entity.Convenio.DatosModalidadFinanciera);
            upDatosGenerales.Update();
            PrestamoSubConvenioRefresh();
        }
        public override void GetValue()
        {
            Entity.Convenio.IdOrganismoFinanciero = UIHelper.GetInt(ddlOrganismoFinanciero);
            Entity.Convenio.Numero = UIHelper.GetStringNullable(txtNumeroConvenio);
            Entity.Convenio.MontoPrestamo = UIHelper.GetDecimal(txtMontoPrestamo);
            Entity.Convenio.IdModalidadFinanciera = UIHelper.GetIntNullable(ddlModalidad);
            Entity.Convenio.Sigla = UIHelper.GetStringNullable(txtSigla);
            Entity.Convenio.MontoTotal = UIHelper.GetDecimal(txtMontoTotal);
            Entity.Convenio.IdMoneda = UIHelper.GetInt(ddlMoneda);
            Entity.Convenio.DatosModalidadFinanciera = UIHelper.GetStringNullable(txtDatosModalidad);
            Entity.Convenio.Observacion = UIHelper.GetStringNullable(txtObservacion);          
        }
        
        #endregion Override
        #region Events
        protected void ddlOrganismoFinanciero_SelectedIndexChanged(object sender, EventArgs e)
        {
            CallTryMethod(ChangeOrganismoFinanciero);
        }
        #endregion
        #region Private Functions
        private void ChangeOrganismoFinanciero()
        {
            Int32 IdOrganismoFinanciero = UIHelper.GetInt(ddlOrganismoFinanciero);
            UIHelper.Load<nc.ModalidadFinanciera>(ddlModalidad, ModalidadFinancieraService.Current.GetList(new nc.ModalidadFinancieraFilter() { Activo = true ,IdOrganismoFinanciero = IdOrganismoFinanciero }), "Nombre", "IdModalidadFinanciera", new nc.ModalidadFinanciera() { IdModalidadFinanciera = 0, Nombre = "Seleccione Modalidad Financiera", IdOrganismoFinanciero = IdOrganismoFinanciero });
        }
        #endregion

        #region Sobre SubConvenio

        private PrestamoSubConvenioResult actualPrestamoSubConvenio;
        protected PrestamoSubConvenioResult ActualPrestamoSubConvenio
        {
            get
            {
                if (actualPrestamoSubConvenio == null)
                    if (ViewState["actualPrestamoSubConvenio"] != null)
                        actualPrestamoSubConvenio = ViewState["actualPrestamoSubConvenio"] as PrestamoSubConvenioResult;
                    else
                    {
                        actualPrestamoSubConvenio = GetNewSubConvenio();
                        ViewState["actualPrestamoSubConvenio"] = actualPrestamoSubConvenio;
                    }
                return actualPrestamoSubConvenio;
            }
            set
            {
                actualPrestamoSubConvenio = value;
                ViewState["actualPrestamoSubConvenio"] = value;
            }
        }
        PrestamoSubConvenioResult GetNewSubConvenio()
        {
            int id = 0;
            if (Entity.SubConvenios.Count > 0) id = Entity.SubConvenios.Min(l => l.IdPrestamoSubConvenio);
            if (id > 0) id = 0;
            id--;
            PrestamoSubConvenioResult plResult = new PrestamoSubConvenioResult();
            plResult.IdPrestamoSubConvenio = id;
            plResult.IdPrestamoConvenio = Entity.Convenio.IdPrestamoConvenio;
            return plResult;
        }

        #region Methods
        void HidePopUpSubConvenios()
        {
            ModalPopupExtenderSubConvenios.Hide();
        }
        void PrestamoSubConvenioClear()
        {
            UIHelper.Clear(txtCodigo);
            UIHelper.Clear(txtDescripcion);
            UIHelper.Clear(ddlTipo);
            UIHelper.Clear(diFechaSubConvenio);
            UIHelper.Clear(txtEjecutor);
            UIHelper.Clear(txtContraparte);
            UIHelper.Clear(txtMontoTotalSubConvenio);
            UIHelper.Clear(txtMontoPrestamoSubConvenio);
            UIHelper.Clear(txtObservaciones);
            ActualPrestamoSubConvenio = GetNewSubConvenio();
        }
        void PrestamoSubConvenioSetValue()
        {
            UIHelper.SetValue(txtCodigo, ActualPrestamoSubConvenio.Codigo);
            UIHelper.SetValue(txtDescripcion, ActualPrestamoSubConvenio.Descripcion);
            UIHelper.SetValue<SubConvenioTipo,int>(ddlTipo, ActualPrestamoSubConvenio.IdTipoSubConvenio,SubConvenioTipoService.Current.GetById);
            UIHelper.SetValue(diFechaSubConvenio, ActualPrestamoSubConvenio.Fecha);
            UIHelper.SetValue(txtEjecutor, ActualPrestamoSubConvenio.Ejecutor);
            UIHelper.SetValue(txtContraparte, ActualPrestamoSubConvenio.Contraparte);
            UIHelper.SetValue(txtMontoTotalSubConvenio, ActualPrestamoSubConvenio.MontoTotal);
            UIHelper.SetValue(txtMontoPrestamoSubConvenio, ActualPrestamoSubConvenio.MontoPrestamo);
            UIHelper.SetValue(txtObservaciones, ActualPrestamoSubConvenio.Observaciones);
            upSubConveniosPopUp.Update();
        }
        void PrestamoSubConvenioGetValue()
        {
            ActualPrestamoSubConvenio.Codigo = UIHelper.GetString(txtCodigo);
            ActualPrestamoSubConvenio.Descripcion = UIHelper.GetString(txtDescripcion);
            ActualPrestamoSubConvenio.IdTipoSubConvenio = UIHelper.GetInt(ddlTipo);
            ActualPrestamoSubConvenio.TipoSubConvenio_Nombre = UIHelper.GetString(ddlTipo);
            ActualPrestamoSubConvenio.Fecha = UIHelper.GetDateTime(diFechaSubConvenio);
            ActualPrestamoSubConvenio.Ejecutor = UIHelper.GetString(txtEjecutor);
            ActualPrestamoSubConvenio.Contraparte = UIHelper.GetString(txtContraparte);
            ActualPrestamoSubConvenio.MontoTotal = UIHelper.GetDecimal(txtMontoTotalSubConvenio);
            ActualPrestamoSubConvenio.MontoPrestamo = UIHelper.GetDecimal(txtMontoPrestamoSubConvenio);
            ActualPrestamoSubConvenio.Observaciones = UIHelper.GetString(txtObservaciones);
        }
        void PrestamoSubConvenioRefresh()
        {
            UIHelper.Load(gridSubConvenios, Entity.SubConvenios, "Codigo");
            upGridSubConvenios.Update();
        }
        #endregion Methods

        #region Commands
        void CommandPrestamoSubConvenioEdit()
        {
            PrestamoSubConvenioSetValue();
            ModalPopupExtenderSubConvenios.Show();
            upSubConveniosPopUp.Update();
        }
        void CommandPrestamoSubConvenioSave()
        {
            PrestamoSubConvenioGetValue();

            PrestamoSubConvenioResult result = (from o in Entity.SubConvenios where o.IdPrestamoSubConvenio == ActualPrestamoSubConvenio.ID select o).FirstOrDefault();
            if (result != null)
            {
                result.Codigo = ActualPrestamoSubConvenio.Codigo;
                result.Descripcion = ActualPrestamoSubConvenio.Descripcion;
                result.IdTipoSubConvenio = ActualPrestamoSubConvenio.IdTipoSubConvenio;
                result.Fecha = ActualPrestamoSubConvenio.Fecha;
                result.Ejecutor = ActualPrestamoSubConvenio.Ejecutor;
                result.TipoSubConvenio_Nombre = ActualPrestamoSubConvenio.TipoSubConvenio_Nombre;
                result.Contraparte = ActualPrestamoSubConvenio.Contraparte;
                result.MontoTotal = ActualPrestamoSubConvenio.MontoTotal;
                result.MontoPrestamo = ActualPrestamoSubConvenio.MontoPrestamo;
                result.Observaciones = ActualPrestamoSubConvenio.Observaciones;
                
            }
            else
            {
                Entity.SubConvenios.Add(ActualPrestamoSubConvenio);
            }
            PrestamoSubConvenioClear();
            PrestamoSubConvenioRefresh();
        }
        void CommandPrestamoSubConvenioDelete()
        {
            PrestamoSubConvenioResult result = (from l in Entity.SubConvenios where l.IdPrestamoSubConvenio == ActualPrestamoSubConvenio.ID select l).FirstOrDefault();
            Entity.SubConvenios.Remove(result);
            PrestamoSubConvenioClear();
            PrestamoSubConvenioRefresh();
        }
        #endregion

        #region Eventos
        protected void btSaveSubConvenio_Click(object sender, EventArgs e)
        {
            if (!validate())
                return;
            CallTryMethod(CommandPrestamoSubConvenioSave);
            HidePopUpSubConvenios();
        }
        private bool validate()
        {
            if (UIHelper.GetDecimal(txtMontoTotalSubConvenio) < UIHelper.GetDecimal(txtMontoPrestamoSubConvenio))
            {
                UIHelper.ShowAlert(Translate("- El Monto del Préstamo debe ser inferior al de Monto Total"), upSubConveniosPopUp);
                return false;
            }
            if (UIHelper.GetDecimal(txtMontoTotalSubConvenio) <= 0 || UIHelper.GetDecimal(txtMontoPrestamoSubConvenio) <= 0)
            {
                UIHelper.ShowAlert(Translate("- Los montos deben ser mayores a cero"), upSubConveniosPopUp);
                return false;
            }
            return true;
        }
        protected void btNewSubConvenio_Click(object sender, EventArgs e)
        {
            if (!validate())
                return;
            CallTryMethod(CommandPrestamoSubConvenioSave);
        }
        protected void btCancelSubConvenio_Click(object sender, EventArgs e)
        {
            PrestamoSubConvenioClear();
            HidePopUpSubConvenios();
        }
        protected void btAgregarSubConvenio_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderSubConvenios.Show();
            txtCodigo.Focus();
        }
        #endregion

        #region EventosGrillas
        protected void GridSubConvenios_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
                return;

            ActualPrestamoSubConvenio = (from l in Entity.SubConvenios where l.IdPrestamoSubConvenio == id select l).FirstOrDefault();

            switch (e.CommandName)
            {
                case Command.EDIT:
                    CommandPrestamoSubConvenioEdit();
                    break;
                case Command.DELETE:
                    CommandPrestamoSubConvenioDelete();
                    break;
            }
        }
        protected virtual void GridSubConvenios_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                gridSubConvenios.PageIndex = 0;
                RaiseControlCommand(Command.SORT, e);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        protected virtual void GridSubConvenios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridSubConvenios.PageIndex = e.NewPageIndex;
                base.RaiseControlCommand(Command.REFRESH);
            }
            catch (Exception exception)
            {
                AddException(exception);
            }
        }
        #endregion

      

        #endregion Sobre SubConvenio

    }
}

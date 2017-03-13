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
    public partial class PrestamoDictamenFilter : WebControlFilter<nc.PrestamoDictamenFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
            revDenominacion.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(500);
			revExpediente.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
            revNumeroPrestamo.ValidationExpression = Contract.DataHelper.GetExpRegStringNullable(10);

			UIHelper.Load<nc.Organismo>(ddlOrganismo, OrganismoService.Current.GetList(),"Nombre","IdOrganismo",new nc.Organismo(){IdOrganismo=0, Nombre= "Seleccione Organismo"});
			UIHelper.Load<nc.GestionTipo>(ddlGestionTipo, GestionTipoService.Current.GetList(),"Nombre","IdGestionTipo",new nc.GestionTipo(){IdGestionTipo=0, Nombre= "Seleccione GestionTipo"});
			UIHelper.Load<nc.OrganismoFinanciero>(ddlOrganismoFinanciero, OrganismoFinancieroService.Current.GetList(),"Nombre","IdOrganismoFinanciero",new nc.OrganismoFinanciero(){IdOrganismoFinanciero=0, Nombre= "Seleccione OrganismoFinanciero"});
            UIHelper.Load<UsuarioResult>(ddlAnalista, UsuarioService.Current.GetResult(new nc.UsuarioFilter() { Activo = true, EsSectioralista = true }), "ApellidoYNombre", "IdUsuario", new UsuarioResult() { Persona_Nombre = "Seleccione Analista", Persona_Apellido = String.Empty, IdUsuario = 0 });
            UIHelper.Load<nc.Estado>(lbxEstado, EstadoService.Current.GetList(new nc.EstadoFilter() { EntidadTipo = SistemaEntidadConfig.PRESTAMO_DICTAMEN }), "Nombre", "IdEstado");			
            revCalificacionITecnico.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
			revCalificacionNotaDNIP.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);		

		}
		protected override void Clear()
        {
            UIHelper.Clear(ddlOrganismo);
            UIHelper.Clear(ddlOrganismoFinanciero);
            UIHelper.Clear(ddlGestionTipo);
            UIHelper.Clear(txtExpediente);
            UIHelper.Clear(ddlAnalista);
            lbxEstado.ClearSelection();
			UIHelper.Clear(txtDenominacion);
            UIHelper.Clear(txtCalificacionNotaDNIP);					
			UIHelper.Clear(txtNumeroPrestamo);
			UIHelper.Clear(txtCalificacionITecnico);
            //UIHelper.Clear(diFechaAltaDesde);
            //UIHelper.Clear(diFechaAltaHasta);
            UIHelper.Clear(rdFechaAlta);
            UIHelper.Clear(txtNumeroSecuencialDesde);
            UIHelper.Clear(txtNumeroSecuencialHasta);
            txtExpediente.Focus();	
        }		
		protected override void SetValue()
        {
            UIHelper.SetValue(ddlOrganismo, Filter.IDOrganismo);
            UIHelper.SetValue(ddlOrganismoFinanciero, Filter.IdOrganismoFinanciero);
            UIHelper.SetValue(ddlGestionTipo, Filter.IdGestionTipo);
            UIHelper.SetValueFilter(txtExpediente, Filter.Expediente);
            UIHelper.SetValue(ddlAnalista, Filter.IdAnalista);
            UIHelper.SetValueFilter(txtDenominacion, Filter.Denominacion);
            UIHelper.SetValueFilter(txtCalificacionNotaDNIP, Filter.CalificacionNotaDNIP);
            UIHelper.SetValue(txtNumeroPrestamo, Filter.Prestamo_Numero);
            UIHelper.SetValueFilter(txtCalificacionITecnico, Filter.CalificacionITecnico);
            //UIHelper.SetValue(diFechaAltaDesde, Filter.FechaAlta);
            //UIHelper.SetValue(diFechaAltaHasta, Filter.FechaAlta_To);
            UIHelper.SetValue(rdFechaAlta, filter.FechaAlta, filter.FechaAlta_To);
            UIHelper.SetValue(lbxEstado, Filter.IdsEstado);
            UIHelper.SetValue(txtNumeroSecuencialDesde, Filter.IdPrestamoDictamen_From);
            UIHelper.SetValue(txtNumeroSecuencialHasta, Filter.IdPrestamoDictamen_To);
            txtExpediente.Focus();                                               			        							
        }	




        protected override void GetValue()
        {
            Filter.Expediente = UIHelper.GetStringBetweenFilter(txtExpediente);
			Filter.IDOrganismo =UIHelper.GetIntNullable(ddlOrganismo);            
            Filter.Denominacion = UIHelper.GetStringBetweenFilter(txtDenominacion);
			Filter.IdGestionTipo =UIHelper.GetIntNullable(ddlGestionTipo);
			Filter.IdOrganismoFinanciero =UIHelper.GetIntNullable(ddlOrganismoFinanciero);
			Filter.IdAnalista =UIHelper.GetIntNullable(ddlAnalista);
            //Filter.FechaAlta = UIHelper.GetFromDateTimeNullable(diFechaAltaDesde);
            //Filter.FechaAlta_To = UIHelper.GetToDateTimeNullable(diFechaAltaHasta);
            filter.FechaAlta = UIHelper.GetValueFrom(rdFechaAlta );
            Filter.FechaAlta_To = UIHelper.GetValueTo(rdFechaAlta);
            Filter.CalificacionITecnico = UIHelper.GetStringBetweenFilter(txtCalificacionITecnico);
            Filter.CalificacionNotaDNIP = UIHelper.GetStringBetweenFilter(txtCalificacionNotaDNIP);
            Filter.IdsEstado = UIHelper.GetSelectedIntValues(lbxEstado);
            Filter.IdPrestamoDictamen_From = UIHelper.GetIntNullable(txtNumeroSecuencialDesde);
            Filter.IdPrestamoDictamen_To = UIHelper.GetIntNullable(txtNumeroSecuencialHasta);
            Filter.Prestamo_Numero = UIHelper.GetIntNullable(txtNumeroPrestamo);
        }
		protected void btClear_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.CLEAR_SEARCH);
        }
		protected void btSearch_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SEARCH);
        }
    }
}

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
    public partial class SafFilter : WebControlFilter<nc.SafFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revCodigo.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(5);
			revDenominacion.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(255);
            revCodigo.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revDenominacion.ErrorMessage = TranslateFormat("InvalidField", "Denominación");
			UIHelper.Load<nc.OrganismoTipo>(ddlTipoOrganismo, OrganismoTipoService.Current.GetList(),"Nombre","IdOrganismoTipo",new nc.OrganismoTipo(){IdOrganismoTipo=0, Nombre= "Seleccione OrganismoTipo"});
            UIHelper.Load<SectorResult>(ddlSector, SectorService.Current.GetResultFromList(new nc.SectorFilter()), "CodigoNombre", "IdSector", new SectorResult() { IdSector = 0, Codigo = "", Nombre = "Seleccione Sector" });
            UIHelper.Load<AdministracionTipoResult>(ddlAdministracionTipo, AdministracionTipoService.Current.GetResultFromList(new nc.AdministracionTipoFilter()), "CodigoNombre", "IdAdministracionTipo", new AdministracionTipoResult() { IdAdministracionTipo = 0, Codigo = "", Nombre = "Seleccione AdministracionTipo" });
            UIHelper.Load<EntidadTipoResult>(ddlEntidadTipo, EntidadTipoService.Current.GetResultFromList(new nc.EntidadTipoFilter()), "CodigoNombre", "IdEntidadTipo", new EntidadTipoResult() { IdEntidadTipo = 0, Codigo = "", Nombre = "Seleccione EntidadTipo" });
            UIHelper.Load<JurisdiccionResult>(ddlJurisdiccion, JurisdiccionService.Current.GetResultFromList(new nc.JurisdiccionFilter()), "CodigoNombre", "IdJurisdiccion", new JurisdiccionResult() { IdJurisdiccion = 0, Codigo = "", Nombre = "Seleccione Jurisdiccion" });
            UIHelper.Load<SubJurisdiccionResult>(ddlSubJurisdiccion, SubJurisdiccionService.Current.GetResultFromList(new nc.SubJurisdiccionFilter()), "CodigoNombre", "IdSubJuridiccion", new SubJurisdiccionResult() { IdSubJuridiccion = 0, Codigo = "", Nombre = "Seleccione SubJurisdiccion" });
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtCodigo);
			txtCodigo.Focus();
				UIHelper.Clear(txtDenominacion);
			UIHelper.Clear(ddlTipoOrganismo);
			UIHelper.Clear(ddlSector);
			UIHelper.Clear(ddlAdministracionTipo);
			UIHelper.Clear(ddlEntidadTipo);
			UIHelper.Clear(ddlJurisdiccion);
			UIHelper.Clear(ddlSubJurisdiccion);
			UIHelper.Clear(rdFechaAlta);
			UIHelper.Clear(rdFechaBaja);
			chkActivo.CheckedValue = true;

            chkActivo.CheckedValue = true;
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtCodigo, Filter.Codigo);
						txtCodigo.Focus();
                UIHelper.SetValue(ddlTipoOrganismo, Filter.IdTipoOrganismo);
                UIHelper.SetValue(ddlSector, Filter.IdSector);
                UIHelper.SetValue(ddlAdministracionTipo, Filter.IdAdministracionTipo);
                UIHelper.SetValue(ddlEntidadTipo, Filter.IdEntidadTipo);
                UIHelper.SetValue(ddlJurisdiccion, Filter.IdJurisdiccion);
                UIHelper.SetValue(ddlSubJurisdiccion, Filter.IdSubJurisdiccion);
                UIHelper.SetValueFilter(txtDenominacion, Filter.Denominacion);
						UIHelper.SetValue<DateTime?>(rdFechaAlta, Filter.FechaAlta, Filter.FechaAlta_To);
						UIHelper.SetValue<DateTime?>(rdFechaBaja, Filter.FechaBaja, Filter.FechaBaja_To);
						UIHelper.SetValue(chkActivo, Filter.Activo);
							
        }	
        protected override void GetValue()
        {
            Filter.Codigo = UIHelper.GetStringBetweenFilter(txtCodigo);
            Filter.Denominacion = UIHelper.GetStringBetweenFilter(txtDenominacion);
			Filter.IdTipoOrganismo =UIHelper.GetIntNullable(ddlTipoOrganismo);
			Filter.IdSector =UIHelper.GetIntNullable(ddlSector);
			Filter.IdAdministracionTipo =UIHelper.GetIntNullable(ddlAdministracionTipo);
			Filter.IdEntidadTipo =UIHelper.GetIntNullable(ddlEntidadTipo);
			Filter.IdJurisdiccion =UIHelper.GetIntNullable(ddlJurisdiccion);
			Filter.IdSubJurisdiccion =UIHelper.GetIntNullable(ddlSubJurisdiccion);
			Filter.FechaAlta =UIHelper.GetValueFromDate(rdFechaAlta);
            Filter.FechaAlta_To = UIHelper.GetValueToDate(rdFechaAlta);
			Filter.FechaBaja =UIHelper.GetValueFromDate(rdFechaBaja);
            Filter.FechaBaja_To = UIHelper.GetValueToDate(rdFechaBaja);
			Filter.Activo=UIHelper.GetBooleanNullable(chkActivo);

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

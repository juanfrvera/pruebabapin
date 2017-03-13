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
    public partial class SafEdit : WebControlEdit<nc.Saf>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revCodigo.ValidationExpression=Contract.DataHelper.GetExpRegString(5);
			revDenominacion.ValidationExpression=Contract.DataHelper.GetExpRegString(255);
            revCodigo.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revDenominacion.ErrorMessage = TranslateFormat("InvalidField", "Denominación");
            rfvCodigo.ErrorMessage = TranslateFormat("FieldIsNull", "Código");
            rfvJurisdiccion.ErrorMessage = TranslateFormat("FieldIsNull", "Jurisdicción");
            rfvSector.ErrorMessage = TranslateFormat("FieldIsNull", "Sector");
            rfvDenominacion.ErrorMessage = TranslateFormat("FieldIsNull", "Denominación");
            rfvTipoOrganismo.ErrorMessage = TranslateFormat("FieldIsNull", "Tipo de Organismo");
            diFechaAlta.RequiredErrorMessage = TranslateFormat("FieldIsNull", "Fecha de Alta");
            UIHelper.Load<nc.OrganismoTipo>(ddlTipoOrganismo, OrganismoTipoService.Current.GetList(new nc.OrganismoTipoFilter() { Activo = true }), "Nombre", "IdOrganismoTipo", new nc.OrganismoTipo() { IdOrganismoTipo = 0, Nombre = "Seleccione OrganismoTipo" });
			UIHelper.Load<SectorResult>(ddlSector, SectorService.Current.GetResultFromList(new nc.SectorFilter() { Activo=true }),"CodigoNombre","IdSector",new SectorResult(){IdSector=0,Codigo="", Nombre= "Seleccione Sector"});
            UIHelper.Load<AdministracionTipoResult>(ddlAdministracionTipo, AdministracionTipoService.Current.GetResultFromList(new nc.AdministracionTipoFilter() { Activo = true }), "CodigoNombre", "IdAdministracionTipo", new AdministracionTipoResult() { IdAdministracionTipo = 0, Codigo = "", Nombre = "Seleccione AdministracionTipo" });
            UIHelper.Load<EntidadTipoResult>(ddlEntidadTipo, EntidadTipoService.Current.GetResultFromList(new nc.EntidadTipoFilter() { Activo = true }), "CodigoNombre", "IdEntidadTipo", new EntidadTipoResult() { IdEntidadTipo = 0, Codigo = "", Nombre = "Seleccione EntidadTipo" });
            UIHelper.Load<JurisdiccionResult>(ddlJurisdiccion, JurisdiccionService.Current.GetResultFromList(new nc.JurisdiccionFilter() { Activo = true }), "CodigoNombre", "IdJurisdiccion", new JurisdiccionResult() { IdJurisdiccion = 0, Codigo = "", Nombre = "Seleccione Jurisdiccion" });
            UIHelper.Load<SubJurisdiccionResult>(ddlSubJurisdiccion, SubJurisdiccionService.Current.GetResultFromList(new nc.SubJurisdiccionFilter() { Activo = true }), "CodigoNombre", "IdSubJuridiccion", new SubJurisdiccionResult() { IdSubJuridiccion = 0, Codigo = "", Nombre = "Seleccione SubJurisdiccion" });
			
		}
		public override void Clear()
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
			UIHelper.Clear(diFechaAlta);
			UIHelper.Clear(diFechaBaja);
			UIHelper.Clear(chkActivo);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtCodigo, Entity.Codigo);
			txtCodigo.Focus();
				UIHelper.SetValue(txtDenominacion, Entity.Denominacion);
			UIHelper.SetValue<OrganismoTipo, int>(ddlTipoOrganismo, Entity.IdTipoOrganismo,OrganismoTipoService.Current.GetById);
            if(Entity.IdSector.HasValue)
    			UIHelper.SetValue<Sector,int>(ddlSector, Entity.IdSector.Value, SectorService.Current.GetById);
            if (Entity.IdAdministracionTipo.HasValue) 
                UIHelper.SetValue<AdministracionTipo, int>(ddlAdministracionTipo, Entity.IdAdministracionTipo.Value, AdministracionTipoService.Current.GetById);
            if (Entity.IdEntidadTipo.HasValue) 
                UIHelper.SetValue<EntidadTipo, int>(ddlEntidadTipo, Entity.IdEntidadTipo.Value, EntidadTipoService.Current.GetById);
            if (Entity.IdJurisdiccion.HasValue) 
                UIHelper.SetValue<Jurisdiccion, int>(ddlJurisdiccion, Entity.IdJurisdiccion.Value, JurisdiccionService.Current.GetById);
            if (Entity.IdSubJurisdiccion.HasValue) 
                UIHelper.SetValue<SubJurisdiccion, int>(ddlSubJurisdiccion, Entity.IdSubJurisdiccion.Value, SubJurisdiccionService.Current.GetById);
			UIHelper.SetValue(diFechaAlta, Entity.FechaAlta);
			UIHelper.SetValue(diFechaBaja, Entity.FechaBaja);
			UIHelper.SetValue(chkActivo, Entity.Activo);
				
        }	
        public override void GetValue()
        {
			Entity.Codigo =UIHelper.GetString(txtCodigo);
			Entity.Denominacion =UIHelper.GetString(txtDenominacion);
			Entity.IdTipoOrganismo =UIHelper.GetInt(ddlTipoOrganismo);
			Entity.IdSector =UIHelper.GetIntNullable(ddlSector);
			Entity.IdAdministracionTipo =UIHelper.GetIntNullable(ddlAdministracionTipo);
			Entity.IdEntidadTipo =UIHelper.GetIntNullable(ddlEntidadTipo);
			Entity.IdJurisdiccion =UIHelper.GetIntNullable(ddlJurisdiccion);
			Entity.IdSubJurisdiccion =UIHelper.GetIntNullable(ddlSubJurisdiccion);
			Entity.FechaAlta =UIHelper.GetDateTime(diFechaAlta);
			Entity.FechaBaja =UIHelper.GetDateTimeNullable(diFechaBaja);
			Entity.Activo=UIHelper.GetBoolean(chkActivo);
				
        }
    }
}

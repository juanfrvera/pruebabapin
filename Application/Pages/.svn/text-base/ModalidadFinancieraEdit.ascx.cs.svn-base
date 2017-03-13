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
    public partial class ModalidadFinancieraEdit : WebControlEdit<nc.ModalidadFinanciera>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			rfvOrganismoFinanciero.ErrorMessage = TranslateFormat("FieldIsNull", "Organismo Financiero");
            UIHelper.Load<nc.OrganismoFinanciero>(ddlOrganismoFinanciero, OrganismoFinancieroService.Current.GetList(new nc.OrganismoFinancieroFilter() { Activo = true }), "Nombre", "IdOrganismoFinanciero", new nc.OrganismoFinanciero() { IdOrganismoFinanciero = 0, Nombre = "Seleccione Organismo Financiero" });
            revSigla.ValidationExpression=Contract.DataHelper.GetExpRegString(8);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(50);
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            rfvNombre.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
            revSigla.ErrorMessage = TranslateFormat("InvalidField", "Sigla");
            rfvSigla.ErrorMessage = TranslateFormat("FieldIsNull", "Sigla");
			
		}
		public override void Clear()
        {			
			ddlOrganismoFinanciero.Focus();
			UIHelper.Clear(ddlOrganismoFinanciero);
			UIHelper.Clear(txtSigla);
			UIHelper.Clear(txtNombre);
			UIHelper.Clear(chkActivo);
				
        }		
		public override void SetValue()
        {			
			ddlOrganismoFinanciero.Focus();
			UIHelper.SetValue<OrganismoFinanciero,int>(ddlOrganismoFinanciero, Entity.IdOrganismoFinanciero, OrganismoFinancieroService.Current.GetById);
			UIHelper.SetValue(txtSigla, Entity.Sigla);
			UIHelper.SetValue(txtNombre, Entity.Nombre);
			UIHelper.SetValue(chkActivo, Entity.Activo);
				
        }	
        public override void GetValue()
        {
			Entity.IdOrganismoFinanciero =UIHelper.GetInt(ddlOrganismoFinanciero);
			Entity.Sigla =UIHelper.GetString(txtSigla);
			Entity.Nombre =UIHelper.GetString(txtNombre);
			Entity.Activo=UIHelper.GetBoolean(chkActivo);
				
        }
    }
}

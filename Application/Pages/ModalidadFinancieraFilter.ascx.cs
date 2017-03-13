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
    public partial class ModalidadFinancieraFilter : WebControlFilter<nc.ModalidadFinancieraFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
            UIHelper.Load<nc.OrganismoFinanciero>(ddlOrganismoFinanciero, OrganismoFinancieroService.Current.GetList(), "Nombre", "IdOrganismoFinanciero", new nc.OrganismoFinanciero() { IdOrganismoFinanciero = 0, Nombre = "Seleccione Organismo Financiero" });
			revSigla.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(8);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
            revSigla.ErrorMessage = TranslateFormat("InvalidField", "Sigla");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");

            chkActivo.CheckedValue = true;
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(ddlOrganismoFinanciero);
			ddlOrganismoFinanciero.Focus();
				UIHelper.Clear(txtSigla);
			UIHelper.Clear(txtNombre);
			chkActivo.CheckedValue = true;
				
        }		
		protected override void SetValue()
        {ddlOrganismoFinanciero.Focus();
				UIHelper.SetValueFilter(txtSigla, Filter.Sigla);
                UIHelper.SetValue(ddlOrganismoFinanciero, Filter.IdOrganismoFinanciero);
						UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
						UIHelper.SetValue(chkActivo, Filter.Activo);
							
        }	
        protected override void GetValue()
        {
			Filter.IdOrganismoFinanciero =UIHelper.GetIntNullable(ddlOrganismoFinanciero);
            Filter.Sigla = UIHelper.GetStringBetweenFilter(txtSigla);
            Filter.Nombre = UIHelper.GetStringBetweenFilter(txtNombre);
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

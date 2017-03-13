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
    public partial class CaracterEconomicoFilter : WebControlFilter<nc.CaracterEconomicoFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revCodigo.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(3);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
			UIHelper.Load<nc.CaracterEconomicoTipo>(ddlCaracterEconomicoTipo, CaracterEconomicoTipoService.Current.GetList(),"Nombre","IdCaracterEconomicoTipo",new nc.CaracterEconomicoTipo(){IdCaracterEconomicoTipo=0, Nombre= "Seleccione CaracterEconomicoTipo"});
			UIHelper.Load<nc.CaracterEconomico>(ddlCaracterEconomicoPadre, CaracterEconomicoService.Current.GetList(),"Nombre","IdCaracterEconomico",new nc.CaracterEconomico(){IdCaracterEconomico=0, Nombre= "Seleccione CaracterEconomico"});
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtCodigo);
			txtCodigo.Focus();
				UIHelper.Clear(txtNombre);
			UIHelper.Clear(ddlCaracterEconomicoTipo);
			UIHelper.Clear(chkActivo);
			UIHelper.Clear(ddlCaracterEconomicoPadre);
				
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtCodigo, Filter.Codigo);
						txtCodigo.Focus();
				UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
						UIHelper.SetValue(chkActivo, Filter.Activo);
							
        }	
        protected override void GetValue()
        {
			Filter.Codigo =UIHelper.GetStringFilter(txtCodigo);
			Filter.Nombre =UIHelper.GetStringFilter(txtNombre);
			Filter.IdCaracterEconomicoTipo =UIHelper.GetIntNullable(ddlCaracterEconomicoTipo);
			Filter.Activo=UIHelper.GetBooleanNullable(chkActivo);			  
			Filter.IdCaracterEconomicoPadre =UIHelper.GetIntNullable(ddlCaracterEconomicoPadre);
				
        }
		protected void btSearch_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SEARCH);
        }
    }
}

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
    public partial class CaracterEconomicoEdit : WebControlEdit<nc.CaracterEconomico>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revIdCaracterEconomico.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
			revCodigo.ValidationExpression=Contract.DataHelper.GetExpRegString(3);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(50);
			UIHelper.Load<nc.CaracterEconomicoTipo>(ddlCaracterEconomicoTipo, CaracterEconomicoTipoService.Current.GetList(),"Nombre","IdCaracterEconomicoTipo",new nc.CaracterEconomicoTipo(){IdCaracterEconomicoTipo=0, Nombre= "Seleccione CaracterEconomicoTipo"});
			UIHelper.Load<nc.CaracterEconomico>(ddlCaracterEconomicoPadre, CaracterEconomicoService.Current.GetList(),"Nombre","IdCaracterEconomico",new nc.CaracterEconomico(){IdCaracterEconomico=0, Nombre= "Seleccione CaracterEconomico"});
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtIdCaracterEconomico);
			txtIdCaracterEconomico.Focus();
				UIHelper.Clear(txtCodigo);
			UIHelper.Clear(txtNombre);
			UIHelper.Clear(ddlCaracterEconomicoTipo);
			UIHelper.Clear(chkActivo);
			UIHelper.Clear(ddlCaracterEconomicoPadre);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtIdCaracterEconomico, Entity.IdCaracterEconomico);
			txtIdCaracterEconomico.Focus();
				UIHelper.SetValue(txtCodigo, Entity.Codigo);
			UIHelper.SetValue(txtNombre, Entity.Nombre);
			UIHelper.SetValue(ddlCaracterEconomicoTipo, Entity.IdCaracterEconomicoTipo);
			UIHelper.SetValue(chkActivo, Entity.Activo);
			UIHelper.SetValue(ddlCaracterEconomicoPadre, Entity.IdCaracterEconomicoPadre);
				
        }	
        public override void GetValue()
        {
			Entity.IdCaracterEconomico=UIHelper.GetInt(txtIdCaracterEconomico);
			Entity.Codigo =UIHelper.GetString(txtCodigo);
			Entity.Nombre =UIHelper.GetString(txtNombre);
			Entity.IdCaracterEconomicoTipo =UIHelper.GetInt(ddlCaracterEconomicoTipo);
			Entity.Activo=UIHelper.GetBoolean(chkActivo);
			Entity.IdCaracterEconomicoPadre =UIHelper.GetIntNullable(ddlCaracterEconomicoPadre);
				
        }
    }
}

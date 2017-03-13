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
    public partial class ProcesoTipoEdit : WebControlEdit<nc.ProcesoTipo>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revIdProcesoTipo.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(20);
			revNivel.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtIdProcesoTipo);
			txtIdProcesoTipo.Focus();
				UIHelper.Clear(txtNombre);
			UIHelper.Clear(txtNivel);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtIdProcesoTipo, Entity.IdProcesoTipo);
			txtIdProcesoTipo.Focus();
				UIHelper.SetValue(txtNombre, Entity.Nombre);
			UIHelper.SetValue(txtNivel, Entity.Nivel);
				
        }	
        public override void GetValue()
        {
			Entity.IdProcesoTipo=UIHelper.GetInt(txtIdProcesoTipo);
			Entity.Nombre =UIHelper.GetString(txtNombre);
			Entity.Nivel=UIHelper.GetInt(txtNivel);
				
        }
    }
}

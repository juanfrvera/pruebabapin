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
    public partial class AnioEdit : WebControlEdit<nc.Anio>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			//revIdAnio.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(4);
            //revIdAnio.ErrorMessage = TranslateFormat("InvalidField", "Id Año");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            //revIdAnio.ErrorMessage = TranslateFormat("FieldIsNull", "Id Año");
            revNombre.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
		}
		public override void Clear()
        {			
            //UIHelper.Clear(txtIdAnio);
            //txtIdAnio.Focus();
				UIHelper.Clear(txtNombre);
			UIHelper.Clear(chkActivo);
				
        }		
		public override void SetValue()
        {			
            //UIHelper.SetValue(txtIdAnio, Entity.IdAnio);
            //txtIdAnio.Focus();
				UIHelper.SetValue(txtNombre, Entity.Nombre);
			UIHelper.SetValue(chkActivo, Entity.Activo);
				
        }	
        public override void GetValue()
        {
			//Entity.IdAnio=UIHelper.GetInt(txtIdAnio);
			Entity.Nombre =UIHelper.GetString(txtNombre);
			Entity.Activo=UIHelper.GetBoolean(chkActivo);
				
        }
    }
}

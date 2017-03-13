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
    public partial class PrioridadEdit : WebControlEdit<nc.Prioridad>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revSigla.ValidationExpression=Contract.DataHelper.GetExpRegString(10);
			revOrden.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
		//	revPuntaje.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegString(50);
            revSigla.ErrorMessage = TranslateFormat("InvalidField", "Sigla");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
        //    revPuntaje.ErrorMessage = TranslateFormat("InvalidField", "Puntaje");
            rfvSigla.ErrorMessage = TranslateFormat("FieldIsNull", "Sigla");
            rfvNombre.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
            rfvOrden.ErrorMessage = TranslateFormat("FieldIsNull", "Orden");
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtSigla);
			txtSigla.Focus();
				UIHelper.Clear(txtOrden);
		//	UIHelper.Clear(txtPuntaje);
			UIHelper.Clear(txtNombre);
			UIHelper.Clear(chkActivo);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtSigla, Entity.Sigla);
			txtSigla.Focus();
				UIHelper.SetValue(txtOrden, Entity.Orden);
			UIHelper.SetValue(txtNombre, Entity.Nombre);
			UIHelper.SetValue(chkActivo, Entity.Activo);
				
        }	
        public override void GetValue()
        {
			Entity.Sigla =UIHelper.GetString(txtSigla);
			Entity.Orden=UIHelper.GetInt(txtOrden);
			Entity.Nombre =UIHelper.GetString(txtNombre);
			Entity.Activo=UIHelper.GetBoolean(chkActivo);
				
        }
    }
}

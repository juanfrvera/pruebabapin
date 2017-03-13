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
    public partial class GeoreferenciacionEdit : WebControlEdit<nc.Georeferenciacion>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revTipo.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
			  revTipo.ErrorMessage = TranslateFormat("InvalidField", "Tipo");
			  rfvTipo.ErrorMessage = TranslateFormat("FieldIsNull", "Tipo");
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtTipo);
			txtTipo.Focus();
					
        }		
		public override void SetValue()
        {
            UIHelper.SetValue(txtTipo, Entity.IdGeoreferenciacionTipo);
			txtTipo.Focus();
					
        }	
        public override void GetValue()
        {
            Entity.IdGeoreferenciacionTipo = UIHelper.GetInt(txtTipo);
				
        }
    }
}

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
    public partial class PriorityEdit : WebControlEdit<nc.Priority>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			revIdPriority.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
			revName.ValidationExpression=Contract.DataHelper.GetExpRegString(50);
			revImg.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
            revIdPriority.ErrorMessage = TranslateFormat("InvalidField", "Prioridad");
            revName.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
            revImg.ErrorMessage = TranslateFormat("InvalidField", "Imagen");
            rfvName.ErrorMessage = TranslateFormat("FieldIsNull", "Nombre");
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(txtIdPriority);
			txtIdPriority.Focus();
				UIHelper.Clear(txtName);
			UIHelper.Clear(txtImg);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(txtIdPriority, Entity.IdPriority);
			txtIdPriority.Focus();
				UIHelper.SetValue(txtName, Entity.Name);
			UIHelper.SetValue(txtImg, Entity.Img);
				
        }	
        public override void GetValue()
        {
			Entity.IdPriority=UIHelper.GetInt(txtIdPriority);
			Entity.Name =UIHelper.GetString(txtName);
			Entity.Img =UIHelper.GetString(txtImg);
				
        }
    }
}

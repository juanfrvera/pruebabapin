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
    public partial class IndicadorEdit : WebControlEdit<nc.Indicador>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.MedioVerificacion>(ddlMedioVerificacion, MedioVerificacionService.Current.GetList(),"Nombre","IdMedioVerificacion",new nc.MedioVerificacion(){IdMedioVerificacion=0, Nombre= "Seleccione MedioVerificacion"});
			revObservacion.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(500);
            revObservacion.ErrorMessage = TranslateFormat("InvalidField", "Observación");
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(ddlMedioVerificacion);
			ddlMedioVerificacion.Focus();
				UIHelper.Clear(txtObservacion);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(ddlMedioVerificacion, Entity.IdMedioVerificacion);
			ddlMedioVerificacion.Focus();
				UIHelper.SetValue(txtObservacion, Entity.Observacion);
				
        }	
        public override void GetValue()
        {
			Entity.IdMedioVerificacion =UIHelper.GetIntNullable(ddlMedioVerificacion);
			Entity.Observacion =UIHelper.GetString(txtObservacion);
				
        }
    }
}

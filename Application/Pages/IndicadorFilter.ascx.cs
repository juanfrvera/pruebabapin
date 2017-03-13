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
    public partial class IndicadorFilter : WebControlFilter<nc.IndicadorFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.MedioVerificacion>(ddlMedioVerificacion, MedioVerificacionService.Current.GetList(),"Nombre","IdMedioVerificacion",new nc.MedioVerificacion(){IdMedioVerificacion=0, Nombre= "Seleccione MedioVerificacion"});
			revObservacion.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(500);
            revObservacion.ErrorMessage = TranslateFormat("InvalidField", "Observación");
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(ddlMedioVerificacion);
			ddlMedioVerificacion.Focus();
				UIHelper.Clear(txtObservacion);
				
        }		
		protected override void SetValue()
        {ddlMedioVerificacion.Focus();
				UIHelper.SetValueFilter(txtObservacion, Filter.Observacion);
                UIHelper.SetValue(ddlMedioVerificacion, Filter.IdMedioVerificacion);
							
        }	
        protected override void GetValue()
        {
			Filter.IdMedioVerificacion =UIHelper.GetIntNullable(ddlMedioVerificacion);
            Filter.Observacion = UIHelper.GetStringBetweenFilter(txtObservacion);
				
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

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
    public partial class SistemaCommandFilter : WebControlFilter<nc.SistemaCommandFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
			  revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
		
			UIHelper.Load<nc.SistemaEntidad>(ddlsistemaEntidad, SistemaEntidadService.Current.GetList(),"Nombre","IdSistemaEntidad",new nc.SistemaEntidad(){IdSistemaEntidad=0, Nombre= "Seleccione SistemaEntidad"});
			revCommandText.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(2000);
			  revCommandText.ErrorMessage = TranslateFormat("InvalidField", "CommandText");


              chkActivo.CheckedValue = true;
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtNombre);
			txtNombre.Focus();
			UIHelper.Clear(ddlsistemaEntidad);
			UIHelper.Clear(txtCommandText);
			chkActivo.CheckedValue = true;
				
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
						txtNombre.Focus();
						UIHelper.SetValue(ddlsistemaEntidad, Filter.IdsistemaEntidad);
				UIHelper.SetValueFilter(txtCommandText, Filter.CommandText);
						UIHelper.SetValue(chkActivo, Filter.Activo);
							
        }	
        protected override void GetValue()
        {
			Filter.Nombre =UIHelper.GetStringFilter(txtNombre);
			Filter.IdsistemaEntidad =UIHelper.GetIntNullable(ddlsistemaEntidad);
			Filter.CommandText =UIHelper.GetStringFilter(txtCommandText);
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

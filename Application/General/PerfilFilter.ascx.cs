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
    public partial class PerfilFilter : WebControlFilter<nc.PerfilFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
			UIHelper.Load<nc.PerfilTipo>(ddlPerfilTipo, PerfilTipoService.Current.GetList(),"Nombre","IdPerfilTipo",new nc.PerfilTipo(){IdPerfilTipo=0, Nombre= "Seleccione PerfilTipo"});

            chkActivo.CheckedValue = true;
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtNombre);
			txtNombre.Focus();
				UIHelper.Clear(ddlPerfilTipo);
			chkActivo.CheckedValue = true;
			UIHelper.Clear(chkEsDefault);				
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
						txtNombre.Focus();
                UIHelper.SetValue(ddlPerfilTipo, Filter.IdPerfilTipo);
				UIHelper.SetValue(chkActivo, Filter.Activo);
						UIHelper.SetValue(chkEsDefault, Filter.EsDefault);
							
        }	
        protected override void GetValue()
        {
            Filter.Nombre = UIHelper.GetStringBetweenFilter(txtNombre);
			Filter.IdPerfilTipo =UIHelper.GetIntNullable(ddlPerfilTipo);
			Filter.Activo=UIHelper.GetBooleanNullable(chkActivo);			  
			Filter.EsDefault=UIHelper.GetBooleanNullable(chkEsDefault);
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

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
    public partial class SistemaEntidadAccionFilter : WebControlFilter<nc.SistemaEntidadAccionFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.SistemaEntidad>(ddlSistemaEntidad, SistemaEntidadService.Current.GetList(),"Nombre","IdSistemaEntidad",new nc.SistemaEntidad(){IdSistemaEntidad=0, Nombre= "Seleccione SistemaEntidad"});
			UIHelper.Load<nc.SistemaAccion>(ddlSistemaAccion, SistemaAccionService.Current.GetList(),"Nombre","IdSistemaAccion",new nc.SistemaAccion(){IdSistemaAccion=0, Nombre= "Seleccione SistemaAccion"});
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
		}
		protected override void Clear()
        {			
			UIHelper.Clear(ddlSistemaEntidad);
			ddlSistemaEntidad.Focus();
				UIHelper.Clear(ddlSistemaAccion);
			UIHelper.Clear(txtNombre);
				
        }		
		protected override void SetValue()
        {ddlSistemaEntidad.Focus();
                UIHelper.SetValue(ddlSistemaEntidad, Filter.IdSistemaEntidad);
                UIHelper.SetValue(ddlSistemaAccion, Filter.IdSistemaAccion);
				UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
							
        }	
        protected override void GetValue()
        {
			Filter.IdSistemaEntidad =UIHelper.GetIntNullable(ddlSistemaEntidad);
			Filter.IdSistemaAccion =UIHelper.GetIntNullable(ddlSistemaAccion);
            Filter.Nombre = UIHelper.GetStringBetweenFilter(txtNombre);

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

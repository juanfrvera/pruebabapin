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
    public partial class SistemaEntidadEstadoFilter : WebControlFilter<nc.SistemaEntidadEstadoFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.SistemaEntidad>(ddlSistemaEntidad, SistemaEntidadService.Current.GetList(),"Nombre","IdSistemaEntidad",new nc.SistemaEntidad(){IdSistemaEntidad=0, Nombre= "Seleccione SistemaEntidad"});
			UIHelper.Load<nc.Estado>(ddlEstado, EstadoService.Current.GetList(),"Nombre","IdEstado",new nc.Estado(){IdEstado=0, Nombre= "Seleccione Estado"});
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(ddlSistemaEntidad);
			ddlSistemaEntidad.Focus();
				UIHelper.Clear(ddlEstado);
			UIHelper.Clear(txtNombre);
				
        }		
		protected override void SetValue()
        {ddlSistemaEntidad.Focus();
				UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
                UIHelper.SetValue(ddlSistemaEntidad, Filter.IdSistemaEntidad);
                UIHelper.SetValue(ddlEstado, Filter.IdEstado);
							
        }	
        protected override void GetValue()
        {
			Filter.IdSistemaEntidad =UIHelper.GetIntNullable(ddlSistemaEntidad);
			Filter.IdEstado =UIHelper.GetIntNullable(ddlEstado);
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

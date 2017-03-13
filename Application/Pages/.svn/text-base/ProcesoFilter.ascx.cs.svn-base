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
    public partial class ProcesoFilter : WebControlFilter<nc.ProcesoFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.ProyectoTipo>(ddlProyectoTipo, ProyectoTipoService.Current.GetList(),"Nombre","IdProyectoTipo",new nc.ProyectoTipo(){IdProyectoTipo=0, Nombre= "Seleccione ProyectoTipo"});
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");

            chkActivo.CheckedValue = true;
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(ddlProyectoTipo);
			ddlProyectoTipo.Focus();
				UIHelper.Clear(txtNombre);
			chkActivo.CheckedValue = true;
				
        }		
		protected override void SetValue()
        {ddlProyectoTipo.Focus();
                UIHelper.SetValue(ddlProyectoTipo, Filter.IdProyectoTipo);
				UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
						UIHelper.SetValue(chkActivo, Filter.Activo);
							
        }	
        protected override void GetValue()
        {
			Filter.IdProyectoTipo =UIHelper.GetIntNullable(ddlProyectoTipo);
            Filter.Nombre = UIHelper.GetStringBetweenFilter(txtNombre);
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

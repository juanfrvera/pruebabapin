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
    public partial class ClasificacionGeograficaFilter : WebControlFilter<nc.ClasificacionGeograficaFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
            toClasificacionGeograficaPadre.Width = 500;
			revCodigo.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(4);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(60);
            revCodigo.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
			UIHelper.Load<nc.ClasificacionGeograficaTipo>(ddlClasificacionGeograficaTipo, ClasificacionGeograficaTipoService.Current.GetList(),"Nombre","IdClasificacionGeograficaTipo",new nc.ClasificacionGeograficaTipo(){IdClasificacionGeograficaTipo=0, Nombre= "Seleccione Clasificacion Geográfica Tipo"});


            chkActivo.CheckedValue = true;
        }
		protected override void Clear()
        {			
			UIHelper.Clear(txtCodigo);
			txtCodigo.Focus();
				UIHelper.Clear(txtNombre);
			UIHelper.Clear(ddlClasificacionGeograficaTipo);
			UIHelper.Clear(toClasificacionGeograficaPadre);
			chkActivo.CheckedValue = true;
            UIHelper.Clear(chkIncluirSubClasificaciones);
				
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtCodigo, Filter.Codigo);
						txtCodigo.Focus();
                UIHelper.SetValue(ddlClasificacionGeograficaTipo, Filter.IdClasificacionGeograficaTipo);
                UIHelper.SetValue(toClasificacionGeograficaPadre, Filter.IdClasificacionGeograficaPadre);
				UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
						UIHelper.SetValue(chkActivo, Filter.Activo);
                        UIHelper.SetValue(chkIncluirSubClasificaciones, Filter.IncluirSubClasificaciones);
							
        }	
        protected override void GetValue()
        {
            Filter.Codigo = UIHelper.GetStringBetweenFilter(txtCodigo);
            Filter.Nombre = UIHelper.GetStringBetweenFilter(txtNombre);
			Filter.IdClasificacionGeograficaTipo =UIHelper.GetIntNullable(ddlClasificacionGeograficaTipo);
			Filter.IdClasificacionGeograficaPadre =UIHelper.GetIntNullable(toClasificacionGeograficaPadre);
			Filter.Activo=UIHelper.GetBooleanNullable(chkActivo);
            Filter.IncluirSubClasificaciones = UIHelper.GetBooleanNullable(chkIncluirSubClasificaciones);
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

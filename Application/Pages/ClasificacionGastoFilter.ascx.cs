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
    public partial class ClasificacionGastoFilter : WebControlFilter<nc.ClasificacionGastoFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
            toCaracterEconomico.Width = 550;
            toClasificacionGastoPadre.Width = 550;
			revCodigo.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(4);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(90);
			UIHelper.Load<nc.ClasificacionGastoTipo>(ddlClasificacionGastoTipo, ClasificacionGastoTipoService.Current.GetList(),"Nombre","IdClasificacionGastoTipo",new nc.ClasificacionGastoTipo(){IdClasificacionGastoTipo=0, Nombre= "Seleccione Clasificación Gasto Tipo"});
            UIHelper.Load<nc.ClasificacionGastoRubro>(ddlClasificacionGastoRubro, ClasificacionGastoRubroService.Current.GetList(), "Nombre", "IdClasificacionGastoRubro", new nc.ClasificacionGastoRubro() { IdClasificacionGastoRubro = 0, Nombre = "Seleccione Clasificación Gasto Rubro" });

            chkActivo.CheckedValue = true;
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtCodigo);
			txtCodigo.Focus();
				UIHelper.Clear(txtNombre);
			UIHelper.Clear(ddlClasificacionGastoTipo);
            UIHelper.Clear(ddlClasificacionGastoRubro);
            UIHelper.Clear(chkIncluirSubClasificaciones);
			UIHelper.Clear(toCaracterEconomico);
			chkActivo.CheckedValue = true;
			UIHelper.Clear(toClasificacionGastoPadre);
            UIHelper.Clear(chkIncluirSubCaracterEconomico);
				
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtCodigo, Filter.Codigo);
						txtCodigo.Focus();
                UIHelper.SetValue(ddlClasificacionGastoTipo, Filter.IdClasificacionGasto);
                UIHelper.SetValue(ddlClasificacionGastoRubro, Filter.IdClasificacionGastoRubro);
                UIHelper.SetValue(toClasificacionGastoPadre, Filter.IdClasificacionGastoPadre);
                UIHelper.SetValue(toCaracterEconomico, Filter.IdCaracterEconomico);
                UIHelper.SetValue(chkIncluirSubCaracterEconomico, Filter.IncluirkSubCaracterEconomico);
                UIHelper.SetValue(chkIncluirSubClasificaciones, Filter.IncluirSubClasificaciones);
				UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
				UIHelper.SetValue(chkActivo, Filter.Activo);
							
        }	
        protected override void GetValue()
        {
            Filter.Codigo = UIHelper.GetStringBetweenFilter(txtCodigo);
            Filter.Nombre = UIHelper.GetStringBetweenFilter(txtNombre);
			Filter.IdClasificacionGastoTipo =UIHelper.GetIntNullable(ddlClasificacionGastoTipo);
            Filter.IdClasificacionGastoRubro = UIHelper.GetIntNullable(ddlClasificacionGastoRubro);
			Filter.Activo=UIHelper.GetBooleanNullable(chkActivo);
            Filter.IncluirkSubCaracterEconomico = UIHelper.GetBooleanNullable(chkIncluirSubCaracterEconomico);
            Filter.IncluirSubClasificaciones = UIHelper.GetBooleanNullable(chkIncluirSubClasificaciones);	
			Filter.IdClasificacionGastoPadre =UIHelper.GetIntNullable(toClasificacionGastoPadre);
            Filter.IdCaracterEconomico = UIHelper.GetIntNullable(toCaracterEconomico);
				
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

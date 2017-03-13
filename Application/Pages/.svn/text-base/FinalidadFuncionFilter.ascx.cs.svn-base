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
    public partial class FinalidadFuncionFilter : WebControlFilter<nc.FinalidadFuncionFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();

            toFinalidadFuncionPadre.Width = 500;
			revCodigo.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(3);
			revDenominacion.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
            revCodigo.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revDenominacion.ErrorMessage = TranslateFormat("InvalidField", "Denominación");
			UIHelper.Load<nc.FinalidadFuncionTipo>(ddlFinalidadFunciontipo, FinalidadFuncionTipoService.Current.GetList(),"Nombre","IdFinalidadFuncionTipo",new nc.FinalidadFuncionTipo(){IdFinalidadFuncionTipo=0, Nombre= "Seleccione Finalidad Función Tipo"});

            chkActivo.CheckedValue = true;
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtCodigo);
			txtCodigo.Focus();
				UIHelper.Clear(txtDenominacion);
			chkActivo.CheckedValue = true;
            UIHelper.Clear(chkIncluirSubFinalidades);
			UIHelper.Clear(ddlFinalidadFunciontipo);
            UIHelper.Clear(toFinalidadFuncionPadre);
				
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtCodigo, Filter.Codigo);
						txtCodigo.Focus();
                UIHelper.SetValue(ddlFinalidadFunciontipo, Filter.IdFinalidadFunciontipo);
                UIHelper.SetValue(toFinalidadFuncionPadre, Filter.IdFinalidadFuncionPadre);
                UIHelper.SetValue(chkIncluirSubFinalidades, Filter.IncluirSubFinalidades);
				UIHelper.SetValueFilter(txtDenominacion, Filter.Denominacion);
						UIHelper.SetValue(chkActivo, Filter.Activo);
							
        }	
        protected override void GetValue()
        {
            Filter.Codigo = UIHelper.GetStringBetweenFilter(txtCodigo);
            Filter.Denominacion = UIHelper.GetStringBetweenFilter(txtDenominacion);
			Filter.Activo=UIHelper.GetBooleanNullable(chkActivo);			  
			Filter.IdFinalidadFunciontipo =UIHelper.GetIntNullable(ddlFinalidadFunciontipo);
            Filter.IdFinalidadFuncionPadre = UIHelper.GetIntNullable(toFinalidadFuncionPadre);
            Filter.IncluirSubFinalidades = UIHelper.GetBooleanNullable(chkIncluirSubFinalidades);	

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

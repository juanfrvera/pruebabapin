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
    public partial class FuenteFinanciamientoFilter : WebControlFilter<nc.FuenteFinanciamientoFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
            toFuenteFinanciamientoPadre.Width = 500;
			revCodigo.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(2);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(50);
            revCodigo.ErrorMessage = TranslateFormat("InvalidField", "Código");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
			UIHelper.Load<nc.FuenteFinanciamientoTipo>(ddlFuenteFinanciamientoTipo, FuenteFinanciamientoTipoService.Current.GetList(),"Nombre","IdFuenteFinanciamientoTipo",new nc.FuenteFinanciamientoTipo(){IdFuenteFinanciamientoTipo=0, Nombre= "Seleccione FuenteFinanciamientoTipo"});

            chkActivo.CheckedValue = true;
		}
		protected override void Clear()
        {			
			UIHelper.Clear(txtCodigo);
			txtCodigo.Focus();
				UIHelper.Clear(txtNombre);
			UIHelper.Clear(ddlFuenteFinanciamientoTipo);
			chkActivo.CheckedValue = true;
            UIHelper.Clear(chkIncluirSubFuenteFinanciamiento);
			UIHelper.Clear(toFuenteFinanciamientoPadre);
				
        }		
		protected override void SetValue()
        {UIHelper.SetValueFilter(txtCodigo, Filter.Codigo);
						txtCodigo.Focus();
                        UIHelper.SetValue(ddlFuenteFinanciamientoTipo, Filter.IdFuenteFinanciamientoTipo);
                        UIHelper.SetValue(chkIncluirSubFuenteFinanciamiento, Filter.IncluirSubFuenteFinanciamiento);
				UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
						UIHelper.SetValue(chkActivo, Filter.Activo);
							
        }	
        protected override void GetValue()
        {
            Filter.Codigo = UIHelper.GetStringBetweenFilter(txtCodigo);
            Filter.Nombre = UIHelper.GetStringBetweenFilter(txtNombre);
			Filter.IdFuenteFinanciamientoTipo =UIHelper.GetIntNullable(ddlFuenteFinanciamientoTipo);
			Filter.Activo=UIHelper.GetBooleanNullable(chkActivo);			  
			Filter.IdFuenteFinanciamientoPadre =UIHelper.GetIntNullable(toFuenteFinanciamientoPadre);
            Filter.IncluirSubFuenteFinanciamiento = UIHelper.GetBooleanNullable(chkIncluirSubFuenteFinanciamiento);	
				
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

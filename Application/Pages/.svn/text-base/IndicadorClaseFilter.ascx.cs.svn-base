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
    public partial class IndicadorClaseFilter : WebControlFilter<nc.IndicadorClaseFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.IndicadorTipo>(ddlIndicadorTipo, IndicadorTipoService.Current.GetList(),"Nombre","IdIndicadorTipo",new nc.IndicadorTipo(){IdIndicadorTipo=0, Nombre= "Seleccione IndicadorTipo"});
			UIHelper.Load<nc.IndicadorRubro>(ddlIndicadorSector, IndicadorRubroService.Current.GetList(),"Nombre","IdIndicadorRubro",new nc.IndicadorRubro(){IdIndicadorRubro=0, Nombre= "Seleccione IndicadorSector"});
			revSigla.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(10);
			revNombre.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
            revSigla.ErrorMessage = TranslateFormat("InvalidField", "Sigla");
            revNombre.ErrorMessage = TranslateFormat("InvalidField", "Nombre");
			UIHelper.Load<nc.UnidadMedida>(ddlUnidad, UnidadMedidaService.Current.GetList(),"Nombre","IdUnidadMedida",new nc.UnidadMedida(){IdUnidadMedida=0, Nombre= "Seleccione UnidadMedida"});
			revRangoInicial.ValidationExpression=Contract.DataHelper.GetExpRegNumberNullable();
			revRangoFinal.ValidationExpression=Contract.DataHelper.GetExpRegNumberNullable();
            revRangoInicial.ErrorMessage = TranslateFormat("InvalidField", "Rango Inicial");
            revRangoFinal.ErrorMessage = TranslateFormat("InvalidField", "Rango Final");
		}
		protected override void Clear()
        {			
			UIHelper.Clear(ddlIndicadorTipo);
			ddlIndicadorTipo.Focus();
				UIHelper.Clear(ddlIndicadorSector);
			UIHelper.Clear(txtSigla);
			UIHelper.Clear(txtNombre);
			UIHelper.Clear(ddlUnidad);
			UIHelper.Clear(txtRangoInicial);
			UIHelper.Clear(txtRangoFinal);
			chkActivo.CheckedValue = true;

            chkActivo.CheckedValue = true;
        }		
		protected override void SetValue()
        {ddlIndicadorTipo.Focus();
				UIHelper.SetValueFilter(txtSigla, Filter.Sigla);
                UIHelper.SetValue(ddlIndicadorTipo, Filter.IdIndicadorTipo);
                UIHelper.SetValue(ddlIndicadorSector, Filter.IdIndicadorRubro);
                UIHelper.SetValue(ddlUnidad, Filter.IdUnidad);
						UIHelper.SetValueFilter(txtNombre, Filter.Nombre);
						UIHelper.SetValue(txtRangoInicial, Filter.RangoInicial);
						UIHelper.SetValue(txtRangoFinal, Filter.RangoFinal);
						UIHelper.SetValue(chkActivo, Filter.Activo);
							
        }	
        protected override void GetValue()
        {
			Filter.IdIndicadorTipo =UIHelper.GetIntNullable(ddlIndicadorTipo);
            Filter.IdIndicadorRubro =UIHelper.GetIntNullable(ddlIndicadorSector);
            Filter.Sigla = UIHelper.GetStringBetweenFilter(txtSigla);
            Filter.Nombre = UIHelper.GetStringBetweenFilter(txtNombre);
			Filter.IdUnidad =UIHelper.GetIntNullable(ddlUnidad);
			Filter.RangoInicial=UIHelper.GetIntNullable(txtRangoInicial);
			Filter.RangoFinal=UIHelper.GetIntNullable(txtRangoFinal);
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

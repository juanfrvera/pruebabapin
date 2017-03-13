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
    public partial class MonedaCotizacionFilter : WebControlFilter<nc.MonedaCotizacionFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.Moneda>(ddlMoneda, MonedaService.Current.GetList(),"Nombre","IdMoneda",new nc.Moneda(){IdMoneda=0, Nombre= "Seleccione Moneda"});
            rdFecha.ErrorMessageValidator = TranslateFormat("InvalidField", "Nombre");
            rnCotizacion.ErrorMessageNumericFrom = TranslateFormat("InvalidField", "Cotización de");
            rnCotizacion.ErrorMessageNumericTo= TranslateFormat("InvalidField", "Cotización a");
            rnCotizacion.ErrorMessageValidator = TranslateFormat("InvalidField", "Cotización");
		}
		protected override void Clear()
        {			
			UIHelper.Clear(ddlMoneda);
			ddlMoneda.Focus();
				UIHelper.Clear(rdFecha);
			UIHelper.Clear(rnCotizacion);
				
        }		
		protected override void SetValue()
        {ddlMoneda.Focus();
				UIHelper.SetValue<DateTime?>(rdFecha, Filter.Fecha, Filter.Fecha_To);
                UIHelper.SetValue(ddlMoneda, Filter.IdMoneda);
						UIHelper.SetValue<decimal?>(rnCotizacion, Filter.Cotizacion, Filter.Cotizacion_To);
							
        }	
        protected override void GetValue()
        {
			Filter.IdMoneda =UIHelper.GetIntNullable(ddlMoneda);
			Filter.Fecha =UIHelper.GetValueFromDate(rdFecha);
            Filter.Fecha_To = UIHelper.GetValueToDate(rdFecha);
			Filter.Cotizacion =UIHelper.GetValueFrom<decimal?>(rnCotizacion);
            Filter.Cotizacion_To = UIHelper.GetValueTo<decimal?>(rnCotizacion);

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

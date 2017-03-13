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
    public partial class MonedaCotizacionEdit : WebControlEdit<nc.MonedaCotizacion>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
            UIHelper.Load<nc.Moneda>(ddlMoneda, MonedaService.Current.GetList(new nc.MonedaFilter() { Activo = true }), "Nombre", "IdMoneda", new nc.Moneda() { IdMoneda = 0, Nombre = "Seleccione Moneda" });
			revCotizacion.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
            revCotizacion.ErrorMessage = TranslateFormat("InvalidField", "Cotización");
            rfvCotizacion.ErrorMessage = TranslateFormat("FieldIsNull", "Cotización");
            rfvMoneda.ErrorMessage = TranslateFormat("FieldIsNull", "Moneda");
            diFecha.RequiredErrorMessage = TranslateFormat("FieldIsNull", "Fecha");
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(ddlMoneda);
			ddlMoneda.Focus();
				UIHelper.Clear(diFecha);
			UIHelper.Clear(txtCotizacion);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue<Moneda,int>(ddlMoneda, Entity.IdMoneda, MonedaService.Current.GetById);
			ddlMoneda.Focus();
				UIHelper.SetValue(diFecha, Entity.Fecha);
			UIHelper.SetValue(txtCotizacion, Entity.Cotizacion);
				
        }	
        public override void GetValue()
        {
			Entity.IdMoneda =UIHelper.GetInt(ddlMoneda);
			Entity.Fecha =UIHelper.GetDateTime(diFecha);
			Entity.Cotizacion=UIHelper.GetDecimal(txtCotizacion);
				
        }
    }
}

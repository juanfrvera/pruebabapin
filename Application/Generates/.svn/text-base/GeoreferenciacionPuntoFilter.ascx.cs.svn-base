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
    public partial class GeoreferenciacionPuntoFilter : WebControlFilter<nc.GeoreferenciacionPuntoFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			//UIHelper.Load<nc.Georeferenciacion>(ddlGeoreferenciacion, GeoreferenciacionService.Current.GetList(),"IdGeoreferenciacion","IdGeoreferenciacion",new nc.Georeferenciacion(){IdGeoreferenciacion=0, IdGeoreferenciacion= "Seleccione Georeferenciacion"});
			revOrden.ValidationExpression=Contract.DataHelper.GetExpRegNumberNullable();
			  revOrden.ErrorMessage = TranslateFormat("InvalidField", "Orden");	
			revdescripcion.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
			  revdescripcion.ErrorMessage = TranslateFormat("InvalidField", "descripcion");	
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(ddlGeoreferenciacion);
			ddlGeoreferenciacion.Focus();
				UIHelper.Clear(txtOrden);
			UIHelper.Clear(rnLongitud);
			UIHelper.Clear(rnLatitud);
			UIHelper.Clear(txtdescripcion);
				
        }		
		protected override void SetValue()
        {UIHelper.SetValue(ddlGeoreferenciacion, Filter.IdGeoreferenciacion);
				ddlGeoreferenciacion.Focus();
				UIHelper.SetValue(txtOrden, Filter.Orden);
						UIHelper.SetValue<decimal?>(rnLongitud, Filter.Longitud, Filter.Longitud_To);
						UIHelper.SetValue<decimal?>(rnLatitud, Filter.Latitud, Filter.Latitud_To);
						UIHelper.SetValueFilter(txtdescripcion, Filter.descripcion);
							
        }	
        protected override void GetValue()
        {
			Filter.IdGeoreferenciacion =UIHelper.GetIntNullable(ddlGeoreferenciacion);
			Filter.Orden=UIHelper.GetIntNullable(txtOrden);
			Filter.Longitud =UIHelper.GetValueFrom<decimal?>(rnLongitud);
            Filter.Longitud_To = UIHelper.GetValueTo<decimal?>(rnLongitud);
			Filter.Latitud =UIHelper.GetValueFrom<decimal?>(rnLatitud);
            Filter.Latitud_To = UIHelper.GetValueTo<decimal?>(rnLatitud);
			Filter.descripcion =UIHelper.GetStringFilter(txtdescripcion);
				
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

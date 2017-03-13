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
    public partial class GeoreferenciacionPuntoEdit : WebControlEdit<nc.GeoreferenciacionPunto>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			//UIHelper.Load<nc.Georeferenciacion>(ddlGeoreferenciacion, GeoreferenciacionService.Current.GetList(),"IdGeoreferenciacion","IdGeoreferenciacion",new nc.Georeferenciacion(){IdGeoreferenciacion=0, IdGeoreferenciacion= "Seleccione Georeferenciacion"});
			revOrden.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
			  revOrden.ErrorMessage = TranslateFormat("InvalidField", "Orden");
			  rfvOrden.ErrorMessage = TranslateFormat("FieldIsNull", "Orden");
			revLongitud.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
			  revLongitud.ErrorMessage = TranslateFormat("InvalidField", "Longitud");
			  rfvLongitud.ErrorMessage = TranslateFormat("FieldIsNull", "Longitud");
			revLatitud.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
			  revLatitud.ErrorMessage = TranslateFormat("InvalidField", "Latitud");
			  rfvLatitud.ErrorMessage = TranslateFormat("FieldIsNull", "Latitud");
			revdescripcion.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(100);
			  revdescripcion.ErrorMessage = TranslateFormat("InvalidField", "descripcion");
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(ddlGeoreferenciacion);
			ddlGeoreferenciacion.Focus();
				UIHelper.Clear(txtOrden);
			UIHelper.Clear(txtLongitud);
			UIHelper.Clear(txtLatitud);
			UIHelper.Clear(txtdescripcion);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(ddlGeoreferenciacion, Entity.IdGeoreferenciacion);
			ddlGeoreferenciacion.Focus();
				UIHelper.SetValue(txtOrden, Entity.Orden);
			UIHelper.SetValue(txtLongitud, Entity.Longitud);
			UIHelper.SetValue(txtLatitud, Entity.Latitud);
			UIHelper.SetValue(txtdescripcion, Entity.descripcion);
				
        }	
        public override void GetValue()
        {
			Entity.IdGeoreferenciacion =UIHelper.GetInt(ddlGeoreferenciacion);
			Entity.Orden=UIHelper.GetInt(txtOrden);
			Entity.Longitud=UIHelper.GetDecimal(txtLongitud);
			Entity.Latitud=UIHelper.GetDecimal(txtLatitud);
			Entity.descripcion =UIHelper.GetString(txtdescripcion);
				
        }
    }
}

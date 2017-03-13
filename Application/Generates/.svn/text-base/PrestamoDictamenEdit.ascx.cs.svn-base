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
    public partial class PrestamoDictamenEdit : WebControlEdit<nc.PrestamoDictamen>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.Prestamo>(ddlPrestamo, PrestamoService.Current.GetList(),"Descripcion","IdPrestamo",new nc.Prestamo(){IdPrestamo=0, Descripcion= "Seleccione Prestamo"});
			revIdDictamen.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
			revObservacion.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(500);
			revIdUsuario.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(ddlPrestamo);
			ddlPrestamo.Focus();
				UIHelper.Clear(txtIdDictamen);
			UIHelper.Clear(txtObservacion);
			UIHelper.Clear(txtIdUsuario);
			UIHelper.Clear(diFecha);
			UIHelper.Clear(diFechaIngreso);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(ddlPrestamo, Entity.IdPrestamo);
			ddlPrestamo.Focus();
				UIHelper.SetValue(txtIdDictamen, Entity.IdDictamen);
			UIHelper.SetValue(txtObservacion, Entity.Observacion);
			UIHelper.SetValue(txtIdUsuario, Entity.IdUsuario);
			UIHelper.SetValue(diFecha, Entity.Fecha);
			UIHelper.SetValue(diFechaIngreso, Entity.FechaIngreso);
				
        }	
        public override void GetValue()
        {
			Entity.IdPrestamo =UIHelper.GetInt(ddlPrestamo);
			Entity.IdDictamen=UIHelper.GetInt(txtIdDictamen);
			Entity.Observacion =UIHelper.GetString(txtObservacion);
			Entity.IdUsuario=UIHelper.GetInt(txtIdUsuario);
			Entity.Fecha =UIHelper.GetDateTime(diFecha);
			Entity.FechaIngreso =UIHelper.GetDateTime(diFechaIngreso);
				
        }
    }
}

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
    public partial class PrestamoDictamenFilter : WebControlFilter<nc.PrestamoDictamenFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.Prestamo>(ddlPrestamo, PrestamoService.Current.GetList(),"Descripcion","IdPrestamo",new nc.Prestamo(){IdPrestamo=0, Descripcion= "Seleccione Prestamo"});
			revIdDictamen.ValidationExpression=Contract.DataHelper.GetExpRegNumberNullable();
			revObservacion.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(500);
			revIdUsuario.ValidationExpression=Contract.DataHelper.GetExpRegNumberNullable();
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(ddlPrestamo);
			ddlPrestamo.Focus();
				UIHelper.Clear(txtIdDictamen);
			UIHelper.Clear(txtObservacion);
			UIHelper.Clear(txtIdUsuario);
			UIHelper.Clear(rdFecha);
			UIHelper.Clear(rdFechaIngreso);
				
        }		
		protected override void SetValue()
        {ddlPrestamo.Focus();
				UIHelper.SetValue(txtIdDictamen, Filter.IdDictamen);
						UIHelper.SetValueFilter(txtObservacion, Filter.Observacion);
						UIHelper.SetValue(txtIdUsuario, Filter.IdUsuario);
						UIHelper.SetValue<DateTime?>(rdFecha, Filter.Fecha, Filter.Fecha_To);
						UIHelper.SetValue<DateTime?>(rdFechaIngreso, Filter.FechaIngreso, Filter.FechaIngreso_To);
							
        }	
        protected override void GetValue()
        {
			Filter.IdPrestamo =UIHelper.GetIntNullable(ddlPrestamo);
			Filter.IdDictamen=UIHelper.GetIntNullable(txtIdDictamen);
			Filter.Observacion =UIHelper.GetStringFilter(txtObservacion);
			Filter.IdUsuario=UIHelper.GetIntNullable(txtIdUsuario);
			Filter.Fecha =UIHelper.GetValueFrom<DateTime?>(rdFecha);
            Filter.Fecha_To = UIHelper.GetValueTo<DateTime?>(rdFecha);
			Filter.FechaIngreso =UIHelper.GetValueFrom<DateTime?>(rdFechaIngreso);
            Filter.FechaIngreso_To = UIHelper.GetValueTo<DateTime?>(rdFechaIngreso);
				
        }
		protected void btSearch_Click(object sender, EventArgs e)
        {
            RaiseControlCommand(Command.SEARCH);
        }
    }
}

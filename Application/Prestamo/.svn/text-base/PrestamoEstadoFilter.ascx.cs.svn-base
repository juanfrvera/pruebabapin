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
    public partial class PrestamoEstadoFilter : WebControlFilter<nc.PrestamoEstadoFilter>
    {
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.Prestamo>(ddlPrestamo, PrestamoService.Current.GetList(),"Descripcion","IdPrestamo",new nc.Prestamo(){IdPrestamo=0, Descripcion= "Seleccione Prestamo"});
			UIHelper.Load<nc.Estado>(ddlEstado, EstadoService.Current.GetList(),"Nombre","IdEstado",new nc.Estado(){IdEstado=0, Nombre= "Seleccione Estado"});
			
		}
		protected override void Clear()
        {			
			UIHelper.Clear(ddlPrestamo);
			ddlPrestamo.Focus();
				UIHelper.Clear(ddlEstado);
			UIHelper.Clear(rdFechaEstimada);
			UIHelper.Clear(rdFechaRealizada);
				
        }		
		protected override void SetValue()
        {ddlPrestamo.Focus();
                UIHelper.SetValue(ddlPrestamo, Filter.IdPrestamo);
                UIHelper.SetValue(ddlEstado, Filter.IdEstado);
				UIHelper.SetValue<DateTime?>(rdFechaEstimada, Filter.FechaEstimada, Filter.FechaEstimada_To);
						UIHelper.SetValue<DateTime?>(rdFechaRealizada, Filter.FechaRealizada, Filter.FechaRealizada_To);
							
        }	
        protected override void GetValue()
        {
			Filter.IdPrestamo =UIHelper.GetIntNullable(ddlPrestamo);
			Filter.IdEstado =UIHelper.GetIntNullable(ddlEstado);
			Filter.FechaEstimada =UIHelper.GetValueFromDate(rdFechaEstimada);
            Filter.FechaEstimada_To = UIHelper.GetValueToDate(rdFechaEstimada);
			Filter.FechaRealizada =UIHelper.GetValueFromDate(rdFechaRealizada);
            Filter.FechaRealizada_To = UIHelper.GetValueToDate(rdFechaRealizada);

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

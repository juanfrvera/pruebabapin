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
    public partial class PrestamoEstadoEdit : WebControlEdit<nc.PrestamoEstado>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
			UIHelper.Load<nc.Prestamo>(ddlPrestamo, PrestamoService.Current.GetList(),"Descripcion","IdPrestamo",new nc.Prestamo(){IdPrestamo=0, Descripcion= "Seleccione Prestamo"});
			UIHelper.Load<nc.Estado>(ddlEstado, EstadoService.Current.GetList(new nc.EstadoFilter() {Activo=true}) ,"Nombre","IdEstado",new nc.Estado(){IdEstado=0, Nombre= "Seleccione Estado"});
            diFechaEstimada.RequiredErrorMessage = TranslateFormat("FieldIsNull", "Fecha Estimada");
		}
		public override void Clear()
        {			
			UIHelper.Clear(ddlPrestamo);
			ddlPrestamo.Focus();
				UIHelper.Clear(ddlEstado);
			UIHelper.Clear(diFechaEstimada);
			UIHelper.Clear(diFechaRealizada);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(ddlPrestamo, Entity.IdPrestamo);
			ddlPrestamo.Focus();
			UIHelper.SetValue<Estado,int>(ddlEstado, Entity.IdEstado,EstadoService.Current.GetById);
			UIHelper.SetValue(diFechaEstimada, Entity.FechaEstimada);
			UIHelper.SetValue(diFechaRealizada, Entity.FechaRealizada);
				
        }	
        public override void GetValue()
        {
			Entity.IdPrestamo =UIHelper.GetInt(ddlPrestamo);
			Entity.IdEstado =UIHelper.GetInt(ddlEstado);
			Entity.FechaEstimada =UIHelper.GetDateTime(diFechaEstimada);
			Entity.FechaRealizada =UIHelper.GetDateTimeNullable(diFechaRealizada);
				
        }
    }
}

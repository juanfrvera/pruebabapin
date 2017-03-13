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
    public partial class ProyectoPrioridadEdit : WebControlEdit<nc.ProyectoPrioridad>
    { 
		protected override void _Initialize()
        {
            base._Initialize();
            UIHelper.Load<nc.Proyecto>(ddlProyecto, ProyectoService.Current.GetList(), "ProyectoDenominacion", "IdProyecto", new nc.Proyecto() { IdProyecto = 0, ProyectoDenominacion = "Seleccione Proyecto" });
            UIHelper.Load<nc.PlanPeriodo>(ddlPlanPeriodo, PlanPeriodoService.Current.GetList(new nc.PlanPeriodoFilter() { Activo = true }), "Nombre", "IdPlanPeriodo", new nc.PlanPeriodo() { IdPlanPeriodo = 0, Nombre = "Seleccione PlanPeriodo" });
            UIHelper.Load<nc.Prioridad>(ddlPrioridad, PrioridadService.Current.GetList(new nc.PrioridadFilter() { Activo = true }), "Nombre", "IdPrioridad", new nc.Prioridad() { IdPrioridad = 0, Nombre = "Seleccione Prioridad" });
			revPuntaje.ValidationExpression=Contract.DataHelper.GetExpRegNumber();
            UIHelper.Load<nc.Clasificacion>(ddlClasificacion, ClasificacionService.Current.GetList(new nc.ClasificacionFilter() { Activo = true }), "Nombre", "IdClasificacion", new nc.Clasificacion() { IdClasificacion = 0, Nombre = "Seleccione Clasificacion" });
			revComentario.ValidationExpression=Contract.DataHelper.GetExpRegStringNullable(500);
			
		}
		public override void Clear()
        {			
			UIHelper.Clear(ddlProyecto);
			ddlProyecto.Focus();
				UIHelper.Clear(ddlPlanPeriodo);
			UIHelper.Clear(ddlPrioridad);
			UIHelper.Clear(txtPuntaje);
			UIHelper.Clear(chkReqArt15);
			UIHelper.Clear(ddlClasificacion);
			UIHelper.Clear(txtComentario);
				
        }		
		public override void SetValue()
        {			
			UIHelper.SetValue(ddlProyecto, Entity.IdProyecto);
			ddlProyecto.Focus();
				UIHelper.SetValue<PlanPeriodo,int>(ddlPlanPeriodo, Entity.IdPlanPeriodo, PlanPeriodoService.Current.GetById);
            if(Entity.IdPrioridad.HasValue)
    			UIHelper.SetValue<Prioridad,int>(ddlPrioridad, Entity.IdPrioridad.Value,PrioridadService.Current.GetById);
			UIHelper.SetValue(txtPuntaje, Entity.Puntaje);
			UIHelper.SetValue(chkReqArt15, Entity.ReqArt15);
            if(Entity.IdClasificacion.HasValue)
    			UIHelper.SetValue<Clasificacion,int>(ddlClasificacion, Entity.IdClasificacion.Value, ClasificacionService.Current.GetById);
			UIHelper.SetValue(txtComentario, Entity.Comentario);
				
        }	
        public override void GetValue()
        {
			Entity.IdProyecto =UIHelper.GetInt(ddlProyecto);
			Entity.IdPlanPeriodo =UIHelper.GetInt(ddlPlanPeriodo);
			Entity.IdPrioridad =UIHelper.GetIntNullable(ddlPrioridad);
			Entity.Puntaje=UIHelper.GetInt(txtPuntaje);
			Entity.ReqArt15=UIHelper.GetBoolean(chkReqArt15);
			Entity.IdClasificacion =UIHelper.GetIntNullable(ddlClasificacion);
			Entity.Comentario =UIHelper.GetString(txtComentario);
				
        }
    }
}

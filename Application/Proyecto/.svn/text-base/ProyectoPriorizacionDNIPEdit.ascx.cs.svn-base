using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Contract;
using nc = Contract;
using Service;
namespace UI.Web
{
    public partial class ProyectoPriorizacionDNIPEdit : WebControlEdit<nc.ProyectoPrioridad >
    {
    
        protected override void _Initialize()
        {
            base._Initialize();
            UIHelper.Load<nc.Clasificacion>(ddlClasificacion, ClasificacionService.Current.GetList(new nc.ClasificacionFilter() { Activo = true }), "Nombre", "IdClasificacion", new nc.Clasificacion() { IdClasificacion = 0, Nombre = "Seleccione Clasificacion" });
            UIHelper.Load<nc.Prioridad>(ddlPrioridad, PrioridadService.Current.GetList(new nc.PrioridadFilter() { Activo = true }), "Nombre", "IdPrioridad", new nc.Prioridad() { IdPrioridad = 0, Nombre = "Seleccione Prioridad" });
        }
        public override void Clear()
        {
            UIHelper.Clear(chkPrioridadAsignada);
            UIHelper.Clear(ddlPrioridad);
            UIHelper.Clear(txtPuntaje);
            UIHelper.Clear(chkConfReq);
            UIHelper.Clear(chkReqArt15);
            UIHelper.Clear(ddlClasificacion);
            UIHelper.Clear(txtComentario);
            
        }
        public override void SetValue()
        {
            UIHelper.SetValue (chkPrioridadAsignada , Entity.PrioridadAsignada);
            UIHelper.SetValue(txtPuntaje, Entity.Puntaje);
            UIHelper.SetValue(chkConfReq, Entity.ConfRequerimientos );
            UIHelper.SetValue(chkReqArt15, Entity.ReqArt15 );
            if(Entity.IdPrioridad.HasValue)
                UIHelper.SetValue<Prioridad, int>(ddlPrioridad, Entity.IdPrioridad.Value, PrioridadService.Current.GetById);
            if(Entity.IdClasificacion.HasValue)
                UIHelper.SetValue<Clasificacion,int>(ddlClasificacion, Entity.IdClasificacion.Value,ClasificacionService.Current.GetById);
            UIHelper.SetValue(txtComentario, Entity.Comentario );
        }
        public override void GetValue()
        {
            Entity.PrioridadAsignada = UIHelper.GetBoolean (chkPrioridadAsignada );
            Entity.IdPrioridad =  UIHelper.GetIntNullable  ( ddlPrioridad );
            Entity.Puntaje = UIHelper.GetInt(txtPuntaje );
            Entity.ConfRequerimientos  = UIHelper.GetBoolean (chkConfReq );
            Entity.ReqArt15 = UIHelper.GetBoolean(chkReqArt15);
            Entity.IdClasificacion = UIHelper.GetInt (ddlClasificacion);
            Entity.Comentario = UIHelper.GetString (txtComentario);

        }

      
    }
}

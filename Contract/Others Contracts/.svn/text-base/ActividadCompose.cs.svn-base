using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Xml.Serialization;

namespace Contract
{
    [Serializable]
    public class ActividadPermisoNode : NodeModel
    {
        public int? idPermiso;
        public int? IdPermiso 
        {
            get {return idPermiso;}
            set {
                idPermiso = value;
                Value = idPermiso.HasValue ? idPermiso.Value.ToString() : "";
                }        
        }
        public int? IdSistemaAccion { get; set; }
        public int? IdSistemaEntidad { get; set; }
        public int? IdSistemaEstado { get; set; }
    }

    [Serializable]
    public class ActividadCompose
    {
        public ActividadResult Actividad { get; set; }
        public List<ActividadPermisoResult> ActividadPermisos { get; set; }

        public List<NodeModel> GetActividadPermisosNodes()
        {
            List<NodeModel> AllNodes = new List<NodeModel>();

            if (ActividadPermisos == null || ActividadPermisos.Count < 1) return AllNodes; 

            List<ActividadPermisoNode> OtherNodes;
            List<ActividadPermisoNode> EntityNodes;
            List<ActividadPermisoNode> PermisosEntidadNodes;
            List<ActividadPermisoNode> ActionNodes;
            List<ActividadPermisoNode> EstadoNodes;

            OtherNodes =
            (from o in ActividadPermisos
             where o.Permiso_IdSistemaEntidad.HasValue == false
             select new ActividadPermisoNode() { Value= o.IdPermiso.ToString(),  IdPermiso = o.IdPermiso, Text = o.Permiso_Nombre, Checked = o.Selected }
             ).ToList();

            EntityNodes =
             (from o in ActividadPermisos
              where o.Permiso_IdSistemaEntidad.HasValue == true
                 //&& o.Permiso_IdSistemaAccion.HasValue == true
              orderby o.Permiso_SistemaEntidad_Nombre
              group o by new { IdSistemaEntidad = o.Permiso_IdSistemaEntidad, Nombre = o.Permiso_SistemaEntidad_Nombre }  into g
              select new ActividadPermisoNode() { IdPermiso = 0, IdSistemaEntidad = g.Key.IdSistemaEntidad, Text = g.Key.Nombre, Checked = g.Sum(p => p.Selected ? 1 : 0) > 0 }
              ).ToList();


            foreach (ActividadPermisoNode EntityNode in EntityNodes)
            {
                //permisos que no son acciones
                PermisosEntidadNodes =
               (from o in ActividadPermisos
                where o.Permiso_IdSistemaEntidad == EntityNode.IdSistemaEntidad
                   && o.Permiso_IdSistemaAccion.HasValue == false
                select new ActividadPermisoNode() { Value = o.IdPermiso.ToString(), IdPermiso = o.IdPermiso, IdSistemaEntidad = o.Permiso_IdSistemaEntidad, Text = o.Permiso_Nombre, Checked = o.Selected }
                ).ToList();

                if(PermisosEntidadNodes.Count> 0)
                   EntityNode.Childs.AddRange(DataHelper.ToList<ActividadPermisoNode, NodeModel>(PermisosEntidadNodes));


                //acciones sin estado
                ActionNodes =
               (from o in ActividadPermisos
                where o.Permiso_IdSistemaEntidad == EntityNode.IdSistemaEntidad
                   && o.Permiso_SistemaAccion_IncluirEstado ==false
                select new ActividadPermisoNode() { Value = o.IdPermiso.ToString(), IdPermiso = o.IdPermiso, IdSistemaEntidad = o.Permiso_IdSistemaEntidad, IdSistemaAccion = o.Permiso_IdSistemaAccion, Text = o.Permiso_SistemaAccion_Nombre, Checked = o.Selected }
                ).ToList();
                EntityNode.Childs.AddRange(DataHelper.ToList<ActividadPermisoNode, NodeModel>(ActionNodes));

                //acciones que podrian tener estado pero no estan por estado
                ActionNodes =
               (from o in ActividadPermisos
                where o.Permiso_IdSistemaEntidad == EntityNode.IdSistemaEntidad
                   && o.Permiso_IdSistemaEstado.HasValue == false  && o.Permiso_IdSistemaAccion.HasValue == true && o.Permiso_SistemaAccion_IncluirEstado == true
                select new ActividadPermisoNode() { Value = o.IdPermiso.ToString(), IdPermiso = o.IdPermiso, IdSistemaEntidad = o.Permiso_IdSistemaEntidad, IdSistemaAccion = o.Permiso_IdSistemaAccion, Text = o.Permiso_SistemaAccion_Nombre, Checked = o.Selected }
                ).ToList();

                if (ActionNodes.Count == 0 )
                {//acciones con estado
                    ActionNodes =
                    (from o in ActividadPermisos
                     where o.Permiso_IdSistemaEntidad == EntityNode.IdSistemaEntidad
                        && o.Permiso_IdSistemaEstado.HasValue == true
                     group o by new {IdSistemaEntidad = o.Permiso_IdSistemaEntidad, IdSistemaAccion = o.Permiso_IdSistemaAccion, Text = o.Permiso_SistemaAccion_Nombre } into g
                     select new ActividadPermisoNode() { IdPermiso = 0, IdSistemaEntidad = g.Key.IdSistemaEntidad, IdSistemaAccion = g.Key.IdSistemaAccion, Text = g.Key.Text, Checked = g.Sum(p => p.Selected ? 1 : 0) > 0 }
                     ).ToList();
                    foreach (ActividadPermisoNode ActionNode in ActionNodes)
                    {
                        EstadoNodes =
                       (from o in ActividadPermisos
                        where o.Permiso_IdSistemaEntidad == ActionNode.IdSistemaEntidad
                           && o.Permiso_IdSistemaAccion == ActionNode.IdSistemaAccion
                        select new ActividadPermisoNode() { Value = o.IdPermiso.ToString(), IdPermiso = o.IdPermiso, IdSistemaEntidad = o.Permiso_IdSistemaEntidad, IdSistemaAccion = o.Permiso_IdSistemaAccion, IdSistemaEstado = o.Permiso_IdSistemaEstado, Text = o.Permiso_SistemaEstado_Nombre, Checked = o.Selected }
                        ).ToList();
                        ActionNode.Childs.AddRange(DataHelper.ToList<ActividadPermisoNode, NodeModel>(EstadoNodes));
                    }
                }
                EntityNode.Childs.AddRange(DataHelper.ToList<ActividadPermisoNode, NodeModel>(ActionNodes));
            }
            AllNodes.AddRange(DataHelper.ToList<ActividadPermisoNode, NodeModel>(OtherNodes));
            AllNodes.AddRange(DataHelper.ToList<ActividadPermisoNode, NodeModel>(EntityNodes));
            return AllNodes;
        }
    }
}

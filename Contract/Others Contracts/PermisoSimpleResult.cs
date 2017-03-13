using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    [Serializable]
    public class PermisoByTypeNameResult
    {
        public PermisoByTypeNameResult(string typeName, string actionName, int? idEstado)
        {
            this.TypeName = typeName;
            this.ActionName = actionName;
            this.IdEstado = idEstado;
        }        
        public string TypeName { get; set; }
        public string ActionName { get; set; }
        public int? IdEstado { get; set; }
        public bool Permiso { get; set; }   
    }

    [Serializable]
    public class PermisoSimpleResult
    {
        public virtual int ID { get { return IdPermiso; } }
        public int IdPermiso { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int? IdSistemaEntidad { get; set; }
        public int? IdSistemaAccion { get; set; }
        public int? IdSistemaEstado { get; set; }
        public string SistemaEntidad_Codigo { get; set; }
        public string SistemaAccion_Codigo { get; set; }
        public bool SistemaAccion_IncluirEstado { get; set; }
        
    }
}

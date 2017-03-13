using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
    [Serializable]
    public abstract class _ActividadPermisoResult : IResult<int>
    {
        public virtual int ID { get { return IdActividadPermiso; } }
        public int IdActividadPermiso { get; set; }
        public int IdPermiso { get; set; }
        public int IdActividad { get; set; }

        public string Actividad_Nombre { get; set; }
        public bool Actividad_Activo { get; set; }
        public string Permiso_Nombre { get; set; }
        public string Permiso_Codigo { get; set; }
        public int? Permiso_IdSistemaEntidad { get; set; }
        public int? Permiso_IdSistemaAccion { get; set; }
        public int? Permiso_IdSistemaEstado { get; set; }
        public bool? Permiso_Activo { get; set; }

        public virtual ActividadPermiso ToEntity()
        {
            ActividadPermiso _ActividadPermiso = new ActividadPermiso();
            _ActividadPermiso.IdActividadPermiso = this.IdActividadPermiso;
            _ActividadPermiso.IdPermiso = this.IdPermiso;
            _ActividadPermiso.IdActividad = this.IdActividad;

            return _ActividadPermiso;
        }
        public virtual void Set(ActividadPermiso entity)
        {
            this.IdActividadPermiso = entity.IdActividadPermiso;
            this.IdPermiso = entity.IdPermiso;
            this.IdActividad = entity.IdActividad;

        }
        public virtual bool Equals(ActividadPermiso entity)
        {
            if (entity == null) return false;
            if (!entity.IdActividadPermiso.Equals(this.IdActividadPermiso)) return false;
            if (!entity.IdPermiso.Equals(this.IdPermiso)) return false;
            if (!entity.IdActividad.Equals(this.IdActividad)) return false;

            return true;
        }

        public virtual DataTableMapping ToMapping()
        {
            return new DataTableMapping("ActividadPermiso", new List<DataColumnMapping>(new DataColumnMapping[]{
		new DataColumnMapping("Permiso","Permiso_Nombre")
			,new DataColumnMapping("Actividad","Actividad_Nombre")
			}));
        }
    }
}

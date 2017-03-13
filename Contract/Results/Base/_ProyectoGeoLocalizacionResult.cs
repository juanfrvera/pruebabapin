using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract.Base
{
    [Serializable]
    public class _ProyectoGeoLocalizacionResult : IResult<int>
    {
        public virtual int ID { get { return IdGeoLocalizacion; } }
        public int IdGeoLocalizacion { get; set; }
        public int IdProyecto { get; set; }
        public string TipoLocalizacion { get; set; }
        public string InfoLocalizacion { get; set; }

        public virtual ProyectoGeoLocalizacion ToEntity()
        {
            ProyectoGeoLocalizacion _ProyectoGeoLocalizacion = new ProyectoGeoLocalizacion();
            _ProyectoGeoLocalizacion.IdGeoLocalizacion = this.IdGeoLocalizacion;
            _ProyectoGeoLocalizacion.IdProyecto = this.IdProyecto;
            _ProyectoGeoLocalizacion.TipoLocalizacion = this.TipoLocalizacion;
            _ProyectoGeoLocalizacion.InfoLocalizacion = this.InfoLocalizacion;

            return _ProyectoGeoLocalizacion;
        }
        public virtual void Set(ProyectoGeoLocalizacion entity)
        {
            this.IdProyecto = entity.IdProyecto;
            this.TipoLocalizacion = entity.TipoLocalizacion;
            this.InfoLocalizacion = entity.InfoLocalizacion;
        }

        public virtual bool Equals(ProyectoGeoLocalizacion entity)
        {
            if (entity == null) return false;
            if (!entity.IdGeoLocalizacion.Equals(this.IdGeoLocalizacion)) return false;
            if (!entity.IdProyecto.Equals(this.IdProyecto)) return false;
            if (!entity.TipoLocalizacion.Equals(this.TipoLocalizacion)) return false;
            if (!entity.InfoLocalizacion.Equals(this.InfoLocalizacion)) return false;

            return true;
        }

        public virtual DataTableMapping ToMapping()
        {
            return new DataTableMapping("ProyectoGeoLocalizacion", new List<DataColumnMapping>(new DataColumnMapping[]{
		        new DataColumnMapping("IdProyecto","IdProyecto")
			    ,new DataColumnMapping("TipoLocalizacion","TipoLocalizacion")
                ,new DataColumnMapping("InfoLocalizacion","InfoLocalizacion")
			}));
        }
    }
}

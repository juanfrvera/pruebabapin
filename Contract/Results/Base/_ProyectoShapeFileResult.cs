using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract.Base
{
    [Serializable]
    public class _ProyectoShapeFileResult : IResult<int>
    {
        public virtual int ID { get { return IdProyectoShapeFile; } }
        public int IdProyectoShapeFile { get; set; }
        public int IdProyecto { get; set; }
        public string RutaArchivo { get; set; }

        public virtual ProyectoShapeFile ToEntity()
        {
            ProyectoShapeFile _ProyectoShapeFile = new ProyectoShapeFile();
            _ProyectoShapeFile.IdProyectoShapeFile = this.IdProyectoShapeFile;
            _ProyectoShapeFile.IdProyecto = this.IdProyecto;
            _ProyectoShapeFile.RutaArchivo = this.RutaArchivo;

            return _ProyectoShapeFile;
        }
        public virtual void Set(ProyectoShapeFile entity)
        {
            this.IdProyecto = entity.IdProyecto;
            this.RutaArchivo = entity.RutaArchivo;
        }

        public virtual bool Equals(ProyectoShapeFile entity)
        {
            if (entity == null) return false;
            if (!entity.IdProyectoShapeFile.Equals(this.IdProyectoShapeFile)) return false;
            if (!entity.IdProyecto.Equals(this.IdProyecto)) return false;
            if (!entity.RutaArchivo.Equals(this.RutaArchivo)) return false;

            return true;
        }

        public virtual DataTableMapping ToMapping()
        {
            return new DataTableMapping("ProyectoShapeFile", new List<DataColumnMapping>(new DataColumnMapping[]{
		        new DataColumnMapping("IdProyecto","IdProyecto")
			    ,new DataColumnMapping("RutaArchivo","RutaArchivo")
			}));
        }
    }
}

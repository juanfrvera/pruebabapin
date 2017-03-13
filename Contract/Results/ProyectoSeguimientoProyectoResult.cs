using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class ProyectoSeguimientoProyectoResult : IResult<int>
    {
        public virtual int ID { get { return IdProyectoSeguimientoProyecto; } }
        public int IdProyectoSeguimientoProyecto { get; set; }
        public int IdProyectoSeguimiento { get; set; }
        public int IdProyecto { get; set; }
        public string ProvinciasConcatenadas { get; set; }
        public int Proyecto_Codigo { get; set; }
        public string Proyecto_ProyectoDenominacion { get; set; }
        /// <summary>
        /// Solo se utiliza para Reporte de dictamen
        /// </summary>
        public string Proyecto_ProvinciasConcatenadas { get; set; }

        public virtual ProyectoSeguimientoProyecto ToEntity()
        {
            ProyectoSeguimientoProyecto _ProyectoSeguimientoProyecto = new ProyectoSeguimientoProyecto();
            _ProyectoSeguimientoProyecto.IdProyectoSeguimientoProyecto = this.IdProyectoSeguimientoProyecto;
            _ProyectoSeguimientoProyecto.IdProyectoSeguimiento = this.IdProyectoSeguimiento;
            _ProyectoSeguimientoProyecto.IdProyecto = this.IdProyecto;

            return _ProyectoSeguimientoProyecto;
        }
        public virtual void Set(ProyectoSeguimientoProyecto entity)
        {
            this.IdProyectoSeguimientoProyecto = entity.IdProyectoSeguimientoProyecto;
            this.IdProyectoSeguimiento = entity.IdProyectoSeguimiento;
            this.IdProyecto = entity.IdProyecto;

        }
        public virtual bool Equals(ProyectoSeguimientoProyecto entity)
        {
            if (entity == null) return false;
            if (!entity.IdProyectoSeguimientoProyecto.Equals(this.IdProyectoSeguimientoProyecto)) return false;
            if (!entity.IdProyectoSeguimiento.Equals(this.IdProyectoSeguimiento)) return false;
            if (!entity.IdProyecto.Equals(this.IdProyecto)) return false;

            return true;
        }
        
        public virtual DataTableMapping ToMapping()
        {
            return new DataTableMapping("ProyectoSeguimientoProyecto", new List<DataColumnMapping>(new DataColumnMapping[]{
		new DataColumnMapping("ProyectoSeguimiento","ProyectoSeguimiento_Denominacion")
			,new DataColumnMapping("Proyecto","Proyecto_ProyectoDenominacion")
			}));
        }
    }
}

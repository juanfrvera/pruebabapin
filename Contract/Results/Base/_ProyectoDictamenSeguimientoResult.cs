using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoDictamenSeguimientoResult : IResult<int>
    {        
        public virtual int ID{get{return IdProyectoDictamenSeguimiento;}}
         public int IdProyectoDictamenSeguimiento{get;set;}
         public int IdProyectoDictamen{get;set;}
         public int IdProyectoSeguimiento{get;set;}
		 
 
         public virtual ProyectoDictamenSeguimiento ToEntity()
         {
             ProyectoDictamenSeguimiento _ProyectoDictamenSeguimiento = new ProyectoDictamenSeguimiento();
             _ProyectoDictamenSeguimiento.IdProyectoDictamenSeguimiento = this.IdProyectoDictamenSeguimiento;
             _ProyectoDictamenSeguimiento.IdProyectoDictamen = this.IdProyectoDictamen;
             _ProyectoDictamenSeguimiento.IdProyectoSeguimiento = this.IdProyectoSeguimiento;

             return _ProyectoDictamenSeguimiento;
         }
         public virtual void Set(ProyectoDictamenSeguimiento entity)
         {
             this.IdProyectoDictamenSeguimiento = entity.IdProyectoDictamenSeguimiento;
             this.IdProyectoDictamen = entity.IdProyectoDictamen;
             this.IdProyectoSeguimiento = entity.IdProyectoSeguimiento;

         }
         public virtual bool Equals(ProyectoDictamenSeguimiento entity)
         {
             if (entity == null) return false;
             if (!entity.IdProyectoDictamenSeguimiento.Equals(this.IdProyectoDictamenSeguimiento)) return false;
             if (!entity.IdProyectoDictamen.Equals(this.IdProyectoDictamen)) return false;
             if (!entity.IdProyectoSeguimiento.Equals(this.IdProyectoSeguimiento)) return false;

             return true;
         }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoDictamenSeguimiento", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("ProyectoDictamen","ProyectoDictamen_InformeTecnico")
			,new DataColumnMapping("ProyectoSeguimiento","ProyectoSeguimiento_Denominacion")
			}));
		}
	}
}
		
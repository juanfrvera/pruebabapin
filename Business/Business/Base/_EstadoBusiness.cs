using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc=Contract;

namespace Business.Base
{
    public class _EstadoBusiness : EntityBusiness<Estado,EstadoFilter,EstadoResult,int>
    {        
		protected readonly EstadoData Data = new EstadoData();
        protected override IEntityData<Estado,EstadoFilter,EstadoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Estado() { IdEstado = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Estado entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdEstado != default(int),"InvalidField", "Estado");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 70,"FieldInvalidLength","Nombre");
DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 2,"FieldInvalidLength","Codigo");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdEstado != default(int),"InvalidField", "Estado");
                DataHelper.ValidateForeignKey(entity.Configurations.Any(), "El registro no se puede eliminar porque tiene al menos una configuración asociada", "Estado");
                DataHelper.ValidateForeignKey(entity.IndicadorEvolucions.Any(), "El registro no se puede eliminar porque tiene al menos un indicador de evolución asociado", "Estado");
                DataHelper.ValidateForeignKey(entity.Permisos.Any(), "El registro no se puede eliminar porque tiene al menos un permiso asociado", "Estado");
                DataHelper.ValidateForeignKey(entity.PrestamoDictamenEstados.Any(), "El registro no se puede eliminar porque tiene al menos un dictamen de prestamo asociado", "Estado");
                DataHelper.ValidateForeignKey(entity.PrestamoEstados.Any(), "El registro no se puede eliminar porque tiene al menos un estado de prestamo asociado", "Estado");
                DataHelper.ValidateForeignKey(entity.ProyectoCalidads.Any(), "El registro no se puede eliminar porque tiene al menos una calidad de proyecto asociada", "Estado");
                DataHelper.ValidateForeignKey(entity.ProyectoDictamenEstados.Any(), "El registro no se puede eliminar porque tiene al menos un dictamen de proyecto asociado", "Estado");
                DataHelper.ValidateForeignKey(entity.ProyectoEtapas.Any(), "El registro no se puede eliminar porque tiene al menos una etapa de proyecto asociada", "Estado");
                DataHelper.ValidateForeignKey(entity.Proyectos.Any(), "El registro no se puede eliminar porque tiene al menos un proyecto asociado", "Estado");
                DataHelper.ValidateForeignKey(entity.ProyectoSeguimientoEstados.Any(), "El registro no se puede eliminar porque tiene al menos un seguimiento de proyecto asociado", "Estado");
                DataHelper.ValidateForeignKey(entity.SistemaEntidadEstados.Any(), "El registro no se puede eliminar porque tiene al menos un sistema de entidad asociado", "Estado");    

				break;
            }
        }   
		
    }	
}

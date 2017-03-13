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
    public class _ProyectoSeguimientoEstadoBusiness : EntityBusiness<ProyectoSeguimientoEstado,ProyectoSeguimientoEstadoFilter,ProyectoSeguimientoEstadoResult,int>
    {        
		protected readonly ProyectoSeguimientoEstadoData Data = new ProyectoSeguimientoEstadoData();
        protected override IEntityData<ProyectoSeguimientoEstado,ProyectoSeguimientoEstadoFilter,ProyectoSeguimientoEstadoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoSeguimientoEstado() { IdProyectoSeguimientoEstado = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoSeguimientoEstado entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoSeguimientoEstado != default(int),"InvalidField", "ProyectoSeguimientoEstado");
DataHelper.Validate(entity.IdProyectoSeguimiento != default(int),"InvalidField", "ProyectoSeguimiento");
DataHelper.Validate(entity.IdEstado != default(int),"InvalidField", "Estado");
DataHelper.Validate(entity.IdUsuario != default(int),"InvalidField", "Usuario");

                  }				
				DataHelper.Validate(entity.IdProyectoSeguimiento != default(int),"InvalidField", "ProyectoSeguimiento");
DataHelper.Validate(entity.IdEstado != default(int),"InvalidField", "Estado");
DataHelper.Validate(entity.Fecha > new DateTime(1900,1,1) ,"InvalidField", "Fecha");
DataHelper.Validate(entity.IdUsuario != default(int),"InvalidField", "Usuario");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoSeguimientoEstado != default(int),"InvalidField", "ProyectoSeguimientoEstado");
                DataHelper.ValidateForeignKey(entity.ProyectoSeguimientos.Any(), "El registro no se puede eliminar porque tiene al menos un seguimiento asociado", "ProyectoSeguimientoEstado");

				break;
            }
        }   
		
    }	
}

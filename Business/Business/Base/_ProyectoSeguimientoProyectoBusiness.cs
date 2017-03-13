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
    public class _ProyectoSeguimientoProyectoBusiness : EntityBusiness<ProyectoSeguimientoProyecto,ProyectoSeguimientoProyectoFilter,ProyectoSeguimientoProyectoResult,int>
    {        
		protected readonly ProyectoSeguimientoProyectoData Data = new ProyectoSeguimientoProyectoData();
        protected override IEntityData<ProyectoSeguimientoProyecto,ProyectoSeguimientoProyectoFilter,ProyectoSeguimientoProyectoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoSeguimientoProyecto() { IdProyectoSeguimientoProyecto = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoSeguimientoProyecto entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoSeguimientoProyecto != default(int),"InvalidField", "ProyectoSeguimientoProyecto");
DataHelper.Validate(entity.IdProyectoSeguimiento != default(int),"InvalidField", "ProyectoSeguimiento");
DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");

                  }				
				DataHelper.Validate(entity.IdProyectoSeguimiento != default(int),"InvalidField", "ProyectoSeguimiento");
DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoSeguimientoProyecto != default(int),"InvalidField", "ProyectoSeguimientoProyecto");

				break;
            }
        }   
		
    }	
}

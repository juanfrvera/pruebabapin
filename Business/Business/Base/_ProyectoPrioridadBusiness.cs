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
    public class _ProyectoPrioridadBusiness : EntityBusiness<ProyectoPrioridad,ProyectoPrioridadFilter,ProyectoPrioridadResult,int>
    {        
		protected readonly ProyectoPrioridadData Data = new ProyectoPrioridadData();
        protected override IEntityData<ProyectoPrioridad,ProyectoPrioridadFilter,ProyectoPrioridadResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoPrioridad() { IdProyectoPrioridad = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoPrioridad entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoPrioridad != default(int),"InvalidField", "ProyectoPrioridad");
DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdPlanPeriodo != default(int),"InvalidField", "PlanPeriodo");

                  }				
				DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdPlanPeriodo != default(int),"InvalidField", "PlanPeriodo");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoPrioridad != default(int),"InvalidField", "ProyectoPrioridad");

				break;
            }
        }   
		
    }	
}

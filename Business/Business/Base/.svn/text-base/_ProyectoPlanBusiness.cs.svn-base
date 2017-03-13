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
    public class _ProyectoPlanBusiness : EntityBusiness<ProyectoPlan,ProyectoPlanFilter,ProyectoPlanResult,int>
    {        
		protected readonly ProyectoPlanData Data = new ProyectoPlanData();
        protected override IEntityData<ProyectoPlan,ProyectoPlanFilter,ProyectoPlanResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoPlan() { IdProyectoPlan = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoPlan entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoPlan != default(int),"InvalidField", "ProyectoPlan");
DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdPlanPeriodo != default(int),"InvalidField", "PlanPeriodo");
DataHelper.Validate(entity.IdPlanVersion != default(int),"InvalidField", "PlanVersion");

                  }				
				DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdPlanPeriodo != default(int),"InvalidField", "PlanPeriodo");
DataHelper.Validate(entity.IdPlanVersion != default(int),"InvalidField", "PlanVersion");
DataHelper.Validate(entity.Fecha > new DateTime(1900,1,1) ,"InvalidField", "Fecha");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoPlan != default(int),"InvalidField", "ProyectoPlan");

				break;
            }
        }   
		
    }	
}

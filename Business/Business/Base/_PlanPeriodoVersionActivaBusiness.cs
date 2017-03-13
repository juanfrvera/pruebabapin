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
    public class _PlanPeriodoVersionActivaBusiness : EntityBusiness<PlanPeriodoVersionActiva,PlanPeriodoVersionActivaFilter,PlanPeriodoVersionActivaResult,int>
    {        
		protected readonly PlanPeriodoVersionActivaData Data = new PlanPeriodoVersionActivaData();
        protected override IEntityData<PlanPeriodoVersionActiva,PlanPeriodoVersionActivaFilter,PlanPeriodoVersionActivaResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.PlanPeriodoVersionActiva() { IdPlanPeriodoVersionActiva = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.PlanPeriodoVersionActiva entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPlanPeriodoVersionActiva != default(int),"InvalidField", "PlanPeriodoVersionActiva");
DataHelper.Validate(entity.IdPlanPeriodo != default(int),"InvalidField", "PlanPeriodo");
DataHelper.Validate(entity.IdPlanVersion != default(int),"InvalidField", "PlanVersion");

                  }				
				DataHelper.Validate(entity.IdPlanPeriodo != default(int),"InvalidField", "PlanPeriodo");
DataHelper.Validate(entity.IdPlanVersion != default(int),"InvalidField", "PlanVersion");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPlanPeriodoVersionActiva != default(int),"InvalidField", "PlanPeriodoVersionActiva");

				break;
            }
        }   
		
    }	
}

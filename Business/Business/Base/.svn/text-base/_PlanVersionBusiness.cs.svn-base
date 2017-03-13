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
    public class _PlanVersionBusiness : EntityBusiness<PlanVersion,PlanVersionFilter,PlanVersionResult,int>
    {        
		protected readonly PlanVersionData Data = new PlanVersionData();
        protected override IEntityData<PlanVersion,PlanVersionFilter,PlanVersionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.PlanVersion() { IdPlanVersion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.PlanVersion entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPlanVersion != default(int),"InvalidField", "PlanVersion");
DataHelper.Validate(entity.IdPlanTipo != default(int),"InvalidField", "PlanTipo");

                  }				
				DataHelper.Validate(entity.IdPlanTipo != default(int),"InvalidField", "PlanTipo");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 100,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPlanVersion != default(int),"InvalidField", "PlanVersion");
                DataHelper.ValidateForeignKey(entity.PlanPeriodoVersionActivas.Any(), "El registro no se puede eliminar porque tiene al menos un plan de periodo asociado", "PlanVersion");
                DataHelper.ValidateForeignKey(entity.ProyectoPlans.Any(), "El registro no se puede eliminar porque tiene al menos un plan de proyecto asociado", "PlanVersion");   

				break;
            }
        }   
		
    }	
}

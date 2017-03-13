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
    public class _PlanPeriodoBusiness : EntityBusiness<PlanPeriodo,PlanPeriodoFilter,PlanPeriodoResult,int>
    {        
		protected readonly PlanPeriodoData Data = new PlanPeriodoData();
        protected override IEntityData<PlanPeriodo,PlanPeriodoFilter,PlanPeriodoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.PlanPeriodo() { IdPlanPeriodo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.PlanPeriodo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPlanPeriodo != default(int),"InvalidField", "PlanPeriodo");
DataHelper.Validate(entity.IdPlanTipo != default(int),"InvalidField", "PlanTipo");

                  }				
				DataHelper.Validate(entity.IdPlanTipo != default(int),"InvalidField", "PlanTipo");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");
DataHelper.Validate(entity.Sigla!=null,"FieldIsNull","Sigla");
DataHelper.Validate(entity.Sigla.Trim().Length <= 20,"FieldInvalidLength","Sigla");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPlanPeriodo != default(int),"InvalidField", "PlanPeriodo");
                DataHelper.ValidateForeignKey(entity.PlanPeriodoVersionActivas.Any(), "El registro no se puede eliminar porque tiene al menos una version activa asociada", "PlanPeriodo");
                DataHelper.ValidateForeignKey(entity.ProyectoDictamens.Any(), "El registro no se puede eliminar porque tiene al menos un dictamente de proyecto asociado", "PlanPeriodo");
                DataHelper.ValidateForeignKey(entity.ProyectoPlans.Any(), "El registro no se puede eliminar porque tiene al menos un plan de proyecto asociado", "PlanPeriodo");
                DataHelper.ValidateForeignKey(entity.ProyectoPrioridads.Any(), "El registro no se puede eliminar porque tiene al menos una prioridad de proyecto asociada", "PlanPeriodo");   

				break;
            }
        }   
		
    }	
}

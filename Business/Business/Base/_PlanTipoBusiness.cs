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
    public class _PlanTipoBusiness : EntityBusiness<PlanTipo,PlanTipoFilter,PlanTipoResult,int>
    {        
		protected readonly PlanTipoData Data = new PlanTipoData();
        protected override IEntityData<PlanTipo,PlanTipoFilter,PlanTipoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.PlanTipo() { IdPlanTipo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.PlanTipo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPlanTipo != default(int),"InvalidField", "PlanTipo");

                  }				
				DataHelper.Validate(entity.Sigla!=null,"FieldIsNull","Sigla");
DataHelper.Validate(entity.Sigla.Trim().Length <= 5,"FieldInvalidLength","Sigla");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPlanTipo != default(int),"InvalidField", "PlanTipo");
                DataHelper.ValidateForeignKey(entity.PlanPeriodos.Any(), "El registro no se puede eliminar porque tiene al menos un periodo de plan asociado", "PlanTipo");
                DataHelper.ValidateForeignKey(entity.PlanVersions.Any(), "El registro no se puede eliminar porque tiene al menos una version de plan asociada", "PlanTipo");   

				break;
            }
        }   
		

        
    }	
}

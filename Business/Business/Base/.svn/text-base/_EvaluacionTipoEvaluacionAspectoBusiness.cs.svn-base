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
    public class _EvaluacionTipoEvaluacionAspectoBusiness : EntityBusiness<EvaluacionTipoEvaluacionAspecto,EvaluacionTipoEvaluacionAspectoFilter,EvaluacionTipoEvaluacionAspectoResult,int>
    {        
		protected readonly EvaluacionTipoEvaluacionAspectoData Data = new EvaluacionTipoEvaluacionAspectoData();
        protected override IEntityData<EvaluacionTipoEvaluacionAspecto,EvaluacionTipoEvaluacionAspectoFilter,EvaluacionTipoEvaluacionAspectoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.EvaluacionTipoEvaluacionAspecto() { IdEvalaucionTipoEvaluacionAspecto = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.EvaluacionTipoEvaluacionAspecto entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdEvalaucionTipoEvaluacionAspecto != default(int),"InvalidField", "EvalaucionTipoEvaluacionAspecto");
DataHelper.Validate(entity.IdEvaluacionTipo != default(int),"InvalidField", "EvaluacionTipo");
DataHelper.Validate(entity.IdEvaluacionAspecto != default(int),"InvalidField", "EvaluacionAspecto");

                  }				
				DataHelper.Validate(entity.IdEvaluacionTipo != default(int),"InvalidField", "EvaluacionTipo");
DataHelper.Validate(entity.IdEvaluacionAspecto != default(int),"InvalidField", "EvaluacionAspecto");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdEvalaucionTipoEvaluacionAspecto != default(int),"InvalidField", "EvalaucionTipoEvaluacionAspecto");

				break;
            }
        }   
		
    }	
}

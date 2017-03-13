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
    public class _EvaluacionAspectoEvaluacionResultadoBusiness : EntityBusiness<EvaluacionAspectoEvaluacionResultado,EvaluacionAspectoEvaluacionResultadoFilter,EvaluacionAspectoEvaluacionResultadoResult,int>
    {        
		protected readonly EvaluacionAspectoEvaluacionResultadoData Data = new EvaluacionAspectoEvaluacionResultadoData();
        protected override IEntityData<EvaluacionAspectoEvaluacionResultado,EvaluacionAspectoEvaluacionResultadoFilter,EvaluacionAspectoEvaluacionResultadoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.EvaluacionAspectoEvaluacionResultado() { IdEvalaucionAspectoEvaluacionResultado = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.EvaluacionAspectoEvaluacionResultado entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdEvalaucionAspectoEvaluacionResultado != default(int),"InvalidField", "EvalaucionAspectoEvaluacionResultado");
DataHelper.Validate(entity.IdEvaluacionAspecto != default(int),"InvalidField", "EvaluacionAspecto");
DataHelper.Validate(entity.IdEvaluacionResultado != default(int),"InvalidField", "EvaluacionResultado");

                  }				
				DataHelper.Validate(entity.IdEvaluacionAspecto != default(int),"InvalidField", "EvaluacionAspecto");
DataHelper.Validate(entity.IdEvaluacionResultado != default(int),"InvalidField", "EvaluacionResultado");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdEvalaucionAspectoEvaluacionResultado != default(int),"InvalidField", "EvalaucionAspectoEvaluacionResultado");

				break;
            }
        }   
		
    }	
}

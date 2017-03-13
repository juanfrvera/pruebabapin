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
    public class _EvaluacionTipoBusiness : EntityBusiness<EvaluacionTipo,EvaluacionTipoFilter,EvaluacionTipoResult,int>
    {        
		protected readonly EvaluacionTipoData Data = new EvaluacionTipoData();
        protected override IEntityData<EvaluacionTipo,EvaluacionTipoFilter,EvaluacionTipoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.EvaluacionTipo() { IdEvaluacionTipo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.EvaluacionTipo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdEvaluacionTipo != default(int),"InvalidField", "EvaluacionTipo");

                  }				
				DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 1,"FieldInvalidLength","Codigo");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 30,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdEvaluacionTipo != default(int),"InvalidField", "EvaluacionTipo");
                DataHelper.ValidateForeignKey(entity.EvaluacionTipoEvaluacionAspectos.Any(), "El registro no se puede eliminar porque tiene al menos un tipo de evaluacion de aspecto asociado", "EvaluacionTipo");    

				break;
            }
        }   
		
    }	
}

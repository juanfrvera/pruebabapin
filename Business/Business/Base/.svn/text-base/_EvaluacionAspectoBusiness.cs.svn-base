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
    public class _EvaluacionAspectoBusiness : EntityBusiness<EvaluacionAspecto,EvaluacionAspectoFilter,EvaluacionAspectoResult,int>
    {        
		protected readonly EvaluacionAspectoData Data = new EvaluacionAspectoData();
        protected override IEntityData<EvaluacionAspecto,EvaluacionAspectoFilter,EvaluacionAspectoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.EvaluacionAspecto() { IdEvaluacionAspecto = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.EvaluacionAspecto entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdEvaluacionAspecto != default(int),"InvalidField", "EvaluacionAspecto");

                  }				
				DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 1,"FieldInvalidLength","Codigo");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 30,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdEvaluacionAspecto != default(int),"InvalidField", "EvaluacionAspecto");
                DataHelper.ValidateForeignKey(entity.EvaluacionAspectoEvaluacionResultados.Any(), "El registro no se puede eliminar porque tiene al menos un resultado de aspecto de evaluacion asociado", "EvaluacionAspecto");
                DataHelper.ValidateForeignKey(entity.EvaluacionTipoEvaluacionAspectos.Any(), "El registro no se puede eliminar porque tiene al menos un tipo de evaluacion asociado", "EvaluacionAspecto");    

				break;
            }
        }   
		
    }	
}

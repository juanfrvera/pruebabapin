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
    public class _EvaluacionResultadoBusiness : EntityBusiness<EvaluacionResultado,EvaluacionResultadoFilter,EvaluacionResultadoResult,int>
    {        
		protected readonly EvaluacionResultadoData Data = new EvaluacionResultadoData();
        protected override IEntityData<EvaluacionResultado,EvaluacionResultadoFilter,EvaluacionResultadoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.EvaluacionResultado() { IdEvaluacionResultado = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.EvaluacionResultado entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdEvaluacionResultado != default(int),"InvalidField", "EvaluacionResultado");

                  }				
				DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 1,"FieldInvalidLength","Codigo");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 70,"FieldInvalidLength","Nombre");
DataHelper.Validate(entity.Aspecto!=null,"FieldIsNull","Aspecto");
DataHelper.Validate(entity.Aspecto.Trim().Length <= 30,"FieldInvalidLength","Aspecto");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdEvaluacionResultado != default(int),"InvalidField", "EvaluacionResultado");
                DataHelper.ValidateForeignKey(entity.EvaluacionAspectoEvaluacionResultados.Any(), "El registro no se puede eliminar porque tiene al menos un resultado de ascpecto de evaluacion asociado", "EvaluacionResultado");    

				break;
            }
        }   
		
    }	
}

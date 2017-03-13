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
    public class _ProgramaObjetivoBusiness : EntityBusiness<ProgramaObjetivo,ProgramaObjetivoFilter,ProgramaObjetivoResult,int>
    {        
		protected readonly ProgramaObjetivoData Data = new ProgramaObjetivoData();
        protected override IEntityData<ProgramaObjetivo,ProgramaObjetivoFilter,ProgramaObjetivoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProgramaObjetivo() { IdProgramaObjetivo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProgramaObjetivo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProgramaObjetivo != default(int),"InvalidField", "ProgramaObjetivo");
DataHelper.Validate(entity.IdPrograma != default(int),"InvalidField", "Programa");
DataHelper.Validate(entity.IDObjetivo != default(int),"InvalidField", "Objetivo");

                  }				
				DataHelper.Validate(entity.IdPrograma != default(int),"InvalidField", "Programa");
DataHelper.Validate(entity.IDObjetivo != default(int),"InvalidField", "Objetivo");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProgramaObjetivo != default(int),"InvalidField", "ProgramaObjetivo");
                DataHelper.ValidateForeignKey(entity.ProyectoFins.Any(), "El registro no se puede eliminar porque tiene al menos un fin de proyecto asociado", "ProgramaObjetivo");
               
				break;
            }
        }   
		
    }	
}

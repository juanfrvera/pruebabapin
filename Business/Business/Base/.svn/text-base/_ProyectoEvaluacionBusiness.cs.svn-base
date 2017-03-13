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
    public class _ProyectoEvaluacionBusiness : EntityBusiness<ProyectoEvaluacion,ProyectoEvaluacionFilter,ProyectoEvaluacionResult,int>
    {        
		protected readonly ProyectoEvaluacionData Data = new ProyectoEvaluacionData();
        protected override IEntityData<ProyectoEvaluacion,ProyectoEvaluacionFilter,ProyectoEvaluacionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoEvaluacion() { Id_ProyectoEvaluacion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoEvaluacion entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.Id_ProyectoEvaluacion != default(int),"InvalidField", "_ProyectoEvaluacion");
DataHelper.Validate(entity.Id_Proyecto != default(int),"InvalidField", "_Proyecto");

                  }				
				DataHelper.Validate(entity.Id_Proyecto != default(int),"InvalidField", "_Proyecto");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.Id_ProyectoEvaluacion != default(int),"InvalidField", "_ProyectoEvaluacion");

				break;
            }
        }   
		
    }	
}

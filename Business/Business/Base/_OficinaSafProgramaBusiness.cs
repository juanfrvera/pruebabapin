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
    public class _OficinaSafProgramaBusiness : EntityBusiness<OficinaSafPrograma,OficinaSafProgramaFilter,OficinaSafProgramaResult,int>
    {        
		protected readonly OficinaSafProgramaData Data = new OficinaSafProgramaData();
        protected override IEntityData<OficinaSafPrograma,OficinaSafProgramaFilter,OficinaSafProgramaResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.OficinaSafPrograma() { IdOficinaSafPrograma = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.OficinaSafPrograma entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdOficinaSafPrograma != default(int),"InvalidField", "OficinaSafPrograma");
DataHelper.Validate(entity.IdOficinaSaf != default(int),"InvalidField", "OficinaSaf");
DataHelper.Validate(entity.IdPrograma != default(int),"InvalidField", "Programa");

                  }				
				DataHelper.Validate(entity.IdOficinaSaf != default(int),"InvalidField", "OficinaSaf");
DataHelper.Validate(entity.IdPrograma != default(int),"InvalidField", "Programa");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdOficinaSafPrograma != default(int),"InvalidField", "OficinaSafPrograma");

				break;
            }
        }   
		
    }	
}

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
    public class _PriorityBusiness : EntityBusiness<Priority,PriorityFilter,PriorityResult,int>
    {        
		protected readonly PriorityData Data = new PriorityData();
        protected override IEntityData<Priority,PriorityFilter,PriorityResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Priority() { IdPriority = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Priority entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPriority != default(int),"InvalidField", "Priority");

                  }				
				DataHelper.Validate(entity.Name!=null,"FieldIsNull","Name");
DataHelper.Validate(entity.Name.Trim().Length <= 50,"FieldInvalidLength","Name");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPriority != default(int),"InvalidField", "Priority");
                DataHelper.ValidateForeignKey(entity.Messages.Any(), "El registro no se puede eliminar porque tiene al menos un mensaje asociado", "Priority");
               
				break;
            }
        }   
		
    }	
}

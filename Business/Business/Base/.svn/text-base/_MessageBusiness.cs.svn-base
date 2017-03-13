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
    public class _MessageBusiness : EntityBusiness<Message,MessageFilter,MessageResult,int>
    {        
		protected readonly MessageData Data = new MessageData();
        protected override IEntityData<Message,MessageFilter,MessageResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Message() { IdMessage = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Message entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdMessage != default(int),"InvalidField", "Message");
DataHelper.Validate(entity.IdMediaFrom != default(int),"InvalidField", "MediaFrom");
DataHelper.Validate(entity.IdUserFrom != default(int),"InvalidField", "UserFrom");
DataHelper.Validate(entity.IdPriority != default(int),"InvalidField", "Priority");

                  }				
				DataHelper.Validate(entity.IdMediaFrom != default(int),"InvalidField", "MediaFrom");
DataHelper.Validate(entity.IdUserFrom != default(int),"InvalidField", "UserFrom");
DataHelper.Validate(entity.IdPriority != default(int),"InvalidField", "Priority");
DataHelper.Validate(entity.Subject!=null,"FieldIsNull","Subject");
DataHelper.Validate(entity.Subject.Trim().Length <= 500,"FieldInvalidLength","Subject");
DataHelper.Validate(entity.StartDate > new DateTime(1900,1,1) ,"InvalidField", "StartDate");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdMessage != default(int),"InvalidField", "Message");
                DataHelper.ValidateForeignKey(entity.MessageAttaches.Any(), "El mensaje no se puede eliminar porque ya fue recibido", "Message");
                DataHelper.ValidateForeignKey(entity.MessageSends.Any(), "El mensaje no se puede eliminar porque ya fue enviado", "Message");
                
				break;
            }
        }   
		
    }	
}

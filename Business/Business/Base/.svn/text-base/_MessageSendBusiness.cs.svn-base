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
    public class _MessageSendBusiness : EntityBusiness<MessageSend,MessageSendFilter,MessageSendResult,int>
    {        
		protected readonly MessageSendData Data = new MessageSendData();
        protected override IEntityData<MessageSend,MessageSendFilter,MessageSendResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.MessageSend() { IdMessageSend = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.MessageSend entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdMessageSend != default(int),"InvalidField", "MessageSend");
DataHelper.Validate(entity.IdMessage != default(int),"InvalidField", "Message");
DataHelper.Validate(entity.IdUserTo != default(int),"InvalidField", "UserTo");
DataHelper.Validate(entity.IdMediaTo != default(int),"InvalidField", "MediaTo");

                  }				
				DataHelper.Validate(entity.IdMessage != default(int),"InvalidField", "Message");
DataHelper.Validate(entity.IdUserTo != default(int),"InvalidField", "UserTo");
DataHelper.Validate(entity.IdMediaTo != default(int),"InvalidField", "MediaTo");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdMessageSend != default(int),"InvalidField", "MessageSend");

				break;
            }
        }   
		
    }	
}

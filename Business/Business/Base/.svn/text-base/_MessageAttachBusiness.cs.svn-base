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
    public class _MessageAttachBusiness : EntityBusiness<MessageAttach,MessageAttachFilter,MessageAttachResult,int>
    {        
		protected readonly MessageAttachData Data = new MessageAttachData();
        protected override IEntityData<MessageAttach,MessageAttachFilter,MessageAttachResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.MessageAttach() { IdMessageAttach = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.MessageAttach entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdMessageAttach != default(int),"InvalidField", "MessageAttach");
DataHelper.Validate(entity.IdMessage != default(int),"InvalidField", "Message");

                  }				
				DataHelper.Validate(entity.IdMessage != default(int),"InvalidField", "Message");
DataHelper.Validate(entity.FileName!=null,"FieldIsNull","FileName");
DataHelper.Validate(entity.FileName.Trim().Length <= 150,"FieldInvalidLength","FileName");
DataHelper.Validate(entity.FileType!=null,"FieldIsNull","FileType");
DataHelper.Validate(entity.FileType.Trim().Length <= 3,"FieldInvalidLength","FileType");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdMessageAttach != default(int),"InvalidField", "MessageAttach");
                    
				break;
            }
        }   
		
    }	
}

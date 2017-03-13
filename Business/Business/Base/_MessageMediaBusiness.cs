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
    public class _MessageMediaBusiness : EntityBusiness<MessageMedia,MessageMediaFilter,MessageMediaResult,int>
    {        
		protected readonly MessageMediaData Data = new MessageMediaData();
        protected override IEntityData<MessageMedia,MessageMediaFilter,MessageMediaResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.MessageMedia() { IdMessageMedia = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.MessageMedia entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdMessageMedia != default(int),"InvalidField", "MessageMedia");

                  }				
				DataHelper.Validate(entity.Name!=null,"FieldIsNull","Name");
DataHelper.Validate(entity.Name.Trim().Length <= 70,"FieldInvalidLength","Name");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdMessageMedia != default(int),"InvalidField", "MessageMedia");
                DataHelper.ValidateForeignKey(entity.Messages.Any(), "El registro no se puede eliminar porque tiene al menos un mensaje asociado", "MessageMedia");
                DataHelper.ValidateForeignKey(entity.MessageSends.Any(), "El registro no se puede eliminar porque tiene al menos un mensaje asociado", "MessageMedia");
                
				break;
            }
        }   
		
    }	
}

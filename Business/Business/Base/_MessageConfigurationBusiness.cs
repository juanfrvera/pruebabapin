using Contract;
using DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nc = Contract;

namespace Business.Base
{
    public class _MessageConfigurationBusiness : EntityBusiness<MessageConfiguration, MessageConfigurationFilter, MessageConfigurationResult, int>
    {
        protected readonly MessageConfigurationData Data = new MessageConfigurationData();

        protected override IEntityData<MessageConfiguration, MessageConfigurationFilter, MessageConfigurationResult, int> EntityData
        {
            get { return this.Data; }
        }

        public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.MessageConfiguration() { IdMessageConfiguration = id }, actionName, contextUser, args);
        }

        public override void Validate(nc.MessageConfiguration entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            base.Validate(entity, actionName, contextUser, args);
            switch (actionName)
            {
                case ActionConfig.CREATE:
                case ActionConfig.UPDATE:
                    if (actionName != ActionConfig.CREATE)
                    {
                        DataHelper.Validate(entity.IdMessageConfiguration != default(int), "InvalidField", "MessageConfiguration");

                    }
                    DataHelper.Validate(entity.Page != null, "FieldIsNull", "Page");
                    DataHelper.Validate(entity.Page.Trim().Length <= 150, "FieldInvalidLength", "Page");

                    break;
                case ActionConfig.READ:
                case ActionConfig.DELETE:
                    DataHelper.Validate(entity.IdMessageConfiguration != default(int), "InvalidField", "MessageConfiguration");
                    DataHelper.ValidateForeignKey(entity.Message.MessageAttaches.Any(), "El registro no se puede eliminar porque tiene mensajes enviados", "MessageConfiguration");
                    DataHelper.ValidateForeignKey(entity.Message.MessageSends.Any(), "El registro no se puede eliminar porque tiene mensajes enviados", "MessageConfiguration");

                    break;
            }
        }
   
    }
}

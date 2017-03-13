using Business.Base;
using Contract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class MessageConfigurationComposeBusiness : EntityComposeBusiness<MessageConfigurationCompose, MessageConfiguration, MessageConfigurationFilter, MessageConfigurationResult, int>
    {
        #region Singleton

        private static volatile MessageConfigurationComposeBusiness current;
        private static object syncRoot = new Object();

        public static MessageConfigurationComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new MessageConfigurationComposeBusiness();
                    }
                }
                return current;
            }
        }

        #endregion

        protected override EntityBusiness<MessageConfiguration, MessageConfigurationFilter, MessageConfigurationResult, int> EntityBusinessBase
        {
            get { return MessageConfigurationBusiness.Current; }
        }

        #region Gets

        public override MessageConfigurationCompose GetNew(MessageConfigurationResult example)
        {
            MessageConfigurationCompose compose = base.GetNew();
            compose.MessageConfiguration = example;
            return compose;
        }

        public override MessageConfigurationCompose GetNew()
        {
            MessageConfigurationResult example = new MessageConfigurationResult();
            MessageConfigurationBusiness.Current.Set(MessageConfigurationBusiness.Current.GetNew(), example);
            return GetNew(example);
        }

        public override int GetId(MessageConfigurationCompose entity)
        {
            return entity.MessageConfiguration.IdMessageConfiguration;
        }

        public override MessageConfigurationCompose GetById(int id)
        {
            MessageConfigurationCompose compose = new MessageConfigurationCompose();
            compose.MessageConfiguration = MessageConfigurationBusiness.Current.GetResult(new MessageConfigurationFilter() { IdMessageConfiguration = id }).FirstOrDefault();
            return compose;
        }

        #endregion

        #region Actions

        public override void Delete(MessageConfigurationCompose entity, IContextUser contextUser)
        {
            MessageConfigurationBusiness.Current.Delete(entity.MessageConfiguration.IdMessageConfiguration, contextUser);
        }

        public override void Add(MessageConfigurationCompose entity, IContextUser contextUser)
        {
            Message message = new Message();
            message.IdMediaFrom = 1;
            message.IdPriority = entity.MessageConfiguration.idPrioridad;
            message.IdUserFrom = entity.MessageConfiguration.idUserForm;
            message.IsManual = false;
            message.StartDate = DateTime.Now;
            message.Subject = entity.MessageConfiguration.Subject;
            message.Body = entity.MessageConfiguration.Message;

            MessageBusiness.Current.Add(message, contextUser);

            entity.MessageConfiguration.IdMessage = message.IdMessage;

            MessageConfigurationBusiness.Current.Add(entity.MessageConfiguration.ToEntity(), contextUser);
        }

        public override void Update(MessageConfigurationCompose entity, IContextUser contextUser)
        {

            MessageConfiguration messageConfiguration = entity.MessageConfiguration.ToEntity();
            MessageResult mensaje = MessageBusiness.Current.GetResult(new Contract.MessageFilter() { IdMessage = messageConfiguration.IdMessage }).FirstOrDefault();

            mensaje.Subject = entity.MessageConfiguration.Subject;
            mensaje.Body = entity.MessageConfiguration.Message;
            mensaje.IdPriority = entity.MessageConfiguration.idPrioridad;

            MessageBusiness.Current.Update(mensaje.ToEntity(), contextUser);
            MessageConfigurationBusiness.Current.Update(messageConfiguration, contextUser);

        }

        #endregion

        #region Validations

        public override void Validate(MessageConfigurationCompose entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            base.Validate(entity, actionName, contextUser, args);
            MessageConfigurationBusiness.Current.Validate(MessageConfigurationBusiness.Current.ToEntity(entity.MessageConfiguration), actionName, contextUser, args);
        }

        public override bool Can(MessageConfigurationCompose entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            if (entity == null || entity.MessageConfiguration == null) return false;
            return MessageConfigurationBusiness.Current.Can(MessageConfigurationBusiness.Current.ToEntity(entity.MessageConfiguration), actionName, contextUser, args);
        }

        #endregion
    }

    public class MessageConfigurationBusiness : _MessageConfigurationBusiness
    {
        #region Singleton

        private static volatile MessageConfigurationBusiness current;

        private static object syncRoot = new Object();

        public static MessageConfigurationBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new MessageConfigurationBusiness();
                    }
                }
                return current;
            }
        }

        #endregion

        public override MessageConfiguration GetNew()
        {
            MessageConfiguration entity = base.GetNew();
            return entity;
        }

        public override void Delete(MessageConfiguration entity, IContextUser contextUser)
        {
            Delete(entity.IdMessageConfiguration, contextUser);
            MessageBusiness.Current.Delete(new MessageFilter() { IdMessage = entity.IdMessage }, contextUser);
        }

        public override void Delete(int id, IContextUser contextUser)
        {
            MessageConfigurationCompose messageConfigurationCompose = MessageConfigurationComposeBusiness.Current.GetById(id);

            base.Delete(id, contextUser);
            MessageBusiness.Current.Delete(new MessageFilter() { IdMessage = messageConfigurationCompose.MessageConfiguration.IdMessage }, contextUser);

        }
    }
}

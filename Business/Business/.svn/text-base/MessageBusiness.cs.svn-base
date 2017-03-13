using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc = Contract;
using DataAccess;
using Business.Base;
using System.Collections;

namespace Business
{
    public class MessageComposeBusiness : EntityComposeBusiness<MessageCompose, Message, MessageFilter, MessageResult, int>
    {
        #region Singleton
        private static volatile MessageComposeBusiness current;
        private static object syncRoot = new Object();
        public static MessageComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new MessageComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<Message, MessageFilter, MessageResult, int> EntityBusinessBase
        {
            get { return MessageBusiness.Current; }
        }
        #region Gets
        public override MessageCompose GetNew(MessageResult example)
        {
            MessageCompose compose = base.GetNew();
            compose.Message = example;                      
            compose.MessageSends = new List<MessageSendResult>();
            return compose;
        }
        public override MessageCompose GetNew()
        {
            MessageResult example = new MessageResult();
            MessageBusiness.Current.Set(MessageBusiness.Current.GetNew(), example);  
            return GetNew(example);
        }
        public override int GetId(MessageCompose entity)
        {
            return entity.Message.IdMessage;
        }
        public override MessageCompose GetById(int id)
        {
            MessageCompose compose = new MessageCompose();
            compose.Message = MessageBusiness.Current.GetResult(new MessageFilter() { IdMessage = id }).FirstOrDefault();
            compose.MessageSends = MessageSendBusiness.Current.GetResult(new MessageSendFilter(){ IdMessage = id});
            return compose;
        }
        #endregion

        #region Actions
        public override void Add(MessageCompose entity, IContextUser contextUser)
        {
            try
            {
                if (entity.Message.Proyecto_Codigo.HasValue)
                {
                    Proyecto proyecto = ProyectoBusiness.Current.GetList(new nc.ProyectoFilter() { Codigo = entity.Message.Proyecto_Codigo.Value }).FirstOrDefault();
                    if (proyecto != null)
                    {
                        entity.Message.IdProyecto = proyecto.IdProyecto;
                    }
                }

                Message message = entity.Message.ToEntity();
                MessageBusiness.Current.Add(message, contextUser);
                entity.Message.IdMessage = message.IdMessage;

                

                foreach (MessageSendResult messageSendResult in entity.MessageSends)
                {
                    messageSendResult.IdMessage = entity.Message.IdMessage;
                    MessageSendBusiness.Current.Add(MessageSendBusiness.Current.ToEntity(messageSendResult), contextUser);
                }
            }
            catch (Exception exception)
            {
                entity.Message.IdMessage = 0;
                throw exception;
            }
        }
        public override void Update(MessageCompose entity, IContextUser contextUser)
        {
            if (entity.Message.Proyecto_Codigo.HasValue)
            {
                Proyecto proyecto = ProyectoBusiness.Current.GetList(new nc.ProyectoFilter() { Codigo = entity.Message.Proyecto_Codigo.Value }).FirstOrDefault();
                if (proyecto != null)
                {
                    entity.Message.IdProyecto = proyecto.IdProyecto;
                }
            }
            Message message = entity.Message.ToEntity();
            MessageBusiness.Current.Add(message, contextUser);
            foreach (MessageSendResult messageSendResult in entity.MessageSends)
            {
                messageSendResult.IdMessage = entity.Message.IdMessage;
                MessageSendBusiness.Current.Save(messageSendResult, contextUser);
            }

            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;
        }
        public override void Delete(MessageCompose entity, IContextUser contextUser)
        {
            MessageSendBusiness.Current.Delete(new MessageSendFilter() { IdMessage = entity.Message.IdMessage },contextUser);
            MessageBusiness.Current.Delete(entity.Message.IdMessage, contextUser);            
        }
        #endregion

        #region Validations
        public override void Validate(MessageCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            base.Validate(entity, actionName, contextUser, args);
            MessageBusiness.Current.Validate(MessageBusiness.Current.ToEntity(entity.Message), actionName, contextUser, args);
            DataHelper.Validate(entity.MessageSends.Count > 0, "FieldIsNull", "Para"); //Matias 20131204 - Tarea 95
            DataHelper.Validate((entity.Message.Proyecto_Codigo == null) ? true : ProyectoBusiness.Current.GetList(new nc.ProyectoFilter() { Codigo = entity.Message.Proyecto_Codigo }).Count() > 0, "InvalidField", "BAPIN");
        }
        public override bool Can(MessageCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return MessageBusiness.Current.Can(MessageBusiness.Current.ToEntity(entity.Message), actionName, contextUser, args);
        }
        #endregion        
    } 
    public class MessageBusiness : _MessageBusiness 
    {   
	   #region Singleton
	   private static volatile MessageBusiness current;
	   private static object syncRoot = new Object();

	   //private MessageBusiness() {}
	   public static MessageBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new MessageBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public override Message GetNew()
       { 
           Message entity=base.GetNew();
           entity.StartDate = DateTime.Now;
           entity.IdPriority = 1;
           entity.IdMediaFrom = 1;
           entity.IsManual = true;           
           return entity;
       }
    }
}

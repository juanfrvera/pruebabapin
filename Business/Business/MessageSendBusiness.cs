using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class MessageSendBusiness : _MessageSendBusiness 
    {   
	   #region Singleton
	   private static volatile MessageSendBusiness current;
	   private static object syncRoot = new Object();

	   //private MessageSendBusiness() {}
	   public static MessageSendBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new MessageSendBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public override MessageSend GetNew()
       {
           MessageSend entity = base.GetNew();
           entity.IdMediaTo = 1;
           return entity;
       }

       #region Actions

       public override void Update(MessageSend entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}

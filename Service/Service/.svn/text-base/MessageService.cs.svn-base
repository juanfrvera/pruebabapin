using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;
using System.Collections;

namespace Service
{

    public class MessageComposeService : EntityComposeService<MessageCompose, MessageFilter, MessageResult, int>
    {
        #region Singleton
        private static volatile MessageComposeService current;
        private static object syncRoot = new Object();
        public static MessageComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new MessageComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        protected readonly MessageComposeBusiness Business = new MessageComposeBusiness();
        protected override IEntityBusiness<MessageCompose, MessageFilter, MessageResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return MessageService.Current.Execute(id, actionName, contextUser, args);
        }
    }

    public class MessageService : _MessageService 
    {	  
	   #region Singleton
	   private static volatile MessageService current;
	   private static object syncRoot = new Object();

	   //private MessageService() {}
	   public static MessageService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new MessageService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

using Business;
using Contract;
using Service.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class MessageConfigurationComposeService : EntityComposeService<MessageConfigurationCompose, MessageConfigurationFilter, MessageConfigurationResult, int>
    {
        #region Singleton

        private static volatile MessageConfigurationComposeService current;
        private static object syncRoot = new Object();

        public static MessageConfigurationComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new MessageConfigurationComposeService();
                    }
                }
                return current;
            }
        }
       
        #endregion

        protected readonly MessageConfigurationComposeBusiness Business = new MessageConfigurationComposeBusiness();
        
        protected override IEntityBusiness<MessageConfigurationCompose, MessageConfigurationFilter, MessageConfigurationResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
      
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return MessageConfigurationService.Current.Execute(id, actionName, contextUser, args);
        }
    }

    public class MessageConfigurationService : _MessageConfigurationService
    {
        #region Singleton

        private static volatile MessageConfigurationService current;
        private static object syncRoot = new Object();

        public static MessageConfigurationService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new MessageConfigurationService();
                    }
                }
                return current;
            }
        }
      
        #endregion
    }
}

using DataAccess.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class MessageConfigurationData : _MessageConfigurationData
    {
        #region Singleton
        private static volatile MessageConfigurationData current;

        private static object syncRoot = new Object();

        public static MessageConfigurationData Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new MessageConfigurationData();
                    }
                }
                return current;
            }
        }

        #endregion
    }
}

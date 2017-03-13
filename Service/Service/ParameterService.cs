using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ParameterService : _ParameterService
    {
        #region Singleton
        private static volatile ParameterService current;
        private static object syncRoot = new Object();

        //private ParameterService() {}
        public static ParameterService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ParameterService();
                    }
                }
                return current;
            }
        }
        #endregion
    }
}
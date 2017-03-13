using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;

namespace Business
{
    public class SecurityBusiness
    {

        #region singleton
        private static readonly object padlock = new object();
        private static SecurityBusiness current;
        public static SecurityBusiness Current
        {
            get
            {
                if (current == null)
                    lock (padlock)
                    {
                        if (current == null)
                            current = new SecurityBusiness();
                    }
                return current;
            }
        }
        #endregion


        
    }
}

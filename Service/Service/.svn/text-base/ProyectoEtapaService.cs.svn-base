using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoEtapaService : _ProyectoEtapaService
    {
        #region Singleton
        private static volatile ProyectoEtapaService current;
        private static object syncRoot = new Object();

        //private ProyectoEtapaService() {}
        public static ProyectoEtapaService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoEtapaService();
                    }
                }
                return current;
            }
        }
        #endregion
    }
   
}
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
    public class ProyectoDictamenService : _ProyectoDictamenService 
    {	  
	   #region Singleton
	   private static volatile ProyectoDictamenService current;
	   private static object syncRoot = new Object();

	   //private ProyectoDictamenService() {}
	   public static ProyectoDictamenService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoDictamenService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }

    public class DictamenComposeService : EntityComposeService<DictamenCompose, ProyectoDictamenFilter, ProyectoDictamenResult, int>
    {
        #region Singleton
        private static volatile DictamenComposeService current;
        private static object syncRoot = new Object();

        //private SolicitudService() {}
        public static DictamenComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new DictamenComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "DictamenComposeService"; } }

        protected readonly DictamenComposeBusiness Business = DictamenComposeBusiness.Current;
        protected override IEntityBusiness<DictamenCompose, ProyectoDictamenFilter, ProyectoDictamenResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return ProyectoDictamenService.Current.Execute(id, actionName, contextUser, args);
        }
    }

}

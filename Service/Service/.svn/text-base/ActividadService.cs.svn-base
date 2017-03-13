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
    public class ActividadComposeService : EntityComposeService<ActividadCompose, ActividadFilter, ActividadResult, int>
    {
        #region Singleton
        private static volatile ActividadComposeService current;
        private static object syncRoot = new Object();
        public static ActividadComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ActividadComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        protected readonly ActividadComposeBusiness Business = new ActividadComposeBusiness();
        protected override IEntityBusiness<ActividadCompose, ActividadFilter, ActividadResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return ActividadService.Current.Execute(id, actionName, contextUser, args);
        }
    }

    public class ActividadService : _ActividadService 
    {	  
	   #region Singleton
	   private static volatile ActividadService current;
	   private static object syncRoot = new Object();

	   //private ActividadService() {}
	   public static ActividadService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ActividadService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

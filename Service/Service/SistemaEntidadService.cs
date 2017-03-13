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
    public class SistemaEntidadComposeService : EntityComposeService<SistemaEntidadCompose, SistemaEntidadFilter, SistemaEntidadResult, int>
    {
        #region Singleton
        private static volatile SistemaEntidadComposeService current;
        private static object syncRoot = new Object();
        public static SistemaEntidadComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new SistemaEntidadComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        protected readonly SistemaEntidadComposeBusiness Business = new SistemaEntidadComposeBusiness();
        protected override IEntityBusiness<SistemaEntidadCompose, SistemaEntidadFilter, SistemaEntidadResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return SistemaEntidadService.Current.Execute(id, actionName, contextUser, args);
        }
    }
    public class SistemaEntidadService : _SistemaEntidadService 
    {	  
	   #region Singleton
	   private static volatile SistemaEntidadService current;
	   private static object syncRoot = new Object();

	   //private SistemaEntidadService() {}
	   public static SistemaEntidadService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SistemaEntidadService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

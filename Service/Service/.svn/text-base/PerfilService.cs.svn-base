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
    public class PerfilComposeService : EntityComposeService<PerfilCompose, PerfilFilter, PerfilResult, int>
    {
        #region Singleton
        private static volatile PerfilComposeService current;
        private static object syncRoot = new Object();
        public static PerfilComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PerfilComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        protected readonly PerfilComposeBusiness Business = new PerfilComposeBusiness();
        protected override IEntityBusiness<PerfilCompose, PerfilFilter, PerfilResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return PerfilService.Current.Execute(id, actionName, contextUser, args);
        }
    }


    public class PerfilService : _PerfilService 
    {	  
	   #region Singleton
	   private static volatile PerfilService current;
	   private static object syncRoot = new Object();

	   //private PerfilService() {}
	   public static PerfilService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PerfilService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

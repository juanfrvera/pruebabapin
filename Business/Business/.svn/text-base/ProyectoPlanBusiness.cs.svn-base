using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoPlanBusiness : _ProyectoPlanBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoPlanBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoPlanBusiness() {}
	   public static ProyectoPlanBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoPlanBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       internal Int32? GetIdTipoPlan(Int32 IdProyecto)
       {
           return ProyectoPlanData.Current.GetIdTipoPlan(IdProyecto);
       }

       #region Actions

       public override void Update(ProyectoPlan entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoIndicadorPriorizacionBusiness : _ProyectoIndicadorPriorizacionBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoIndicadorPriorizacionBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoIndicadorPriorizacionBusiness() {}
	   public static ProyectoIndicadorPriorizacionBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoIndicadorPriorizacionBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(ProyectoIndicadorPriorizacion entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}

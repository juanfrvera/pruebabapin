using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class PrestamoObjetivoEspecificoBusiness : _PrestamoObjetivoEspecificoBusiness 
    {   
	   #region Singleton
	   private static volatile PrestamoObjetivoEspecificoBusiness current;
	   private static object syncRoot = new Object();

	   //private PrestamoObjetivoEspecificoBusiness() {}
	   public static PrestamoObjetivoEspecificoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoObjetivoEspecificoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion


       #region Actions

       public override void Update(PrestamoObjetivoEspecifico entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}

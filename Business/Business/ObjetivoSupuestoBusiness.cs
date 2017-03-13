using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ObjetivoSupuestoBusiness : _ObjetivoSupuestoBusiness 
    {   
	   #region Singleton
	   private static volatile ObjetivoSupuestoBusiness current;
	   private static object syncRoot = new Object();

	   //private ObjetivoSupuestoBusiness() {}
	   public static ObjetivoSupuestoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ObjetivoSupuestoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(ObjetivoSupuesto entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}

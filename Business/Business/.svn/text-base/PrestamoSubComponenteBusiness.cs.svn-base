using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class PrestamoSubComponenteBusiness : _PrestamoSubComponenteBusiness 
    {   
	   #region Singleton
	   private static volatile PrestamoSubComponenteBusiness current;
	   private static object syncRoot = new Object();

	   //private PrestamoSubComponenteBusiness() {}
	   public static PrestamoSubComponenteBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoSubComponenteBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       internal List<PrestamoSubComponenteResult> GetResultByPrestamoId(int id)
       {
           return PrestamoSubComponenteData.Current.GetResultByPrestamoId(id);
       }

       internal List<PrestamoSubComponente> GetByPrestamoId(int id)
       {
           return PrestamoSubComponenteData.Current.GetByPrestamoId(id);
       }


       #region Actions

       public override void Update(PrestamoSubComponente entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}

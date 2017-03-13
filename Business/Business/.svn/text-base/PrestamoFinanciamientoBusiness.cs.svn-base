using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class PrestamoFinanciamientoBusiness : _PrestamoFinanciamientoBusiness 
    {   
	   #region Singleton
	   private static volatile PrestamoFinanciamientoBusiness current;
	   private static object syncRoot = new Object();

	   //private PrestamoFinanciamientoBusiness() {}
	   public static PrestamoFinanciamientoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoFinanciamientoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       internal List<PrestamoFinanciamientoResult> GetResultByPrestamoId(int id)
       {
           return PrestamoFinanciamientoData.Current.GetResultByPrestamoId(id);
       }

       internal List<PrestamoFinanciamiento> GetByPrestamoId(int id)
       {
           return PrestamoFinanciamientoData.Current.GetByPrestamoId(id);
       }


       #region Actions

       public override void Update(PrestamoFinanciamiento entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}

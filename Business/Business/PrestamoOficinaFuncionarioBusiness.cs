using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class PrestamoOficinaFuncionarioBusiness : _PrestamoOficinaFuncionarioBusiness 
    {   
	   #region Singleton
	   private static volatile PrestamoOficinaFuncionarioBusiness current;
	   private static object syncRoot = new Object();

	   //private PrestamoOficinaFuncionarioBusiness() {}
	   public static PrestamoOficinaFuncionarioBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoOficinaFuncionarioBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion


       #region Actions

       public override void Update(PrestamoOficinaFuncionario entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}

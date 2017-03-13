using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class IndicadorRelacionRubroBusiness : _IndicadorRelacionRubroBusiness 
    {   
	   #region Singleton
	   private static volatile IndicadorRelacionRubroBusiness current;
	   private static object syncRoot = new Object();

	   //private IndicadorRelacionRubroBusiness() {}
	   public static IndicadorRelacionRubroBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorRelacionRubroBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(IndicadorRelacionRubro entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}

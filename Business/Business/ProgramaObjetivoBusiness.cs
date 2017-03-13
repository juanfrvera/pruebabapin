using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProgramaObjetivoBusiness : _ProgramaObjetivoBusiness 
    {   
	   #region Singleton
	   private static volatile ProgramaObjetivoBusiness current;
	   private static object syncRoot = new Object();

	   //private ProgramaObjetivoBusiness() {}
	   public static ProgramaObjetivoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProgramaObjetivoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion


       #region Actions

       public override void Update(ProgramaObjetivo entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}

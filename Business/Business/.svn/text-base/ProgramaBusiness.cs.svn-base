using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProgramaBusiness : _ProgramaBusiness 
    {   
	   #region Singleton
	   private static volatile ProgramaBusiness current;
	   private static object syncRoot = new Object();

	   //private ProgramaBusiness() {}
	   public static ProgramaBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProgramaBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion        

       public virtual ProgramaResult GetResultById(int id)
       {
           return GetResult(new ProgramaFilter() { IdPrograma = id }).FirstOrDefault();
       }


       #region Actions

       public override void Update(Programa entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion

    }
}

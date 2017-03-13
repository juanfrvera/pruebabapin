using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class OficinaSafProgramaBusiness : _OficinaSafProgramaBusiness 
    {   
	   #region Singleton
	   private static volatile OficinaSafProgramaBusiness current;
	   private static object syncRoot = new Object();

	   //private OficinaSafProgramaBusiness() {}
	   public static OficinaSafProgramaBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new OficinaSafProgramaBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion


       #region Actions

       public override void Update(OficinaSafPrograma entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}

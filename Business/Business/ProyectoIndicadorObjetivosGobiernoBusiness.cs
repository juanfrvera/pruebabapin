using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoIndicadorObjetivosGobiernoBusiness : _ProyectoIndicadorObjetivosGobiernoBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoIndicadorObjetivosGobiernoBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoIndicadorObjetivosGobiernoBusiness() {}
	   public static ProyectoIndicadorObjetivosGobiernoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoIndicadorObjetivosGobiernoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(ProyectoIndicadorObjetivosGobierno entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}

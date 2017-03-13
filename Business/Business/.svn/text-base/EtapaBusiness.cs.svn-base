using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class EtapaBusiness : _EtapaBusiness 
    {   
	   #region Singleton
	   private static volatile EtapaBusiness current;
	   private static object syncRoot = new Object();

	   //private EtapaBusiness() {}
	   public static EtapaBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EtapaBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override Etapa GetNew()
       {
           Etapa entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }

       #region Actions

       public override void Update(Etapa entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}

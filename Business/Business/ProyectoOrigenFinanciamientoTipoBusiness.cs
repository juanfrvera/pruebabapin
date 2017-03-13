using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoOrigenFinanciamientoTipoBusiness : _ProyectoOrigenFinanciamientoTipoBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoOrigenFinanciamientoTipoBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoOrigenFinanciamientoTipoBusiness() {}
	   public static ProyectoOrigenFinanciamientoTipoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoOrigenFinanciamientoTipoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(ProyectoOrigenFinanciamientoTipo entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}

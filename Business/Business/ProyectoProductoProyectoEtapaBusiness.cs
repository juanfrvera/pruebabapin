using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoProductoProyectoEtapaBusiness : _ProyectoProductoProyectoEtapaBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoProductoProyectoEtapaBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoProductoProyectoEtapaBusiness() {}
	   public static ProyectoProductoProyectoEtapaBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoProductoProyectoEtapaBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(ProyectoProductoProyectoEtapa entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}

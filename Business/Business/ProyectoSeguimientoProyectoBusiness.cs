using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoSeguimientoProyectoBusiness : _ProyectoSeguimientoProyectoBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoSeguimientoProyectoBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoSeguimientoProyectoBusiness() {}
	   public static ProyectoSeguimientoProyectoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoSeguimientoProyectoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public List<ProyectoSeguimientoProyectoResult> ProyectoSeguimientoConProvincias(ProyectoSeguimientoProyectoFilter filter)
       {
           return ProyectoSeguimientoProyectoData.Current.ProyectoSeguimientoConProvincias(filter);
       }

       #region Actions

       public override void Update(ProyectoSeguimientoProyecto entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}

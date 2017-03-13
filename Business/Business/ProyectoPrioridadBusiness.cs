using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoPrioridadBusiness : _ProyectoPrioridadBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoPrioridadBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoPrioridadBusiness() {}
	   public static ProyectoPrioridadBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoPrioridadBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       internal ProyectoPrioridadResult GetUltimaPrioridad(Int32 idProyecto)
       {
           return ProyectoPrioridadData.Current.GetUltimaPrioridad(idProyecto);
       }
       public decimal CalcularPuntaje(Int32 idProyecto)
       {
           return ProyectoPrioridadData.Current.CalcularPuntaje(idProyecto);
       }

       #region Actions

       public override void Update(ProyectoPrioridad entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}

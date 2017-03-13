using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoPrioridadService : _ProyectoPrioridadService 
    {	  
	   #region Singleton
	   private static volatile ProyectoPrioridadService current;
	   private static object syncRoot = new Object();

	   //private ProyectoPrioridadService() {}
	   public static ProyectoPrioridadService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoPrioridadService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public decimal CalcularPuntaje(Int32 idProyecto)
       {
           return ProyectoPrioridadBusiness.Current.CalcularPuntaje(idProyecto);
       }
    }
}

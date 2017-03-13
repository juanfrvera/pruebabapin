using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoCalidadService : _ProyectoCalidadService 
    {	  
	   #region Singleton
	   private static volatile ProyectoCalidadService current;
	   private static object syncRoot = new Object();

	   //private ProyectoCalidadService() {}
	   public static ProyectoCalidadService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoCalidadService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public ListPaged<ProyectoCalidadResult> GetListadoExtendido(ProyectoCalidadFilter proyectoCalidadFilter)
       {
           return ProyectoCalidadBusiness.Current.GetListadoExtendido(proyectoCalidadFilter);
       }
    }
}

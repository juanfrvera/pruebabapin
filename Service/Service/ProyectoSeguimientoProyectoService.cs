using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoSeguimientoProyectoService : _ProyectoSeguimientoProyectoService 
    {	  
	   #region Singleton
	   private static volatile ProyectoSeguimientoProyectoService current;
	   private static object syncRoot = new Object();

	   //private ProyectoSeguimientoProyectoService() {}
	   public static ProyectoSeguimientoProyectoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoSeguimientoProyectoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public List<ProyectoSeguimientoProyectoResult> ProyectoSeguimientoConProvincias(ProyectoSeguimientoProyectoFilter filter)
       {
           return ProyectoSeguimientoProyectoBusiness.Current.ProyectoSeguimientoConProvincias(filter);
       }
    }
}

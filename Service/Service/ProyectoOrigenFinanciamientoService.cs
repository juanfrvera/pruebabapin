using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoOrigenFinanciamientoService : _ProyectoOrigenFinanciamientoService 
    {	  
	   #region Singleton
	   private static volatile ProyectoOrigenFinanciamientoService current;
	   private static object syncRoot = new Object();

	   //private ProyectoOrigenFinanciamientoService() {}
	   public static ProyectoOrigenFinanciamientoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoOrigenFinanciamientoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public List<ProyectoOrigenFinanciamientoResult> GetOrigenes(ProyectoOrigenFinanciamientoFilter filter)
       {
           return ProyectoOrigenFinanciamientoBusiness.Current.GetOrigenes(filter);
       }
    }
}
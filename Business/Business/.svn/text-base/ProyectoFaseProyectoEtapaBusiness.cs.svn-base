using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoFaseProyectoEtapaBusiness : _ProyectoFaseProyectoEtapaBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoFaseProyectoEtapaBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoFaseProyectoEtapaBusiness() {}
	   public static ProyectoFaseProyectoEtapaBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoFaseProyectoEtapaBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoIndicadorObjetivosGobiernoService : _ProyectoIndicadorObjetivosGobiernoService 
    {	  
	   #region Singleton
	   private static volatile ProyectoIndicadorObjetivosGobiernoService current;
	   private static object syncRoot = new Object();

	   //private ProyectoIndicadorObjetivosGobiernoService() {}
	   public static ProyectoIndicadorObjetivosGobiernoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoIndicadorObjetivosGobiernoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

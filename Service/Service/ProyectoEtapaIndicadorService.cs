using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoEtapaIndicadorService : _ProyectoEtapaIndicadorService 
    {	  
	   #region Singleton
	   private static volatile ProyectoEtapaIndicadorService current;
	   private static object syncRoot = new Object();

	   //private ProyectoEtapaIndicadorService() {}
	   public static ProyectoEtapaIndicadorService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoEtapaIndicadorService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

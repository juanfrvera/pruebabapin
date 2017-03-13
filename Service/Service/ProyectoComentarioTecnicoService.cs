using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoComentarioTecnicoService : _ProyectoComentarioTecnicoService 
    {	  
	   #region Singleton
	   private static volatile ProyectoComentarioTecnicoService current;
	   private static object syncRoot = new Object();

	   //private ProyectoComentarioTecnicoService() {}
	   public static ProyectoComentarioTecnicoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoComentarioTecnicoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

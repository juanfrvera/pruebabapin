using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ComentarioTecnicoService : _ComentarioTecnicoService 
    {	  
	   #region Singleton
	   private static volatile ComentarioTecnicoService current;
	   private static object syncRoot = new Object();

	   //private ComentarioTecnicoService() {}
	   public static ComentarioTecnicoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ComentarioTecnicoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ClasificacionGeograficaService : _ClasificacionGeograficaService 
    {	  
	   #region Singleton
	   private static volatile ClasificacionGeograficaService current;
	   private static object syncRoot = new Object();

	   //private ClasificacionGeograficaService() {}
	   public static ClasificacionGeograficaService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ClasificacionGeograficaService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public ListPaged<NodeResult> GetNodesResult(ClasificacionGeograficaFilter filter)
       {
           return Business.GetNodesResult(filter);
       }
    }
}

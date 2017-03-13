using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class FuenteFinanciamientoService : _FuenteFinanciamientoService 
    {	  
	   #region Singleton
	   private static volatile FuenteFinanciamientoService current;
	   private static object syncRoot = new Object();

	   //private FuenteFinanciamientoService() {}
	   public static FuenteFinanciamientoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new FuenteFinanciamientoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public ListPaged<NodeResult> GetNodesResult(FuenteFinanciamientoFilter filter)
       {
           return Business.GetNodesResult(filter);
       }
    }
}

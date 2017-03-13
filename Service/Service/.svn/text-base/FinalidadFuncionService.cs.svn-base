using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class FinalidadFuncionService : _FinalidadFuncionService 
    {	  
	   #region Singleton
	   private static volatile FinalidadFuncionService current;
	   private static object syncRoot = new Object();

	   //private FinalidadFuncionService() {}
	   public static FinalidadFuncionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new FinalidadFuncionService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public ListPaged<NodeResult> GetNodesResult(FinalidadFuncionFilter filter)
       {
           return Business.GetNodesResult(filter);
       }    
    }
}

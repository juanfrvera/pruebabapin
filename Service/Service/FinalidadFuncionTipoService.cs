using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class FinalidadFuncionTipoService : _FinalidadFuncionTipoService 
    {	  
	   #region Singleton
	   private static volatile FinalidadFuncionTipoService current;
	   private static object syncRoot = new Object();

	   //private FinalidadFuncionTipoService() {}
	   public static FinalidadFuncionTipoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new FinalidadFuncionTipoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

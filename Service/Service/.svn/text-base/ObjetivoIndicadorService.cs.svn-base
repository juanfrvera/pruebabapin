using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ObjetivoIndicadorService : _ObjetivoIndicadorService 
    {	  
	   #region Singleton
	   private static volatile ObjetivoIndicadorService current;
	   private static object syncRoot = new Object();

	   //private ObjetivoIndicadorService() {}
	   public static ObjetivoIndicadorService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ObjetivoIndicadorService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

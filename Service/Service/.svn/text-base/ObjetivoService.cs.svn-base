using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ObjetivoService : _ObjetivoService 
    {	  
	   #region Singleton
	   private static volatile ObjetivoService current;
	   private static object syncRoot = new Object();

	   //private ObjetivoService() {}
	   public static ObjetivoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ObjetivoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }

 
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class IndicadorRubroService : _IndicadorRubroService 
    {	  
	   #region Singleton
	   private static volatile IndicadorRubroService current;
	   private static object syncRoot = new Object();

	   //private IndicadorRubroService() {}
	   public static IndicadorRubroService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorRubroService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

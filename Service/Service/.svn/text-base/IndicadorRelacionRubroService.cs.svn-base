using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class IndicadorRelacionRubroService : _IndicadorRelacionRubroService 
    {	  
	   #region Singleton
	   private static volatile IndicadorRelacionRubroService current;
	   private static object syncRoot = new Object();

	   //private IndicadorRelacionRubroService() {}
	   public static IndicadorRelacionRubroService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorRelacionRubroService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

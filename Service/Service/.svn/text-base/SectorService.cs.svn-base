using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class SectorService : _SectorService 
    {	  
	   #region Singleton
	   private static volatile SectorService current;
	   private static object syncRoot = new Object();

	   //private SectorService() {}
	   public static SectorService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SectorService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class SubJurisdiccionService : _SubJurisdiccionService 
    {	  
	   #region Singleton
	   private static volatile SubJurisdiccionService current;
	   private static object syncRoot = new Object();

	   //private SubJurisdiccionService() {}
	   public static SubJurisdiccionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SubJurisdiccionService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

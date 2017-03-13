using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class JurisdiccionService : _JurisdiccionService 
    {	  
	   #region Singleton
	   private static volatile JurisdiccionService current;
	   private static object syncRoot = new Object();

	   //private JurisdiccionService() {}
	   public static JurisdiccionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new JurisdiccionService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

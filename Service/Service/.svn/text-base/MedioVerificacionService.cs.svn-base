using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class MedioVerificacionService : _MedioVerificacionService 
    {	  
	   #region Singleton
	   private static volatile MedioVerificacionService current;
	   private static object syncRoot = new Object();

	   //private MedioVerificacionService() {}
	   public static MedioVerificacionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new MedioVerificacionService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

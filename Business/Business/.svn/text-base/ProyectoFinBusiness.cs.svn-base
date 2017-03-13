using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoFinBusiness : _ProyectoFinBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoFinBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoFinBusiness() {}
	   public static ProyectoFinBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoFinBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

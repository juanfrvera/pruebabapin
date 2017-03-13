using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class SubProcesoBusiness : _SubProcesoBusiness 
    {   
	   #region Singleton
	   private static volatile SubProcesoBusiness current;
	   private static object syncRoot = new Object();

	   //private SubProcesoBusiness() {}
	   public static SubProcesoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SubProcesoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

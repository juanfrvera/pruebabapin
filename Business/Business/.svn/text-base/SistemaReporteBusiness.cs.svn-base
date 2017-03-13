using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class SistemaReporteBusiness : _SistemaReporteBusiness 
    {   
	   #region Singleton
	   private static volatile SistemaReporteBusiness current;
	   private static object syncRoot = new Object();

	   //private SistemaReporteBusiness() {}
	   public static SistemaReporteBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SistemaReporteBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

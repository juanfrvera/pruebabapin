using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class AuditOperationBusiness : _AuditOperationBusiness 
    {   
	   #region Singleton
	   private static volatile AuditOperationBusiness current;
	   private static object syncRoot = new Object();

	   //private AuditOperationBusiness() {}
	   public static AuditOperationBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new AuditOperationBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class AuditOperationDetailBusiness : _AuditOperationDetailBusiness 
    {   
	   #region Singleton
	   private static volatile AuditOperationDetailBusiness current;
	   private static object syncRoot = new Object();

	   //private AuditOperationDetailBusiness() {}
	   public static AuditOperationDetailBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new AuditOperationDetailBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

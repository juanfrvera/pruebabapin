using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class AuditSessionBusiness : _AuditSessionBusiness 
    {   
	   #region Singleton
	   private static volatile AuditSessionBusiness current;
	   private static object syncRoot = new Object();

	   //private AuditSessionBusiness() {}
	   public static AuditSessionBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new AuditSessionBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

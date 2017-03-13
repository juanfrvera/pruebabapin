using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class AuditOperationDetailService : _AuditOperationDetailService 
    {	  
	   #region Singleton
	   private static volatile AuditOperationDetailService current;
	   private static object syncRoot = new Object();

	   //private AuditOperationDetailService() {}
	   public static AuditOperationDetailService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new AuditOperationDetailService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public override EntityServiceBehaviour Behaviour
       {
           get
           {
               return new EntityServiceBehaviour() { Audit = false };
           }
       }
    }
}

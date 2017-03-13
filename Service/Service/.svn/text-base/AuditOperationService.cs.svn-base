using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class AuditOperationService : _AuditOperationService 
    {	  
	   #region Singleton
	   private static volatile AuditOperationService current;
	   private static object syncRoot = new Object();

	   //private AuditOperationService() {}
	   public static AuditOperationService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new AuditOperationService();
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

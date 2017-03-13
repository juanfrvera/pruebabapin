using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class AuditSessionService : _AuditSessionService 
    {	  
	   #region Singleton
	   private static volatile AuditSessionService current;
	   private static object syncRoot = new Object();

	   //private AuditSessionService() {}
	   public static AuditSessionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new AuditSessionService();
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

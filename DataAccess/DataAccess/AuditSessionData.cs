using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class AuditSessionData : _AuditSessionData
    {
	   #region Singleton
	   private static volatile AuditSessionData current;
	   private static object syncRoot = new Object();

	   //private AuditSessionData() {}
	   public static AuditSessionData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new AuditSessionData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdAuditSession"; } } 
    }
}

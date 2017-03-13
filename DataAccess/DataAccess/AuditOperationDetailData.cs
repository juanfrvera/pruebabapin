using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class AuditOperationDetailData : _AuditOperationDetailData 
    {
	   #region Singleton
	   private static volatile AuditOperationDetailData current;
	   private static object syncRoot = new Object();

	   //private AuditOperationDetailData() {}
	   public static AuditOperationDetailData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new AuditOperationDetailData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdAuditOperationDetail"; } }  
    }
}

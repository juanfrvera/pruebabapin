using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class EtapaData : _EtapaData
    {
	   #region Singleton
	   private static volatile EtapaData current;
	   private static object syncRoot = new Object();

	   //private EtapaData() {}
	   public static EtapaData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EtapaData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdEtapa"; } }  
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class GeoreferenciacionData : _GeoreferenciacionData
    {
	   #region Singleton
	   private static volatile GeoreferenciacionData current;
	   private static object syncRoot = new Object();

	   //private GeoreferenciacionData() {}
	   public static GeoreferenciacionData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new GeoreferenciacionData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdGeoreferenciacion"; } }   
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ActividadData : _ActividadData 
    {
	   #region Singleton
	   private static volatile ActividadData current;
	   private static object syncRoot = new Object();

	   //private ActividadData() {}
	   public static ActividadData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ActividadData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdActividad"; } }
    }
}

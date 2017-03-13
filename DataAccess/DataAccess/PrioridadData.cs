using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PrioridadData : _PrioridadData 
    { 
	   #region Singleton
	   private static volatile PrioridadData current;
	   private static object syncRoot = new Object();

	   //private PrioridadData() {}
	   public static PrioridadData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrioridadData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPrioridad"; } } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PriorityData : _PriorityData 
    {
	   #region Singleton
	   private static volatile PriorityData current;
	   private static object syncRoot = new Object();

	   //private PriorityData() {}
	   public static PriorityData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PriorityData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPriority"; } }
    }
}

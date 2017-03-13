using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ObjetivoData : _ObjetivoData 
    {    
	   #region Singleton
	   private static volatile ObjetivoData current;
	   private static object syncRoot = new Object();

	   //private ObjetivoData() {}
	   public static ObjetivoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ObjetivoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdObjetivo"; } }  
    }

}

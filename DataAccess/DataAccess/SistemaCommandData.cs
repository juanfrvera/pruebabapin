using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class SistemaCommandData : _SistemaCommandData 
    { 
	   #region Singleton
	   private static volatile SistemaCommandData current;
	   private static object syncRoot = new Object();

	   //private SistemaCommandData() {}
	   public static SistemaCommandData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SistemaCommandData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdSistemaCommand"; } } 
    }
}

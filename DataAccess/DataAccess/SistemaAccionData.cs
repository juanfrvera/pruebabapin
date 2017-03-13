using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class SistemaAccionData : _SistemaAccionData
    {
	   #region Singleton
	   private static volatile SistemaAccionData current;
	   private static object syncRoot = new Object();

	   //private SistemaAccionData() {}
	   public static SistemaAccionData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SistemaAccionData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdSistemaAccion"; } } 
    }
}

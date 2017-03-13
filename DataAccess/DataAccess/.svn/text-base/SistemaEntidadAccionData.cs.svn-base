using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class SistemaEntidadAccionData : _SistemaEntidadAccionData 
    { 
	   #region Singleton
	   private static volatile SistemaEntidadAccionData current;
	   private static object syncRoot = new Object();

	   //private SistemaEntidadAccionData() {}
	   public static SistemaEntidadAccionData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SistemaEntidadAccionData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdSistemaEntidadAccion"; } } 
    }
}

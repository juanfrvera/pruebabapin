using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class SistemaEntidadData : _SistemaEntidadData 
    { 
	   #region Singleton
	   private static volatile SistemaEntidadData current;
	   private static object syncRoot = new Object();

	   //private SistemaEntidadData() {}
	   public static SistemaEntidadData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SistemaEntidadData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdSistemaEntidad"; } } 

       #region Store Procedures       
       public void RefreshPermisosPorEntidad()
       {
           RefreshPermisosPorEntidad(null);
       }
       public void RefreshPermisosPorEntidad(int? idEntidad)
       {
           LinqUtility.Context.RefreshPermisosPorEntidad(null);
       }
       #endregion
    }
}

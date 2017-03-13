using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ClasificacionGastoTipoData : _ClasificacionGastoTipoData 
    {   
	   #region Singleton
	   private static volatile ClasificacionGastoTipoData current;
	   private static object syncRoot = new Object();

	   //private ClasificacionGastoTipoData() {}
	   public static ClasificacionGastoTipoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ClasificacionGastoTipoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdClasificacionGastoTipo"; } } 
    }
}

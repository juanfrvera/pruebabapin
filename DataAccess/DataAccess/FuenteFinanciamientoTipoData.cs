using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class FuenteFinanciamientoTipoData : _FuenteFinanciamientoTipoData
    {
	   #region Singleton
	   private static volatile FuenteFinanciamientoTipoData current;
	   private static object syncRoot = new Object();

	   //private FuenteFinanciamientoTipoData() {}
	   public static FuenteFinanciamientoTipoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new FuenteFinanciamientoTipoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdFuenteFinanciamientoTipo"; } }  
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ClasificacionGeograficaTipoData : _ClasificacionGeograficaTipoData 
    {
	   #region Singleton
	   private static volatile ClasificacionGeograficaTipoData current;
	   private static object syncRoot = new Object();

	   //private ClasificacionGeograficaTipoData() {}
	   public static ClasificacionGeograficaTipoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ClasificacionGeograficaTipoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdClasificacionGeograficaTipo"; } } 
    }
}

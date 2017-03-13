using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ClasificacionGastoRubroData : _ClasificacionGastoRubroData
    {
	   #region Singleton
	   private static volatile ClasificacionGastoRubroData current;
	   private static object syncRoot = new Object();

	   //private ClasificacionGastoRubroData() {}
	   public static ClasificacionGastoRubroData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ClasificacionGastoRubroData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdClasificacionGastoRubro"; } }   
    }
}

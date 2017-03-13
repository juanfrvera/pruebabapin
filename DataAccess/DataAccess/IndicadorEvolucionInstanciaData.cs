using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class IndicadorEvolucionInstanciaData : _IndicadorEvolucionInstanciaData 
    {
	   #region Singleton
	   private static volatile IndicadorEvolucionInstanciaData current;
	   private static object syncRoot = new Object();

	   //private IndicadorEvolucionInstanciaData() {}
	   public static IndicadorEvolucionInstanciaData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorEvolucionInstanciaData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdIndicadorEvolucionInstancia"; } } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class IndicadorMedioVerificacionData : _IndicadorMedioVerificacionData 
    {
	   #region Singleton
	   private static volatile IndicadorMedioVerificacionData current;
	   private static object syncRoot = new Object();

	   //private IndicadorMedioVerificacionData() {}
	   public static IndicadorMedioVerificacionData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorMedioVerificacionData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdIndicadorMedioVerificacion"; } }  
    }
}

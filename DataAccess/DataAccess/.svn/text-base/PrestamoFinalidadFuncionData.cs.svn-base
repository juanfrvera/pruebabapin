using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PrestamoFinalidadFuncionData : _PrestamoFinalidadFuncionData 
    { 
	   #region Singleton
	   private static volatile PrestamoFinalidadFuncionData current;
	   private static object syncRoot = new Object();

	   //private PrestamoFinalidadFuncionData() {}
	   public static PrestamoFinalidadFuncionData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoFinalidadFuncionData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPrestamoFinalidadFuncion"; } } 
    }
}

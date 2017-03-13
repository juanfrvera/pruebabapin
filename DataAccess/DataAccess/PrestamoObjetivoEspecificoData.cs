using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PrestamoObjetivoEspecificoData : _PrestamoObjetivoEspecificoData 
    { 
	   #region Singleton
	   private static volatile PrestamoObjetivoEspecificoData current;
	   private static object syncRoot = new Object();

	   //private PrestamoObjetivoEspecificoData() {}
	   public static PrestamoObjetivoEspecificoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoObjetivoEspecificoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPrestamoObjetivoEspecifico"; } } 
    }
}

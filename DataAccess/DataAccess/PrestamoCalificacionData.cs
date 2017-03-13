using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PrestamoCalificacionData : _PrestamoCalificacionData
    {
        #region Singleton
	   private static volatile PrestamoCalificacionData current;
	   private static object syncRoot = new Object();

	   //private PrestamoCalificacionData() {}
	   public static PrestamoCalificacionData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoCalificacionData();
				}
			 }
			 return current;
		  }
	   }
        #endregion
       public override string IdFieldName { get { return "IdPrestamoCalificacion"; } }
    }
}

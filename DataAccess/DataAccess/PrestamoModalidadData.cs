using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PrestamoModalidadData : _PrestamoModalidadData
    {
	   #region Singleton
	   private static volatile PrestamoModalidadData current;
	   private static object syncRoot = new Object();

	   //private PrestamoModalidadData() {}
	   public static PrestamoModalidadData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoModalidadData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPrestamoModalidad"; } } 
    }
}

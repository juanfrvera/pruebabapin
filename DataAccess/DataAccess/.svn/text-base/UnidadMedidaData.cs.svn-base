using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class UnidadMedidaData : _UnidadMedidaData 
    { 
	   #region Singleton
	   private static volatile UnidadMedidaData current;
	   private static object syncRoot = new Object();

	   //private UnidadMedidaData() {}
	   public static UnidadMedidaData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new UnidadMedidaData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdUnidadMedida"; } }
    }
}

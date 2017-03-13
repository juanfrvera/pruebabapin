using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class TransferenciaDetalleData : _TransferenciaDetalleData 
    { 
	   #region Singleton
	   private static volatile TransferenciaDetalleData current;
	   private static object syncRoot = new Object();

	   //private TransferenciaDetalleData() {}
	   public static TransferenciaDetalleData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new TransferenciaDetalleData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdTransferenciaDetalle"; } }
    }
}

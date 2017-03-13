using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class EstadoDeDesicionData : _EstadoDeDesicionData
    {
	   #region Singleton
	   private static volatile EstadoDeDesicionData current;
	   private static object syncRoot = new Object();

	   //private EstadoDeDesicionData() {}
	   public static EstadoDeDesicionData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EstadoDeDesicionData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdEstadoDeDesicion"; } }
    }
}

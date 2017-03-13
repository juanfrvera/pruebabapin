using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class EstadoTipoData : _EstadoTipoData 
    { 
	   #region Singleton
	   private static volatile EstadoTipoData current;
	   private static object syncRoot = new Object();

	   //private EstadoTipoData() {}
	   public static EstadoTipoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EstadoTipoData();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

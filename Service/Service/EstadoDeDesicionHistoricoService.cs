using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class EstadoDeDesicionHistoricoService : _EstadoDeDesicionHistoricoService 
    {	  
	   #region Singleton
	   private static volatile EstadoDeDesicionHistoricoService current;
	   private static object syncRoot = new Object();

	   //private EstadoDeDesicionHistoricoService() {}
	   public static EstadoDeDesicionHistoricoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EstadoDeDesicionHistoricoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

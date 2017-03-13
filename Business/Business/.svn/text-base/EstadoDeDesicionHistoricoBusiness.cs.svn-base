using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class EstadoDeDesicionHistoricoBusiness : _EstadoDeDesicionHistoricoBusiness 
    {   
	   #region Singleton
	   private static volatile EstadoDeDesicionHistoricoBusiness current;
	   private static object syncRoot = new Object();

	   //private EstadoDeDesicionHistoricoBusiness() {}
	   public static EstadoDeDesicionHistoricoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EstadoDeDesicionHistoricoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

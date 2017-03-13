using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class EstadoTipoBusiness : _EstadoTipoBusiness 
    {   
	   #region Singleton
	   private static volatile EstadoTipoBusiness current;
	   private static object syncRoot = new Object();

	   //private EstadoTipoBusiness() {}
	   public static EstadoTipoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EstadoTipoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

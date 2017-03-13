using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ModalidadFinancieraService : _ModalidadFinancieraService 
    {	  
	   #region Singleton
	   private static volatile ModalidadFinancieraService current;
	   private static object syncRoot = new Object();

	   //private ModalidadFinancieraService() {}
	   public static ModalidadFinancieraService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ModalidadFinancieraService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

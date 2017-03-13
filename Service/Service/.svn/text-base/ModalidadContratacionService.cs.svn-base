using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ModalidadContratacionService : _ModalidadContratacionService 
    {	  
	   #region Singleton
	   private static volatile ModalidadContratacionService current;
	   private static object syncRoot = new Object();

	   //private ModalidadContratacionService() {}
	   public static ModalidadContratacionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ModalidadContratacionService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

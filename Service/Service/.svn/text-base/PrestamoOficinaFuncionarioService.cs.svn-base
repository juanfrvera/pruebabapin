using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class PrestamoOficinaFuncionarioService : _PrestamoOficinaFuncionarioService 
    {	  
	   #region Singleton
	   private static volatile PrestamoOficinaFuncionarioService current;
	   private static object syncRoot = new Object();

	   //private PrestamoOficinaFuncionarioService() {}
	   public static PrestamoOficinaFuncionarioService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoOficinaFuncionarioService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

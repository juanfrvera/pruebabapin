using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoOficinaPerfilFuncionarioService : _ProyectoOficinaPerfilFuncionarioService 
    {	  
	   #region Singleton
	   private static volatile ProyectoOficinaPerfilFuncionarioService current;
	   private static object syncRoot = new Object();

	   //private ProyectoOficinaPerfilFuncionarioService() {}
	   public static ProyectoOficinaPerfilFuncionarioService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoOficinaPerfilFuncionarioService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

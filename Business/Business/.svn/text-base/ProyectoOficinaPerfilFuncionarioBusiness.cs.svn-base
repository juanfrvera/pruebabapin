using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoOficinaPerfilFuncionarioBusiness : _ProyectoOficinaPerfilFuncionarioBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoOficinaPerfilFuncionarioBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoOficinaPerfilFuncionarioBusiness() {}
	   public static ProyectoOficinaPerfilFuncionarioBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoOficinaPerfilFuncionarioBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

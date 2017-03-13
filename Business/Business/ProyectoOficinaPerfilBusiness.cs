using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoOficinaPerfilBusiness : _ProyectoOficinaPerfilBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoOficinaPerfilBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoOficinaPerfilBusiness() {}
	   public static ProyectoOficinaPerfilBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoOficinaPerfilBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public List<Int32> GetIdFuncionariosProyectos(ProyectoOficinaPerfilFilter filter)
       {
           return ProyectoOficinaPerfilData.Current.GetIdFuncionariosProyectos(filter);
       }
    }
}

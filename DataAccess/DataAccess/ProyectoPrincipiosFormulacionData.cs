using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoPrincipiosFormulacionData : _ProyectoPrincipiosFormulacionData 
    { 
	   #region Singleton
	   private static volatile ProyectoPrincipiosFormulacionData current;
	   private static object syncRoot = new Object();

	   //private ProyectoPrincipiosFormulacionData() {}
	   public static ProyectoPrincipiosFormulacionData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoPrincipiosFormulacionData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoPrincipiosFormulacion"; } }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class PermisoService : _PermisoService 
    {	  
	   #region Singleton
	   private static volatile PermisoService current;
	   private static object syncRoot = new Object();

	   //private PermisoService() {}
	   public static PermisoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PermisoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public List<PermisoSimpleResult> GetSimpleResult(PermisoPerfilFilter filter)
       {
           return Business.GetSimpleResult(filter);
       } 
    }
}

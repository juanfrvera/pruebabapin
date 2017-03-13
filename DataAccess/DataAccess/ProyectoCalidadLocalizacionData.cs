using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoCalidadLocalizacionData : _ProyectoCalidadLocalizacionData 
    {
	   #region Singleton
	   private static volatile ProyectoCalidadLocalizacionData current;
	   private static object syncRoot = new Object();

	   //private ProyectoCalidadLocalizacionData() {}
	   public static ProyectoCalidadLocalizacionData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoCalidadLocalizacionData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoCalidadLocalizacion"; } }
    }
}

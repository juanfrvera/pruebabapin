using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoCalificacionData : _ProyectoCalificacionData 
    {
	   #region Singleton
	   private static volatile ProyectoCalificacionData current;
	   private static object syncRoot = new Object();

	   //private ProyectoCalificacionData() {}
	   public static ProyectoCalificacionData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoCalificacionData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoCalificacion"; } }
    }
}

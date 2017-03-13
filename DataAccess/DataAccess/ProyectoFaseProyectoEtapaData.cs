using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoFaseProyectoEtapaData : _ProyectoFaseProyectoEtapaData 
    { 
	   #region Singleton
	   private static volatile ProyectoFaseProyectoEtapaData current;
	   private static object syncRoot = new Object();

	   //private ProyectoFaseProyectoEtapaData() {}
	   public static ProyectoFaseProyectoEtapaData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoFaseProyectoEtapaData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoFaseProyectoEtapa"; } }
    }
}

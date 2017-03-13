using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoOrigenFinanciamientoTipoData : _ProyectoOrigenFinanciamientoTipoData 
    { 
	   #region Singleton
	   private static volatile ProyectoOrigenFinanciamientoTipoData current;
	   private static object syncRoot = new Object();

	   //private ProyectoOrigenFinanciamientoTipoData() {}
	   public static ProyectoOrigenFinanciamientoTipoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoOrigenFinanciamientoTipoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoOrigenFinanciamientoTipo"; } }
    }
}

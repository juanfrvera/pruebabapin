using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoTipoData : _ProyectoTipoData 
    { 
	   #region Singleton
	   private static volatile ProyectoTipoData current;
	   private static object syncRoot = new Object();

	   //private ProyectoTipoData() {}
	   public static ProyectoTipoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoTipoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoTipo"; } } 
    }
}

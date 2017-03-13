using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoRelacionTipoData : _ProyectoRelacionTipoData 
    { 
	   #region Singleton
	   private static volatile ProyectoRelacionTipoData current;
	   private static object syncRoot = new Object();

	   //private ProyectoRelacionTipoData() {}
	   public static ProyectoRelacionTipoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoRelacionTipoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoRelacionTipo"; } }
    }
}

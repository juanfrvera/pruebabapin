using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProcesoTipoData : _ProcesoTipoData 
    {
	   #region Singleton
	   private static volatile ProcesoTipoData current;
	   private static object syncRoot = new Object();

	   //private ProcesoTipoData() {}
	   public static ProcesoTipoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProcesoTipoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProcesoTipo"; } }
    }
}

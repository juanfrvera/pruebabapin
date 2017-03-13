using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProcesoData : _ProcesoData 
    {
	   #region Singleton
	   private static volatile ProcesoData current;
	   private static object syncRoot = new Object();

	   //private ProcesoData() {}
	   public static ProcesoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProcesoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProceso"; } }
    }
}

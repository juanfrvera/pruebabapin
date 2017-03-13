using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoProductoData : _ProyectoProductoData 
    { 
	   #region Singleton
	   private static volatile ProyectoProductoData current;
	   private static object syncRoot = new Object();

	   //private ProyectoProductoData() {}
	   public static ProyectoProductoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoProductoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoProducto"; } }


    }

}

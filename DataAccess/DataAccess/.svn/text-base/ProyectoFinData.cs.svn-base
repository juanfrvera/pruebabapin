using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoFinData : _ProyectoFinData 
    { 
	   #region Singleton
	   private static volatile ProyectoFinData current;
	   private static object syncRoot = new Object();

	   //private ProyectoFinData() {}
	   public static ProyectoFinData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoFinData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoFin"; } }
    }
}

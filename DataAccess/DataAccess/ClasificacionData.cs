using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ClasificacionData : _ClasificacionData 
    {
	   #region Singleton
	   private static volatile ClasificacionData current;
	   private static object syncRoot = new Object();

	   //private ClasificacionData() {}
	   public static ClasificacionData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ClasificacionData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdClasificacion"; } }   
    }
}

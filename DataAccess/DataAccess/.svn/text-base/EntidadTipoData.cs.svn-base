using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class EntidadTipoData : _EntidadTipoData 
    {  
	   #region Singleton
	   private static volatile EntidadTipoData current;
	   private static object syncRoot = new Object();

	   //private EntidadTipoData() {}
	   public static EntidadTipoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EntidadTipoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdEntidadTipo"; } }
    }
}

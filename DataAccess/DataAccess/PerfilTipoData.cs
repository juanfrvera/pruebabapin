using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PerfilTipoData : _PerfilTipoData 
    { 
	   #region Singleton
	   private static volatile PerfilTipoData current;
	   private static object syncRoot = new Object();

	   //private PerfilTipoData() {}
	   public static PerfilTipoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PerfilTipoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPerfilTipo"; } }
    }
}

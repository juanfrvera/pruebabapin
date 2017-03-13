using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class AdministracionTipoData : _AdministracionTipoData 
    {
	   #region Singleton
	   private static volatile AdministracionTipoData current;
	   private static object syncRoot = new Object();

	   //private AdministracionTipoData() {}
	   public static AdministracionTipoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new AdministracionTipoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdAdministracionTipo"; } }
    }
}

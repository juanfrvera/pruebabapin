using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class GestionTipoData : _GestionTipoData
    {
	   #region Singleton
	   private static volatile GestionTipoData current;
	   private static object syncRoot = new Object();

	   //private GestionTipoData() {}
	   public static GestionTipoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new GestionTipoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdGestionTipo"; } }  
    }
}

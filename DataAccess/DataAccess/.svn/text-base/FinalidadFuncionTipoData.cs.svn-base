using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class FinalidadFuncionTipoData : _FinalidadFuncionTipoData
    {
       public override string IdFieldName { get { return "IdFinalidadFuncionTipo"; } }   
	   #region Singleton
	   private static volatile FinalidadFuncionTipoData current;
	   private static object syncRoot = new Object();

	   //private FinalidadFuncionTipoData() {}
	   public static FinalidadFuncionTipoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new FinalidadFuncionTipoData();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

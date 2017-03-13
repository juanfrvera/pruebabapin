using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class IndicadorTipoData : _IndicadorTipoData
    {
	   #region Singleton
	   private static volatile IndicadorTipoData current;
	   private static object syncRoot = new Object();

	   //private IndicadorTipoData() {}
	   public static IndicadorTipoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorTipoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdIndicadorTipo"; } }   
    }
}

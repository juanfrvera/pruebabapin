using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class SistemaReporteData : _SistemaReporteData 
    {
	   #region Singleton
	   private static volatile SistemaReporteData current;
	   private static object syncRoot = new Object();

	   //private SistemaReporteData() {}
	   public static SistemaReporteData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SistemaReporteData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdSistemaReporte"; } } 
    }
}

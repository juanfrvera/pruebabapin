using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class SistemaReporteHistoricoData : _SistemaReporteHistoricoData 
    { 
	   #region Singleton
	   private static volatile SistemaReporteHistoricoData current;
	   private static object syncRoot = new Object();

	   //private SistemaReporteHistoricoData() {}
	   public static SistemaReporteHistoricoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SistemaReporteHistoricoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdSistemaReporteHistorico"; } }
    }
}

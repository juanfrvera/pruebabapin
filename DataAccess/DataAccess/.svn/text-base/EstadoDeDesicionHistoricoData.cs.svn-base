using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class EstadoDeDesicionHistoricoData : _EstadoDeDesicionHistoricoData
    {
	   #region Singleton
	   private static volatile EstadoDeDesicionHistoricoData current;
	   private static object syncRoot = new Object();

	   //private EstadoDeDesicionHistoricoData() {}
	   public static EstadoDeDesicionHistoricoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EstadoDeDesicionHistoricoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdEstadoDeDesicionHistorico"; } } 
    }
}

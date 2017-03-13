using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class EvaluacionTipoData : _EvaluacionTipoData
    {
	   #region Singleton
	   private static volatile EvaluacionTipoData current;
	   private static object syncRoot = new Object();

	   //private EvaluacionTipoData() {}
	   public static EvaluacionTipoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EvaluacionTipoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdEvaluacionTipo"; } }
    }
}

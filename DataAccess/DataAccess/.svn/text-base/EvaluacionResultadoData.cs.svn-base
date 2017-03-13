using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class EvaluacionResultadoData : _EvaluacionResultadoData
    {  
	   #region Singleton
	   private static volatile EvaluacionResultadoData current;
	   private static object syncRoot = new Object();

	   //private EvaluacionResultadoData() {}
	   public static EvaluacionResultadoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EvaluacionResultadoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdEvaluacionResultado"; } }
    }
}

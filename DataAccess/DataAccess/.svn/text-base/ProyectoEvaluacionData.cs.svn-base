using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoEvaluacionData : _ProyectoEvaluacionData 
    { 
	   #region Singleton
	   private static volatile ProyectoEvaluacionData current;
	   private static object syncRoot = new Object();

	   //private ProyectoEvaluacionData() {}
	   public static ProyectoEvaluacionData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoEvaluacionData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoEvaluacion"; } }
    }
}

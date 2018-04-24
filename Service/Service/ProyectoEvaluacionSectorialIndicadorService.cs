using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoEvaluacionSectorialIndicadorService : _ProyectoEvaluacionSectorialIndicadorService 
    {	  
	   #region Singleton
	   private static volatile ProyectoEvaluacionSectorialIndicadorService current;
	   private static object syncRoot = new Object();

	   //private ProyectoEvaluacionSectorialIndicadorService() {}
	   public static ProyectoEvaluacionSectorialIndicadorService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoEvaluacionSectorialIndicadorService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}

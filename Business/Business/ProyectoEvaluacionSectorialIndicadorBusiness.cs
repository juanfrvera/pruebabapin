using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoEvaluacionSectorialIndicadorBusiness : _ProyectoEvaluacionSectorialIndicadorBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoEvaluacionSectorialIndicadorBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoEvaluacionSectorialIndicadorBusiness() {}
	   public static ProyectoEvaluacionSectorialIndicadorBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoEvaluacionSectorialIndicadorBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion


       #region Actions

       public override void Update(ProyectoEvaluacionSectorialIndicador entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}

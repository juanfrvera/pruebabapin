using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoEtapaInformacionPresupuestariaPeriodoBusiness : _ProyectoEtapaInformacionPresupuestariaPeriodoBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoEtapaInformacionPresupuestariaPeriodoBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoEtapaInformacionPresupuestariaPeriodoBusiness() {}
	   public static ProyectoEtapaInformacionPresupuestariaPeriodoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoEtapaInformacionPresupuestariaPeriodoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(ProyectoEtapaInformacionPresupuestariaPeriodo entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoBeneficioIndicadorBusiness : _ProyectoBeneficioIndicadorBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoBeneficioIndicadorBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoBeneficioIndicadorBusiness() {}
	   public static ProyectoBeneficioIndicadorBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoBeneficioIndicadorBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion


       #region Actions

       public override void Update(ProyectoBeneficioIndicador entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}

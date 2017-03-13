using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoBeneficiarioIndicadorBusiness : _ProyectoBeneficiarioIndicadorBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoBeneficiarioIndicadorBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoBeneficiarioIndicadorBusiness() {}
	   public static ProyectoBeneficiarioIndicadorBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoBeneficiarioIndicadorBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion


       #region Actions

       public override void Update(ProyectoBeneficiarioIndicador entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}

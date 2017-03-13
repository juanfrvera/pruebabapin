using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoEtapaIndicadorBusiness : _ProyectoEtapaIndicadorBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoEtapaIndicadorBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoEtapaIndicadorBusiness() {}
	   public static ProyectoEtapaIndicadorBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoEtapaIndicadorBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       internal List<ProyectoEtapaIndicador> GetByIdProyecto(int IdProyecto)
       {
           return ProyectoEtapaIndicadorData.Current.GetByIdProyecto(IdProyecto);
       }

       #region Actions

       public override void Update(ProyectoEtapaIndicador entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}

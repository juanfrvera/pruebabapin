using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class PlanTipoBusiness : _PlanTipoBusiness 
    {   
	   #region Singleton
	   private static volatile PlanTipoBusiness current;
	   private static object syncRoot = new Object();

	   //private PlanTipoBusiness() {}
	   public static PlanTipoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PlanTipoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override PlanTipo GetNew()
       {
           PlanTipo entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }

       //Matias 20170210 - Ticket #REQ653581
       public ListPaged<PlanTipo> GetPlanTipoPlanesActivosResult(PlanTipoFilter filter)
       {
           ListPaged<PlanTipo> result = new ListPaged<PlanTipo>(PlanTipoData.Current.QueryResultPlanesActivos(filter));
           return result;
       }
       //FinMatias 20170210 - Ticket #REQ653581

       #region Actions

       public override void Update(PlanTipo entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}

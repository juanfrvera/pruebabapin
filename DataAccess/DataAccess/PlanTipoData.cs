using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PlanTipoData : _PlanTipoData 
    { 
	   #region Singleton
	   private static volatile PlanTipoData current;
	   private static object syncRoot = new Object();

	   //private PlanTipoData() {}
	   public static PlanTipoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PlanTipoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPlanTipo"; } }

       //Matias 20170210 - Ticket #REQ653581
       public IQueryable<PlanTipo> QueryResultPlanesActivos(PlanTipoFilter filter)
       {
           IQueryable<PlanTipo> query = (from o in Query(filter)
                   join t1 in this.Context.PlanPeriodos on o.IdPlanTipo equals t1.IdPlanTipo
                   join t2 in this.Context.PlanPeriodoVersionActivas on t1.IdPlanPeriodo equals t2.IdPlanPeriodo
                   select o
                   ).AsQueryable();

           //List<PlanTipo> query = (from o in Query(filter)
           //                              join t1 in this.Context.PlanPeriodos on o.IdPlanTipo equals t1.IdPlanTipo
           //                              join t2 in this.Context.PlanPeriodoVersionActivas on t1.IdPlanPeriodo equals t2.IdPlanPeriodo
           //                              group o by new { Id = o.IdPlanTipo, Sigla = o.Sigla, Nombre = o.Nombre, Orden = o.Orden, Activo = o.Activo } into groupQuery
           //                              select new PlanTipo
           //                              {
           //                                  IdPlanTipo = groupQuery.Key.Id,
           //                                  Sigla = groupQuery.Key.Sigla,
           //                                  Nombre = groupQuery.Key.Nombre,
           //                                  Orden = groupQuery.Key.Orden,
           //                                  Activo = groupQuery.Key.Activo,
           //                              }
           //        ).ToList();

           //return query.Distinct(); 
           return query.Distinct();
       }
        //FinMatias 20170210 - Ticket #REQ653581
    }
}

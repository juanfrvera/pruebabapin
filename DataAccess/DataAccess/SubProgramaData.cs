using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class SubProgramaData : _SubProgramaData 
    { 
	   #region Singleton
	   private static volatile SubProgramaData current;
	   private static object syncRoot = new Object();

	   //private SubProgramaData() {}
	   public static SubProgramaData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SubProgramaData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdSubPrograma"; } }

       public List<Int32> IdsSubProgramasPermitidosPorProyecto(SubProgramaFilter filter)
       {
           var query =
               (
                 from p in this.Context.Proyectos
                 join sp in this.Context.SubProgramas on p.IdSubPrograma equals sp.IdSubPrograma
                 where
                (
                    filter.IdsOficinaByUsuario == null
                    || filter.IdsOficinaByUsuario.Count == 0
                    || (
                            from pop in this.Context.ProyectoOficinaPerfils
                            where filter.IdsOficinaByUsuario.Contains(pop.IdOficina)
                            select pop.IdProyecto
                        ).Contains(p.IdProyecto))
                 select sp.IdSubPrograma

            ).Distinct().AsQueryable();
           return query.ToList();
       }

       #region Query
       protected override IQueryable<SubPrograma> Query(SubProgramaFilter filter)
       {
           return (from o in base.Query (filter)
                   where (filter.IdsOficinaByUsuario == null || filter.IdsOficinaByUsuario.Count == 0 ||
                       IdsSubProgramasPermitidosPorProyecto(filter).Contains(o.IdSubPrograma))
                   select o
                   ).AsQueryable();
       }
       #endregion
    }
}

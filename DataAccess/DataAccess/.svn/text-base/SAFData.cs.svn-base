using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class SafData : _SafData 
    { 
	   #region Singleton
	   private static volatile SafData current;
	   private static object syncRoot = new Object();

	   //private SafData() {}
	   public static SafData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SafData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdSaf"; } } 

       #region

       public List<Int32> IdsSafPermitidasPorProyecto(SafFilter filter)
       {
           var query =
               (
                 from p in this.Context.Proyectos
                 join sp in this.Context.SubProgramas on p.IdSubPrograma equals sp.IdSubPrograma
                 join pr in this.Context.Programas on sp.IdPrograma equals pr.IdPrograma
                 join s in this.Context.Safs on pr.IdSAF equals s.IdSaf
                 where
                (
                    filter.IdsOficinaByUsuario == null
                    || filter.IdsOficinaByUsuario.Count == 0
                    || (
                            from pop in this.Context.ProyectoOficinaPerfils
                            where filter.IdsOficinaByUsuario.Contains(pop.IdOficina)
                            select pop.IdProyecto
                        ).Contains(p.IdProyecto))
                 select s.IdSaf

            ).Distinct().AsQueryable();
           return query.ToList();
       }

       protected override IQueryable<Saf> Query(SafFilter filter)
       {
           if (filter.IdUsusario == null) { filter.IdUsusario = 0; }           
           if (filter.IdUsuarioOficinasRelacionadasProyecto == null) filter.IdUsuarioOficinasRelacionadasProyecto = 0;
           if (filter.IdSectorialistaPrograma == null) filter.IdSectorialistaPrograma = 0;

           var query = (from o in base.Query(filter)
                   where
                    //(filter.IdUsusario == null || filter.IdUsusario == 0 ||
                    //    (from os in this.Context.OficinaSafs
                    //     join pe in this.Context.Personas on os.IdOficina equals pe.IdOficina
                    //     join u in this.Context.Usuarios on pe.IdPersona equals u.IdUsuario  
                    //     where (pe.IdPersona == (int)filter.IdUsusario ) 
                    //     select os.IdSaf).Contains(o.IdSaf))
                    //&& (
                    //    filter.IdUsuarioOficinasRelacionadasProyecto == null || filter.IdUsuarioOficinasRelacionadasProyecto == 0 ||
                    //    (
                    //         from os in this.Context.OficinaSafs
                    //         where OficinaData.Current.GetIdsOficinaPorUsuario(filter.IdUsuarioOficinasRelacionadasProyecto.Value).Contains(os.IdOficina)
                    //         select os.IdSaf).Contains(o.IdSaf)
                    //    )
                   (filter.IdSectorialistaPrograma == null || filter.IdSectorialistaPrograma == 0 ||
                        (from os in this.Context.Programas
                         where os.IdSectorialista == (int)filter.IdSectorialistaPrograma
                         select os.IdSAF).Contains(o.IdSaf))
                    &&
                    (filter.IdsOficinaByUsuario == null || filter.IdsOficinaByUsuario.Count == 0 ||
                       IdsSafPermitidasPorProyecto(filter).Contains(o.IdSaf ))
                   select o
                   );


           if (filter.IdUsusario != null && filter.IdUsusario != 0)
           {
               query = QueryUsuarioSaf(query, (int)filter.IdUsusario);
           }
           return query.AsQueryable();

       }
       public IQueryable<Saf> QueryUsuarioSaf(IQueryable<Saf> safs, int IdUsuarioSaf)
       {
           var q = (from o in safs
                    join os in this.Context.OficinaSafs on o.IdSaf equals os.IdSaf
                    join pe in this.Context.Personas on os.IdOficina equals pe.IdOficina
                    where pe.IdPersona == IdUsuarioSaf
                    select o
                    );

           return q.AsQueryable();
       }

       public override ListPaged<SimpleResult<int>> GetSimpleList(SafFilter filter)
       {
           return ListPaged<SimpleResult<int>>((from o in QueryResult(filter) select new SimpleResult<int> { ID = o.IdSaf , Text = String.Format ("{0}-{1}", o.Codigo, o.Denominacion)  }).AsQueryable(), filter);
       }
       #endregion
    }
}

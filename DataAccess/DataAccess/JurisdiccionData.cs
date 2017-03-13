using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class JurisdiccionData : _JurisdiccionData 
    {
	   #region Singleton
	   private static volatile JurisdiccionData current;
	   private static object syncRoot = new Object();

	   //private JurisdiccionData() {}
	   public static JurisdiccionData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new JurisdiccionData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdJurisdiccion"; } }   

       public List<Int32> IdsJurisdiccionPermitidasPorProyecto(JurisdiccionFilter filter)
       {
           var query =
               (
                 from p in this.Context.Proyectos
                 join sp in this.Context.SubProgramas on p.IdSubPrograma equals sp.IdSubPrograma
                 join pr in this.Context.Programas on sp.IdPrograma equals pr.IdPrograma
                 join s in this.Context.Safs on pr.IdSAF equals s.IdSaf
                 join j in this.Context.Jurisdiccions on s.IdJurisdiccion equals j.IdJurisdiccion
                 where
                (
                    filter.IdsOficinaByUsuario == null
                    || filter.IdsOficinaByUsuario.Count == 0
                    || (
                            from pop in this.Context.ProyectoOficinaPerfils
                            where filter.IdsOficinaByUsuario.Contains(pop.IdOficina)
                            select pop.IdProyecto
                        ).Contains(p.IdProyecto))
                 select j.IdJurisdiccion

            ).Distinct ().AsQueryable ();
           return query.ToList();
       }



       #region Query
       protected override IQueryable<Jurisdiccion> Query(JurisdiccionFilter filter)
       {

           var a = (from o in base.Query(filter)
                    where (filter.IdsOficinaByUsuario == null || filter.IdsOficinaByUsuario.Count == 0 ||
                         IdsJurisdiccionPermitidasPorProyecto(filter).Contains ( o.IdJurisdiccion))
                    select o
                   );

           if (filter.IdUsuarioSaf != null && filter.IdUsuarioSaf != 0)
           {
               a = QueryUsuarioSaf(a, (int)filter.IdUsuarioSaf);
           }
           return a.AsQueryable();
       }

       public IQueryable<Jurisdiccion> QueryUsuarioSaf(IQueryable<Jurisdiccion> jurisdiccion, int IdUsuarioSaf)
       {
           var q = (from o in jurisdiccion
                    join s in this.Context.Safs on o.IdJurisdiccion equals s.IdJurisdiccion 
                    join os in this.Context.OficinaSafs on s.IdSaf  equals os.IdSaf
                    join pe in this.Context.Personas on os.IdOficina equals pe.IdOficina
                    where pe.IdPersona == IdUsuarioSaf
                    select o
                    );

           return q.AsQueryable();
       }


       #endregion
    }
}

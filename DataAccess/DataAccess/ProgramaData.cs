using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProgramaData : _ProgramaData 
    {
	   #region Singleton
	   private static volatile ProgramaData current;
	   private static object syncRoot = new Object();

	   //private ProgramaData() {}
	   public static ProgramaData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProgramaData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPrograma"; } }

       public List<Int32> IdsProgramasPermitidosPorProyecto(ProgramaFilter filter)
       {
           var query =
               (
                 from p in this.Context.Proyectos
                 join sp in this.Context.SubProgramas on p.IdSubPrograma equals sp.IdSubPrograma
                 join pr in this.Context.Programas on sp.IdPrograma equals pr.IdPrograma
                 where
                (
                    filter.IdsOficinaByUsuario == null
                    || filter.IdsOficinaByUsuario.Count == 0
                    || (
                            from pop in this.Context.ProyectoOficinaPerfils
                            where filter.IdsOficinaByUsuario.Contains(pop.IdOficina)
                            select pop.IdProyecto
                        ).Contains(p.IdProyecto))
                 select pr.IdPrograma

            ).Distinct().AsQueryable();
           return query.ToList();
       }

       #region Query
       protected override IQueryable<Programa> Query(ProgramaFilter filter)
       {
           
           var a = (from o in base.Query(filter)
                   where (filter.IdOficina == null || filter.IdOficina == 0 || (from os in this.Context.OficinaSafs where os.IdOficina == filter.IdOficina select os.IdSaf).Contains(o.IdSAF))
                   && ( filter.IdSubPrograma == null || filter.IdSubPrograma == 0 || (from sp in this.Context.SubProgramas where sp.IdSubPrograma == filter.IdSubPrograma select sp.IdPrograma).Contains(o.IdPrograma))
                   &&
                    (filter.IdsOficinaByUsuario == null || filter.IdsOficinaByUsuario.Count == 0 ||
                       IdsProgramasPermitidosPorProyecto(filter).Contains(o.IdPrograma))
                    select o
                   );

           if (filter.IdUsuarioSaf != null && filter.IdUsuarioSaf != 0)
           {
               a = QueryUsuarioSaf(a, (int)filter.IdUsuarioSaf);
           }
           return a.AsQueryable();
       }

       public IQueryable<Programa> QueryUsuarioSaf(IQueryable<Programa> programas, int IdUsuarioSaf)
       {
           var q = (from o in programas
                    join osp in this.Context.OficinaSafProgramas on o.IdPrograma equals osp.IdPrograma
                    join os in this.Context.OficinaSafs on osp.IdOficinaSaf equals os.IdOficinaSaf
                    join pe in this.Context.Personas on os.IdOficina equals pe.IdOficina
                    where pe.IdPersona == IdUsuarioSaf
                    select o
                    );

           return q.AsQueryable();
       }
        protected override IQueryable<ProgramaResult> QueryResult(ProgramaFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Safs on o.IdSAF equals t1.IdSaf   
				   join _t2  in this.Context.Usuarios on o.IdSectorialista equals _t2.IdUsuario into tt2 from t2 in tt2.DefaultIfEmpty()
                   join _t3  in this.Context.Personas on  t2.IdUsuario equals _t3.IdPersona into tt3 from t3 in tt3.DefaultIfEmpty()
				   select new ProgramaResult(){
					 IdPrograma=o.IdPrograma
					 ,IdSAF=o.IdSAF
					 ,Codigo=o.Codigo
					 ,Nombre=o.Nombre
					 ,FechaAlta=o.FechaAlta
					 ,FechaBaja=o.FechaBaja
					 ,Activo=o.Activo
					 ,IdSectorialista=o.IdSectorialista
					,SAF_Codigo= t1.Codigo	
						,SAF_Denominacion= t1.Denominacion	
						,SAF_IdTipoOrganismo= t1.IdTipoOrganismo	
						,SAF_IdSector= t1.IdSector	
						,SAF_IdAdministracionTipo= t1.IdAdministracionTipo	
						,SAF_IdEntidadTipo= t1.IdEntidadTipo	
						,SAF_IdJurisdiccion= t1.IdJurisdiccion	
						,SAF_IdSubJurisdiccion= t1.IdSubJurisdiccion	
						,SAF_FechaAlta= t1.FechaAlta	
						,SAF_FechaBaja= t1.FechaBaja	
						,SAF_Activo= t1.Activo	
						,Sectorialista_NombreUsuario= t2!=null?(string)t2.NombreUsuario:null	
						,Sectorialista_Clave= t2!=null?(string)t2.Clave:null	
						,Sectorialista_Activo= t2!=null?(bool?)t2.Activo:null	
						,Sectorialista_EsSectioralista= t2!=null?(bool?)t2.EsSectioralista:null	
						,Sectorialista_IdLanguage= t2!=null?(int?)t2.IdLanguage:null	
						,Sectorialista_AccesoTotal= t2!=null?(bool?)t2.AccesoTotal:null	
                        ,Sectorialista_Nombre = t3!=null?(string)t3.NombreCompleto:null
						}
                    ).AsQueryable();
        }
        
       #endregion


    }
}

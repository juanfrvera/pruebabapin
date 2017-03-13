using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoOficinaPerfilData : _ProyectoOficinaPerfilData 
    { 
	   #region Singleton
	   private static volatile ProyectoOficinaPerfilData current;
	   private static object syncRoot = new Object();

	   //private ProyectoOficinaPerfilData() {}
	   public static ProyectoOficinaPerfilData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoOficinaPerfilData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoOficinaPerfil"; } }

       protected override IQueryable<ProyectoOficinaPerfil> Query(ProyectoOficinaPerfilFilter filter)
       {
           //Matias 20131106 - Tarea 79 - Problema 2100
           //Referenia http://techsolutions-at-desk.blogspot.com.ar/2012/04/fixedhow-to-overcome-linq-contains.html 

           /*
           return (from o in this.Table
                   where (filter.IdProyectoOficinaPerfil == null || filter.IdProyectoOficinaPerfil == 0 || o.IdProyectoOficinaPerfil == filter.IdProyectoOficinaPerfil)
                           && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto == filter.IdProyecto)
                           && (filter.IdOficina == null || filter.IdOficina == 0 || o.IdOficina == filter.IdOficina)
                           && (filter.IdPerfil == null || filter.IdPerfil == 0 || o.IdPerfil == filter.IdPerfil)
                           && (filter.IdsProyecto == null || filter.IdsProyecto.Count == 0 || filter.IdsProyecto.Contains(o.IdProyecto))
                   select o
                   ).AsQueryable();

           
           */

           List<int> proyetoIds = filter.IdsProyecto;
           if (filter.IdsProyecto == null || filter.IdsProyecto.Count == 0 || filter.IdsProyecto.Count < 2100)
           {
               return (from o in this.Table
                       where (filter.IdProyectoOficinaPerfil == null || filter.IdProyectoOficinaPerfil == 0 || o.IdProyectoOficinaPerfil == filter.IdProyectoOficinaPerfil)
                               && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto == filter.IdProyecto)
                               && (filter.IdOficina == null || filter.IdOficina == 0 || o.IdOficina == filter.IdOficina)
                               && (filter.IdPerfil == null || filter.IdPerfil == 0 || o.IdPerfil == filter.IdPerfil)
                               && (filter.IdsProyecto == null || filter.IdsProyecto.Count == 0 || filter.IdsProyecto.Contains(o.IdProyecto))
                       select o
                  ).AsQueryable();
           }

           else
           {
               return (from o in this.Table.AsEnumerable().Join(proyetoIds, c => c.IdProyecto, ci => ci, (c, ci) => c).ToList()
                       where (filter.IdProyectoOficinaPerfil == null || filter.IdProyectoOficinaPerfil == 0 || o.IdProyectoOficinaPerfil == filter.IdProyectoOficinaPerfil)
                               && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto == filter.IdProyecto)
                               && (filter.IdOficina == null || filter.IdOficina == 0 || o.IdOficina == filter.IdOficina)
                               && (filter.IdPerfil == null || filter.IdPerfil == 0 || o.IdPerfil == filter.IdPerfil)
                       select o
                       ).AsQueryable();
           }

           //FinMatias 20131106 - Tarea 79 - Problema 2100
       }
       protected override IQueryable<ProyectoOficinaPerfilResult> QueryResult(ProyectoOficinaPerfilFilter filter)
       {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Oficinas on o.IdOficina equals t1.IdOficina   
				    join t2  in this.Context.Perfils on o.IdPerfil equals t2.IdPerfil   
				    join t3  in this.Context.Proyectos on o.IdProyecto equals t3.IdProyecto   
                    where ( filter.CodigoPerfil == null || filter.CodigoPerfil.Trim() == "" || t2.Codigo == filter.CodigoPerfil )
				   select new ProyectoOficinaPerfilResult(){
					 IdProyectoOficinaPerfil=o.IdProyectoOficinaPerfil
					 ,IdProyecto=o.IdProyecto
					 ,IdOficina=o.IdOficina
					 ,IdPerfil=o.IdPerfil
					,Oficina_Nombre= t1.Nombre	
						,Oficina_Codigo= t1.Codigo	
						,Oficina_Activo= t1.Activo	
						,Oficina_Visible= t1.Visible	
						,Oficina_IdOficinaPadre= t1.IdOficinaPadre	
						,Oficina_IdSaf= t1.IdSaf
                        ,Oficina_BreadcrumbId = t1.BreadcrumbId
                        ,Oficina_BreadcrumbOrden = t1.BreadcrumbOrden	
						,Oficina_Nivel= t1.Nivel	
                        , Oficina_BreadcrumbCode = t1.BreadcrumbCode
                        , Oficina_Descripcion = t1.Descripcion
                        , Oficina_DescripcionCodigo = t1.DescripcionCodigo
                        , Oficina_DescripcionInvertida = t1.DescripcionInvertida
                        , Oficina_Orden = t1.Orden
                        , Oficina_Seleccionable =t1.Seleccionable                        
						,Perfil_Nombre= t2.Nombre	
						,Perfil_IdPerfilTipo= t2.IdPerfilTipo	
						,Perfil_Activo= t2.Activo	
						,Perfil_EsDefault= t2.EsDefault	
                        ,Perfil_Codigo = t2.Codigo
                        //,Perfil_HeredaConsulta= t2.HeredaConsulta	
                        //,Perfil_HeredaEdicion= t2.HeredaEdicion	
						,Proyecto_IdTipoProyecto= t3.IdTipoProyecto	
						,Proyecto_IdSubPrograma= t3.IdSubPrograma	
						,Proyecto_Codigo= t3.Codigo	
						,Proyecto_ProyectoDenominacion= t3.ProyectoDenominacion	
						,Proyecto_ProyectoSituacionActual= t3.ProyectoSituacionActual	
						,Proyecto_ProyectoDescripcion= t3.ProyectoDescripcion	
						,Proyecto_ProyectoObservacion= t3.ProyectoObservacion	
						,Proyecto_IdEstado= t3.IdEstado	
						,Proyecto_IdProceso= t3.IdProceso	
						,Proyecto_IdModalidadContratacion= t3.IdModalidadContratacion	
						,Proyecto_IdFinalidadFuncion= t3.IdFinalidadFuncion	
						,Proyecto_IdOrganismoPrioridad= t3.IdOrganismoPrioridad	
						,Proyecto_SubPrioridad= t3.SubPrioridad	
						,Proyecto_EsBorrador= t3.EsBorrador	
						,Proyecto_EsProyecto= t3.EsProyecto	
						,Proyecto_NroProyecto= t3.NroProyecto	
						,Proyecto_AnioCorriente= t3.AnioCorriente	
						,Proyecto_FechaInicioEjecucionCalculada= t3.FechaInicioEjecucionCalculada	
						,Proyecto_FechaFinEjecucionCalculada= t3.FechaFinEjecucionCalculada	
						,Proyecto_FechaAlta= t3.FechaAlta	
						,Proyecto_FechaModificacion= t3.FechaModificacion	
						,Proyecto_IdUsuarioModificacion= t3.IdUsuarioModificacion	
						}
                    ).AsQueryable();
        }
       public List<Int32> GetIdFuncionariosProyectos(ProyectoOficinaPerfilFilter filter)
       {
		  return (from o in Query(filter)					
				  join popf in this.Context.ProyectoOficinaPerfilFuncionarios on o.IdProyectoOficinaPerfil equals popf.IdProyectoOficinaPerfil
                  where filter.IdsProyecto == null || filter.IdsProyecto.Count == 0 || filter.IdsProyecto.Contains (o.IdProyecto )
				   select popf.IdUsuario 
                    ).ToList ();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc=Contract;
using nd=DataAccess;

namespace DataAccess.Base
{
    public abstract class _ProyectoAlcanceGeograficoData : EntityData<ProyectoAlcanceGeografico,ProyectoAlcanceGeograficoFilter,ProyectoAlcanceGeograficoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoAlcanceGeografico entity)
		{			
			return entity.IdProyectoAlcanceGeografico;
		}		
		public override ProyectoAlcanceGeografico GetByEntity(ProyectoAlcanceGeografico entity)
        {
            return this.GetById(entity.IdProyectoAlcanceGeografico);
        }
        public override ProyectoAlcanceGeografico GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoAlcanceGeografico == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoAlcanceGeografico> Query(ProyectoAlcanceGeograficoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoAlcanceGeografico == null || o.IdProyectoAlcanceGeografico >=  filter.IdProyectoAlcanceGeografico) && (filter.IdProyectoAlcanceGeografico_To == null || o.IdProyectoAlcanceGeografico <= filter.IdProyectoAlcanceGeografico_To)
					  && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto==filter.IdProyecto)
					  && (filter.IdClasificacionGeografica == null || filter.IdClasificacionGeografica == 0 || o.IdClasificacionGeografica==filter.IdClasificacionGeografica)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoAlcanceGeograficoResult> QueryResult(ProyectoAlcanceGeograficoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.ClasificacionGeograficas on o.IdClasificacionGeografica equals t1.IdClasificacionGeografica   
				    join t2  in this.Context.Proyectos on o.IdProyecto equals t2.IdProyecto   
				   select new ProyectoAlcanceGeograficoResult(){
					 IdProyectoAlcanceGeografico=o.IdProyectoAlcanceGeografico
					 ,IdProyecto=o.IdProyecto
					 ,IdClasificacionGeografica=o.IdClasificacionGeografica
                    //,ClasificacionGeografica_Codigo= t1.Codigo	
                    //    ,ClasificacionGeografica_Nombre= t1.Nombre	
                        ,ClasificacionGeografica_IdClasificacionGeograficaTipo= t1.IdClasificacionGeograficaTipo	
                    //    ,ClasificacionGeografica_IdClasificacionGeograficaPadre= t1.IdClasificacionGeograficaPadre	
                    //    ,ClasificacionGeografica_Activo= t1.Activo	
                        ,ClasificacionGeografica_Descripcion= t1.Descripcion	
                    //    ,ClasificacionGeografica_BreadcrumbId= t1.BreadcrumbId	
                    //    ,ClasificacionGeografica_BreadcrumOrden= t1.BreadcrumOrden	
                    //    ,ClasificacionGeografica_Orden= t1.Orden	
                    //    ,ClasificacionGeografica_Nivel= t1.Nivel	
                    //    ,ClasificacionGeografica_DescripcionInvertida= t1.DescripcionInvertida	
                    //    ,ClasificacionGeografica_Seleccionable= t1.Seleccionable	
                    //    ,ClasificacionGeografica_BreadcrumbCode= t1.BreadcrumbCode	
                    //    ,ClasificacionGeografica_DescripcionCodigo= t1.DescripcionCodigo	
                    //    ,Proyecto_IdTipoProyecto= t2.IdTipoProyecto	
                    //    ,Proyecto_IdSubPrograma= t2.IdSubPrograma	
                    //    ,Proyecto_Codigo= t2.Codigo	
                    //    ,Proyecto_ProyectoDenominacion= t2.ProyectoDenominacion	
                    //    ,Proyecto_ProyectoSituacionActual= t2.ProyectoSituacionActual	
                    //    ,Proyecto_ProyectoDescripcion= t2.ProyectoDescripcion	
                    //    ,Proyecto_ProyectoObservacion= t2.ProyectoObservacion	
                    //    ,Proyecto_IdEstado= t2.IdEstado	
                    //    ,Proyecto_IdProceso= t2.IdProceso	
                    //    ,Proyecto_IdModalidadContratacion= t2.IdModalidadContratacion	
                    //    ,Proyecto_IdFinalidadFuncion= t2.IdFinalidadFuncion	
                    //    ,Proyecto_IdOrganismoPrioridad= t2.IdOrganismoPrioridad	
                    //    ,Proyecto_SubPrioridad= t2.SubPrioridad	
                    //    ,Proyecto_EsBorrador= t2.EsBorrador	
                    //    ,Proyecto_EsProyecto= t2.EsProyecto	
                    //    ,Proyecto_NroProyecto= t2.NroProyecto	
                    //    ,Proyecto_AnioCorriente= t2.AnioCorriente	
                    //    ,Proyecto_FechaInicioEjecucionCalculada= t2.FechaInicioEjecucionCalculada	
                    //    ,Proyecto_FechaFinEjecucionCalculada= t2.FechaFinEjecucionCalculada	
                    //    ,Proyecto_FechaAlta= t2.FechaAlta	
                    //    ,Proyecto_FechaModificacion= t2.FechaModificacion	
                    //    ,Proyecto_IdUsuarioModificacion= t2.IdUsuarioModificacion	
                    //    ,Proyecto_IdProyectoPlan= t2.IdProyectoPlan	
                    //    ,Proyecto_EvaluarValidaciones= t2.EvaluarValidaciones	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoAlcanceGeografico Copy(nc.ProyectoAlcanceGeografico entity)
        {           
            nc.ProyectoAlcanceGeografico _new = new nc.ProyectoAlcanceGeografico();
		 _new.IdProyecto= entity.IdProyecto;
		 _new.IdClasificacionGeografica= entity.IdClasificacionGeografica;
		return _new;			
        }
		public override int CopyAndSave(ProyectoAlcanceGeografico entity,string renameFormat)
        {
            ProyectoAlcanceGeografico  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoAlcanceGeografico entity, int id)
        {            
            entity.IdProyectoAlcanceGeografico = id;            
        }
		public override void Set(ProyectoAlcanceGeografico source,ProyectoAlcanceGeografico target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoAlcanceGeografico= source.IdProyectoAlcanceGeografico ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 		  
		}
		public override void Set(ProyectoAlcanceGeograficoResult source,ProyectoAlcanceGeografico target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoAlcanceGeografico= source.IdProyectoAlcanceGeografico ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 
		}
		public override void Set(ProyectoAlcanceGeografico source,ProyectoAlcanceGeograficoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoAlcanceGeografico= source.IdProyectoAlcanceGeografico ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 	
		}		
		public override void Set(ProyectoAlcanceGeograficoResult source,ProyectoAlcanceGeograficoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoAlcanceGeografico= source.IdProyectoAlcanceGeografico ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
         //target.ClasificacionGeografica_Codigo= source.ClasificacionGeografica_Codigo;	
         //   target.ClasificacionGeografica_Nombre= source.ClasificacionGeografica_Nombre;	
            target.ClasificacionGeografica_IdClasificacionGeograficaTipo= source.ClasificacionGeografica_IdClasificacionGeograficaTipo;	
         //   target.ClasificacionGeografica_IdClasificacionGeograficaPadre= source.ClasificacionGeografica_IdClasificacionGeograficaPadre;	
         //   target.ClasificacionGeografica_Activo= source.ClasificacionGeografica_Activo;	
            target.ClasificacionGeografica_Descripcion= source.ClasificacionGeografica_Descripcion;	
         //   target.ClasificacionGeografica_BreadcrumbId= source.ClasificacionGeografica_BreadcrumbId;	
         //   target.ClasificacionGeografica_BreadcrumOrden= source.ClasificacionGeografica_BreadcrumOrden;	
         //   target.ClasificacionGeografica_Orden= source.ClasificacionGeografica_Orden;	
         //   target.ClasificacionGeografica_Nivel= source.ClasificacionGeografica_Nivel;	
            //target.ClasificacionGeografica_DescripcionInvertida= source.ClasificacionGeografica_DescripcionInvertida;	
         //   target.ClasificacionGeografica_Seleccionable= source.ClasificacionGeografica_Seleccionable;	
         //   target.ClasificacionGeografica_BreadcrumbCode= source.ClasificacionGeografica_BreadcrumbCode;	
            //target.ClasificacionGeografica_DescripcionCodigo= source.ClasificacionGeografica_DescripcionCodigo;	
         //   target.Proyecto_IdTipoProyecto= source.Proyecto_IdTipoProyecto;	
         //   target.Proyecto_IdSubPrograma= source.Proyecto_IdSubPrograma;	
         //   target.Proyecto_Codigo= source.Proyecto_Codigo;	
         //   target.Proyecto_ProyectoDenominacion= source.Proyecto_ProyectoDenominacion;	
         //   target.Proyecto_ProyectoSituacionActual= source.Proyecto_ProyectoSituacionActual;	
         //   target.Proyecto_ProyectoDescripcion= source.Proyecto_ProyectoDescripcion;	
         //   target.Proyecto_ProyectoObservacion= source.Proyecto_ProyectoObservacion;	
         //   target.Proyecto_IdEstado= source.Proyecto_IdEstado;	
         //   target.Proyecto_IdProceso= source.Proyecto_IdProceso;	
         //   target.Proyecto_IdModalidadContratacion= source.Proyecto_IdModalidadContratacion;	
         //   target.Proyecto_IdFinalidadFuncion= source.Proyecto_IdFinalidadFuncion;	
         //   target.Proyecto_IdOrganismoPrioridad= source.Proyecto_IdOrganismoPrioridad;	
         //   target.Proyecto_SubPrioridad= source.Proyecto_SubPrioridad;	
         //   target.Proyecto_EsBorrador= source.Proyecto_EsBorrador;	
         //   target.Proyecto_EsProyecto= source.Proyecto_EsProyecto;	
         //   target.Proyecto_NroProyecto= source.Proyecto_NroProyecto;	
         //   target.Proyecto_AnioCorriente= source.Proyecto_AnioCorriente;	
         //   target.Proyecto_FechaInicioEjecucionCalculada= source.Proyecto_FechaInicioEjecucionCalculada;	
         //   target.Proyecto_FechaFinEjecucionCalculada= source.Proyecto_FechaFinEjecucionCalculada;	
         //   target.Proyecto_FechaAlta= source.Proyecto_FechaAlta;	
         //   target.Proyecto_FechaModificacion= source.Proyecto_FechaModificacion;	
         //   target.Proyecto_IdUsuarioModificacion= source.Proyecto_IdUsuarioModificacion;	
         //   target.Proyecto_IdProyectoPlan= source.Proyecto_IdProyectoPlan;	
         //   target.Proyecto_EvaluarValidaciones= source.Proyecto_EvaluarValidaciones;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoAlcanceGeografico source,ProyectoAlcanceGeografico target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoAlcanceGeografico.Equals(target.IdProyectoAlcanceGeografico))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if(!source.IdClasificacionGeografica.Equals(target.IdClasificacionGeografica))return false;
		 
		  return true;
        }
		public override bool Equals(ProyectoAlcanceGeograficoResult source,ProyectoAlcanceGeograficoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoAlcanceGeografico.Equals(target.IdProyectoAlcanceGeografico))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if(!source.IdClasificacionGeografica.Equals(target.IdClasificacionGeografica))return false;
          //if((source.ClasificacionGeografica_Codigo == null)?target.ClasificacionGeografica_Codigo!=null:!source.ClasificacionGeografica_Codigo.Equals(target.ClasificacionGeografica_Codigo))return false;
          //               if((source.ClasificacionGeografica_Nombre == null)?target.ClasificacionGeografica_Nombre!=null:!source.ClasificacionGeografica_Nombre.Equals(target.ClasificacionGeografica_Nombre))return false;
                         if(!source.ClasificacionGeografica_IdClasificacionGeograficaTipo.Equals(target.ClasificacionGeografica_IdClasificacionGeograficaTipo))return false;
          //            if((source.ClasificacionGeografica_IdClasificacionGeograficaPadre == null)?(target.ClasificacionGeografica_IdClasificacionGeograficaPadre.HasValue && target.ClasificacionGeografica_IdClasificacionGeograficaPadre.Value > 0):!source.ClasificacionGeografica_IdClasificacionGeograficaPadre.Equals(target.ClasificacionGeografica_IdClasificacionGeograficaPadre))return false;
          //                            if(!source.ClasificacionGeografica_Activo.Equals(target.ClasificacionGeografica_Activo))return false;
					  if((source.ClasificacionGeografica_Descripcion == null)?target.ClasificacionGeografica_Descripcion!=null:!source.ClasificacionGeografica_Descripcion.Equals(target.ClasificacionGeografica_Descripcion))return false;
                      //   if((source.ClasificacionGeografica_BreadcrumbId == null)?target.ClasificacionGeografica_BreadcrumbId!=null:!source.ClasificacionGeografica_BreadcrumbId.Equals(target.ClasificacionGeografica_BreadcrumbId))return false;
                      //   if((source.ClasificacionGeografica_BreadcrumOrden == null)?target.ClasificacionGeografica_BreadcrumOrden!=null:!source.ClasificacionGeografica_BreadcrumOrden.Equals(target.ClasificacionGeografica_BreadcrumOrden))return false;
                      //   if((source.ClasificacionGeografica_Orden == null)?(target.ClasificacionGeografica_Orden.HasValue ):!source.ClasificacionGeografica_Orden.Equals(target.ClasificacionGeografica_Orden))return false;
                      //   if((source.ClasificacionGeografica_Nivel == null)?(target.ClasificacionGeografica_Nivel.HasValue ):!source.ClasificacionGeografica_Nivel.Equals(target.ClasificacionGeografica_Nivel))return false;
                      //   if((source.ClasificacionGeografica_DescripcionInvertida == null)?target.ClasificacionGeografica_DescripcionInvertida!=null:!source.ClasificacionGeografica_DescripcionInvertida.Equals(target.ClasificacionGeografica_DescripcionInvertida))return false;
                      //   if(!source.ClasificacionGeografica_Seleccionable.Equals(target.ClasificacionGeografica_Seleccionable))return false;
                      //if((source.ClasificacionGeografica_BreadcrumbCode == null)?target.ClasificacionGeografica_BreadcrumbCode!=null:!source.ClasificacionGeografica_BreadcrumbCode.Equals(target.ClasificacionGeografica_BreadcrumbCode))return false;
                      //   if((source.ClasificacionGeografica_DescripcionCodigo == null)?target.ClasificacionGeografica_DescripcionCodigo!=null:!source.ClasificacionGeografica_DescripcionCodigo.Equals(target.ClasificacionGeografica_DescripcionCodigo))return false;
                      //   if(!source.Proyecto_IdTipoProyecto.Equals(target.Proyecto_IdTipoProyecto))return false;
                      //if(!source.Proyecto_IdSubPrograma.Equals(target.Proyecto_IdSubPrograma))return false;
                      //if(!source.Proyecto_Codigo.Equals(target.Proyecto_Codigo))return false;
                      //if((source.Proyecto_ProyectoDenominacion == null)?target.Proyecto_ProyectoDenominacion!=null:!source.Proyecto_ProyectoDenominacion.Equals(target.Proyecto_ProyectoDenominacion))return false;
                      //   if((source.Proyecto_ProyectoSituacionActual == null)?target.Proyecto_ProyectoSituacionActual!=null:!source.Proyecto_ProyectoSituacionActual.Equals(target.Proyecto_ProyectoSituacionActual))return false;
                      //   if((source.Proyecto_ProyectoDescripcion == null)?target.Proyecto_ProyectoDescripcion!=null:!source.Proyecto_ProyectoDescripcion.Equals(target.Proyecto_ProyectoDescripcion))return false;
                      //   if((source.Proyecto_ProyectoObservacion == null)?target.Proyecto_ProyectoObservacion!=null:!source.Proyecto_ProyectoObservacion.Equals(target.Proyecto_ProyectoObservacion))return false;
                      //   if(!source.Proyecto_IdEstado.Equals(target.Proyecto_IdEstado))return false;
                      //if((source.Proyecto_IdProceso == null)?(target.Proyecto_IdProceso.HasValue && target.Proyecto_IdProceso.Value > 0):!source.Proyecto_IdProceso.Equals(target.Proyecto_IdProceso))return false;
                      //                if((source.Proyecto_IdModalidadContratacion == null)?(target.Proyecto_IdModalidadContratacion.HasValue && target.Proyecto_IdModalidadContratacion.Value > 0):!source.Proyecto_IdModalidadContratacion.Equals(target.Proyecto_IdModalidadContratacion))return false;
                      //                if((source.Proyecto_IdFinalidadFuncion == null)?(target.Proyecto_IdFinalidadFuncion.HasValue && target.Proyecto_IdFinalidadFuncion.Value > 0):!source.Proyecto_IdFinalidadFuncion.Equals(target.Proyecto_IdFinalidadFuncion))return false;
                      //                if((source.Proyecto_IdOrganismoPrioridad == null)?(target.Proyecto_IdOrganismoPrioridad.HasValue && target.Proyecto_IdOrganismoPrioridad.Value > 0):!source.Proyecto_IdOrganismoPrioridad.Equals(target.Proyecto_IdOrganismoPrioridad))return false;
                      //                if((source.Proyecto_SubPrioridad == null)?(target.Proyecto_SubPrioridad.HasValue ):!source.Proyecto_SubPrioridad.Equals(target.Proyecto_SubPrioridad))return false;
                      //   if(!source.Proyecto_EsBorrador.Equals(target.Proyecto_EsBorrador))return false;
                      //if((source.Proyecto_EsProyecto == null)?(target.Proyecto_EsProyecto.HasValue ):!source.Proyecto_EsProyecto.Equals(target.Proyecto_EsProyecto))return false;
                      //   if((source.Proyecto_NroProyecto == null)?(target.Proyecto_NroProyecto.HasValue ):!source.Proyecto_NroProyecto.Equals(target.Proyecto_NroProyecto))return false;
                      //   if((source.Proyecto_AnioCorriente == null)?(target.Proyecto_AnioCorriente.HasValue ):!source.Proyecto_AnioCorriente.Equals(target.Proyecto_AnioCorriente))return false;
                      //   if((source.Proyecto_FechaInicioEjecucionCalculada == null)?(target.Proyecto_FechaInicioEjecucionCalculada.HasValue ):!source.Proyecto_FechaInicioEjecucionCalculada.Equals(target.Proyecto_FechaInicioEjecucionCalculada))return false;
                      //   if((source.Proyecto_FechaFinEjecucionCalculada == null)?(target.Proyecto_FechaFinEjecucionCalculada.HasValue ):!source.Proyecto_FechaFinEjecucionCalculada.Equals(target.Proyecto_FechaFinEjecucionCalculada))return false;
                      //   if(!source.Proyecto_FechaAlta.Equals(target.Proyecto_FechaAlta))return false;
                      //if(!source.Proyecto_FechaModificacion.Equals(target.Proyecto_FechaModificacion))return false;
                      //if(!source.Proyecto_IdUsuarioModificacion.Equals(target.Proyecto_IdUsuarioModificacion))return false;
                      //if((source.Proyecto_IdProyectoPlan == null)?(target.Proyecto_IdProyectoPlan.HasValue ):!source.Proyecto_IdProyectoPlan.Equals(target.Proyecto_IdProyectoPlan))return false;
                      //   if(!source.Proyecto_EvaluarValidaciones.Equals(target.Proyecto_EvaluarValidaciones))return false;
					 		
		  return true;
        }
		#endregion
    }
}

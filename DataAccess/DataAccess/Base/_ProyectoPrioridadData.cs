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
    public abstract class _ProyectoPrioridadData : EntityData<ProyectoPrioridad,ProyectoPrioridadFilter,ProyectoPrioridadResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoPrioridad entity)
		{			
			return entity.IdProyectoPrioridad;
		}		
		public override ProyectoPrioridad GetByEntity(ProyectoPrioridad entity)
        {
            return this.GetById(entity.IdProyectoPrioridad);
        }
        public override ProyectoPrioridad GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoPrioridad == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoPrioridad> Query(ProyectoPrioridadFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoPrioridad == null || o.IdProyectoPrioridad >=  filter.IdProyectoPrioridad) && (filter.IdProyectoPrioridad_To == null || o.IdProyectoPrioridad <= filter.IdProyectoPrioridad_To)
					  && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto==filter.IdProyecto)
					  && (filter.IdPlanPeriodo == null || filter.IdPlanPeriodo == 0 || o.IdPlanPeriodo==filter.IdPlanPeriodo)
					  && (filter.IdPrioridad == null || filter.IdPrioridad == 0 || o.IdPrioridad==filter.IdPrioridad)
					  && (filter.IdPrioridadIsNull == null || filter.IdPrioridadIsNull == true || o.IdPrioridad != null ) && (filter.IdPrioridadIsNull == null || filter.IdPrioridadIsNull == false || o.IdPrioridad == null)
					  && (filter.Puntaje == null || o.Puntaje >=  filter.Puntaje) && (filter.Puntaje_To == null || o.Puntaje <= filter.Puntaje_To)
					  && (filter.ReqArt15 == null || o.ReqArt15==filter.ReqArt15)
					  && (filter.ReqArt15IsNull == null || filter.ReqArt15IsNull == true || o.ReqArt15 != null ) && (filter.ReqArt15IsNull == null || filter.ReqArt15IsNull == false || o.ReqArt15 == null)
					  && (filter.IdClasificacion == null || filter.IdClasificacion == 0 || o.IdClasificacion==filter.IdClasificacion)
					  && (filter.IdClasificacionIsNull == null || filter.IdClasificacionIsNull == true || o.IdClasificacion != null ) && (filter.IdClasificacionIsNull == null || filter.IdClasificacionIsNull == false || o.IdClasificacion == null)
					  && (filter.Comentario == null || filter.Comentario.Trim() == string.Empty || filter.Comentario.Trim() == "%"  || (filter.Comentario.EndsWith("%") && filter.Comentario.StartsWith("%") && (o.Comentario.Contains(filter.Comentario.Replace("%", "")))) || (filter.Comentario.EndsWith("%") && o.Comentario.StartsWith(filter.Comentario.Replace("%",""))) || (filter.Comentario.StartsWith("%") && o.Comentario.EndsWith(filter.Comentario.Replace("%",""))) || o.Comentario == filter.Comentario )
					  && (filter.PrioridadAsignada == null || o.PrioridadAsignada==filter.PrioridadAsignada)
					  && (filter.ConfRequerimientos == null || o.ConfRequerimientos==filter.ConfRequerimientos)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoPrioridadResult> QueryResult(ProyectoPrioridadFilter filter)
        {
		  return (from o in Query(filter)					
					join _t1  in this.Context.Clasificacions on o.IdClasificacion equals _t1.IdClasificacion into tt1 from t1 in tt1.DefaultIfEmpty()
				    join t2  in this.Context.PlanPeriodos on o.IdPlanPeriodo equals t2.IdPlanPeriodo   
				   join _t3  in this.Context.Prioridads on o.IdPrioridad equals _t3.IdPrioridad into tt3 from t3 in tt3.DefaultIfEmpty()
				    join t4  in this.Context.Proyectos on o.IdProyecto equals t4.IdProyecto 
                    
				   select new ProyectoPrioridadResult(){
					 IdProyectoPrioridad=o.IdProyectoPrioridad
					 ,IdProyecto=o.IdProyecto
					 ,IdPlanPeriodo=o.IdPlanPeriodo
					 ,IdPrioridad=o.IdPrioridad
					 ,Puntaje=o.Puntaje
					 ,ReqArt15=o.ReqArt15
					 ,IdClasificacion=o.IdClasificacion
					 ,Comentario=o.Comentario
					 ,PrioridadAsignada=o.PrioridadAsignada
					 ,ConfRequerimientos=o.ConfRequerimientos
					,Clasificacion_Nombre= t1!=null?(string)t1.Nombre:null	
						,Clasificacion_Activo= t1!=null?(bool?)t1.Activo:null	
						,PlanPeriodo_IdPlanTipo= t2.IdPlanTipo	
						,PlanPeriodo_Nombre= t2.Nombre	
						,PlanPeriodo_Sigla= t2.Sigla	
						,PlanPeriodo_AnioInicial= t2.AnioInicial	
						,PlanPeriodo_AnioFinal= t2.AnioFinal	
						,PlanPeriodo_Activo= t2.Activo	
						,Prioridad_Sigla= t3!=null?(string)t3.Sigla:null	
						,Prioridad_Orden= t3!=null?(int?)t3.Orden:null	
						,Prioridad_Nombre= t3!=null?(string)t3.Nombre:null	
						,Prioridad_Activo= t3!=null?(bool?)t3.Activo:null	
                        //,Proyecto_IdTipoProyecto= t4.IdTipoProyecto	
                        //,Proyecto_IdSubPrograma= t4.IdSubPrograma	
                        //,Proyecto_Codigo= t4.Codigo	
                        //,Proyecto_ProyectoDenominacion= t4.ProyectoDenominacion	
                        //,Proyecto_ProyectoSituacionActual= t4.ProyectoSituacionActual	
                        //,Proyecto_ProyectoDescripcion= t4.ProyectoDescripcion	
                        //,Proyecto_ProyectoObservacion= t4.ProyectoObservacion	
                        //,Proyecto_IdEstado= t4.IdEstado	
                        //,Proyecto_IdProceso= t4.IdProceso	
                        //,Proyecto_IdModalidadContratacion= t4.IdModalidadContratacion	
                        //,Proyecto_IdFinalidadFuncion= t4.IdFinalidadFuncion	
                        //,Proyecto_IdOrganismoPrioridad= t4.IdOrganismoPrioridad	
                        //,Proyecto_SubPrioridad= t4.SubPrioridad	
                        //,Proyecto_EsBorrador= t4.EsBorrador	
                        //,Proyecto_EsProyecto= t4.EsProyecto	
                        //,Proyecto_NroProyecto= t4.NroProyecto	
                        //,Proyecto_AnioCorriente= t4.AnioCorriente	
                        //,Proyecto_FechaInicioEjecucionCalculada= t4.FechaInicioEjecucionCalculada	
                        //,Proyecto_FechaFinEjecucionCalculada= t4.FechaFinEjecucionCalculada	
                        //,Proyecto_FechaAlta= t4.FechaAlta	
                        ,Proyecto_FechaModificacion= t4.FechaModificacion	
                        //,Proyecto_IdUsuarioModificacion= t4.IdUsuarioModificacion	
                        //,Proyecto_IdProyectoPlan= t4.IdProyectoPlan	
                        //,Proyecto_EvaluarValidaciones= t4.EvaluarValidaciones	
                        //,Proyecto_Activo= t4.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoPrioridad Copy(nc.ProyectoPrioridad entity)
        {           
            nc.ProyectoPrioridad _new = new nc.ProyectoPrioridad();
		 _new.IdProyecto= entity.IdProyecto;
		 _new.IdPlanPeriodo= entity.IdPlanPeriodo;
		 _new.IdPrioridad= entity.IdPrioridad;
		 _new.Puntaje= entity.Puntaje;
		 _new.ReqArt15= entity.ReqArt15;
		 _new.IdClasificacion= entity.IdClasificacion;
		 _new.Comentario= entity.Comentario;
		 _new.PrioridadAsignada= entity.PrioridadAsignada;
		 _new.ConfRequerimientos= entity.ConfRequerimientos;
		return _new;			
        }
		public override int CopyAndSave(ProyectoPrioridad entity,string renameFormat)
        {
            ProyectoPrioridad  newEntity = Copy(entity);
            newEntity.Comentario = string.Format(renameFormat,newEntity.Comentario);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoPrioridad entity, int id)
        {            
            entity.IdProyectoPrioridad = id;            
        }
		public override void Set(ProyectoPrioridad source,ProyectoPrioridad target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoPrioridad= source.IdProyectoPrioridad ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdPlanPeriodo= source.IdPlanPeriodo ;
		 target.IdPrioridad= source.IdPrioridad ;
		 target.Puntaje= source.Puntaje ;
		 target.ReqArt15= source.ReqArt15 ;
		 target.IdClasificacion= source.IdClasificacion ;
		 target.Comentario= source.Comentario ;
		 target.PrioridadAsignada= source.PrioridadAsignada ;
		 target.ConfRequerimientos= source.ConfRequerimientos ;
		 		  
		}
		public override void Set(ProyectoPrioridadResult source,ProyectoPrioridad target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoPrioridad= source.IdProyectoPrioridad ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdPlanPeriodo= source.IdPlanPeriodo ;
		 target.IdPrioridad= source.IdPrioridad ;
		 target.Puntaje= source.Puntaje ;
		 target.ReqArt15= source.ReqArt15 ;
		 target.IdClasificacion= source.IdClasificacion ;
		 target.Comentario= source.Comentario ;
		 target.PrioridadAsignada= source.PrioridadAsignada ;
		 target.ConfRequerimientos= source.ConfRequerimientos ;
		 
		}
		public override void Set(ProyectoPrioridad source,ProyectoPrioridadResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoPrioridad= source.IdProyectoPrioridad ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdPlanPeriodo= source.IdPlanPeriodo ;
		 target.IdPrioridad= source.IdPrioridad ;
		 target.Puntaje= source.Puntaje ;
		 target.ReqArt15= source.ReqArt15 ;
		 target.IdClasificacion= source.IdClasificacion ;
		 target.Comentario= source.Comentario ;
		 target.PrioridadAsignada= source.PrioridadAsignada ;
		 target.ConfRequerimientos= source.ConfRequerimientos ;
		 	
		}		
		public override void Set(ProyectoPrioridadResult source,ProyectoPrioridadResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoPrioridad= source.IdProyectoPrioridad ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdPlanPeriodo= source.IdPlanPeriodo ;
		 target.IdPrioridad= source.IdPrioridad ;
		 target.Puntaje= source.Puntaje ;
		 target.ReqArt15= source.ReqArt15 ;
		 target.IdClasificacion= source.IdClasificacion ;
		 target.Comentario= source.Comentario ;
		 target.PrioridadAsignada= source.PrioridadAsignada ;
		 target.ConfRequerimientos= source.ConfRequerimientos ;
		 target.Clasificacion_Nombre= source.Clasificacion_Nombre;	
			target.Clasificacion_Activo= source.Clasificacion_Activo;	
			target.PlanPeriodo_IdPlanTipo= source.PlanPeriodo_IdPlanTipo;	
			target.PlanPeriodo_Nombre= source.PlanPeriodo_Nombre;	
			target.PlanPeriodo_Sigla= source.PlanPeriodo_Sigla;	
			target.PlanPeriodo_AnioInicial= source.PlanPeriodo_AnioInicial;	
			target.PlanPeriodo_AnioFinal= source.PlanPeriodo_AnioFinal;	
			target.PlanPeriodo_Activo= source.PlanPeriodo_Activo;	
			target.Prioridad_Sigla= source.Prioridad_Sigla;	
			target.Prioridad_Orden= source.Prioridad_Orden;	
			target.Prioridad_Nombre= source.Prioridad_Nombre;	
			target.Prioridad_Activo= source.Prioridad_Activo;	
            //target.Proyecto_IdTipoProyecto= source.Proyecto_IdTipoProyecto;	
            //target.Proyecto_IdSubPrograma= source.Proyecto_IdSubPrograma;	
            //target.Proyecto_Codigo= source.Proyecto_Codigo;	
            //target.Proyecto_ProyectoDenominacion= source.Proyecto_ProyectoDenominacion;	
            //target.Proyecto_ProyectoSituacionActual= source.Proyecto_ProyectoSituacionActual;	
            //target.Proyecto_ProyectoDescripcion= source.Proyecto_ProyectoDescripcion;	
            //target.Proyecto_ProyectoObservacion= source.Proyecto_ProyectoObservacion;	
            //target.Proyecto_IdEstado= source.Proyecto_IdEstado;	
            //target.Proyecto_IdProceso= source.Proyecto_IdProceso;	
            //target.Proyecto_IdModalidadContratacion= source.Proyecto_IdModalidadContratacion;	
            //target.Proyecto_IdFinalidadFuncion= source.Proyecto_IdFinalidadFuncion;	
            //target.Proyecto_IdOrganismoPrioridad= source.Proyecto_IdOrganismoPrioridad;	
            //target.Proyecto_SubPrioridad= source.Proyecto_SubPrioridad;	
            //target.Proyecto_EsBorrador= source.Proyecto_EsBorrador;	
            //target.Proyecto_EsProyecto= source.Proyecto_EsProyecto;	
            //target.Proyecto_NroProyecto= source.Proyecto_NroProyecto;	
            //target.Proyecto_AnioCorriente= source.Proyecto_AnioCorriente;	
            //target.Proyecto_FechaInicioEjecucionCalculada= source.Proyecto_FechaInicioEjecucionCalculada;	
            //target.Proyecto_FechaFinEjecucionCalculada= source.Proyecto_FechaFinEjecucionCalculada;	
            //target.Proyecto_FechaAlta= source.Proyecto_FechaAlta;	
            //target.Proyecto_FechaModificacion= source.Proyecto_FechaModificacion;	
            //target.Proyecto_IdUsuarioModificacion= source.Proyecto_IdUsuarioModificacion;	
            //target.Proyecto_IdProyectoPlan= source.Proyecto_IdProyectoPlan;	
            //target.Proyecto_EvaluarValidaciones= source.Proyecto_EvaluarValidaciones;	
            //target.Proyecto_Activo= source.Proyecto_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoPrioridad source,ProyectoPrioridad target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoPrioridad.Equals(target.IdProyectoPrioridad))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if(!source.IdPlanPeriodo.Equals(target.IdPlanPeriodo))return false;
		  if((source.IdPrioridad == null)?(target.IdPrioridad.HasValue && target.IdPrioridad.Value > 0):!source.IdPrioridad.Equals(target.IdPrioridad))return false;
						  if(!source.Puntaje.Equals(target.Puntaje))return false;
		  if((source.ReqArt15 == null)?(target.ReqArt15.HasValue):!source.ReqArt15.Equals(target.ReqArt15))return false;
			 if((source.IdClasificacion == null)?(target.IdClasificacion.HasValue && target.IdClasificacion.Value > 0):!source.IdClasificacion.Equals(target.IdClasificacion))return false;
						  if((source.Comentario == null)?target.Comentario!=null:  !( (target.Comentario== String.Empty && source.Comentario== null) || (target.Comentario==null && source.Comentario== String.Empty )) &&  !source.Comentario.Trim().Replace ("\r","").Equals(target.Comentario.Trim().Replace ("\r","")))return false;
			 if(!source.PrioridadAsignada.Equals(target.PrioridadAsignada))return false;
		  if(!source.ConfRequerimientos.Equals(target.ConfRequerimientos))return false;
		 
		  return true;
        }
		public override bool Equals(ProyectoPrioridadResult source,ProyectoPrioridadResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoPrioridad.Equals(target.IdProyectoPrioridad))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if(!source.IdPlanPeriodo.Equals(target.IdPlanPeriodo))return false;
		  if((source.IdPrioridad == null)?(target.IdPrioridad.HasValue && target.IdPrioridad.Value > 0):!source.IdPrioridad.Equals(target.IdPrioridad))return false;
						  if(!source.Puntaje.Equals(target.Puntaje))return false;
		  if((source.ReqArt15 == null)?(target.ReqArt15.HasValue):!source.ReqArt15.Equals(target.ReqArt15))return false;
			 if((source.IdClasificacion == null)?(target.IdClasificacion.HasValue && target.IdClasificacion.Value > 0):!source.IdClasificacion.Equals(target.IdClasificacion))return false;
						  if((source.Comentario == null)?target.Comentario!=null: !( (target.Comentario== String.Empty && source.Comentario== null) || (target.Comentario==null && source.Comentario== String.Empty )) && !source.Comentario.Trim().Replace ("\r","").Equals(target.Comentario.Trim().Replace ("\r","")))return false;
			 if(!source.PrioridadAsignada.Equals(target.PrioridadAsignada))return false;
		  if(!source.ConfRequerimientos.Equals(target.ConfRequerimientos))return false;
		  if((source.Clasificacion_Nombre == null)?target.Clasificacion_Nombre!=null: !( (target.Clasificacion_Nombre== String.Empty && source.Clasificacion_Nombre== null) || (target.Clasificacion_Nombre==null && source.Clasificacion_Nombre== String.Empty )) &&   !source.Clasificacion_Nombre.Trim().Replace ("\r","").Equals(target.Clasificacion_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.Clasificacion_Activo.Equals(target.Clasificacion_Activo))return false;
					  if(!source.PlanPeriodo_IdPlanTipo.Equals(target.PlanPeriodo_IdPlanTipo))return false;
					  if((source.PlanPeriodo_Nombre == null)?target.PlanPeriodo_Nombre!=null: !( (target.PlanPeriodo_Nombre== String.Empty && source.PlanPeriodo_Nombre== null) || (target.PlanPeriodo_Nombre==null && source.PlanPeriodo_Nombre== String.Empty )) &&   !source.PlanPeriodo_Nombre.Trim().Replace ("\r","").Equals(target.PlanPeriodo_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.PlanPeriodo_Sigla == null)?target.PlanPeriodo_Sigla!=null: !( (target.PlanPeriodo_Sigla== String.Empty && source.PlanPeriodo_Sigla== null) || (target.PlanPeriodo_Sigla==null && source.PlanPeriodo_Sigla== String.Empty )) &&   !source.PlanPeriodo_Sigla.Trim().Replace ("\r","").Equals(target.PlanPeriodo_Sigla.Trim().Replace ("\r","")))return false;
						 if(!source.PlanPeriodo_AnioInicial.Equals(target.PlanPeriodo_AnioInicial))return false;
					  if(!source.PlanPeriodo_AnioFinal.Equals(target.PlanPeriodo_AnioFinal))return false;
					  if(!source.PlanPeriodo_Activo.Equals(target.PlanPeriodo_Activo))return false;
					  if((source.Prioridad_Sigla == null)?target.Prioridad_Sigla!=null: !( (target.Prioridad_Sigla== String.Empty && source.Prioridad_Sigla== null) || (target.Prioridad_Sigla==null && source.Prioridad_Sigla== String.Empty )) &&   !source.Prioridad_Sigla.Trim().Replace ("\r","").Equals(target.Prioridad_Sigla.Trim().Replace ("\r","")))return false;
						 if(!source.Prioridad_Orden.Equals(target.Prioridad_Orden))return false;
					  if((source.Prioridad_Nombre == null)?target.Prioridad_Nombre!=null: !( (target.Prioridad_Nombre== String.Empty && source.Prioridad_Nombre== null) || (target.Prioridad_Nombre==null && source.Prioridad_Nombre== String.Empty )) &&   !source.Prioridad_Nombre.Trim().Replace ("\r","").Equals(target.Prioridad_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.Prioridad_Activo.Equals(target.Prioridad_Activo))return false;
                      //if(!source.Proyecto_IdTipoProyecto.Equals(target.Proyecto_IdTipoProyecto))return false;
                      //if(!source.Proyecto_IdSubPrograma.Equals(target.Proyecto_IdSubPrograma))return false;
                      //if(!source.Proyecto_Codigo.Equals(target.Proyecto_Codigo))return false;
                      //if((source.Proyecto_ProyectoDenominacion == null)?target.Proyecto_ProyectoDenominacion!=null: !( (target.Proyecto_ProyectoDenominacion== String.Empty && source.Proyecto_ProyectoDenominacion== null) || (target.Proyecto_ProyectoDenominacion==null && source.Proyecto_ProyectoDenominacion== String.Empty )) &&   !source.Proyecto_ProyectoDenominacion.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoDenominacion.Trim().Replace ("\r","")))return false;
                      //   if((source.Proyecto_ProyectoSituacionActual == null)?target.Proyecto_ProyectoSituacionActual!=null: !( (target.Proyecto_ProyectoSituacionActual== String.Empty && source.Proyecto_ProyectoSituacionActual== null) || (target.Proyecto_ProyectoSituacionActual==null && source.Proyecto_ProyectoSituacionActual== String.Empty )) &&   !source.Proyecto_ProyectoSituacionActual.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoSituacionActual.Trim().Replace ("\r","")))return false;
                      //   if((source.Proyecto_ProyectoDescripcion == null)?target.Proyecto_ProyectoDescripcion!=null: !( (target.Proyecto_ProyectoDescripcion== String.Empty && source.Proyecto_ProyectoDescripcion== null) || (target.Proyecto_ProyectoDescripcion==null && source.Proyecto_ProyectoDescripcion== String.Empty )) &&   !source.Proyecto_ProyectoDescripcion.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoDescripcion.Trim().Replace ("\r","")))return false;
                      //   if((source.Proyecto_ProyectoObservacion == null)?target.Proyecto_ProyectoObservacion!=null: !( (target.Proyecto_ProyectoObservacion== String.Empty && source.Proyecto_ProyectoObservacion== null) || (target.Proyecto_ProyectoObservacion==null && source.Proyecto_ProyectoObservacion== String.Empty )) &&   !source.Proyecto_ProyectoObservacion.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoObservacion.Trim().Replace ("\r","")))return false;
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
                      //if(!source.Proyecto_Activo.Equals(target.Proyecto_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}

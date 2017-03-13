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
    public abstract class _ProyectoRelacionData : EntityData<ProyectoRelacion,ProyectoRelacionFilter,ProyectoRelacionResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoRelacion entity)
		{			
			return entity.IdProyectoRelacion;
		}		
		public override ProyectoRelacion GetByEntity(ProyectoRelacion entity)
        {
            return this.GetById(entity.IdProyectoRelacion);
        }
        public override ProyectoRelacion GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoRelacion == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoRelacion> Query(ProyectoRelacionFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoRelacion == null || o.IdProyectoRelacion >=  filter.IdProyectoRelacion) && (filter.IdProyectoRelacion_To == null || o.IdProyectoRelacion <= filter.IdProyectoRelacion_To)
					  && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto==filter.IdProyecto)
					  && (filter.IdProyectoRelacionado == null || filter.IdProyectoRelacionado == 0 || o.IdProyectoRelacionado==filter.IdProyectoRelacionado)
					  && (filter.IdProyectoRelacionTipo == null || filter.IdProyectoRelacionTipo == 0 || o.IdProyectoRelacionTipo==filter.IdProyectoRelacionTipo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoRelacionResult> QueryResult(ProyectoRelacionFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Proyectos on o.IdProyectoRelacionado equals t1.IdProyecto   
				    join t2  in this.Context.Proyectos on o.IdProyecto equals t2.IdProyecto   
				    join t3  in this.Context.ProyectoRelacionTipos on o.IdProyectoRelacionTipo equals t3.IdProyectoRelacionTipo   
				   select new ProyectoRelacionResult(){
					 IdProyectoRelacion=o.IdProyectoRelacion
					 ,IdProyecto=o.IdProyecto
					 ,IdProyectoRelacionado=o.IdProyectoRelacionado
					 ,IdProyectoRelacionTipo=o.IdProyectoRelacionTipo
					,ProyectoRelacionado_IdTipoProyecto= t1.IdTipoProyecto	
						,ProyectoRelacionado_IdSubPrograma= t1.IdSubPrograma	
						,ProyectoRelacionado_Codigo= t1.Codigo	
						,ProyectoRelacionado_ProyectoDenominacion= t1.ProyectoDenominacion	
						,ProyectoRelacionado_ProyectoSituacionActual= t1.ProyectoSituacionActual	
						,ProyectoRelacionado_ProyectoDescripcion= t1.ProyectoDescripcion	
						,ProyectoRelacionado_ProyectoObservacion= t1.ProyectoObservacion	
						,ProyectoRelacionado_IdEstado= t1.IdEstado	
						,ProyectoRelacionado_IdProceso= t1.IdProceso	
						,ProyectoRelacionado_IdModalidadContratacion= t1.IdModalidadContratacion	
						,ProyectoRelacionado_IdFinalidadFuncion= t1.IdFinalidadFuncion	
						,ProyectoRelacionado_IdOrganismoPrioridad= t1.IdOrganismoPrioridad	
						,ProyectoRelacionado_SubPrioridad= t1.SubPrioridad	
						,ProyectoRelacionado_EsBorrador= t1.EsBorrador	
						,ProyectoRelacionado_EsProyecto= t1.EsProyecto	
						,ProyectoRelacionado_NroProyecto= t1.NroProyecto	
						,ProyectoRelacionado_AnioCorriente= t1.AnioCorriente	
						,ProyectoRelacionado_FechaInicioEjecucionCalculada= t1.FechaInicioEjecucionCalculada	
						,ProyectoRelacionado_FechaFinEjecucionCalculada= t1.FechaFinEjecucionCalculada	
						,ProyectoRelacionado_FechaAlta= t1.FechaAlta	
						,ProyectoRelacionado_FechaModificacion= t1.FechaModificacion	
						,ProyectoRelacionado_IdUsuarioModificacion= t1.IdUsuarioModificacion	
						,ProyectoRelacionado_IdProyectoPlan= t1.IdProyectoPlan	
						,ProyectoRelacionado_EvaluarValidaciones= t1.EvaluarValidaciones	
						,Proyecto_IdTipoProyecto= t2.IdTipoProyecto	
						,Proyecto_IdSubPrograma= t2.IdSubPrograma	
						,Proyecto_Codigo= t2.Codigo	
						,Proyecto_ProyectoDenominacion= t2.ProyectoDenominacion	
						,Proyecto_ProyectoSituacionActual= t2.ProyectoSituacionActual	
						,Proyecto_ProyectoDescripcion= t2.ProyectoDescripcion	
						,Proyecto_ProyectoObservacion= t2.ProyectoObservacion	
						,Proyecto_IdEstado= t2.IdEstado	
						,Proyecto_IdProceso= t2.IdProceso	
						,Proyecto_IdModalidadContratacion= t2.IdModalidadContratacion	
						,Proyecto_IdFinalidadFuncion= t2.IdFinalidadFuncion	
						,Proyecto_IdOrganismoPrioridad= t2.IdOrganismoPrioridad	
						,Proyecto_SubPrioridad= t2.SubPrioridad	
						,Proyecto_EsBorrador= t2.EsBorrador	
						,Proyecto_EsProyecto= t2.EsProyecto	
						,Proyecto_NroProyecto= t2.NroProyecto	
						,Proyecto_AnioCorriente= t2.AnioCorriente	
						,Proyecto_FechaInicioEjecucionCalculada= t2.FechaInicioEjecucionCalculada	
						,Proyecto_FechaFinEjecucionCalculada= t2.FechaFinEjecucionCalculada	
						,Proyecto_FechaAlta= t2.FechaAlta	
						,Proyecto_FechaModificacion= t2.FechaModificacion	
						,Proyecto_IdUsuarioModificacion= t2.IdUsuarioModificacion	
						,Proyecto_IdProyectoPlan= t2.IdProyectoPlan	
						,Proyecto_EvaluarValidaciones= t2.EvaluarValidaciones	
						,ProyectoRelacionTipo_Nombre= t3.Nombre	
						,ProyectoRelacionTipo_Activo= t3.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoRelacion Copy(nc.ProyectoRelacion entity)
        {           
            nc.ProyectoRelacion _new = new nc.ProyectoRelacion();
		 _new.IdProyecto= entity.IdProyecto;
		 _new.IdProyectoRelacionado= entity.IdProyectoRelacionado;
		 _new.IdProyectoRelacionTipo= entity.IdProyectoRelacionTipo;
		return _new;			
        }
		public override int CopyAndSave(ProyectoRelacion entity,string renameFormat)
        {
            ProyectoRelacion  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoRelacion entity, int id)
        {            
            entity.IdProyectoRelacion = id;            
        }
		public override void Set(ProyectoRelacion source,ProyectoRelacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoRelacion= source.IdProyectoRelacion ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdProyectoRelacionado= source.IdProyectoRelacionado ;
		 target.IdProyectoRelacionTipo= source.IdProyectoRelacionTipo ;
		 		  
		}
		public override void Set(ProyectoRelacionResult source,ProyectoRelacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoRelacion= source.IdProyectoRelacion ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdProyectoRelacionado= source.IdProyectoRelacionado ;
		 target.IdProyectoRelacionTipo= source.IdProyectoRelacionTipo ;
		 
		}
		public override void Set(ProyectoRelacion source,ProyectoRelacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoRelacion= source.IdProyectoRelacion ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdProyectoRelacionado= source.IdProyectoRelacionado ;
		 target.IdProyectoRelacionTipo= source.IdProyectoRelacionTipo ;
		 	
		}		
		public override void Set(ProyectoRelacionResult source,ProyectoRelacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoRelacion= source.IdProyectoRelacion ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdProyectoRelacionado= source.IdProyectoRelacionado ;
		 target.IdProyectoRelacionTipo= source.IdProyectoRelacionTipo ;
		 target.ProyectoRelacionado_IdTipoProyecto= source.ProyectoRelacionado_IdTipoProyecto;	
			target.ProyectoRelacionado_IdSubPrograma= source.ProyectoRelacionado_IdSubPrograma;	
			target.ProyectoRelacionado_Codigo= source.ProyectoRelacionado_Codigo;	
			target.ProyectoRelacionado_ProyectoDenominacion= source.ProyectoRelacionado_ProyectoDenominacion;	
			target.ProyectoRelacionado_ProyectoSituacionActual= source.ProyectoRelacionado_ProyectoSituacionActual;	
			target.ProyectoRelacionado_ProyectoDescripcion= source.ProyectoRelacionado_ProyectoDescripcion;	
			target.ProyectoRelacionado_ProyectoObservacion= source.ProyectoRelacionado_ProyectoObservacion;	
			target.ProyectoRelacionado_IdEstado= source.ProyectoRelacionado_IdEstado;	
			target.ProyectoRelacionado_IdProceso= source.ProyectoRelacionado_IdProceso;	
			target.ProyectoRelacionado_IdModalidadContratacion= source.ProyectoRelacionado_IdModalidadContratacion;	
			target.ProyectoRelacionado_IdFinalidadFuncion= source.ProyectoRelacionado_IdFinalidadFuncion;	
			target.ProyectoRelacionado_IdOrganismoPrioridad= source.ProyectoRelacionado_IdOrganismoPrioridad;	
			target.ProyectoRelacionado_SubPrioridad= source.ProyectoRelacionado_SubPrioridad;	
			target.ProyectoRelacionado_EsBorrador= source.ProyectoRelacionado_EsBorrador;	
			target.ProyectoRelacionado_EsProyecto= source.ProyectoRelacionado_EsProyecto;	
			target.ProyectoRelacionado_NroProyecto= source.ProyectoRelacionado_NroProyecto;	
			target.ProyectoRelacionado_AnioCorriente= source.ProyectoRelacionado_AnioCorriente;	
			target.ProyectoRelacionado_FechaInicioEjecucionCalculada= source.ProyectoRelacionado_FechaInicioEjecucionCalculada;	
			target.ProyectoRelacionado_FechaFinEjecucionCalculada= source.ProyectoRelacionado_FechaFinEjecucionCalculada;	
			target.ProyectoRelacionado_FechaAlta= source.ProyectoRelacionado_FechaAlta;	
			target.ProyectoRelacionado_FechaModificacion= source.ProyectoRelacionado_FechaModificacion;	
			target.ProyectoRelacionado_IdUsuarioModificacion= source.ProyectoRelacionado_IdUsuarioModificacion;	
			target.ProyectoRelacionado_IdProyectoPlan= source.ProyectoRelacionado_IdProyectoPlan;	
			target.ProyectoRelacionado_EvaluarValidaciones= source.ProyectoRelacionado_EvaluarValidaciones;	
			target.Proyecto_IdTipoProyecto= source.Proyecto_IdTipoProyecto;	
			target.Proyecto_IdSubPrograma= source.Proyecto_IdSubPrograma;	
			target.Proyecto_Codigo= source.Proyecto_Codigo;	
			target.Proyecto_ProyectoDenominacion= source.Proyecto_ProyectoDenominacion;	
			target.Proyecto_ProyectoSituacionActual= source.Proyecto_ProyectoSituacionActual;	
			target.Proyecto_ProyectoDescripcion= source.Proyecto_ProyectoDescripcion;	
			target.Proyecto_ProyectoObservacion= source.Proyecto_ProyectoObservacion;	
			target.Proyecto_IdEstado= source.Proyecto_IdEstado;	
			target.Proyecto_IdProceso= source.Proyecto_IdProceso;	
			target.Proyecto_IdModalidadContratacion= source.Proyecto_IdModalidadContratacion;	
			target.Proyecto_IdFinalidadFuncion= source.Proyecto_IdFinalidadFuncion;	
			target.Proyecto_IdOrganismoPrioridad= source.Proyecto_IdOrganismoPrioridad;	
			target.Proyecto_SubPrioridad= source.Proyecto_SubPrioridad;	
			target.Proyecto_EsBorrador= source.Proyecto_EsBorrador;	
			target.Proyecto_EsProyecto= source.Proyecto_EsProyecto;	
			target.Proyecto_NroProyecto= source.Proyecto_NroProyecto;	
			target.Proyecto_AnioCorriente= source.Proyecto_AnioCorriente;	
			target.Proyecto_FechaInicioEjecucionCalculada= source.Proyecto_FechaInicioEjecucionCalculada;	
			target.Proyecto_FechaFinEjecucionCalculada= source.Proyecto_FechaFinEjecucionCalculada;	
			target.Proyecto_FechaAlta= source.Proyecto_FechaAlta;	
			target.Proyecto_FechaModificacion= source.Proyecto_FechaModificacion;	
			target.Proyecto_IdUsuarioModificacion= source.Proyecto_IdUsuarioModificacion;	
			target.Proyecto_IdProyectoPlan= source.Proyecto_IdProyectoPlan;	
			target.Proyecto_EvaluarValidaciones= source.Proyecto_EvaluarValidaciones;	
			target.ProyectoRelacionTipo_Nombre= source.ProyectoRelacionTipo_Nombre;	
			target.ProyectoRelacionTipo_Activo= source.ProyectoRelacionTipo_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoRelacion source,ProyectoRelacion target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoRelacion.Equals(target.IdProyectoRelacion))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if(!source.IdProyectoRelacionado.Equals(target.IdProyectoRelacionado))return false;
		  if(!source.IdProyectoRelacionTipo.Equals(target.IdProyectoRelacionTipo))return false;
		 
		  return true;
        }
		public override bool Equals(ProyectoRelacionResult source,ProyectoRelacionResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoRelacion.Equals(target.IdProyectoRelacion))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if(!source.IdProyectoRelacionado.Equals(target.IdProyectoRelacionado))return false;
		  if(!source.IdProyectoRelacionTipo.Equals(target.IdProyectoRelacionTipo))return false;
		  if(!source.ProyectoRelacionado_IdTipoProyecto.Equals(target.ProyectoRelacionado_IdTipoProyecto))return false;
					  if(!source.ProyectoRelacionado_IdSubPrograma.Equals(target.ProyectoRelacionado_IdSubPrograma))return false;
					  if(!source.ProyectoRelacionado_Codigo.Equals(target.ProyectoRelacionado_Codigo))return false;
					  if((source.ProyectoRelacionado_ProyectoDenominacion == null)?target.ProyectoRelacionado_ProyectoDenominacion!=null:!source.ProyectoRelacionado_ProyectoDenominacion.Equals(target.ProyectoRelacionado_ProyectoDenominacion))return false;
						 if((source.ProyectoRelacionado_ProyectoSituacionActual == null)?target.ProyectoRelacionado_ProyectoSituacionActual!=null:!source.ProyectoRelacionado_ProyectoSituacionActual.Equals(target.ProyectoRelacionado_ProyectoSituacionActual))return false;
						 if((source.ProyectoRelacionado_ProyectoDescripcion == null)?target.ProyectoRelacionado_ProyectoDescripcion!=null:!source.ProyectoRelacionado_ProyectoDescripcion.Equals(target.ProyectoRelacionado_ProyectoDescripcion))return false;
						 if((source.ProyectoRelacionado_ProyectoObservacion == null)?target.ProyectoRelacionado_ProyectoObservacion!=null:!source.ProyectoRelacionado_ProyectoObservacion.Equals(target.ProyectoRelacionado_ProyectoObservacion))return false;
						 if(!source.ProyectoRelacionado_IdEstado.Equals(target.ProyectoRelacionado_IdEstado))return false;
					  if((source.ProyectoRelacionado_IdProceso == null)?(target.ProyectoRelacionado_IdProceso.HasValue && target.ProyectoRelacionado_IdProceso.Value > 0):!source.ProyectoRelacionado_IdProceso.Equals(target.ProyectoRelacionado_IdProceso))return false;
									  if((source.ProyectoRelacionado_IdModalidadContratacion == null)?(target.ProyectoRelacionado_IdModalidadContratacion.HasValue && target.ProyectoRelacionado_IdModalidadContratacion.Value > 0):!source.ProyectoRelacionado_IdModalidadContratacion.Equals(target.ProyectoRelacionado_IdModalidadContratacion))return false;
									  if((source.ProyectoRelacionado_IdFinalidadFuncion == null)?(target.ProyectoRelacionado_IdFinalidadFuncion.HasValue && target.ProyectoRelacionado_IdFinalidadFuncion.Value > 0):!source.ProyectoRelacionado_IdFinalidadFuncion.Equals(target.ProyectoRelacionado_IdFinalidadFuncion))return false;
									  if((source.ProyectoRelacionado_IdOrganismoPrioridad == null)?(target.ProyectoRelacionado_IdOrganismoPrioridad.HasValue && target.ProyectoRelacionado_IdOrganismoPrioridad.Value > 0):!source.ProyectoRelacionado_IdOrganismoPrioridad.Equals(target.ProyectoRelacionado_IdOrganismoPrioridad))return false;
									  if((source.ProyectoRelacionado_SubPrioridad == null)?(target.ProyectoRelacionado_SubPrioridad.HasValue ):!source.ProyectoRelacionado_SubPrioridad.Equals(target.ProyectoRelacionado_SubPrioridad))return false;
						 if(!source.ProyectoRelacionado_EsBorrador.Equals(target.ProyectoRelacionado_EsBorrador))return false;
					  if((source.ProyectoRelacionado_EsProyecto == null)?(target.ProyectoRelacionado_EsProyecto.HasValue ):!source.ProyectoRelacionado_EsProyecto.Equals(target.ProyectoRelacionado_EsProyecto))return false;
						 if((source.ProyectoRelacionado_NroProyecto == null)?(target.ProyectoRelacionado_NroProyecto.HasValue ):!source.ProyectoRelacionado_NroProyecto.Equals(target.ProyectoRelacionado_NroProyecto))return false;
						 if((source.ProyectoRelacionado_AnioCorriente == null)?(target.ProyectoRelacionado_AnioCorriente.HasValue ):!source.ProyectoRelacionado_AnioCorriente.Equals(target.ProyectoRelacionado_AnioCorriente))return false;
						 if((source.ProyectoRelacionado_FechaInicioEjecucionCalculada == null)?(target.ProyectoRelacionado_FechaInicioEjecucionCalculada.HasValue ):!source.ProyectoRelacionado_FechaInicioEjecucionCalculada.Equals(target.ProyectoRelacionado_FechaInicioEjecucionCalculada))return false;
						 if((source.ProyectoRelacionado_FechaFinEjecucionCalculada == null)?(target.ProyectoRelacionado_FechaFinEjecucionCalculada.HasValue ):!source.ProyectoRelacionado_FechaFinEjecucionCalculada.Equals(target.ProyectoRelacionado_FechaFinEjecucionCalculada))return false;
						 if(!source.ProyectoRelacionado_FechaAlta.Equals(target.ProyectoRelacionado_FechaAlta))return false;
					  if(!source.ProyectoRelacionado_FechaModificacion.Equals(target.ProyectoRelacionado_FechaModificacion))return false;
					  if(!source.ProyectoRelacionado_IdUsuarioModificacion.Equals(target.ProyectoRelacionado_IdUsuarioModificacion))return false;
					  if((source.ProyectoRelacionado_IdProyectoPlan == null)?(target.ProyectoRelacionado_IdProyectoPlan.HasValue ):!source.ProyectoRelacionado_IdProyectoPlan.Equals(target.ProyectoRelacionado_IdProyectoPlan))return false;
						 if(!source.ProyectoRelacionado_EvaluarValidaciones.Equals(target.ProyectoRelacionado_EvaluarValidaciones))return false;
					  if(!source.Proyecto_IdTipoProyecto.Equals(target.Proyecto_IdTipoProyecto))return false;
					  if(!source.Proyecto_IdSubPrograma.Equals(target.Proyecto_IdSubPrograma))return false;
					  if(!source.Proyecto_Codigo.Equals(target.Proyecto_Codigo))return false;
					  if((source.Proyecto_ProyectoDenominacion == null)?target.Proyecto_ProyectoDenominacion!=null:!source.Proyecto_ProyectoDenominacion.Equals(target.Proyecto_ProyectoDenominacion))return false;
						 if((source.Proyecto_ProyectoSituacionActual == null)?target.Proyecto_ProyectoSituacionActual!=null:!source.Proyecto_ProyectoSituacionActual.Equals(target.Proyecto_ProyectoSituacionActual))return false;
						 if((source.Proyecto_ProyectoDescripcion == null)?target.Proyecto_ProyectoDescripcion!=null:!source.Proyecto_ProyectoDescripcion.Equals(target.Proyecto_ProyectoDescripcion))return false;
						 if((source.Proyecto_ProyectoObservacion == null)?target.Proyecto_ProyectoObservacion!=null:!source.Proyecto_ProyectoObservacion.Equals(target.Proyecto_ProyectoObservacion))return false;
						 if(!source.Proyecto_IdEstado.Equals(target.Proyecto_IdEstado))return false;
					  if((source.Proyecto_IdProceso == null)?(target.Proyecto_IdProceso.HasValue && target.Proyecto_IdProceso.Value > 0):!source.Proyecto_IdProceso.Equals(target.Proyecto_IdProceso))return false;
									  if((source.Proyecto_IdModalidadContratacion == null)?(target.Proyecto_IdModalidadContratacion.HasValue && target.Proyecto_IdModalidadContratacion.Value > 0):!source.Proyecto_IdModalidadContratacion.Equals(target.Proyecto_IdModalidadContratacion))return false;
									  if((source.Proyecto_IdFinalidadFuncion == null)?(target.Proyecto_IdFinalidadFuncion.HasValue && target.Proyecto_IdFinalidadFuncion.Value > 0):!source.Proyecto_IdFinalidadFuncion.Equals(target.Proyecto_IdFinalidadFuncion))return false;
									  if((source.Proyecto_IdOrganismoPrioridad == null)?(target.Proyecto_IdOrganismoPrioridad.HasValue && target.Proyecto_IdOrganismoPrioridad.Value > 0):!source.Proyecto_IdOrganismoPrioridad.Equals(target.Proyecto_IdOrganismoPrioridad))return false;
									  if((source.Proyecto_SubPrioridad == null)?(target.Proyecto_SubPrioridad.HasValue ):!source.Proyecto_SubPrioridad.Equals(target.Proyecto_SubPrioridad))return false;
						 if(!source.Proyecto_EsBorrador.Equals(target.Proyecto_EsBorrador))return false;
					  if((source.Proyecto_EsProyecto == null)?(target.Proyecto_EsProyecto.HasValue ):!source.Proyecto_EsProyecto.Equals(target.Proyecto_EsProyecto))return false;
						 if((source.Proyecto_NroProyecto == null)?(target.Proyecto_NroProyecto.HasValue ):!source.Proyecto_NroProyecto.Equals(target.Proyecto_NroProyecto))return false;
						 if((source.Proyecto_AnioCorriente == null)?(target.Proyecto_AnioCorriente.HasValue ):!source.Proyecto_AnioCorriente.Equals(target.Proyecto_AnioCorriente))return false;
						 if((source.Proyecto_FechaInicioEjecucionCalculada == null)?(target.Proyecto_FechaInicioEjecucionCalculada.HasValue ):!source.Proyecto_FechaInicioEjecucionCalculada.Equals(target.Proyecto_FechaInicioEjecucionCalculada))return false;
						 if((source.Proyecto_FechaFinEjecucionCalculada == null)?(target.Proyecto_FechaFinEjecucionCalculada.HasValue ):!source.Proyecto_FechaFinEjecucionCalculada.Equals(target.Proyecto_FechaFinEjecucionCalculada))return false;
						 if(!source.Proyecto_FechaAlta.Equals(target.Proyecto_FechaAlta))return false;
					  if(!source.Proyecto_FechaModificacion.Equals(target.Proyecto_FechaModificacion))return false;
					  if(!source.Proyecto_IdUsuarioModificacion.Equals(target.Proyecto_IdUsuarioModificacion))return false;
					  if((source.Proyecto_IdProyectoPlan == null)?(target.Proyecto_IdProyectoPlan.HasValue ):!source.Proyecto_IdProyectoPlan.Equals(target.Proyecto_IdProyectoPlan))return false;
						 if(!source.Proyecto_EvaluarValidaciones.Equals(target.Proyecto_EvaluarValidaciones))return false;
					  if((source.ProyectoRelacionTipo_Nombre == null)?target.ProyectoRelacionTipo_Nombre!=null:!source.ProyectoRelacionTipo_Nombre.Equals(target.ProyectoRelacionTipo_Nombre))return false;
						 if(!source.ProyectoRelacionTipo_Activo.Equals(target.ProyectoRelacionTipo_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}

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
    public abstract class _ProyectoFinData : EntityData<ProyectoFin,ProyectoFinFilter,ProyectoFinResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoFin entity)
		{			
			return entity.IdProyectoFin;
		}		
		public override ProyectoFin GetByEntity(ProyectoFin entity)
        {
            return this.GetById(entity.IdProyectoFin);
        }
        public override ProyectoFin GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoFin == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoFin> Query(ProyectoFinFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoFin == null || o.IdProyectoFin >=  filter.IdProyectoFin) && (filter.IdProyectoFin_To == null || o.IdProyectoFin <= filter.IdProyectoFin_To)
					  && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto==filter.IdProyecto)
					  && (filter.IdProgramaObjetivo == null || filter.IdProgramaObjetivo == 0 || o.IdProgramaObjetivo==filter.IdProgramaObjetivo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoFinResult> QueryResult(ProyectoFinFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.ProgramaObjetivos on o.IdProgramaObjetivo equals t1.IdProgramaObjetivo   
				    join t2  in this.Context.Proyectos on o.IdProyecto equals t2.IdProyecto   
				   select new ProyectoFinResult(){
					 IdProyectoFin=o.IdProyectoFin
					 ,IdProyecto=o.IdProyecto
					 ,IdProgramaObjetivo=o.IdProgramaObjetivo
                    //,ProgramaObjetivo_IdPrograma= t1.IdPrograma	
                    //    ,ProgramaObjetivo_IDObjetivo= t1.IDObjetivo	
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
                    //    ,Proyecto_Activo= t2.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoFin Copy(nc.ProyectoFin entity)
        {           
            nc.ProyectoFin _new = new nc.ProyectoFin();
		 _new.IdProyecto= entity.IdProyecto;
		 _new.IdProgramaObjetivo= entity.IdProgramaObjetivo;
		return _new;			
        }
		public override int CopyAndSave(ProyectoFin entity,string renameFormat)
        {
            ProyectoFin  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoFin entity, int id)
        {            
            entity.IdProyectoFin = id;            
        }
		public override void Set(ProyectoFin source,ProyectoFin target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoFin= source.IdProyectoFin ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdProgramaObjetivo= source.IdProgramaObjetivo ;
		 		  
		}
		public override void Set(ProyectoFinResult source,ProyectoFin target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoFin= source.IdProyectoFin ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdProgramaObjetivo= source.IdProgramaObjetivo ;
		 
		}
		public override void Set(ProyectoFin source,ProyectoFinResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoFin= source.IdProyectoFin ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdProgramaObjetivo= source.IdProgramaObjetivo ;
		 	
		}		
		public override void Set(ProyectoFinResult source,ProyectoFinResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoFin= source.IdProyectoFin ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdProgramaObjetivo= source.IdProgramaObjetivo ;
         //target.ProgramaObjetivo_IdPrograma= source.ProgramaObjetivo_IdPrograma;	
         //   target.ProgramaObjetivo_IDObjetivo= source.ProgramaObjetivo_IDObjetivo;	
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
         //   target.Proyecto_Activo= source.Proyecto_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoFin source,ProyectoFin target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoFin.Equals(target.IdProyectoFin))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if(!source.IdProgramaObjetivo.Equals(target.IdProgramaObjetivo))return false;
		 
		  return true;
        }
		public override bool Equals(ProyectoFinResult source,ProyectoFinResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoFin.Equals(target.IdProyectoFin))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if(!source.IdProgramaObjetivo.Equals(target.IdProgramaObjetivo))return false;
          //if(!source.ProgramaObjetivo_IdPrograma.Equals(target.ProgramaObjetivo_IdPrograma))return false;
          //            if(!source.ProgramaObjetivo_IDObjetivo.Equals(target.ProgramaObjetivo_IDObjetivo))return false;
          //            if(!source.Proyecto_IdTipoProyecto.Equals(target.Proyecto_IdTipoProyecto))return false;
          //            if(!source.Proyecto_IdSubPrograma.Equals(target.Proyecto_IdSubPrograma))return false;
          //            if(!source.Proyecto_Codigo.Equals(target.Proyecto_Codigo))return false;
          //            if((source.Proyecto_ProyectoDenominacion == null)?target.Proyecto_ProyectoDenominacion!=null: !( (target.Proyecto_ProyectoDenominacion== String.Empty && source.Proyecto_ProyectoDenominacion== null) || (target.Proyecto_ProyectoDenominacion==null && source.Proyecto_ProyectoDenominacion== String.Empty )) &&   !source.Proyecto_ProyectoDenominacion.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoDenominacion.Trim().Replace ("\r","")))return false;
          //               if((source.Proyecto_ProyectoSituacionActual == null)?target.Proyecto_ProyectoSituacionActual!=null: !( (target.Proyecto_ProyectoSituacionActual== String.Empty && source.Proyecto_ProyectoSituacionActual== null) || (target.Proyecto_ProyectoSituacionActual==null && source.Proyecto_ProyectoSituacionActual== String.Empty )) &&   !source.Proyecto_ProyectoSituacionActual.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoSituacionActual.Trim().Replace ("\r","")))return false;
          //               if((source.Proyecto_ProyectoDescripcion == null)?target.Proyecto_ProyectoDescripcion!=null: !( (target.Proyecto_ProyectoDescripcion== String.Empty && source.Proyecto_ProyectoDescripcion== null) || (target.Proyecto_ProyectoDescripcion==null && source.Proyecto_ProyectoDescripcion== String.Empty )) &&   !source.Proyecto_ProyectoDescripcion.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoDescripcion.Trim().Replace ("\r","")))return false;
          //               if((source.Proyecto_ProyectoObservacion == null)?target.Proyecto_ProyectoObservacion!=null: !( (target.Proyecto_ProyectoObservacion== String.Empty && source.Proyecto_ProyectoObservacion== null) || (target.Proyecto_ProyectoObservacion==null && source.Proyecto_ProyectoObservacion== String.Empty )) &&   !source.Proyecto_ProyectoObservacion.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoObservacion.Trim().Replace ("\r","")))return false;
          //               if(!source.Proyecto_IdEstado.Equals(target.Proyecto_IdEstado))return false;
          //            if((source.Proyecto_IdProceso == null)?(target.Proyecto_IdProceso.HasValue && target.Proyecto_IdProceso.Value > 0):!source.Proyecto_IdProceso.Equals(target.Proyecto_IdProceso))return false;
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

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
    public abstract class _ProyectoPropositoData : EntityData<ProyectoProposito,ProyectoPropositoFilter,ProyectoPropositoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoProposito entity)
		{			
			return entity.IdProyectoProposito;
		}		
		public override ProyectoProposito GetByEntity(ProyectoProposito entity)
        {
            return this.GetById(entity.IdProyectoProposito);
        }
        public override ProyectoProposito GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoProposito == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoProposito> Query(ProyectoPropositoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoProposito == null || o.IdProyectoProposito >=  filter.IdProyectoProposito) && (filter.IdProyectoProposito_To == null || o.IdProyectoProposito <= filter.IdProyectoProposito_To)
					  && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto==filter.IdProyecto)
					  && (filter.IdObjetivo == null || filter.IdObjetivo == 0 || o.IdObjetivo==filter.IdObjetivo)
                      orderby o.IdProyectoProposito
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoPropositoResult> QueryResult(ProyectoPropositoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Objetivos on o.IdObjetivo equals t1.IdObjetivo   
				    join t2  in this.Context.Proyectos on o.IdProyecto equals t2.IdProyecto   
				   select new ProyectoPropositoResult(){
					 IdProyectoProposito=o.IdProyectoProposito
					 ,IdProyecto=o.IdProyecto
					 ,IdObjetivo=o.IdObjetivo
					,Objetivo_Nombre= t1.Nombre	
                        //,Proyecto_IdTipoProyecto= t2.IdTipoProyecto	
                        //,Proyecto_IdSubPrograma= t2.IdSubPrograma	
                        //,Proyecto_Codigo= t2.Codigo	
                        //,Proyecto_ProyectoDenominacion= t2.ProyectoDenominacion	
                        //,Proyecto_ProyectoSituacionActual= t2.ProyectoSituacionActual	
                        //,Proyecto_ProyectoDescripcion= t2.ProyectoDescripcion	
                        //,Proyecto_ProyectoObservacion= t2.ProyectoObservacion	
                        //,Proyecto_IdEstado= t2.IdEstado	
                        //,Proyecto_IdProceso= t2.IdProceso	
                        //,Proyecto_IdModalidadContratacion= t2.IdModalidadContratacion	
                        //,Proyecto_IdFinalidadFuncion= t2.IdFinalidadFuncion	
                        //,Proyecto_IdOrganismoPrioridad= t2.IdOrganismoPrioridad	
                        //,Proyecto_SubPrioridad= t2.SubPrioridad	
                        //,Proyecto_EsBorrador= t2.EsBorrador	
                        //,Proyecto_EsProyecto= t2.EsProyecto	
                        //,Proyecto_NroProyecto= t2.NroProyecto	
                        //,Proyecto_AnioCorriente= t2.AnioCorriente	
                        //,Proyecto_FechaInicioEjecucionCalculada= t2.FechaInicioEjecucionCalculada	
                        //,Proyecto_FechaFinEjecucionCalculada= t2.FechaFinEjecucionCalculada	
                        //,Proyecto_FechaAlta= t2.FechaAlta	
                        //,Proyecto_FechaModificacion= t2.FechaModificacion	
                        //,Proyecto_IdUsuarioModificacion= t2.IdUsuarioModificacion	
                        //,Proyecto_IdProyectoPlan= t2.IdProyectoPlan	
                        //,Proyecto_EvaluarValidaciones= t2.EvaluarValidaciones	
                        //,Proyecto_Activo= t2.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoProposito Copy(nc.ProyectoProposito entity)
        {           
            nc.ProyectoProposito _new = new nc.ProyectoProposito();
		 _new.IdProyecto= entity.IdProyecto;
		 _new.IdObjetivo= entity.IdObjetivo;
		return _new;			
        }
		public override int CopyAndSave(ProyectoProposito entity,string renameFormat)
        {
            ProyectoProposito  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoProposito entity, int id)
        {            
            entity.IdProyectoProposito = id;            
        }
		public override void Set(ProyectoProposito source,ProyectoProposito target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoProposito= source.IdProyectoProposito ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdObjetivo= source.IdObjetivo ;
		 		  
		}
		public override void Set(ProyectoPropositoResult source,ProyectoProposito target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoProposito= source.IdProyectoProposito ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdObjetivo= source.IdObjetivo ;
		 
		}
		public override void Set(ProyectoProposito source,ProyectoPropositoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoProposito= source.IdProyectoProposito ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdObjetivo= source.IdObjetivo ;
		 	
		}		
		public override void Set(ProyectoPropositoResult source,ProyectoPropositoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoProposito= source.IdProyectoProposito ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdObjetivo= source.IdObjetivo ;
		 target.Objetivo_Nombre= source.Objetivo_Nombre;	
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
		public override bool Equals(ProyectoProposito source,ProyectoProposito target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoProposito.Equals(target.IdProyectoProposito))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if(!source.IdObjetivo.Equals(target.IdObjetivo))return false;
		 
		  return true;
        }
		public override bool Equals(ProyectoPropositoResult source,ProyectoPropositoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoProposito.Equals(target.IdProyectoProposito))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if(!source.IdObjetivo.Equals(target.IdObjetivo))return false;
		  if((source.Objetivo_Nombre == null)?target.Objetivo_Nombre!=null: !( (target.Objetivo_Nombre== String.Empty && source.Objetivo_Nombre== null) || (target.Objetivo_Nombre==null && source.Objetivo_Nombre== String.Empty )) &&   !source.Objetivo_Nombre.Trim().Replace ("\r","").Equals(target.Objetivo_Nombre.Trim().Replace ("\r","")))return false;
                      //   if(!source.Proyecto_IdTipoProyecto.Equals(target.Proyecto_IdTipoProyecto))return false;
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

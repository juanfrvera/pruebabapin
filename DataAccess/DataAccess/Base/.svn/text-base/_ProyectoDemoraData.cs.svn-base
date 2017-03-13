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
    public abstract class _ProyectoDemoraData : EntityData<ProyectoDemora,ProyectoDemoraFilter,ProyectoDemoraResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoDemora entity)
		{			
			return entity.IdProyectoDemora;
		}		
		public override ProyectoDemora GetByEntity(ProyectoDemora entity)
        {
            return this.GetById(entity.IdProyectoDemora);
        }
        public override ProyectoDemora GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoDemora == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoDemora> Query(ProyectoDemoraFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoDemora == null || o.IdProyectoDemora >=  filter.IdProyectoDemora) && (filter.IdProyectoDemora_To == null || o.IdProyectoDemora <= filter.IdProyectoDemora_To)
					  && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto==filter.IdProyecto)
					  && (filter.Justificacion == null || filter.Justificacion.Trim() == string.Empty || filter.Justificacion.Trim() == "%"  || (filter.Justificacion.EndsWith("%") && filter.Justificacion.StartsWith("%") && (o.Justificacion.Contains(filter.Justificacion.Replace("%", "")))) || (filter.Justificacion.EndsWith("%") && o.Justificacion.StartsWith(filter.Justificacion.Replace("%",""))) || (filter.Justificacion.StartsWith("%") && o.Justificacion.EndsWith(filter.Justificacion.Replace("%",""))) || o.Justificacion == filter.Justificacion )
					  && (filter.Fecha == null || filter.Fecha == DateTime.MinValue || o.Fecha >=  filter.Fecha) && (filter.Fecha_To == null || filter.Fecha_To == DateTime.MinValue || o.Fecha <= filter.Fecha_To)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoDemoraResult> QueryResult(ProyectoDemoraFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Proyectos on o.IdProyecto equals t1.IdProyecto   
				   select new ProyectoDemoraResult(){
					 IdProyectoDemora=o.IdProyectoDemora
					 ,IdProyecto=o.IdProyecto
					 ,Justificacion=o.Justificacion
					 ,Fecha=o.Fecha
                    //,Proyecto_IdTipoProyecto= t1.IdTipoProyecto	
                    //    ,Proyecto_IdSubPrograma= t1.IdSubPrograma	
                    //    ,Proyecto_Codigo= t1.Codigo	
                    //    ,Proyecto_ProyectoDenominacion= t1.ProyectoDenominacion	
                    //    ,Proyecto_ProyectoSituacionActual= t1.ProyectoSituacionActual	
                    //    ,Proyecto_ProyectoDescripcion= t1.ProyectoDescripcion	
                    //    ,Proyecto_ProyectoObservacion= t1.ProyectoObservacion	
                    //    ,Proyecto_IdEstado= t1.IdEstado	
                    //    ,Proyecto_IdProceso= t1.IdProceso	
                    //    ,Proyecto_IdModalidadContratacion= t1.IdModalidadContratacion	
                    //    ,Proyecto_IdFinalidadFuncion= t1.IdFinalidadFuncion	
                    //    ,Proyecto_IdOrganismoPrioridad= t1.IdOrganismoPrioridad	
                    //    ,Proyecto_SubPrioridad= t1.SubPrioridad	
                    //    ,Proyecto_EsBorrador= t1.EsBorrador	
                    //    ,Proyecto_EsProyecto= t1.EsProyecto	
                    //    ,Proyecto_NroProyecto= t1.NroProyecto	
                    //    ,Proyecto_AnioCorriente= t1.AnioCorriente	
                    //    ,Proyecto_FechaInicioEjecucionCalculada= t1.FechaInicioEjecucionCalculada	
                    //    ,Proyecto_FechaFinEjecucionCalculada= t1.FechaFinEjecucionCalculada	
                    //    ,Proyecto_FechaAlta= t1.FechaAlta	
                    //    ,Proyecto_FechaModificacion= t1.FechaModificacion	
                    //    ,Proyecto_IdUsuarioModificacion= t1.IdUsuarioModificacion	
                    //    ,Proyecto_IdProyectoPlan= t1.IdProyectoPlan	
                    //    ,Proyecto_EvaluarValidaciones= t1.EvaluarValidaciones	
                    //    ,Proyecto_Activo= t1.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoDemora Copy(nc.ProyectoDemora entity)
        {           
            nc.ProyectoDemora _new = new nc.ProyectoDemora();
		 _new.IdProyecto= entity.IdProyecto;
		 _new.Justificacion= entity.Justificacion;
		 _new.Fecha= entity.Fecha;
		return _new;			
        }
		public override int CopyAndSave(ProyectoDemora entity,string renameFormat)
        {
            ProyectoDemora  newEntity = Copy(entity);
            newEntity.Justificacion = string.Format(renameFormat,newEntity.Justificacion);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoDemora entity, int id)
        {            
            entity.IdProyectoDemora = id;            
        }
		public override void Set(ProyectoDemora source,ProyectoDemora target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoDemora= source.IdProyectoDemora ;
		 target.IdProyecto= source.IdProyecto ;
		 target.Justificacion= source.Justificacion ;
		 target.Fecha= source.Fecha ;
		 		  
		}
		public override void Set(ProyectoDemoraResult source,ProyectoDemora target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoDemora= source.IdProyectoDemora ;
		 target.IdProyecto= source.IdProyecto ;
		 target.Justificacion= source.Justificacion ;
		 target.Fecha= source.Fecha ;
		 
		}
		public override void Set(ProyectoDemora source,ProyectoDemoraResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoDemora= source.IdProyectoDemora ;
		 target.IdProyecto= source.IdProyecto ;
		 target.Justificacion= source.Justificacion ;
		 target.Fecha= source.Fecha ;
		 	
		}		
		public override void Set(ProyectoDemoraResult source,ProyectoDemoraResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoDemora= source.IdProyectoDemora ;
		 target.IdProyecto= source.IdProyecto ;
		 target.Justificacion= source.Justificacion ;
		 target.Fecha= source.Fecha ;
         //target.Proyecto_IdTipoProyecto= source.Proyecto_IdTipoProyecto;	
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
		public override bool Equals(ProyectoDemora source,ProyectoDemora target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoDemora.Equals(target.IdProyectoDemora))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if((source.Justificacion == null)?target.Justificacion!=null:  !( (target.Justificacion== String.Empty && source.Justificacion== null) || (target.Justificacion==null && source.Justificacion== String.Empty )) &&  !source.Justificacion.Trim().Replace ("\r","").Equals(target.Justificacion.Trim().Replace ("\r","")))return false;
			 if(!source.Fecha.Equals(target.Fecha))return false;
		 
		  return true;
        }
		public override bool Equals(ProyectoDemoraResult source,ProyectoDemoraResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoDemora.Equals(target.IdProyectoDemora))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if((source.Justificacion == null)?target.Justificacion!=null: !( (target.Justificacion== String.Empty && source.Justificacion== null) || (target.Justificacion==null && source.Justificacion== String.Empty )) && !source.Justificacion.Trim().Replace ("\r","").Equals(target.Justificacion.Trim().Replace ("\r","")))return false;
			 if(!source.Fecha.Equals(target.Fecha))return false;
          //if(!source.Proyecto_IdTipoProyecto.Equals(target.Proyecto_IdTipoProyecto))return false;
          //            if(!source.Proyecto_IdSubPrograma.Equals(target.Proyecto_IdSubPrograma))return false;
          //            if(!source.Proyecto_Codigo.Equals(target.Proyecto_Codigo))return false;
          //            if((source.Proyecto_ProyectoDenominacion == null)?target.Proyecto_ProyectoDenominacion!=null: !( (target.Proyecto_ProyectoDenominacion== String.Empty && source.Proyecto_ProyectoDenominacion== null) || (target.Proyecto_ProyectoDenominacion==null && source.Proyecto_ProyectoDenominacion== String.Empty )) &&   !source.Proyecto_ProyectoDenominacion.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoDenominacion.Trim().Replace ("\r","")))return false;
          //               if((source.Proyecto_ProyectoSituacionActual == null)?target.Proyecto_ProyectoSituacionActual!=null: !( (target.Proyecto_ProyectoSituacionActual== String.Empty && source.Proyecto_ProyectoSituacionActual== null) || (target.Proyecto_ProyectoSituacionActual==null && source.Proyecto_ProyectoSituacionActual== String.Empty )) &&   !source.Proyecto_ProyectoSituacionActual.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoSituacionActual.Trim().Replace ("\r","")))return false;
          //               if((source.Proyecto_ProyectoDescripcion == null)?target.Proyecto_ProyectoDescripcion!=null: !( (target.Proyecto_ProyectoDescripcion== String.Empty && source.Proyecto_ProyectoDescripcion== null) || (target.Proyecto_ProyectoDescripcion==null && source.Proyecto_ProyectoDescripcion== String.Empty )) &&   !source.Proyecto_ProyectoDescripcion.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoDescripcion.Trim().Replace ("\r","")))return false;
          //               if((source.Proyecto_ProyectoObservacion == null)?target.Proyecto_ProyectoObservacion!=null: !( (target.Proyecto_ProyectoObservacion== String.Empty && source.Proyecto_ProyectoObservacion== null) || (target.Proyecto_ProyectoObservacion==null && source.Proyecto_ProyectoObservacion== String.Empty )) &&   !source.Proyecto_ProyectoObservacion.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoObservacion.Trim().Replace ("\r","")))return false;
          //               if(!source.Proyecto_IdEstado.Equals(target.Proyecto_IdEstado))return false;
          //            if((source.Proyecto_IdProceso == null)?(target.Proyecto_IdProceso.HasValue && target.Proyecto_IdProceso.Value > 0):!source.Proyecto_IdProceso.Equals(target.Proyecto_IdProceso))return false;
          //                            if((source.Proyecto_IdModalidadContratacion == null)?(target.Proyecto_IdModalidadContratacion.HasValue && target.Proyecto_IdModalidadContratacion.Value > 0):!source.Proyecto_IdModalidadContratacion.Equals(target.Proyecto_IdModalidadContratacion))return false;
          //                            if((source.Proyecto_IdFinalidadFuncion == null)?(target.Proyecto_IdFinalidadFuncion.HasValue && target.Proyecto_IdFinalidadFuncion.Value > 0):!source.Proyecto_IdFinalidadFuncion.Equals(target.Proyecto_IdFinalidadFuncion))return false;
          //                            if((source.Proyecto_IdOrganismoPrioridad == null)?(target.Proyecto_IdOrganismoPrioridad.HasValue && target.Proyecto_IdOrganismoPrioridad.Value > 0):!source.Proyecto_IdOrganismoPrioridad.Equals(target.Proyecto_IdOrganismoPrioridad))return false;
          //                            if((source.Proyecto_SubPrioridad == null)?(target.Proyecto_SubPrioridad.HasValue ):!source.Proyecto_SubPrioridad.Equals(target.Proyecto_SubPrioridad))return false;
          //               if(!source.Proyecto_EsBorrador.Equals(target.Proyecto_EsBorrador))return false;
          //            if((source.Proyecto_EsProyecto == null)?(target.Proyecto_EsProyecto.HasValue ):!source.Proyecto_EsProyecto.Equals(target.Proyecto_EsProyecto))return false;
          //               if((source.Proyecto_NroProyecto == null)?(target.Proyecto_NroProyecto.HasValue ):!source.Proyecto_NroProyecto.Equals(target.Proyecto_NroProyecto))return false;
          //               if((source.Proyecto_AnioCorriente == null)?(target.Proyecto_AnioCorriente.HasValue ):!source.Proyecto_AnioCorriente.Equals(target.Proyecto_AnioCorriente))return false;
          //               if((source.Proyecto_FechaInicioEjecucionCalculada == null)?(target.Proyecto_FechaInicioEjecucionCalculada.HasValue ):!source.Proyecto_FechaInicioEjecucionCalculada.Equals(target.Proyecto_FechaInicioEjecucionCalculada))return false;
          //               if((source.Proyecto_FechaFinEjecucionCalculada == null)?(target.Proyecto_FechaFinEjecucionCalculada.HasValue ):!source.Proyecto_FechaFinEjecucionCalculada.Equals(target.Proyecto_FechaFinEjecucionCalculada))return false;
          //               if(!source.Proyecto_FechaAlta.Equals(target.Proyecto_FechaAlta))return false;
          //            if(!source.Proyecto_FechaModificacion.Equals(target.Proyecto_FechaModificacion))return false;
          //            if(!source.Proyecto_IdUsuarioModificacion.Equals(target.Proyecto_IdUsuarioModificacion))return false;
          //            if((source.Proyecto_IdProyectoPlan == null)?(target.Proyecto_IdProyectoPlan.HasValue ):!source.Proyecto_IdProyectoPlan.Equals(target.Proyecto_IdProyectoPlan))return false;
          //               if(!source.Proyecto_EvaluarValidaciones.Equals(target.Proyecto_EvaluarValidaciones))return false;
          //            if(!source.Proyecto_Activo.Equals(target.Proyecto_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}

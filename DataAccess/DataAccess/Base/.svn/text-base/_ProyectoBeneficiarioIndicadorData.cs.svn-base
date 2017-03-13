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
    public abstract class _ProyectoBeneficiarioIndicadorData : EntityData<ProyectoBeneficiarioIndicador,ProyectoBeneficiarioIndicadorFilter,ProyectoBeneficiarioIndicadorResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoBeneficiarioIndicador entity)
		{			
			return entity.IdProyectoBeneficiarioIndicador;
		}		
		public override ProyectoBeneficiarioIndicador GetByEntity(ProyectoBeneficiarioIndicador entity)
        {
            return this.GetById(entity.IdProyectoBeneficiarioIndicador);
        }
        public override ProyectoBeneficiarioIndicador GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoBeneficiarioIndicador == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoBeneficiarioIndicador> Query(ProyectoBeneficiarioIndicadorFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoBeneficiarioIndicador == null || o.IdProyectoBeneficiarioIndicador >=  filter.IdProyectoBeneficiarioIndicador) && (filter.IdProyectoBeneficiarioIndicador_To == null || o.IdProyectoBeneficiarioIndicador <= filter.IdProyectoBeneficiarioIndicador_To)
					  && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto==filter.IdProyecto)
					  && (filter.Beneficiario == null || filter.Beneficiario.Trim() == string.Empty || filter.Beneficiario.Trim() == "%"  || (filter.Beneficiario.EndsWith("%") && filter.Beneficiario.StartsWith("%") && (o.Beneficiario.Contains(filter.Beneficiario.Replace("%", "")))) || (filter.Beneficiario.EndsWith("%") && o.Beneficiario.StartsWith(filter.Beneficiario.Replace("%",""))) || (filter.Beneficiario.StartsWith("%") && o.Beneficiario.EndsWith(filter.Beneficiario.Replace("%",""))) || o.Beneficiario == filter.Beneficiario )
					  && (filter.Indirecto == null || o.Indirecto==filter.Indirecto)
					  && (filter.IdIndicador == null || filter.IdIndicador == 0 || o.IdIndicador==filter.IdIndicador)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoBeneficiarioIndicadorResult> QueryResult(ProyectoBeneficiarioIndicadorFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Indicadors on o.IdIndicador equals t1.IdIndicador   
				    join t2  in this.Context.Proyectos on o.IdProyecto equals t2.IdProyecto   
				   select new ProyectoBeneficiarioIndicadorResult(){
					 IdProyectoBeneficiarioIndicador=o.IdProyectoBeneficiarioIndicador
					 ,IdProyecto=o.IdProyecto
					 ,Beneficiario=o.Beneficiario
					 ,Indirecto=o.Indirecto
					 ,IdIndicador=o.IdIndicador
					,Indicador_IdMedioVerificacion= t1.IdMedioVerificacion	
						,Indicador_Observacion= t1.Observacion	
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
		public override nc.ProyectoBeneficiarioIndicador Copy(nc.ProyectoBeneficiarioIndicador entity)
        {           
            nc.ProyectoBeneficiarioIndicador _new = new nc.ProyectoBeneficiarioIndicador();
		 _new.IdProyecto= entity.IdProyecto;
		 _new.Beneficiario= entity.Beneficiario;
		 _new.Indirecto= entity.Indirecto;
		 _new.IdIndicador= entity.IdIndicador;
		return _new;			
        }
		public override int CopyAndSave(ProyectoBeneficiarioIndicador entity,string renameFormat)
        {
            ProyectoBeneficiarioIndicador  newEntity = Copy(entity);
            newEntity.Beneficiario = string.Format(renameFormat,newEntity.Beneficiario);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoBeneficiarioIndicador entity, int id)
        {            
            entity.IdProyectoBeneficiarioIndicador = id;            
        }
		public override void Set(ProyectoBeneficiarioIndicador source,ProyectoBeneficiarioIndicador target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoBeneficiarioIndicador= source.IdProyectoBeneficiarioIndicador ;
		 target.IdProyecto= source.IdProyecto ;
		 target.Beneficiario= source.Beneficiario ;
		 target.Indirecto= source.Indirecto ;
		 target.IdIndicador= source.IdIndicador ;
		 		  
		}
		public override void Set(ProyectoBeneficiarioIndicadorResult source,ProyectoBeneficiarioIndicador target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoBeneficiarioIndicador= source.IdProyectoBeneficiarioIndicador ;
		 target.IdProyecto= source.IdProyecto ;
		 target.Beneficiario= source.Beneficiario ;
		 target.Indirecto= source.Indirecto ;
		 target.IdIndicador= source.IdIndicador ;
		 
		}
		public override void Set(ProyectoBeneficiarioIndicador source,ProyectoBeneficiarioIndicadorResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoBeneficiarioIndicador= source.IdProyectoBeneficiarioIndicador ;
		 target.IdProyecto= source.IdProyecto ;
		 target.Beneficiario= source.Beneficiario ;
		 target.Indirecto= source.Indirecto ;
		 target.IdIndicador= source.IdIndicador ;
		 	
		}		
		public override void Set(ProyectoBeneficiarioIndicadorResult source,ProyectoBeneficiarioIndicadorResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoBeneficiarioIndicador= source.IdProyectoBeneficiarioIndicador ;
		 target.IdProyecto= source.IdProyecto ;
		 target.Beneficiario= source.Beneficiario ;
		 target.Indirecto= source.Indirecto ;
		 target.IdIndicador= source.IdIndicador ;
		 target.Indicador_IdMedioVerificacion= source.Indicador_IdMedioVerificacion;	
			target.Indicador_Observacion= source.Indicador_Observacion;	
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
		public override bool Equals(ProyectoBeneficiarioIndicador source,ProyectoBeneficiarioIndicador target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoBeneficiarioIndicador.Equals(target.IdProyectoBeneficiarioIndicador))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if((source.Beneficiario == null)?target.Beneficiario!=null:  !( (target.Beneficiario== String.Empty && source.Beneficiario== null) || (target.Beneficiario==null && source.Beneficiario== String.Empty )) &&  !source.Beneficiario.Trim().Replace ("\r","").Equals(target.Beneficiario.Trim().Replace ("\r","")))return false;
			 if(!source.Indirecto.Equals(target.Indirecto))return false;
		  if(!source.IdIndicador.Equals(target.IdIndicador))return false;
		 
		  return true;
        }
		public override bool Equals(ProyectoBeneficiarioIndicadorResult source,ProyectoBeneficiarioIndicadorResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoBeneficiarioIndicador.Equals(target.IdProyectoBeneficiarioIndicador))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if((source.Beneficiario == null)?target.Beneficiario!=null: !( (target.Beneficiario== String.Empty && source.Beneficiario== null) || (target.Beneficiario==null && source.Beneficiario== String.Empty )) && !source.Beneficiario.Trim().Replace ("\r","").Equals(target.Beneficiario.Trim().Replace ("\r","")))return false;
			 if(!source.Indirecto.Equals(target.Indirecto))return false;
		  if(!source.IdIndicador.Equals(target.IdIndicador))return false;
		  if((source.Indicador_IdMedioVerificacion == null)?(target.Indicador_IdMedioVerificacion.HasValue && target.Indicador_IdMedioVerificacion.Value > 0):!source.Indicador_IdMedioVerificacion.Equals(target.Indicador_IdMedioVerificacion))return false;
									  if((source.Indicador_Observacion == null)?target.Indicador_Observacion!=null: !( (target.Indicador_Observacion== String.Empty && source.Indicador_Observacion== null) || (target.Indicador_Observacion==null && source.Indicador_Observacion== String.Empty )) &&   !source.Indicador_Observacion.Trim().Replace ("\r","").Equals(target.Indicador_Observacion.Trim().Replace ("\r","")))return false;
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

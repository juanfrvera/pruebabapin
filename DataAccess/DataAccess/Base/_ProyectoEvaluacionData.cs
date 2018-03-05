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
    public abstract class _ProyectoEvaluacionData : EntityData<ProyectoEvaluacion,ProyectoEvaluacionFilter,ProyectoEvaluacionResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoEvaluacion entity)
		{			
			return entity.Id_ProyectoEvaluacion;
		}		
		public override ProyectoEvaluacion GetByEntity(ProyectoEvaluacion entity)
        {
            return this.GetById(entity.Id_ProyectoEvaluacion);
        }
        public override ProyectoEvaluacion GetById(int id)
        {
            return (from o in this.Table where o.Id_ProyectoEvaluacion == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoEvaluacion> Query(ProyectoEvaluacionFilter filter)
        {
			return (from o in this.Table
                      where (filter.Id_ProyectoEvaluacion == null || o.Id_ProyectoEvaluacion >=  filter.Id_ProyectoEvaluacion) && (filter.Id_ProyectoEvaluacion_To == null || o.Id_ProyectoEvaluacion <= filter.Id_ProyectoEvaluacion_To)
					  && (filter.Id_Proyecto == null || filter.Id_Proyecto == 0 || o.Id_Proyecto==filter.Id_Proyecto)
					  && (filter.MarcoLegal == null || filter.MarcoLegal.Trim() == string.Empty || filter.MarcoLegal.Trim() == "%"  || (filter.MarcoLegal.EndsWith("%") && filter.MarcoLegal.StartsWith("%") && (o.MarcoLegal.Contains(filter.MarcoLegal.Replace("%", "")))) || (filter.MarcoLegal.EndsWith("%") && o.MarcoLegal.StartsWith(filter.MarcoLegal.Replace("%",""))) || (filter.MarcoLegal.StartsWith("%") && o.MarcoLegal.EndsWith(filter.MarcoLegal.Replace("%",""))) || o.MarcoLegal == filter.MarcoLegal )
                      && (filter.InfoAdicional == null || filter.InfoAdicional.Trim() == string.Empty || filter.InfoAdicional.Trim() == "%" || (filter.InfoAdicional.EndsWith("%") && filter.InfoAdicional.StartsWith("%") && (o.InfoAdicional.Contains(filter.InfoAdicional.Replace("%", "")))) || (filter.InfoAdicional.EndsWith("%") && o.InfoAdicional.StartsWith(filter.InfoAdicional.Replace("%", ""))) || (filter.InfoAdicional.StartsWith("%") && o.InfoAdicional.EndsWith(filter.InfoAdicional.Replace("%", ""))) || o.InfoAdicional == filter.InfoAdicional)
					  && (filter.EstudioRealizado == null || filter.EstudioRealizado.Trim() == string.Empty || filter.EstudioRealizado.Trim() == "%"  || (filter.EstudioRealizado.EndsWith("%") && filter.EstudioRealizado.StartsWith("%") && (o.EstudioRealizado.Contains(filter.EstudioRealizado.Replace("%", "")))) || (filter.EstudioRealizado.EndsWith("%") && o.EstudioRealizado.StartsWith(filter.EstudioRealizado.Replace("%",""))) || (filter.EstudioRealizado.StartsWith("%") && o.EstudioRealizado.EndsWith(filter.EstudioRealizado.Replace("%",""))) || o.EstudioRealizado == filter.EstudioRealizado )
					  && (filter.EstudioaRealizar == null || filter.EstudioaRealizar.Trim() == string.Empty || filter.EstudioaRealizar.Trim() == "%"  || (filter.EstudioaRealizar.EndsWith("%") && filter.EstudioaRealizar.StartsWith("%") && (o.EstudioaRealizar.Contains(filter.EstudioaRealizar.Replace("%", "")))) || (filter.EstudioaRealizar.EndsWith("%") && o.EstudioaRealizar.StartsWith(filter.EstudioaRealizar.Replace("%",""))) || (filter.EstudioaRealizar.StartsWith("%") && o.EstudioaRealizar.EndsWith(filter.EstudioaRealizar.Replace("%",""))) || o.EstudioaRealizar == filter.EstudioaRealizar )
					  && (filter.SituacionSinProyecto == null || filter.SituacionSinProyecto.Trim() == string.Empty || filter.SituacionSinProyecto.Trim() == "%"  || (filter.SituacionSinProyecto.EndsWith("%") && filter.SituacionSinProyecto.StartsWith("%") && (o.SituacionSinProyecto.Contains(filter.SituacionSinProyecto.Replace("%", "")))) || (filter.SituacionSinProyecto.EndsWith("%") && o.SituacionSinProyecto.StartsWith(filter.SituacionSinProyecto.Replace("%",""))) || (filter.SituacionSinProyecto.StartsWith("%") && o.SituacionSinProyecto.EndsWith(filter.SituacionSinProyecto.Replace("%",""))) || o.SituacionSinProyecto == filter.SituacionSinProyecto )
					  && (filter.OpcionA == null || filter.OpcionA.Trim() == string.Empty || filter.OpcionA.Trim() == "%"  || (filter.OpcionA.EndsWith("%") && filter.OpcionA.StartsWith("%") && (o.OpcionA.Contains(filter.OpcionA.Replace("%", "")))) || (filter.OpcionA.EndsWith("%") && o.OpcionA.StartsWith(filter.OpcionA.Replace("%",""))) || (filter.OpcionA.StartsWith("%") && o.OpcionA.EndsWith(filter.OpcionA.Replace("%",""))) || o.OpcionA == filter.OpcionA )
					  && (filter.OpcionB == null || filter.OpcionB.Trim() == string.Empty || filter.OpcionB.Trim() == "%"  || (filter.OpcionB.EndsWith("%") && filter.OpcionB.StartsWith("%") && (o.OpcionB.Contains(filter.OpcionB.Replace("%", "")))) || (filter.OpcionB.EndsWith("%") && o.OpcionB.StartsWith(filter.OpcionB.Replace("%",""))) || (filter.OpcionB.StartsWith("%") && o.OpcionB.EndsWith(filter.OpcionB.Replace("%",""))) || o.OpcionB == filter.OpcionB )
					  && (filter.OpcionJustificacion == null || filter.OpcionJustificacion.Trim() == string.Empty || filter.OpcionJustificacion.Trim() == "%"  || (filter.OpcionJustificacion.EndsWith("%") && filter.OpcionJustificacion.StartsWith("%") && (o.OpcionJustificacion.Contains(filter.OpcionJustificacion.Replace("%", "")))) || (filter.OpcionJustificacion.EndsWith("%") && o.OpcionJustificacion.StartsWith(filter.OpcionJustificacion.Replace("%",""))) || (filter.OpcionJustificacion.StartsWith("%") && o.OpcionJustificacion.EndsWith(filter.OpcionJustificacion.Replace("%",""))) || o.OpcionJustificacion == filter.OpcionJustificacion )
					  && (filter.CriterioEvaluacion == null || filter.CriterioEvaluacion.Trim() == string.Empty || filter.CriterioEvaluacion.Trim() == "%"  || (filter.CriterioEvaluacion.EndsWith("%") && filter.CriterioEvaluacion.StartsWith("%") && (o.CriterioEvaluacion.Contains(filter.CriterioEvaluacion.Replace("%", "")))) || (filter.CriterioEvaluacion.EndsWith("%") && o.CriterioEvaluacion.StartsWith(filter.CriterioEvaluacion.Replace("%",""))) || (filter.CriterioEvaluacion.StartsWith("%") && o.CriterioEvaluacion.EndsWith(filter.CriterioEvaluacion.Replace("%",""))) || o.CriterioEvaluacion == filter.CriterioEvaluacion )
					  && (filter.HorizonteEvaluacion == null || o.HorizonteEvaluacion >=  filter.HorizonteEvaluacion) && (filter.HorizonteEvaluacion_To == null || o.HorizonteEvaluacion <= filter.HorizonteEvaluacion_To)
					  && (filter.HorizonteEvaluacionIsNull == null || filter.HorizonteEvaluacionIsNull == true || o.HorizonteEvaluacion != null ) && (filter.HorizonteEvaluacionIsNull == null || filter.HorizonteEvaluacionIsNull == false || o.HorizonteEvaluacion == null)
					  && (filter.TasaReferencia == null || o.TasaReferencia >=  filter.TasaReferencia) && (filter.TasaReferencia_To == null || o.TasaReferencia <= filter.TasaReferencia_To)
					  && (filter.TasaReferenciaIsNull == null || filter.TasaReferenciaIsNull == true || o.TasaReferencia != null ) && (filter.TasaReferenciaIsNull == null || filter.TasaReferenciaIsNull == false || o.TasaReferencia == null)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoEvaluacionResult> QueryResult(ProyectoEvaluacionFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Proyectos on o.Id_Proyecto equals t1.IdProyecto   
				   select new ProyectoEvaluacionResult(){
					 Id_ProyectoEvaluacion=o.Id_ProyectoEvaluacion
					 ,Id_Proyecto=o.Id_Proyecto
					 ,MarcoLegal=o.MarcoLegal
                     ,InfoAdicional=o.InfoAdicional
					 ,EstudioRealizado=o.EstudioRealizado
					 ,EstudioaRealizar=o.EstudioaRealizar
					 ,SituacionSinProyecto=o.SituacionSinProyecto
					 ,OpcionA=o.OpcionA
					 ,OpcionB=o.OpcionB
					 ,OpcionJustificacion=o.OpcionJustificacion
					 ,CriterioEvaluacion=o.CriterioEvaluacion
					 ,HorizonteEvaluacion=o.HorizonteEvaluacion
					 ,TasaReferencia=o.TasaReferencia
                    //,_Proyecto_IdTipoProyecto= t1.IdTipoProyecto	
                    //    ,_Proyecto_IdSubPrograma= t1.IdSubPrograma	
                    //    ,_Proyecto_Codigo= t1.Codigo	
                    //    ,_Proyecto_ProyectoDenominacion= t1.ProyectoDenominacion	
                    //    ,_Proyecto_ProyectoSituacionActual= t1.ProyectoSituacionActual	
                    //    ,_Proyecto_ProyectoDescripcion= t1.ProyectoDescripcion	
                    //    ,_Proyecto_ProyectoObservacion= t1.ProyectoObservacion	
                    //    ,_Proyecto_IdEstado= t1.IdEstado	
                    //    ,_Proyecto_IdProceso= t1.IdProceso	
                    //    ,_Proyecto_IdModalidadContratacion= t1.IdModalidadContratacion	
                    //    ,_Proyecto_IdFinalidadFuncion= t1.IdFinalidadFuncion	
                    //    ,_Proyecto_IdOrganismoPrioridad= t1.IdOrganismoPrioridad	
                    //    ,_Proyecto_SubPrioridad= t1.SubPrioridad	
                    //    ,_Proyecto_EsBorrador= t1.EsBorrador	
                    //    ,_Proyecto_EsProyecto= t1.EsProyecto	
                    //    ,_Proyecto_NroProyecto= t1.NroProyecto	
                    //    ,_Proyecto_AnioCorriente= t1.AnioCorriente	
                    //    ,_Proyecto_FechaInicioEjecucionCalculada= t1.FechaInicioEjecucionCalculada	
                    //    ,_Proyecto_FechaFinEjecucionCalculada= t1.FechaFinEjecucionCalculada	
                    //    ,_Proyecto_FechaAlta= t1.FechaAlta	
                    //    ,_Proyecto_FechaModificacion= t1.FechaModificacion	
                    //    ,_Proyecto_IdUsuarioModificacion= t1.IdUsuarioModificacion	
                    //    ,_Proyecto_IdProyectoPlan= t1.IdProyectoPlan	
                    //    ,_Proyecto_EvaluarValidaciones= t1.EvaluarValidaciones	
                    //    ,_Proyecto_Activo= t1.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoEvaluacion Copy(nc.ProyectoEvaluacion entity)
        {           
            nc.ProyectoEvaluacion _new = new nc.ProyectoEvaluacion();
		 _new.Id_Proyecto= entity.Id_Proyecto;
		 _new.MarcoLegal= entity.MarcoLegal;
         _new.InfoAdicional = entity.InfoAdicional;
		 _new.EstudioRealizado= entity.EstudioRealizado;
		 _new.EstudioaRealizar= entity.EstudioaRealizar;
		 _new.SituacionSinProyecto= entity.SituacionSinProyecto;
		 _new.OpcionA= entity.OpcionA;
		 _new.OpcionB= entity.OpcionB;
		 _new.OpcionJustificacion= entity.OpcionJustificacion;
		 _new.CriterioEvaluacion= entity.CriterioEvaluacion;
		 _new.HorizonteEvaluacion= entity.HorizonteEvaluacion;
		 _new.TasaReferencia= entity.TasaReferencia;
		return _new;			
        }
		public override int CopyAndSave(ProyectoEvaluacion entity,string renameFormat)
        {
            ProyectoEvaluacion  newEntity = Copy(entity);
            newEntity.MarcoLegal = string.Format(renameFormat,newEntity.MarcoLegal);
            newEntity.InfoAdicional = string.Format(renameFormat, newEntity.InfoAdicional);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoEvaluacion entity, int id)
        {            
            entity.Id_ProyectoEvaluacion = id;            
        }
		public override void Set(ProyectoEvaluacion source,ProyectoEvaluacion target,bool hadSetId)
		{		   
		if(hadSetId)target.Id_ProyectoEvaluacion= source.Id_ProyectoEvaluacion ;
		 target.Id_Proyecto= source.Id_Proyecto ;
		 target.MarcoLegal= source.MarcoLegal ;
         target.InfoAdicional = source.InfoAdicional;
		 target.EstudioRealizado= source.EstudioRealizado ;
		 target.EstudioaRealizar= source.EstudioaRealizar ;
		 target.SituacionSinProyecto= source.SituacionSinProyecto ;
		 target.OpcionA= source.OpcionA ;
		 target.OpcionB= source.OpcionB ;
		 target.OpcionJustificacion= source.OpcionJustificacion ;
		 target.CriterioEvaluacion= source.CriterioEvaluacion ;
		 target.HorizonteEvaluacion= source.HorizonteEvaluacion ;
		 target.TasaReferencia= source.TasaReferencia ;
		 		  
		}
		public override void Set(ProyectoEvaluacionResult source,ProyectoEvaluacion target,bool hadSetId)
		{		   
		if(hadSetId)target.Id_ProyectoEvaluacion= source.Id_ProyectoEvaluacion ;
		 target.Id_Proyecto= source.Id_Proyecto ;
		 target.MarcoLegal= source.MarcoLegal ;
         target.InfoAdicional = source.InfoAdicional;
		 target.EstudioRealizado= source.EstudioRealizado ;
		 target.EstudioaRealizar= source.EstudioaRealizar ;
		 target.SituacionSinProyecto= source.SituacionSinProyecto ;
		 target.OpcionA= source.OpcionA ;
		 target.OpcionB= source.OpcionB ;
		 target.OpcionJustificacion= source.OpcionJustificacion ;
		 target.CriterioEvaluacion= source.CriterioEvaluacion ;
		 target.HorizonteEvaluacion= source.HorizonteEvaluacion ;
		 target.TasaReferencia= source.TasaReferencia ;
		 
		}
		public override void Set(ProyectoEvaluacion source,ProyectoEvaluacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.Id_ProyectoEvaluacion= source.Id_ProyectoEvaluacion ;
		 target.Id_Proyecto= source.Id_Proyecto ;
		 target.MarcoLegal= source.MarcoLegal ;
         target.InfoAdicional = source.InfoAdicional;
		 target.EstudioRealizado= source.EstudioRealizado ;
		 target.EstudioaRealizar= source.EstudioaRealizar ;
		 target.SituacionSinProyecto= source.SituacionSinProyecto ;
		 target.OpcionA= source.OpcionA ;
		 target.OpcionB= source.OpcionB ;
		 target.OpcionJustificacion= source.OpcionJustificacion ;
		 target.CriterioEvaluacion= source.CriterioEvaluacion ;
		 target.HorizonteEvaluacion= source.HorizonteEvaluacion ;
		 target.TasaReferencia= source.TasaReferencia ;
		 	
		}		
		public override void Set(ProyectoEvaluacionResult source,ProyectoEvaluacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.Id_ProyectoEvaluacion= source.Id_ProyectoEvaluacion ;
		 target.Id_Proyecto= source.Id_Proyecto ;
		 target.MarcoLegal= source.MarcoLegal ;
         target.InfoAdicional = source.InfoAdicional;
		 target.EstudioRealizado= source.EstudioRealizado ;
		 target.EstudioaRealizar= source.EstudioaRealizar ;
		 target.SituacionSinProyecto= source.SituacionSinProyecto ;
		 target.OpcionA= source.OpcionA ;
		 target.OpcionB= source.OpcionB ;
		 target.OpcionJustificacion= source.OpcionJustificacion ;
		 target.CriterioEvaluacion= source.CriterioEvaluacion ;
		 target.HorizonteEvaluacion= source.HorizonteEvaluacion ;
		 target.TasaReferencia= source.TasaReferencia ;
         //target._Proyecto_IdTipoProyecto= source._Proyecto_IdTipoProyecto;	
         //   target._Proyecto_IdSubPrograma= source._Proyecto_IdSubPrograma;	
         //   target._Proyecto_Codigo= source._Proyecto_Codigo;	
         //   target._Proyecto_ProyectoDenominacion= source._Proyecto_ProyectoDenominacion;	
         //   target._Proyecto_ProyectoSituacionActual= source._Proyecto_ProyectoSituacionActual;	
         //   target._Proyecto_ProyectoDescripcion= source._Proyecto_ProyectoDescripcion;	
         //   target._Proyecto_ProyectoObservacion= source._Proyecto_ProyectoObservacion;	
         //   target._Proyecto_IdEstado= source._Proyecto_IdEstado;	
         //   target._Proyecto_IdProceso= source._Proyecto_IdProceso;	
         //   target._Proyecto_IdModalidadContratacion= source._Proyecto_IdModalidadContratacion;	
         //   target._Proyecto_IdFinalidadFuncion= source._Proyecto_IdFinalidadFuncion;	
         //   target._Proyecto_IdOrganismoPrioridad= source._Proyecto_IdOrganismoPrioridad;	
         //   target._Proyecto_SubPrioridad= source._Proyecto_SubPrioridad;	
         //   target._Proyecto_EsBorrador= source._Proyecto_EsBorrador;	
         //   target._Proyecto_EsProyecto= source._Proyecto_EsProyecto;	
         //   target._Proyecto_NroProyecto= source._Proyecto_NroProyecto;	
         //   target._Proyecto_AnioCorriente= source._Proyecto_AnioCorriente;	
         //   target._Proyecto_FechaInicioEjecucionCalculada= source._Proyecto_FechaInicioEjecucionCalculada;	
         //   target._Proyecto_FechaFinEjecucionCalculada= source._Proyecto_FechaFinEjecucionCalculada;	
         //   target._Proyecto_FechaAlta= source._Proyecto_FechaAlta;	
         //   target._Proyecto_FechaModificacion= source._Proyecto_FechaModificacion;	
         //   target._Proyecto_IdUsuarioModificacion= source._Proyecto_IdUsuarioModificacion;	
         //   target._Proyecto_IdProyectoPlan= source._Proyecto_IdProyectoPlan;	
         //   target._Proyecto_EvaluarValidaciones= source._Proyecto_EvaluarValidaciones;	
         //   target._Proyecto_Activo= source._Proyecto_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoEvaluacion source,ProyectoEvaluacion target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.Id_ProyectoEvaluacion.Equals(target.Id_ProyectoEvaluacion))return false;
		  if(!source.Id_Proyecto.Equals(target.Id_Proyecto))return false;
		  if((source.MarcoLegal == null)?target.MarcoLegal!=null:  !( (target.MarcoLegal== String.Empty && source.MarcoLegal== null) || (target.MarcoLegal==null && source.MarcoLegal== String.Empty )) &&  !source.MarcoLegal.Trim().Replace ("\r","").Equals(target.MarcoLegal.Trim().Replace ("\r","")))return false;
          if ((source.InfoAdicional == null) ? target.InfoAdicional != null : !((target.InfoAdicional == String.Empty && source.InfoAdicional == null) || (target.InfoAdicional == null && source.InfoAdicional == String.Empty)) && !source.InfoAdicional.Trim().Replace("\r", "").Equals(target.InfoAdicional.Trim().Replace("\r", ""))) return false;
			 if((source.EstudioRealizado == null)?target.EstudioRealizado!=null:  !( (target.EstudioRealizado== String.Empty && source.EstudioRealizado== null) || (target.EstudioRealizado==null && source.EstudioRealizado== String.Empty )) &&  !source.EstudioRealizado.Trim().Replace ("\r","").Equals(target.EstudioRealizado.Trim().Replace ("\r","")))return false;
			 if((source.EstudioaRealizar == null)?target.EstudioaRealizar!=null:  !( (target.EstudioaRealizar== String.Empty && source.EstudioaRealizar== null) || (target.EstudioaRealizar==null && source.EstudioaRealizar== String.Empty )) &&  !source.EstudioaRealizar.Trim().Replace ("\r","").Equals(target.EstudioaRealizar.Trim().Replace ("\r","")))return false;
			 if((source.SituacionSinProyecto == null)?target.SituacionSinProyecto!=null:  !( (target.SituacionSinProyecto== String.Empty && source.SituacionSinProyecto== null) || (target.SituacionSinProyecto==null && source.SituacionSinProyecto== String.Empty )) &&  !source.SituacionSinProyecto.Trim().Replace ("\r","").Equals(target.SituacionSinProyecto.Trim().Replace ("\r","")))return false;
			 if((source.OpcionA == null)?target.OpcionA!=null:  !( (target.OpcionA== String.Empty && source.OpcionA== null) || (target.OpcionA==null && source.OpcionA== String.Empty )) &&  !source.OpcionA.Trim().Replace ("\r","").Equals(target.OpcionA.Trim().Replace ("\r","")))return false;
			 if((source.OpcionB == null)?target.OpcionB!=null:  !( (target.OpcionB== String.Empty && source.OpcionB== null) || (target.OpcionB==null && source.OpcionB== String.Empty )) &&  !source.OpcionB.Trim().Replace ("\r","").Equals(target.OpcionB.Trim().Replace ("\r","")))return false;
			 if((source.OpcionJustificacion == null)?target.OpcionJustificacion!=null:  !( (target.OpcionJustificacion== String.Empty && source.OpcionJustificacion== null) || (target.OpcionJustificacion==null && source.OpcionJustificacion== String.Empty )) &&  !source.OpcionJustificacion.Trim().Replace ("\r","").Equals(target.OpcionJustificacion.Trim().Replace ("\r","")))return false;
			 if((source.CriterioEvaluacion == null)?target.CriterioEvaluacion!=null:  !( (target.CriterioEvaluacion== String.Empty && source.CriterioEvaluacion== null) || (target.CriterioEvaluacion==null && source.CriterioEvaluacion== String.Empty )) &&  !source.CriterioEvaluacion.Trim().Replace ("\r","").Equals(target.CriterioEvaluacion.Trim().Replace ("\r","")))return false;
			 if((source.HorizonteEvaluacion == null)?(target.HorizonteEvaluacion.HasValue):!source.HorizonteEvaluacion.Equals(target.HorizonteEvaluacion))return false;
			 if((source.TasaReferencia == null)?(target.TasaReferencia.HasValue):!source.TasaReferencia.Equals(target.TasaReferencia))return false;
			
		  return true;
        }
		public override bool Equals(ProyectoEvaluacionResult source,ProyectoEvaluacionResult target)
        {
		    if(source == null && target == null)return true;
		    if(source == null )return false;
            //Matias 20141015 - Tarea 159
            //if(target == null)return false;
            if (target == null)
            {
                //if (!source.Id_ProyectoEvaluacion.Equals(target.Id_ProyectoEvaluacion)) return false;
                //if (!source.Id_Proyecto.Equals(target.Id_Proyecto)) return false;
                if (source.MarcoLegal != null && source.MarcoLegal != String.Empty) return false;
                if (source.InfoAdicional != null && source.InfoAdicional != String.Empty) return false;
                if (source.EstudioRealizado != null && source.EstudioRealizado != String.Empty) return false;
                if (source.EstudioaRealizar != null && source.EstudioaRealizar != String.Empty) return false;
                if (source.SituacionSinProyecto != null && source.SituacionSinProyecto != String.Empty) return false;
                if (source.OpcionA != null && source.OpcionA != String.Empty) return false;
                if (source.OpcionB != null && source.OpcionB != String.Empty) return false;
                if (source.OpcionJustificacion != null && source.OpcionJustificacion != String.Empty) return false;
                if (source.CriterioEvaluacion != null && source.CriterioEvaluacion != String.Empty) return false;
                if (source.HorizonteEvaluacion != null && source.HorizonteEvaluacion != 0) return false;
                if (source.TasaReferencia != null && source.TasaReferencia != 0) return false;                
                return true;
            }
            //FinMatias 20141015 - Tarea 159
            if(!source.Id_ProyectoEvaluacion.Equals(target.Id_ProyectoEvaluacion))return false;
		    if(!source.Id_Proyecto.Equals(target.Id_Proyecto))return false;
		    if((source.MarcoLegal == null)?target.MarcoLegal!=null: !( (target.MarcoLegal== String.Empty && source.MarcoLegal== null) || (target.MarcoLegal==null && source.MarcoLegal== String.Empty )) && !source.MarcoLegal.Trim().Replace ("\r","").Equals(target.MarcoLegal.Trim().Replace ("\r","")))return false;
            if ((source.InfoAdicional == null) ? target.InfoAdicional != null : !((target.InfoAdicional == String.Empty && source.InfoAdicional == null) || (target.InfoAdicional == null && source.InfoAdicional == String.Empty)) && !source.InfoAdicional.Trim().Replace("\r", "").Equals(target.InfoAdicional.Trim().Replace("\r", ""))) return false;
			if((source.EstudioRealizado == null)?target.EstudioRealizado!=null: !( (target.EstudioRealizado== String.Empty && source.EstudioRealizado== null) || (target.EstudioRealizado==null && source.EstudioRealizado== String.Empty )) && !source.EstudioRealizado.Trim().Replace ("\r","").Equals(target.EstudioRealizado.Trim().Replace ("\r","")))return false;
			if((source.EstudioaRealizar == null)?target.EstudioaRealizar!=null: !( (target.EstudioaRealizar== String.Empty && source.EstudioaRealizar== null) || (target.EstudioaRealizar==null && source.EstudioaRealizar== String.Empty )) && !source.EstudioaRealizar.Trim().Replace ("\r","").Equals(target.EstudioaRealizar.Trim().Replace ("\r","")))return false;
			if((source.SituacionSinProyecto == null)?target.SituacionSinProyecto!=null: !( (target.SituacionSinProyecto== String.Empty && source.SituacionSinProyecto== null) || (target.SituacionSinProyecto==null && source.SituacionSinProyecto== String.Empty )) && !source.SituacionSinProyecto.Trim().Replace ("\r","").Equals(target.SituacionSinProyecto.Trim().Replace ("\r","")))return false;
			if((source.OpcionA == null)?target.OpcionA!=null: !( (target.OpcionA== String.Empty && source.OpcionA== null) || (target.OpcionA==null && source.OpcionA== String.Empty )) && !source.OpcionA.Trim().Replace ("\r","").Equals(target.OpcionA.Trim().Replace ("\r","")))return false;
			if((source.OpcionB == null)?target.OpcionB!=null: !( (target.OpcionB== String.Empty && source.OpcionB== null) || (target.OpcionB==null && source.OpcionB== String.Empty )) && !source.OpcionB.Trim().Replace ("\r","").Equals(target.OpcionB.Trim().Replace ("\r","")))return false;
			if((source.OpcionJustificacion == null)?target.OpcionJustificacion!=null: !( (target.OpcionJustificacion== String.Empty && source.OpcionJustificacion== null) || (target.OpcionJustificacion==null && source.OpcionJustificacion== String.Empty )) && !source.OpcionJustificacion.Trim().Replace ("\r","").Equals(target.OpcionJustificacion.Trim().Replace ("\r","")))return false;
			if((source.CriterioEvaluacion == null)?target.CriterioEvaluacion!=null: !( (target.CriterioEvaluacion== String.Empty && source.CriterioEvaluacion== null) || (target.CriterioEvaluacion==null && source.CriterioEvaluacion== String.Empty )) && !source.CriterioEvaluacion.Trim().Replace ("\r","").Equals(target.CriterioEvaluacion.Trim().Replace ("\r","")))return false;
			if((source.HorizonteEvaluacion == null)?(target.HorizonteEvaluacion.HasValue):!source.HorizonteEvaluacion.Equals(target.HorizonteEvaluacion))return false;
			if((source.TasaReferencia == null)?(target.TasaReferencia.HasValue):!source.TasaReferencia.Equals(target.TasaReferencia))return false;
			if(!source._Proyecto_IdTipoProyecto.Equals(target._Proyecto_IdTipoProyecto))return false;
                      //if(!source._Proyecto_IdSubPrograma.Equals(target._Proyecto_IdSubPrograma))return false;
                      //if(!source._Proyecto_Codigo.Equals(target._Proyecto_Codigo))return false;
                      //if((source._Proyecto_ProyectoDenominacion == null)?target._Proyecto_ProyectoDenominacion!=null: !( (target._Proyecto_ProyectoDenominacion== String.Empty && source._Proyecto_ProyectoDenominacion== null) || (target._Proyecto_ProyectoDenominacion==null && source._Proyecto_ProyectoDenominacion== String.Empty )) &&   !source._Proyecto_ProyectoDenominacion.Trim().Replace ("\r","").Equals(target._Proyecto_ProyectoDenominacion.Trim().Replace ("\r","")))return false;
                      //   if((source._Proyecto_ProyectoSituacionActual == null)?target._Proyecto_ProyectoSituacionActual!=null: !( (target._Proyecto_ProyectoSituacionActual== String.Empty && source._Proyecto_ProyectoSituacionActual== null) || (target._Proyecto_ProyectoSituacionActual==null && source._Proyecto_ProyectoSituacionActual== String.Empty )) &&   !source._Proyecto_ProyectoSituacionActual.Trim().Replace ("\r","").Equals(target._Proyecto_ProyectoSituacionActual.Trim().Replace ("\r","")))return false;
                      //   if((source._Proyecto_ProyectoDescripcion == null)?target._Proyecto_ProyectoDescripcion!=null: !( (target._Proyecto_ProyectoDescripcion== String.Empty && source._Proyecto_ProyectoDescripcion== null) || (target._Proyecto_ProyectoDescripcion==null && source._Proyecto_ProyectoDescripcion== String.Empty )) &&   !source._Proyecto_ProyectoDescripcion.Trim().Replace ("\r","").Equals(target._Proyecto_ProyectoDescripcion.Trim().Replace ("\r","")))return false;
                      //   if((source._Proyecto_ProyectoObservacion == null)?target._Proyecto_ProyectoObservacion!=null: !( (target._Proyecto_ProyectoObservacion== String.Empty && source._Proyecto_ProyectoObservacion== null) || (target._Proyecto_ProyectoObservacion==null && source._Proyecto_ProyectoObservacion== String.Empty )) &&   !source._Proyecto_ProyectoObservacion.Trim().Replace ("\r","").Equals(target._Proyecto_ProyectoObservacion.Trim().Replace ("\r","")))return false;
                      //   if(!source._Proyecto_IdEstado.Equals(target._Proyecto_IdEstado))return false;
                      //if((source._Proyecto_IdProceso == null)?(target._Proyecto_IdProceso.HasValue && target._Proyecto_IdProceso.Value > 0):!source._Proyecto_IdProceso.Equals(target._Proyecto_IdProceso))return false;
                      //                if((source._Proyecto_IdModalidadContratacion == null)?(target._Proyecto_IdModalidadContratacion.HasValue && target._Proyecto_IdModalidadContratacion.Value > 0):!source._Proyecto_IdModalidadContratacion.Equals(target._Proyecto_IdModalidadContratacion))return false;
                      //                if((source._Proyecto_IdFinalidadFuncion == null)?(target._Proyecto_IdFinalidadFuncion.HasValue && target._Proyecto_IdFinalidadFuncion.Value > 0):!source._Proyecto_IdFinalidadFuncion.Equals(target._Proyecto_IdFinalidadFuncion))return false;
                      //                if((source._Proyecto_IdOrganismoPrioridad == null)?(target._Proyecto_IdOrganismoPrioridad.HasValue && target._Proyecto_IdOrganismoPrioridad.Value > 0):!source._Proyecto_IdOrganismoPrioridad.Equals(target._Proyecto_IdOrganismoPrioridad))return false;
                      //                if((source._Proyecto_SubPrioridad == null)?(target._Proyecto_SubPrioridad.HasValue ):!source._Proyecto_SubPrioridad.Equals(target._Proyecto_SubPrioridad))return false;
                      //   if(!source._Proyecto_EsBorrador.Equals(target._Proyecto_EsBorrador))return false;
                      //if((source._Proyecto_EsProyecto == null)?(target._Proyecto_EsProyecto.HasValue ):!source._Proyecto_EsProyecto.Equals(target._Proyecto_EsProyecto))return false;
                      //   if((source._Proyecto_NroProyecto == null)?(target._Proyecto_NroProyecto.HasValue ):!source._Proyecto_NroProyecto.Equals(target._Proyecto_NroProyecto))return false;
                      //   if((source._Proyecto_AnioCorriente == null)?(target._Proyecto_AnioCorriente.HasValue ):!source._Proyecto_AnioCorriente.Equals(target._Proyecto_AnioCorriente))return false;
                      //   if((source._Proyecto_FechaInicioEjecucionCalculada == null)?(target._Proyecto_FechaInicioEjecucionCalculada.HasValue ):!source._Proyecto_FechaInicioEjecucionCalculada.Equals(target._Proyecto_FechaInicioEjecucionCalculada))return false;
                      //   if((source._Proyecto_FechaFinEjecucionCalculada == null)?(target._Proyecto_FechaFinEjecucionCalculada.HasValue ):!source._Proyecto_FechaFinEjecucionCalculada.Equals(target._Proyecto_FechaFinEjecucionCalculada))return false;
                      //   if(!source._Proyecto_FechaAlta.Equals(target._Proyecto_FechaAlta))return false;
                      //if(!source._Proyecto_FechaModificacion.Equals(target._Proyecto_FechaModificacion))return false;
                      //if(!source._Proyecto_IdUsuarioModificacion.Equals(target._Proyecto_IdUsuarioModificacion))return false;
                      //if((source._Proyecto_IdProyectoPlan == null)?(target._Proyecto_IdProyectoPlan.HasValue ):!source._Proyecto_IdProyectoPlan.Equals(target._Proyecto_IdProyectoPlan))return false;
                      //   if(!source._Proyecto_EvaluarValidaciones.Equals(target._Proyecto_EvaluarValidaciones))return false;
                      //if(!source._Proyecto_Activo.Equals(target._Proyecto_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}

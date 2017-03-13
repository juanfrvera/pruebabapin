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
    public abstract class _EstadoDeDesicionHistoricoData : EntityData<EstadoDeDesicionHistorico,EstadoDeDesicionHistoricoFilter,EstadoDeDesicionHistoricoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.EstadoDeDesicionHistorico entity)
		{			
			return entity.IdEstadoDeDesicionHistorico;
		}		
		public override EstadoDeDesicionHistorico GetByEntity(EstadoDeDesicionHistorico entity)
        {
            return this.GetById(entity.IdEstadoDeDesicionHistorico);
        }
        public override EstadoDeDesicionHistorico GetById(int id)
        {
            return (from o in this.Table where o.IdEstadoDeDesicionHistorico == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<EstadoDeDesicionHistorico> Query(EstadoDeDesicionHistoricoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdEstadoDeDesicionHistorico == null || o.IdEstadoDeDesicionHistorico >=  filter.IdEstadoDeDesicionHistorico) && (filter.IdEstadoDeDesicionHistorico_To == null || o.IdEstadoDeDesicionHistorico <= filter.IdEstadoDeDesicionHistorico_To)
					  && (filter.IdEstadoDeDesicion == null || filter.IdEstadoDeDesicion == 0 || o.IdEstadoDeDesicion==filter.IdEstadoDeDesicion)
					  && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto==filter.IdProyecto)
					  && (filter.Fecha == null || filter.Fecha == DateTime.MinValue || o.Fecha >=  filter.Fecha) && (filter.Fecha_To == null || filter.Fecha_To == DateTime.MinValue || o.Fecha <= filter.Fecha_To)
					  && (filter.IdUsuario == null || filter.IdUsuario == 0 || o.IdUsuario==filter.IdUsuario)
					  && (filter.Observacion == null || filter.Observacion.Trim() == string.Empty || filter.Observacion.Trim() == "%"  || (filter.Observacion.EndsWith("%") && filter.Observacion.StartsWith("%") && (o.Observacion.Contains(filter.Observacion.Replace("%", "")))) || (filter.Observacion.EndsWith("%") && o.Observacion.StartsWith(filter.Observacion.Replace("%",""))) || (filter.Observacion.StartsWith("%") && o.Observacion.EndsWith(filter.Observacion.Replace("%",""))) || o.Observacion == filter.Observacion )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<EstadoDeDesicionHistoricoResult> QueryResult(EstadoDeDesicionHistoricoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.EstadoDeDesicions on o.IdEstadoDeDesicion equals t1.IdEstadoDeDesicion   
				    join t2  in this.Context.Proyectos on o.IdProyecto equals t2.IdProyecto   
				    join t3  in this.Context.Usuarios on o.IdUsuario equals t3.IdUsuario   
				   select new EstadoDeDesicionHistoricoResult(){
					 IdEstadoDeDesicionHistorico=o.IdEstadoDeDesicionHistorico
					 ,IdEstadoDeDesicion=o.IdEstadoDeDesicion
					 ,IdProyecto=o.IdProyecto
					 ,Fecha=o.Fecha
					 ,IdUsuario=o.IdUsuario
					 ,Observacion=o.Observacion
					,EstadoDeDesicion_Nombre= t1.Nombre	
						,EstadoDeDesicion_Codigo= t1.Codigo	
						,EstadoDeDesicion_Orden= t1.Orden	
						,EstadoDeDesicion_Descripcion= t1.Descripcion	
						,EstadoDeDesicion_Activo= t1.Activo	
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
						,Proyecto_Activo= t2.Activo	
						,Proyecto_IdEstadoDeDesicion= t2.IdEstadoDeDesicion	
						,Usuario_NombreUsuario= t3.NombreUsuario	
						,Usuario_Clave= t3.Clave	
						,Usuario_Activo= t3.Activo	
						,Usuario_EsSectioralista= t3.EsSectioralista	
						,Usuario_IdLanguage= t3.IdLanguage	
						,Usuario_AccesoTotal= t3.AccesoTotal	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.EstadoDeDesicionHistorico Copy(nc.EstadoDeDesicionHistorico entity)
        {           
            nc.EstadoDeDesicionHistorico _new = new nc.EstadoDeDesicionHistorico();
		 _new.IdEstadoDeDesicion= entity.IdEstadoDeDesicion;
		 _new.IdProyecto= entity.IdProyecto;
		 _new.Fecha= entity.Fecha;
		 _new.IdUsuario= entity.IdUsuario;
		 _new.Observacion= entity.Observacion;
		return _new;			
        }
		public override int CopyAndSave(EstadoDeDesicionHistorico entity,string renameFormat)
        {
            EstadoDeDesicionHistorico  newEntity = Copy(entity);
            newEntity.Observacion = string.Format(renameFormat,newEntity.Observacion);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(EstadoDeDesicionHistorico entity, int id)
        {            
            entity.IdEstadoDeDesicionHistorico = id;            
        }
		public override void Set(EstadoDeDesicionHistorico source,EstadoDeDesicionHistorico target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEstadoDeDesicionHistorico= source.IdEstadoDeDesicionHistorico ;
		 target.IdEstadoDeDesicion= source.IdEstadoDeDesicion ;
		 target.IdProyecto= source.IdProyecto ;
		 target.Fecha= source.Fecha ;
		 target.IdUsuario= source.IdUsuario ;
		 target.Observacion= source.Observacion ;
		 		  
		}
		public override void Set(EstadoDeDesicionHistoricoResult source,EstadoDeDesicionHistorico target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEstadoDeDesicionHistorico= source.IdEstadoDeDesicionHistorico ;
		 target.IdEstadoDeDesicion= source.IdEstadoDeDesicion ;
		 target.IdProyecto= source.IdProyecto ;
		 target.Fecha= source.Fecha ;
		 target.IdUsuario= source.IdUsuario ;
		 target.Observacion= source.Observacion ;
		 
		}
		public override void Set(EstadoDeDesicionHistorico source,EstadoDeDesicionHistoricoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEstadoDeDesicionHistorico= source.IdEstadoDeDesicionHistorico ;
		 target.IdEstadoDeDesicion= source.IdEstadoDeDesicion ;
		 target.IdProyecto= source.IdProyecto ;
		 target.Fecha= source.Fecha ;
		 target.IdUsuario= source.IdUsuario ;
		 target.Observacion= source.Observacion ;
		 	
		}		
		public override void Set(EstadoDeDesicionHistoricoResult source,EstadoDeDesicionHistoricoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEstadoDeDesicionHistorico= source.IdEstadoDeDesicionHistorico ;
		 target.IdEstadoDeDesicion= source.IdEstadoDeDesicion ;
		 target.IdProyecto= source.IdProyecto ;
		 target.Fecha= source.Fecha ;
		 target.IdUsuario= source.IdUsuario ;
		 target.Observacion= source.Observacion ;
		 target.EstadoDeDesicion_Nombre= source.EstadoDeDesicion_Nombre;	
			target.EstadoDeDesicion_Codigo= source.EstadoDeDesicion_Codigo;	
			target.EstadoDeDesicion_Orden= source.EstadoDeDesicion_Orden;	
			target.EstadoDeDesicion_Descripcion= source.EstadoDeDesicion_Descripcion;	
			target.EstadoDeDesicion_Activo= source.EstadoDeDesicion_Activo;	
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
			target.Proyecto_Activo= source.Proyecto_Activo;	
			target.Proyecto_IdEstadoDeDesicion= source.Proyecto_IdEstadoDeDesicion;	
			target.Usuario_NombreUsuario= source.Usuario_NombreUsuario;	
			target.Usuario_Clave= source.Usuario_Clave;	
			target.Usuario_Activo= source.Usuario_Activo;	
			target.Usuario_EsSectioralista= source.Usuario_EsSectioralista;	
			target.Usuario_IdLanguage= source.Usuario_IdLanguage;	
			target.Usuario_AccesoTotal= source.Usuario_AccesoTotal;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(EstadoDeDesicionHistorico source,EstadoDeDesicionHistorico target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdEstadoDeDesicionHistorico.Equals(target.IdEstadoDeDesicionHistorico))return false;
		  if(!source.IdEstadoDeDesicion.Equals(target.IdEstadoDeDesicion))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if(!source.Fecha.Equals(target.Fecha))return false;
		  if(!source.IdUsuario.Equals(target.IdUsuario))return false;
		  if((source.Observacion == null)?target.Observacion!=null:  !( (target.Observacion== String.Empty && source.Observacion== null) || (target.Observacion==null && source.Observacion== String.Empty )) &&  !source.Observacion.Trim().Replace ("\r","").Equals(target.Observacion.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(EstadoDeDesicionHistoricoResult source,EstadoDeDesicionHistoricoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdEstadoDeDesicionHistorico.Equals(target.IdEstadoDeDesicionHistorico))return false;
		  if(!source.IdEstadoDeDesicion.Equals(target.IdEstadoDeDesicion))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if(!source.Fecha.Equals(target.Fecha))return false;
		  if(!source.IdUsuario.Equals(target.IdUsuario))return false;
		  if((source.Observacion == null)?target.Observacion!=null: !( (target.Observacion== String.Empty && source.Observacion== null) || (target.Observacion==null && source.Observacion== String.Empty )) && !source.Observacion.Trim().Replace ("\r","").Equals(target.Observacion.Trim().Replace ("\r","")))return false;
			 if((source.EstadoDeDesicion_Nombre == null)?target.EstadoDeDesicion_Nombre!=null: !( (target.EstadoDeDesicion_Nombre== String.Empty && source.EstadoDeDesicion_Nombre== null) || (target.EstadoDeDesicion_Nombre==null && source.EstadoDeDesicion_Nombre== String.Empty )) &&   !source.EstadoDeDesicion_Nombre.Trim().Replace ("\r","").Equals(target.EstadoDeDesicion_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.EstadoDeDesicion_Codigo == null)?target.EstadoDeDesicion_Codigo!=null: !( (target.EstadoDeDesicion_Codigo== String.Empty && source.EstadoDeDesicion_Codigo== null) || (target.EstadoDeDesicion_Codigo==null && source.EstadoDeDesicion_Codigo== String.Empty )) &&   !source.EstadoDeDesicion_Codigo.Trim().Replace ("\r","").Equals(target.EstadoDeDesicion_Codigo.Trim().Replace ("\r","")))return false;
						 if(!source.EstadoDeDesicion_Orden.Equals(target.EstadoDeDesicion_Orden))return false;
					  if((source.EstadoDeDesicion_Descripcion == null)?target.EstadoDeDesicion_Descripcion!=null: !( (target.EstadoDeDesicion_Descripcion== String.Empty && source.EstadoDeDesicion_Descripcion== null) || (target.EstadoDeDesicion_Descripcion==null && source.EstadoDeDesicion_Descripcion== String.Empty )) &&   !source.EstadoDeDesicion_Descripcion.Trim().Replace ("\r","").Equals(target.EstadoDeDesicion_Descripcion.Trim().Replace ("\r","")))return false;
						 if(!source.EstadoDeDesicion_Activo.Equals(target.EstadoDeDesicion_Activo))return false;
					  if(!source.Proyecto_IdTipoProyecto.Equals(target.Proyecto_IdTipoProyecto))return false;
					  if(!source.Proyecto_IdSubPrograma.Equals(target.Proyecto_IdSubPrograma))return false;
					  if(!source.Proyecto_Codigo.Equals(target.Proyecto_Codigo))return false;
					  if((source.Proyecto_ProyectoDenominacion == null)?target.Proyecto_ProyectoDenominacion!=null: !( (target.Proyecto_ProyectoDenominacion== String.Empty && source.Proyecto_ProyectoDenominacion== null) || (target.Proyecto_ProyectoDenominacion==null && source.Proyecto_ProyectoDenominacion== String.Empty )) &&   !source.Proyecto_ProyectoDenominacion.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoDenominacion.Trim().Replace ("\r","")))return false;
						 if((source.Proyecto_ProyectoSituacionActual == null)?target.Proyecto_ProyectoSituacionActual!=null: !( (target.Proyecto_ProyectoSituacionActual== String.Empty && source.Proyecto_ProyectoSituacionActual== null) || (target.Proyecto_ProyectoSituacionActual==null && source.Proyecto_ProyectoSituacionActual== String.Empty )) &&   !source.Proyecto_ProyectoSituacionActual.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoSituacionActual.Trim().Replace ("\r","")))return false;
						 if((source.Proyecto_ProyectoDescripcion == null)?target.Proyecto_ProyectoDescripcion!=null: !( (target.Proyecto_ProyectoDescripcion== String.Empty && source.Proyecto_ProyectoDescripcion== null) || (target.Proyecto_ProyectoDescripcion==null && source.Proyecto_ProyectoDescripcion== String.Empty )) &&   !source.Proyecto_ProyectoDescripcion.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoDescripcion.Trim().Replace ("\r","")))return false;
						 if((source.Proyecto_ProyectoObservacion == null)?target.Proyecto_ProyectoObservacion!=null: !( (target.Proyecto_ProyectoObservacion== String.Empty && source.Proyecto_ProyectoObservacion== null) || (target.Proyecto_ProyectoObservacion==null && source.Proyecto_ProyectoObservacion== String.Empty )) &&   !source.Proyecto_ProyectoObservacion.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoObservacion.Trim().Replace ("\r","")))return false;
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
					  if(!source.Proyecto_Activo.Equals(target.Proyecto_Activo))return false;
					  if((source.Proyecto_IdEstadoDeDesicion == null)?(target.Proyecto_IdEstadoDeDesicion.HasValue && target.Proyecto_IdEstadoDeDesicion.Value > 0):!source.Proyecto_IdEstadoDeDesicion.Equals(target.Proyecto_IdEstadoDeDesicion))return false;
									  if((source.Usuario_NombreUsuario == null)?target.Usuario_NombreUsuario!=null: !( (target.Usuario_NombreUsuario== String.Empty && source.Usuario_NombreUsuario== null) || (target.Usuario_NombreUsuario==null && source.Usuario_NombreUsuario== String.Empty )) &&   !source.Usuario_NombreUsuario.Trim().Replace ("\r","").Equals(target.Usuario_NombreUsuario.Trim().Replace ("\r","")))return false;
						 if((source.Usuario_Clave == null)?target.Usuario_Clave!=null: !( (target.Usuario_Clave== String.Empty && source.Usuario_Clave== null) || (target.Usuario_Clave==null && source.Usuario_Clave== String.Empty )) &&   !source.Usuario_Clave.Trim().Replace ("\r","").Equals(target.Usuario_Clave.Trim().Replace ("\r","")))return false;
						 if(!source.Usuario_Activo.Equals(target.Usuario_Activo))return false;
					  if(!source.Usuario_EsSectioralista.Equals(target.Usuario_EsSectioralista))return false;
					  if(!source.Usuario_IdLanguage.Equals(target.Usuario_IdLanguage))return false;
					  if(!source.Usuario_AccesoTotal.Equals(target.Usuario_AccesoTotal))return false;
					 		
		  return true;
        }
		#endregion
    }
}

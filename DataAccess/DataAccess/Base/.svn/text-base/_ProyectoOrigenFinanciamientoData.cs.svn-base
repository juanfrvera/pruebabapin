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
    public abstract class _ProyectoOrigenFinanciamientoData : EntityData<ProyectoOrigenFinanciamiento,ProyectoOrigenFinanciamientoFilter,ProyectoOrigenFinanciamientoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoOrigenFinanciamiento entity)
		{			
			return entity.IdProyectoOrigenFinanciamiento;
		}		
		public override ProyectoOrigenFinanciamiento GetByEntity(ProyectoOrigenFinanciamiento entity)
        {
            return this.GetById(entity.IdProyectoOrigenFinanciamiento);
        }
        public override ProyectoOrigenFinanciamiento GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoOrigenFinanciamiento == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoOrigenFinanciamiento> Query(ProyectoOrigenFinanciamientoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoOrigenFinanciamiento == null || o.IdProyectoOrigenFinanciamiento >=  filter.IdProyectoOrigenFinanciamiento) && (filter.IdProyectoOrigenFinanciamiento_To == null || o.IdProyectoOrigenFinanciamiento <= filter.IdProyectoOrigenFinanciamiento_To)
					  && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto==filter.IdProyecto)
					  && (filter.IdProyectoOrigenFinancianmientoTipo == null || filter.IdProyectoOrigenFinancianmientoTipo == 0 || o.IdProyectoOrigenFinancianmientoTipo==filter.IdProyectoOrigenFinancianmientoTipo)
					  && (filter.IdPrestamo == null || filter.IdPrestamo == 0 || o.IdPrestamo==filter.IdPrestamo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoOrigenFinanciamientoResult> QueryResult(ProyectoOrigenFinanciamientoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Prestamos on o.IdPrestamo equals t1.IdPrestamo   
				    join t2  in this.Context.Proyectos on o.IdProyecto equals t2.IdProyecto   
				    join t3  in this.Context.ProyectoOrigenFinanciamientoTipos on o.IdProyectoOrigenFinancianmientoTipo equals t3.IdProyectoOrigenFinancianmientoTipo   
				   select new ProyectoOrigenFinanciamientoResult(){
					 IdProyectoOrigenFinanciamiento=o.IdProyectoOrigenFinanciamiento
					 ,IdProyecto=o.IdProyecto
					 ,IdProyectoOrigenFinancianmientoTipo=o.IdProyectoOrigenFinancianmientoTipo
					 ,IdPrestamo=o.IdPrestamo
					,Prestamo_IdPrograma= t1.IdPrograma	
						,Prestamo_Numero= t1.Numero	
						,Prestamo_Denominacion= t1.Denominacion	
						,Prestamo_Descripcion= t1.Descripcion	
						,Prestamo_Observacion= t1.Observacion	
						,Prestamo_FechaAlta= t1.FechaAlta	
						,Prestamo_FechaModificacion= t1.FechaModificacion	
						,Prestamo_IdUsuarioModificacion= t1.IdUsuarioModificacion	
						,Prestamo_IdEstadoActual= t1.IdEstadoActual	
						,Prestamo_ResponsablePolitico= t1.ResponsablePolitico	
						,Prestamo_ResponsableTecnico= t1.ResponsableTecnico	
						,Prestamo_CodigoVinculacion1= t1.CodigoVinculacion1	
						,Prestamo_CodigoVinculacion2= t1.CodigoVinculacion2	
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
						,ProyectoOrigenFinancianmientoTipo_Nombre= t3.Nombre	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoOrigenFinanciamiento Copy(nc.ProyectoOrigenFinanciamiento entity)
        {           
            nc.ProyectoOrigenFinanciamiento _new = new nc.ProyectoOrigenFinanciamiento();
		 _new.IdProyecto= entity.IdProyecto;
		 _new.IdProyectoOrigenFinancianmientoTipo= entity.IdProyectoOrigenFinancianmientoTipo;
		 _new.IdPrestamo= entity.IdPrestamo;
		return _new;			
        }
		public override int CopyAndSave(ProyectoOrigenFinanciamiento entity,string renameFormat)
        {
            ProyectoOrigenFinanciamiento  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoOrigenFinanciamiento entity, int id)
        {            
            entity.IdProyectoOrigenFinanciamiento = id;            
        }
		public override void Set(ProyectoOrigenFinanciamiento source,ProyectoOrigenFinanciamiento target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoOrigenFinanciamiento= source.IdProyectoOrigenFinanciamiento ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdProyectoOrigenFinancianmientoTipo= source.IdProyectoOrigenFinancianmientoTipo ;
		 target.IdPrestamo= source.IdPrestamo ;
		 		  
		}
		public override void Set(ProyectoOrigenFinanciamientoResult source,ProyectoOrigenFinanciamiento target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoOrigenFinanciamiento= source.IdProyectoOrigenFinanciamiento ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdProyectoOrigenFinancianmientoTipo= source.IdProyectoOrigenFinancianmientoTipo ;
		 target.IdPrestamo= source.IdPrestamo ;
		 
		}
		public override void Set(ProyectoOrigenFinanciamiento source,ProyectoOrigenFinanciamientoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoOrigenFinanciamiento= source.IdProyectoOrigenFinanciamiento ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdProyectoOrigenFinancianmientoTipo= source.IdProyectoOrigenFinancianmientoTipo ;
		 target.IdPrestamo= source.IdPrestamo ;
		 	
		}		
		public override void Set(ProyectoOrigenFinanciamientoResult source,ProyectoOrigenFinanciamientoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoOrigenFinanciamiento= source.IdProyectoOrigenFinanciamiento ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdProyectoOrigenFinancianmientoTipo= source.IdProyectoOrigenFinancianmientoTipo ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.Prestamo_IdPrograma= source.Prestamo_IdPrograma;	
			target.Prestamo_Numero= source.Prestamo_Numero;	
			target.Prestamo_Denominacion= source.Prestamo_Denominacion;	
			target.Prestamo_Descripcion= source.Prestamo_Descripcion;	
			target.Prestamo_Observacion= source.Prestamo_Observacion;	
			target.Prestamo_FechaAlta= source.Prestamo_FechaAlta;	
			target.Prestamo_FechaModificacion= source.Prestamo_FechaModificacion;	
			target.Prestamo_IdUsuarioModificacion= source.Prestamo_IdUsuarioModificacion;	
			target.Prestamo_IdEstadoActual= source.Prestamo_IdEstadoActual;	
			target.Prestamo_ResponsablePolitico= source.Prestamo_ResponsablePolitico;	
			target.Prestamo_ResponsableTecnico= source.Prestamo_ResponsableTecnico;	
			target.Prestamo_CodigoVinculacion1= source.Prestamo_CodigoVinculacion1;	
			target.Prestamo_CodigoVinculacion2= source.Prestamo_CodigoVinculacion2;	
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
			target.ProyectoOrigenFinancianmientoTipo_Nombre= source.ProyectoOrigenFinancianmientoTipo_Nombre;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoOrigenFinanciamiento source,ProyectoOrigenFinanciamiento target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoOrigenFinanciamiento.Equals(target.IdProyectoOrigenFinanciamiento))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if(!source.IdProyectoOrigenFinancianmientoTipo.Equals(target.IdProyectoOrigenFinancianmientoTipo))return false;
		  if(!source.IdPrestamo.Equals(target.IdPrestamo))return false;
		 
		  return true;
        }
		public override bool Equals(ProyectoOrigenFinanciamientoResult source,ProyectoOrigenFinanciamientoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoOrigenFinanciamiento.Equals(target.IdProyectoOrigenFinanciamiento))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if(!source.IdProyectoOrigenFinancianmientoTipo.Equals(target.IdProyectoOrigenFinancianmientoTipo))return false;
		  if(!source.IdPrestamo.Equals(target.IdPrestamo))return false;
		  if(!source.Prestamo_IdPrograma.Equals(target.Prestamo_IdPrograma))return false;
					  if(!source.Prestamo_Numero.Equals(target.Prestamo_Numero))return false;
					  if((source.Prestamo_Denominacion == null)?target.Prestamo_Denominacion!=null:!source.Prestamo_Denominacion.Equals(target.Prestamo_Denominacion))return false;
						 if((source.Prestamo_Descripcion == null)?target.Prestamo_Descripcion!=null:!source.Prestamo_Descripcion.Equals(target.Prestamo_Descripcion))return false;
						 if((source.Prestamo_Observacion == null)?target.Prestamo_Observacion!=null:!source.Prestamo_Observacion.Equals(target.Prestamo_Observacion))return false;
						 if(!source.Prestamo_FechaAlta.Equals(target.Prestamo_FechaAlta))return false;
					  if(!source.Prestamo_FechaModificacion.Equals(target.Prestamo_FechaModificacion))return false;
					  if(!source.Prestamo_IdUsuarioModificacion.Equals(target.Prestamo_IdUsuarioModificacion))return false;
					  if((source.Prestamo_IdEstadoActual == null)?(target.Prestamo_IdEstadoActual.HasValue ):!source.Prestamo_IdEstadoActual.Equals(target.Prestamo_IdEstadoActual))return false;
						 if((source.Prestamo_ResponsablePolitico == null)?target.Prestamo_ResponsablePolitico!=null:!source.Prestamo_ResponsablePolitico.Equals(target.Prestamo_ResponsablePolitico))return false;
						 if((source.Prestamo_ResponsableTecnico == null)?target.Prestamo_ResponsableTecnico!=null:!source.Prestamo_ResponsableTecnico.Equals(target.Prestamo_ResponsableTecnico))return false;
						 if((source.Prestamo_CodigoVinculacion1 == null)?target.Prestamo_CodigoVinculacion1!=null:!source.Prestamo_CodigoVinculacion1.Equals(target.Prestamo_CodigoVinculacion1))return false;
						 if((source.Prestamo_CodigoVinculacion2 == null)?target.Prestamo_CodigoVinculacion2!=null:!source.Prestamo_CodigoVinculacion2.Equals(target.Prestamo_CodigoVinculacion2))return false;
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
					  if((source.ProyectoOrigenFinancianmientoTipo_Nombre == null)?target.ProyectoOrigenFinancianmientoTipo_Nombre!=null:!source.ProyectoOrigenFinancianmientoTipo_Nombre.Equals(target.ProyectoOrigenFinancianmientoTipo_Nombre))return false;
								
		  return true;
        }
		#endregion
    }
}

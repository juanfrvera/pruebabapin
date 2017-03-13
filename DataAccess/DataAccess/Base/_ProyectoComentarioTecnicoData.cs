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
    public abstract class _ProyectoComentarioTecnicoData : EntityData<ProyectoComentarioTecnico,ProyectoComentarioTecnicoFilter,ProyectoComentarioTecnicoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoComentarioTecnico entity)
		{			
			return entity.IdProyectoComentarioTecnico;
		}		
		public override ProyectoComentarioTecnico GetByEntity(ProyectoComentarioTecnico entity)
        {
            return this.GetById(entity.IdProyectoComentarioTecnico);
        }
        public override ProyectoComentarioTecnico GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoComentarioTecnico == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoComentarioTecnico> Query(ProyectoComentarioTecnicoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoComentarioTecnico == null || o.IdProyectoComentarioTecnico >=  filter.IdProyectoComentarioTecnico) && (filter.IdProyectoComentarioTecnico_To == null || o.IdProyectoComentarioTecnico <= filter.IdProyectoComentarioTecnico_To)
					  && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto==filter.IdProyecto)
					  && (filter.IdProyectoIsNull == null || filter.IdProyectoIsNull == true || o.IdProyecto != null ) && (filter.IdProyectoIsNull == null || filter.IdProyectoIsNull == false || o.IdProyecto == null)
					  && (filter.IdComentarioTecnico == null || filter.IdComentarioTecnico == 0 || o.IdComentarioTecnico==filter.IdComentarioTecnico)
					  && (filter.Observacion == null || filter.Observacion.Trim() == string.Empty || filter.Observacion.Trim() == "%"  || (filter.Observacion.EndsWith("%") && filter.Observacion.StartsWith("%") && (o.Observacion.Contains(filter.Observacion.Replace("%", "")))) || (filter.Observacion.EndsWith("%") && o.Observacion.StartsWith(filter.Observacion.Replace("%",""))) || (filter.Observacion.StartsWith("%") && o.Observacion.EndsWith(filter.Observacion.Replace("%",""))) || o.Observacion == filter.Observacion )
					  && (filter.IdUsuario == null || o.IdUsuario >=  filter.IdUsuario) && (filter.IdUsuario_To == null || o.IdUsuario <= filter.IdUsuario_To)
					  && (filter.Fecha == null || filter.Fecha == DateTime.MinValue || o.Fecha >=  filter.Fecha) && (filter.Fecha_To == null || filter.Fecha_To == DateTime.MinValue || o.Fecha <= filter.Fecha_To)
					  && (filter.FechaAlta == null || filter.FechaAlta == DateTime.MinValue || o.FechaAlta >=  filter.FechaAlta) && (filter.FechaAlta_To == null || filter.FechaAlta_To == DateTime.MinValue || o.FechaAlta <= filter.FechaAlta_To)
					  && (filter.IdPrestamo == null || filter.IdPrestamo == 0 || o.IdPrestamo==filter.IdPrestamo)
					  && (filter.IdPrestamoIsNull == null || filter.IdPrestamoIsNull == true || o.IdPrestamo != null ) && (filter.IdPrestamoIsNull == null || filter.IdPrestamoIsNull == false || o.IdPrestamo == null)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoComentarioTecnicoResult> QueryResult(ProyectoComentarioTecnicoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.ComentarioTecnicos on o.IdComentarioTecnico equals t1.IdComentarioTecnico   
				   join _t2  in this.Context.Prestamos on o.IdPrestamo equals _t2.IdPrestamo into tt2 from t2 in tt2.DefaultIfEmpty()
				   join _t3  in this.Context.Proyectos on o.IdProyecto equals _t3.IdProyecto into tt3 from t3 in tt3.DefaultIfEmpty()
				   select new ProyectoComentarioTecnicoResult(){
					 IdProyectoComentarioTecnico=o.IdProyectoComentarioTecnico
					 ,IdProyecto=o.IdProyecto
					 ,IdComentarioTecnico=o.IdComentarioTecnico
					 ,Observacion=o.Observacion
					 ,IdUsuario=o.IdUsuario
					 ,Fecha=o.Fecha
					 ,FechaAlta=o.FechaAlta
					 ,IdPrestamo=o.IdPrestamo
					,ComentarioTecnico_Nombre= t1.Nombre	
						,ComentarioTecnico_Activo= t1.Activo	
                        //,Prestamo_IdPrograma= t2!=null?(int?)t2.IdPrograma:null	
						,Prestamo_Numero= t2!=null?(int?)t2.Numero:null	
						,Prestamo_Denominacion= t2!=null?(string)t2.Denominacion:null	
                        //,Prestamo_Descripcion= t2!=null?(string)t2.Descripcion:null	
                        //,Prestamo_Observacion= t2!=null?(string)t2.Observacion:null	
                        //,Prestamo_FechaAlta= t2!=null?(DateTime?)t2.FechaAlta:null	
                        //,Prestamo_FechaModificacion= t2!=null?(DateTime?)t2.FechaModificacion:null	
                        //,Prestamo_IdUsuarioModificacion= t2!=null?(int?)t2.IdUsuarioModificacion:null	
                        //,Prestamo_IdEstadoActual= t2!=null?(int?)t2.IdEstadoActual:null	
                        //,Prestamo_ResponsablePolitico= t2!=null?(string)t2.ResponsablePolitico:null	
                        //,Prestamo_ResponsableTecnico= t2!=null?(string)t2.ResponsableTecnico:null	
                        //,Prestamo_CodigoVinculacion1= t2!=null?(string)t2.CodigoVinculacion1:null	
                        //,Prestamo_CodigoVinculacion2= t2!=null?(string)t2.CodigoVinculacion2:null	
                        //,Prestamo_Activo= t2!=null?(bool?)t2.Activo:null	
                        //,Proyecto_IdTipoProyecto= t3!=null?(int?)t3.IdTipoProyecto:null	
                        //,Proyecto_IdSubPrograma= t3!=null?(int?)t3.IdSubPrograma:null	
						,Proyecto_Codigo= t3!=null?(int?)t3.Codigo:null	
						,Proyecto_ProyectoDenominacion= t3!=null?(string)t3.ProyectoDenominacion:null	
                        //,Proyecto_ProyectoSituacionActual= t3!=null?(string)t3.ProyectoSituacionActual:null	
                        //,Proyecto_ProyectoDescripcion= t3!=null?(string)t3.ProyectoDescripcion:null	
                        //,Proyecto_ProyectoObservacion= t3!=null?(string)t3.ProyectoObservacion:null	
                        //,Proyecto_IdEstado= t3!=null?(int?)t3.IdEstado:null	
                        //,Proyecto_IdProceso= t3!=null?(int?)t3.IdProceso:null	
                        //,Proyecto_IdModalidadContratacion= t3!=null?(int?)t3.IdModalidadContratacion:null	
                        //,Proyecto_IdFinalidadFuncion= t3!=null?(int?)t3.IdFinalidadFuncion:null	
                        //,Proyecto_IdOrganismoPrioridad= t3!=null?(int?)t3.IdOrganismoPrioridad:null	
                        //,Proyecto_SubPrioridad= t3!=null?(int?)t3.SubPrioridad:null	
                        //,Proyecto_EsBorrador= t3!=null?(bool?)t3.EsBorrador:null	
                        //,Proyecto_EsProyecto= t3!=null?(bool?)t3.EsProyecto:null	
                        ,Proyecto_NroProyecto= t3!=null?(int?)t3.NroProyecto:null	
                        //,Proyecto_AnioCorriente= t3!=null?(int?)t3.AnioCorriente:null	
                        //,Proyecto_FechaInicioEjecucionCalculada= t3!=null?(DateTime?)t3.FechaInicioEjecucionCalculada:null	
                        //,Proyecto_FechaFinEjecucionCalculada= t3!=null?(DateTime?)t3.FechaFinEjecucionCalculada:null	
                        //,Proyecto_FechaAlta= t3!=null?(DateTime?)t3.FechaAlta:null	
                        //,Proyecto_FechaModificacion= t3!=null?(DateTime?)t3.FechaModificacion:null	
                        //,Proyecto_IdUsuarioModificacion= t3!=null?(int?)t3.IdUsuarioModificacion:null	
                        //,Proyecto_IdProyectoPlan= t3!=null?(int?)t3.IdProyectoPlan:null	
                        //,Proyecto_EvaluarValidaciones= t3!=null?(bool?)t3.EvaluarValidaciones:null	
                        //,Proyecto_Activo= t3!=null?(bool?)t3.Activo:null	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoComentarioTecnico Copy(nc.ProyectoComentarioTecnico entity)
        {           
            nc.ProyectoComentarioTecnico _new = new nc.ProyectoComentarioTecnico();
		 _new.IdProyecto= entity.IdProyecto;
		 _new.IdComentarioTecnico= entity.IdComentarioTecnico;
		 _new.Observacion= entity.Observacion;
		 _new.IdUsuario= entity.IdUsuario;
		 _new.Fecha= entity.Fecha;
		 _new.FechaAlta= entity.FechaAlta;
		 _new.IdPrestamo= entity.IdPrestamo;
		return _new;			
        }
		public override int CopyAndSave(ProyectoComentarioTecnico entity,string renameFormat)
        {
            ProyectoComentarioTecnico  newEntity = Copy(entity);
            newEntity.Observacion = string.Format(renameFormat,newEntity.Observacion);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoComentarioTecnico entity, int id)
        {            
            entity.IdProyectoComentarioTecnico = id;            
        }
		public override void Set(ProyectoComentarioTecnico source,ProyectoComentarioTecnico target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoComentarioTecnico= source.IdProyectoComentarioTecnico ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdComentarioTecnico= source.IdComentarioTecnico ;
		 target.Observacion= source.Observacion ;
		 target.IdUsuario= source.IdUsuario ;
		 target.Fecha= source.Fecha ;
		 target.FechaAlta= source.FechaAlta ;
		 target.IdPrestamo= source.IdPrestamo ;
		 		  
		}
		public override void Set(ProyectoComentarioTecnicoResult source,ProyectoComentarioTecnico target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoComentarioTecnico= source.IdProyectoComentarioTecnico ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdComentarioTecnico= source.IdComentarioTecnico ;
		 target.Observacion= source.Observacion ;
		 target.IdUsuario= source.IdUsuario ;
		 target.Fecha= source.Fecha ;
		 target.FechaAlta= source.FechaAlta ;
		 target.IdPrestamo= source.IdPrestamo ;
		 
		}
		public override void Set(ProyectoComentarioTecnico source,ProyectoComentarioTecnicoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoComentarioTecnico= source.IdProyectoComentarioTecnico ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdComentarioTecnico= source.IdComentarioTecnico ;
		 target.Observacion= source.Observacion ;
		 target.IdUsuario= source.IdUsuario ;
		 target.Fecha= source.Fecha ;
		 target.FechaAlta= source.FechaAlta ;
		 target.IdPrestamo= source.IdPrestamo ;
		 	
		}		
		public override void Set(ProyectoComentarioTecnicoResult source,ProyectoComentarioTecnicoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoComentarioTecnico= source.IdProyectoComentarioTecnico ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdComentarioTecnico= source.IdComentarioTecnico ;
		 target.Observacion= source.Observacion ;
		 target.IdUsuario= source.IdUsuario ;
		 target.Fecha= source.Fecha ;
		 target.FechaAlta= source.FechaAlta ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.ComentarioTecnico_Nombre= source.ComentarioTecnico_Nombre;	
			target.ComentarioTecnico_Activo= source.ComentarioTecnico_Activo;	
			target.Prestamo_IdPrograma= source.Prestamo_IdPrograma;	
            //target.Prestamo_Numero= source.Prestamo_Numero;	
            //target.Prestamo_Denominacion= source.Prestamo_Denominacion;	
            //target.Prestamo_Descripcion= source.Prestamo_Descripcion;	
            //target.Prestamo_Observacion= source.Prestamo_Observacion;	
            //target.Prestamo_FechaAlta= source.Prestamo_FechaAlta;	
            //target.Prestamo_FechaModificacion= source.Prestamo_FechaModificacion;	
            //target.Prestamo_IdUsuarioModificacion= source.Prestamo_IdUsuarioModificacion;	
            //target.Prestamo_IdEstadoActual= source.Prestamo_IdEstadoActual;	
            //target.Prestamo_ResponsablePolitico= source.Prestamo_ResponsablePolitico;	
            //target.Prestamo_ResponsableTecnico= source.Prestamo_ResponsableTecnico;	
            //target.Prestamo_CodigoVinculacion1= source.Prestamo_CodigoVinculacion1;	
            //target.Prestamo_CodigoVinculacion2= source.Prestamo_CodigoVinculacion2;	
            //target.Prestamo_Activo= source.Prestamo_Activo;	
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
		public override bool Equals(ProyectoComentarioTecnico source,ProyectoComentarioTecnico target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoComentarioTecnico.Equals(target.IdProyectoComentarioTecnico))return false;
		  if((source.IdProyecto == null)?(target.IdProyecto.HasValue && target.IdProyecto.Value > 0):!source.IdProyecto.Equals(target.IdProyecto))return false;
						  if(!source.IdComentarioTecnico.Equals(target.IdComentarioTecnico))return false;
		  if((source.Observacion == null)?target.Observacion!=null:  !( (target.Observacion== String.Empty && source.Observacion== null) || (target.Observacion==null && source.Observacion== String.Empty )) &&  !source.Observacion.Trim().Replace ("\r","").Equals(target.Observacion.Trim().Replace ("\r","")))return false;
			 if(!source.IdUsuario.Equals(target.IdUsuario))return false;
		  if(!source.Fecha.Equals(target.Fecha))return false;
		  if(!source.FechaAlta.Equals(target.FechaAlta))return false;
		  if((source.IdPrestamo == null)?(target.IdPrestamo.HasValue && target.IdPrestamo.Value > 0):!source.IdPrestamo.Equals(target.IdPrestamo))return false;
						 
		  return true;
        }
		public override bool Equals(ProyectoComentarioTecnicoResult source,ProyectoComentarioTecnicoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoComentarioTecnico.Equals(target.IdProyectoComentarioTecnico))return false;
		  if((source.IdProyecto == null)?(target.IdProyecto.HasValue && target.IdProyecto.Value > 0):!source.IdProyecto.Equals(target.IdProyecto))return false;
						  if(!source.IdComentarioTecnico.Equals(target.IdComentarioTecnico))return false;
		  if((source.Observacion == null)?target.Observacion!=null: !( (target.Observacion== String.Empty && source.Observacion== null) || (target.Observacion==null && source.Observacion== String.Empty )) && !source.Observacion.Trim().Replace ("\r","").Equals(target.Observacion.Trim().Replace ("\r","")))return false;
			 if(!source.IdUsuario.Equals(target.IdUsuario))return false;
		  if(!source.Fecha.Equals(target.Fecha))return false;
		  if(!source.FechaAlta.Equals(target.FechaAlta))return false;
		  if((source.IdPrestamo == null)?(target.IdPrestamo.HasValue && target.IdPrestamo.Value > 0):!source.IdPrestamo.Equals(target.IdPrestamo))return false;
						  if((source.ComentarioTecnico_Nombre == null)?target.ComentarioTecnico_Nombre!=null: !( (target.ComentarioTecnico_Nombre== String.Empty && source.ComentarioTecnico_Nombre== null) || (target.ComentarioTecnico_Nombre==null && source.ComentarioTecnico_Nombre== String.Empty )) &&   !source.ComentarioTecnico_Nombre.Trim().Replace ("\r","").Equals(target.ComentarioTecnico_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.ComentarioTecnico_Activo.Equals(target.ComentarioTecnico_Activo))return false;
                      //if(!source.Prestamo_IdPrograma.Equals(target.Prestamo_IdPrograma))return false;
                      //if(!source.Prestamo_Numero.Equals(target.Prestamo_Numero))return false;
                      //if((source.Prestamo_Denominacion == null)?target.Prestamo_Denominacion!=null: !( (target.Prestamo_Denominacion== String.Empty && source.Prestamo_Denominacion== null) || (target.Prestamo_Denominacion==null && source.Prestamo_Denominacion== String.Empty )) &&   !source.Prestamo_Denominacion.Trim().Replace ("\r","").Equals(target.Prestamo_Denominacion.Trim().Replace ("\r","")))return false;
                      //   if((source.Prestamo_Descripcion == null)?target.Prestamo_Descripcion!=null: !( (target.Prestamo_Descripcion== String.Empty && source.Prestamo_Descripcion== null) || (target.Prestamo_Descripcion==null && source.Prestamo_Descripcion== String.Empty )) &&   !source.Prestamo_Descripcion.Trim().Replace ("\r","").Equals(target.Prestamo_Descripcion.Trim().Replace ("\r","")))return false;
                      //   if((source.Prestamo_Observacion == null)?target.Prestamo_Observacion!=null: !( (target.Prestamo_Observacion== String.Empty && source.Prestamo_Observacion== null) || (target.Prestamo_Observacion==null && source.Prestamo_Observacion== String.Empty )) &&   !source.Prestamo_Observacion.Trim().Replace ("\r","").Equals(target.Prestamo_Observacion.Trim().Replace ("\r","")))return false;
                      //   if(!source.Prestamo_FechaAlta.Equals(target.Prestamo_FechaAlta))return false;
                      //if(!source.Prestamo_FechaModificacion.Equals(target.Prestamo_FechaModificacion))return false;
                      //if(!source.Prestamo_IdUsuarioModificacion.Equals(target.Prestamo_IdUsuarioModificacion))return false;
                      //if((source.Prestamo_IdEstadoActual == null)?(target.Prestamo_IdEstadoActual.HasValue ):!source.Prestamo_IdEstadoActual.Equals(target.Prestamo_IdEstadoActual))return false;
                      //   if((source.Prestamo_ResponsablePolitico == null)?target.Prestamo_ResponsablePolitico!=null: !( (target.Prestamo_ResponsablePolitico== String.Empty && source.Prestamo_ResponsablePolitico== null) || (target.Prestamo_ResponsablePolitico==null && source.Prestamo_ResponsablePolitico== String.Empty )) &&   !source.Prestamo_ResponsablePolitico.Trim().Replace ("\r","").Equals(target.Prestamo_ResponsablePolitico.Trim().Replace ("\r","")))return false;
                      //   if((source.Prestamo_ResponsableTecnico == null)?target.Prestamo_ResponsableTecnico!=null: !( (target.Prestamo_ResponsableTecnico== String.Empty && source.Prestamo_ResponsableTecnico== null) || (target.Prestamo_ResponsableTecnico==null && source.Prestamo_ResponsableTecnico== String.Empty )) &&   !source.Prestamo_ResponsableTecnico.Trim().Replace ("\r","").Equals(target.Prestamo_ResponsableTecnico.Trim().Replace ("\r","")))return false;
                      //   if((source.Prestamo_CodigoVinculacion1 == null)?target.Prestamo_CodigoVinculacion1!=null: !( (target.Prestamo_CodigoVinculacion1== String.Empty && source.Prestamo_CodigoVinculacion1== null) || (target.Prestamo_CodigoVinculacion1==null && source.Prestamo_CodigoVinculacion1== String.Empty )) &&   !source.Prestamo_CodigoVinculacion1.Trim().Replace ("\r","").Equals(target.Prestamo_CodigoVinculacion1.Trim().Replace ("\r","")))return false;
                      //   if((source.Prestamo_CodigoVinculacion2 == null)?target.Prestamo_CodigoVinculacion2!=null: !( (target.Prestamo_CodigoVinculacion2== String.Empty && source.Prestamo_CodigoVinculacion2== null) || (target.Prestamo_CodigoVinculacion2==null && source.Prestamo_CodigoVinculacion2== String.Empty )) &&   !source.Prestamo_CodigoVinculacion2.Trim().Replace ("\r","").Equals(target.Prestamo_CodigoVinculacion2.Trim().Replace ("\r","")))return false;
                      //   if(!source.Prestamo_Activo.Equals(target.Prestamo_Activo))return false;
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

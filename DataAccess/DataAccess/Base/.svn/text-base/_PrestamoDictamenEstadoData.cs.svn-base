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
    public abstract class _PrestamoDictamenEstadoData : EntityData<PrestamoDictamenEstado,PrestamoDictamenEstadoFilter,PrestamoDictamenEstadoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.PrestamoDictamenEstado entity)
		{			
			return entity.IdPrestamoDictamenEstado;
		}		
		public override PrestamoDictamenEstado GetByEntity(PrestamoDictamenEstado entity)
        {
            return this.GetById(entity.IdPrestamoDictamenEstado);
        }
        public override PrestamoDictamenEstado GetById(int id)
        {
            return (from o in this.Table where o.IdPrestamoDictamenEstado == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<PrestamoDictamenEstado> Query(PrestamoDictamenEstadoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPrestamoDictamenEstado == null || o.IdPrestamoDictamenEstado >=  filter.IdPrestamoDictamenEstado) && (filter.IdPrestamoDictamenEstado_To == null || o.IdPrestamoDictamenEstado <= filter.IdPrestamoDictamenEstado_To)
					  && (filter.IdPrestamoDictamen == null || filter.IdPrestamoDictamen == 0 || o.IdPrestamoDictamen==filter.IdPrestamoDictamen)
					  && (filter.IdEstado == null || filter.IdEstado == 0 || o.IdEstado==filter.IdEstado)
					  && (filter.Fecha == null || filter.Fecha == DateTime.MinValue || o.Fecha >=  filter.Fecha) && (filter.Fecha_To == null || filter.Fecha_To == DateTime.MinValue || o.Fecha <= filter.Fecha_To)
					  && (filter.Observacion == null || filter.Observacion.Trim() == string.Empty || filter.Observacion.Trim() == "%"  || (filter.Observacion.EndsWith("%") && filter.Observacion.StartsWith("%") && (o.Observacion.Contains(filter.Observacion.Replace("%", "")))) || (filter.Observacion.EndsWith("%") && o.Observacion.StartsWith(filter.Observacion.Replace("%",""))) || (filter.Observacion.StartsWith("%") && o.Observacion.EndsWith(filter.Observacion.Replace("%",""))) || o.Observacion == filter.Observacion )
					  && (filter.IdUsuario == null || filter.IdUsuario == 0 || o.IdUsuario==filter.IdUsuario)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PrestamoDictamenEstadoResult> QueryResult(PrestamoDictamenEstadoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Estados on o.IdEstado equals t1.IdEstado   
				    join t2  in this.Context.PrestamoDictamens on o.IdPrestamoDictamen equals t2.IdPrestamoDictamen   
				    join t3  in this.Context.Usuarios on o.IdUsuario equals t3.IdUsuario   
				   select new PrestamoDictamenEstadoResult(){
					 IdPrestamoDictamenEstado=o.IdPrestamoDictamenEstado
					 ,IdPrestamoDictamen=o.IdPrestamoDictamen
					 ,IdEstado=o.IdEstado
					 ,Fecha=o.Fecha
					 ,Observacion=o.Observacion
					 ,IdUsuario=o.IdUsuario
					,Estado_Nombre= t1.Nombre	
						,Estado_Codigo= t1.Codigo	
						,Estado_Orden= t1.Orden	
						,Estado_Descripcion= t1.Descripcion	
						,Estado_Activo= t1.Activo	
                        //,PrestamoDictamen_Expediente= t2.Expediente	
                        //,PrestamoDictamen_IDOrganismo= t2.IDOrganismo	
                        //,PrestamoDictamen_OrganismoDetalle= t2.OrganismoDetalle	
                        //,PrestamoDictamen_Denominacion= t2.Denominacion	
                        //,PrestamoDictamen_IdGestionTipo= t2.IdGestionTipo	
                        //,PrestamoDictamen_IdOrganismoFinanciero= t2.IdOrganismoFinanciero	
                        //,PrestamoDictamen_MontoTotal= t2.MontoTotal	
                        //,PrestamoDictamen_MontoPrestamo= t2.MontoPrestamo	
                        //,PrestamoDictamen_MontoContraparteLocal= t2.MontoContraparteLocal	
                        //,PrestamoDictamen_MontoOtros= t2.MontoOtros	
                        //,PrestamoDictamen_IdAnalista= t2.IdAnalista	
                        //,PrestamoDictamen_IdPrestamo= t2.IdPrestamo	
                        //,PrestamoDictamen_IdPrestamoDictamenRelacionado= t2.IdPrestamoDictamenRelacionado	
                        //,PrestamoDictamen_Comentario= t2.Comentario	
                        //,PrestamoDictamen_IDPrestamoCalificacion= t2.IDPrestamoCalificacion	
                        //,PrestamoDictamen_CalificacionFecha= t2.CalificacionFecha	
                        //,PrestamoDictamen_CalificacionITecnico= t2.CalificacionITecnico	
                        //,PrestamoDictamen_CalificacionITFecha= t2.CalificacionITFecha	
                        //,PrestamoDictamen_CalificacionNotaDNIP= t2.CalificacionNotaDNIP	
                        //,PrestamoDictamen_CalificacionObservacion= t2.CalificacionObservacion	
                        //,PrestamoDictamen_CalificacionRecomendacion= t2.CalificacionRecomendacion	
                        //,PrestamoDictamen_FechaAlta= t2.FechaAlta	
                        //,PrestamoDictamen_FechaModificacion= t2.FechaModificacion	
                        //,PrestamoDictamen_IDUsuarioModificacion= t2.IDUsuarioModificacion	
                        //,PrestamoDictamen_IdEstado= t2.IdEstado	
                        //,PrestamoDictamen_FechaEstado= t2.FechaEstado	
						,Usuario_NombreUsuario= t3.NombreUsuario	
                        //,Usuario_Clave= t3.Clave	
                        //,Usuario_Activo= t3.Activo	
                        //,Usuario_EsSectioralista= t3.EsSectioralista	
                        //,Usuario_IdLanguage= t3.IdLanguage	
                        //,Usuario_AccesoTotal= t3.AccesoTotal	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.PrestamoDictamenEstado Copy(nc.PrestamoDictamenEstado entity)
        {           
            nc.PrestamoDictamenEstado _new = new nc.PrestamoDictamenEstado();
		 _new.IdPrestamoDictamen= entity.IdPrestamoDictamen;
		 _new.IdEstado= entity.IdEstado;
		 _new.Fecha= entity.Fecha;
		 _new.Observacion= entity.Observacion;
		 _new.IdUsuario= entity.IdUsuario;
		return _new;			
        }
		public override int CopyAndSave(PrestamoDictamenEstado entity,string renameFormat)
        {
            PrestamoDictamenEstado  newEntity = Copy(entity);
            newEntity.Observacion = string.Format(renameFormat,newEntity.Observacion);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(PrestamoDictamenEstado entity, int id)
        {            
            entity.IdPrestamoDictamenEstado = id;            
        }
		public override void Set(PrestamoDictamenEstado source,PrestamoDictamenEstado target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoDictamenEstado= source.IdPrestamoDictamenEstado ;
		 target.IdPrestamoDictamen= source.IdPrestamoDictamen ;
		 target.IdEstado= source.IdEstado ;
		 target.Fecha= source.Fecha ;
		 target.Observacion= source.Observacion ;
		 target.IdUsuario= source.IdUsuario ;
		 		  
		}
		public override void Set(PrestamoDictamenEstadoResult source,PrestamoDictamenEstado target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoDictamenEstado= source.IdPrestamoDictamenEstado ;
		 target.IdPrestamoDictamen= source.IdPrestamoDictamen ;
		 target.IdEstado= source.IdEstado ;
		 target.Fecha= source.Fecha ;
		 target.Observacion= source.Observacion ;
		 target.IdUsuario= source.IdUsuario ;
		 
		}
		public override void Set(PrestamoDictamenEstado source,PrestamoDictamenEstadoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoDictamenEstado= source.IdPrestamoDictamenEstado ;
		 target.IdPrestamoDictamen= source.IdPrestamoDictamen ;
		 target.IdEstado= source.IdEstado ;
		 target.Fecha= source.Fecha ;
		 target.Observacion= source.Observacion ;
		 target.IdUsuario= source.IdUsuario ;
		 	
		}		
		public override void Set(PrestamoDictamenEstadoResult source,PrestamoDictamenEstadoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoDictamenEstado= source.IdPrestamoDictamenEstado ;
		 target.IdPrestamoDictamen= source.IdPrestamoDictamen ;
		 target.IdEstado= source.IdEstado ;
		 target.Fecha= source.Fecha ;
		 target.Observacion= source.Observacion ;
		 target.IdUsuario= source.IdUsuario ;
		 target.Estado_Nombre= source.Estado_Nombre;	
			target.Estado_Codigo= source.Estado_Codigo;	
			target.Estado_Orden= source.Estado_Orden;	
			target.Estado_Descripcion= source.Estado_Descripcion;	
			target.Estado_Activo= source.Estado_Activo;	
            //target.PrestamoDictamen_Expediente= source.PrestamoDictamen_Expediente;	
            //target.PrestamoDictamen_IDOrganismo= source.PrestamoDictamen_IDOrganismo;	
            //target.PrestamoDictamen_OrganismoDetalle= source.PrestamoDictamen_OrganismoDetalle;	
            //target.PrestamoDictamen_Denominacion= source.PrestamoDictamen_Denominacion;	
            //target.PrestamoDictamen_IdGestionTipo= source.PrestamoDictamen_IdGestionTipo;	
            //target.PrestamoDictamen_IdOrganismoFinanciero= source.PrestamoDictamen_IdOrganismoFinanciero;	
            //target.PrestamoDictamen_MontoTotal= source.PrestamoDictamen_MontoTotal;	
            //target.PrestamoDictamen_MontoPrestamo= source.PrestamoDictamen_MontoPrestamo;	
            //target.PrestamoDictamen_MontoContraparteLocal= source.PrestamoDictamen_MontoContraparteLocal;	
            //target.PrestamoDictamen_MontoOtros= source.PrestamoDictamen_MontoOtros;	
            //target.PrestamoDictamen_IdAnalista= source.PrestamoDictamen_IdAnalista;	
            //target.PrestamoDictamen_IdPrestamo= source.PrestamoDictamen_IdPrestamo;	
            //target.PrestamoDictamen_IdPrestamoDictamenRelacionado= source.PrestamoDictamen_IdPrestamoDictamenRelacionado;	
            //target.PrestamoDictamen_Comentario= source.PrestamoDictamen_Comentario;	
            //target.PrestamoDictamen_IDPrestamoCalificacion= source.PrestamoDictamen_IDPrestamoCalificacion;	
            //target.PrestamoDictamen_CalificacionFecha= source.PrestamoDictamen_CalificacionFecha;	
            //target.PrestamoDictamen_CalificacionITecnico= source.PrestamoDictamen_CalificacionITecnico;	
            //target.PrestamoDictamen_CalificacionITFecha= source.PrestamoDictamen_CalificacionITFecha;	
            //target.PrestamoDictamen_CalificacionNotaDNIP= source.PrestamoDictamen_CalificacionNotaDNIP;	
            //target.PrestamoDictamen_CalificacionObservacion= source.PrestamoDictamen_CalificacionObservacion;	
            //target.PrestamoDictamen_CalificacionRecomendacion= source.PrestamoDictamen_CalificacionRecomendacion;	
            //target.PrestamoDictamen_FechaAlta= source.PrestamoDictamen_FechaAlta;	
            //target.PrestamoDictamen_FechaModificacion= source.PrestamoDictamen_FechaModificacion;	
            //target.PrestamoDictamen_IDUsuarioModificacion= source.PrestamoDictamen_IDUsuarioModificacion;	
            //target.PrestamoDictamen_IdEstado= source.PrestamoDictamen_IdEstado;	
            //target.PrestamoDictamen_FechaEstado= source.PrestamoDictamen_FechaEstado;	
			target.Usuario_NombreUsuario= source.Usuario_NombreUsuario;	
            //target.Usuario_Clave= source.Usuario_Clave;	
            //target.Usuario_Activo= source.Usuario_Activo;	
            //target.Usuario_EsSectioralista= source.Usuario_EsSectioralista;	
            //target.Usuario_IdLanguage= source.Usuario_IdLanguage;	
            //target.Usuario_AccesoTotal= source.Usuario_AccesoTotal;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(PrestamoDictamenEstado source,PrestamoDictamenEstado target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoDictamenEstado.Equals(target.IdPrestamoDictamenEstado))return false;
		  if(!source.IdPrestamoDictamen.Equals(target.IdPrestamoDictamen))return false;
		  if(!source.IdEstado.Equals(target.IdEstado))return false;
		  if(!source.Fecha.Equals(target.Fecha))return false;
		  if((source.Observacion == null)?target.Observacion!=null:  !( (target.Observacion== String.Empty && source.Observacion== null) || (target.Observacion==null && source.Observacion== String.Empty )) &&  !source.Observacion.Trim().Replace ("\r","").Equals(target.Observacion.Trim().Replace ("\r","")))return false;
			 if(!source.IdUsuario.Equals(target.IdUsuario))return false;
		 
		  return true;
        }
		public override bool Equals(PrestamoDictamenEstadoResult source,PrestamoDictamenEstadoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoDictamenEstado.Equals(target.IdPrestamoDictamenEstado))return false;
		  if(!source.IdPrestamoDictamen.Equals(target.IdPrestamoDictamen))return false;
		  if(!source.IdEstado.Equals(target.IdEstado))return false;
		  if(!source.Fecha.Equals(target.Fecha))return false;
		  if((source.Observacion == null)?target.Observacion!=null: !( (target.Observacion== String.Empty && source.Observacion== null) || (target.Observacion==null && source.Observacion== String.Empty )) && !source.Observacion.Trim().Replace ("\r","").Equals(target.Observacion.Trim().Replace ("\r","")))return false;
			 if(!source.IdUsuario.Equals(target.IdUsuario))return false;
		  if((source.Estado_Nombre == null)?target.Estado_Nombre!=null: !( (target.Estado_Nombre== String.Empty && source.Estado_Nombre== null) || (target.Estado_Nombre==null && source.Estado_Nombre== String.Empty )) &&   !source.Estado_Nombre.Trim().Replace ("\r","").Equals(target.Estado_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.Estado_Codigo == null)?target.Estado_Codigo!=null: !( (target.Estado_Codigo== String.Empty && source.Estado_Codigo== null) || (target.Estado_Codigo==null && source.Estado_Codigo== String.Empty )) &&   !source.Estado_Codigo.Trim().Replace ("\r","").Equals(target.Estado_Codigo.Trim().Replace ("\r","")))return false;
						 if(!source.Estado_Orden.Equals(target.Estado_Orden))return false;
					  if((source.Estado_Descripcion == null)?target.Estado_Descripcion!=null: !( (target.Estado_Descripcion== String.Empty && source.Estado_Descripcion== null) || (target.Estado_Descripcion==null && source.Estado_Descripcion== String.Empty )) &&   !source.Estado_Descripcion.Trim().Replace ("\r","").Equals(target.Estado_Descripcion.Trim().Replace ("\r","")))return false;
						 if(!source.Estado_Activo.Equals(target.Estado_Activo))return false;
                      //if((source.PrestamoDictamen_Expediente == null)?target.PrestamoDictamen_Expediente!=null: !( (target.PrestamoDictamen_Expediente== String.Empty && source.PrestamoDictamen_Expediente== null) || (target.PrestamoDictamen_Expediente==null && source.PrestamoDictamen_Expediente== String.Empty )) &&   !source.PrestamoDictamen_Expediente.Trim().Replace ("\r","").Equals(target.PrestamoDictamen_Expediente.Trim().Replace ("\r","")))return false;
                      //   if(!source.PrestamoDictamen_IDOrganismo.Equals(target.PrestamoDictamen_IDOrganismo))return false;
                      //if((source.PrestamoDictamen_OrganismoDetalle == null)?target.PrestamoDictamen_OrganismoDetalle!=null: !( (target.PrestamoDictamen_OrganismoDetalle== String.Empty && source.PrestamoDictamen_OrganismoDetalle== null) || (target.PrestamoDictamen_OrganismoDetalle==null && source.PrestamoDictamen_OrganismoDetalle== String.Empty )) &&   !source.PrestamoDictamen_OrganismoDetalle.Trim().Replace ("\r","").Equals(target.PrestamoDictamen_OrganismoDetalle.Trim().Replace ("\r","")))return false;
                      //   if((source.PrestamoDictamen_Denominacion == null)?target.PrestamoDictamen_Denominacion!=null: !( (target.PrestamoDictamen_Denominacion== String.Empty && source.PrestamoDictamen_Denominacion== null) || (target.PrestamoDictamen_Denominacion==null && source.PrestamoDictamen_Denominacion== String.Empty )) &&   !source.PrestamoDictamen_Denominacion.Trim().Replace ("\r","").Equals(target.PrestamoDictamen_Denominacion.Trim().Replace ("\r","")))return false;
                      //   if(!source.PrestamoDictamen_IdGestionTipo.Equals(target.PrestamoDictamen_IdGestionTipo))return false;
                      //if(!source.PrestamoDictamen_IdOrganismoFinanciero.Equals(target.PrestamoDictamen_IdOrganismoFinanciero))return false;
                      //if((source.PrestamoDictamen_MontoTotal == null)?(target.PrestamoDictamen_MontoTotal.HasValue ):!source.PrestamoDictamen_MontoTotal.Equals(target.PrestamoDictamen_MontoTotal))return false;
                      //   if((source.PrestamoDictamen_MontoPrestamo == null)?(target.PrestamoDictamen_MontoPrestamo.HasValue ):!source.PrestamoDictamen_MontoPrestamo.Equals(target.PrestamoDictamen_MontoPrestamo))return false;
                      //   if((source.PrestamoDictamen_MontoContraparteLocal == null)?(target.PrestamoDictamen_MontoContraparteLocal.HasValue ):!source.PrestamoDictamen_MontoContraparteLocal.Equals(target.PrestamoDictamen_MontoContraparteLocal))return false;
                         //if((source.PrestamoDictamen_MontoOtros == null)?(target.PrestamoDictamen_MontoOtros.HasValue ):!source.PrestamoDictamen_MontoOtros.Equals(target.PrestamoDictamen_MontoOtros))return false;
                         //if((source.PrestamoDictamen_IdAnalista == null)?(target.PrestamoDictamen_IdAnalista.HasValue && target.PrestamoDictamen_IdAnalista.Value > 0):!source.PrestamoDictamen_IdAnalista.Equals(target.PrestamoDictamen_IdAnalista))return false;
                         //             if((source.PrestamoDictamen_IdPrestamo == null)?(target.PrestamoDictamen_IdPrestamo.HasValue && target.PrestamoDictamen_IdPrestamo.Value > 0):!source.PrestamoDictamen_IdPrestamo.Equals(target.PrestamoDictamen_IdPrestamo))return false;
                         //             if((source.PrestamoDictamen_IdPrestamoDictamenRelacionado == null)?(target.PrestamoDictamen_IdPrestamoDictamenRelacionado.HasValue && target.PrestamoDictamen_IdPrestamoDictamenRelacionado.Value > 0):!source.PrestamoDictamen_IdPrestamoDictamenRelacionado.Equals(target.PrestamoDictamen_IdPrestamoDictamenRelacionado))return false;
                         //             if((source.PrestamoDictamen_Comentario == null)?target.PrestamoDictamen_Comentario!=null: !( (target.PrestamoDictamen_Comentario== String.Empty && source.PrestamoDictamen_Comentario== null) || (target.PrestamoDictamen_Comentario==null && source.PrestamoDictamen_Comentario== String.Empty )) &&   !source.PrestamoDictamen_Comentario.Trim().Replace ("\r","").Equals(target.PrestamoDictamen_Comentario.Trim().Replace ("\r","")))return false;
                         //if((source.PrestamoDictamen_IDPrestamoCalificacion == null)?(target.PrestamoDictamen_IDPrestamoCalificacion.HasValue && target.PrestamoDictamen_IDPrestamoCalificacion.Value > 0):!source.PrestamoDictamen_IDPrestamoCalificacion.Equals(target.PrestamoDictamen_IDPrestamoCalificacion))return false;
                         //             if((source.PrestamoDictamen_CalificacionFecha == null)?(target.PrestamoDictamen_CalificacionFecha.HasValue ):!source.PrestamoDictamen_CalificacionFecha.Equals(target.PrestamoDictamen_CalificacionFecha))return false;
                         //if((source.PrestamoDictamen_CalificacionITecnico == null)?target.PrestamoDictamen_CalificacionITecnico!=null: !( (target.PrestamoDictamen_CalificacionITecnico== String.Empty && source.PrestamoDictamen_CalificacionITecnico== null) || (target.PrestamoDictamen_CalificacionITecnico==null && source.PrestamoDictamen_CalificacionITecnico== String.Empty )) &&   !source.PrestamoDictamen_CalificacionITecnico.Trim().Replace ("\r","").Equals(target.PrestamoDictamen_CalificacionITecnico.Trim().Replace ("\r","")))return false;
                      //   if((source.PrestamoDictamen_CalificacionITFecha == null)?(target.PrestamoDictamen_CalificacionITFecha.HasValue ):!source.PrestamoDictamen_CalificacionITFecha.Equals(target.PrestamoDictamen_CalificacionITFecha))return false;
                      //   if((source.PrestamoDictamen_CalificacionNotaDNIP == null)?target.PrestamoDictamen_CalificacionNotaDNIP!=null: !( (target.PrestamoDictamen_CalificacionNotaDNIP== String.Empty && source.PrestamoDictamen_CalificacionNotaDNIP== null) || (target.PrestamoDictamen_CalificacionNotaDNIP==null && source.PrestamoDictamen_CalificacionNotaDNIP== String.Empty )) &&   !source.PrestamoDictamen_CalificacionNotaDNIP.Trim().Replace ("\r","").Equals(target.PrestamoDictamen_CalificacionNotaDNIP.Trim().Replace ("\r","")))return false;
                      //   if((source.PrestamoDictamen_CalificacionObservacion == null)?target.PrestamoDictamen_CalificacionObservacion!=null: !( (target.PrestamoDictamen_CalificacionObservacion== String.Empty && source.PrestamoDictamen_CalificacionObservacion== null) || (target.PrestamoDictamen_CalificacionObservacion==null && source.PrestamoDictamen_CalificacionObservacion== String.Empty )) &&   !source.PrestamoDictamen_CalificacionObservacion.Trim().Replace ("\r","").Equals(target.PrestamoDictamen_CalificacionObservacion.Trim().Replace ("\r","")))return false;
                      //   if((source.PrestamoDictamen_CalificacionRecomendacion == null)?target.PrestamoDictamen_CalificacionRecomendacion!=null: !( (target.PrestamoDictamen_CalificacionRecomendacion== String.Empty && source.PrestamoDictamen_CalificacionRecomendacion== null) || (target.PrestamoDictamen_CalificacionRecomendacion==null && source.PrestamoDictamen_CalificacionRecomendacion== String.Empty )) &&   !source.PrestamoDictamen_CalificacionRecomendacion.Trim().Replace ("\r","").Equals(target.PrestamoDictamen_CalificacionRecomendacion.Trim().Replace ("\r","")))return false;
                      //   if(!source.PrestamoDictamen_FechaAlta.Equals(target.PrestamoDictamen_FechaAlta))return false;
                      //if(!source.PrestamoDictamen_FechaModificacion.Equals(target.PrestamoDictamen_FechaModificacion))return false;
                      //if(!source.PrestamoDictamen_IDUsuarioModificacion.Equals(target.PrestamoDictamen_IDUsuarioModificacion))return false;
                      //if((source.PrestamoDictamen_IdEstado == null)?(target.PrestamoDictamen_IdEstado.HasValue ):!source.PrestamoDictamen_IdEstado.Equals(target.PrestamoDictamen_IdEstado))return false;
                      //   if((source.PrestamoDictamen_FechaEstado == null)?(target.PrestamoDictamen_FechaEstado.HasValue ):!source.PrestamoDictamen_FechaEstado.Equals(target.PrestamoDictamen_FechaEstado))return false;
						 if((source.Usuario_NombreUsuario == null)?target.Usuario_NombreUsuario!=null: !( (target.Usuario_NombreUsuario== String.Empty && source.Usuario_NombreUsuario== null) || (target.Usuario_NombreUsuario==null && source.Usuario_NombreUsuario== String.Empty )) &&   !source.Usuario_NombreUsuario.Trim().Replace ("\r","").Equals(target.Usuario_NombreUsuario.Trim().Replace ("\r","")))return false;
                      //   if((source.Usuario_Clave == null)?target.Usuario_Clave!=null: !( (target.Usuario_Clave== String.Empty && source.Usuario_Clave== null) || (target.Usuario_Clave==null && source.Usuario_Clave== String.Empty )) &&   !source.Usuario_Clave.Trim().Replace ("\r","").Equals(target.Usuario_Clave.Trim().Replace ("\r","")))return false;
                      //   if(!source.Usuario_Activo.Equals(target.Usuario_Activo))return false;
                      //if(!source.Usuario_EsSectioralista.Equals(target.Usuario_EsSectioralista))return false;
                      //if(!source.Usuario_IdLanguage.Equals(target.Usuario_IdLanguage))return false;
                      //if(!source.Usuario_AccesoTotal.Equals(target.Usuario_AccesoTotal))return false;
					 		
		  return true;
        }
		#endregion
    }
}

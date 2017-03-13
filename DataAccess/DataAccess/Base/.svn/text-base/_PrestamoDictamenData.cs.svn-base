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
    public abstract class _PrestamoDictamenData : EntityData<PrestamoDictamen,PrestamoDictamenFilter,PrestamoDictamenResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.PrestamoDictamen entity)
		{			
			return entity.IdPrestamoDictamen;
		}		
		public override PrestamoDictamen GetByEntity(PrestamoDictamen entity)
        {
            return this.GetById(entity.IdPrestamoDictamen);
        }
        public override PrestamoDictamen GetById(int id)
        {
            return (from o in this.Table where o.IdPrestamoDictamen == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<PrestamoDictamen> Query(PrestamoDictamenFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPrestamoDictamen == null || filter.IdPrestamoDictamen == 0 || o.IdPrestamoDictamen==filter.IdPrestamoDictamen)
					  && (filter.Expediente == null || filter.Expediente.Trim() == string.Empty || filter.Expediente.Trim() == "%"  || (filter.Expediente.EndsWith("%") && filter.Expediente.StartsWith("%") && (o.Expediente.Contains(filter.Expediente.Replace("%", "")))) || (filter.Expediente.EndsWith("%") && o.Expediente.StartsWith(filter.Expediente.Replace("%",""))) || (filter.Expediente.StartsWith("%") && o.Expediente.EndsWith(filter.Expediente.Replace("%",""))) || o.Expediente == filter.Expediente )
					  && (filter.IDOrganismo == null || o.IDOrganismo >=  filter.IDOrganismo) && (filter.IDOrganismo_To == null || o.IDOrganismo <= filter.IDOrganismo_To)
					  && (filter.OrganismoDetalle == null || filter.OrganismoDetalle.Trim() == string.Empty || filter.OrganismoDetalle.Trim() == "%"  || (filter.OrganismoDetalle.EndsWith("%") && filter.OrganismoDetalle.StartsWith("%") && (o.OrganismoDetalle.Contains(filter.OrganismoDetalle.Replace("%", "")))) || (filter.OrganismoDetalle.EndsWith("%") && o.OrganismoDetalle.StartsWith(filter.OrganismoDetalle.Replace("%",""))) || (filter.OrganismoDetalle.StartsWith("%") && o.OrganismoDetalle.EndsWith(filter.OrganismoDetalle.Replace("%",""))) || o.OrganismoDetalle == filter.OrganismoDetalle )
					  && (filter.Denominacion == null || filter.Denominacion.Trim() == string.Empty || filter.Denominacion.Trim() == "%"  || (filter.Denominacion.EndsWith("%") && filter.Denominacion.StartsWith("%") && (o.Denominacion.Contains(filter.Denominacion.Replace("%", "")))) || (filter.Denominacion.EndsWith("%") && o.Denominacion.StartsWith(filter.Denominacion.Replace("%",""))) || (filter.Denominacion.StartsWith("%") && o.Denominacion.EndsWith(filter.Denominacion.Replace("%",""))) || o.Denominacion == filter.Denominacion )
					  && (filter.IdGestionTipo == null || o.IdGestionTipo >=  filter.IdGestionTipo) && (filter.IdGestionTipo_To == null || o.IdGestionTipo <= filter.IdGestionTipo_To)
					  && (filter.IdOrganismoFinanciero == null || o.IdOrganismoFinanciero >=  filter.IdOrganismoFinanciero) && (filter.IdOrganismoFinanciero_To == null || o.IdOrganismoFinanciero <= filter.IdOrganismoFinanciero_To)
					  && (filter.MontoTotal == null || o.MontoTotal >=  filter.MontoTotal) && (filter.MontoTotal_To == null || o.MontoTotal <= filter.MontoTotal_To)
					  && (filter.MontoTotalIsNull == null || filter.MontoTotalIsNull == true || o.MontoTotal != null ) && (filter.MontoTotalIsNull == null || filter.MontoTotalIsNull == false || o.MontoTotal == null)
					  && (filter.MontoPrestamo == null || o.MontoPrestamo >=  filter.MontoPrestamo) && (filter.MontoPrestamo_To == null || o.MontoPrestamo <= filter.MontoPrestamo_To)
					  && (filter.MontoPrestamoIsNull == null || filter.MontoPrestamoIsNull == true || o.MontoPrestamo != null ) && (filter.MontoPrestamoIsNull == null || filter.MontoPrestamoIsNull == false || o.MontoPrestamo == null)
					  && (filter.MontoContraparteLocal == null || o.MontoContraparteLocal >=  filter.MontoContraparteLocal) && (filter.MontoContraparteLocal_To == null || o.MontoContraparteLocal <= filter.MontoContraparteLocal_To)
					  && (filter.MontoContraparteLocalIsNull == null || filter.MontoContraparteLocalIsNull == true || o.MontoContraparteLocal != null ) && (filter.MontoContraparteLocalIsNull == null || filter.MontoContraparteLocalIsNull == false || o.MontoContraparteLocal == null)
					  && (filter.MontoOtros == null || o.MontoOtros >=  filter.MontoOtros) && (filter.MontoOtros_To == null || o.MontoOtros <= filter.MontoOtros_To)
					  && (filter.MontoOtrosIsNull == null || filter.MontoOtrosIsNull == true || o.MontoOtros != null ) && (filter.MontoOtrosIsNull == null || filter.MontoOtrosIsNull == false || o.MontoOtros == null)
					  && (filter.IdAnalista == null || o.IdAnalista >=  filter.IdAnalista) && (filter.IdAnalista_To == null || o.IdAnalista <= filter.IdAnalista_To)
					  && (filter.IdAnalistaIsNull == null || filter.IdAnalistaIsNull == true || o.IdAnalista != null ) && (filter.IdAnalistaIsNull == null || filter.IdAnalistaIsNull == false || o.IdAnalista == null)
					  && (filter.IdPrestamo == null || o.IdPrestamo >=  filter.IdPrestamo) && (filter.IdPrestamo_To == null || o.IdPrestamo <= filter.IdPrestamo_To)
					  && (filter.IdPrestamoIsNull == null || filter.IdPrestamoIsNull == true || o.IdPrestamo != null ) && (filter.IdPrestamoIsNull == null || filter.IdPrestamoIsNull == false || o.IdPrestamo == null)
					  && (filter.IdPrestamoDictamenRelacionado == null || filter.IdPrestamoDictamenRelacionado == 0 || o.IdPrestamoDictamenRelacionado==filter.IdPrestamoDictamenRelacionado)
					  && (filter.IdPrestamoDictamenRelacionadoIsNull == null || filter.IdPrestamoDictamenRelacionadoIsNull == true || o.IdPrestamoDictamenRelacionado != null ) && (filter.IdPrestamoDictamenRelacionadoIsNull == null || filter.IdPrestamoDictamenRelacionadoIsNull == false || o.IdPrestamoDictamenRelacionado == null)
					  && (filter.Comentario == null || filter.Comentario.Trim() == string.Empty || filter.Comentario.Trim() == "%"  || (filter.Comentario.EndsWith("%") && filter.Comentario.StartsWith("%") && (o.Comentario.Contains(filter.Comentario.Replace("%", "")))) || (filter.Comentario.EndsWith("%") && o.Comentario.StartsWith(filter.Comentario.Replace("%",""))) || (filter.Comentario.StartsWith("%") && o.Comentario.EndsWith(filter.Comentario.Replace("%",""))) || o.Comentario == filter.Comentario )
					  && (filter.IDPrestamoCalificacion == null || o.IDPrestamoCalificacion >=  filter.IDPrestamoCalificacion) && (filter.IDPrestamoCalificacion_To == null || o.IDPrestamoCalificacion <= filter.IDPrestamoCalificacion_To)
					  && (filter.IDPrestamoCalificacionIsNull == null || filter.IDPrestamoCalificacionIsNull == true || o.IDPrestamoCalificacion != null ) && (filter.IDPrestamoCalificacionIsNull == null || filter.IDPrestamoCalificacionIsNull == false || o.IDPrestamoCalificacion == null)
					  && (filter.CalificacionFecha == null || filter.CalificacionFecha == DateTime.MinValue || o.CalificacionFecha >=  filter.CalificacionFecha) && (filter.CalificacionFecha_To == null || filter.CalificacionFecha_To == DateTime.MinValue || o.CalificacionFecha <= filter.CalificacionFecha_To)
					  && (filter.CalificacionFechaIsNull == null || filter.CalificacionFechaIsNull == true || o.CalificacionFecha != null ) && (filter.CalificacionFechaIsNull == null || filter.CalificacionFechaIsNull == false || o.CalificacionFecha == null)
					  && (filter.CalificacionITecnico == null || filter.CalificacionITecnico.Trim() == string.Empty || filter.CalificacionITecnico.Trim() == "%"  || (filter.CalificacionITecnico.EndsWith("%") && filter.CalificacionITecnico.StartsWith("%") && (o.CalificacionITecnico.Contains(filter.CalificacionITecnico.Replace("%", "")))) || (filter.CalificacionITecnico.EndsWith("%") && o.CalificacionITecnico.StartsWith(filter.CalificacionITecnico.Replace("%",""))) || (filter.CalificacionITecnico.StartsWith("%") && o.CalificacionITecnico.EndsWith(filter.CalificacionITecnico.Replace("%",""))) || o.CalificacionITecnico == filter.CalificacionITecnico )
					  && (filter.CalificacionITFecha == null || filter.CalificacionITFecha == DateTime.MinValue || o.CalificacionITFecha >=  filter.CalificacionITFecha) && (filter.CalificacionITFecha_To == null || filter.CalificacionITFecha_To == DateTime.MinValue || o.CalificacionITFecha <= filter.CalificacionITFecha_To)
					  && (filter.CalificacionITFechaIsNull == null || filter.CalificacionITFechaIsNull == true || o.CalificacionITFecha != null ) && (filter.CalificacionITFechaIsNull == null || filter.CalificacionITFechaIsNull == false || o.CalificacionITFecha == null)
					  && (filter.CalificacionNotaDNIP == null || filter.CalificacionNotaDNIP.Trim() == string.Empty || filter.CalificacionNotaDNIP.Trim() == "%"  || (filter.CalificacionNotaDNIP.EndsWith("%") && filter.CalificacionNotaDNIP.StartsWith("%") && (o.CalificacionNotaDNIP.Contains(filter.CalificacionNotaDNIP.Replace("%", "")))) || (filter.CalificacionNotaDNIP.EndsWith("%") && o.CalificacionNotaDNIP.StartsWith(filter.CalificacionNotaDNIP.Replace("%",""))) || (filter.CalificacionNotaDNIP.StartsWith("%") && o.CalificacionNotaDNIP.EndsWith(filter.CalificacionNotaDNIP.Replace("%",""))) || o.CalificacionNotaDNIP == filter.CalificacionNotaDNIP )
					  && (filter.CalificacionObservacion == null || filter.CalificacionObservacion.Trim() == string.Empty || filter.CalificacionObservacion.Trim() == "%"  || (filter.CalificacionObservacion.EndsWith("%") && filter.CalificacionObservacion.StartsWith("%") && (o.CalificacionObservacion.Contains(filter.CalificacionObservacion.Replace("%", "")))) || (filter.CalificacionObservacion.EndsWith("%") && o.CalificacionObservacion.StartsWith(filter.CalificacionObservacion.Replace("%",""))) || (filter.CalificacionObservacion.StartsWith("%") && o.CalificacionObservacion.EndsWith(filter.CalificacionObservacion.Replace("%",""))) || o.CalificacionObservacion == filter.CalificacionObservacion )
					  && (filter.CalificacionRecomendacion == null || filter.CalificacionRecomendacion.Trim() == string.Empty || filter.CalificacionRecomendacion.Trim() == "%"  || (filter.CalificacionRecomendacion.EndsWith("%") && filter.CalificacionRecomendacion.StartsWith("%") && (o.CalificacionRecomendacion.Contains(filter.CalificacionRecomendacion.Replace("%", "")))) || (filter.CalificacionRecomendacion.EndsWith("%") && o.CalificacionRecomendacion.StartsWith(filter.CalificacionRecomendacion.Replace("%",""))) || (filter.CalificacionRecomendacion.StartsWith("%") && o.CalificacionRecomendacion.EndsWith(filter.CalificacionRecomendacion.Replace("%",""))) || o.CalificacionRecomendacion == filter.CalificacionRecomendacion )
					  && (filter.FechaAlta == null || filter.FechaAlta == DateTime.MinValue || o.FechaAlta >=  filter.FechaAlta) && (filter.FechaAlta_To == null || filter.FechaAlta_To == DateTime.MinValue || o.FechaAlta <= filter.FechaAlta_To)
					  && (filter.FechaModificacion == null || filter.FechaModificacion == DateTime.MinValue || o.FechaModificacion >=  filter.FechaModificacion) && (filter.FechaModificacion_To == null || filter.FechaModificacion_To == DateTime.MinValue || o.FechaModificacion <= filter.FechaModificacion_To)
					  && (filter.IDUsuarioModificacion == null || o.IDUsuarioModificacion >=  filter.IDUsuarioModificacion) && (filter.IDUsuarioModificacion_To == null || o.IDUsuarioModificacion <= filter.IDUsuarioModificacion_To)
					  && (filter.IdPrestamoDictamenEstado == null || o.IdPrestamoDictamenEstado >=  filter.IdPrestamoDictamenEstado) && (filter.IdPrestamoDictamenEstado_To == null || o.IdPrestamoDictamenEstado <= filter.IdPrestamoDictamenEstado_To)
					  && (filter.IdPrestamoDictamenEstadoIsNull == null || filter.IdPrestamoDictamenEstadoIsNull == true || o.IdPrestamoDictamenEstado != null ) && (filter.IdPrestamoDictamenEstadoIsNull == null || filter.IdPrestamoDictamenEstadoIsNull == false || o.IdPrestamoDictamenEstado == null)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PrestamoDictamenResult> QueryResult(PrestamoDictamenFilter filter)
        {
		  return (from o in Query(filter)					
					join _t1  in this.Context.PrestamoDictamens on o.IdPrestamoDictamenRelacionado equals _t1.IdPrestamoDictamen into tt1 from t1 in tt1.DefaultIfEmpty()
				   select new PrestamoDictamenResult(){
					 IdPrestamoDictamen=o.IdPrestamoDictamen
					 ,Expediente=o.Expediente
					 ,IDOrganismo=o.IDOrganismo
					 ,OrganismoDetalle=o.OrganismoDetalle
					 ,Denominacion=o.Denominacion
					 ,IdGestionTipo=o.IdGestionTipo
					 ,IdOrganismoFinanciero=o.IdOrganismoFinanciero
					 ,MontoTotal=o.MontoTotal
					 ,MontoPrestamo=o.MontoPrestamo
					 ,MontoContraparteLocal=o.MontoContraparteLocal
					 ,MontoOtros=o.MontoOtros
					 ,IdAnalista=o.IdAnalista
					 ,IdPrestamo=o.IdPrestamo
					 ,IdPrestamoDictamenRelacionado=o.IdPrestamoDictamenRelacionado
					 ,Comentario=o.Comentario
					 ,IDPrestamoCalificacion=o.IDPrestamoCalificacion
					 ,CalificacionFecha=o.CalificacionFecha
					 ,CalificacionITecnico=o.CalificacionITecnico
					 ,CalificacionITFecha=o.CalificacionITFecha
					 ,CalificacionNotaDNIP=o.CalificacionNotaDNIP
					 ,CalificacionObservacion=o.CalificacionObservacion
					 ,CalificacionRecomendacion=o.CalificacionRecomendacion
					 ,FechaAlta=o.FechaAlta
					 ,FechaModificacion=o.FechaModificacion
					 ,IDUsuarioModificacion=o.IDUsuarioModificacion
					 ,IdPrestamoDictamenEstado=o.IdPrestamoDictamenEstado
					,PrestamoDictamenRelacionado_Expediente= t1!=null?(string)t1.Expediente:null	
						,PrestamoDictamenRelacionado_IDOrganismo= t1!=null?(int?)t1.IDOrganismo:null	
						,PrestamoDictamenRelacionado_OrganismoDetalle= t1!=null?(string)t1.OrganismoDetalle:null	
						,PrestamoDictamenRelacionado_Denominacion= t1!=null?(string)t1.Denominacion:null	
						,PrestamoDictamenRelacionado_IdGestionTipo= t1!=null?(int?)t1.IdGestionTipo:null	
						,PrestamoDictamenRelacionado_IdOrganismoFinanciero= t1!=null?(int?)t1.IdOrganismoFinanciero:null	
						,PrestamoDictamenRelacionado_MontoTotal= t1!=null?(decimal?)t1.MontoTotal:null	
						,PrestamoDictamenRelacionado_MontoPrestamo= t1!=null?(decimal?)t1.MontoPrestamo:null	
						,PrestamoDictamenRelacionado_MontoContraparteLocal= t1!=null?(decimal?)t1.MontoContraparteLocal:null	
						,PrestamoDictamenRelacionado_MontoOtros= t1!=null?(decimal?)t1.MontoOtros:null	
						,PrestamoDictamenRelacionado_IdAnalista= t1!=null?(int?)t1.IdAnalista:null	
						,PrestamoDictamenRelacionado_IdPrestamo= t1!=null?(int?)t1.IdPrestamo:null	
						,PrestamoDictamenRelacionado_IdPrestamoDictamenRelacionado= t1!=null?(int?)t1.IdPrestamoDictamenRelacionado:null	
						,PrestamoDictamenRelacionado_Comentario= t1!=null?(string)t1.Comentario:null	
						,PrestamoDictamenRelacionado_IDPrestamoCalificacion= t1!=null?(int?)t1.IDPrestamoCalificacion:null	
						,PrestamoDictamenRelacionado_CalificacionFecha= t1!=null?(DateTime?)t1.CalificacionFecha:null	
						,PrestamoDictamenRelacionado_CalificacionITecnico= t1!=null?(string)t1.CalificacionITecnico:null	
						,PrestamoDictamenRelacionado_CalificacionITFecha= t1!=null?(DateTime?)t1.CalificacionITFecha:null	
						,PrestamoDictamenRelacionado_CalificacionNotaDNIP= t1!=null?(string)t1.CalificacionNotaDNIP:null	
						,PrestamoDictamenRelacionado_CalificacionObservacion= t1!=null?(string)t1.CalificacionObservacion:null	
						,PrestamoDictamenRelacionado_CalificacionRecomendacion= t1!=null?(string)t1.CalificacionRecomendacion:null	
						,PrestamoDictamenRelacionado_FechaAlta= t1!=null?(DateTime?)t1.FechaAlta:null	
						,PrestamoDictamenRelacionado_FechaModificacion= t1!=null?(DateTime?)t1.FechaModificacion:null	
						,PrestamoDictamenRelacionado_IDUsuarioModificacion= t1!=null?(int?)t1.IDUsuarioModificacion:null	
						,PrestamoDictamenRelacionado_IdPrestamoDictamenEstado= t1!=null?(int?)t1.IdPrestamoDictamenEstado:null	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.PrestamoDictamen Copy(nc.PrestamoDictamen entity)
        {           
            nc.PrestamoDictamen _new = new nc.PrestamoDictamen();
		 _new.Expediente= entity.Expediente;
		 _new.IDOrganismo= entity.IDOrganismo;
		 _new.OrganismoDetalle= entity.OrganismoDetalle;
		 _new.Denominacion= entity.Denominacion;
		 _new.IdGestionTipo= entity.IdGestionTipo;
		 _new.IdOrganismoFinanciero= entity.IdOrganismoFinanciero;
		 _new.MontoTotal= entity.MontoTotal;
		 _new.MontoPrestamo= entity.MontoPrestamo;
		 _new.MontoContraparteLocal= entity.MontoContraparteLocal;
		 _new.MontoOtros= entity.MontoOtros;
		 _new.IdAnalista= entity.IdAnalista;
		 _new.IdPrestamo= entity.IdPrestamo;
		 _new.IdPrestamoDictamenRelacionado= entity.IdPrestamoDictamenRelacionado;
		 _new.Comentario= entity.Comentario;
		 _new.IDPrestamoCalificacion= entity.IDPrestamoCalificacion;
		 _new.CalificacionFecha= entity.CalificacionFecha;
		 _new.CalificacionITecnico= entity.CalificacionITecnico;
		 _new.CalificacionITFecha= entity.CalificacionITFecha;
		 _new.CalificacionNotaDNIP= entity.CalificacionNotaDNIP;
		 _new.CalificacionObservacion= entity.CalificacionObservacion;
		 _new.CalificacionRecomendacion= entity.CalificacionRecomendacion;
		 _new.FechaAlta= entity.FechaAlta;
		 _new.FechaModificacion= entity.FechaModificacion;
		 _new.IDUsuarioModificacion= entity.IDUsuarioModificacion;
		 _new.IdPrestamoDictamenEstado= entity.IdPrestamoDictamenEstado;
		return _new;			
        }
		public override int CopyAndSave(PrestamoDictamen entity,string renameFormat)
        {
            PrestamoDictamen  newEntity = Copy(entity);
            newEntity.Expediente = string.Format(renameFormat,newEntity.Expediente);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(PrestamoDictamen entity, int id)
        {            
            entity.IdPrestamoDictamen = id;            
        }
		public override void Set(PrestamoDictamen source,PrestamoDictamen target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoDictamen= source.IdPrestamoDictamen ;
		 target.Expediente= source.Expediente ;
		 target.IDOrganismo= source.IDOrganismo ;
		 target.OrganismoDetalle= source.OrganismoDetalle ;
		 target.Denominacion= source.Denominacion ;
		 target.IdGestionTipo= source.IdGestionTipo ;
		 target.IdOrganismoFinanciero= source.IdOrganismoFinanciero ;
		 target.MontoTotal= source.MontoTotal ;
		 target.MontoPrestamo= source.MontoPrestamo ;
		 target.MontoContraparteLocal= source.MontoContraparteLocal ;
		 target.MontoOtros= source.MontoOtros ;
		 target.IdAnalista= source.IdAnalista ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdPrestamoDictamenRelacionado= source.IdPrestamoDictamenRelacionado ;
		 target.Comentario= source.Comentario ;
		 target.IDPrestamoCalificacion= source.IDPrestamoCalificacion ;
		 target.CalificacionFecha= source.CalificacionFecha ;
		 target.CalificacionITecnico= source.CalificacionITecnico ;
		 target.CalificacionITFecha= source.CalificacionITFecha ;
		 target.CalificacionNotaDNIP= source.CalificacionNotaDNIP ;
		 target.CalificacionObservacion= source.CalificacionObservacion ;
		 target.CalificacionRecomendacion= source.CalificacionRecomendacion ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaModificacion= source.FechaModificacion ;
		 target.IDUsuarioModificacion= source.IDUsuarioModificacion ;
		 target.IdPrestamoDictamenEstado= source.IdPrestamoDictamenEstado ;
		 		  
		}
		public override void Set(PrestamoDictamenResult source,PrestamoDictamen target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoDictamen= source.IdPrestamoDictamen ;
		 target.Expediente= source.Expediente ;
		 target.IDOrganismo= source.IDOrganismo ;
		 target.OrganismoDetalle= source.OrganismoDetalle ;
		 target.Denominacion= source.Denominacion ;
		 target.IdGestionTipo= source.IdGestionTipo ;
		 target.IdOrganismoFinanciero= source.IdOrganismoFinanciero ;
		 target.MontoTotal= source.MontoTotal ;
		 target.MontoPrestamo= source.MontoPrestamo ;
		 target.MontoContraparteLocal= source.MontoContraparteLocal ;
		 target.MontoOtros= source.MontoOtros ;
		 target.IdAnalista= source.IdAnalista ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdPrestamoDictamenRelacionado= source.IdPrestamoDictamenRelacionado ;
		 target.Comentario= source.Comentario ;
		 target.IDPrestamoCalificacion= source.IDPrestamoCalificacion ;
		 target.CalificacionFecha= source.CalificacionFecha ;
		 target.CalificacionITecnico= source.CalificacionITecnico ;
		 target.CalificacionITFecha= source.CalificacionITFecha ;
		 target.CalificacionNotaDNIP= source.CalificacionNotaDNIP ;
		 target.CalificacionObservacion= source.CalificacionObservacion ;
		 target.CalificacionRecomendacion= source.CalificacionRecomendacion ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaModificacion= source.FechaModificacion ;
		 target.IDUsuarioModificacion= source.IDUsuarioModificacion ;
		 target.IdPrestamoDictamenEstado= source.IdPrestamoDictamenEstado ;
		 
		}
		public override void Set(PrestamoDictamen source,PrestamoDictamenResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoDictamen= source.IdPrestamoDictamen ;
		 target.Expediente= source.Expediente ;
		 target.IDOrganismo= source.IDOrganismo ;
		 target.OrganismoDetalle= source.OrganismoDetalle ;
		 target.Denominacion= source.Denominacion ;
		 target.IdGestionTipo= source.IdGestionTipo ;
		 target.IdOrganismoFinanciero= source.IdOrganismoFinanciero ;
		 target.MontoTotal= source.MontoTotal ;
		 target.MontoPrestamo= source.MontoPrestamo ;
		 target.MontoContraparteLocal= source.MontoContraparteLocal ;
		 target.MontoOtros= source.MontoOtros ;
		 target.IdAnalista= source.IdAnalista ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdPrestamoDictamenRelacionado= source.IdPrestamoDictamenRelacionado ;
		 target.Comentario= source.Comentario ;
		 target.IDPrestamoCalificacion= source.IDPrestamoCalificacion ;
		 target.CalificacionFecha= source.CalificacionFecha ;
		 target.CalificacionITecnico= source.CalificacionITecnico ;
		 target.CalificacionITFecha= source.CalificacionITFecha ;
		 target.CalificacionNotaDNIP= source.CalificacionNotaDNIP ;
		 target.CalificacionObservacion= source.CalificacionObservacion ;
		 target.CalificacionRecomendacion= source.CalificacionRecomendacion ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaModificacion= source.FechaModificacion ;
		 target.IDUsuarioModificacion= source.IDUsuarioModificacion ;
		 target.IdPrestamoDictamenEstado= source.IdPrestamoDictamenEstado ;
		 	
		}		
		public override void Set(PrestamoDictamenResult source,PrestamoDictamenResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoDictamen= source.IdPrestamoDictamen ;
		 target.Expediente= source.Expediente ;
		 target.IDOrganismo= source.IDOrganismo ;
		 target.OrganismoDetalle= source.OrganismoDetalle ;
		 target.Denominacion= source.Denominacion ;
		 target.IdGestionTipo= source.IdGestionTipo ;
		 target.IdOrganismoFinanciero= source.IdOrganismoFinanciero ;
		 target.MontoTotal= source.MontoTotal ;
		 target.MontoPrestamo= source.MontoPrestamo ;
		 target.MontoContraparteLocal= source.MontoContraparteLocal ;
		 target.MontoOtros= source.MontoOtros ;
		 target.IdAnalista= source.IdAnalista ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdPrestamoDictamenRelacionado= source.IdPrestamoDictamenRelacionado ;
		 target.Comentario= source.Comentario ;
		 target.IDPrestamoCalificacion= source.IDPrestamoCalificacion ;
		 target.CalificacionFecha= source.CalificacionFecha ;
		 target.CalificacionITecnico= source.CalificacionITecnico ;
		 target.CalificacionITFecha= source.CalificacionITFecha ;
		 target.CalificacionNotaDNIP= source.CalificacionNotaDNIP ;
		 target.CalificacionObservacion= source.CalificacionObservacion ;
		 target.CalificacionRecomendacion= source.CalificacionRecomendacion ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaModificacion= source.FechaModificacion ;
		 target.IDUsuarioModificacion= source.IDUsuarioModificacion ;
		 target.IdPrestamoDictamenEstado= source.IdPrestamoDictamenEstado ;
		 target.PrestamoDictamenRelacionado_Expediente= source.PrestamoDictamenRelacionado_Expediente;	
			target.PrestamoDictamenRelacionado_IDOrganismo= source.PrestamoDictamenRelacionado_IDOrganismo;	
			target.PrestamoDictamenRelacionado_OrganismoDetalle= source.PrestamoDictamenRelacionado_OrganismoDetalle;	
			target.PrestamoDictamenRelacionado_Denominacion= source.PrestamoDictamenRelacionado_Denominacion;	
			target.PrestamoDictamenRelacionado_IdGestionTipo= source.PrestamoDictamenRelacionado_IdGestionTipo;	
			target.PrestamoDictamenRelacionado_IdOrganismoFinanciero= source.PrestamoDictamenRelacionado_IdOrganismoFinanciero;	
			target.PrestamoDictamenRelacionado_MontoTotal= source.PrestamoDictamenRelacionado_MontoTotal;	
			target.PrestamoDictamenRelacionado_MontoPrestamo= source.PrestamoDictamenRelacionado_MontoPrestamo;	
			target.PrestamoDictamenRelacionado_MontoContraparteLocal= source.PrestamoDictamenRelacionado_MontoContraparteLocal;	
			target.PrestamoDictamenRelacionado_MontoOtros= source.PrestamoDictamenRelacionado_MontoOtros;	
			target.PrestamoDictamenRelacionado_IdAnalista= source.PrestamoDictamenRelacionado_IdAnalista;	
			target.PrestamoDictamenRelacionado_IdPrestamo= source.PrestamoDictamenRelacionado_IdPrestamo;	
			target.PrestamoDictamenRelacionado_IdPrestamoDictamenRelacionado= source.PrestamoDictamenRelacionado_IdPrestamoDictamenRelacionado;	
			target.PrestamoDictamenRelacionado_Comentario= source.PrestamoDictamenRelacionado_Comentario;	
			target.PrestamoDictamenRelacionado_IDPrestamoCalificacion= source.PrestamoDictamenRelacionado_IDPrestamoCalificacion;	
			target.PrestamoDictamenRelacionado_CalificacionFecha= source.PrestamoDictamenRelacionado_CalificacionFecha;	
			target.PrestamoDictamenRelacionado_CalificacionITecnico= source.PrestamoDictamenRelacionado_CalificacionITecnico;	
			target.PrestamoDictamenRelacionado_CalificacionITFecha= source.PrestamoDictamenRelacionado_CalificacionITFecha;	
			target.PrestamoDictamenRelacionado_CalificacionNotaDNIP= source.PrestamoDictamenRelacionado_CalificacionNotaDNIP;	
			target.PrestamoDictamenRelacionado_CalificacionObservacion= source.PrestamoDictamenRelacionado_CalificacionObservacion;	
			target.PrestamoDictamenRelacionado_CalificacionRecomendacion= source.PrestamoDictamenRelacionado_CalificacionRecomendacion;	
			target.PrestamoDictamenRelacionado_FechaAlta= source.PrestamoDictamenRelacionado_FechaAlta;	
			target.PrestamoDictamenRelacionado_FechaModificacion= source.PrestamoDictamenRelacionado_FechaModificacion;	
			target.PrestamoDictamenRelacionado_IDUsuarioModificacion= source.PrestamoDictamenRelacionado_IDUsuarioModificacion;	
			target.PrestamoDictamenRelacionado_IdPrestamoDictamenEstado= source.PrestamoDictamenRelacionado_IdPrestamoDictamenEstado;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(PrestamoDictamen source,PrestamoDictamen target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoDictamen.Equals(target.IdPrestamoDictamen))return false;
		  if((source.Expediente == null)?target.Expediente!=null:  !( (target.Expediente== String.Empty && source.Expediente== null) || (target.Expediente==null && source.Expediente== String.Empty )) &&  !source.Expediente.Trim().Replace ("\r","").Equals(target.Expediente.Trim().Replace ("\r","")))return false;
			 if(!source.IDOrganismo.Equals(target.IDOrganismo))return false;
		  if((source.OrganismoDetalle == null)?target.OrganismoDetalle!=null:  !( (target.OrganismoDetalle== String.Empty && source.OrganismoDetalle== null) || (target.OrganismoDetalle==null && source.OrganismoDetalle== String.Empty )) &&  !source.OrganismoDetalle.Trim().Replace ("\r","").Equals(target.OrganismoDetalle.Trim().Replace ("\r","")))return false;
			 if((source.Denominacion == null)?target.Denominacion!=null:  !( (target.Denominacion== String.Empty && source.Denominacion== null) || (target.Denominacion==null && source.Denominacion== String.Empty )) &&  !source.Denominacion.Trim().Replace ("\r","").Equals(target.Denominacion.Trim().Replace ("\r","")))return false;
			 if(!source.IdGestionTipo.Equals(target.IdGestionTipo))return false;
		  if(!source.IdOrganismoFinanciero.Equals(target.IdOrganismoFinanciero))return false;
		  if((source.MontoTotal == null)?(target.MontoTotal.HasValue):!source.MontoTotal.Equals(target.MontoTotal))return false;
			 if((source.MontoPrestamo == null)?(target.MontoPrestamo.HasValue):!source.MontoPrestamo.Equals(target.MontoPrestamo))return false;
			 if((source.MontoContraparteLocal == null)?(target.MontoContraparteLocal.HasValue):!source.MontoContraparteLocal.Equals(target.MontoContraparteLocal))return false;
			 if((source.MontoOtros == null)?(target.MontoOtros.HasValue):!source.MontoOtros.Equals(target.MontoOtros))return false;
			 if((source.IdAnalista == null)?(target.IdAnalista.HasValue):!source.IdAnalista.Equals(target.IdAnalista))return false;
			 if((source.IdPrestamo == null)?(target.IdPrestamo.HasValue):!source.IdPrestamo.Equals(target.IdPrestamo))return false;
			 if((source.IdPrestamoDictamenRelacionado == null)?(target.IdPrestamoDictamenRelacionado.HasValue && target.IdPrestamoDictamenRelacionado.Value > 0):!source.IdPrestamoDictamenRelacionado.Equals(target.IdPrestamoDictamenRelacionado))return false;
						  if((source.Comentario == null)?target.Comentario!=null:  !( (target.Comentario== String.Empty && source.Comentario== null) || (target.Comentario==null && source.Comentario== String.Empty )) &&  !source.Comentario.Trim().Replace ("\r","").Equals(target.Comentario.Trim().Replace ("\r","")))return false;
			 if((source.IDPrestamoCalificacion == null)?(target.IDPrestamoCalificacion.HasValue):!source.IDPrestamoCalificacion.Equals(target.IDPrestamoCalificacion))return false;
			 if((source.CalificacionFecha == null)?(target.CalificacionFecha.HasValue):!source.CalificacionFecha.Equals(target.CalificacionFecha))return false;
			 if((source.CalificacionITecnico == null)?target.CalificacionITecnico!=null:  !( (target.CalificacionITecnico== String.Empty && source.CalificacionITecnico== null) || (target.CalificacionITecnico==null && source.CalificacionITecnico== String.Empty )) &&  !source.CalificacionITecnico.Trim().Replace ("\r","").Equals(target.CalificacionITecnico.Trim().Replace ("\r","")))return false;
			 if((source.CalificacionITFecha == null)?(target.CalificacionITFecha.HasValue):!source.CalificacionITFecha.Equals(target.CalificacionITFecha))return false;
			 if((source.CalificacionNotaDNIP == null)?target.CalificacionNotaDNIP!=null:  !( (target.CalificacionNotaDNIP== String.Empty && source.CalificacionNotaDNIP== null) || (target.CalificacionNotaDNIP==null && source.CalificacionNotaDNIP== String.Empty )) &&  !source.CalificacionNotaDNIP.Trim().Replace ("\r","").Equals(target.CalificacionNotaDNIP.Trim().Replace ("\r","")))return false;
			 if((source.CalificacionObservacion == null)?target.CalificacionObservacion!=null:  !( (target.CalificacionObservacion== String.Empty && source.CalificacionObservacion== null) || (target.CalificacionObservacion==null && source.CalificacionObservacion== String.Empty )) &&  !source.CalificacionObservacion.Trim().Replace ("\r","").Equals(target.CalificacionObservacion.Trim().Replace ("\r","")))return false;
			 if((source.CalificacionRecomendacion == null)?target.CalificacionRecomendacion!=null:  !( (target.CalificacionRecomendacion== String.Empty && source.CalificacionRecomendacion== null) || (target.CalificacionRecomendacion==null && source.CalificacionRecomendacion== String.Empty )) &&  !source.CalificacionRecomendacion.Trim().Replace ("\r","").Equals(target.CalificacionRecomendacion.Trim().Replace ("\r","")))return false;
			 if(!source.FechaAlta.Equals(target.FechaAlta))return false;
		  if(!source.FechaModificacion.Equals(target.FechaModificacion))return false;
		  if(!source.IDUsuarioModificacion.Equals(target.IDUsuarioModificacion))return false;
		  if((source.IdPrestamoDictamenEstado == null)?(target.IdPrestamoDictamenEstado.HasValue):!source.IdPrestamoDictamenEstado.Equals(target.IdPrestamoDictamenEstado))return false;
			
		  return true;
        }
		public override bool Equals(PrestamoDictamenResult source,PrestamoDictamenResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoDictamen.Equals(target.IdPrestamoDictamen))return false;
		  if((source.Expediente == null)?target.Expediente!=null: !( (target.Expediente== String.Empty && source.Expediente== null) || (target.Expediente==null && source.Expediente== String.Empty )) && !source.Expediente.Trim().Replace ("\r","").Equals(target.Expediente.Trim().Replace ("\r","")))return false;
			 if(!source.IDOrganismo.Equals(target.IDOrganismo))return false;
		  if((source.OrganismoDetalle == null)?target.OrganismoDetalle!=null: !( (target.OrganismoDetalle== String.Empty && source.OrganismoDetalle== null) || (target.OrganismoDetalle==null && source.OrganismoDetalle== String.Empty )) && !source.OrganismoDetalle.Trim().Replace ("\r","").Equals(target.OrganismoDetalle.Trim().Replace ("\r","")))return false;
			 if((source.Denominacion == null)?target.Denominacion!=null: !( (target.Denominacion== String.Empty && source.Denominacion== null) || (target.Denominacion==null && source.Denominacion== String.Empty )) && !source.Denominacion.Trim().Replace ("\r","").Equals(target.Denominacion.Trim().Replace ("\r","")))return false;
			 if(!source.IdGestionTipo.Equals(target.IdGestionTipo))return false;
		  if(!source.IdOrganismoFinanciero.Equals(target.IdOrganismoFinanciero))return false;
		  if((source.MontoTotal == null)?(target.MontoTotal.HasValue):!source.MontoTotal.Equals(target.MontoTotal))return false;
			 if((source.MontoPrestamo == null)?(target.MontoPrestamo.HasValue):!source.MontoPrestamo.Equals(target.MontoPrestamo))return false;
			 if((source.MontoContraparteLocal == null)?(target.MontoContraparteLocal.HasValue):!source.MontoContraparteLocal.Equals(target.MontoContraparteLocal))return false;
			 if((source.MontoOtros == null)?(target.MontoOtros.HasValue):!source.MontoOtros.Equals(target.MontoOtros))return false;
			 if((source.IdAnalista == null)?(target.IdAnalista.HasValue):!source.IdAnalista.Equals(target.IdAnalista))return false;
			 if((source.IdPrestamo == null)?(target.IdPrestamo.HasValue):!source.IdPrestamo.Equals(target.IdPrestamo))return false;
			 if((source.IdPrestamoDictamenRelacionado == null)?(target.IdPrestamoDictamenRelacionado.HasValue && target.IdPrestamoDictamenRelacionado.Value > 0):!source.IdPrestamoDictamenRelacionado.Equals(target.IdPrestamoDictamenRelacionado))return false;
						  if((source.Comentario == null)?target.Comentario!=null: !( (target.Comentario== String.Empty && source.Comentario== null) || (target.Comentario==null && source.Comentario== String.Empty )) && !source.Comentario.Trim().Replace ("\r","").Equals(target.Comentario.Trim().Replace ("\r","")))return false;
			 if((source.IDPrestamoCalificacion == null)?(target.IDPrestamoCalificacion.HasValue):!source.IDPrestamoCalificacion.Equals(target.IDPrestamoCalificacion))return false;
			 if((source.CalificacionFecha == null)?(target.CalificacionFecha.HasValue):!source.CalificacionFecha.Equals(target.CalificacionFecha))return false;
			 if((source.CalificacionITecnico == null)?target.CalificacionITecnico!=null: !( (target.CalificacionITecnico== String.Empty && source.CalificacionITecnico== null) || (target.CalificacionITecnico==null && source.CalificacionITecnico== String.Empty )) && !source.CalificacionITecnico.Trim().Replace ("\r","").Equals(target.CalificacionITecnico.Trim().Replace ("\r","")))return false;
			 if((source.CalificacionITFecha == null)?(target.CalificacionITFecha.HasValue):!source.CalificacionITFecha.Equals(target.CalificacionITFecha))return false;
			 if((source.CalificacionNotaDNIP == null)?target.CalificacionNotaDNIP!=null: !( (target.CalificacionNotaDNIP== String.Empty && source.CalificacionNotaDNIP== null) || (target.CalificacionNotaDNIP==null && source.CalificacionNotaDNIP== String.Empty )) && !source.CalificacionNotaDNIP.Trim().Replace ("\r","").Equals(target.CalificacionNotaDNIP.Trim().Replace ("\r","")))return false;
			 if((source.CalificacionObservacion == null)?target.CalificacionObservacion!=null: !( (target.CalificacionObservacion== String.Empty && source.CalificacionObservacion== null) || (target.CalificacionObservacion==null && source.CalificacionObservacion== String.Empty )) && !source.CalificacionObservacion.Trim().Replace ("\r","").Equals(target.CalificacionObservacion.Trim().Replace ("\r","")))return false;
			 if((source.CalificacionRecomendacion == null)?target.CalificacionRecomendacion!=null: !( (target.CalificacionRecomendacion== String.Empty && source.CalificacionRecomendacion== null) || (target.CalificacionRecomendacion==null && source.CalificacionRecomendacion== String.Empty )) && !source.CalificacionRecomendacion.Trim().Replace ("\r","").Equals(target.CalificacionRecomendacion.Trim().Replace ("\r","")))return false;
			 if(!source.FechaAlta.Equals(target.FechaAlta))return false;
		  if(!source.FechaModificacion.Equals(target.FechaModificacion))return false;
		  if(!source.IDUsuarioModificacion.Equals(target.IDUsuarioModificacion))return false;
		  if((source.IdPrestamoDictamenEstado == null)?(target.IdPrestamoDictamenEstado.HasValue):!source.IdPrestamoDictamenEstado.Equals(target.IdPrestamoDictamenEstado))return false;
			 if((source.PrestamoDictamenRelacionado_Expediente == null)?target.PrestamoDictamenRelacionado_Expediente!=null: !( (target.PrestamoDictamenRelacionado_Expediente== String.Empty && source.PrestamoDictamenRelacionado_Expediente== null) || (target.PrestamoDictamenRelacionado_Expediente==null && source.PrestamoDictamenRelacionado_Expediente== String.Empty )) &&   !source.PrestamoDictamenRelacionado_Expediente.Trim().Replace ("\r","").Equals(target.PrestamoDictamenRelacionado_Expediente.Trim().Replace ("\r","")))return false;
						 if(!source.PrestamoDictamenRelacionado_IDOrganismo.Equals(target.PrestamoDictamenRelacionado_IDOrganismo))return false;
					  if((source.PrestamoDictamenRelacionado_OrganismoDetalle == null)?target.PrestamoDictamenRelacionado_OrganismoDetalle!=null: !( (target.PrestamoDictamenRelacionado_OrganismoDetalle== String.Empty && source.PrestamoDictamenRelacionado_OrganismoDetalle== null) || (target.PrestamoDictamenRelacionado_OrganismoDetalle==null && source.PrestamoDictamenRelacionado_OrganismoDetalle== String.Empty )) &&   !source.PrestamoDictamenRelacionado_OrganismoDetalle.Trim().Replace ("\r","").Equals(target.PrestamoDictamenRelacionado_OrganismoDetalle.Trim().Replace ("\r","")))return false;
						 if((source.PrestamoDictamenRelacionado_Denominacion == null)?target.PrestamoDictamenRelacionado_Denominacion!=null: !( (target.PrestamoDictamenRelacionado_Denominacion== String.Empty && source.PrestamoDictamenRelacionado_Denominacion== null) || (target.PrestamoDictamenRelacionado_Denominacion==null && source.PrestamoDictamenRelacionado_Denominacion== String.Empty )) &&   !source.PrestamoDictamenRelacionado_Denominacion.Trim().Replace ("\r","").Equals(target.PrestamoDictamenRelacionado_Denominacion.Trim().Replace ("\r","")))return false;
						 if(!source.PrestamoDictamenRelacionado_IdGestionTipo.Equals(target.PrestamoDictamenRelacionado_IdGestionTipo))return false;
					  if(!source.PrestamoDictamenRelacionado_IdOrganismoFinanciero.Equals(target.PrestamoDictamenRelacionado_IdOrganismoFinanciero))return false;
					  if((source.PrestamoDictamenRelacionado_MontoTotal == null)?(target.PrestamoDictamenRelacionado_MontoTotal.HasValue ):!source.PrestamoDictamenRelacionado_MontoTotal.Equals(target.PrestamoDictamenRelacionado_MontoTotal))return false;
						 if((source.PrestamoDictamenRelacionado_MontoPrestamo == null)?(target.PrestamoDictamenRelacionado_MontoPrestamo.HasValue ):!source.PrestamoDictamenRelacionado_MontoPrestamo.Equals(target.PrestamoDictamenRelacionado_MontoPrestamo))return false;
						 if((source.PrestamoDictamenRelacionado_MontoContraparteLocal == null)?(target.PrestamoDictamenRelacionado_MontoContraparteLocal.HasValue ):!source.PrestamoDictamenRelacionado_MontoContraparteLocal.Equals(target.PrestamoDictamenRelacionado_MontoContraparteLocal))return false;
						 if((source.PrestamoDictamenRelacionado_MontoOtros == null)?(target.PrestamoDictamenRelacionado_MontoOtros.HasValue ):!source.PrestamoDictamenRelacionado_MontoOtros.Equals(target.PrestamoDictamenRelacionado_MontoOtros))return false;
						 if((source.PrestamoDictamenRelacionado_IdAnalista == null)?(target.PrestamoDictamenRelacionado_IdAnalista.HasValue ):!source.PrestamoDictamenRelacionado_IdAnalista.Equals(target.PrestamoDictamenRelacionado_IdAnalista))return false;
						 if((source.PrestamoDictamenRelacionado_IdPrestamo == null)?(target.PrestamoDictamenRelacionado_IdPrestamo.HasValue ):!source.PrestamoDictamenRelacionado_IdPrestamo.Equals(target.PrestamoDictamenRelacionado_IdPrestamo))return false;
						 if((source.PrestamoDictamenRelacionado_IdPrestamoDictamenRelacionado == null)?(target.PrestamoDictamenRelacionado_IdPrestamoDictamenRelacionado.HasValue && target.PrestamoDictamenRelacionado_IdPrestamoDictamenRelacionado.Value > 0):!source.PrestamoDictamenRelacionado_IdPrestamoDictamenRelacionado.Equals(target.PrestamoDictamenRelacionado_IdPrestamoDictamenRelacionado))return false;
									  if((source.PrestamoDictamenRelacionado_Comentario == null)?target.PrestamoDictamenRelacionado_Comentario!=null: !( (target.PrestamoDictamenRelacionado_Comentario== String.Empty && source.PrestamoDictamenRelacionado_Comentario== null) || (target.PrestamoDictamenRelacionado_Comentario==null && source.PrestamoDictamenRelacionado_Comentario== String.Empty )) &&   !source.PrestamoDictamenRelacionado_Comentario.Trim().Replace ("\r","").Equals(target.PrestamoDictamenRelacionado_Comentario.Trim().Replace ("\r","")))return false;
						 if((source.PrestamoDictamenRelacionado_IDPrestamoCalificacion == null)?(target.PrestamoDictamenRelacionado_IDPrestamoCalificacion.HasValue ):!source.PrestamoDictamenRelacionado_IDPrestamoCalificacion.Equals(target.PrestamoDictamenRelacionado_IDPrestamoCalificacion))return false;
						 if((source.PrestamoDictamenRelacionado_CalificacionFecha == null)?(target.PrestamoDictamenRelacionado_CalificacionFecha.HasValue ):!source.PrestamoDictamenRelacionado_CalificacionFecha.Equals(target.PrestamoDictamenRelacionado_CalificacionFecha))return false;
						 if((source.PrestamoDictamenRelacionado_CalificacionITecnico == null)?target.PrestamoDictamenRelacionado_CalificacionITecnico!=null: !( (target.PrestamoDictamenRelacionado_CalificacionITecnico== String.Empty && source.PrestamoDictamenRelacionado_CalificacionITecnico== null) || (target.PrestamoDictamenRelacionado_CalificacionITecnico==null && source.PrestamoDictamenRelacionado_CalificacionITecnico== String.Empty )) &&   !source.PrestamoDictamenRelacionado_CalificacionITecnico.Trim().Replace ("\r","").Equals(target.PrestamoDictamenRelacionado_CalificacionITecnico.Trim().Replace ("\r","")))return false;
						 if((source.PrestamoDictamenRelacionado_CalificacionITFecha == null)?(target.PrestamoDictamenRelacionado_CalificacionITFecha.HasValue ):!source.PrestamoDictamenRelacionado_CalificacionITFecha.Equals(target.PrestamoDictamenRelacionado_CalificacionITFecha))return false;
						 if((source.PrestamoDictamenRelacionado_CalificacionNotaDNIP == null)?target.PrestamoDictamenRelacionado_CalificacionNotaDNIP!=null: !( (target.PrestamoDictamenRelacionado_CalificacionNotaDNIP== String.Empty && source.PrestamoDictamenRelacionado_CalificacionNotaDNIP== null) || (target.PrestamoDictamenRelacionado_CalificacionNotaDNIP==null && source.PrestamoDictamenRelacionado_CalificacionNotaDNIP== String.Empty )) &&   !source.PrestamoDictamenRelacionado_CalificacionNotaDNIP.Trim().Replace ("\r","").Equals(target.PrestamoDictamenRelacionado_CalificacionNotaDNIP.Trim().Replace ("\r","")))return false;
						 if((source.PrestamoDictamenRelacionado_CalificacionObservacion == null)?target.PrestamoDictamenRelacionado_CalificacionObservacion!=null: !( (target.PrestamoDictamenRelacionado_CalificacionObservacion== String.Empty && source.PrestamoDictamenRelacionado_CalificacionObservacion== null) || (target.PrestamoDictamenRelacionado_CalificacionObservacion==null && source.PrestamoDictamenRelacionado_CalificacionObservacion== String.Empty )) &&   !source.PrestamoDictamenRelacionado_CalificacionObservacion.Trim().Replace ("\r","").Equals(target.PrestamoDictamenRelacionado_CalificacionObservacion.Trim().Replace ("\r","")))return false;
						 if((source.PrestamoDictamenRelacionado_CalificacionRecomendacion == null)?target.PrestamoDictamenRelacionado_CalificacionRecomendacion!=null: !( (target.PrestamoDictamenRelacionado_CalificacionRecomendacion== String.Empty && source.PrestamoDictamenRelacionado_CalificacionRecomendacion== null) || (target.PrestamoDictamenRelacionado_CalificacionRecomendacion==null && source.PrestamoDictamenRelacionado_CalificacionRecomendacion== String.Empty )) &&   !source.PrestamoDictamenRelacionado_CalificacionRecomendacion.Trim().Replace ("\r","").Equals(target.PrestamoDictamenRelacionado_CalificacionRecomendacion.Trim().Replace ("\r","")))return false;
						 if(!source.PrestamoDictamenRelacionado_FechaAlta.Equals(target.PrestamoDictamenRelacionado_FechaAlta))return false;
					  if(!source.PrestamoDictamenRelacionado_FechaModificacion.Equals(target.PrestamoDictamenRelacionado_FechaModificacion))return false;
					  if(!source.PrestamoDictamenRelacionado_IDUsuarioModificacion.Equals(target.PrestamoDictamenRelacionado_IDUsuarioModificacion))return false;
					  if((source.PrestamoDictamenRelacionado_IdPrestamoDictamenEstado == null)?(target.PrestamoDictamenRelacionado_IdPrestamoDictamenEstado.HasValue ):!source.PrestamoDictamenRelacionado_IdPrestamoDictamenEstado.Equals(target.PrestamoDictamenRelacionado_IdPrestamoDictamenEstado))return false;
								
		  return true;
        }
		#endregion
    }
}

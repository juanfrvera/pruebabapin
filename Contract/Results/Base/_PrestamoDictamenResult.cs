using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PrestamoDictamenResult : IResult<int>
    {        
		public virtual int ID{get{return IdPrestamoDictamen;}}
		 public int IdPrestamoDictamen{get;set;}
		 public string Expediente{get;set;}
		 public int IDOrganismo{get;set;}
		 public string OrganismoDetalle{get;set;}
		 public string Denominacion{get;set;}
		 public int IdGestionTipo{get;set;}
		 public int IdOrganismoFinanciero{get;set;}
		 public decimal? MontoTotal{get;set;}
		 public decimal? MontoPrestamo{get;set;}
		 public decimal? MontoContraparteLocal{get;set;}
		 public decimal? MontoOtros{get;set;}
		 public int? IdAnalista{get;set;}
		 public int? IdPrestamo{get;set;}
		 public int? IdPrestamoDictamenRelacionado{get;set;}
		 public string Comentario{get;set;}
		 public int? IDPrestamoCalificacion{get;set;}
		 public DateTime? CalificacionFecha{get;set;}
		 public string CalificacionITecnico{get;set;}
		 public DateTime? CalificacionITFecha{get;set;}
		 public string CalificacionNotaDNIP{get;set;}
		 public string CalificacionObservacion{get;set;}
		 public string CalificacionRecomendacion{get;set;}
		 public DateTime FechaAlta{get;set;}
		 public DateTime FechaModificacion{get;set;}
		 public int IDUsuarioModificacion{get;set;}
		 public int? IdPrestamoDictamenEstado{get;set;}
		 
		 public string PrestamoDictamenRelacionado_Expediente{get;set;}	
	public int? PrestamoDictamenRelacionado_IDOrganismo{get;set;}	
	public string PrestamoDictamenRelacionado_OrganismoDetalle{get;set;}	
	public string PrestamoDictamenRelacionado_Denominacion{get;set;}	
	public int? PrestamoDictamenRelacionado_IdGestionTipo{get;set;}	
	public int? PrestamoDictamenRelacionado_IdOrganismoFinanciero{get;set;}	
	public decimal? PrestamoDictamenRelacionado_MontoTotal{get;set;}	
	public decimal? PrestamoDictamenRelacionado_MontoPrestamo{get;set;}	
	public decimal? PrestamoDictamenRelacionado_MontoContraparteLocal{get;set;}	
	public decimal? PrestamoDictamenRelacionado_MontoOtros{get;set;}	
	public int? PrestamoDictamenRelacionado_IdAnalista{get;set;}	
	public int? PrestamoDictamenRelacionado_IdPrestamo{get;set;}	
	public int? PrestamoDictamenRelacionado_IdPrestamoDictamenRelacionado{get;set;}	
	public string PrestamoDictamenRelacionado_Comentario{get;set;}	
	public int? PrestamoDictamenRelacionado_IDPrestamoCalificacion{get;set;}	
	public DateTime? PrestamoDictamenRelacionado_CalificacionFecha{get;set;}	
	public string PrestamoDictamenRelacionado_CalificacionITecnico{get;set;}	
	public DateTime? PrestamoDictamenRelacionado_CalificacionITFecha{get;set;}	
	public string PrestamoDictamenRelacionado_CalificacionNotaDNIP{get;set;}	
	public string PrestamoDictamenRelacionado_CalificacionObservacion{get;set;}	
	public string PrestamoDictamenRelacionado_CalificacionRecomendacion{get;set;}	
	public DateTime? PrestamoDictamenRelacionado_FechaAlta{get;set;}	
	public DateTime? PrestamoDictamenRelacionado_FechaModificacion{get;set;}	
	public int? PrestamoDictamenRelacionado_IDUsuarioModificacion{get;set;}	
	public int? PrestamoDictamenRelacionado_IdPrestamoDictamenEstado{get;set;}	
					
		public virtual PrestamoDictamen ToEntity()
		{
		   PrestamoDictamen _PrestamoDictamen = new PrestamoDictamen();
		_PrestamoDictamen.IdPrestamoDictamen = this.IdPrestamoDictamen;
		 _PrestamoDictamen.Expediente = this.Expediente;
		 _PrestamoDictamen.IDOrganismo = this.IDOrganismo;
		 _PrestamoDictamen.OrganismoDetalle = this.OrganismoDetalle;
		 _PrestamoDictamen.Denominacion = this.Denominacion;
		 _PrestamoDictamen.IdGestionTipo = this.IdGestionTipo;
		 _PrestamoDictamen.IdOrganismoFinanciero = this.IdOrganismoFinanciero;
		 _PrestamoDictamen.MontoTotal = this.MontoTotal;
		 _PrestamoDictamen.MontoPrestamo = this.MontoPrestamo;
		 _PrestamoDictamen.MontoContraparteLocal = this.MontoContraparteLocal;
		 _PrestamoDictamen.MontoOtros = this.MontoOtros;
		 _PrestamoDictamen.IdAnalista = this.IdAnalista;
		 _PrestamoDictamen.IdPrestamo = this.IdPrestamo;
		 _PrestamoDictamen.IdPrestamoDictamenRelacionado = this.IdPrestamoDictamenRelacionado;
		 _PrestamoDictamen.Comentario = this.Comentario;
		 _PrestamoDictamen.IDPrestamoCalificacion = this.IDPrestamoCalificacion;
		 _PrestamoDictamen.CalificacionFecha = this.CalificacionFecha;
		 _PrestamoDictamen.CalificacionITecnico = this.CalificacionITecnico;
		 _PrestamoDictamen.CalificacionITFecha = this.CalificacionITFecha;
		 _PrestamoDictamen.CalificacionNotaDNIP = this.CalificacionNotaDNIP;
		 _PrestamoDictamen.CalificacionObservacion = this.CalificacionObservacion;
		 _PrestamoDictamen.CalificacionRecomendacion = this.CalificacionRecomendacion;
		 _PrestamoDictamen.FechaAlta = this.FechaAlta;
		 _PrestamoDictamen.FechaModificacion = this.FechaModificacion;
		 _PrestamoDictamen.IDUsuarioModificacion = this.IDUsuarioModificacion;
		 _PrestamoDictamen.IdPrestamoDictamenEstado = this.IdPrestamoDictamenEstado;
		 
		  return _PrestamoDictamen;
		}		
		public virtual void Set(PrestamoDictamen entity)
		{		   
		 this.IdPrestamoDictamen= entity.IdPrestamoDictamen ;
		  this.Expediente= entity.Expediente ;
		  this.IDOrganismo= entity.IDOrganismo ;
		  this.OrganismoDetalle= entity.OrganismoDetalle ;
		  this.Denominacion= entity.Denominacion ;
		  this.IdGestionTipo= entity.IdGestionTipo ;
		  this.IdOrganismoFinanciero= entity.IdOrganismoFinanciero ;
		  this.MontoTotal= entity.MontoTotal ;
		  this.MontoPrestamo= entity.MontoPrestamo ;
		  this.MontoContraparteLocal= entity.MontoContraparteLocal ;
		  this.MontoOtros= entity.MontoOtros ;
		  this.IdAnalista= entity.IdAnalista ;
		  this.IdPrestamo= entity.IdPrestamo ;
		  this.IdPrestamoDictamenRelacionado= entity.IdPrestamoDictamenRelacionado ;
		  this.Comentario= entity.Comentario ;
		  this.IDPrestamoCalificacion= entity.IDPrestamoCalificacion ;
		  this.CalificacionFecha= entity.CalificacionFecha ;
		  this.CalificacionITecnico= entity.CalificacionITecnico ;
		  this.CalificacionITFecha= entity.CalificacionITFecha ;
		  this.CalificacionNotaDNIP= entity.CalificacionNotaDNIP ;
		  this.CalificacionObservacion= entity.CalificacionObservacion ;
		  this.CalificacionRecomendacion= entity.CalificacionRecomendacion ;
		  this.FechaAlta= entity.FechaAlta ;
		  this.FechaModificacion= entity.FechaModificacion ;
		  this.IDUsuarioModificacion= entity.IDUsuarioModificacion ;
		  this.IdPrestamoDictamenEstado= entity.IdPrestamoDictamenEstado ;
		 		  
		}		
		public virtual bool Equals(PrestamoDictamen entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPrestamoDictamen.Equals(this.IdPrestamoDictamen))return false;
		  if((entity.Expediente == null)?this.Expediente!=null:  !( (this.Expediente== String.Empty && entity.Expediente== null) || (this.Expediente==null && entity.Expediente== String.Empty )) &&  !entity.Expediente.Trim().Replace ("\r","").Equals(this.Expediente.Trim().Replace ("\r","")))return false;
			 if(!entity.IDOrganismo.Equals(this.IDOrganismo))return false;
		  if((entity.OrganismoDetalle == null)?this.OrganismoDetalle!=null:  !( (this.OrganismoDetalle== String.Empty && entity.OrganismoDetalle== null) || (this.OrganismoDetalle==null && entity.OrganismoDetalle== String.Empty )) &&  !entity.OrganismoDetalle.Trim().Replace ("\r","").Equals(this.OrganismoDetalle.Trim().Replace ("\r","")))return false;
			 if((entity.Denominacion == null)?this.Denominacion!=null:  !( (this.Denominacion== String.Empty && entity.Denominacion== null) || (this.Denominacion==null && entity.Denominacion== String.Empty )) &&  !entity.Denominacion.Trim().Replace ("\r","").Equals(this.Denominacion.Trim().Replace ("\r","")))return false;
			 if(!entity.IdGestionTipo.Equals(this.IdGestionTipo))return false;
		  if(!entity.IdOrganismoFinanciero.Equals(this.IdOrganismoFinanciero))return false;
		  if((entity.MontoTotal == null)?(this.MontoTotal.HasValue):!entity.MontoTotal.Equals(this.MontoTotal))return false;
			 if((entity.MontoPrestamo == null)?(this.MontoPrestamo.HasValue):!entity.MontoPrestamo.Equals(this.MontoPrestamo))return false;
			 if((entity.MontoContraparteLocal == null)?(this.MontoContraparteLocal.HasValue):!entity.MontoContraparteLocal.Equals(this.MontoContraparteLocal))return false;
			 if((entity.MontoOtros == null)?(this.MontoOtros.HasValue):!entity.MontoOtros.Equals(this.MontoOtros))return false;
			 if((entity.IdAnalista == null)?(this.IdAnalista.HasValue):!entity.IdAnalista.Equals(this.IdAnalista))return false;
			 if((entity.IdPrestamo == null)?(this.IdPrestamo.HasValue):!entity.IdPrestamo.Equals(this.IdPrestamo))return false;
			 if((entity.IdPrestamoDictamenRelacionado == null)?(this.IdPrestamoDictamenRelacionado.HasValue && this.IdPrestamoDictamenRelacionado.Value > 0):!entity.IdPrestamoDictamenRelacionado.Equals(this.IdPrestamoDictamenRelacionado))return false;
						  if((entity.Comentario == null)?this.Comentario!=null:  !( (this.Comentario== String.Empty && entity.Comentario== null) || (this.Comentario==null && entity.Comentario== String.Empty )) &&  !entity.Comentario.Trim().Replace ("\r","").Equals(this.Comentario.Trim().Replace ("\r","")))return false;
			 if((entity.IDPrestamoCalificacion == null)?(this.IDPrestamoCalificacion.HasValue):!entity.IDPrestamoCalificacion.Equals(this.IDPrestamoCalificacion))return false;
			 if((entity.CalificacionFecha == null)?(this.CalificacionFecha.HasValue):!entity.CalificacionFecha.Equals(this.CalificacionFecha))return false;
			 if((entity.CalificacionITecnico == null)?this.CalificacionITecnico!=null:  !( (this.CalificacionITecnico== String.Empty && entity.CalificacionITecnico== null) || (this.CalificacionITecnico==null && entity.CalificacionITecnico== String.Empty )) &&  !entity.CalificacionITecnico.Trim().Replace ("\r","").Equals(this.CalificacionITecnico.Trim().Replace ("\r","")))return false;
			 if((entity.CalificacionITFecha == null)?(this.CalificacionITFecha.HasValue):!entity.CalificacionITFecha.Equals(this.CalificacionITFecha))return false;
			 if((entity.CalificacionNotaDNIP == null)?this.CalificacionNotaDNIP!=null:  !( (this.CalificacionNotaDNIP== String.Empty && entity.CalificacionNotaDNIP== null) || (this.CalificacionNotaDNIP==null && entity.CalificacionNotaDNIP== String.Empty )) &&  !entity.CalificacionNotaDNIP.Trim().Replace ("\r","").Equals(this.CalificacionNotaDNIP.Trim().Replace ("\r","")))return false;
			 if((entity.CalificacionObservacion == null)?this.CalificacionObservacion!=null:  !( (this.CalificacionObservacion== String.Empty && entity.CalificacionObservacion== null) || (this.CalificacionObservacion==null && entity.CalificacionObservacion== String.Empty )) &&  !entity.CalificacionObservacion.Trim().Replace ("\r","").Equals(this.CalificacionObservacion.Trim().Replace ("\r","")))return false;
			 if((entity.CalificacionRecomendacion == null)?this.CalificacionRecomendacion!=null:  !( (this.CalificacionRecomendacion== String.Empty && entity.CalificacionRecomendacion== null) || (this.CalificacionRecomendacion==null && entity.CalificacionRecomendacion== String.Empty )) &&  !entity.CalificacionRecomendacion.Trim().Replace ("\r","").Equals(this.CalificacionRecomendacion.Trim().Replace ("\r","")))return false;
			 if(!entity.FechaAlta.Equals(this.FechaAlta))return false;
		  if(!entity.FechaModificacion.Equals(this.FechaModificacion))return false;
		  if(!entity.IDUsuarioModificacion.Equals(this.IDUsuarioModificacion))return false;
		  if((entity.IdPrestamoDictamenEstado == null)?(this.IdPrestamoDictamenEstado.HasValue):!entity.IdPrestamoDictamenEstado.Equals(this.IdPrestamoDictamenEstado))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("PrestamoDictamen", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Expediente","Expediente")
			,new DataColumnMapping("Organismo","IdOrganismo")
			,new DataColumnMapping("OrganismoDetalle","OrganismoDetalle")
			,new DataColumnMapping("Denominacion","Denominacion")
			,new DataColumnMapping("GestionTipo","IdGestionTipo")
			,new DataColumnMapping("OrganismoFinanciero","IdOrganismoFinanciero")
			,new DataColumnMapping("MontoTotal","MontoTotal")
			,new DataColumnMapping("MontoPrestamo","MontoPrestamo")
			,new DataColumnMapping("MontoContraparteLocal","MontoContraparteLocal")
			,new DataColumnMapping("MontoOtros","MontoOtros")
			,new DataColumnMapping("Analista","IdAnalista")
			,new DataColumnMapping("Prestamo","IdPrestamo")
			,new DataColumnMapping("PrestamoDictamenRelacionado","PrestamoDictamen_Expediente")
			,new DataColumnMapping("Comentario","Comentario")
			,new DataColumnMapping("PrestamoCalificacion","IdPrestamoCalificacion")
			,new DataColumnMapping("CalificacionFecha","CalificacionFecha","{0:dd/MM/yyyy}")
			,new DataColumnMapping("CalificacionITecnico","CalificacioniTecnico")
			,new DataColumnMapping("CalificacionITFecha","CalificacionitFecha","{0:dd/MM/yyyy}")
			,new DataColumnMapping("CalificacionNotaDNIP","CalificacionNotadnip")
			,new DataColumnMapping("CalificacionObservacion","CalificacionObservacion")
			,new DataColumnMapping("CalificacionRecomendacion","CalificacionRecomendacion")
			,new DataColumnMapping("FechaAlta","FechaAlta","{0:dd/MM/yyyy}")
			,new DataColumnMapping("FechaModificacion","FechaModificacion","{0:dd/MM/yyyy}")
			,new DataColumnMapping("UsuarioModificacion","IdUsuarioModificacion")
			,new DataColumnMapping("PrestamoDictamenEstado","IdPrestamoDictamenEstado")
			}));
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PrestamoDictamenEstadoResult : IResult<int>
    {        
		public virtual int ID{get{return IdPrestamoDictamenEstado;}}
		 public int IdPrestamoDictamenEstado{get;set;}
		 public int IdPrestamoDictamen{get;set;}
		 public int IdEstado{get;set;}
		 public DateTime Fecha{get;set;}
		 public string Observacion{get;set;}
		 public int IdUsuario{get;set;}
		 
		 public string Estado_Nombre{get;set;}	
	public string Estado_Codigo{get;set;}	
	public int Estado_Orden{get;set;}	
	public string Estado_Descripcion{get;set;}	
	public bool Estado_Activo{get;set;}	
    //public string PrestamoDictamen_Expediente{get;set;}	
    //public int PrestamoDictamen_IDOrganismo{get;set;}	
    //public string PrestamoDictamen_OrganismoDetalle{get;set;}	
    //public string PrestamoDictamen_Denominacion{get;set;}	
    //public int PrestamoDictamen_IdGestionTipo{get;set;}	
    //public int PrestamoDictamen_IdOrganismoFinanciero{get;set;}	
    //public decimal? PrestamoDictamen_MontoTotal{get;set;}	
    //public decimal? PrestamoDictamen_MontoPrestamo{get;set;}	
    //public decimal? PrestamoDictamen_MontoContraparteLocal{get;set;}	
    //public decimal? PrestamoDictamen_MontoOtros{get;set;}	
    //public int? PrestamoDictamen_IdAnalista{get;set;}	
    //public int? PrestamoDictamen_IdPrestamo{get;set;}	
    //public int? PrestamoDictamen_IdPrestamoDictamenRelacionado{get;set;}	
    //public string PrestamoDictamen_Comentario{get;set;}	
    //public int? PrestamoDictamen_IDPrestamoCalificacion{get;set;}	
    //public DateTime? PrestamoDictamen_CalificacionFecha{get;set;}	
    //public string PrestamoDictamen_CalificacionITecnico{get;set;}	
    //public DateTime? PrestamoDictamen_CalificacionITFecha{get;set;}	
    //public string PrestamoDictamen_CalificacionNotaDNIP{get;set;}	
    //public string PrestamoDictamen_CalificacionObservacion{get;set;}	
    //public string PrestamoDictamen_CalificacionRecomendacion{get;set;}	
    //public DateTime PrestamoDictamen_FechaAlta{get;set;}	
    //public DateTime PrestamoDictamen_FechaModificacion{get;set;}	
    //public int PrestamoDictamen_IDUsuarioModificacion{get;set;}	
    //public int? PrestamoDictamen_IdEstado{get;set;}	
    //public DateTime? PrestamoDictamen_FechaEstado{get;set;}	
    public string Usuario_NombreUsuario{get;set;}	
    //public string Usuario_Clave{get;set;}	
    //public bool Usuario_Activo{get;set;}	
    //public bool Usuario_EsSectioralista{get;set;}	
    //public int Usuario_IdLanguage{get;set;}	
    //public bool Usuario_AccesoTotal{get;set;}	
					
		public virtual PrestamoDictamenEstado ToEntity()
		{
		   PrestamoDictamenEstado _PrestamoDictamenEstado = new PrestamoDictamenEstado();
		_PrestamoDictamenEstado.IdPrestamoDictamenEstado = this.IdPrestamoDictamenEstado;
		 _PrestamoDictamenEstado.IdPrestamoDictamen = this.IdPrestamoDictamen;
		 _PrestamoDictamenEstado.IdEstado = this.IdEstado;
		 _PrestamoDictamenEstado.Fecha = this.Fecha;
		 _PrestamoDictamenEstado.Observacion = this.Observacion;
		 _PrestamoDictamenEstado.IdUsuario = this.IdUsuario;
		 
		  return _PrestamoDictamenEstado;
		}		
		public virtual void Set(PrestamoDictamenEstado entity)
		{		   
		 this.IdPrestamoDictamenEstado= entity.IdPrestamoDictamenEstado ;
		  this.IdPrestamoDictamen= entity.IdPrestamoDictamen ;
		  this.IdEstado= entity.IdEstado ;
		  this.Fecha= entity.Fecha ;
		  this.Observacion= entity.Observacion ;
		  this.IdUsuario= entity.IdUsuario ;
		 		  
		}		
		public virtual bool Equals(PrestamoDictamenEstado entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPrestamoDictamenEstado.Equals(this.IdPrestamoDictamenEstado))return false;
		  if(!entity.IdPrestamoDictamen.Equals(this.IdPrestamoDictamen))return false;
		  if(!entity.IdEstado.Equals(this.IdEstado))return false;
		  if(!entity.Fecha.Equals(this.Fecha))return false;
		  if((entity.Observacion == null)?this.Observacion!=null:!entity.Observacion.Equals(this.Observacion))return false;
			 if(!entity.IdUsuario.Equals(this.IdUsuario))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("PrestamoDictamenEstado", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("PrestamoDictamen","PrestamoDictamen_Expediente")
			,new DataColumnMapping("Estado","Estado_Nombre")
			,new DataColumnMapping("Fecha","Fecha","{0:dd/MM/yyyy}")
			,new DataColumnMapping("Observacion","Observacion")
			,new DataColumnMapping("Usuario","Usuario_NombreUsuario")
			}));
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PrestamoEstadoAsociadoResult : IResult<int>
    {        
		public virtual int ID{get{return IdPrestamoEstadoasociado;}}
		 public int IdPrestamoEstadoasociado{get;set;}
		 public int IdPrestamo{get;set;}
		 public int IdEstado{get;set;}
		 public DateTime FechaEstimada{get;set;}
		 public DateTime? FechaRealizada{get;set;}
		 
		 public string Estado_Nombre{get;set;}	
	public int Estado_IdTipoEstado{get;set;}	
	public int Estado_Orden{get;set;}	
	public string Estado_Descripcion{get;set;}	
	public bool Estado_Activo{get;set;}	
	public int Prestamo_IdPrograma{get;set;}	
	public int Prestamo_Numero{get;set;}	
	public string Prestamo_Denominacion{get;set;}	
	public string Prestamo_Descripcion{get;set;}	
	public string Prestamo_Observacion{get;set;}	
	public DateTime Prestamo_FechaAlta{get;set;}	
	public DateTime Prestamo_FechaModificacion{get;set;}	
	public int Prestamo_IdUsuarioModificacion{get;set;}	
					
		public virtual PrestamoEstadoAsociado ToEntity()
		{
		   PrestamoEstadoAsociado _PrestamoEstadoAsociado = new PrestamoEstadoAsociado();
		_PrestamoEstadoAsociado.IdPrestamoEstadoasociado = this.IdPrestamoEstadoasociado;
		 _PrestamoEstadoAsociado.IdPrestamo = this.IdPrestamo;
		 _PrestamoEstadoAsociado.IdEstado = this.IdEstado;
		 _PrestamoEstadoAsociado.FechaEstimada = this.FechaEstimada;
		 _PrestamoEstadoAsociado.FechaRealizada = this.FechaRealizada;
		 
		  return _PrestamoEstadoAsociado;
		}		
		public virtual void Set(PrestamoEstadoAsociado entity)
		{		   
		 this.IdPrestamoEstadoasociado= entity.IdPrestamoEstadoasociado ;
		  this.IdPrestamo= entity.IdPrestamo ;
		  this.IdEstado= entity.IdEstado ;
		  this.FechaEstimada= entity.FechaEstimada ;
		  this.FechaRealizada= entity.FechaRealizada ;
		 		  
		}		
		public virtual bool Equals(PrestamoEstadoAsociado entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPrestamoEstadoasociado.Equals(this.IdPrestamoEstadoasociado))return false;
		  if(!entity.IdPrestamo.Equals(this.IdPrestamo))return false;
		  if(!entity.IdEstado.Equals(this.IdEstado))return false;
		  if(!entity.FechaEstimada.Equals(this.FechaEstimada))return false;
		  if((entity.FechaRealizada == null)?this.FechaRealizada!=null:!entity.FechaRealizada.Equals(this.FechaRealizada))return false;
			
		  return true;
        }
	}
}
		
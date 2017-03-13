using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PrestamoEstadoResult : IResult<int>
    {        
		public virtual int ID{get{return IdPrestamoEstado;}}
		 public int IdPrestamoEstado{get;set;}
		 public int IdPrestamo{get;set;}
		 public int IdEstado{get;set;}
		 public DateTime FechaEstimada{get;set;}
		 public DateTime? FechaRealizada{get;set;}
		 
		 public string Estado_Nombre{get;set;}	
	public string Estado_Codigo{get;set;}	
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
	public int? Prestamo_IdEstadoActual{get;set;}	
	public string Prestamo_ResponsablePolitico{get;set;}	
	public string Prestamo_ResponsableTecnico{get;set;}	
	public string Prestamo_CodigoVinculacion1{get;set;}	
	public string Prestamo_CodigoVinculacion2{get;set;}	
					
		public virtual PrestamoEstado ToEntity()
		{
		   PrestamoEstado _PrestamoEstado = new PrestamoEstado();
		_PrestamoEstado.IdPrestamoEstado = this.IdPrestamoEstado;
		 _PrestamoEstado.IdPrestamo = this.IdPrestamo;
		 _PrestamoEstado.IdEstado = this.IdEstado;
		 _PrestamoEstado.FechaEstimada = this.FechaEstimada;
		 _PrestamoEstado.FechaRealizada = this.FechaRealizada;
		 
		  return _PrestamoEstado;
		}		
		public virtual void Set(PrestamoEstado entity)
		{		   
		 this.IdPrestamoEstado= entity.IdPrestamoEstado ;
		  this.IdPrestamo= entity.IdPrestamo ;
		  this.IdEstado= entity.IdEstado ;
		  this.FechaEstimada= entity.FechaEstimada ;
		  this.FechaRealizada= entity.FechaRealizada ;
		 		  
		}		
		public virtual bool Equals(PrestamoEstado entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPrestamoEstado.Equals(this.IdPrestamoEstado))return false;
		  if(!entity.IdPrestamo.Equals(this.IdPrestamo))return false;
		  if(!entity.IdEstado.Equals(this.IdEstado))return false;
		  if(!entity.FechaEstimada.Equals(this.FechaEstimada))return false;
		  if((entity.FechaRealizada == null)?this.FechaRealizada!=null:!entity.FechaRealizada.Equals(this.FechaRealizada))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("PrestamoEstado", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Prestamo","Prestamo_Descripcion")
			,new DataColumnMapping("Estado","Estado_Nombre")
			,new DataColumnMapping("FechaEstimada","FechaEstimada","{0:dd/MM/yyyy}")
			,new DataColumnMapping("FechaRealizada","FechaRealizada","{0:dd/MM/yyyy}")
			}));
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PrestamoDesembolsoResult : IResult<int>
    {        
		public virtual int ID{get{return IdPrestamoDesembolso;}}
		 public int IdPrestamoDesembolso{get;set;}
		 public int? IdPrestamo{get;set;}
		 public DateTime? Fecha{get;set;}
		 public decimal? MontoAcumulado{get;set;}
		 public string Observacion{get;set;}
		 
		 public int? Prestamo_IdPrograma{get;set;}	
	public int? Prestamo_Numero{get;set;}	
	public string Prestamo_Denominacion{get;set;}	
	public string Prestamo_Descripcion{get;set;}	
	public string Prestamo_Observacion{get;set;}	
	public DateTime? Prestamo_FechaAlta{get;set;}	
	public DateTime? Prestamo_FechaModificacion{get;set;}	
	public int? Prestamo_IdUsuarioModificacion{get;set;}	
	public int? Prestamo_IdEstadoActual{get;set;}	
	public string Prestamo_ResponsablePolitico{get;set;}	
	public string Prestamo_ResponsableTecnico{get;set;}	
	public string Prestamo_CodigoVinculacion1{get;set;}	
	public string Prestamo_CodigoVinculacion2{get;set;}	
					
		public virtual PrestamoDesembolso ToEntity()
		{
		   PrestamoDesembolso _PrestamoDesembolso = new PrestamoDesembolso();
		_PrestamoDesembolso.IdPrestamoDesembolso = this.IdPrestamoDesembolso;
		 _PrestamoDesembolso.IdPrestamo = this.IdPrestamo;
		 _PrestamoDesembolso.Fecha = this.Fecha;
		 _PrestamoDesembolso.MontoAcumulado = this.MontoAcumulado;
		 _PrestamoDesembolso.Observacion = this.Observacion;
		 
		  return _PrestamoDesembolso;
		}		
		public virtual void Set(PrestamoDesembolso entity)
		{		   
		 this.IdPrestamoDesembolso= entity.IdPrestamoDesembolso ;
		  this.IdPrestamo= entity.IdPrestamo ;
		  this.Fecha= entity.Fecha ;
		  this.MontoAcumulado= entity.MontoAcumulado ;
		  this.Observacion= entity.Observacion ;
		 		  
		}		
		public virtual bool Equals(PrestamoDesembolso entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPrestamoDesembolso.Equals(this.IdPrestamoDesembolso))return false;
		  if((entity.IdPrestamo == null)?(this.IdPrestamo.HasValue && this.IdPrestamo.Value > 0):!entity.IdPrestamo.Equals(this.IdPrestamo))return false;
						  if((entity.Fecha == null)?this.Fecha!=null:!entity.Fecha.Equals(this.Fecha))return false;
			 if((entity.MontoAcumulado == null)?this.MontoAcumulado!=null:!entity.MontoAcumulado.Equals(this.MontoAcumulado))return false;
			 if((entity.Observacion == null)?this.Observacion!=null:!entity.Observacion.Equals(this.Observacion))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("PrestamoDesembolso", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Prestamo","Prestamo_Descripcion")
			,new DataColumnMapping("Fecha","Fecha","{0:dd/MM/yyyy}")
			,new DataColumnMapping("MontoAcumulado","MontoAcumulado")
			,new DataColumnMapping("Observacion","Observacion")
			}));
		}
	}
}
		
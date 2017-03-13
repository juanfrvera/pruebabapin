using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _MonedaCotizacionResult : IResult<int>
    {        
		public virtual int ID{get{return IdMonedaCotizacion;}}
		 public int IdMonedaCotizacion{get;set;}
		 public int IdMoneda{get;set;}
		 public DateTime Fecha{get;set;}
		 public decimal Cotizacion{get;set;}
		 
		 public string Moneda_Sigla{get;set;}	
	public string Moneda_Nombre{get;set;}	
	public bool Moneda_Activo{get;set;}	
	public bool Moneda_Base{get;set;}	
					
		public virtual MonedaCotizacion ToEntity()
		{
		   MonedaCotizacion _MonedaCotizacion = new MonedaCotizacion();
		_MonedaCotizacion.IdMonedaCotizacion = this.IdMonedaCotizacion;
		 _MonedaCotizacion.IdMoneda = this.IdMoneda;
		 _MonedaCotizacion.Fecha = this.Fecha;
		 _MonedaCotizacion.Cotizacion = this.Cotizacion;
		 
		  return _MonedaCotizacion;
		}		
		public virtual void Set(MonedaCotizacion entity)
		{		   
		 this.IdMonedaCotizacion= entity.IdMonedaCotizacion ;
		  this.IdMoneda= entity.IdMoneda ;
		  this.Fecha= entity.Fecha ;
		  this.Cotizacion= entity.Cotizacion ;
		 		  
		}		
		public virtual bool Equals(MonedaCotizacion entity)
        {
		   if(entity == null)return false;
         if(!entity.IdMonedaCotizacion.Equals(this.IdMonedaCotizacion))return false;
		  if(!entity.IdMoneda.Equals(this.IdMoneda))return false;
		  if(!entity.Fecha.Equals(this.Fecha))return false;
		  if(!entity.Cotizacion.Equals(this.Cotizacion))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("MonedaCotizacion", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Moneda","Moneda_Nombre")
			,new DataColumnMapping("Fecha","Fecha","{0:dd/MM/yyyy}")
			,new DataColumnMapping("Cotizacion","Cotizacion")
			}));
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoEtapaRealizadoPeriodoResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoEtapaRealizadoPeriodo;}}
		 public int IdProyectoEtapaRealizadoPeriodo{get;set;}
		 public int IdProyectoEtapaRealizado{get;set;}
		 public int Periodo{get;set;}
		 public DateTime Fecha{get;set;}
		 public decimal Monto{get;set;}
		 public decimal? Cotizacion{get;set;}
		 public decimal MontoCalculado{get;set;}
		 
		 public int ProyectoEtapaRealizado_IdProyectoEtapa{get;set;}	
	public int ProyectoEtapaRealizado_IdClasificacionGasto{get;set;}	
	public int ProyectoEtapaRealizado_IdFuenteFinanciamiento{get;set;}	
	public int? ProyectoEtapaRealizado_IdMoneda{get;set;}	
					
		public virtual ProyectoEtapaRealizadoPeriodo ToEntity()
		{
		   ProyectoEtapaRealizadoPeriodo _ProyectoEtapaRealizadoPeriodo = new ProyectoEtapaRealizadoPeriodo();
		_ProyectoEtapaRealizadoPeriodo.IdProyectoEtapaRealizadoPeriodo = this.IdProyectoEtapaRealizadoPeriodo;
		 _ProyectoEtapaRealizadoPeriodo.IdProyectoEtapaRealizado = this.IdProyectoEtapaRealizado;
		 _ProyectoEtapaRealizadoPeriodo.Periodo = this.Periodo;
		 _ProyectoEtapaRealizadoPeriodo.Fecha = this.Fecha;
		 _ProyectoEtapaRealizadoPeriodo.Monto = this.Monto;
		 _ProyectoEtapaRealizadoPeriodo.Cotizacion = this.Cotizacion;
		 _ProyectoEtapaRealizadoPeriodo.MontoCalculado = this.MontoCalculado;
		 
		  return _ProyectoEtapaRealizadoPeriodo;
		}		
		public virtual void Set(ProyectoEtapaRealizadoPeriodo entity)
		{		   
		 this.IdProyectoEtapaRealizadoPeriodo= entity.IdProyectoEtapaRealizadoPeriodo ;
		  this.IdProyectoEtapaRealizado= entity.IdProyectoEtapaRealizado ;
		  this.Periodo= entity.Periodo ;
		  this.Fecha= entity.Fecha ;
		  this.Monto= entity.Monto ;
		  this.Cotizacion= entity.Cotizacion ;
		  this.MontoCalculado= entity.MontoCalculado ;
		 		  
		}		
		public virtual bool Equals(ProyectoEtapaRealizadoPeriodo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoEtapaRealizadoPeriodo.Equals(this.IdProyectoEtapaRealizadoPeriodo))return false;
		  if(!entity.IdProyectoEtapaRealizado.Equals(this.IdProyectoEtapaRealizado))return false;
		  if(!entity.Periodo.Equals(this.Periodo))return false;
		  if(!entity.Fecha.Equals(this.Fecha))return false;
		  if(!entity.Monto.Equals(this.Monto))return false;
		  if((entity.Cotizacion == null)?this.Cotizacion!=null:!entity.Cotizacion.Equals(this.Cotizacion))return false;
			 if(!entity.MontoCalculado.Equals(this.MontoCalculado))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoEtapaRealizadoPeriodo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("ProyectoEtapaRealizado","ProyectoEtapaRealizado_IdProyectoEtapaRealizado")
			,new DataColumnMapping("Periodo","Periodo")
			,new DataColumnMapping("Fecha","Fecha","{0:dd/MM/yyyy}")
			,new DataColumnMapping("Monto","Monto")
			,new DataColumnMapping("Cotizacion","Cotizacion")
			,new DataColumnMapping("MontoCalculado","MontoCalculado")
			}));
		}
	}
}
		
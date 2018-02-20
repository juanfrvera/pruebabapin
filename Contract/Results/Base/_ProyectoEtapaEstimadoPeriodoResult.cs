using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoEtapaEstimadoPeriodoResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoEtapaEstimadoPeriodo;}}
		 public int IdProyectoEtapaEstimadoPeriodo{get;set;}
		 public int IdProyectoEtapaEstimado{get;set;}
		 public int Periodo{get;set;}
		 public decimal Monto{get;set;}
		 public decimal? Cotizacion{get;set;}
		 public decimal MontoCalculado{get;set;}
         public decimal MontoInicial{ get; set; }
         public decimal MontoVigente { get; set; }
         public decimal MontoDevengado { get; set; }
         public bool MontoVigenteEstimativo { get; set; }
		 
		 public int ProyectoEtapaEstimado_IdProyectoEtapa{get;set;}	
	public int ProyectoEtapaEstimado_IdClasificacionGasto{get;set;}	
	public int ProyectoEtapaEstimado_IdFuenteFinanciamiento{get;set;}	
	public int ProyectoEtapaEstimado_IdMoneda{get;set;}	
					
		public virtual ProyectoEtapaEstimadoPeriodo ToEntity()
		{
		   ProyectoEtapaEstimadoPeriodo _ProyectoEtapaEstimadoPeriodo = new ProyectoEtapaEstimadoPeriodo();
		_ProyectoEtapaEstimadoPeriodo.IdProyectoEtapaEstimadoPeriodo = this.IdProyectoEtapaEstimadoPeriodo;
		 _ProyectoEtapaEstimadoPeriodo.IdProyectoEtapaEstimado = this.IdProyectoEtapaEstimado;
		 _ProyectoEtapaEstimadoPeriodo.Periodo = this.Periodo;
		 _ProyectoEtapaEstimadoPeriodo.Monto = this.Monto;
		 _ProyectoEtapaEstimadoPeriodo.Cotizacion = this.Cotizacion;
		 _ProyectoEtapaEstimadoPeriodo.MontoCalculado = this.MontoCalculado;
         _ProyectoEtapaEstimadoPeriodo.MontoInicial = this.MontoInicial;
         _ProyectoEtapaEstimadoPeriodo.MontoVigente = this.MontoVigente;
         _ProyectoEtapaEstimadoPeriodo.MontoDevengado = this.MontoDevengado;
         _ProyectoEtapaEstimadoPeriodo.MontoVigenteEstimativo = this.MontoVigenteEstimativo;
		 
		  return _ProyectoEtapaEstimadoPeriodo;
		}		
		public virtual void Set(ProyectoEtapaEstimadoPeriodo entity)
		{		   
		 this.IdProyectoEtapaEstimadoPeriodo= entity.IdProyectoEtapaEstimadoPeriodo ;
		  this.IdProyectoEtapaEstimado= entity.IdProyectoEtapaEstimado ;
		  this.Periodo= entity.Periodo ;
		  this.Monto= entity.Monto ;
		  this.Cotizacion= entity.Cotizacion ;
		  this.MontoCalculado= entity.MontoCalculado ;
          this.MontoInicial = entity.MontoInicial;
          this.MontoVigente = entity.MontoVigente;
          this.MontoDevengado = entity.MontoDevengado;
          this.MontoVigenteEstimativo = entity.MontoVigenteEstimativo;
		 		  
		}		
		public virtual bool Equals(ProyectoEtapaEstimadoPeriodo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoEtapaEstimadoPeriodo.Equals(this.IdProyectoEtapaEstimadoPeriodo))return false;
		  if(!entity.IdProyectoEtapaEstimado.Equals(this.IdProyectoEtapaEstimado))return false;
		  if(!entity.Periodo.Equals(this.Periodo))return false;
		  if(!entity.Monto.Equals(this.Monto))return false;
		  if((entity.Cotizacion == null)?this.Cotizacion!=null:!entity.Cotizacion.Equals(this.Cotizacion))return false;
			 if(!entity.MontoCalculado.Equals(this.MontoCalculado))return false;
             if (!entity.MontoInicial.Equals(this.MontoInicial)) return false;
             if (!entity.MontoVigente.Equals(this.MontoVigente)) return false;
             if (!entity.MontoDevengado.Equals(this.MontoDevengado)) return false;
             if (!entity.MontoVigenteEstimativo.Equals(this.MontoVigenteEstimativo)) return false;
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoEtapaEstimadoPeriodo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("ProyectoEtapaEstimado","ProyectoEtapaEstimado_IdProyectoEtapaEstimado")
			,new DataColumnMapping("Periodo","Periodo")
			,new DataColumnMapping("Monto","Monto")
			,new DataColumnMapping("Cotizacion","Cotizacion")
			,new DataColumnMapping("MontoCalculado","MontoCalculado")
            ,new DataColumnMapping("MontoInicial","MontoInicial")
            ,new DataColumnMapping("MontoVigente","MontoVigente")
            ,new DataColumnMapping("MontoDevengado","MontoDevengado")
            ,new DataColumnMapping("MontoVigenteEstimativo","MontoVigenteEstimativo")
			}));
		}
	}
}
		
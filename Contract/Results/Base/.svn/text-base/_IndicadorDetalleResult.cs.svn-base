using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _IndicadorDetalleResult : IResult<int>
    {        
		public virtual int ID{get{return IdIndicadorDetalle;}}
		 public int IdIndicadorDetalle{get;set;}
		 public int? IdMedioVerificacion{get;set;}
		 public string Observacion{get;set;}
		 
		 public string MedioVerificacion_Sigla{get;set;}	
	public string MedioVerificacion_Nombre{get;set;}	
					
		public virtual IndicadorDetalle ToEntity()
		{
		   IndicadorDetalle _IndicadorDetalle = new IndicadorDetalle();
		_IndicadorDetalle.IdIndicadorDetalle = this.IdIndicadorDetalle;
		 _IndicadorDetalle.IdMedioVerificacion = this.IdMedioVerificacion;
		 _IndicadorDetalle.Observacion = this.Observacion;
		 
		  return _IndicadorDetalle;
		}		
		public virtual void Set(IndicadorDetalle entity)
		{		   
		 this.IdIndicadorDetalle= entity.IdIndicadorDetalle ;
		  this.IdMedioVerificacion= entity.IdMedioVerificacion ;
		  this.Observacion= entity.Observacion ;
		 		  
		}		
		public virtual bool Equals(IndicadorDetalle entity)
        {
		   if(entity == null)return false;
         if(!entity.IdIndicadorDetalle.Equals(this.IdIndicadorDetalle))return false;
		  if((entity.IdMedioVerificacion == null)?(this.IdMedioVerificacion.HasValue && this.IdMedioVerificacion.Value > 0):!entity.IdMedioVerificacion.Equals(this.IdMedioVerificacion))return false;
						  if((entity.Observacion == null)?this.Observacion!=null:!entity.Observacion.Equals(this.Observacion))return false;
			
		  return true;
        }
	}
}
		
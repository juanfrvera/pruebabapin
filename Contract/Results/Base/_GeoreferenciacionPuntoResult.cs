using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _GeoreferenciacionPuntoResult : IResult<int>
    {        
		public virtual int ID{get{return IdGeoreferenciacionPunto;}}
		 public int IdGeoreferenciacionPunto{get;set;}
		 public int IdGeoreferenciacion{get;set;}
		 public int Orden{get;set;}
		 public decimal Longitud{get;set;}
		 public decimal Latitud{get;set;}
		 public string descripcion{get;set;}
		 
		 public int Georeferenciacion_IdGeoreferenciacionTipo{get;set;}	
					
		public virtual GeoreferenciacionPunto ToEntity()
		{
		   GeoreferenciacionPunto _GeoreferenciacionPunto = new GeoreferenciacionPunto();
		_GeoreferenciacionPunto.IdGeoreferenciacionPunto = this.IdGeoreferenciacionPunto;
		 _GeoreferenciacionPunto.IdGeoreferenciacion = this.IdGeoreferenciacion;
		 _GeoreferenciacionPunto.Orden = this.Orden;
		 _GeoreferenciacionPunto.Longitud = this.Longitud;
		 _GeoreferenciacionPunto.Latitud = this.Latitud;
		 _GeoreferenciacionPunto.descripcion = this.descripcion;
		 
		  return _GeoreferenciacionPunto;
		}		
		public virtual void Set(GeoreferenciacionPunto entity)
		{		   
		 this.IdGeoreferenciacionPunto= entity.IdGeoreferenciacionPunto ;
		  this.IdGeoreferenciacion= entity.IdGeoreferenciacion ;
		  this.Orden= entity.Orden ;
		  this.Longitud= entity.Longitud ;
		  this.Latitud= entity.Latitud ;
		  this.descripcion= entity.descripcion ;
		 		  
		}		
		public virtual bool Equals(GeoreferenciacionPunto entity)
        {
		   if(entity == null)return false;
         if(!entity.IdGeoreferenciacionPunto.Equals(this.IdGeoreferenciacionPunto))return false;
		  if(!entity.IdGeoreferenciacion.Equals(this.IdGeoreferenciacion))return false;
		  if(!entity.Orden.Equals(this.Orden))return false;
		  if(!entity.Longitud.Equals(this.Longitud))return false;
		  if(!entity.Latitud.Equals(this.Latitud))return false;
		  if((entity.descripcion == null)?this.descripcion!=null:  !( (this.descripcion== String.Empty && entity.descripcion== null) || (this.descripcion==null && entity.descripcion== String.Empty )) &&  !entity.descripcion.Trim().Replace ("\r","").Equals(this.descripcion.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("GeoreferenciacionPunto", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Georeferenciacion","Georeferenciacion_IdGeoreferenciacion")
			,new DataColumnMapping("Orden","Orden")
			,new DataColumnMapping("Longitud","Longitud")
			,new DataColumnMapping("Latitud","Latitud")
			,new DataColumnMapping("descripcion","Descripcion")
			}));
		}
	}
}
		
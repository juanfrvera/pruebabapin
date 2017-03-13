using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _IndicadorObjetivoResult : IResult<int>
    {        
		public virtual int ID{get{return IdIndicadorPriorizacion;}}
		 public int IdIndicadorPriorizacion{get;set;}
		 public string Codigo{get;set;}
		 public string Nombre{get;set;}
		 public int IdUnidadMedida{get;set;}
		 public string Funcion{get;set;}
		 public bool Activo{get;set;}
		 
		 public string UnidadMedida_Sigla{get;set;}	
	public string UnidadMedida_Nombre{get;set;}	
	public bool UnidadMedida_Activo{get;set;}	
					
		public virtual IndicadorObjetivo ToEntity()
		{
		   IndicadorObjetivo _IndicadorObjetivo = new IndicadorObjetivo();
		_IndicadorObjetivo.IdIndicadorPriorizacion = this.IdIndicadorPriorizacion;
		 _IndicadorObjetivo.Codigo = this.Codigo;
		 _IndicadorObjetivo.Nombre = this.Nombre;
		 _IndicadorObjetivo.IdUnidadMedida = this.IdUnidadMedida;
		 _IndicadorObjetivo.Funcion = this.Funcion;
		 _IndicadorObjetivo.Activo = this.Activo;
		 
		  return _IndicadorObjetivo;
		}		
		public virtual void Set(IndicadorObjetivo entity)
		{		   
		 this.IdIndicadorPriorizacion= entity.IdIndicadorPriorizacion ;
		  this.Codigo= entity.Codigo ;
		  this.Nombre= entity.Nombre ;
		  this.IdUnidadMedida= entity.IdUnidadMedida ;
		  this.Funcion= entity.Funcion ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(IndicadorObjetivo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdIndicadorPriorizacion.Equals(this.IdIndicadorPriorizacion))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.IdUnidadMedida.Equals(this.IdUnidadMedida))return false;
		  if(!entity.Funcion.Equals(this.Funcion))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
	}
}
		
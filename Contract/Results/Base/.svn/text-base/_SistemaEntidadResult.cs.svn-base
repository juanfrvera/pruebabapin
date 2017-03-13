using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _SistemaEntidadResult : IResult<int>
    {        
		public virtual int ID{get{return IdSistemaEntidad;}}
		 public int IdSistemaEntidad{get;set;}
		 public string Codigo{get;set;}
		 public string Nombre{get;set;}
		 public string EntidadTipo{get;set;}
		 public string EntidadClase{get;set;}
		 public string EntidadClaseBase{get;set;}
		 public bool Activo{get;set;}
		 public bool? IncluirSeguridad{get;set;}
		 public bool? IncluirConfiguracion{get;set;}
		 
		 				
		public virtual SistemaEntidad ToEntity()
		{
		   SistemaEntidad _SistemaEntidad = new SistemaEntidad();
		_SistemaEntidad.IdSistemaEntidad = this.IdSistemaEntidad;
		 _SistemaEntidad.Codigo = this.Codigo;
		 _SistemaEntidad.Nombre = this.Nombre;
		 _SistemaEntidad.EntidadTipo = this.EntidadTipo;
		 _SistemaEntidad.EntidadClase = this.EntidadClase;
		 _SistemaEntidad.EntidadClaseBase = this.EntidadClaseBase;
		 _SistemaEntidad.Activo = this.Activo;
		 _SistemaEntidad.IncluirSeguridad = this.IncluirSeguridad;
		 _SistemaEntidad.IncluirConfiguracion = this.IncluirConfiguracion;
		 
		  return _SistemaEntidad;
		}		
		public virtual void Set(SistemaEntidad entity)
		{		   
		 this.IdSistemaEntidad= entity.IdSistemaEntidad ;
		  this.Codigo= entity.Codigo ;
		  this.Nombre= entity.Nombre ;
		  this.EntidadTipo= entity.EntidadTipo ;
		  this.EntidadClase= entity.EntidadClase ;
		  this.EntidadClaseBase= entity.EntidadClaseBase ;
		  this.Activo= entity.Activo ;
		  this.IncluirSeguridad= entity.IncluirSeguridad ;
		  this.IncluirConfiguracion= entity.IncluirConfiguracion ;
		 		  
		}		
		public virtual bool Equals(SistemaEntidad entity)
        {
		   if(entity == null)return false;
         if(!entity.IdSistemaEntidad.Equals(this.IdSistemaEntidad))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if((entity.EntidadTipo == null)?this.EntidadTipo!=null:!entity.EntidadTipo.Equals(this.EntidadTipo))return false;
			 if((entity.EntidadClase == null)?this.EntidadClase!=null:!entity.EntidadClase.Equals(this.EntidadClase))return false;
			 if((entity.EntidadClaseBase == null)?this.EntidadClaseBase!=null:!entity.EntidadClaseBase.Equals(this.EntidadClaseBase))return false;
			 if(!entity.Activo.Equals(this.Activo))return false;
		  if((entity.IncluirSeguridad == null)?this.IncluirSeguridad!=null:!entity.IncluirSeguridad.Equals(this.IncluirSeguridad))return false;
			 if((entity.IncluirConfiguracion == null)?this.IncluirConfiguracion!=null:!entity.IncluirConfiguracion.Equals(this.IncluirConfiguracion))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("SistemaEntidad", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("EntidadTipo","EntidadTipo")
			,new DataColumnMapping("EntidadClase","EntidadClase")
			,new DataColumnMapping("EntidadClaseBase","EntidadClaseBase")
			,new DataColumnMapping("Activo","Activo")
			,new DataColumnMapping("IncluirSeguridad","IncluirSeguridad")
			,new DataColumnMapping("IncluirConfiguracion","IncluirConfiguracion")
			}));
		}
	}
}
		
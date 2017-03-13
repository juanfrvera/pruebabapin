using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _SistemaEntidadEstadoResult : IResult<int>
    {        
		public virtual int ID{get{return IdSistemaEntidadEstado;}}
		 public int IdSistemaEntidadEstado{get;set;}
		 public int IdSistemaEntidad{get;set;}
		 public int IdEstado{get;set;}
		 public string Nombre{get;set;}
		 
		 public string Estado_Nombre{get;set;}	
	public string Estado_Codigo{get;set;}	
	public int Estado_Orden{get;set;}	
	public string Estado_Descripcion{get;set;}	
	public bool Estado_Activo{get;set;}	
	public string SistemaEntidad_Codigo{get;set;}	
	public string SistemaEntidad_Nombre{get;set;}	
	public string SistemaEntidad_EntidadTipo{get;set;}	
	public string SistemaEntidad_EntidadClase{get;set;}	
	public string SistemaEntidad_EntidadClaseBase{get;set;}	
	public bool SistemaEntidad_Activo{get;set;}	
	public bool? SistemaEntidad_IncluirSeguridad{get;set;}	
	public bool? SistemaEntidad_IncluirConfiguracion{get;set;}	
					
		public virtual SistemaEntidadEstado ToEntity()
		{
		   SistemaEntidadEstado _SistemaEntidadEstado = new SistemaEntidadEstado();
		_SistemaEntidadEstado.IdSistemaEntidadEstado = this.IdSistemaEntidadEstado;
		 _SistemaEntidadEstado.IdSistemaEntidad = this.IdSistemaEntidad;
		 _SistemaEntidadEstado.IdEstado = this.IdEstado;
		 _SistemaEntidadEstado.Nombre = this.Nombre;
		 
		  return _SistemaEntidadEstado;
		}		
		public virtual void Set(SistemaEntidadEstado entity)
		{		   
		 this.IdSistemaEntidadEstado= entity.IdSistemaEntidadEstado ;
		  this.IdSistemaEntidad= entity.IdSistemaEntidad ;
		  this.IdEstado= entity.IdEstado ;
		  this.Nombre= entity.Nombre ;
		 		  
		}		
		public virtual bool Equals(SistemaEntidadEstado entity)
        {
		   if(entity == null)return false;
         if(!entity.IdSistemaEntidadEstado.Equals(this.IdSistemaEntidadEstado))return false;
		  if(!entity.IdSistemaEntidad.Equals(this.IdSistemaEntidad))return false;
		  if(!entity.IdEstado.Equals(this.IdEstado))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("SistemaEntidadEstado", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("SistemaEntidad","SistemaEntidad_Nombre")
			,new DataColumnMapping("Estado","Estado_Nombre")
			,new DataColumnMapping("Nombre","Nombre")
			}));
		}
	}
}
		
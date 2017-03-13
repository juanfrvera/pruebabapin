using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PermisoResult : IResult<int>
    {        
		public virtual int ID{get{return IdPermiso;}}
		 public int IdPermiso{get;set;}
		 public string Nombre{get;set;}
		 public string Codigo{get;set;}
		 public int? IdSistemaEntidad{get;set;}
		 public int? IdSistemaAccion{get;set;}
		 public int? IdSistemaEstado{get;set;}
		 public bool? Activo{get;set;}
		 
		 public string SistemaEstado_Nombre{get;set;}	
	public string SistemaEstado_Codigo{get;set;}	
	public int? SistemaEstado_Orden{get;set;}	
	public string SistemaEstado_Descripcion{get;set;}	
	public bool? SistemaEstado_Activo{get;set;}	
	public string SistemaAccion_Codigo{get;set;}	
	public string SistemaAccion_Nombre{get;set;}	
	public bool? SistemaAccion_Activo{get;set;}	
	public bool? SistemaAccion_IncluirEstado{get;set;}	
	public bool? SistemaAccion_EsLectura{get;set;}	
	public string SistemaEntidad_Codigo{get;set;}	
	public string SistemaEntidad_Nombre{get;set;}	
	public string SistemaEntidad_EntidadTipo{get;set;}	
	public string SistemaEntidad_EntidadClase{get;set;}	
	public string SistemaEntidad_EntidadClaseBase{get;set;}	
	public bool? SistemaEntidad_Activo{get;set;}	
	public bool? SistemaEntidad_IncluirSeguridad{get;set;}	
	public bool? SistemaEntidad_IncluirConfiguracion{get;set;}	
					
		public virtual Permiso ToEntity()
		{
		   Permiso _Permiso = new Permiso();
		_Permiso.IdPermiso = this.IdPermiso;
		 _Permiso.Nombre = this.Nombre;
		 _Permiso.Codigo = this.Codigo;
		 _Permiso.IdSistemaEntidad = this.IdSistemaEntidad;
		 _Permiso.IdSistemaAccion = this.IdSistemaAccion;
		 _Permiso.IdSistemaEstado = this.IdSistemaEstado;
		 _Permiso.Activo = this.Activo;
		 
		  return _Permiso;
		}		
		public virtual void Set(Permiso entity)
		{		   
		 this.IdPermiso= entity.IdPermiso ;
		  this.Nombre= entity.Nombre ;
		  this.Codigo= entity.Codigo ;
		  this.IdSistemaEntidad= entity.IdSistemaEntidad ;
		  this.IdSistemaAccion= entity.IdSistemaAccion ;
		  this.IdSistemaEstado= entity.IdSistemaEstado ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(Permiso entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPermiso.Equals(this.IdPermiso))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if((entity.IdSistemaEntidad == null)?(this.IdSistemaEntidad.HasValue && this.IdSistemaEntidad.Value > 0):!entity.IdSistemaEntidad.Equals(this.IdSistemaEntidad))return false;
						  if((entity.IdSistemaAccion == null)?(this.IdSistemaAccion.HasValue && this.IdSistemaAccion.Value > 0):!entity.IdSistemaAccion.Equals(this.IdSistemaAccion))return false;
						  if((entity.IdSistemaEstado == null)?(this.IdSistemaEstado.HasValue && this.IdSistemaEstado.Value > 0):!entity.IdSistemaEstado.Equals(this.IdSistemaEstado))return false;
						  if((entity.Activo == null)?this.Activo!=null:!entity.Activo.Equals(this.Activo))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Permiso", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("SistemaEntidad","SistemaEntidad_Nombre")
			,new DataColumnMapping("SistemaAccion","SistemaAccion_Nombre")
			,new DataColumnMapping("SistemaEstado","Estado_Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _SistemaEntidadAccionResult : IResult<int>
    {        
		public virtual int ID{get{return IdSistemaEntidadAccion;}}
		 public int IdSistemaEntidadAccion{get;set;}
		 public int IdSistemaEntidad{get;set;}
		 public int IdSistemaAccion{get;set;}
		 public string Nombre{get;set;}
		 
		 public string SistemaAccion_Codigo{get;set;}	
	public string SistemaAccion_Nombre{get;set;}	
	public bool SistemaAccion_Activo{get;set;}	
	public bool SistemaAccion_IncluirEstado{get;set;}	
	public bool SistemaAccion_EsLectura{get;set;}	
	public string SistemaEntidad_Codigo{get;set;}	
	public string SistemaEntidad_Nombre{get;set;}	
	public string SistemaEntidad_EntidadTipo{get;set;}	
	public string SistemaEntidad_EntidadClase{get;set;}	
	public string SistemaEntidad_EntidadClaseBase{get;set;}	
	public bool SistemaEntidad_Activo{get;set;}	
	public bool? SistemaEntidad_IncluirSeguridad{get;set;}	
	public bool? SistemaEntidad_IncluirConfiguracion{get;set;}	
					
		public virtual SistemaEntidadAccion ToEntity()
		{
		   SistemaEntidadAccion _SistemaEntidadAccion = new SistemaEntidadAccion();
		_SistemaEntidadAccion.IdSistemaEntidadAccion = this.IdSistemaEntidadAccion;
		 _SistemaEntidadAccion.IdSistemaEntidad = this.IdSistemaEntidad;
		 _SistemaEntidadAccion.IdSistemaAccion = this.IdSistemaAccion;
		 _SistemaEntidadAccion.Nombre = this.Nombre;
		 
		  return _SistemaEntidadAccion;
		}		
		public virtual void Set(SistemaEntidadAccion entity)
		{		   
		 this.IdSistemaEntidadAccion= entity.IdSistemaEntidadAccion ;
		  this.IdSistemaEntidad= entity.IdSistemaEntidad ;
		  this.IdSistemaAccion= entity.IdSistemaAccion ;
		  this.Nombre= entity.Nombre ;
		 		  
		}		
		public virtual bool Equals(SistemaEntidadAccion entity)
        {
		   if(entity == null)return false;
         if(!entity.IdSistemaEntidadAccion.Equals(this.IdSistemaEntidadAccion))return false;
		  if(!entity.IdSistemaEntidad.Equals(this.IdSistemaEntidad))return false;
		  if(!entity.IdSistemaAccion.Equals(this.IdSistemaAccion))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("SistemaEntidadAccion", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("SistemaEntidad","SistemaEntidad_Nombre")
			,new DataColumnMapping("SistemaAccion","SistemaAccion_Nombre")
			,new DataColumnMapping("Nombre","Nombre")
			}));
		}
	}
}
		
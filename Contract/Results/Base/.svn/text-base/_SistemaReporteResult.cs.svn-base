using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _SistemaReporteResult : IResult<int>
    {        
		public virtual int ID{get{return IdSistemaReporte;}}
		 public int IdSistemaReporte{get;set;}
		 public string Nombre{get;set;}
		 public string Codigo{get;set;}
		 public string Descripcion{get;set;}
		 public int IdSistemaEntidad{get;set;}
		 public bool Activo{get;set;}
		 public bool EsListado{get;set;}
		 public string FileName{get;set;}
		 
		 public string SistemaEntidad_Codigo{get;set;}	
	public string SistemaEntidad_Nombre{get;set;}	
	public string SistemaEntidad_EntidadTipo{get;set;}	
	public string SistemaEntidad_EntidadClase{get;set;}	
	public string SistemaEntidad_EntidadClaseBase{get;set;}	
	public bool SistemaEntidad_Activo{get;set;}	
	public bool? SistemaEntidad_IncluirSeguridad{get;set;}	
	public bool? SistemaEntidad_IncluirConfiguracion{get;set;}	
					
		public virtual SistemaReporte ToEntity()
		{
		   SistemaReporte _SistemaReporte = new SistemaReporte();
		_SistemaReporte.IdSistemaReporte = this.IdSistemaReporte;
		 _SistemaReporte.Nombre = this.Nombre;
		 _SistemaReporte.Codigo = this.Codigo;
		 _SistemaReporte.Descripcion = this.Descripcion;
		 _SistemaReporte.IdSistemaEntidad = this.IdSistemaEntidad;
		 _SistemaReporte.Activo = this.Activo;
		 _SistemaReporte.EsListado = this.EsListado;
		 _SistemaReporte.FileName = this.FileName;
		 
		  return _SistemaReporte;
		}		
		public virtual void Set(SistemaReporte entity)
		{		   
		 this.IdSistemaReporte= entity.IdSistemaReporte ;
		  this.Nombre= entity.Nombre ;
		  this.Codigo= entity.Codigo ;
		  this.Descripcion= entity.Descripcion ;
		  this.IdSistemaEntidad= entity.IdSistemaEntidad ;
		  this.Activo= entity.Activo ;
		  this.EsListado= entity.EsListado ;
		  this.FileName= entity.FileName ;
		 		  
		}		
		public virtual bool Equals(SistemaReporte entity)
        {
		   if(entity == null)return false;
         if(!entity.IdSistemaReporte.Equals(this.IdSistemaReporte))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if((entity.Descripcion == null)?this.Descripcion!=null:!entity.Descripcion.Equals(this.Descripcion))return false;
			 if(!entity.IdSistemaEntidad.Equals(this.IdSistemaEntidad))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		  if(!entity.EsListado.Equals(this.EsListado))return false;
		  if(!entity.FileName.Equals(this.FileName))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("SistemaReporte", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Descripcion","Descripcion")
			,new DataColumnMapping("SistemaEntidad","SistemaEntidad_Nombre")
			,new DataColumnMapping("Activo","Activo")
			,new DataColumnMapping("EsListado","EsListado")
			,new DataColumnMapping("FileName","FileName")
			}));
		}
	}
}
		
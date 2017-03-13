using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoSeguimientoEstadoResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoSeguimientoEstado;}}
		 public int IdProyectoSeguimientoEstado{get;set;}
		 public int IdProyectoSeguimiento{get;set;}
		 public int IdEstado{get;set;}
		 public DateTime Fecha{get;set;}
		 public string Observacion{get;set;}
		 public int IdUsuario{get;set;}
		 
		 public string Estado_Nombre{get;set;}	
	public string Estado_Codigo{get;set;}	
	public int Estado_Orden{get;set;}	
	public string Estado_Descripcion{get;set;}	
	public bool Estado_Activo{get;set;}	
	public int ProyectoSeguimiento_IdSaf{get;set;}	
	public string ProyectoSeguimiento_Denominacion{get;set;}	
	public string ProyectoSeguimiento_Ruta{get;set;}	
	public string ProyectoSeguimiento_Malla{get;set;}	
	public int ProyectoSeguimiento_IdAnalista{get;set;}	
	public int? ProyectoSeguimiento_IdProyectoSeguimientoAnterior{get;set;}	
	public int? ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo{get;set;}	
	public string Usuario_NombreUsuario{get;set;}	
	public string Usuario_Clave{get;set;}	
	public bool Usuario_Activo{get;set;}	
	public bool Usuario_EsSectioralista{get;set;}	
	public int Usuario_IdLanguage{get;set;}	
	public bool Usuario_AccesoTotal{get;set;}	
    
		public virtual ProyectoSeguimientoEstado ToEntity()
		{
		   ProyectoSeguimientoEstado _ProyectoSeguimientoEstado = new ProyectoSeguimientoEstado();
		_ProyectoSeguimientoEstado.IdProyectoSeguimientoEstado = this.IdProyectoSeguimientoEstado;
		 _ProyectoSeguimientoEstado.IdProyectoSeguimiento = this.IdProyectoSeguimiento;
		 _ProyectoSeguimientoEstado.IdEstado = this.IdEstado;
		 _ProyectoSeguimientoEstado.Fecha = this.Fecha;
		 _ProyectoSeguimientoEstado.Observacion = this.Observacion;
		 _ProyectoSeguimientoEstado.IdUsuario = this.IdUsuario;
		 
		  return _ProyectoSeguimientoEstado;
		}		
		public virtual void Set(ProyectoSeguimientoEstado entity)
		{		   
		 this.IdProyectoSeguimientoEstado= entity.IdProyectoSeguimientoEstado ;
		  this.IdProyectoSeguimiento= entity.IdProyectoSeguimiento ;
		  this.IdEstado= entity.IdEstado ;
		  this.Fecha= entity.Fecha ;
		  this.Observacion= entity.Observacion ;
		  this.IdUsuario= entity.IdUsuario ;
		 		  
		}		
		public virtual bool Equals(ProyectoSeguimientoEstado entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoSeguimientoEstado.Equals(this.IdProyectoSeguimientoEstado))return false;
		  if(!entity.IdProyectoSeguimiento.Equals(this.IdProyectoSeguimiento))return false;
		  if(!entity.IdEstado.Equals(this.IdEstado))return false;
		  if(!entity.Fecha.Equals(this.Fecha))return false;
		  if((entity.Observacion == null)?this.Observacion!=null:!entity.Observacion.Equals(this.Observacion))return false;
			 if(!entity.IdUsuario.Equals(this.IdUsuario))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoSeguimientoEstado", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("ProyectoSeguimiento","ProyectoSeguimiento_Denominacion")
			,new DataColumnMapping("Estado","Estado_Nombre")
			,new DataColumnMapping("Fecha","Fecha","{0:dd/MM/yyyy}")
			,new DataColumnMapping("Observacion","Observacion")
			,new DataColumnMapping("Usuario","Usuario_NombreUsuario")
			}));
		}
	}
}
		
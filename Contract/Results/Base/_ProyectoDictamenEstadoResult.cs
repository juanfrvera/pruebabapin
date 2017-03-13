using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoDictamenEstadoResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoDictamenEstado;}}
		 public int IdProyectoDictamenEstado{get;set;}
		 public int IdProyectoDictamen{get;set;}
		 public int IdEstado{get;set;}
		 public DateTime Fecha{get;set;}
		 public string Observacion{get;set;}
		 public int IdUsuario{get;set;}
		 
		 public string Estado_Nombre{get;set;}	
	public string Estado_Codigo{get;set;}	
	public int Estado_Orden{get;set;}	
	public string Estado_Descripcion{get;set;}	
	public bool Estado_Activo{get;set;}	
	public int? ProyectoDictamen_IdProyectoCalificacion{get;set;}	
	public DateTime? ProyectoDictamen_Fecha{get;set;}	
	public DateTime? ProyectoDictamen_FechaVencimiento{get;set;}	
	public int? ProyectoDictamen_IdPlanPeriodo{get;set;}	
	public decimal? ProyectoDictamen_Monto{get;set;}	
	public int? ProyectoDictamen_Ejercicio{get;set;}	
	public int? ProyectoDictamen_DuracionMeses{get;set;}	
	public string ProyectoDictamen_InformeTecnico{get;set;}	
	public DateTime? ProyectoDictamen_FechaComiteTecnico{get;set;}	
	public string ProyectoDictamen_Observacion{get;set;}	
	public string ProyectoDictamen_Recomendacion{get;set;}	
	public string ProyectoDictamen_RespuestaOrganismo{get;set;}	
	public DateTime? ProyectoDictamen_FechaRepuesta{get;set;}	
	public DateTime ProyectoDictamen_FechaEstado{get;set;}	
	public string ProyectoDictamen_Numero{get;set;}	
	public string ProyectoDictamen_Denominacion{get;set;}	
	//public int? ProyectoDictamen_IdFile{get;set;}	
	public int? ProyectoDictamen_IdProyectoDictamenEstadoUltimo{get;set;}	
	public string Usuario_NombreUsuario{get;set;}	
	public string Usuario_Clave{get;set;}	
	public bool Usuario_Activo{get;set;}	
	public bool Usuario_EsSectioralista{get;set;}	
	public int Usuario_IdLanguage{get;set;}	
	public bool Usuario_AccesoTotal{get;set;}	
					
		public virtual ProyectoDictamenEstado ToEntity()
		{
		   ProyectoDictamenEstado _ProyectoDictamenEstado = new ProyectoDictamenEstado();
		_ProyectoDictamenEstado.IdProyectoDictamenEstado = this.IdProyectoDictamenEstado;
		 _ProyectoDictamenEstado.IdProyectoDictamen = this.IdProyectoDictamen;
		 _ProyectoDictamenEstado.IdEstado = this.IdEstado;
		 _ProyectoDictamenEstado.Fecha = this.Fecha;
		 _ProyectoDictamenEstado.Observacion = this.Observacion;
		 _ProyectoDictamenEstado.IdUsuario = this.IdUsuario;
		 
		  return _ProyectoDictamenEstado;
		}		
		public virtual void Set(ProyectoDictamenEstado entity)
		{		   
		 this.IdProyectoDictamenEstado= entity.IdProyectoDictamenEstado ;
		  this.IdProyectoDictamen= entity.IdProyectoDictamen ;
		  this.IdEstado= entity.IdEstado ;
		  this.Fecha= entity.Fecha ;
		  this.Observacion= entity.Observacion ;
		  this.IdUsuario= entity.IdUsuario ;
		 		  
		}		
		public virtual bool Equals(ProyectoDictamenEstado entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoDictamenEstado.Equals(this.IdProyectoDictamenEstado))return false;
		  if(!entity.IdProyectoDictamen.Equals(this.IdProyectoDictamen))return false;
		  if(!entity.IdEstado.Equals(this.IdEstado))return false;
		  if(!entity.Fecha.Equals(this.Fecha))return false;
		  if((entity.Observacion == null)?this.Observacion!=null:  !( (this.Observacion== String.Empty && entity.Observacion== null) || (this.Observacion==null && entity.Observacion== String.Empty )) &&  !entity.Observacion.Trim().Replace ("\r","").Equals(this.Observacion.Trim().Replace ("\r","")))return false;
			 if(!entity.IdUsuario.Equals(this.IdUsuario))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoDictamenEstado", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("ProyectoDictamenEstado","IdProyectoDictamenEstado")
			,new DataColumnMapping("ProyectoDictamen","ProyectoDictamen_InformeTecnico")
			,new DataColumnMapping("Estado","Estado_Nombre")
			,new DataColumnMapping("Fecha","Fecha","{0:dd/MM/yyyy}")
			,new DataColumnMapping("Observacion","Observacion")
			,new DataColumnMapping("Usuario","Usuario_NombreUsuario")
			}));
		}
	}
}
		
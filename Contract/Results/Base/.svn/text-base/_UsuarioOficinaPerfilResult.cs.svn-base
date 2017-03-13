using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _UsuarioOficinaPerfilResult : IResult<int>
    {        
		public virtual int ID{get{return IdUsuarioOficinaPerfil;}}
		 public int IdUsuarioOficinaPerfil{get;set;}
		 public int IdUsuario{get;set;}
		 public int IdOficina{get;set;}
		 public int IdPerfil{get;set;}
		 public bool Activo{get;set;}
		 public bool HeredaConsulta{get;set;}
		 public bool HeredaEdicion{get;set;}
		 public string Codigo{get;set;}
		 public bool AccesoTotal{get;set;}
		 
		 public string Oficina_Nombre{get;set;}	
	public string Oficina_Codigo{get;set;}	
	public bool Oficina_Activo{get;set;}	
	public bool Oficina_Visible{get;set;}	
	public int? Oficina_IdOficinaPadre{get;set;}	
	public int? Oficina_IdSaf{get;set;}	
	public string Oficina_BreadcrumbId{get;set;}	
	public string Oficina_BreadcrumbOrden{get;set;}	
	public int Oficina_Nivel{get;set;}	
	public int? Oficina_Orden{get;set;}	
	public string Oficina_Descripcion{get;set;}	
	public string Oficina_DescripcionInvertida{get;set;}	
	public bool Oficina_Seleccionable{get;set;}	
	public string Oficina_BreadcrumbCode{get;set;}	
	public string Oficina_DescripcionCodigo{get;set;}	
	public string Perfil_Nombre{get;set;}	
	public int Perfil_IdPerfilTipo{get;set;}	
	public bool Perfil_Activo{get;set;}	
	public bool Perfil_EsDefault{get;set;}	
	public string Perfil_Codigo{get;set;}	
	public string Usuario_NombreUsuario{get;set;}	
	public string Usuario_Clave{get;set;}	
	public bool Usuario_Activo{get;set;}	
	public bool Usuario_EsSectioralista{get;set;}	
	public int Usuario_IdLanguage{get;set;}	
	public bool Usuario_AccesoTotal{get;set;}	
					
		public virtual UsuarioOficinaPerfil ToEntity()
		{
		   UsuarioOficinaPerfil _UsuarioOficinaPerfil = new UsuarioOficinaPerfil();
		_UsuarioOficinaPerfil.IdUsuarioOficinaPerfil = this.IdUsuarioOficinaPerfil;
		 _UsuarioOficinaPerfil.IdUsuario = this.IdUsuario;
		 _UsuarioOficinaPerfil.IdOficina = this.IdOficina;
		 _UsuarioOficinaPerfil.IdPerfil = this.IdPerfil;
		 _UsuarioOficinaPerfil.Activo = this.Activo;
		 _UsuarioOficinaPerfil.HeredaConsulta = this.HeredaConsulta;
		 _UsuarioOficinaPerfil.HeredaEdicion = this.HeredaEdicion;
		 _UsuarioOficinaPerfil.Codigo = this.Codigo;
		 _UsuarioOficinaPerfil.AccesoTotal = this.AccesoTotal;
		 
		  return _UsuarioOficinaPerfil;
		}		
		public virtual void Set(UsuarioOficinaPerfil entity)
		{		   
		 this.IdUsuarioOficinaPerfil= entity.IdUsuarioOficinaPerfil ;
		  this.IdUsuario= entity.IdUsuario ;
		  this.IdOficina= entity.IdOficina ;
		  this.IdPerfil= entity.IdPerfil ;
		  this.Activo= entity.Activo ;
		  this.HeredaConsulta= entity.HeredaConsulta ;
		  this.HeredaEdicion= entity.HeredaEdicion ;
		  this.Codigo= entity.Codigo ;
		  this.AccesoTotal= entity.AccesoTotal ;
		 		  
		}		
		public virtual bool Equals(UsuarioOficinaPerfil entity)
        {
		   if(entity == null)return false;
         if(!entity.IdUsuarioOficinaPerfil.Equals(this.IdUsuarioOficinaPerfil))return false;
		  if(!entity.IdUsuario.Equals(this.IdUsuario))return false;
		  if(!entity.IdOficina.Equals(this.IdOficina))return false;
		  if(!entity.IdPerfil.Equals(this.IdPerfil))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		  if(!entity.HeredaConsulta.Equals(this.HeredaConsulta))return false;
		  if(!entity.HeredaEdicion.Equals(this.HeredaEdicion))return false;
		  if((entity.Codigo == null)?this.Codigo!=null:!entity.Codigo.Equals(this.Codigo))return false;
			 if(!entity.AccesoTotal.Equals(this.AccesoTotal))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("UsuarioOficinaPerfil", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Usuario","Usuario_NombreUsuario")
			,new DataColumnMapping("Oficina","Oficina_Nombre")
			,new DataColumnMapping("Perfil","Perfil_Nombre")
			,new DataColumnMapping("Activo","Activo")
			,new DataColumnMapping("HeredaConsulta","HeredaConsulta")
			,new DataColumnMapping("HeredaEdicion","HeredaEdicion")
			,new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("AccesoTotal","AccesoTotal")
			}));
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _SistemaAccionResult : IResult<int>
    {        
		public virtual int ID{get{return IdSistemaAccion;}}
		 public int IdSistemaAccion{get;set;}
		 public string Codigo{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 public bool IncluirEstado{get;set;}
		 public bool EsLectura{get;set;}
		 
		 				
		public virtual SistemaAccion ToEntity()
		{
		   SistemaAccion _SistemaAccion = new SistemaAccion();
		_SistemaAccion.IdSistemaAccion = this.IdSistemaAccion;
		 _SistemaAccion.Codigo = this.Codigo;
		 _SistemaAccion.Nombre = this.Nombre;
		 _SistemaAccion.Activo = this.Activo;
		 _SistemaAccion.IncluirEstado = this.IncluirEstado;
		 _SistemaAccion.EsLectura = this.EsLectura;
		 
		  return _SistemaAccion;
		}		
		public virtual void Set(SistemaAccion entity)
		{		   
		 this.IdSistemaAccion= entity.IdSistemaAccion ;
		  this.Codigo= entity.Codigo ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		  this.IncluirEstado= entity.IncluirEstado ;
		  this.EsLectura= entity.EsLectura ;
		 		  
		}		
		public virtual bool Equals(SistemaAccion entity)
        {
		   if(entity == null)return false;
         if(!entity.IdSistemaAccion.Equals(this.IdSistemaAccion))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		  if(!entity.IncluirEstado.Equals(this.IncluirEstado))return false;
		  if(!entity.EsLectura.Equals(this.EsLectura))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("SistemaAccion", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			,new DataColumnMapping("IncluirEstado","IncluirEstado")
			,new DataColumnMapping("EsLectura","EsLectura")
			}));
		}
	}
}
		
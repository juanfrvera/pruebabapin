using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _EtapaResult : IResult<int>
    {        
		public virtual int ID{get{return IdEtapa;}}
		 public int IdEtapa{get;set;}
		 public int IdFase{get;set;}
		 public string Codigo{get;set;}
		 public string Nombre{get;set;}
		 public int Orden{get;set;}
		 public bool Activo{get;set;}
		 
		 public string Fase_Codigo{get;set;}	
	public string Fase_Nombre{get;set;}	
	public int Fase_Orden{get;set;}	
	public bool Fase_Activo{get;set;}	
					
		public virtual Etapa ToEntity()
		{
		   Etapa _Etapa = new Etapa();
		_Etapa.IdEtapa = this.IdEtapa;
		 _Etapa.IdFase = this.IdFase;
		 _Etapa.Codigo = this.Codigo;
		 _Etapa.Nombre = this.Nombre;
		 _Etapa.Orden = this.Orden;
		 _Etapa.Activo = this.Activo;
		 
		  return _Etapa;
		}		
		public virtual void Set(Etapa entity)
		{		   
		 this.IdEtapa= entity.IdEtapa ;
		  this.IdFase= entity.IdFase ;
		  this.Codigo= entity.Codigo ;
		  this.Nombre= entity.Nombre ;
		  this.Orden= entity.Orden ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(Etapa entity)
        {
		   if(entity == null)return false;
         if(!entity.IdEtapa.Equals(this.IdEtapa))return false;
		  if(!entity.IdFase.Equals(this.IdFase))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Orden.Equals(this.Orden))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Etapa", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Fase","Fase_Nombre")
			,new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Orden","Orden")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		
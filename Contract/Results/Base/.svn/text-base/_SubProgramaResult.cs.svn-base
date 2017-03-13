using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _SubProgramaResult : IResult<int>
    {        
		public virtual int ID{get{return IdSubPrograma;}}
		 public int IdSubPrograma{get;set;}
		 public int IdPrograma{get;set;}
		 public string Codigo{get;set;}
		 public string Nombre{get;set;}
		 public DateTime FechaAlta{get;set;}
		 public DateTime? FechaBaja{get;set;}
		 public bool Activo{get;set;}
		 
		 public int Programa_IdSAF{get;set;}	
	public string Programa_Codigo{get;set;}	
	public string Programa_Nombre{get;set;}	
	public DateTime Programa_FechaAlta{get;set;}	
	public DateTime? Programa_FechaBaja{get;set;}	
	public bool Programa_Activo{get;set;}	
	public int? Programa_IdSectorialista{get;set;}	
					
		public virtual SubPrograma ToEntity()
		{
		   SubPrograma _SubPrograma = new SubPrograma();
		_SubPrograma.IdSubPrograma = this.IdSubPrograma;
		 _SubPrograma.IdPrograma = this.IdPrograma;
		 _SubPrograma.Codigo = this.Codigo;
		 _SubPrograma.Nombre = this.Nombre;
		 _SubPrograma.FechaAlta = this.FechaAlta;
		 _SubPrograma.FechaBaja = this.FechaBaja;
		 _SubPrograma.Activo = this.Activo;
		 
		  return _SubPrograma;
		}		
		public virtual void Set(SubPrograma entity)
		{		   
		 this.IdSubPrograma= entity.IdSubPrograma ;
		  this.IdPrograma= entity.IdPrograma ;
		  this.Codigo= entity.Codigo ;
		  this.Nombre= entity.Nombre ;
		  this.FechaAlta= entity.FechaAlta ;
		  this.FechaBaja= entity.FechaBaja ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(SubPrograma entity)
        {
		   if(entity == null)return false;
         if(!entity.IdSubPrograma.Equals(this.IdSubPrograma))return false;
		  if(!entity.IdPrograma.Equals(this.IdPrograma))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.FechaAlta.Equals(this.FechaAlta))return false;
		  if((entity.FechaBaja == null)?this.FechaBaja!=null:!entity.FechaBaja.Equals(this.FechaBaja))return false;
			 if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("SubPrograma", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Programa","Programa_Nombre")
			,new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("FechaAlta","FechaAlta","{0:dd/MM/yyyy}")
			,new DataColumnMapping("FechaBaja","FechaBaja","{0:dd/MM/yyyy}")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		
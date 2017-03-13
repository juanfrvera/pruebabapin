using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _OficinaSafProgramaResult : IResult<int>
    {        
		public virtual int ID{get{return IdOficinaSafPrograma;}}
		 public int IdOficinaSafPrograma{get;set;}
		 public int IdOficinaSaf{get;set;}
		 public int IdPrograma{get;set;}
		 
		 public int OficinaSaf_IdOficina{get;set;}	
	public int OficinaSaf_IdSaf{get;set;}	
	public int Programa_IdSAF{get;set;}	
	public string Programa_Codigo{get;set;}	
	public string Programa_Nombre{get;set;}	
	public DateTime Programa_FechaAlta{get;set;}	
	public DateTime? Programa_FechaBaja{get;set;}	
	public bool Programa_Activo{get;set;}	
	public int? Programa_IdSectorialista{get;set;}	
					
		public virtual OficinaSafPrograma ToEntity()
		{
		   OficinaSafPrograma _OficinaSafPrograma = new OficinaSafPrograma();
		_OficinaSafPrograma.IdOficinaSafPrograma = this.IdOficinaSafPrograma;
		 _OficinaSafPrograma.IdOficinaSaf = this.IdOficinaSaf;
		 _OficinaSafPrograma.IdPrograma = this.IdPrograma;
		 
		  return _OficinaSafPrograma;
		}		
		public virtual void Set(OficinaSafPrograma entity)
		{		   
		 this.IdOficinaSafPrograma= entity.IdOficinaSafPrograma ;
		  this.IdOficinaSaf= entity.IdOficinaSaf ;
		  this.IdPrograma= entity.IdPrograma ;
		 		  
		}		
		public virtual bool Equals(OficinaSafPrograma entity)
        {
		   if(entity == null)return false;
         if(!entity.IdOficinaSafPrograma.Equals(this.IdOficinaSafPrograma))return false;
		  if(!entity.IdOficinaSaf.Equals(this.IdOficinaSaf))return false;
		  if(!entity.IdPrograma.Equals(this.IdPrograma))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("OficinaSafPrograma", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("OficinaSaf","OficinaSaf_IdOficinaSaf")
			,new DataColumnMapping("Programa","Programa_Nombre")
			}));
		}
	}
}
		
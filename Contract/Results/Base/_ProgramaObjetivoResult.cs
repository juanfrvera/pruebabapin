using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProgramaObjetivoResult : IResult<int>
    {        
		public virtual int ID{get{return IdProgramaObjetivo;}}
		 public int IdProgramaObjetivo{get;set;}
		 public int IdPrograma{get;set;}
		 public int IDObjetivo{get;set;}
		 
		 public string Objetivo_Nombre{get;set;}	
    //public int Programa_IdSAF{get;set;}	
    //public string Programa_Codigo{get;set;}	
    //public string Programa_Nombre{get;set;}	
    //public DateTime Programa_FechaAlta{get;set;}	
    //public DateTime? Programa_FechaBaja{get;set;}	
    //public bool Programa_Activo{get;set;}	
    //public int? Programa_IdSectorialista{get;set;}	
					
		public virtual ProgramaObjetivo ToEntity()
		{
		   ProgramaObjetivo _ProgramaObjetivo = new ProgramaObjetivo();
		_ProgramaObjetivo.IdProgramaObjetivo = this.IdProgramaObjetivo;
		 _ProgramaObjetivo.IdPrograma = this.IdPrograma;
		 _ProgramaObjetivo.IDObjetivo = this.IDObjetivo;
		 
		  return _ProgramaObjetivo;
		}		
		public virtual void Set(ProgramaObjetivo entity)
		{		   
		 this.IdProgramaObjetivo= entity.IdProgramaObjetivo ;
		  this.IdPrograma= entity.IdPrograma ;
		  this.IDObjetivo= entity.IDObjetivo ;
		 		  
		}		
		public virtual bool Equals(ProgramaObjetivo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProgramaObjetivo.Equals(this.IdProgramaObjetivo))return false;
		  if(!entity.IdPrograma.Equals(this.IdPrograma))return false;
		  if(!entity.IDObjetivo.Equals(this.IDObjetivo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProgramaObjetivo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Programa","Programa_Nombre")
			,new DataColumnMapping("Objetivo","Objetivo_Nombre")
			}));
		}
	}
}
		
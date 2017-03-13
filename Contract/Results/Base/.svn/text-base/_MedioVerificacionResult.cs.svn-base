using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _MedioVerificacionResult : IResult<int>
    {        
		public virtual int ID{get{return IdMedioVerificacion;}}
		 public int IdMedioVerificacion{get;set;}
		 public string Sigla{get;set;}
		 public string Nombre{get;set;}
		 
		 				
		public virtual MedioVerificacion ToEntity()
		{
		   MedioVerificacion _MedioVerificacion = new MedioVerificacion();
		_MedioVerificacion.IdMedioVerificacion = this.IdMedioVerificacion;
		 _MedioVerificacion.Sigla = this.Sigla;
		 _MedioVerificacion.Nombre = this.Nombre;
		 
		  return _MedioVerificacion;
		}		
		public virtual void Set(MedioVerificacion entity)
		{		   
		 this.IdMedioVerificacion= entity.IdMedioVerificacion ;
		  this.Sigla= entity.Sigla ;
		  this.Nombre= entity.Nombre ;
		 		  
		}		
		public virtual bool Equals(MedioVerificacion entity)
        {
		   if(entity == null)return false;
         if(!entity.IdMedioVerificacion.Equals(this.IdMedioVerificacion))return false;
		  if(!entity.Sigla.Equals(this.Sigla))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("MedioVerificacion", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Sigla","Sigla")
			,new DataColumnMapping("Nombre","Nombre")
			}));
		}
	}
}
		
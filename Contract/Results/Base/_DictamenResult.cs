using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _DictamenResult : IResult<int>
    {        
		public virtual int ID{get{return IdDictamen;}}
		 public int IdDictamen{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 public int IdDictamenTipo{get;set;}
		 public int? IdDictamenPadre{get;set;}
		 
		 public string DictamenPadre_Nombre{get;set;}	
	public bool? DictamenPadre_Activo{get;set;}	
	public int? DictamenPadre_IdDictamenTipo{get;set;}	
	public int? DictamenPadre_IdDictamenPadre{get;set;}	
	public string DictamenTipo_Nombre{get;set;}	
	public int DictamenTipo_Nivel{get;set;}	
					
		public virtual Dictamen ToEntity()
		{
		   Dictamen _Dictamen = new Dictamen();
		_Dictamen.IdDictamen = this.IdDictamen;
		 _Dictamen.Nombre = this.Nombre;
		 _Dictamen.Activo = this.Activo;
		 _Dictamen.IdDictamenTipo = this.IdDictamenTipo;
		 _Dictamen.IdDictamenPadre = this.IdDictamenPadre;
		 
		  return _Dictamen;
		}		
		public virtual void Set(Dictamen entity)
		{		   
		 this.IdDictamen= entity.IdDictamen ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		  this.IdDictamenTipo= entity.IdDictamenTipo ;
		  this.IdDictamenPadre= entity.IdDictamenPadre ;
		 		  
		}		
		public virtual bool Equals(Dictamen entity)
        {
		   if(entity == null)return false;
         if(!entity.IdDictamen.Equals(this.IdDictamen))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		  if(!entity.IdDictamenTipo.Equals(this.IdDictamenTipo))return false;
		  if((entity.IdDictamenPadre == null)?(this.IdDictamenPadre.HasValue && this.IdDictamenPadre.Value > 0):!entity.IdDictamenPadre.Equals(this.IdDictamenPadre))return false;
						 
		  return true;
        }
	}
}
		
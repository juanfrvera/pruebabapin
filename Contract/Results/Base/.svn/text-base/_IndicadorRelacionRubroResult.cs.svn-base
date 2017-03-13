using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _IndicadorRelacionRubroResult : IResult<int>
    {        
		public virtual int ID{get{return IdIndicadorRelacionRubro;}}
		 public int IdIndicadorRelacionRubro{get;set;}
		 public int IdIndicadorClase{get;set;}
		 public int IdIndicadorRubro{get;set;}
		 
		 public int IndicadorClase_IdIndicadorTipo{get;set;}	
	public string IndicadorClase_Sigla{get;set;}	
	public string IndicadorClase_Nombre{get;set;}	
	public int IndicadorClase_IdUnidad{get;set;}	
	public int? IndicadorClase_RangoInicial{get;set;}	
	public int? IndicadorClase_RangoFinal{get;set;}	
	public bool IndicadorClase_Activo{get;set;}	
	public string IndicadorRubro_Nombre{get;set;}	
	public bool IndicadorRubro_Activo{get;set;}	
					
		public virtual IndicadorRelacionRubro ToEntity()
		{
		   IndicadorRelacionRubro _IndicadorRelacionRubro = new IndicadorRelacionRubro();
		_IndicadorRelacionRubro.IdIndicadorRelacionRubro = this.IdIndicadorRelacionRubro;
		 _IndicadorRelacionRubro.IdIndicadorClase = this.IdIndicadorClase;
		 _IndicadorRelacionRubro.IdIndicadorRubro = this.IdIndicadorRubro;
		 
		  return _IndicadorRelacionRubro;
		}		
		public virtual void Set(IndicadorRelacionRubro entity)
		{		   
		 this.IdIndicadorRelacionRubro= entity.IdIndicadorRelacionRubro ;
		  this.IdIndicadorClase= entity.IdIndicadorClase ;
		  this.IdIndicadorRubro= entity.IdIndicadorRubro ;
		 		  
		}		
		public virtual bool Equals(IndicadorRelacionRubro entity)
        {
		   if(entity == null)return false;
         if(!entity.IdIndicadorRelacionRubro.Equals(this.IdIndicadorRelacionRubro))return false;
		  if(!entity.IdIndicadorClase.Equals(this.IdIndicadorClase))return false;
		  if(!entity.IdIndicadorRubro.Equals(this.IdIndicadorRubro))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("IndicadorRelacionRubro", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("IndicadorClase","IndicadorClase_Nombre")
			,new DataColumnMapping("IndicadorRubro","IndicadorRubro_Nombre")
			}));
		}
	}
}
		
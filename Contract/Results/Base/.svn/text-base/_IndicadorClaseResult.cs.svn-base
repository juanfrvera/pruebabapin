using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _IndicadorClaseResult : IResult<int>
    {        
		public virtual int ID{get{return IdIndicadorClase;}}
		 public int IdIndicadorClase{get;set;}
		 public int IdIndicadorTipo{get;set;}
		 public string Sigla{get;set;}
		 public string Nombre{get;set;}
		 public int IdUnidad{get;set;}
		 public int? RangoInicial{get;set;}
		 public int? RangoFinal{get;set;}
		 public bool Activo{get;set;}
		 
		 public string IndicadorTipo_Nombre{get;set;}	
	public bool IndicadorTipo_Activo{get;set;}	
	public string Unidad_Sigla{get;set;}	
	public string Unidad_Nombre{get;set;}	
	public bool Unidad_Activo{get;set;}	
					
		public virtual IndicadorClase ToEntity()
		{
		   IndicadorClase _IndicadorClase = new IndicadorClase();
		_IndicadorClase.IdIndicadorClase = this.IdIndicadorClase;
		 _IndicadorClase.IdIndicadorTipo = this.IdIndicadorTipo;
		 _IndicadorClase.Sigla = this.Sigla;
		 _IndicadorClase.Nombre = this.Nombre;
		 _IndicadorClase.IdUnidad = this.IdUnidad;
		 _IndicadorClase.RangoInicial = this.RangoInicial;
		 _IndicadorClase.RangoFinal = this.RangoFinal;
		 _IndicadorClase.Activo = this.Activo;
		 
		  return _IndicadorClase;
		}		
		public virtual void Set(IndicadorClase entity)
		{		   
		 this.IdIndicadorClase= entity.IdIndicadorClase ;
		  this.IdIndicadorTipo= entity.IdIndicadorTipo ;
		  this.Sigla= entity.Sigla ;
		  this.Nombre= entity.Nombre ;
		  this.IdUnidad= entity.IdUnidad ;
		  this.RangoInicial= entity.RangoInicial ;
		  this.RangoFinal= entity.RangoFinal ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(IndicadorClase entity)
        {
		   if(entity == null)return false;
         if(!entity.IdIndicadorClase.Equals(this.IdIndicadorClase))return false;
		  if(!entity.IdIndicadorTipo.Equals(this.IdIndicadorTipo))return false;
		  if(!entity.Sigla.Equals(this.Sigla))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.IdUnidad.Equals(this.IdUnidad))return false;
		  if((entity.RangoInicial == null)?this.RangoInicial!=null:!entity.RangoInicial.Equals(this.RangoInicial))return false;
			 if((entity.RangoFinal == null)?this.RangoFinal!=null:!entity.RangoFinal.Equals(this.RangoFinal))return false;
			 if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("IndicadorClase", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("IndicadorTipo","IndicadorTipo_Nombre")
			,new DataColumnMapping("Sigla","Sigla")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Unidad","UnidadMedida_Nombre")
			,new DataColumnMapping("RangoInicial","RangoInicial")
			,new DataColumnMapping("RangoFinal","RangoFinal")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		
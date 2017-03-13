using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _IndicadorMedioVerificacionResult : IResult<int>
    {        
		public virtual int ID{get{return IdIndicadorMedioVerificacion;}}
		 public int IdIndicadorMedioVerificacion{get;set;}
		 public int IdIndicador{get;set;}
		 public int IdMedioVerificacion{get;set;}
		 
		 public int Indicador_IdIndicadorTipo{get;set;}	
	public string Indicador_Sigla{get;set;}	
	public string Indicador_Nombre{get;set;}	
	public int Indicador_IdUnidad{get;set;}	
	public int? Indicador_RangoInicial{get;set;}	
	public int? Indicador_RangoFinal{get;set;}	
	public bool Indicador_Activo{get;set;}	
	public string MedioVerificacion_Sigla{get;set;}	
	public string MedioVerificacion_Nombre{get;set;}	
					
		public virtual IndicadorMedioVerificacion ToEntity()
		{
		   IndicadorMedioVerificacion _IndicadorMedioVerificacion = new IndicadorMedioVerificacion();
		_IndicadorMedioVerificacion.IdIndicadorMedioVerificacion = this.IdIndicadorMedioVerificacion;
		 _IndicadorMedioVerificacion.IdIndicador = this.IdIndicador;
		 _IndicadorMedioVerificacion.IdMedioVerificacion = this.IdMedioVerificacion;
		 
		  return _IndicadorMedioVerificacion;
		}		
		public virtual void Set(IndicadorMedioVerificacion entity)
		{		   
		 this.IdIndicadorMedioVerificacion= entity.IdIndicadorMedioVerificacion ;
		  this.IdIndicador= entity.IdIndicador ;
		  this.IdMedioVerificacion= entity.IdMedioVerificacion ;
		 		  
		}		
		public virtual bool Equals(IndicadorMedioVerificacion entity)
        {
		   if(entity == null)return false;
         if(!entity.IdIndicadorMedioVerificacion.Equals(this.IdIndicadorMedioVerificacion))return false;
		  if(!entity.IdIndicador.Equals(this.IdIndicador))return false;
		  if(!entity.IdMedioVerificacion.Equals(this.IdMedioVerificacion))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("IndicadorMedioVerificacion", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Indicador","IndicadorClase_Nombre")
			,new DataColumnMapping("MedioVerificacion","MedioVerificacion_Nombre")
			}));
		}
	}
}
		
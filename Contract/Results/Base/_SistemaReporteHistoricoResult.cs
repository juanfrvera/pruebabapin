using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _SistemaReporteHistoricoResult : IResult<int>
    {        
		public virtual int ID{get{return IdSistemaReporteHistorico;}}
		 public int IdSistemaReporteHistorico{get;set;}
		 public int IdSistemaReporte{get;set;}
		 public string EntityId{get;set;}
		 public string FilterData{get;set;}
		 public DateTime Fecha{get;set;}
		 public int IdUsuario{get;set;}
		 public string Comentarios{get;set;}
		 public string Data{get;set;}
		 
		 public string SistemaReporte_Nombre{get;set;}	
	public string SistemaReporte_Codigo{get;set;}	
	public string SistemaReporte_Descripcion{get;set;}	
	public int SistemaReporte_IdSistemaEntidad{get;set;}	
	public bool SistemaReporte_Activo{get;set;}	
	public bool SistemaReporte_EsListado{get;set;}	
	public string SistemaReporte_FileName{get;set;}	
	public string Usuario_NombreUsuario{get;set;}	
	public string Usuario_Clave{get;set;}	
	public bool Usuario_Activo{get;set;}	
	public bool Usuario_EsSectioralista{get;set;}	
	public int Usuario_IdLanguage{get;set;}	
	public bool Usuario_AccesoTotal{get;set;}	
					
		public virtual SistemaReporteHistorico ToEntity()
		{
		   SistemaReporteHistorico _SistemaReporteHistorico = new SistemaReporteHistorico();
		_SistemaReporteHistorico.IdSistemaReporteHistorico = this.IdSistemaReporteHistorico;
		 _SistemaReporteHistorico.IdSistemaReporte = this.IdSistemaReporte;
		 _SistemaReporteHistorico.EntityId = this.EntityId;
		 _SistemaReporteHistorico.FilterData = this.FilterData;
		 _SistemaReporteHistorico.Fecha = this.Fecha;
		 _SistemaReporteHistorico.IdUsuario = this.IdUsuario;
		 _SistemaReporteHistorico.Comentarios = this.Comentarios;
		 _SistemaReporteHistorico.Data = this.Data;
		 
		  return _SistemaReporteHistorico;
		}		
		public virtual void Set(SistemaReporteHistorico entity)
		{		   
		 this.IdSistemaReporteHistorico= entity.IdSistemaReporteHistorico ;
		  this.IdSistemaReporte= entity.IdSistemaReporte ;
		  this.EntityId= entity.EntityId ;
		  this.FilterData= entity.FilterData ;
		  this.Fecha= entity.Fecha ;
		  this.IdUsuario= entity.IdUsuario ;
		  this.Comentarios= entity.Comentarios ;
		  this.Data= entity.Data ;
		 		  
		}		
		public virtual bool Equals(SistemaReporteHistorico entity)
        {
		   if(entity == null)return false;
         if(!entity.IdSistemaReporteHistorico.Equals(this.IdSistemaReporteHistorico))return false;
		  if(!entity.IdSistemaReporte.Equals(this.IdSistemaReporte))return false;
		  if((entity.EntityId == null)?this.EntityId!=null:!entity.EntityId.Equals(this.EntityId))return false;
			 if((entity.FilterData == null)?this.FilterData!=null:!entity.FilterData.Equals(this.FilterData))return false;
			 if(!entity.Fecha.Equals(this.Fecha))return false;
		  if(!entity.IdUsuario.Equals(this.IdUsuario))return false;
		  if((entity.Comentarios == null)?this.Comentarios!=null:!entity.Comentarios.Equals(this.Comentarios))return false;
			 if((entity.Data == null)?this.Data!=null:!entity.Data.Equals(this.Data))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("SistemaReporteHistorico", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("SistemaReporte","SistemaReporte_Nombre")
			,new DataColumnMapping("Entity","EntityId")
			,new DataColumnMapping("FilterData","FilterData")
			,new DataColumnMapping("Fecha","Fecha","{0:dd/MM/yyyy}")
			,new DataColumnMapping("Usuario","Usuario_NombreUsuario")
			,new DataColumnMapping("Comentarios","Comentarios")
			,new DataColumnMapping("Data","Data")
			}));
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _TransferenciaResult : IResult<int>
    {        
		public virtual int ID{get{return IdTransferencia;}}
		 public int IdTransferencia{get;set;}
		 public int IdSubPrograma{get;set;}
		 public int Proyecto{get;set;}
		 public int Actividad{get;set;}
		 public int Obra{get;set;}
		 public string Denominacion{get;set;}
		 public int IdClasificacionGasto{get;set;}
		 public int IdClasificacionGeografica{get;set;}
		 public bool Activo{get;set;}
		 
		 public string ClasificacionGasto_Codigo{get;set;}	
	public string ClasificacionGasto_Nombre{get;set;}	
	public int ClasificacionGasto_IdClasificacionGastoTipo{get;set;}	
	public int? ClasificacionGasto_IdCaracterEconomico{get;set;}	
	public bool ClasificacionGasto_Activo{get;set;}	
	public int? ClasificacionGasto_IdClasificacionGastoPadre{get;set;}	
	public string ClasificacionGasto_BreadcrumbId{get;set;}	
	public string ClasificacionGasto_BreadcrumbOrden{get;set;}	
	public int? ClasificacionGasto_Nivel{get;set;}	
	public int? ClasificacionGasto_Orden{get;set;}	
	public string ClasificacionGasto_Descripcion{get;set;}	
	public string ClasificacionGasto_DescripcionInvertida{get;set;}	
	public int ClasificacionGasto_IdClasificacionGastoRubro{get;set;}	
	public bool ClasificacionGasto_Seleccionable{get;set;}	
	public string ClasificacionGasto_BreadcrumbCode{get;set;}	
	public string ClasificacionGasto_DescripcionCodigo{get;set;}	
	public string ClasificacionGeografica_Codigo{get;set;}	
	public string ClasificacionGeografica_Nombre{get;set;}	
	public int ClasificacionGeografica_IdClasificacionGeograficaTipo{get;set;}	
	public int? ClasificacionGeografica_IdClasificacionGeograficaPadre{get;set;}	
	public bool ClasificacionGeografica_Activo{get;set;}	
	public string ClasificacionGeografica_Descripcion{get;set;}	
	public string ClasificacionGeografica_BreadcrumbId{get;set;}	
	public string ClasificacionGeografica_BreadcrumOrden{get;set;}	
	public int? ClasificacionGeografica_Orden{get;set;}	
	public int? ClasificacionGeografica_Nivel{get;set;}	
	public string ClasificacionGeografica_DescripcionInvertida{get;set;}	
	public bool ClasificacionGeografica_Seleccionable{get;set;}	
	public string ClasificacionGeografica_BreadcrumbCode{get;set;}	
	public string ClasificacionGeografica_DescripcionCodigo{get;set;}	
	public int SubPrograma_IdPrograma{get;set;}	
	public string SubPrograma_Codigo{get;set;}	
	public string SubPrograma_Nombre{get;set;}	
	public DateTime SubPrograma_FechaAlta{get;set;}	
	public DateTime? SubPrograma_FechaBaja{get;set;}	
	public bool SubPrograma_Activo{get;set;}	
					
		public virtual Transferencia ToEntity()
		{
		   Transferencia _Transferencia = new Transferencia();
		_Transferencia.IdTransferencia = this.IdTransferencia;
		 _Transferencia.IdSubPrograma = this.IdSubPrograma;
		 _Transferencia.Proyecto = this.Proyecto;
		 _Transferencia.Actividad = this.Actividad;
		 _Transferencia.Obra = this.Obra;
		 _Transferencia.Denominacion = this.Denominacion;
		 _Transferencia.IdClasificacionGasto = this.IdClasificacionGasto;
		 _Transferencia.IdClasificacionGeografica = this.IdClasificacionGeografica;
		 _Transferencia.Activo = this.Activo;
		 
		  return _Transferencia;
		}		
		public virtual void Set(Transferencia entity)
		{		   
		 this.IdTransferencia= entity.IdTransferencia ;
		  this.IdSubPrograma= entity.IdSubPrograma ;
		  this.Proyecto= entity.Proyecto ;
		  this.Actividad= entity.Actividad ;
		  this.Obra= entity.Obra ;
		  this.Denominacion= entity.Denominacion ;
		  this.IdClasificacionGasto= entity.IdClasificacionGasto ;
		  this.IdClasificacionGeografica= entity.IdClasificacionGeografica ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(Transferencia entity)
        {
		   if(entity == null)return false;
         if(!entity.IdTransferencia.Equals(this.IdTransferencia))return false;
		  if(!entity.IdSubPrograma.Equals(this.IdSubPrograma))return false;
		  if(!entity.Proyecto.Equals(this.Proyecto))return false;
		  if(!entity.Actividad.Equals(this.Actividad))return false;
		  if(!entity.Obra.Equals(this.Obra))return false;
		  if(!entity.Denominacion.Equals(this.Denominacion))return false;
		  if(!entity.IdClasificacionGasto.Equals(this.IdClasificacionGasto))return false;
		  if(!entity.IdClasificacionGeografica.Equals(this.IdClasificacionGeografica))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Transferencia", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("SubPrograma","SubPrograma_Nombre")
			,new DataColumnMapping("Proyecto","Proyecto")
			,new DataColumnMapping("Actividad","Actividad")
			,new DataColumnMapping("Obra","Obra")
			,new DataColumnMapping("Denominacion","Denominacion")
			,new DataColumnMapping("ClasificacionGasto","ClasificacionGasto_Nombre")
			,new DataColumnMapping("ClasificacionGeografica","ClasificacionGeografica_Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		
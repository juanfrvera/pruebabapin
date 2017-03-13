using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _TransferenciaDetalleResult : IResult<int>
    {        
		public virtual int ID{get{return IdTransferenciaDetalle;}}
		 public int IdTransferenciaDetalle{get;set;}
		 public int IdTransferencia{get;set;}
		 public int IdFuenteFinanciamiento{get;set;}
		 public int IdMoneda{get;set;}
		 public int IdFinalidadFuncion{get;set;}
		 public int IdClasificacionGeografica{get;set;}
		 public decimal Inicial{get;set;}
		 public decimal Vigente{get;set;}
		 public decimal Comprometido{get;set;}
		 public decimal Devengado{get;set;}
		 public decimal Pagado{get;set;}
		 
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
	public string FinalidadFuncion_Codigo{get;set;}	
	public string FinalidadFuncion_Denominacion{get;set;}	
	public bool FinalidadFuncion_Activo{get;set;}	
	public int? FinalidadFuncion_IdFinalidadFunciontipo{get;set;}	
	public int? FinalidadFuncion_IdFinalidadFuncionPadre{get;set;}	
	public string FinalidadFuncion_BreadcrumbId{get;set;}	
	public string FinalidadFuncion_BreadcrumbOrden{get;set;}	
	public int? FinalidadFuncion_Nivel{get;set;}	
	public int? FinalidadFuncion_Orden{get;set;}	
	public string FinalidadFuncion_Descripcion{get;set;}	
	public string FinalidadFuncion_DescripcionInvertida{get;set;}	
	public bool FinalidadFuncion_Seleccionable{get;set;}	
	public string FinalidadFuncion_BreadcrumbCode{get;set;}	
	public string FinalidadFuncion_DescripcionCodigo{get;set;}	
	public string FuenteFinanciamiento_Codigo{get;set;}	
	public string FuenteFinanciamiento_Nombre{get;set;}	
	public int FuenteFinanciamiento_IdFuenteFinanciamientoTipo{get;set;}	
	public bool FuenteFinanciamiento_Activo{get;set;}	
	public int? FuenteFinanciamiento_IdFuenteFinanciamientoPadre{get;set;}	
	public string FuenteFinanciamiento_BreadcrumbId{get;set;}	
	public string FuenteFinanciamiento_BreadcrumbOrden{get;set;}	
	public int? FuenteFinanciamiento_Nivel{get;set;}	
	public int? FuenteFinanciamiento_Orden{get;set;}	
	public string FuenteFinanciamiento_Descripcion{get;set;}	
	public string FuenteFinanciamiento_DescripcionInvertida{get;set;}	
	public bool FuenteFinanciamiento_Seleccionable{get;set;}	
	public string FuenteFinanciamiento_BreadcrumbCode{get;set;}	
	public string FuenteFinanciamiento_DescripcionCodigo{get;set;}	
	public string Moneda_Sigla{get;set;}	
	public string Moneda_Nombre{get;set;}	
	public bool Moneda_Activo{get;set;}	
	public bool Moneda_Base{get;set;}	
	public int Transferencia_IdSubPrograma{get;set;}	
	public int Transferencia_Proyecto{get;set;}	
	public int Transferencia_Actividad{get;set;}	
	public int Transferencia_Obra{get;set;}	
	public string Transferencia_Denominacion{get;set;}	
	public int Transferencia_IdClasificacionGasto{get;set;}	
	public bool Transferencia_Activo{get;set;}	
					
		public virtual TransferenciaDetalle ToEntity()
		{
		   TransferenciaDetalle _TransferenciaDetalle = new TransferenciaDetalle();
		_TransferenciaDetalle.IdTransferenciaDetalle = this.IdTransferenciaDetalle;
		 _TransferenciaDetalle.IdTransferencia = this.IdTransferencia;
		 _TransferenciaDetalle.IdFuenteFinanciamiento = this.IdFuenteFinanciamiento;
		 _TransferenciaDetalle.IdMoneda = this.IdMoneda;
		 _TransferenciaDetalle.IdFinalidadFuncion = this.IdFinalidadFuncion;
		 _TransferenciaDetalle.IdClasificacionGeografica = this.IdClasificacionGeografica;
		 _TransferenciaDetalle.Inicial = this.Inicial;
		 _TransferenciaDetalle.Vigente = this.Vigente;
		 _TransferenciaDetalle.Comprometido = this.Comprometido;
		 _TransferenciaDetalle.Devengado = this.Devengado;
		 _TransferenciaDetalle.Pagado = this.Pagado;
		 
		  return _TransferenciaDetalle;
		}		
		public virtual void Set(TransferenciaDetalle entity)
		{		   
		 this.IdTransferenciaDetalle= entity.IdTransferenciaDetalle ;
		  this.IdTransferencia= entity.IdTransferencia ;
		  this.IdFuenteFinanciamiento= entity.IdFuenteFinanciamiento ;
		  this.IdMoneda= entity.IdMoneda ;
		  this.IdFinalidadFuncion= entity.IdFinalidadFuncion ;
		  this.IdClasificacionGeografica= entity.IdClasificacionGeografica ;
		  this.Inicial= entity.Inicial ;
		  this.Vigente= entity.Vigente ;
		  this.Comprometido= entity.Comprometido ;
		  this.Devengado= entity.Devengado ;
		  this.Pagado= entity.Pagado ;
		 		  
		}		
		public virtual bool Equals(TransferenciaDetalle entity)
        {
		   if(entity == null)return false;
         if(!entity.IdTransferenciaDetalle.Equals(this.IdTransferenciaDetalle))return false;
		  if(!entity.IdTransferencia.Equals(this.IdTransferencia))return false;
		  if(!entity.IdFuenteFinanciamiento.Equals(this.IdFuenteFinanciamiento))return false;
		  if(!entity.IdMoneda.Equals(this.IdMoneda))return false;
		  if(!entity.IdFinalidadFuncion.Equals(this.IdFinalidadFuncion))return false;
		  if(!entity.IdClasificacionGeografica.Equals(this.IdClasificacionGeografica))return false;
		  if(!entity.Inicial.Equals(this.Inicial))return false;
		  if(!entity.Vigente.Equals(this.Vigente))return false;
		  if(!entity.Comprometido.Equals(this.Comprometido))return false;
		  if(!entity.Devengado.Equals(this.Devengado))return false;
		  if(!entity.Pagado.Equals(this.Pagado))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("TransferenciaDetalle", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Transferencia","Transferencia_Denominacion")
			,new DataColumnMapping("FuenteFinanciamiento","FuenteFinanciamiento_Nombre")
			,new DataColumnMapping("Moneda","Moneda_Nombre")
			,new DataColumnMapping("FinalidadFuncion","FinalidadFuncion_Descripcion")
			,new DataColumnMapping("ClasificacionGeografica","ClasificacionGeografica_Nombre")
			,new DataColumnMapping("Inicial","Inicial")
			,new DataColumnMapping("Vigente","Vigente")
			,new DataColumnMapping("Comprometido","Comprometido")
			,new DataColumnMapping("Devengado","Devengado")
			,new DataColumnMapping("Pagado","Pagado")
			}));
		}
	}
}
		
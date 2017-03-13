using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _IndicadorEvolucionResult : IResult<int>
    {        
		public virtual int ID{get{return IdIndicadorEvolucion;}}
		 public int IdIndicadorEvolucion{get;set;}
		 public int IdIndicador{get;set;}
		 public int IdClasificacionGeografica{get;set;}
		 public int IdIndicadorEvolucionInstancia{get;set;}
		 public DateTime? FechaEstimada{get;set;}
		 public decimal? CantidadEstimada{get;set;}
		 public decimal? PrecioUnitarioEstimado{get;set;}
		 public DateTime? FechaReal{get;set;}
		 public decimal? CantidadReal{get;set;}
		 public decimal? PrecioUnitarioReal{get;set;}
		 public string CertificadoNumero{get;set;}
		 public DateTime? CertificadoFechaPago{get;set;}
		 public DateTime? CertificadoFechaVencimiento{get;set;}
		 public int? IdCertificadoEstado{get;set;}
		 public decimal? CantidadAcumuladaEstimada{get;set;}
		 public decimal? CantidadAcumuladaRealizada{get;set;}
		 public decimal? MontoEstimado{get;set;}
		 public decimal? MontoRealizado{get;set;}
		 public string Observacion{get;set;}
		 public decimal? Cotizacion{get;set;}
		 public string NumeroDesembolso{get;set;}
		 public string NroExpediente{get;set;}
		 
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
	public string CertificadoEstado_Nombre{get;set;}	
	public string CertificadoEstado_Codigo{get;set;}	
	public int? CertificadoEstado_Orden{get;set;}	
	public string CertificadoEstado_Descripcion{get;set;}	
	public bool? CertificadoEstado_Activo{get;set;}	
	public int? Indicador_IdMedioVerificacion{get;set;}	
	public string Indicador_Observacion{get;set;}	
	public string IndicadorEvolucionInstancia_Nombre{get;set;}	
	public int? IndicadorEvolucionInstancia_Orden{get;set;}	
					
		public virtual IndicadorEvolucion ToEntity()
		{
		   IndicadorEvolucion _IndicadorEvolucion = new IndicadorEvolucion();
		_IndicadorEvolucion.IdIndicadorEvolucion = this.IdIndicadorEvolucion;
		 _IndicadorEvolucion.IdIndicador = this.IdIndicador;
		 _IndicadorEvolucion.IdClasificacionGeografica = this.IdClasificacionGeografica;
		 _IndicadorEvolucion.IdIndicadorEvolucionInstancia = this.IdIndicadorEvolucionInstancia;
		 _IndicadorEvolucion.FechaEstimada = this.FechaEstimada;
		 _IndicadorEvolucion.CantidadEstimada = this.CantidadEstimada;
		 _IndicadorEvolucion.PrecioUnitarioEstimado = this.PrecioUnitarioEstimado;
		 _IndicadorEvolucion.FechaReal = this.FechaReal;
		 _IndicadorEvolucion.CantidadReal = this.CantidadReal;
		 _IndicadorEvolucion.PrecioUnitarioReal = this.PrecioUnitarioReal;
		 _IndicadorEvolucion.CertificadoNumero = this.CertificadoNumero;
		 _IndicadorEvolucion.CertificadoFechaPago = this.CertificadoFechaPago;
		 _IndicadorEvolucion.CertificadoFechaVencimiento = this.CertificadoFechaVencimiento;
		 _IndicadorEvolucion.IdCertificadoEstado = this.IdCertificadoEstado;
		 _IndicadorEvolucion.CantidadAcumuladaEstimada = this.CantidadAcumuladaEstimada;
		 _IndicadorEvolucion.CantidadAcumuladaRealizada = this.CantidadAcumuladaRealizada;
		 _IndicadorEvolucion.MontoEstimado = this.MontoEstimado;
		 _IndicadorEvolucion.MontoRealizado = this.MontoRealizado;
		 _IndicadorEvolucion.Observacion = this.Observacion;
		 _IndicadorEvolucion.Cotizacion = this.Cotizacion;
		 _IndicadorEvolucion.NumeroDesembolso = this.NumeroDesembolso;
		 _IndicadorEvolucion.NroExpediente = this.NroExpediente;
		 
		  return _IndicadorEvolucion;
		}		
		public virtual void Set(IndicadorEvolucion entity)
		{		   
		 this.IdIndicadorEvolucion= entity.IdIndicadorEvolucion ;
		  this.IdIndicador= entity.IdIndicador ;
		  this.IdClasificacionGeografica= entity.IdClasificacionGeografica ;
		  this.IdIndicadorEvolucionInstancia= entity.IdIndicadorEvolucionInstancia ;
		  this.FechaEstimada= entity.FechaEstimada ;
		  this.CantidadEstimada= entity.CantidadEstimada ;
		  this.PrecioUnitarioEstimado= entity.PrecioUnitarioEstimado ;
		  this.FechaReal= entity.FechaReal ;
		  this.CantidadReal= entity.CantidadReal ;
		  this.PrecioUnitarioReal= entity.PrecioUnitarioReal ;
		  this.CertificadoNumero= entity.CertificadoNumero ;
		  this.CertificadoFechaPago= entity.CertificadoFechaPago ;
		  this.CertificadoFechaVencimiento= entity.CertificadoFechaVencimiento ;
		  this.IdCertificadoEstado= entity.IdCertificadoEstado ;
		  this.CantidadAcumuladaEstimada= entity.CantidadAcumuladaEstimada ;
		  this.CantidadAcumuladaRealizada= entity.CantidadAcumuladaRealizada ;
		  this.MontoEstimado= entity.MontoEstimado ;
		  this.MontoRealizado= entity.MontoRealizado ;
		  this.Observacion= entity.Observacion ;
		  this.Cotizacion= entity.Cotizacion ;
		  this.NumeroDesembolso= entity.NumeroDesembolso ;
		  this.NroExpediente= entity.NroExpediente ;
		 		  
		}		
		public virtual bool Equals(IndicadorEvolucion entity)
        {
		   if(entity == null)return false;
         if(!entity.IdIndicadorEvolucion.Equals(this.IdIndicadorEvolucion))return false;
		  if(!entity.IdIndicador.Equals(this.IdIndicador))return false;
		  if(!entity.IdClasificacionGeografica.Equals(this.IdClasificacionGeografica))return false;
		  if(!entity.IdIndicadorEvolucionInstancia.Equals(this.IdIndicadorEvolucionInstancia))return false;
		  if((entity.FechaEstimada == null)?this.FechaEstimada!=null:!entity.FechaEstimada.Equals(this.FechaEstimada))return false;
			 if((entity.CantidadEstimada == null)?this.CantidadEstimada!=null:!entity.CantidadEstimada.Equals(this.CantidadEstimada))return false;
			 if((entity.PrecioUnitarioEstimado == null)?this.PrecioUnitarioEstimado!=null:!entity.PrecioUnitarioEstimado.Equals(this.PrecioUnitarioEstimado))return false;
			 if((entity.FechaReal == null)?this.FechaReal!=null:!entity.FechaReal.Equals(this.FechaReal))return false;
			 if((entity.CantidadReal == null)?this.CantidadReal!=null:!entity.CantidadReal.Equals(this.CantidadReal))return false;
			 if((entity.PrecioUnitarioReal == null)?this.PrecioUnitarioReal!=null:!entity.PrecioUnitarioReal.Equals(this.PrecioUnitarioReal))return false;
			 if((entity.CertificadoNumero == null)?this.CertificadoNumero!=null:!entity.CertificadoNumero.Equals(this.CertificadoNumero))return false;
			 if((entity.CertificadoFechaPago == null)?this.CertificadoFechaPago!=null:!entity.CertificadoFechaPago.Equals(this.CertificadoFechaPago))return false;
			 if((entity.CertificadoFechaVencimiento == null)?this.CertificadoFechaVencimiento!=null:!entity.CertificadoFechaVencimiento.Equals(this.CertificadoFechaVencimiento))return false;
			 if((entity.IdCertificadoEstado == null)?(this.IdCertificadoEstado.HasValue && this.IdCertificadoEstado.Value > 0):!entity.IdCertificadoEstado.Equals(this.IdCertificadoEstado))return false;
						  if((entity.CantidadAcumuladaEstimada == null)?this.CantidadAcumuladaEstimada!=null:!entity.CantidadAcumuladaEstimada.Equals(this.CantidadAcumuladaEstimada))return false;
			 if((entity.CantidadAcumuladaRealizada == null)?this.CantidadAcumuladaRealizada!=null:!entity.CantidadAcumuladaRealizada.Equals(this.CantidadAcumuladaRealizada))return false;
			 if((entity.MontoEstimado == null)?this.MontoEstimado!=null:!entity.MontoEstimado.Equals(this.MontoEstimado))return false;
			 if((entity.MontoRealizado == null)?this.MontoRealizado!=null:!entity.MontoRealizado.Equals(this.MontoRealizado))return false;
			 if((entity.Observacion == null)?this.Observacion!=null:!entity.Observacion.Equals(this.Observacion))return false;
			 if((entity.Cotizacion == null)?this.Cotizacion!=null:!entity.Cotizacion.Equals(this.Cotizacion))return false;
			 if((entity.NumeroDesembolso == null)?this.NumeroDesembolso!=null:!entity.NumeroDesembolso.Equals(this.NumeroDesembolso))return false;
			 if((entity.NroExpediente == null)?this.NroExpediente!=null:!entity.NroExpediente.Equals(this.NroExpediente))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("IndicadorEvolucion", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Indicador","Indicador_Observacion")
			,new DataColumnMapping("ClasificacionGeografica","ClasificacionGeografica_Nombre")
			,new DataColumnMapping("IndicadorEvolucionInstancia","IndicadorEvolucionInstancia_Nombre")
			,new DataColumnMapping("FechaEstimada","FechaEstimada","{0:dd/MM/yyyy}")
			,new DataColumnMapping("CantidadEstimada","CantidadEstimada")
			,new DataColumnMapping("PrecioUnitarioEstimado","PrecioUnitarioEstimado")
			,new DataColumnMapping("FechaReal","FechaReal","{0:dd/MM/yyyy}")
			,new DataColumnMapping("CantidadReal","CantidadReal")
			,new DataColumnMapping("PrecioUnitarioReal","PrecioUnitarioReal")
			,new DataColumnMapping("CertificadoNumero","CertificadoNumero")
			,new DataColumnMapping("CertificadoFechaPago","CertificadoFechaPago","{0:dd/MM/yyyy}")
			,new DataColumnMapping("CertificadoFechaVencimiento","CertificadoFechaVencimiento","{0:dd/MM/yyyy}")
			,new DataColumnMapping("CertificadoEstado","Estado_Nombre")
			,new DataColumnMapping("CantidadAcumuladaEstimada","CantidadAcumuladaEstimada")
			,new DataColumnMapping("CantidadAcumuladaRealizada","CantidadAcumuladaRealizada")
			,new DataColumnMapping("MontoEstimado","MontoEstimado")
			,new DataColumnMapping("MontoRealizado","MontoRealizado")
			,new DataColumnMapping("Observacion","Observacion")
			,new DataColumnMapping("Cotizacion","Cotizacion")
			,new DataColumnMapping("NumeroDesembolso","NumeroDesembolso")
			,new DataColumnMapping("NroExpediente","NroExpediente")
			}));
		}
	}
}
		
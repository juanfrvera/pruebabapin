using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc=Contract;
using nd=DataAccess;

namespace DataAccess.Base
{
    public abstract class _IndicadorEvolucionData : EntityData<IndicadorEvolucion,IndicadorEvolucionFilter,IndicadorEvolucionResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.IndicadorEvolucion entity)
		{			
			return entity.IdIndicadorEvolucion;
		}		
		public override IndicadorEvolucion GetByEntity(IndicadorEvolucion entity)
        {
            return this.GetById(entity.IdIndicadorEvolucion);
        }
        public override IndicadorEvolucion GetById(int id)
        {
            return (from o in this.Table where o.IdIndicadorEvolucion == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<IndicadorEvolucion> Query(IndicadorEvolucionFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdIndicadorEvolucion == null || o.IdIndicadorEvolucion >=  filter.IdIndicadorEvolucion) && (filter.IdIndicadorEvolucion_To == null || o.IdIndicadorEvolucion <= filter.IdIndicadorEvolucion_To)
					  && (filter.IdIndicador == null || filter.IdIndicador == 0 || o.IdIndicador==filter.IdIndicador)
					  && (filter.IdClasificacionGeografica == null || filter.IdClasificacionGeografica == 0 || o.IdClasificacionGeografica==filter.IdClasificacionGeografica)
					  && (filter.IdIndicadorEvolucionInstancia == null || filter.IdIndicadorEvolucionInstancia == 0 || o.IdIndicadorEvolucionInstancia==filter.IdIndicadorEvolucionInstancia)
					  && (filter.FechaEstimada == null || filter.FechaEstimada == DateTime.MinValue || o.FechaEstimada >=  filter.FechaEstimada) && (filter.FechaEstimada_To == null || filter.FechaEstimada_To == DateTime.MinValue || o.FechaEstimada <= filter.FechaEstimada_To)
					  && (filter.FechaEstimadaIsNull == null || filter.FechaEstimadaIsNull == true || o.FechaEstimada != null ) && (filter.FechaEstimadaIsNull == null || filter.FechaEstimadaIsNull == false || o.FechaEstimada == null)
					  && (filter.CantidadEstimada == null || o.CantidadEstimada >=  filter.CantidadEstimada) && (filter.CantidadEstimada_To == null || o.CantidadEstimada <= filter.CantidadEstimada_To)
					  && (filter.CantidadEstimadaIsNull == null || filter.CantidadEstimadaIsNull == true || o.CantidadEstimada != null ) && (filter.CantidadEstimadaIsNull == null || filter.CantidadEstimadaIsNull == false || o.CantidadEstimada == null)
					  && (filter.PrecioUnitarioEstimado == null || o.PrecioUnitarioEstimado >=  filter.PrecioUnitarioEstimado) && (filter.PrecioUnitarioEstimado_To == null || o.PrecioUnitarioEstimado <= filter.PrecioUnitarioEstimado_To)
					  && (filter.PrecioUnitarioEstimadoIsNull == null || filter.PrecioUnitarioEstimadoIsNull == true || o.PrecioUnitarioEstimado != null ) && (filter.PrecioUnitarioEstimadoIsNull == null || filter.PrecioUnitarioEstimadoIsNull == false || o.PrecioUnitarioEstimado == null)
					  && (filter.FechaReal == null || filter.FechaReal == DateTime.MinValue || o.FechaReal >=  filter.FechaReal) && (filter.FechaReal_To == null || filter.FechaReal_To == DateTime.MinValue || o.FechaReal <= filter.FechaReal_To)
					  && (filter.FechaRealIsNull == null || filter.FechaRealIsNull == true || o.FechaReal != null ) && (filter.FechaRealIsNull == null || filter.FechaRealIsNull == false || o.FechaReal == null)
					  && (filter.CantidadReal == null || o.CantidadReal >=  filter.CantidadReal) && (filter.CantidadReal_To == null || o.CantidadReal <= filter.CantidadReal_To)
					  && (filter.CantidadRealIsNull == null || filter.CantidadRealIsNull == true || o.CantidadReal != null ) && (filter.CantidadRealIsNull == null || filter.CantidadRealIsNull == false || o.CantidadReal == null)
					  && (filter.PrecioUnitarioReal == null || o.PrecioUnitarioReal >=  filter.PrecioUnitarioReal) && (filter.PrecioUnitarioReal_To == null || o.PrecioUnitarioReal <= filter.PrecioUnitarioReal_To)
					  && (filter.PrecioUnitarioRealIsNull == null || filter.PrecioUnitarioRealIsNull == true || o.PrecioUnitarioReal != null ) && (filter.PrecioUnitarioRealIsNull == null || filter.PrecioUnitarioRealIsNull == false || o.PrecioUnitarioReal == null)
					  && (filter.CertificadoNumero == null || filter.CertificadoNumero.Trim() == string.Empty || filter.CertificadoNumero.Trim() == "%"  || (filter.CertificadoNumero.EndsWith("%") && filter.CertificadoNumero.StartsWith("%") && (o.CertificadoNumero.Contains(filter.CertificadoNumero.Replace("%", "")))) || (filter.CertificadoNumero.EndsWith("%") && o.CertificadoNumero.StartsWith(filter.CertificadoNumero.Replace("%",""))) || (filter.CertificadoNumero.StartsWith("%") && o.CertificadoNumero.EndsWith(filter.CertificadoNumero.Replace("%",""))) || o.CertificadoNumero == filter.CertificadoNumero )
					  && (filter.CertificadoFechaPago == null || filter.CertificadoFechaPago == DateTime.MinValue || o.CertificadoFechaPago >=  filter.CertificadoFechaPago) && (filter.CertificadoFechaPago_To == null || filter.CertificadoFechaPago_To == DateTime.MinValue || o.CertificadoFechaPago <= filter.CertificadoFechaPago_To)
					  && (filter.CertificadoFechaPagoIsNull == null || filter.CertificadoFechaPagoIsNull == true || o.CertificadoFechaPago != null ) && (filter.CertificadoFechaPagoIsNull == null || filter.CertificadoFechaPagoIsNull == false || o.CertificadoFechaPago == null)
					  && (filter.CertificadoFechaVencimiento == null || filter.CertificadoFechaVencimiento == DateTime.MinValue || o.CertificadoFechaVencimiento >=  filter.CertificadoFechaVencimiento) && (filter.CertificadoFechaVencimiento_To == null || filter.CertificadoFechaVencimiento_To == DateTime.MinValue || o.CertificadoFechaVencimiento <= filter.CertificadoFechaVencimiento_To)
					  && (filter.CertificadoFechaVencimientoIsNull == null || filter.CertificadoFechaVencimientoIsNull == true || o.CertificadoFechaVencimiento != null ) && (filter.CertificadoFechaVencimientoIsNull == null || filter.CertificadoFechaVencimientoIsNull == false || o.CertificadoFechaVencimiento == null)
					  && (filter.IdCertificadoEstado == null || filter.IdCertificadoEstado == 0 || o.IdCertificadoEstado==filter.IdCertificadoEstado)
					  && (filter.IdCertificadoEstadoIsNull == null || filter.IdCertificadoEstadoIsNull == true || o.IdCertificadoEstado != null ) && (filter.IdCertificadoEstadoIsNull == null || filter.IdCertificadoEstadoIsNull == false || o.IdCertificadoEstado == null)
					  && (filter.CantidadAcumuladaEstimada == null || o.CantidadAcumuladaEstimada >=  filter.CantidadAcumuladaEstimada) && (filter.CantidadAcumuladaEstimada_To == null || o.CantidadAcumuladaEstimada <= filter.CantidadAcumuladaEstimada_To)
					  && (filter.CantidadAcumuladaEstimadaIsNull == null || filter.CantidadAcumuladaEstimadaIsNull == true || o.CantidadAcumuladaEstimada != null ) && (filter.CantidadAcumuladaEstimadaIsNull == null || filter.CantidadAcumuladaEstimadaIsNull == false || o.CantidadAcumuladaEstimada == null)
					  && (filter.CantidadAcumuladaRealizada == null || o.CantidadAcumuladaRealizada >=  filter.CantidadAcumuladaRealizada) && (filter.CantidadAcumuladaRealizada_To == null || o.CantidadAcumuladaRealizada <= filter.CantidadAcumuladaRealizada_To)
					  && (filter.CantidadAcumuladaRealizadaIsNull == null || filter.CantidadAcumuladaRealizadaIsNull == true || o.CantidadAcumuladaRealizada != null ) && (filter.CantidadAcumuladaRealizadaIsNull == null || filter.CantidadAcumuladaRealizadaIsNull == false || o.CantidadAcumuladaRealizada == null)
					  && (filter.MontoEstimado == null || o.MontoEstimado >=  filter.MontoEstimado) && (filter.MontoEstimado_To == null || o.MontoEstimado <= filter.MontoEstimado_To)
					  && (filter.MontoEstimadoIsNull == null || filter.MontoEstimadoIsNull == true || o.MontoEstimado != null ) && (filter.MontoEstimadoIsNull == null || filter.MontoEstimadoIsNull == false || o.MontoEstimado == null)
					  && (filter.MontoRealizado == null || o.MontoRealizado >=  filter.MontoRealizado) && (filter.MontoRealizado_To == null || o.MontoRealizado <= filter.MontoRealizado_To)
					  && (filter.MontoRealizadoIsNull == null || filter.MontoRealizadoIsNull == true || o.MontoRealizado != null ) && (filter.MontoRealizadoIsNull == null || filter.MontoRealizadoIsNull == false || o.MontoRealizado == null)
					  && (filter.Observacion == null || filter.Observacion.Trim() == string.Empty || filter.Observacion.Trim() == "%"  || (filter.Observacion.EndsWith("%") && filter.Observacion.StartsWith("%") && (o.Observacion.Contains(filter.Observacion.Replace("%", "")))) || (filter.Observacion.EndsWith("%") && o.Observacion.StartsWith(filter.Observacion.Replace("%",""))) || (filter.Observacion.StartsWith("%") && o.Observacion.EndsWith(filter.Observacion.Replace("%",""))) || o.Observacion == filter.Observacion )
					  && (filter.Cotizacion == null || o.Cotizacion >=  filter.Cotizacion) && (filter.Cotizacion_To == null || o.Cotizacion <= filter.Cotizacion_To)
					  && (filter.CotizacionIsNull == null || filter.CotizacionIsNull == true || o.Cotizacion != null ) && (filter.CotizacionIsNull == null || filter.CotizacionIsNull == false || o.Cotizacion == null)
					  && (filter.NumeroDesembolso == null || filter.NumeroDesembolso.Trim() == string.Empty || filter.NumeroDesembolso.Trim() == "%"  || (filter.NumeroDesembolso.EndsWith("%") && filter.NumeroDesembolso.StartsWith("%") && (o.NumeroDesembolso.Contains(filter.NumeroDesembolso.Replace("%", "")))) || (filter.NumeroDesembolso.EndsWith("%") && o.NumeroDesembolso.StartsWith(filter.NumeroDesembolso.Replace("%",""))) || (filter.NumeroDesembolso.StartsWith("%") && o.NumeroDesembolso.EndsWith(filter.NumeroDesembolso.Replace("%",""))) || o.NumeroDesembolso == filter.NumeroDesembolso )
					  && (filter.NroExpediente == null || filter.NroExpediente.Trim() == string.Empty || filter.NroExpediente.Trim() == "%"  || (filter.NroExpediente.EndsWith("%") && filter.NroExpediente.StartsWith("%") && (o.NroExpediente.Contains(filter.NroExpediente.Replace("%", "")))) || (filter.NroExpediente.EndsWith("%") && o.NroExpediente.StartsWith(filter.NroExpediente.Replace("%",""))) || (filter.NroExpediente.StartsWith("%") && o.NroExpediente.EndsWith(filter.NroExpediente.Replace("%",""))) || o.NroExpediente == filter.NroExpediente )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<IndicadorEvolucionResult> QueryResult(IndicadorEvolucionFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.ClasificacionGeograficas on o.IdClasificacionGeografica equals t1.IdClasificacionGeografica   
				   join _t2  in this.Context.Estados on o.IdCertificadoEstado equals _t2.IdEstado into tt2 from t2 in tt2.DefaultIfEmpty()
				    join t3  in this.Context.Indicadors on o.IdIndicador equals t3.IdIndicador   
				    join t4  in this.Context.IndicadorEvolucionInstancias on o.IdIndicadorEvolucionInstancia equals t4.IdIndicadorEvolucionInstancia   
				   select new IndicadorEvolucionResult(){
					 IdIndicadorEvolucion=o.IdIndicadorEvolucion
					 ,IdIndicador=o.IdIndicador
					 ,IdClasificacionGeografica=o.IdClasificacionGeografica
					 ,IdIndicadorEvolucionInstancia=o.IdIndicadorEvolucionInstancia
					 ,FechaEstimada=o.FechaEstimada
					 ,CantidadEstimada=o.CantidadEstimada
					 ,PrecioUnitarioEstimado=o.PrecioUnitarioEstimado
					 ,FechaReal=o.FechaReal
					 ,CantidadReal=o.CantidadReal
					 ,PrecioUnitarioReal=o.PrecioUnitarioReal
					 ,CertificadoNumero=o.CertificadoNumero
					 ,CertificadoFechaPago=o.CertificadoFechaPago
					 ,CertificadoFechaVencimiento=o.CertificadoFechaVencimiento
					 ,IdCertificadoEstado=o.IdCertificadoEstado
					 ,CantidadAcumuladaEstimada=o.CantidadAcumuladaEstimada
					 ,CantidadAcumuladaRealizada=o.CantidadAcumuladaRealizada
					 ,MontoEstimado=o.MontoEstimado
					 ,MontoRealizado=o.MontoRealizado
					 ,Observacion=o.Observacion
					 ,Cotizacion=o.Cotizacion
					 ,NumeroDesembolso=o.NumeroDesembolso
					 ,NroExpediente=o.NroExpediente
					,ClasificacionGeografica_Codigo= t1.Codigo	
						,ClasificacionGeografica_Nombre= t1.Nombre	
						,ClasificacionGeografica_IdClasificacionGeograficaTipo= t1.IdClasificacionGeograficaTipo	
						,ClasificacionGeografica_IdClasificacionGeograficaPadre= t1.IdClasificacionGeograficaPadre	
						,ClasificacionGeografica_Activo= t1.Activo	
						,ClasificacionGeografica_Descripcion= t1.Descripcion	
						,ClasificacionGeografica_BreadcrumbId= t1.BreadcrumbId	
						,ClasificacionGeografica_BreadcrumOrden= t1.BreadcrumOrden	
						,ClasificacionGeografica_Orden= t1.Orden	
						,ClasificacionGeografica_Nivel= t1.Nivel	
						,ClasificacionGeografica_DescripcionInvertida= t1.DescripcionInvertida	
						,ClasificacionGeografica_Seleccionable= t1.Seleccionable	
						,ClasificacionGeografica_BreadcrumbCode= t1.BreadcrumbCode	
						,ClasificacionGeografica_DescripcionCodigo= t1.DescripcionCodigo	
						,CertificadoEstado_Nombre= t2!=null?(string)t2.Nombre:null	
						,CertificadoEstado_Codigo= t2!=null?(string)t2.Codigo:null	
						,CertificadoEstado_Orden= t2!=null?(int?)t2.Orden:null	
						,CertificadoEstado_Descripcion= t2!=null?(string)t2.Descripcion:null	
						,CertificadoEstado_Activo= t2!=null?(bool?)t2.Activo:null	
						,Indicador_IdMedioVerificacion= t3.IdMedioVerificacion	
						,Indicador_Observacion= t3.Observacion	
						,IndicadorEvolucionInstancia_Nombre= t4.Nombre	
						,IndicadorEvolucionInstancia_Orden= t4.Orden	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.IndicadorEvolucion Copy(nc.IndicadorEvolucion entity)
        {           
            nc.IndicadorEvolucion _new = new nc.IndicadorEvolucion();
		 _new.IdIndicador= entity.IdIndicador;
		 _new.IdClasificacionGeografica= entity.IdClasificacionGeografica;
		 _new.IdIndicadorEvolucionInstancia= entity.IdIndicadorEvolucionInstancia;
		 _new.FechaEstimada= entity.FechaEstimada;
		 _new.CantidadEstimada= entity.CantidadEstimada;
		 _new.PrecioUnitarioEstimado= entity.PrecioUnitarioEstimado;
		 _new.FechaReal= entity.FechaReal;
		 _new.CantidadReal= entity.CantidadReal;
		 _new.PrecioUnitarioReal= entity.PrecioUnitarioReal;
		 _new.CertificadoNumero= entity.CertificadoNumero;
		 _new.CertificadoFechaPago= entity.CertificadoFechaPago;
		 _new.CertificadoFechaVencimiento= entity.CertificadoFechaVencimiento;
		 _new.IdCertificadoEstado= entity.IdCertificadoEstado;
		 _new.CantidadAcumuladaEstimada= entity.CantidadAcumuladaEstimada;
		 _new.CantidadAcumuladaRealizada= entity.CantidadAcumuladaRealizada;
		 _new.MontoEstimado= entity.MontoEstimado;
		 _new.MontoRealizado= entity.MontoRealizado;
		 _new.Observacion= entity.Observacion;
		 _new.Cotizacion= entity.Cotizacion;
		 _new.NumeroDesembolso= entity.NumeroDesembolso;
		 _new.NroExpediente= entity.NroExpediente;
		return _new;			
        }
		public override int CopyAndSave(IndicadorEvolucion entity,string renameFormat)
        {
            IndicadorEvolucion  newEntity = Copy(entity);
            newEntity.CertificadoNumero = string.Format(renameFormat,newEntity.CertificadoNumero);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(IndicadorEvolucion entity, int id)
        {            
            entity.IdIndicadorEvolucion = id;            
        }
		public override void Set(IndicadorEvolucion source,IndicadorEvolucion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorEvolucion= source.IdIndicadorEvolucion ;
		 target.IdIndicador= source.IdIndicador ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 target.IdIndicadorEvolucionInstancia= source.IdIndicadorEvolucionInstancia ;
		 target.FechaEstimada= source.FechaEstimada ;
		 target.CantidadEstimada= source.CantidadEstimada ;
		 target.PrecioUnitarioEstimado= source.PrecioUnitarioEstimado ;
		 target.FechaReal= source.FechaReal ;
		 target.CantidadReal= source.CantidadReal ;
		 target.PrecioUnitarioReal= source.PrecioUnitarioReal ;
		 target.CertificadoNumero= source.CertificadoNumero ;
		 target.CertificadoFechaPago= source.CertificadoFechaPago ;
		 target.CertificadoFechaVencimiento= source.CertificadoFechaVencimiento ;
		 target.IdCertificadoEstado= source.IdCertificadoEstado ;
		 target.CantidadAcumuladaEstimada= source.CantidadAcumuladaEstimada ;
		 target.CantidadAcumuladaRealizada= source.CantidadAcumuladaRealizada ;
		 target.MontoEstimado= source.MontoEstimado ;
		 target.MontoRealizado= source.MontoRealizado ;
		 target.Observacion= source.Observacion ;
		 target.Cotizacion= source.Cotizacion ;
		 target.NumeroDesembolso= source.NumeroDesembolso ;
		 target.NroExpediente= source.NroExpediente ;
		 		  
		}
		public override void Set(IndicadorEvolucionResult source,IndicadorEvolucion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorEvolucion= source.IdIndicadorEvolucion ;
		 target.IdIndicador= source.IdIndicador ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 target.IdIndicadorEvolucionInstancia= source.IdIndicadorEvolucionInstancia ;
		 target.FechaEstimada= source.FechaEstimada ;
		 target.CantidadEstimada= source.CantidadEstimada ;
		 target.PrecioUnitarioEstimado= source.PrecioUnitarioEstimado ;
		 target.FechaReal= source.FechaReal ;
		 target.CantidadReal= source.CantidadReal ;
		 target.PrecioUnitarioReal= source.PrecioUnitarioReal ;
		 target.CertificadoNumero= source.CertificadoNumero ;
		 target.CertificadoFechaPago= source.CertificadoFechaPago ;
		 target.CertificadoFechaVencimiento= source.CertificadoFechaVencimiento ;
		 target.IdCertificadoEstado= source.IdCertificadoEstado ;
		 target.CantidadAcumuladaEstimada= source.CantidadAcumuladaEstimada ;
		 target.CantidadAcumuladaRealizada= source.CantidadAcumuladaRealizada ;
		 target.MontoEstimado= source.MontoEstimado ;
		 target.MontoRealizado= source.MontoRealizado ;
		 target.Observacion= source.Observacion ;
		 target.Cotizacion= source.Cotizacion ;
		 target.NumeroDesembolso= source.NumeroDesembolso ;
		 target.NroExpediente= source.NroExpediente ;
		 
		}
		public override void Set(IndicadorEvolucion source,IndicadorEvolucionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorEvolucion= source.IdIndicadorEvolucion ;
		 target.IdIndicador= source.IdIndicador ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 target.IdIndicadorEvolucionInstancia= source.IdIndicadorEvolucionInstancia ;
		 target.FechaEstimada= source.FechaEstimada ;
		 target.CantidadEstimada= source.CantidadEstimada ;
		 target.PrecioUnitarioEstimado= source.PrecioUnitarioEstimado ;
		 target.FechaReal= source.FechaReal ;
		 target.CantidadReal= source.CantidadReal ;
		 target.PrecioUnitarioReal= source.PrecioUnitarioReal ;
		 target.CertificadoNumero= source.CertificadoNumero ;
		 target.CertificadoFechaPago= source.CertificadoFechaPago ;
		 target.CertificadoFechaVencimiento= source.CertificadoFechaVencimiento ;
		 target.IdCertificadoEstado= source.IdCertificadoEstado ;
		 target.CantidadAcumuladaEstimada= source.CantidadAcumuladaEstimada ;
		 target.CantidadAcumuladaRealizada= source.CantidadAcumuladaRealizada ;
		 target.MontoEstimado= source.MontoEstimado ;
		 target.MontoRealizado= source.MontoRealizado ;
		 target.Observacion= source.Observacion ;
		 target.Cotizacion= source.Cotizacion ;
		 target.NumeroDesembolso= source.NumeroDesembolso ;
		 target.NroExpediente= source.NroExpediente ;
		 	
		}		
		public override void Set(IndicadorEvolucionResult source,IndicadorEvolucionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorEvolucion= source.IdIndicadorEvolucion ;
		 target.IdIndicador= source.IdIndicador ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 target.IdIndicadorEvolucionInstancia= source.IdIndicadorEvolucionInstancia ;
		 target.FechaEstimada= source.FechaEstimada ;
		 target.CantidadEstimada= source.CantidadEstimada ;
		 target.PrecioUnitarioEstimado= source.PrecioUnitarioEstimado ;
		 target.FechaReal= source.FechaReal ;
		 target.CantidadReal= source.CantidadReal ;
		 target.PrecioUnitarioReal= source.PrecioUnitarioReal ;
		 target.CertificadoNumero= source.CertificadoNumero ;
		 target.CertificadoFechaPago= source.CertificadoFechaPago ;
		 target.CertificadoFechaVencimiento= source.CertificadoFechaVencimiento ;
		 target.IdCertificadoEstado= source.IdCertificadoEstado ;
		 target.CantidadAcumuladaEstimada= source.CantidadAcumuladaEstimada ;
		 target.CantidadAcumuladaRealizada= source.CantidadAcumuladaRealizada ;
		 target.MontoEstimado= source.MontoEstimado ;
		 target.MontoRealizado= source.MontoRealizado ;
		 target.Observacion= source.Observacion ;
		 target.Cotizacion= source.Cotizacion ;
		 target.NumeroDesembolso= source.NumeroDesembolso ;
		 target.NroExpediente= source.NroExpediente ;
		 target.ClasificacionGeografica_Codigo= source.ClasificacionGeografica_Codigo;	
			target.ClasificacionGeografica_Nombre= source.ClasificacionGeografica_Nombre;	
			target.ClasificacionGeografica_IdClasificacionGeograficaTipo= source.ClasificacionGeografica_IdClasificacionGeograficaTipo;	
			target.ClasificacionGeografica_IdClasificacionGeograficaPadre= source.ClasificacionGeografica_IdClasificacionGeograficaPadre;	
			target.ClasificacionGeografica_Activo= source.ClasificacionGeografica_Activo;	
			target.ClasificacionGeografica_Descripcion= source.ClasificacionGeografica_Descripcion;	
			target.ClasificacionGeografica_BreadcrumbId= source.ClasificacionGeografica_BreadcrumbId;	
			target.ClasificacionGeografica_BreadcrumOrden= source.ClasificacionGeografica_BreadcrumOrden;	
			target.ClasificacionGeografica_Orden= source.ClasificacionGeografica_Orden;	
			target.ClasificacionGeografica_Nivel= source.ClasificacionGeografica_Nivel;	
			target.ClasificacionGeografica_DescripcionInvertida= source.ClasificacionGeografica_DescripcionInvertida;	
			target.ClasificacionGeografica_Seleccionable= source.ClasificacionGeografica_Seleccionable;	
			target.ClasificacionGeografica_BreadcrumbCode= source.ClasificacionGeografica_BreadcrumbCode;	
			target.ClasificacionGeografica_DescripcionCodigo= source.ClasificacionGeografica_DescripcionCodigo;	
			target.CertificadoEstado_Nombre= source.CertificadoEstado_Nombre;	
			target.CertificadoEstado_Codigo= source.CertificadoEstado_Codigo;	
			target.CertificadoEstado_Orden= source.CertificadoEstado_Orden;	
			target.CertificadoEstado_Descripcion= source.CertificadoEstado_Descripcion;	
			target.CertificadoEstado_Activo= source.CertificadoEstado_Activo;	
			target.Indicador_IdMedioVerificacion= source.Indicador_IdMedioVerificacion;	
			target.Indicador_Observacion= source.Indicador_Observacion;	
			target.IndicadorEvolucionInstancia_Nombre= source.IndicadorEvolucionInstancia_Nombre;	
			target.IndicadorEvolucionInstancia_Orden= source.IndicadorEvolucionInstancia_Orden;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(IndicadorEvolucion source,IndicadorEvolucion target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdIndicadorEvolucion.Equals(target.IdIndicadorEvolucion))return false;
		  if(!source.IdIndicador.Equals(target.IdIndicador))return false;
		  if(!source.IdClasificacionGeografica.Equals(target.IdClasificacionGeografica))return false;
		  if(!source.IdIndicadorEvolucionInstancia.Equals(target.IdIndicadorEvolucionInstancia))return false;
		  if((source.FechaEstimada == null)?(target.FechaEstimada.HasValue):!source.FechaEstimada.Equals(target.FechaEstimada))return false;
			 if((source.CantidadEstimada == null)?(target.CantidadEstimada.HasValue):!source.CantidadEstimada.Equals(target.CantidadEstimada))return false;
			 if((source.PrecioUnitarioEstimado == null)?(target.PrecioUnitarioEstimado.HasValue):!source.PrecioUnitarioEstimado.Equals(target.PrecioUnitarioEstimado))return false;
			 if((source.FechaReal == null)?(target.FechaReal.HasValue):!source.FechaReal.Equals(target.FechaReal))return false;
			 if((source.CantidadReal == null)?(target.CantidadReal.HasValue):!source.CantidadReal.Equals(target.CantidadReal))return false;
			 if((source.PrecioUnitarioReal == null)?(target.PrecioUnitarioReal.HasValue):!source.PrecioUnitarioReal.Equals(target.PrecioUnitarioReal))return false;
			 if((source.CertificadoNumero == null)?target.CertificadoNumero!=null:  !( (target.CertificadoNumero== String.Empty && source.CertificadoNumero== null) || (target.CertificadoNumero==null && source.CertificadoNumero== String.Empty )) &&  !source.CertificadoNumero.Trim().Replace ("\r","").Equals(target.CertificadoNumero.Trim().Replace ("\r","")))return false;
			 if((source.CertificadoFechaPago == null)?(target.CertificadoFechaPago.HasValue):!source.CertificadoFechaPago.Equals(target.CertificadoFechaPago))return false;
			 if((source.CertificadoFechaVencimiento == null)?(target.CertificadoFechaVencimiento.HasValue):!source.CertificadoFechaVencimiento.Equals(target.CertificadoFechaVencimiento))return false;
			 if((source.IdCertificadoEstado == null)?(target.IdCertificadoEstado.HasValue && target.IdCertificadoEstado.Value > 0):!source.IdCertificadoEstado.Equals(target.IdCertificadoEstado))return false;
						  if((source.CantidadAcumuladaEstimada == null)?(target.CantidadAcumuladaEstimada.HasValue):!source.CantidadAcumuladaEstimada.Equals(target.CantidadAcumuladaEstimada))return false;
			 if((source.CantidadAcumuladaRealizada == null)?(target.CantidadAcumuladaRealizada.HasValue):!source.CantidadAcumuladaRealizada.Equals(target.CantidadAcumuladaRealizada))return false;
			 if((source.MontoEstimado == null)?(target.MontoEstimado.HasValue):!source.MontoEstimado.Equals(target.MontoEstimado))return false;
			 if((source.MontoRealizado == null)?(target.MontoRealizado.HasValue):!source.MontoRealizado.Equals(target.MontoRealizado))return false;
			 if((source.Observacion == null)?target.Observacion!=null:  !( (target.Observacion== String.Empty && source.Observacion== null) || (target.Observacion==null && source.Observacion== String.Empty )) &&  !source.Observacion.Trim().Replace ("\r","").Equals(target.Observacion.Trim().Replace ("\r","")))return false;
			 if((source.Cotizacion == null)?(target.Cotizacion.HasValue):!source.Cotizacion.Equals(target.Cotizacion))return false;
			 if((source.NumeroDesembolso == null)?target.NumeroDesembolso!=null:  !( (target.NumeroDesembolso== String.Empty && source.NumeroDesembolso== null) || (target.NumeroDesembolso==null && source.NumeroDesembolso== String.Empty )) &&  !source.NumeroDesembolso.Trim().Replace ("\r","").Equals(target.NumeroDesembolso.Trim().Replace ("\r","")))return false;
			 if((source.NroExpediente == null)?target.NroExpediente!=null:  !( (target.NroExpediente== String.Empty && source.NroExpediente== null) || (target.NroExpediente==null && source.NroExpediente== String.Empty )) &&  !source.NroExpediente.Trim().Replace ("\r","").Equals(target.NroExpediente.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(IndicadorEvolucionResult source,IndicadorEvolucionResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdIndicadorEvolucion.Equals(target.IdIndicadorEvolucion))return false;
		  if(!source.IdIndicador.Equals(target.IdIndicador))return false;
		  if(!source.IdClasificacionGeografica.Equals(target.IdClasificacionGeografica))return false;
		  if(!source.IdIndicadorEvolucionInstancia.Equals(target.IdIndicadorEvolucionInstancia))return false;
		  if((source.FechaEstimada == null)?(target.FechaEstimada.HasValue):!source.FechaEstimada.Equals(target.FechaEstimada))return false;
			 if((source.CantidadEstimada == null)?(target.CantidadEstimada.HasValue):!source.CantidadEstimada.Equals(target.CantidadEstimada))return false;
			 if((source.PrecioUnitarioEstimado == null)?(target.PrecioUnitarioEstimado.HasValue):!source.PrecioUnitarioEstimado.Equals(target.PrecioUnitarioEstimado))return false;
			 if((source.FechaReal == null)?(target.FechaReal.HasValue):!source.FechaReal.Equals(target.FechaReal))return false;
			 if((source.CantidadReal == null)?(target.CantidadReal.HasValue):!source.CantidadReal.Equals(target.CantidadReal))return false;
			 if((source.PrecioUnitarioReal == null)?(target.PrecioUnitarioReal.HasValue):!source.PrecioUnitarioReal.Equals(target.PrecioUnitarioReal))return false;
			 if((source.CertificadoNumero == null)?target.CertificadoNumero!=null: !( (target.CertificadoNumero== String.Empty && source.CertificadoNumero== null) || (target.CertificadoNumero==null && source.CertificadoNumero== String.Empty )) && !source.CertificadoNumero.Trim().Replace ("\r","").Equals(target.CertificadoNumero.Trim().Replace ("\r","")))return false;
			 if((source.CertificadoFechaPago == null)?(target.CertificadoFechaPago.HasValue):!source.CertificadoFechaPago.Equals(target.CertificadoFechaPago))return false;
			 if((source.CertificadoFechaVencimiento == null)?(target.CertificadoFechaVencimiento.HasValue):!source.CertificadoFechaVencimiento.Equals(target.CertificadoFechaVencimiento))return false;
			 if((source.IdCertificadoEstado == null)?(target.IdCertificadoEstado.HasValue && target.IdCertificadoEstado.Value > 0):!source.IdCertificadoEstado.Equals(target.IdCertificadoEstado))return false;
						  if((source.CantidadAcumuladaEstimada == null)?(target.CantidadAcumuladaEstimada.HasValue):!source.CantidadAcumuladaEstimada.Equals(target.CantidadAcumuladaEstimada))return false;
			 if((source.CantidadAcumuladaRealizada == null)?(target.CantidadAcumuladaRealizada.HasValue):!source.CantidadAcumuladaRealizada.Equals(target.CantidadAcumuladaRealizada))return false;
			 if((source.MontoEstimado == null)?(target.MontoEstimado.HasValue):!source.MontoEstimado.Equals(target.MontoEstimado))return false;
			 if((source.MontoRealizado == null)?(target.MontoRealizado.HasValue):!source.MontoRealizado.Equals(target.MontoRealizado))return false;
			 if((source.Observacion == null)?target.Observacion!=null: !( (target.Observacion== String.Empty && source.Observacion== null) || (target.Observacion==null && source.Observacion== String.Empty )) && !source.Observacion.Trim().Replace ("\r","").Equals(target.Observacion.Trim().Replace ("\r","")))return false;
			 if((source.Cotizacion == null)?(target.Cotizacion.HasValue):!source.Cotizacion.Equals(target.Cotizacion))return false;
			 if((source.NumeroDesembolso == null)?target.NumeroDesembolso!=null: !( (target.NumeroDesembolso== String.Empty && source.NumeroDesembolso== null) || (target.NumeroDesembolso==null && source.NumeroDesembolso== String.Empty )) && !source.NumeroDesembolso.Trim().Replace ("\r","").Equals(target.NumeroDesembolso.Trim().Replace ("\r","")))return false;
			 if((source.NroExpediente == null)?target.NroExpediente!=null: !( (target.NroExpediente== String.Empty && source.NroExpediente== null) || (target.NroExpediente==null && source.NroExpediente== String.Empty )) && !source.NroExpediente.Trim().Replace ("\r","").Equals(target.NroExpediente.Trim().Replace ("\r","")))return false;
			 if((source.ClasificacionGeografica_Codigo == null)?target.ClasificacionGeografica_Codigo!=null: !( (target.ClasificacionGeografica_Codigo== String.Empty && source.ClasificacionGeografica_Codigo== null) || (target.ClasificacionGeografica_Codigo==null && source.ClasificacionGeografica_Codigo== String.Empty )) &&   !source.ClasificacionGeografica_Codigo.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGeografica_Nombre == null)?target.ClasificacionGeografica_Nombre!=null: !( (target.ClasificacionGeografica_Nombre== String.Empty && source.ClasificacionGeografica_Nombre== null) || (target.ClasificacionGeografica_Nombre==null && source.ClasificacionGeografica_Nombre== String.Empty )) &&   !source.ClasificacionGeografica_Nombre.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.ClasificacionGeografica_IdClasificacionGeograficaTipo.Equals(target.ClasificacionGeografica_IdClasificacionGeograficaTipo))return false;
					  if((source.ClasificacionGeografica_IdClasificacionGeograficaPadre == null)?(target.ClasificacionGeografica_IdClasificacionGeograficaPadre.HasValue && target.ClasificacionGeografica_IdClasificacionGeograficaPadre.Value > 0):!source.ClasificacionGeografica_IdClasificacionGeograficaPadre.Equals(target.ClasificacionGeografica_IdClasificacionGeograficaPadre))return false;
									  if(!source.ClasificacionGeografica_Activo.Equals(target.ClasificacionGeografica_Activo))return false;
					  if((source.ClasificacionGeografica_Descripcion == null)?target.ClasificacionGeografica_Descripcion!=null: !( (target.ClasificacionGeografica_Descripcion== String.Empty && source.ClasificacionGeografica_Descripcion== null) || (target.ClasificacionGeografica_Descripcion==null && source.ClasificacionGeografica_Descripcion== String.Empty )) &&   !source.ClasificacionGeografica_Descripcion.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_Descripcion.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGeografica_BreadcrumbId == null)?target.ClasificacionGeografica_BreadcrumbId!=null: !( (target.ClasificacionGeografica_BreadcrumbId== String.Empty && source.ClasificacionGeografica_BreadcrumbId== null) || (target.ClasificacionGeografica_BreadcrumbId==null && source.ClasificacionGeografica_BreadcrumbId== String.Empty )) &&   !source.ClasificacionGeografica_BreadcrumbId.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_BreadcrumbId.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGeografica_BreadcrumOrden == null)?target.ClasificacionGeografica_BreadcrumOrden!=null: !( (target.ClasificacionGeografica_BreadcrumOrden== String.Empty && source.ClasificacionGeografica_BreadcrumOrden== null) || (target.ClasificacionGeografica_BreadcrumOrden==null && source.ClasificacionGeografica_BreadcrumOrden== String.Empty )) &&   !source.ClasificacionGeografica_BreadcrumOrden.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_BreadcrumOrden.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGeografica_Orden == null)?(target.ClasificacionGeografica_Orden.HasValue ):!source.ClasificacionGeografica_Orden.Equals(target.ClasificacionGeografica_Orden))return false;
						 if((source.ClasificacionGeografica_Nivel == null)?(target.ClasificacionGeografica_Nivel.HasValue ):!source.ClasificacionGeografica_Nivel.Equals(target.ClasificacionGeografica_Nivel))return false;
						 if((source.ClasificacionGeografica_DescripcionInvertida == null)?target.ClasificacionGeografica_DescripcionInvertida!=null: !( (target.ClasificacionGeografica_DescripcionInvertida== String.Empty && source.ClasificacionGeografica_DescripcionInvertida== null) || (target.ClasificacionGeografica_DescripcionInvertida==null && source.ClasificacionGeografica_DescripcionInvertida== String.Empty )) &&   !source.ClasificacionGeografica_DescripcionInvertida.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_DescripcionInvertida.Trim().Replace ("\r","")))return false;
						 if(!source.ClasificacionGeografica_Seleccionable.Equals(target.ClasificacionGeografica_Seleccionable))return false;
					  if((source.ClasificacionGeografica_BreadcrumbCode == null)?target.ClasificacionGeografica_BreadcrumbCode!=null: !( (target.ClasificacionGeografica_BreadcrumbCode== String.Empty && source.ClasificacionGeografica_BreadcrumbCode== null) || (target.ClasificacionGeografica_BreadcrumbCode==null && source.ClasificacionGeografica_BreadcrumbCode== String.Empty )) &&   !source.ClasificacionGeografica_BreadcrumbCode.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_BreadcrumbCode.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGeografica_DescripcionCodigo == null)?target.ClasificacionGeografica_DescripcionCodigo!=null: !( (target.ClasificacionGeografica_DescripcionCodigo== String.Empty && source.ClasificacionGeografica_DescripcionCodigo== null) || (target.ClasificacionGeografica_DescripcionCodigo==null && source.ClasificacionGeografica_DescripcionCodigo== String.Empty )) &&   !source.ClasificacionGeografica_DescripcionCodigo.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_DescripcionCodigo.Trim().Replace ("\r","")))return false;
						 if((source.CertificadoEstado_Nombre == null)?target.CertificadoEstado_Nombre!=null: !( (target.CertificadoEstado_Nombre== String.Empty && source.CertificadoEstado_Nombre== null) || (target.CertificadoEstado_Nombre==null && source.CertificadoEstado_Nombre== String.Empty )) &&   !source.CertificadoEstado_Nombre.Trim().Replace ("\r","").Equals(target.CertificadoEstado_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.CertificadoEstado_Codigo == null)?target.CertificadoEstado_Codigo!=null: !( (target.CertificadoEstado_Codigo== String.Empty && source.CertificadoEstado_Codigo== null) || (target.CertificadoEstado_Codigo==null && source.CertificadoEstado_Codigo== String.Empty )) &&   !source.CertificadoEstado_Codigo.Trim().Replace ("\r","").Equals(target.CertificadoEstado_Codigo.Trim().Replace ("\r","")))return false;
						 if(!source.CertificadoEstado_Orden.Equals(target.CertificadoEstado_Orden))return false;
					  if((source.CertificadoEstado_Descripcion == null)?target.CertificadoEstado_Descripcion!=null: !( (target.CertificadoEstado_Descripcion== String.Empty && source.CertificadoEstado_Descripcion== null) || (target.CertificadoEstado_Descripcion==null && source.CertificadoEstado_Descripcion== String.Empty )) &&   !source.CertificadoEstado_Descripcion.Trim().Replace ("\r","").Equals(target.CertificadoEstado_Descripcion.Trim().Replace ("\r","")))return false;
						 if(!source.CertificadoEstado_Activo.Equals(target.CertificadoEstado_Activo))return false;
					  if((source.Indicador_IdMedioVerificacion == null)?(target.Indicador_IdMedioVerificacion.HasValue && target.Indicador_IdMedioVerificacion.Value > 0):!source.Indicador_IdMedioVerificacion.Equals(target.Indicador_IdMedioVerificacion))return false;
									  if((source.Indicador_Observacion == null)?target.Indicador_Observacion!=null: !( (target.Indicador_Observacion== String.Empty && source.Indicador_Observacion== null) || (target.Indicador_Observacion==null && source.Indicador_Observacion== String.Empty )) &&   !source.Indicador_Observacion.Trim().Replace ("\r","").Equals(target.Indicador_Observacion.Trim().Replace ("\r","")))return false;
						 if((source.IndicadorEvolucionInstancia_Nombre == null)?target.IndicadorEvolucionInstancia_Nombre!=null: !( (target.IndicadorEvolucionInstancia_Nombre== String.Empty && source.IndicadorEvolucionInstancia_Nombre== null) || (target.IndicadorEvolucionInstancia_Nombre==null && source.IndicadorEvolucionInstancia_Nombre== String.Empty )) &&   !source.IndicadorEvolucionInstancia_Nombre.Trim().Replace ("\r","").Equals(target.IndicadorEvolucionInstancia_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.IndicadorEvolucionInstancia_Orden == null)?(target.IndicadorEvolucionInstancia_Orden.HasValue ):!source.IndicadorEvolucionInstancia_Orden.Equals(target.IndicadorEvolucionInstancia_Orden))return false;
								
		  return true;
        }
		#endregion
    }
}

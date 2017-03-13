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
    public abstract class _TransferenciaDetalleData : EntityData<TransferenciaDetalle,TransferenciaDetalleFilter,TransferenciaDetalleResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.TransferenciaDetalle entity)
		{			
			return entity.IdTransferenciaDetalle;
		}		
		public override TransferenciaDetalle GetByEntity(TransferenciaDetalle entity)
        {
            return this.GetById(entity.IdTransferenciaDetalle);
        }
        public override TransferenciaDetalle GetById(int id)
        {
            return (from o in this.Table where o.IdTransferenciaDetalle == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<TransferenciaDetalle> Query(TransferenciaDetalleFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdTransferenciaDetalle == null || o.IdTransferenciaDetalle >=  filter.IdTransferenciaDetalle) && (filter.IdTransferenciaDetalle_To == null || o.IdTransferenciaDetalle <= filter.IdTransferenciaDetalle_To)
					  && (filter.IdTransferencia == null || filter.IdTransferencia == 0 || o.IdTransferencia==filter.IdTransferencia)
					  //&& (filter.Anio == null || o.Anio >=  filter.Anio) && (filter.Anio_To == null || o.Anio <= filter.Anio_To)
					  && (filter.IdFuenteFinanciamiento == null || filter.IdFuenteFinanciamiento == 0 || o.IdFuenteFinanciamiento==filter.IdFuenteFinanciamiento)
					  && (filter.IdMoneda == null || filter.IdMoneda == 0 || o.IdMoneda==filter.IdMoneda)
					  && (filter.IdFinalidadFuncion == null || filter.IdFinalidadFuncion == 0 || o.IdFinalidadFuncion==filter.IdFinalidadFuncion)
					  && (filter.Inicial == null || o.Inicial >=  filter.Inicial) && (filter.Inicial_To == null || o.Inicial <= filter.Inicial_To)
					  && (filter.Vigente == null || o.Vigente >=  filter.Vigente) && (filter.Vigente_To == null || o.Vigente <= filter.Vigente_To)
					  && (filter.Comprometido == null || o.Comprometido >=  filter.Comprometido) && (filter.Comprometido_To == null || o.Comprometido <= filter.Comprometido_To)
					  && (filter.Devengado == null || o.Devengado >=  filter.Devengado) && (filter.Devengado_To == null || o.Devengado <= filter.Devengado_To)
					  && (filter.Pagado == null || o.Pagado >=  filter.Pagado) && (filter.Pagado_To == null || o.Pagado <= filter.Pagado_To)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<TransferenciaDetalleResult> QueryResult(TransferenciaDetalleFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.FinalidadFuncions on o.IdFinalidadFuncion equals t1.IdFinalidadFuncion   
				    join t2  in this.Context.FuenteFinanciamientos on o.IdFuenteFinanciamiento equals t2.IdFuenteFinanciamiento   
				    join t3  in this.Context.Monedas on o.IdMoneda equals t3.IdMoneda   
				    join t4  in this.Context.Transferencias on o.IdTransferencia equals t4.IdTransferencia   
				   select new TransferenciaDetalleResult(){
					 IdTransferenciaDetalle=o.IdTransferenciaDetalle
					 ,IdTransferencia=o.IdTransferencia
					 //,Anio=o.Anio
					 ,IdFuenteFinanciamiento=o.IdFuenteFinanciamiento
					 ,IdMoneda=o.IdMoneda
					 ,IdFinalidadFuncion=o.IdFinalidadFuncion
					 ,Inicial=o.Inicial
					 ,Vigente=o.Vigente
					 ,Comprometido=o.Comprometido
					 ,Devengado=o.Devengado
					 ,Pagado=o.Pagado
                    //,FinalidadFuncion_Codigo= t1.Codigo	
                    //    ,FinalidadFuncion_Denominacion= t1.Denominacion	
                    //    ,FinalidadFuncion_Activo= t1.Activo	
                    //    ,FinalidadFuncion_IdFinalidadFunciontipo= t1.IdFinalidadFunciontipo	
                    //    ,FinalidadFuncion_IdFinalidadFuncionPadre= t1.IdFinalidadFuncionPadre	
                    //    ,FinalidadFuncion_BreadcrumbId= t1.BreadcrumbId	
                    //    ,FinalidadFuncion_BreadcrumbOrden= t1.BreadcrumbOrden	
                    //    ,FinalidadFuncion_Nivel= t1.Nivel	
                    //    ,FinalidadFuncion_Orden= t1.Orden	
                    //    ,FinalidadFuncion_Descripcion= t1.Descripcion	
                    //    ,FinalidadFuncion_DescripcionInvertida= t1.DescripcionInvertida	
                    //    ,FinalidadFuncion_Seleccionable= t1.Seleccionable	
                    //    ,FinalidadFuncion_BreadcrumbCode= t1.BreadcrumbCode	
                    //    ,FinalidadFuncion_DescripcionCodigo= t1.DescripcionCodigo	
                    //    ,FuenteFinanciamiento_Codigo= t2.Codigo	
                    //    ,FuenteFinanciamiento_Nombre= t2.Nombre	
                    //    ,FuenteFinanciamiento_IdFuenteFinanciamientoTipo= t2.IdFuenteFinanciamientoTipo	
                    //    ,FuenteFinanciamiento_Activo= t2.Activo	
                    //    ,FuenteFinanciamiento_IdFuenteFinanciamientoPadre= t2.IdFuenteFinanciamientoPadre	
                    //    ,FuenteFinanciamiento_BreadcrumbId= t2.BreadcrumbId	
                    //    ,FuenteFinanciamiento_BreadcrumbOrden= t2.BreadcrumbOrden	
                    //    ,FuenteFinanciamiento_Nivel= t2.Nivel	
                    //    ,FuenteFinanciamiento_Orden= t2.Orden	
                    //    ,FuenteFinanciamiento_Descripcion= t2.Descripcion	
                    //    ,FuenteFinanciamiento_DescripcionInvertida= t2.DescripcionInvertida	
                    //    ,FuenteFinanciamiento_Seleccionable= t2.Seleccionable	
                    //    ,FuenteFinanciamiento_BreadcrumbCode= t2.BreadcrumbCode	
                    //    ,FuenteFinanciamiento_DescripcionCodigo= t2.DescripcionCodigo	
                    //    ,Moneda_Sigla= t3.Sigla	
                    //    ,Moneda_Nombre= t3.Nombre	
                    //    ,Moneda_Activo= t3.Activo	
                    //    ,Moneda_Base= t3.Base	
                        //,Transferencia_IdSubPrograma= t4.IdSubPrograma	
                        //,Transferencia_Proyecto= t4.Proyecto	
                        //,Transferencia_Actividad= t4.Actividad	
                        //,Transferencia_Obra= t4.Obra	
                        //,Transferencia_Denominacion= t4.Denominacion	
                        //,Transferencia_IdClasificacionGasto= t4.IdClasificacionGasto	
                        //,Transferencia_IdClasificacionGeografica= t4.IdClasificacionGeografica	
                        //,Transferencia_Activo= t4.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.TransferenciaDetalle Copy(nc.TransferenciaDetalle entity)
        {           
            nc.TransferenciaDetalle _new = new nc.TransferenciaDetalle();
		 _new.IdTransferencia= entity.IdTransferencia;
		// _new.Anio= entity.Anio;
		 _new.IdFuenteFinanciamiento= entity.IdFuenteFinanciamiento;
		 _new.IdMoneda= entity.IdMoneda;
		 _new.IdFinalidadFuncion= entity.IdFinalidadFuncion;
		 _new.Inicial= entity.Inicial;
		 _new.Vigente= entity.Vigente;
		 _new.Comprometido= entity.Comprometido;
		 _new.Devengado= entity.Devengado;
		 _new.Pagado= entity.Pagado;
		return _new;			
        }
		public override int CopyAndSave(TransferenciaDetalle entity,string renameFormat)
        {
            TransferenciaDetalle  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(TransferenciaDetalle entity, int id)
        {            
            entity.IdTransferenciaDetalle = id;            
        }
		public override void Set(TransferenciaDetalle source,TransferenciaDetalle target,bool hadSetId)
		{		   
		if(hadSetId)target.IdTransferenciaDetalle= source.IdTransferenciaDetalle ;
		 target.IdTransferencia= source.IdTransferencia ;
		 //target.Anio= source.Anio ;
		 target.IdFuenteFinanciamiento= source.IdFuenteFinanciamiento ;
		 target.IdMoneda= source.IdMoneda ;
		 target.IdFinalidadFuncion= source.IdFinalidadFuncion ;
		 target.Inicial= source.Inicial ;
		 target.Vigente= source.Vigente ;
		 target.Comprometido= source.Comprometido ;
		 target.Devengado= source.Devengado ;
		 target.Pagado= source.Pagado ;
		 		  
		}
		public override void Set(TransferenciaDetalleResult source,TransferenciaDetalle target,bool hadSetId)
		{		   
		if(hadSetId)target.IdTransferenciaDetalle= source.IdTransferenciaDetalle ;
		 target.IdTransferencia= source.IdTransferencia ;
		 //target.Anio= source.Anio ;
		 target.IdFuenteFinanciamiento= source.IdFuenteFinanciamiento ;
		 target.IdMoneda= source.IdMoneda ;
		 target.IdFinalidadFuncion= source.IdFinalidadFuncion ;
		 target.Inicial= source.Inicial ;
		 target.Vigente= source.Vigente ;
		 target.Comprometido= source.Comprometido ;
		 target.Devengado= source.Devengado ;
		 target.Pagado= source.Pagado ;
		 
		}
		public override void Set(TransferenciaDetalle source,TransferenciaDetalleResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdTransferenciaDetalle= source.IdTransferenciaDetalle ;
		 target.IdTransferencia= source.IdTransferencia ;
		 //target.Anio= source.Anio ;
		 target.IdFuenteFinanciamiento= source.IdFuenteFinanciamiento ;
		 target.IdMoneda= source.IdMoneda ;
		 target.IdFinalidadFuncion= source.IdFinalidadFuncion ;
		 target.Inicial= source.Inicial ;
		 target.Vigente= source.Vigente ;
		 target.Comprometido= source.Comprometido ;
		 target.Devengado= source.Devengado ;
		 target.Pagado= source.Pagado ;
		 	
		}		
		public override void Set(TransferenciaDetalleResult source,TransferenciaDetalleResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdTransferenciaDetalle= source.IdTransferenciaDetalle ;
		 target.IdTransferencia= source.IdTransferencia ;
		 //target.Anio= source.Anio ;
		 target.IdFuenteFinanciamiento= source.IdFuenteFinanciamiento ;
		 target.IdMoneda= source.IdMoneda ;
		 target.IdFinalidadFuncion= source.IdFinalidadFuncion ;
		 target.Inicial= source.Inicial ;
		 target.Vigente= source.Vigente ;
		 target.Comprometido= source.Comprometido ;
		 target.Devengado= source.Devengado ;
		 target.Pagado= source.Pagado ;
         //target.FinalidadFuncion_Codigo= source.FinalidadFuncion_Codigo;	
         //   target.FinalidadFuncion_Denominacion= source.FinalidadFuncion_Denominacion;	
         //   target.FinalidadFuncion_Activo= source.FinalidadFuncion_Activo;	
         //   target.FinalidadFuncion_IdFinalidadFunciontipo= source.FinalidadFuncion_IdFinalidadFunciontipo;	
         //   target.FinalidadFuncion_IdFinalidadFuncionPadre= source.FinalidadFuncion_IdFinalidadFuncionPadre;	
         //   target.FinalidadFuncion_BreadcrumbId= source.FinalidadFuncion_BreadcrumbId;	
         //   target.FinalidadFuncion_BreadcrumbOrden= source.FinalidadFuncion_BreadcrumbOrden;	
         //   target.FinalidadFuncion_Nivel= source.FinalidadFuncion_Nivel;	
         //   target.FinalidadFuncion_Orden= source.FinalidadFuncion_Orden;	
         //   target.FinalidadFuncion_Descripcion= source.FinalidadFuncion_Descripcion;	
         //   target.FinalidadFuncion_DescripcionInvertida= source.FinalidadFuncion_DescripcionInvertida;	
         //   target.FinalidadFuncion_Seleccionable= source.FinalidadFuncion_Seleccionable;	
         //   target.FinalidadFuncion_BreadcrumbCode= source.FinalidadFuncion_BreadcrumbCode;	
         //   target.FinalidadFuncion_DescripcionCodigo= source.FinalidadFuncion_DescripcionCodigo;	
         //   target.FuenteFinanciamiento_Codigo= source.FuenteFinanciamiento_Codigo;	
         //   target.FuenteFinanciamiento_Nombre= source.FuenteFinanciamiento_Nombre;	
         //   target.FuenteFinanciamiento_IdFuenteFinanciamientoTipo= source.FuenteFinanciamiento_IdFuenteFinanciamientoTipo;	
         //   target.FuenteFinanciamiento_Activo= source.FuenteFinanciamiento_Activo;	
         //   target.FuenteFinanciamiento_IdFuenteFinanciamientoPadre= source.FuenteFinanciamiento_IdFuenteFinanciamientoPadre;	
         //   target.FuenteFinanciamiento_BreadcrumbId= source.FuenteFinanciamiento_BreadcrumbId;	
         //   target.FuenteFinanciamiento_BreadcrumbOrden= source.FuenteFinanciamiento_BreadcrumbOrden;	
         //   target.FuenteFinanciamiento_Nivel= source.FuenteFinanciamiento_Nivel;	
         //   target.FuenteFinanciamiento_Orden= source.FuenteFinanciamiento_Orden;	
         //   target.FuenteFinanciamiento_Descripcion= source.FuenteFinanciamiento_Descripcion;	
         //   target.FuenteFinanciamiento_DescripcionInvertida= source.FuenteFinanciamiento_DescripcionInvertida;	
         //   target.FuenteFinanciamiento_Seleccionable= source.FuenteFinanciamiento_Seleccionable;	
         //   target.FuenteFinanciamiento_BreadcrumbCode= source.FuenteFinanciamiento_BreadcrumbCode;	
         //   target.FuenteFinanciamiento_DescripcionCodigo= source.FuenteFinanciamiento_DescripcionCodigo;	
         //   target.Moneda_Sigla= source.Moneda_Sigla;	
         //   target.Moneda_Nombre= source.Moneda_Nombre;	
         //   target.Moneda_Activo= source.Moneda_Activo;	
         //   target.Moneda_Base= source.Moneda_Base;	
         //   target.Transferencia_IdSubPrograma= source.Transferencia_IdSubPrograma;	
         //   target.Transferencia_Proyecto= source.Transferencia_Proyecto;	
         //   target.Transferencia_Actividad= source.Transferencia_Actividad;	
         //   target.Transferencia_Obra= source.Transferencia_Obra;	
         //   target.Transferencia_Denominacion= source.Transferencia_Denominacion;	
         //   target.Transferencia_IdClasificacionGasto= source.Transferencia_IdClasificacionGasto;	
         //   target.Transferencia_IdClasificacionGeografica= source.Transferencia_IdClasificacionGeografica;	
         //   target.Transferencia_Activo= source.Transferencia_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(TransferenciaDetalle source,TransferenciaDetalle target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdTransferenciaDetalle.Equals(target.IdTransferenciaDetalle))return false;
		  if(!source.IdTransferencia.Equals(target.IdTransferencia))return false;
		  //if(!source.Anio.Equals(target.Anio))return false;
		  if(!source.IdFuenteFinanciamiento.Equals(target.IdFuenteFinanciamiento))return false;
		  if(!source.IdMoneda.Equals(target.IdMoneda))return false;
		  if(!source.IdFinalidadFuncion.Equals(target.IdFinalidadFuncion))return false;
		  if(!source.Inicial.Equals(target.Inicial))return false;
		  if(!source.Vigente.Equals(target.Vigente))return false;
		  if(!source.Comprometido.Equals(target.Comprometido))return false;
		  if(!source.Devengado.Equals(target.Devengado))return false;
		  if(!source.Pagado.Equals(target.Pagado))return false;
		 
		  return true;
        }
		public override bool Equals(TransferenciaDetalleResult source,TransferenciaDetalleResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdTransferenciaDetalle.Equals(target.IdTransferenciaDetalle))return false;
		  if(!source.IdTransferencia.Equals(target.IdTransferencia))return false;
		  //if(!source.Anio.Equals(target.Anio))return false;
		  if(!source.IdFuenteFinanciamiento.Equals(target.IdFuenteFinanciamiento))return false;
		  if(!source.IdMoneda.Equals(target.IdMoneda))return false;
		  if(!source.IdFinalidadFuncion.Equals(target.IdFinalidadFuncion))return false;
		  if(!source.Inicial.Equals(target.Inicial))return false;
		  if(!source.Vigente.Equals(target.Vigente))return false;
		  if(!source.Comprometido.Equals(target.Comprometido))return false;
		  if(!source.Devengado.Equals(target.Devengado))return false;
		  if(!source.Pagado.Equals(target.Pagado))return false;
          //if((source.FinalidadFuncion_Codigo == null)?target.FinalidadFuncion_Codigo!=null: !( (target.FinalidadFuncion_Codigo== String.Empty && source.FinalidadFuncion_Codigo== null) || (target.FinalidadFuncion_Codigo==null && source.FinalidadFuncion_Codigo== String.Empty )) &&   !source.FinalidadFuncion_Codigo.Trim().Replace ("\r","").Equals(target.FinalidadFuncion_Codigo.Trim().Replace ("\r","")))return false;
          //               if((source.FinalidadFuncion_Denominacion == null)?target.FinalidadFuncion_Denominacion!=null: !( (target.FinalidadFuncion_Denominacion== String.Empty && source.FinalidadFuncion_Denominacion== null) || (target.FinalidadFuncion_Denominacion==null && source.FinalidadFuncion_Denominacion== String.Empty )) &&   !source.FinalidadFuncion_Denominacion.Trim().Replace ("\r","").Equals(target.FinalidadFuncion_Denominacion.Trim().Replace ("\r","")))return false;
          //               if(!source.FinalidadFuncion_Activo.Equals(target.FinalidadFuncion_Activo))return false;
          //            if((source.FinalidadFuncion_IdFinalidadFunciontipo == null)?(target.FinalidadFuncion_IdFinalidadFunciontipo.HasValue && target.FinalidadFuncion_IdFinalidadFunciontipo.Value > 0):!source.FinalidadFuncion_IdFinalidadFunciontipo.Equals(target.FinalidadFuncion_IdFinalidadFunciontipo))return false;
          //                            if((source.FinalidadFuncion_IdFinalidadFuncionPadre == null)?(target.FinalidadFuncion_IdFinalidadFuncionPadre.HasValue && target.FinalidadFuncion_IdFinalidadFuncionPadre.Value > 0):!source.FinalidadFuncion_IdFinalidadFuncionPadre.Equals(target.FinalidadFuncion_IdFinalidadFuncionPadre))return false;
          //                            if((source.FinalidadFuncion_BreadcrumbId == null)?target.FinalidadFuncion_BreadcrumbId!=null: !( (target.FinalidadFuncion_BreadcrumbId== String.Empty && source.FinalidadFuncion_BreadcrumbId== null) || (target.FinalidadFuncion_BreadcrumbId==null && source.FinalidadFuncion_BreadcrumbId== String.Empty )) &&   !source.FinalidadFuncion_BreadcrumbId.Trim().Replace ("\r","").Equals(target.FinalidadFuncion_BreadcrumbId.Trim().Replace ("\r","")))return false;
          //               if((source.FinalidadFuncion_BreadcrumbOrden == null)?target.FinalidadFuncion_BreadcrumbOrden!=null: !( (target.FinalidadFuncion_BreadcrumbOrden== String.Empty && source.FinalidadFuncion_BreadcrumbOrden== null) || (target.FinalidadFuncion_BreadcrumbOrden==null && source.FinalidadFuncion_BreadcrumbOrden== String.Empty )) &&   !source.FinalidadFuncion_BreadcrumbOrden.Trim().Replace ("\r","").Equals(target.FinalidadFuncion_BreadcrumbOrden.Trim().Replace ("\r","")))return false;
          //               if((source.FinalidadFuncion_Nivel == null)?(target.FinalidadFuncion_Nivel.HasValue ):!source.FinalidadFuncion_Nivel.Equals(target.FinalidadFuncion_Nivel))return false;
          //               if((source.FinalidadFuncion_Orden == null)?(target.FinalidadFuncion_Orden.HasValue ):!source.FinalidadFuncion_Orden.Equals(target.FinalidadFuncion_Orden))return false;
          //               if((source.FinalidadFuncion_Descripcion == null)?target.FinalidadFuncion_Descripcion!=null: !( (target.FinalidadFuncion_Descripcion== String.Empty && source.FinalidadFuncion_Descripcion== null) || (target.FinalidadFuncion_Descripcion==null && source.FinalidadFuncion_Descripcion== String.Empty )) &&   !source.FinalidadFuncion_Descripcion.Trim().Replace ("\r","").Equals(target.FinalidadFuncion_Descripcion.Trim().Replace ("\r","")))return false;
          //               if((source.FinalidadFuncion_DescripcionInvertida == null)?target.FinalidadFuncion_DescripcionInvertida!=null: !( (target.FinalidadFuncion_DescripcionInvertida== String.Empty && source.FinalidadFuncion_DescripcionInvertida== null) || (target.FinalidadFuncion_DescripcionInvertida==null && source.FinalidadFuncion_DescripcionInvertida== String.Empty )) &&   !source.FinalidadFuncion_DescripcionInvertida.Trim().Replace ("\r","").Equals(target.FinalidadFuncion_DescripcionInvertida.Trim().Replace ("\r","")))return false;
          //               if(!source.FinalidadFuncion_Seleccionable.Equals(target.FinalidadFuncion_Seleccionable))return false;
          //            if((source.FinalidadFuncion_BreadcrumbCode == null)?target.FinalidadFuncion_BreadcrumbCode!=null: !( (target.FinalidadFuncion_BreadcrumbCode== String.Empty && source.FinalidadFuncion_BreadcrumbCode== null) || (target.FinalidadFuncion_BreadcrumbCode==null && source.FinalidadFuncion_BreadcrumbCode== String.Empty )) &&   !source.FinalidadFuncion_BreadcrumbCode.Trim().Replace ("\r","").Equals(target.FinalidadFuncion_BreadcrumbCode.Trim().Replace ("\r","")))return false;
          //               if((source.FinalidadFuncion_DescripcionCodigo == null)?target.FinalidadFuncion_DescripcionCodigo!=null: !( (target.FinalidadFuncion_DescripcionCodigo== String.Empty && source.FinalidadFuncion_DescripcionCodigo== null) || (target.FinalidadFuncion_DescripcionCodigo==null && source.FinalidadFuncion_DescripcionCodigo== String.Empty )) &&   !source.FinalidadFuncion_DescripcionCodigo.Trim().Replace ("\r","").Equals(target.FinalidadFuncion_DescripcionCodigo.Trim().Replace ("\r","")))return false;
          //               if((source.FuenteFinanciamiento_Codigo == null)?target.FuenteFinanciamiento_Codigo!=null: !( (target.FuenteFinanciamiento_Codigo== String.Empty && source.FuenteFinanciamiento_Codigo== null) || (target.FuenteFinanciamiento_Codigo==null && source.FuenteFinanciamiento_Codigo== String.Empty )) &&   !source.FuenteFinanciamiento_Codigo.Trim().Replace ("\r","").Equals(target.FuenteFinanciamiento_Codigo.Trim().Replace ("\r","")))return false;
          //               if((source.FuenteFinanciamiento_Nombre == null)?target.FuenteFinanciamiento_Nombre!=null: !( (target.FuenteFinanciamiento_Nombre== String.Empty && source.FuenteFinanciamiento_Nombre== null) || (target.FuenteFinanciamiento_Nombre==null && source.FuenteFinanciamiento_Nombre== String.Empty )) &&   !source.FuenteFinanciamiento_Nombre.Trim().Replace ("\r","").Equals(target.FuenteFinanciamiento_Nombre.Trim().Replace ("\r","")))return false;
          //               if(!source.FuenteFinanciamiento_IdFuenteFinanciamientoTipo.Equals(target.FuenteFinanciamiento_IdFuenteFinanciamientoTipo))return false;
          //            if(!source.FuenteFinanciamiento_Activo.Equals(target.FuenteFinanciamiento_Activo))return false;
          //            if((source.FuenteFinanciamiento_IdFuenteFinanciamientoPadre == null)?(target.FuenteFinanciamiento_IdFuenteFinanciamientoPadre.HasValue && target.FuenteFinanciamiento_IdFuenteFinanciamientoPadre.Value > 0):!source.FuenteFinanciamiento_IdFuenteFinanciamientoPadre.Equals(target.FuenteFinanciamiento_IdFuenteFinanciamientoPadre))return false;
          //                            if((source.FuenteFinanciamiento_BreadcrumbId == null)?target.FuenteFinanciamiento_BreadcrumbId!=null: !( (target.FuenteFinanciamiento_BreadcrumbId== String.Empty && source.FuenteFinanciamiento_BreadcrumbId== null) || (target.FuenteFinanciamiento_BreadcrumbId==null && source.FuenteFinanciamiento_BreadcrumbId== String.Empty )) &&   !source.FuenteFinanciamiento_BreadcrumbId.Trim().Replace ("\r","").Equals(target.FuenteFinanciamiento_BreadcrumbId.Trim().Replace ("\r","")))return false;
          //               if((source.FuenteFinanciamiento_BreadcrumbOrden == null)?target.FuenteFinanciamiento_BreadcrumbOrden!=null: !( (target.FuenteFinanciamiento_BreadcrumbOrden== String.Empty && source.FuenteFinanciamiento_BreadcrumbOrden== null) || (target.FuenteFinanciamiento_BreadcrumbOrden==null && source.FuenteFinanciamiento_BreadcrumbOrden== String.Empty )) &&   !source.FuenteFinanciamiento_BreadcrumbOrden.Trim().Replace ("\r","").Equals(target.FuenteFinanciamiento_BreadcrumbOrden.Trim().Replace ("\r","")))return false;
          //               if((source.FuenteFinanciamiento_Nivel == null)?(target.FuenteFinanciamiento_Nivel.HasValue ):!source.FuenteFinanciamiento_Nivel.Equals(target.FuenteFinanciamiento_Nivel))return false;
          //               if((source.FuenteFinanciamiento_Orden == null)?(target.FuenteFinanciamiento_Orden.HasValue ):!source.FuenteFinanciamiento_Orden.Equals(target.FuenteFinanciamiento_Orden))return false;
          //               if((source.FuenteFinanciamiento_Descripcion == null)?target.FuenteFinanciamiento_Descripcion!=null: !( (target.FuenteFinanciamiento_Descripcion== String.Empty && source.FuenteFinanciamiento_Descripcion== null) || (target.FuenteFinanciamiento_Descripcion==null && source.FuenteFinanciamiento_Descripcion== String.Empty )) &&   !source.FuenteFinanciamiento_Descripcion.Trim().Replace ("\r","").Equals(target.FuenteFinanciamiento_Descripcion.Trim().Replace ("\r","")))return false;
          //               if((source.FuenteFinanciamiento_DescripcionInvertida == null)?target.FuenteFinanciamiento_DescripcionInvertida!=null: !( (target.FuenteFinanciamiento_DescripcionInvertida== String.Empty && source.FuenteFinanciamiento_DescripcionInvertida== null) || (target.FuenteFinanciamiento_DescripcionInvertida==null && source.FuenteFinanciamiento_DescripcionInvertida== String.Empty )) &&   !source.FuenteFinanciamiento_DescripcionInvertida.Trim().Replace ("\r","").Equals(target.FuenteFinanciamiento_DescripcionInvertida.Trim().Replace ("\r","")))return false;
          //               if(!source.FuenteFinanciamiento_Seleccionable.Equals(target.FuenteFinanciamiento_Seleccionable))return false;
          //            if((source.FuenteFinanciamiento_BreadcrumbCode == null)?target.FuenteFinanciamiento_BreadcrumbCode!=null: !( (target.FuenteFinanciamiento_BreadcrumbCode== String.Empty && source.FuenteFinanciamiento_BreadcrumbCode== null) || (target.FuenteFinanciamiento_BreadcrumbCode==null && source.FuenteFinanciamiento_BreadcrumbCode== String.Empty )) &&   !source.FuenteFinanciamiento_BreadcrumbCode.Trim().Replace ("\r","").Equals(target.FuenteFinanciamiento_BreadcrumbCode.Trim().Replace ("\r","")))return false;
          //               if((source.FuenteFinanciamiento_DescripcionCodigo == null)?target.FuenteFinanciamiento_DescripcionCodigo!=null: !( (target.FuenteFinanciamiento_DescripcionCodigo== String.Empty && source.FuenteFinanciamiento_DescripcionCodigo== null) || (target.FuenteFinanciamiento_DescripcionCodigo==null && source.FuenteFinanciamiento_DescripcionCodigo== String.Empty )) &&   !source.FuenteFinanciamiento_DescripcionCodigo.Trim().Replace ("\r","").Equals(target.FuenteFinanciamiento_DescripcionCodigo.Trim().Replace ("\r","")))return false;
          //               if((source.Moneda_Sigla == null)?target.Moneda_Sigla!=null: !( (target.Moneda_Sigla== String.Empty && source.Moneda_Sigla== null) || (target.Moneda_Sigla==null && source.Moneda_Sigla== String.Empty )) &&   !source.Moneda_Sigla.Trim().Replace ("\r","").Equals(target.Moneda_Sigla.Trim().Replace ("\r","")))return false;
          //               if((source.Moneda_Nombre == null)?target.Moneda_Nombre!=null: !( (target.Moneda_Nombre== String.Empty && source.Moneda_Nombre== null) || (target.Moneda_Nombre==null && source.Moneda_Nombre== String.Empty )) &&   !source.Moneda_Nombre.Trim().Replace ("\r","").Equals(target.Moneda_Nombre.Trim().Replace ("\r","")))return false;
          //               if(!source.Moneda_Activo.Equals(target.Moneda_Activo))return false;
          //            if(!source.Moneda_Base.Equals(target.Moneda_Base))return false;
          //            if(!source.Transferencia_IdSubPrograma.Equals(target.Transferencia_IdSubPrograma))return false;
          //            if(!source.Transferencia_Proyecto.Equals(target.Transferencia_Proyecto))return false;
          //            if(!source.Transferencia_Actividad.Equals(target.Transferencia_Actividad))return false;
          //            if(!source.Transferencia_Obra.Equals(target.Transferencia_Obra))return false;
          //            if((source.Transferencia_Denominacion == null)?target.Transferencia_Denominacion!=null: !( (target.Transferencia_Denominacion== String.Empty && source.Transferencia_Denominacion== null) || (target.Transferencia_Denominacion==null && source.Transferencia_Denominacion== String.Empty )) &&   !source.Transferencia_Denominacion.Trim().Replace ("\r","").Equals(target.Transferencia_Denominacion.Trim().Replace ("\r","")))return false;
          //               if(!source.Transferencia_IdClasificacionGasto.Equals(target.Transferencia_IdClasificacionGasto))return false;
          //            if(!source.Transferencia_IdClasificacionGeografica.Equals(target.Transferencia_IdClasificacionGeografica))return false;
          //            if(!source.Transferencia_Activo.Equals(target.Transferencia_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}

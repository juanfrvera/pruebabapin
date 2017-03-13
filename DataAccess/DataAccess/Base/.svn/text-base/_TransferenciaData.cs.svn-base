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
    public abstract class _TransferenciaData : EntityData<Transferencia,TransferenciaFilter,TransferenciaResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Transferencia entity)
		{			
			return entity.IdTransferencia;
		}		
		public override Transferencia GetByEntity(Transferencia entity)
        {
            return this.GetById(entity.IdTransferencia);
        }
        public override Transferencia GetById(int id)
        {
            return (from o in this.Table where o.IdTransferencia == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Transferencia> Query(TransferenciaFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdTransferencia == null || filter.IdTransferencia == 0 || o.IdTransferencia==filter.IdTransferencia)
					  && (filter.IdSubPrograma == null || filter.IdSubPrograma == 0 || o.IdSubPrograma==filter.IdSubPrograma)
					  && (filter.Proyecto == null || o.Proyecto >=  filter.Proyecto) && (filter.Proyecto_To == null || o.Proyecto <= filter.Proyecto_To)
					  && (filter.Actividad == null || o.Actividad >=  filter.Actividad) && (filter.Actividad_To == null || o.Actividad <= filter.Actividad_To)
					  && (filter.Obra == null || o.Obra >=  filter.Obra) && (filter.Obra_To == null || o.Obra <= filter.Obra_To)
					  && (filter.Denominacion == null || filter.Denominacion.Trim() == string.Empty || filter.Denominacion.Trim() == "%"  || (filter.Denominacion.EndsWith("%") && filter.Denominacion.StartsWith("%") && (o.Denominacion.Contains(filter.Denominacion.Replace("%", "")))) || (filter.Denominacion.EndsWith("%") && o.Denominacion.StartsWith(filter.Denominacion.Replace("%",""))) || (filter.Denominacion.StartsWith("%") && o.Denominacion.EndsWith(filter.Denominacion.Replace("%",""))) || o.Denominacion == filter.Denominacion )
					  && (filter.IdClasificacionGasto == null || filter.IdClasificacionGasto == 0 || o.IdClasificacionGasto==filter.IdClasificacionGasto)
					  && (filter.IdClasificacionGeografica == null || filter.IdClasificacionGeografica == 0 || o.IdClasificacionGeografica==filter.IdClasificacionGeografica)
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<TransferenciaResult> QueryResult(TransferenciaFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.ClasificacionGastos on o.IdClasificacionGasto equals t1.IdClasificacionGasto   
				    join t2  in this.Context.ClasificacionGeograficas on o.IdClasificacionGeografica equals t2.IdClasificacionGeografica   
				    join t3  in this.Context.SubProgramas on o.IdSubPrograma equals t3.IdSubPrograma   
				   select new TransferenciaResult(){
					 IdTransferencia=o.IdTransferencia
					 ,IdSubPrograma=o.IdSubPrograma
					 ,Proyecto=o.Proyecto
					 ,Actividad=o.Actividad
					 ,Obra=o.Obra
					 ,Denominacion=o.Denominacion
					 ,IdClasificacionGasto=o.IdClasificacionGasto
					 ,IdClasificacionGeografica=o.IdClasificacionGeografica
					 ,Activo=o.Activo
					,ClasificacionGasto_Codigo= t1.Codigo	
						,ClasificacionGasto_Nombre= t1.Nombre	
						,ClasificacionGasto_IdClasificacionGastoTipo= t1.IdClasificacionGastoTipo	
						,ClasificacionGasto_IdCaracterEconomico= t1.IdCaracterEconomico	
						,ClasificacionGasto_Activo= t1.Activo	
						,ClasificacionGasto_IdClasificacionGastoPadre= t1.IdClasificacionGastoPadre	
						,ClasificacionGasto_BreadcrumbId= t1.BreadcrumbId	
						,ClasificacionGasto_BreadcrumbOrden= t1.BreadcrumbOrden	
						,ClasificacionGasto_Nivel= t1.Nivel	
						,ClasificacionGasto_Orden= t1.Orden	
						,ClasificacionGasto_Descripcion= t1.Descripcion	
						,ClasificacionGasto_DescripcionInvertida= t1.DescripcionInvertida	
						,ClasificacionGasto_IdClasificacionGastoRubro= t1.IdClasificacionGastoRubro	
						,ClasificacionGasto_Seleccionable= t1.Seleccionable	
						,ClasificacionGasto_BreadcrumbCode= t1.BreadcrumbCode	
						,ClasificacionGasto_DescripcionCodigo= t1.DescripcionCodigo	
						,ClasificacionGeografica_Codigo= t2.Codigo	
						,ClasificacionGeografica_Nombre= t2.Nombre	
						,ClasificacionGeografica_IdClasificacionGeograficaTipo= t2.IdClasificacionGeograficaTipo	
						,ClasificacionGeografica_IdClasificacionGeograficaPadre= t2.IdClasificacionGeograficaPadre	
						,ClasificacionGeografica_Activo= t2.Activo	
						,ClasificacionGeografica_Descripcion= t2.Descripcion	
						,ClasificacionGeografica_BreadcrumbId= t2.BreadcrumbId	
						,ClasificacionGeografica_BreadcrumOrden= t2.BreadcrumOrden	
						,ClasificacionGeografica_Orden= t2.Orden	
						,ClasificacionGeografica_Nivel= t2.Nivel	
						,ClasificacionGeografica_DescripcionInvertida= t2.DescripcionInvertida	
						,ClasificacionGeografica_Seleccionable= t2.Seleccionable	
						,ClasificacionGeografica_BreadcrumbCode= t2.BreadcrumbCode	
						,ClasificacionGeografica_DescripcionCodigo= t2.DescripcionCodigo	
						,SubPrograma_IdPrograma= t3.IdPrograma	
						,SubPrograma_Codigo= t3.Codigo	
						,SubPrograma_Nombre= t3.Nombre	
						,SubPrograma_FechaAlta= t3.FechaAlta	
						,SubPrograma_FechaBaja= t3.FechaBaja	
						,SubPrograma_Activo= t3.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Transferencia Copy(nc.Transferencia entity)
        {           
            nc.Transferencia _new = new nc.Transferencia();
		 _new.IdSubPrograma= entity.IdSubPrograma;
		 _new.Proyecto= entity.Proyecto;
		 _new.Actividad= entity.Actividad;
		 _new.Obra= entity.Obra;
		 _new.Denominacion= entity.Denominacion;
		 _new.IdClasificacionGasto= entity.IdClasificacionGasto;
		 _new.IdClasificacionGeografica= entity.IdClasificacionGeografica;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(Transferencia entity,string renameFormat)
        {
            Transferencia  newEntity = Copy(entity);
            newEntity.Denominacion = string.Format(renameFormat,newEntity.Denominacion);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Transferencia entity, int id)
        {            
            entity.IdTransferencia = id;            
        }
		public override void Set(Transferencia source,Transferencia target,bool hadSetId)
		{		   
		if(hadSetId)target.IdTransferencia= source.IdTransferencia ;
		 target.IdSubPrograma= source.IdSubPrograma ;
		 target.Proyecto= source.Proyecto ;
		 target.Actividad= source.Actividad ;
		 target.Obra= source.Obra ;
		 target.Denominacion= source.Denominacion ;
		 target.IdClasificacionGasto= source.IdClasificacionGasto ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(TransferenciaResult source,Transferencia target,bool hadSetId)
		{		   
		if(hadSetId)target.IdTransferencia= source.IdTransferencia ;
		 target.IdSubPrograma= source.IdSubPrograma ;
		 target.Proyecto= source.Proyecto ;
		 target.Actividad= source.Actividad ;
		 target.Obra= source.Obra ;
		 target.Denominacion= source.Denominacion ;
		 target.IdClasificacionGasto= source.IdClasificacionGasto ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(Transferencia source,TransferenciaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdTransferencia= source.IdTransferencia ;
		 target.IdSubPrograma= source.IdSubPrograma ;
		 target.Proyecto= source.Proyecto ;
		 target.Actividad= source.Actividad ;
		 target.Obra= source.Obra ;
		 target.Denominacion= source.Denominacion ;
		 target.IdClasificacionGasto= source.IdClasificacionGasto ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(TransferenciaResult source,TransferenciaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdTransferencia= source.IdTransferencia ;
		 target.IdSubPrograma= source.IdSubPrograma ;
		 target.Proyecto= source.Proyecto ;
		 target.Actividad= source.Actividad ;
		 target.Obra= source.Obra ;
		 target.Denominacion= source.Denominacion ;
		 target.IdClasificacionGasto= source.IdClasificacionGasto ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 target.Activo= source.Activo ;
		 target.ClasificacionGasto_Codigo= source.ClasificacionGasto_Codigo;	
			target.ClasificacionGasto_Nombre= source.ClasificacionGasto_Nombre;	
			target.ClasificacionGasto_IdClasificacionGastoTipo= source.ClasificacionGasto_IdClasificacionGastoTipo;	
			target.ClasificacionGasto_IdCaracterEconomico= source.ClasificacionGasto_IdCaracterEconomico;	
			target.ClasificacionGasto_Activo= source.ClasificacionGasto_Activo;	
			target.ClasificacionGasto_IdClasificacionGastoPadre= source.ClasificacionGasto_IdClasificacionGastoPadre;	
			target.ClasificacionGasto_BreadcrumbId= source.ClasificacionGasto_BreadcrumbId;	
			target.ClasificacionGasto_BreadcrumbOrden= source.ClasificacionGasto_BreadcrumbOrden;	
			target.ClasificacionGasto_Nivel= source.ClasificacionGasto_Nivel;	
			target.ClasificacionGasto_Orden= source.ClasificacionGasto_Orden;	
			target.ClasificacionGasto_Descripcion= source.ClasificacionGasto_Descripcion;	
			target.ClasificacionGasto_DescripcionInvertida= source.ClasificacionGasto_DescripcionInvertida;	
			target.ClasificacionGasto_IdClasificacionGastoRubro= source.ClasificacionGasto_IdClasificacionGastoRubro;	
			target.ClasificacionGasto_Seleccionable= source.ClasificacionGasto_Seleccionable;	
			target.ClasificacionGasto_BreadcrumbCode= source.ClasificacionGasto_BreadcrumbCode;	
			target.ClasificacionGasto_DescripcionCodigo= source.ClasificacionGasto_DescripcionCodigo;	
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
			target.SubPrograma_IdPrograma= source.SubPrograma_IdPrograma;	
			target.SubPrograma_Codigo= source.SubPrograma_Codigo;	
			target.SubPrograma_Nombre= source.SubPrograma_Nombre;	
			target.SubPrograma_FechaAlta= source.SubPrograma_FechaAlta;	
			target.SubPrograma_FechaBaja= source.SubPrograma_FechaBaja;	
			target.SubPrograma_Activo= source.SubPrograma_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(Transferencia source,Transferencia target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdTransferencia.Equals(target.IdTransferencia))return false;
		  if(!source.IdSubPrograma.Equals(target.IdSubPrograma))return false;
		  if(!source.Proyecto.Equals(target.Proyecto))return false;
		  if(!source.Actividad.Equals(target.Actividad))return false;
		  if(!source.Obra.Equals(target.Obra))return false;
		  if((source.Denominacion == null)?target.Denominacion!=null:  !( (target.Denominacion== String.Empty && source.Denominacion== null) || (target.Denominacion==null && source.Denominacion== String.Empty )) &&  !source.Denominacion.Trim().Replace ("\r","").Equals(target.Denominacion.Trim().Replace ("\r","")))return false;
			 if(!source.IdClasificacionGasto.Equals(target.IdClasificacionGasto))return false;
		  if(!source.IdClasificacionGeografica.Equals(target.IdClasificacionGeografica))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(TransferenciaResult source,TransferenciaResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdTransferencia.Equals(target.IdTransferencia))return false;
		  if(!source.IdSubPrograma.Equals(target.IdSubPrograma))return false;
		  if(!source.Proyecto.Equals(target.Proyecto))return false;
		  if(!source.Actividad.Equals(target.Actividad))return false;
		  if(!source.Obra.Equals(target.Obra))return false;
		  if((source.Denominacion == null)?target.Denominacion!=null: !( (target.Denominacion== String.Empty && source.Denominacion== null) || (target.Denominacion==null && source.Denominacion== String.Empty )) && !source.Denominacion.Trim().Replace ("\r","").Equals(target.Denominacion.Trim().Replace ("\r","")))return false;
			 if(!source.IdClasificacionGasto.Equals(target.IdClasificacionGasto))return false;
		  if(!source.IdClasificacionGeografica.Equals(target.IdClasificacionGeografica))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		  if((source.ClasificacionGasto_Codigo == null)?target.ClasificacionGasto_Codigo!=null: !( (target.ClasificacionGasto_Codigo== String.Empty && source.ClasificacionGasto_Codigo== null) || (target.ClasificacionGasto_Codigo==null && source.ClasificacionGasto_Codigo== String.Empty )) &&   !source.ClasificacionGasto_Codigo.Trim().Replace ("\r","").Equals(target.ClasificacionGasto_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGasto_Nombre == null)?target.ClasificacionGasto_Nombre!=null: !( (target.ClasificacionGasto_Nombre== String.Empty && source.ClasificacionGasto_Nombre== null) || (target.ClasificacionGasto_Nombre==null && source.ClasificacionGasto_Nombre== String.Empty )) &&   !source.ClasificacionGasto_Nombre.Trim().Replace ("\r","").Equals(target.ClasificacionGasto_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.ClasificacionGasto_IdClasificacionGastoTipo.Equals(target.ClasificacionGasto_IdClasificacionGastoTipo))return false;
					  if((source.ClasificacionGasto_IdCaracterEconomico == null)?(target.ClasificacionGasto_IdCaracterEconomico.HasValue ):!source.ClasificacionGasto_IdCaracterEconomico.Equals(target.ClasificacionGasto_IdCaracterEconomico))return false;
						 if(!source.ClasificacionGasto_Activo.Equals(target.ClasificacionGasto_Activo))return false;
					  if((source.ClasificacionGasto_IdClasificacionGastoPadre == null)?(target.ClasificacionGasto_IdClasificacionGastoPadre.HasValue && target.ClasificacionGasto_IdClasificacionGastoPadre.Value > 0):!source.ClasificacionGasto_IdClasificacionGastoPadre.Equals(target.ClasificacionGasto_IdClasificacionGastoPadre))return false;
									  if((source.ClasificacionGasto_BreadcrumbId == null)?target.ClasificacionGasto_BreadcrumbId!=null: !( (target.ClasificacionGasto_BreadcrumbId== String.Empty && source.ClasificacionGasto_BreadcrumbId== null) || (target.ClasificacionGasto_BreadcrumbId==null && source.ClasificacionGasto_BreadcrumbId== String.Empty )) &&   !source.ClasificacionGasto_BreadcrumbId.Trim().Replace ("\r","").Equals(target.ClasificacionGasto_BreadcrumbId.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGasto_BreadcrumbOrden == null)?target.ClasificacionGasto_BreadcrumbOrden!=null: !( (target.ClasificacionGasto_BreadcrumbOrden== String.Empty && source.ClasificacionGasto_BreadcrumbOrden== null) || (target.ClasificacionGasto_BreadcrumbOrden==null && source.ClasificacionGasto_BreadcrumbOrden== String.Empty )) &&   !source.ClasificacionGasto_BreadcrumbOrden.Trim().Replace ("\r","").Equals(target.ClasificacionGasto_BreadcrumbOrden.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGasto_Nivel == null)?(target.ClasificacionGasto_Nivel.HasValue ):!source.ClasificacionGasto_Nivel.Equals(target.ClasificacionGasto_Nivel))return false;
						 if((source.ClasificacionGasto_Orden == null)?(target.ClasificacionGasto_Orden.HasValue ):!source.ClasificacionGasto_Orden.Equals(target.ClasificacionGasto_Orden))return false;
						 if((source.ClasificacionGasto_Descripcion == null)?target.ClasificacionGasto_Descripcion!=null: !( (target.ClasificacionGasto_Descripcion== String.Empty && source.ClasificacionGasto_Descripcion== null) || (target.ClasificacionGasto_Descripcion==null && source.ClasificacionGasto_Descripcion== String.Empty )) &&   !source.ClasificacionGasto_Descripcion.Trim().Replace ("\r","").Equals(target.ClasificacionGasto_Descripcion.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGasto_DescripcionInvertida == null)?target.ClasificacionGasto_DescripcionInvertida!=null: !( (target.ClasificacionGasto_DescripcionInvertida== String.Empty && source.ClasificacionGasto_DescripcionInvertida== null) || (target.ClasificacionGasto_DescripcionInvertida==null && source.ClasificacionGasto_DescripcionInvertida== String.Empty )) &&   !source.ClasificacionGasto_DescripcionInvertida.Trim().Replace ("\r","").Equals(target.ClasificacionGasto_DescripcionInvertida.Trim().Replace ("\r","")))return false;
						 if(!source.ClasificacionGasto_IdClasificacionGastoRubro.Equals(target.ClasificacionGasto_IdClasificacionGastoRubro))return false;
					  if(!source.ClasificacionGasto_Seleccionable.Equals(target.ClasificacionGasto_Seleccionable))return false;
					  if((source.ClasificacionGasto_BreadcrumbCode == null)?target.ClasificacionGasto_BreadcrumbCode!=null: !( (target.ClasificacionGasto_BreadcrumbCode== String.Empty && source.ClasificacionGasto_BreadcrumbCode== null) || (target.ClasificacionGasto_BreadcrumbCode==null && source.ClasificacionGasto_BreadcrumbCode== String.Empty )) &&   !source.ClasificacionGasto_BreadcrumbCode.Trim().Replace ("\r","").Equals(target.ClasificacionGasto_BreadcrumbCode.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGasto_DescripcionCodigo == null)?target.ClasificacionGasto_DescripcionCodigo!=null: !( (target.ClasificacionGasto_DescripcionCodigo== String.Empty && source.ClasificacionGasto_DescripcionCodigo== null) || (target.ClasificacionGasto_DescripcionCodigo==null && source.ClasificacionGasto_DescripcionCodigo== String.Empty )) &&   !source.ClasificacionGasto_DescripcionCodigo.Trim().Replace ("\r","").Equals(target.ClasificacionGasto_DescripcionCodigo.Trim().Replace ("\r","")))return false;
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
						 if(!source.SubPrograma_IdPrograma.Equals(target.SubPrograma_IdPrograma))return false;
					  if((source.SubPrograma_Codigo == null)?target.SubPrograma_Codigo!=null: !( (target.SubPrograma_Codigo== String.Empty && source.SubPrograma_Codigo== null) || (target.SubPrograma_Codigo==null && source.SubPrograma_Codigo== String.Empty )) &&   !source.SubPrograma_Codigo.Trim().Replace ("\r","").Equals(target.SubPrograma_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.SubPrograma_Nombre == null)?target.SubPrograma_Nombre!=null: !( (target.SubPrograma_Nombre== String.Empty && source.SubPrograma_Nombre== null) || (target.SubPrograma_Nombre==null && source.SubPrograma_Nombre== String.Empty )) &&   !source.SubPrograma_Nombre.Trim().Replace ("\r","").Equals(target.SubPrograma_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.SubPrograma_FechaAlta.Equals(target.SubPrograma_FechaAlta))return false;
					  if((source.SubPrograma_FechaBaja == null)?(target.SubPrograma_FechaBaja.HasValue ):!source.SubPrograma_FechaBaja.Equals(target.SubPrograma_FechaBaja))return false;
						 if(!source.SubPrograma_Activo.Equals(target.SubPrograma_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}

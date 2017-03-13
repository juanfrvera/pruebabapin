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
    public abstract class _PrestamoEstadoAsociadoData : EntityData<PrestamoEstadoAsociado,PrestamoEstadoAsociadoFilter,PrestamoEstadoAsociadoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.PrestamoEstadoAsociado entity)
		{			
			return entity.IdPrestamoEstadoasociado;
		}		
		public override PrestamoEstadoAsociado GetByEntity(PrestamoEstadoAsociado entity)
        {
            return this.GetById(entity.IdPrestamoEstadoasociado);
        }
        public override PrestamoEstadoAsociado GetById(int id)
        {
            return (from o in this.Table where o.IdPrestamoEstadoasociado == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<PrestamoEstadoAsociado> Query(PrestamoEstadoAsociadoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPrestamoEstadoasociado == null || o.IdPrestamoEstadoasociado >=  filter.IdPrestamoEstadoasociado) && (filter.IdPrestamoEstadoasociado_To == null || o.IdPrestamoEstadoasociado <= filter.IdPrestamoEstadoasociado_To)
					  && (filter.IdPrestamo == null || filter.IdPrestamo == 0 || o.IdPrestamo==filter.IdPrestamo)
					  && (filter.IdEstado == null || filter.IdEstado == 0 || o.IdEstado==filter.IdEstado)
					  && (filter.FechaEstimada == null || filter.FechaEstimada == DateTime.MinValue || o.FechaEstimada >=  filter.FechaEstimada) && (filter.FechaEstimada_To == null || filter.FechaEstimada_To == DateTime.MinValue || o.FechaEstimada <= filter.FechaEstimada_To)
					  && (filter.FechaRealizada == null || filter.FechaRealizada == DateTime.MinValue || o.FechaRealizada >=  filter.FechaRealizada) && (filter.FechaRealizada_To == null || filter.FechaRealizada_To == DateTime.MinValue || o.FechaRealizada <= filter.FechaRealizada_To)
					  && (filter.FechaRealizadaIsNull == null || filter.FechaRealizadaIsNull == true || o.FechaRealizada != null ) && (filter.FechaRealizadaIsNull == null || filter.FechaRealizadaIsNull == false || o.FechaRealizada == null)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PrestamoEstadoAsociadoResult> QueryResult(PrestamoEstadoAsociadoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Estados on o.IdEstado equals t1.IdEstado   
				    join t2  in this.Context.Prestamos on o.IdPrestamo equals t2.IdPrestamo   
				   select new PrestamoEstadoAsociadoResult(){
					 IdPrestamoEstadoasociado=o.IdPrestamoEstadoasociado
					 ,IdPrestamo=o.IdPrestamo
					 ,IdEstado=o.IdEstado
					 ,FechaEstimada=o.FechaEstimada
					 ,FechaRealizada=o.FechaRealizada
					,Estado_Nombre= t1.Nombre	
						,Estado_IdTipoEstado= t1.IdTipoEstado	
						,Estado_Orden= t1.Orden	
						,Estado_Descripcion= t1.Descripcion	
						,Estado_Activo= t1.Activo	
						,Prestamo_IdPrograma= t2.IdPrograma	
						,Prestamo_Numero= t2.Numero	
						,Prestamo_Denominacion= t2.Denominacion	
						,Prestamo_Descripcion= t2.Descripcion	
						,Prestamo_Observacion= t2.Observacion	
						,Prestamo_FechaAlta= t2.FechaAlta	
						,Prestamo_FechaModificacion= t2.FechaModificacion	
						,Prestamo_IdUsuarioModificacion= t2.IdUsuarioModificacion	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.PrestamoEstadoAsociado Copy(nc.PrestamoEstadoAsociado entity)
        {           
            nc.PrestamoEstadoAsociado _new = new nc.PrestamoEstadoAsociado();
		 _new.IdPrestamo= entity.IdPrestamo;
		 _new.IdEstado= entity.IdEstado;
		 _new.FechaEstimada= entity.FechaEstimada;
		 _new.FechaRealizada= entity.FechaRealizada;
		return _new;			
        }
		#endregion
		#region Set
		public override void SetId(PrestamoEstadoAsociado entity, int id)
        {            
            entity.IdPrestamoEstadoasociado = id;            
        }
		public override void Set(PrestamoEstadoAsociado source,PrestamoEstadoAsociado target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoEstadoasociado= source.IdPrestamoEstadoasociado ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdEstado= source.IdEstado ;
		 target.FechaEstimada= source.FechaEstimada ;
		 target.FechaRealizada= source.FechaRealizada ;
		 		  
		}
		public override void Set(PrestamoEstadoAsociadoResult source,PrestamoEstadoAsociado target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoEstadoasociado= source.IdPrestamoEstadoasociado ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdEstado= source.IdEstado ;
		 target.FechaEstimada= source.FechaEstimada ;
		 target.FechaRealizada= source.FechaRealizada ;
		 
		}
		public override void Set(PrestamoEstadoAsociado source,PrestamoEstadoAsociadoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoEstadoasociado= source.IdPrestamoEstadoasociado ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdEstado= source.IdEstado ;
		 target.FechaEstimada= source.FechaEstimada ;
		 target.FechaRealizada= source.FechaRealizada ;
		 	
		}		
		public override void Set(PrestamoEstadoAsociadoResult source,PrestamoEstadoAsociadoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoEstadoasociado= source.IdPrestamoEstadoasociado ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdEstado= source.IdEstado ;
		 target.FechaEstimada= source.FechaEstimada ;
		 target.FechaRealizada= source.FechaRealizada ;
		 target.Estado_Nombre= source.Estado_Nombre;	
			target.Estado_IdTipoEstado= source.Estado_IdTipoEstado;	
			target.Estado_Orden= source.Estado_Orden;	
			target.Estado_Descripcion= source.Estado_Descripcion;	
			target.Estado_Activo= source.Estado_Activo;	
			target.Prestamo_IdPrograma= source.Prestamo_IdPrograma;	
			target.Prestamo_Numero= source.Prestamo_Numero;	
			target.Prestamo_Denominacion= source.Prestamo_Denominacion;	
			target.Prestamo_Descripcion= source.Prestamo_Descripcion;	
			target.Prestamo_Observacion= source.Prestamo_Observacion;	
			target.Prestamo_FechaAlta= source.Prestamo_FechaAlta;	
			target.Prestamo_FechaModificacion= source.Prestamo_FechaModificacion;	
			target.Prestamo_IdUsuarioModificacion= source.Prestamo_IdUsuarioModificacion;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(PrestamoEstadoAsociado source,PrestamoEstadoAsociado target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoEstadoasociado.Equals(target.IdPrestamoEstadoasociado))return false;
		  if(!source.IdPrestamo.Equals(target.IdPrestamo))return false;
		  if(!source.IdEstado.Equals(target.IdEstado))return false;
		  if(!source.FechaEstimada.Equals(target.FechaEstimada))return false;
		  if((source.FechaRealizada == null)?target.FechaRealizada!=null:!source.FechaRealizada.Equals(target.FechaRealizada))return false;
			
		  return true;
        }
		public override bool Equals(PrestamoEstadoAsociadoResult source,PrestamoEstadoAsociadoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoEstadoasociado.Equals(target.IdPrestamoEstadoasociado))return false;
		  if(!source.IdPrestamo.Equals(target.IdPrestamo))return false;
		  if(!source.IdEstado.Equals(target.IdEstado))return false;
		  if(!source.FechaEstimada.Equals(target.FechaEstimada))return false;
		  if((source.FechaRealizada == null)?target.FechaRealizada!=null:!source.FechaRealizada.Equals(target.FechaRealizada))return false;
			 if(!source.Estado_Nombre.Equals(target.Estado_Nombre))return false;
					  if(!source.Estado_IdTipoEstado.Equals(target.Estado_IdTipoEstado))return false;
					  if(!source.Estado_Orden.Equals(target.Estado_Orden))return false;
					  if(!source.Estado_Descripcion.Equals(target.Estado_Descripcion))return false;
					  if(!source.Estado_Activo.Equals(target.Estado_Activo))return false;
					  if(!source.Prestamo_IdPrograma.Equals(target.Prestamo_IdPrograma))return false;
					  if(!source.Prestamo_Numero.Equals(target.Prestamo_Numero))return false;
					  if(!source.Prestamo_Denominacion.Equals(target.Prestamo_Denominacion))return false;
					  if(!source.Prestamo_Descripcion.Equals(target.Prestamo_Descripcion))return false;
					  if(!source.Prestamo_Observacion.Equals(target.Prestamo_Observacion))return false;
					  if(!source.Prestamo_FechaAlta.Equals(target.Prestamo_FechaAlta))return false;
					  if(!source.Prestamo_FechaModificacion.Equals(target.Prestamo_FechaModificacion))return false;
					  if(!source.Prestamo_IdUsuarioModificacion.Equals(target.Prestamo_IdUsuarioModificacion))return false;
					 		
		  return true;
        }
		#endregion
    }
}

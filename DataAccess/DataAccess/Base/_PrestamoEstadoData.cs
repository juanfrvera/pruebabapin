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
    public abstract class _PrestamoEstadoData : EntityData<PrestamoEstado,PrestamoEstadoFilter,PrestamoEstadoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.PrestamoEstado entity)
		{			
			return entity.IdPrestamoEstado;
		}		
		public override PrestamoEstado GetByEntity(PrestamoEstado entity)
        {
            return this.GetById(entity.IdPrestamoEstado);
        }
        public override PrestamoEstado GetById(int id)
        {
            return (from o in this.Table where o.IdPrestamoEstado == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<PrestamoEstado> Query(PrestamoEstadoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPrestamoEstado == null || o.IdPrestamoEstado >=  filter.IdPrestamoEstado) && (filter.IdPrestamoEstado_To == null || o.IdPrestamoEstado <= filter.IdPrestamoEstado_To)
					  && (filter.IdPrestamo == null || filter.IdPrestamo == 0 || o.IdPrestamo==filter.IdPrestamo)
					  && (filter.IdEstado == null || filter.IdEstado == 0 || o.IdEstado==filter.IdEstado)
					  && (filter.FechaEstimada == null || filter.FechaEstimada == DateTime.MinValue || o.FechaEstimada >=  filter.FechaEstimada) && (filter.FechaEstimada_To == null || filter.FechaEstimada_To == DateTime.MinValue || o.FechaEstimada <= filter.FechaEstimada_To)
					  && (filter.FechaRealizada == null || filter.FechaRealizada == DateTime.MinValue || o.FechaRealizada >=  filter.FechaRealizada) && (filter.FechaRealizada_To == null || filter.FechaRealizada_To == DateTime.MinValue || o.FechaRealizada <= filter.FechaRealizada_To)
					  && (filter.FechaRealizadaIsNull == null || filter.FechaRealizadaIsNull == true || o.FechaRealizada != null ) && (filter.FechaRealizadaIsNull == null || filter.FechaRealizadaIsNull == false || o.FechaRealizada == null)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PrestamoEstadoResult> QueryResult(PrestamoEstadoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Estados on o.IdEstado equals t1.IdEstado   
				    join t2  in this.Context.Prestamos on o.IdPrestamo equals t2.IdPrestamo   
				   select new PrestamoEstadoResult(){
					 IdPrestamoEstado=o.IdPrestamoEstado
					 ,IdPrestamo=o.IdPrestamo
					 ,IdEstado=o.IdEstado
					 ,FechaEstimada=o.FechaEstimada
					 ,FechaRealizada=o.FechaRealizada
					,Estado_Nombre= t1.Nombre	
						,Estado_Codigo= t1.Codigo	
						,Estado_Orden= t1.Orden	
						,Estado_Descripcion= t1.Descripcion	
						,Estado_Activo= t1.Activo	
                        //,Prestamo_IdPrograma= t2.IdPrograma	
                        //,Prestamo_Numero= t2.Numero	
                        //,Prestamo_Denominacion= t2.Denominacion	
                        //,Prestamo_Descripcion= t2.Descripcion	
                        //,Prestamo_Observacion= t2.Observacion	
                        //,Prestamo_FechaAlta= t2.FechaAlta	
                        //,Prestamo_FechaModificacion= t2.FechaModificacion	
                        //,Prestamo_IdUsuarioModificacion= t2.IdUsuarioModificacion	
                        //,Prestamo_IdEstadoActual= t2.IdEstadoActual	
                        //,Prestamo_ResponsablePolitico= t2.ResponsablePolitico	
                        //,Prestamo_ResponsableTecnico= t2.ResponsableTecnico	
                        //,Prestamo_CodigoVinculacion1= t2.CodigoVinculacion1	
                        //,Prestamo_CodigoVinculacion2= t2.CodigoVinculacion2	
                        //,Prestamo_Activo= t2.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.PrestamoEstado Copy(nc.PrestamoEstado entity)
        {           
            nc.PrestamoEstado _new = new nc.PrestamoEstado();
		 _new.IdPrestamo= entity.IdPrestamo;
		 _new.IdEstado= entity.IdEstado;
		 _new.FechaEstimada= entity.FechaEstimada;
		 _new.FechaRealizada= entity.FechaRealizada;
		return _new;			
        }
		public override int CopyAndSave(PrestamoEstado entity,string renameFormat)
        {
            PrestamoEstado  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(PrestamoEstado entity, int id)
        {            
            entity.IdPrestamoEstado = id;            
        }
		public override void Set(PrestamoEstado source,PrestamoEstado target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoEstado= source.IdPrestamoEstado ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdEstado= source.IdEstado ;
		 target.FechaEstimada= source.FechaEstimada ;
		 target.FechaRealizada= source.FechaRealizada ;
		 		  
		}
		public override void Set(PrestamoEstadoResult source,PrestamoEstado target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoEstado= source.IdPrestamoEstado ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdEstado= source.IdEstado ;
		 target.FechaEstimada= source.FechaEstimada ;
		 target.FechaRealizada= source.FechaRealizada ;
		 
		}
		public override void Set(PrestamoEstado source,PrestamoEstadoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoEstado= source.IdPrestamoEstado ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdEstado= source.IdEstado ;
		 target.FechaEstimada= source.FechaEstimada ;
		 target.FechaRealizada= source.FechaRealizada ;
		 	
		}		
		public override void Set(PrestamoEstadoResult source,PrestamoEstadoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoEstado= source.IdPrestamoEstado ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdEstado= source.IdEstado ;
		 target.FechaEstimada= source.FechaEstimada ;
		 target.FechaRealizada= source.FechaRealizada ;
		 target.Estado_Nombre= source.Estado_Nombre;	
			target.Estado_Codigo= source.Estado_Codigo;	
			target.Estado_Orden= source.Estado_Orden;	
			target.Estado_Descripcion= source.Estado_Descripcion;	
			target.Estado_Activo= source.Estado_Activo;	
            //target.Prestamo_IdPrograma= source.Prestamo_IdPrograma;	
            //target.Prestamo_Numero= source.Prestamo_Numero;	
            //target.Prestamo_Denominacion= source.Prestamo_Denominacion;	
            //target.Prestamo_Descripcion= source.Prestamo_Descripcion;	
            //target.Prestamo_Observacion= source.Prestamo_Observacion;	
            //target.Prestamo_FechaAlta= source.Prestamo_FechaAlta;	
            //target.Prestamo_FechaModificacion= source.Prestamo_FechaModificacion;	
            //target.Prestamo_IdUsuarioModificacion= source.Prestamo_IdUsuarioModificacion;	
            //target.Prestamo_IdEstadoActual= source.Prestamo_IdEstadoActual;	
            //target.Prestamo_ResponsablePolitico= source.Prestamo_ResponsablePolitico;	
            //target.Prestamo_ResponsableTecnico= source.Prestamo_ResponsableTecnico;	
            //target.Prestamo_CodigoVinculacion1= source.Prestamo_CodigoVinculacion1;	
            //target.Prestamo_CodigoVinculacion2= source.Prestamo_CodigoVinculacion2;	
            //target.Prestamo_Activo= source.Prestamo_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(PrestamoEstado source,PrestamoEstado target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoEstado.Equals(target.IdPrestamoEstado))return false;
		  if(!source.IdPrestamo.Equals(target.IdPrestamo))return false;
		  if(!source.IdEstado.Equals(target.IdEstado))return false;
		  if(!source.FechaEstimada.Equals(target.FechaEstimada))return false;
		  if((source.FechaRealizada == null)?(target.FechaRealizada.HasValue):!source.FechaRealizada.Equals(target.FechaRealizada))return false;
			
		  return true;
        }
		public override bool Equals(PrestamoEstadoResult source,PrestamoEstadoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoEstado.Equals(target.IdPrestamoEstado))return false;
		  if(!source.IdPrestamo.Equals(target.IdPrestamo))return false;
		  if(!source.IdEstado.Equals(target.IdEstado))return false;
		  if(!source.FechaEstimada.Equals(target.FechaEstimada))return false;
		  if((source.FechaRealizada == null)?(target.FechaRealizada.HasValue):!source.FechaRealizada.Equals(target.FechaRealizada))return false;
			 if((source.Estado_Nombre == null)?target.Estado_Nombre!=null: !( (target.Estado_Nombre== String.Empty && source.Estado_Nombre== null) || (target.Estado_Nombre==null && source.Estado_Nombre== String.Empty )) &&   !source.Estado_Nombre.Trim().Replace ("\r","").Equals(target.Estado_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.Estado_Codigo == null)?target.Estado_Codigo!=null: !( (target.Estado_Codigo== String.Empty && source.Estado_Codigo== null) || (target.Estado_Codigo==null && source.Estado_Codigo== String.Empty )) &&   !source.Estado_Codigo.Trim().Replace ("\r","").Equals(target.Estado_Codigo.Trim().Replace ("\r","")))return false;
						 if(!source.Estado_Orden.Equals(target.Estado_Orden))return false;
					  if((source.Estado_Descripcion == null)?target.Estado_Descripcion!=null: !( (target.Estado_Descripcion== String.Empty && source.Estado_Descripcion== null) || (target.Estado_Descripcion==null && source.Estado_Descripcion== String.Empty )) &&   !source.Estado_Descripcion.Trim().Replace ("\r","").Equals(target.Estado_Descripcion.Trim().Replace ("\r","")))return false;
						 if(!source.Estado_Activo.Equals(target.Estado_Activo))return false;
                      //if(!source.Prestamo_IdPrograma.Equals(target.Prestamo_IdPrograma))return false;
                      //if(!source.Prestamo_Numero.Equals(target.Prestamo_Numero))return false;
                      //if((source.Prestamo_Denominacion == null)?target.Prestamo_Denominacion!=null: !( (target.Prestamo_Denominacion== String.Empty && source.Prestamo_Denominacion== null) || (target.Prestamo_Denominacion==null && source.Prestamo_Denominacion== String.Empty )) &&   !source.Prestamo_Denominacion.Trim().Replace ("\r","").Equals(target.Prestamo_Denominacion.Trim().Replace ("\r","")))return false;
                      //   if((source.Prestamo_Descripcion == null)?target.Prestamo_Descripcion!=null: !( (target.Prestamo_Descripcion== String.Empty && source.Prestamo_Descripcion== null) || (target.Prestamo_Descripcion==null && source.Prestamo_Descripcion== String.Empty )) &&   !source.Prestamo_Descripcion.Trim().Replace ("\r","").Equals(target.Prestamo_Descripcion.Trim().Replace ("\r","")))return false;
                      //   if((source.Prestamo_Observacion == null)?target.Prestamo_Observacion!=null: !( (target.Prestamo_Observacion== String.Empty && source.Prestamo_Observacion== null) || (target.Prestamo_Observacion==null && source.Prestamo_Observacion== String.Empty )) &&   !source.Prestamo_Observacion.Trim().Replace ("\r","").Equals(target.Prestamo_Observacion.Trim().Replace ("\r","")))return false;
                      //   if(!source.Prestamo_FechaAlta.Equals(target.Prestamo_FechaAlta))return false;
                      //if(!source.Prestamo_FechaModificacion.Equals(target.Prestamo_FechaModificacion))return false;
                      //if(!source.Prestamo_IdUsuarioModificacion.Equals(target.Prestamo_IdUsuarioModificacion))return false;
                      //if((source.Prestamo_IdEstadoActual == null)?(target.Prestamo_IdEstadoActual.HasValue ):!source.Prestamo_IdEstadoActual.Equals(target.Prestamo_IdEstadoActual))return false;
                      //   if((source.Prestamo_ResponsablePolitico == null)?target.Prestamo_ResponsablePolitico!=null: !( (target.Prestamo_ResponsablePolitico== String.Empty && source.Prestamo_ResponsablePolitico== null) || (target.Prestamo_ResponsablePolitico==null && source.Prestamo_ResponsablePolitico== String.Empty )) &&   !source.Prestamo_ResponsablePolitico.Trim().Replace ("\r","").Equals(target.Prestamo_ResponsablePolitico.Trim().Replace ("\r","")))return false;
                      //   if((source.Prestamo_ResponsableTecnico == null)?target.Prestamo_ResponsableTecnico!=null: !( (target.Prestamo_ResponsableTecnico== String.Empty && source.Prestamo_ResponsableTecnico== null) || (target.Prestamo_ResponsableTecnico==null && source.Prestamo_ResponsableTecnico== String.Empty )) &&   !source.Prestamo_ResponsableTecnico.Trim().Replace ("\r","").Equals(target.Prestamo_ResponsableTecnico.Trim().Replace ("\r","")))return false;
                      //   if((source.Prestamo_CodigoVinculacion1 == null)?target.Prestamo_CodigoVinculacion1!=null: !( (target.Prestamo_CodigoVinculacion1== String.Empty && source.Prestamo_CodigoVinculacion1== null) || (target.Prestamo_CodigoVinculacion1==null && source.Prestamo_CodigoVinculacion1== String.Empty )) &&   !source.Prestamo_CodigoVinculacion1.Trim().Replace ("\r","").Equals(target.Prestamo_CodigoVinculacion1.Trim().Replace ("\r","")))return false;
                      //   if((source.Prestamo_CodigoVinculacion2 == null)?target.Prestamo_CodigoVinculacion2!=null: !( (target.Prestamo_CodigoVinculacion2== String.Empty && source.Prestamo_CodigoVinculacion2== null) || (target.Prestamo_CodigoVinculacion2==null && source.Prestamo_CodigoVinculacion2== String.Empty )) &&   !source.Prestamo_CodigoVinculacion2.Trim().Replace ("\r","").Equals(target.Prestamo_CodigoVinculacion2.Trim().Replace ("\r","")))return false;
                      //   if(!source.Prestamo_Activo.Equals(target.Prestamo_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}

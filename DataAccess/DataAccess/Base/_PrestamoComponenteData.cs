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
    public abstract class _PrestamoComponenteData : EntityData<PrestamoComponente,PrestamoComponenteFilter,PrestamoComponenteResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.PrestamoComponente entity)
		{			
			return entity.IdPrestamoComponente;
		}		
		public override PrestamoComponente GetByEntity(PrestamoComponente entity)
        {
            return this.GetById(entity.IdPrestamoComponente);
        }
        public override PrestamoComponente GetById(int id)
        {
            return (from o in this.Table where o.IdPrestamoComponente == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<PrestamoComponente> Query(PrestamoComponenteFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPrestamoComponente == null || filter.IdPrestamoComponente == 0 || o.IdPrestamoComponente==filter.IdPrestamoComponente)
					  && (filter.IdPrestamo == null || filter.IdPrestamo == 0 || o.IdPrestamo==filter.IdPrestamo)
					  && (filter.IdObjetivo == null || filter.IdObjetivo == 0 || o.IdObjetivo==filter.IdObjetivo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PrestamoComponenteResult> QueryResult(PrestamoComponenteFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Objetivos on o.IdObjetivo equals t1.IdObjetivo   
				    join t2  in this.Context.Prestamos on o.IdPrestamo equals t2.IdPrestamo   
				   select new PrestamoComponenteResult(){
					 IdPrestamoComponente=o.IdPrestamoComponente
					 ,IdPrestamo=o.IdPrestamo
					 ,IdObjetivo=o.IdObjetivo
					,Objetivo_Nombre= t1.Nombre	
						,Prestamo_IdPrograma= t2.IdPrograma	
						,Prestamo_Numero= t2.Numero	
						,Prestamo_Denominacion= t2.Denominacion	
						,Prestamo_Descripcion= t2.Descripcion	
						,Prestamo_Observacion= t2.Observacion	
						,Prestamo_FechaAlta= t2.FechaAlta	
						,Prestamo_FechaModificacion= t2.FechaModificacion	
						,Prestamo_IdUsuarioModificacion= t2.IdUsuarioModificacion	
						,Prestamo_IdEstadoActual= t2.IdEstadoActual	
						,Prestamo_ResponsablePolitico= t2.ResponsablePolitico	
						,Prestamo_ResponsableTecnico= t2.ResponsableTecnico	
						,Prestamo_CodigoVinculacion1= t2.CodigoVinculacion1	
						,Prestamo_CodigoVinculacion2= t2.CodigoVinculacion2	
						,Prestamo_Activo= t2.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.PrestamoComponente Copy(nc.PrestamoComponente entity)
        {           
            nc.PrestamoComponente _new = new nc.PrestamoComponente();
		 _new.IdPrestamo= entity.IdPrestamo;
		 _new.IdObjetivo= entity.IdObjetivo;
		return _new;			
        }
		public override int CopyAndSave(PrestamoComponente entity,string renameFormat)
        {
            PrestamoComponente  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(PrestamoComponente entity, int id)
        {            
            entity.IdPrestamoComponente = id;            
        }
		public override void Set(PrestamoComponente source,PrestamoComponente target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoComponente= source.IdPrestamoComponente ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdObjetivo= source.IdObjetivo ;
		 		  
		}
		public override void Set(PrestamoComponenteResult source,PrestamoComponente target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoComponente= source.IdPrestamoComponente ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdObjetivo= source.IdObjetivo ;
		 
		}
		public override void Set(PrestamoComponente source,PrestamoComponenteResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoComponente= source.IdPrestamoComponente ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdObjetivo= source.IdObjetivo ;
		 	
		}		
		public override void Set(PrestamoComponenteResult source,PrestamoComponenteResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoComponente= source.IdPrestamoComponente ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdObjetivo= source.IdObjetivo ;
		 target.Objetivo_Nombre= source.Objetivo_Nombre;	
			target.Prestamo_IdPrograma= source.Prestamo_IdPrograma;	
			target.Prestamo_Numero= source.Prestamo_Numero;	
			target.Prestamo_Denominacion= source.Prestamo_Denominacion;	
			target.Prestamo_Descripcion= source.Prestamo_Descripcion;	
			target.Prestamo_Observacion= source.Prestamo_Observacion;	
			target.Prestamo_FechaAlta= source.Prestamo_FechaAlta;	
			target.Prestamo_FechaModificacion= source.Prestamo_FechaModificacion;	
			target.Prestamo_IdUsuarioModificacion= source.Prestamo_IdUsuarioModificacion;	
			target.Prestamo_IdEstadoActual= source.Prestamo_IdEstadoActual;	
			target.Prestamo_ResponsablePolitico= source.Prestamo_ResponsablePolitico;	
			target.Prestamo_ResponsableTecnico= source.Prestamo_ResponsableTecnico;	
			target.Prestamo_CodigoVinculacion1= source.Prestamo_CodigoVinculacion1;	
			target.Prestamo_CodigoVinculacion2= source.Prestamo_CodigoVinculacion2;	
			target.Prestamo_Activo= source.Prestamo_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(PrestamoComponente source,PrestamoComponente target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoComponente.Equals(target.IdPrestamoComponente))return false;
		  if(!source.IdPrestamo.Equals(target.IdPrestamo))return false;
		  if(!source.IdObjetivo.Equals(target.IdObjetivo))return false;
		 
		  return true;
        }
		public override bool Equals(PrestamoComponenteResult source,PrestamoComponenteResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoComponente.Equals(target.IdPrestamoComponente))return false;
		  if(!source.IdPrestamo.Equals(target.IdPrestamo))return false;
		  if(!source.IdObjetivo.Equals(target.IdObjetivo))return false;
		  if((source.Objetivo_Nombre == null)?target.Objetivo_Nombre!=null: !( (target.Objetivo_Nombre== String.Empty && source.Objetivo_Nombre== null) || (target.Objetivo_Nombre==null && source.Objetivo_Nombre== String.Empty )) &&   !source.Objetivo_Nombre.Trim().Replace ("\r","").Equals(target.Objetivo_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.Prestamo_IdPrograma.Equals(target.Prestamo_IdPrograma))return false;
					  if(!source.Prestamo_Numero.Equals(target.Prestamo_Numero))return false;
					  if((source.Prestamo_Denominacion == null)?target.Prestamo_Denominacion!=null: !( (target.Prestamo_Denominacion== String.Empty && source.Prestamo_Denominacion== null) || (target.Prestamo_Denominacion==null && source.Prestamo_Denominacion== String.Empty )) &&   !source.Prestamo_Denominacion.Trim().Replace ("\r","").Equals(target.Prestamo_Denominacion.Trim().Replace ("\r","")))return false;
						 if((source.Prestamo_Descripcion == null)?target.Prestamo_Descripcion!=null: !( (target.Prestamo_Descripcion== String.Empty && source.Prestamo_Descripcion== null) || (target.Prestamo_Descripcion==null && source.Prestamo_Descripcion== String.Empty )) &&   !source.Prestamo_Descripcion.Trim().Replace ("\r","").Equals(target.Prestamo_Descripcion.Trim().Replace ("\r","")))return false;
						 if((source.Prestamo_Observacion == null)?target.Prestamo_Observacion!=null: !( (target.Prestamo_Observacion== String.Empty && source.Prestamo_Observacion== null) || (target.Prestamo_Observacion==null && source.Prestamo_Observacion== String.Empty )) &&   !source.Prestamo_Observacion.Trim().Replace ("\r","").Equals(target.Prestamo_Observacion.Trim().Replace ("\r","")))return false;
						 if(!source.Prestamo_FechaAlta.Equals(target.Prestamo_FechaAlta))return false;
					  if(!source.Prestamo_FechaModificacion.Equals(target.Prestamo_FechaModificacion))return false;
					  if(!source.Prestamo_IdUsuarioModificacion.Equals(target.Prestamo_IdUsuarioModificacion))return false;
					  if((source.Prestamo_IdEstadoActual == null)?(target.Prestamo_IdEstadoActual.HasValue ):!source.Prestamo_IdEstadoActual.Equals(target.Prestamo_IdEstadoActual))return false;
						 if((source.Prestamo_ResponsablePolitico == null)?target.Prestamo_ResponsablePolitico!=null: !( (target.Prestamo_ResponsablePolitico== String.Empty && source.Prestamo_ResponsablePolitico== null) || (target.Prestamo_ResponsablePolitico==null && source.Prestamo_ResponsablePolitico== String.Empty )) &&   !source.Prestamo_ResponsablePolitico.Trim().Replace ("\r","").Equals(target.Prestamo_ResponsablePolitico.Trim().Replace ("\r","")))return false;
						 if((source.Prestamo_ResponsableTecnico == null)?target.Prestamo_ResponsableTecnico!=null: !( (target.Prestamo_ResponsableTecnico== String.Empty && source.Prestamo_ResponsableTecnico== null) || (target.Prestamo_ResponsableTecnico==null && source.Prestamo_ResponsableTecnico== String.Empty )) &&   !source.Prestamo_ResponsableTecnico.Trim().Replace ("\r","").Equals(target.Prestamo_ResponsableTecnico.Trim().Replace ("\r","")))return false;
						 if((source.Prestamo_CodigoVinculacion1 == null)?target.Prestamo_CodigoVinculacion1!=null: !( (target.Prestamo_CodigoVinculacion1== String.Empty && source.Prestamo_CodigoVinculacion1== null) || (target.Prestamo_CodigoVinculacion1==null && source.Prestamo_CodigoVinculacion1== String.Empty )) &&   !source.Prestamo_CodigoVinculacion1.Trim().Replace ("\r","").Equals(target.Prestamo_CodigoVinculacion1.Trim().Replace ("\r","")))return false;
						 if((source.Prestamo_CodigoVinculacion2 == null)?target.Prestamo_CodigoVinculacion2!=null: !( (target.Prestamo_CodigoVinculacion2== String.Empty && source.Prestamo_CodigoVinculacion2== null) || (target.Prestamo_CodigoVinculacion2==null && source.Prestamo_CodigoVinculacion2== String.Empty )) &&   !source.Prestamo_CodigoVinculacion2.Trim().Replace ("\r","").Equals(target.Prestamo_CodigoVinculacion2.Trim().Replace ("\r","")))return false;
						 if(!source.Prestamo_Activo.Equals(target.Prestamo_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}

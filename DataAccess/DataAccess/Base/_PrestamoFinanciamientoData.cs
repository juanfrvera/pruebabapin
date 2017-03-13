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
    public abstract class _PrestamoFinanciamientoData : EntityData<PrestamoFinanciamiento,PrestamoFinanciamientoFilter,PrestamoFinanciamientoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.PrestamoFinanciamiento entity)
		{			
			return entity.IdPrestamoFinanciamiento;
		}		
		public override PrestamoFinanciamiento GetByEntity(PrestamoFinanciamiento entity)
        {
            return this.GetById(entity.IdPrestamoFinanciamiento);
        }
        public override PrestamoFinanciamiento GetById(int id)
        {
            return (from o in this.Table where o.IdPrestamoFinanciamiento == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<PrestamoFinanciamiento> Query(PrestamoFinanciamientoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPrestamoFinanciamiento == null || o.IdPrestamoFinanciamiento >=  filter.IdPrestamoFinanciamiento) && (filter.IdPrestamoFinanciamiento_To == null || o.IdPrestamoFinanciamiento <= filter.IdPrestamoFinanciamiento_To)
					  && (filter.IdPrestamoComponente == null || filter.IdPrestamoComponente == 0 || o.IdPrestamoComponente==filter.IdPrestamoComponente)
					  && (filter.IdPrestamoSubComponente == null || o.IdPrestamoSubComponente >=  filter.IdPrestamoSubComponente) && (filter.IdPrestamoSubComponente_To == null || o.IdPrestamoSubComponente <= filter.IdPrestamoSubComponente_To)
					  && (filter.IdPrestamoSubComponenteIsNull == null || filter.IdPrestamoSubComponenteIsNull == true || o.IdPrestamoSubComponente != null ) && (filter.IdPrestamoSubComponenteIsNull == null || filter.IdPrestamoSubComponenteIsNull == false || o.IdPrestamoSubComponente == null)
					  && (filter.IdFuenteFinanciamiento == null || filter.IdFuenteFinanciamiento == 0 || o.IdFuenteFinanciamiento==filter.IdFuenteFinanciamiento)
					  && (filter.Monto == null || o.Monto >=  filter.Monto) && (filter.Monto_To == null || o.Monto <= filter.Monto_To)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PrestamoFinanciamientoResult> QueryResult(PrestamoFinanciamientoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.FuenteFinanciamientos on o.IdFuenteFinanciamiento equals t1.IdFuenteFinanciamiento   
				    join t2  in this.Context.PrestamoComponentes on o.IdPrestamoComponente equals t2.IdPrestamoComponente   
				   select new PrestamoFinanciamientoResult(){
					 IdPrestamoFinanciamiento=o.IdPrestamoFinanciamiento
					 ,IdPrestamoComponente=o.IdPrestamoComponente
					 ,IdPrestamoSubComponente=o.IdPrestamoSubComponente
					 ,IdFuenteFinanciamiento=o.IdFuenteFinanciamiento
					 ,Monto=o.Monto
					,FuenteFinanciamiento_Codigo= t1.Codigo	
						,FuenteFinanciamiento_Nombre= t1.Nombre	
						,FuenteFinanciamiento_IdFuenteFinanciamientoTipo= t1.IdFuenteFinanciamientoTipo	
						,FuenteFinanciamiento_Activo= t1.Activo	
						,FuenteFinanciamiento_IdFuenteFinanciamientoPadre= t1.IdFuenteFinanciamientoPadre	
						,FuenteFinanciamiento_BreadcrumbId= t1.BreadcrumbId	
						,FuenteFinanciamiento_BreadcrumbOrden= t1.BreadcrumbOrden	
						,FuenteFinanciamiento_Nivel= t1.Nivel	
						,FuenteFinanciamiento_Orden= t1.Orden	
						,FuenteFinanciamiento_Descripcion= t1.Descripcion	
						,FuenteFinanciamiento_DescripcionInvertida= t1.DescripcionInvertida	
						,FuenteFinanciamiento_Seleccionable= t1.Seleccionable	
						,FuenteFinanciamiento_BreadcrumbCode= t1.BreadcrumbCode	
						,FuenteFinanciamiento_DescripcionCodigo= t1.DescripcionCodigo	
						,PrestamoComponente_IdPrestamo= t2.IdPrestamo	
						,PrestamoComponente_IdObjetivo= t2.IdObjetivo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.PrestamoFinanciamiento Copy(nc.PrestamoFinanciamiento entity)
        {           
            nc.PrestamoFinanciamiento _new = new nc.PrestamoFinanciamiento();
		 _new.IdPrestamoComponente= entity.IdPrestamoComponente;
		 _new.IdPrestamoSubComponente= entity.IdPrestamoSubComponente;
		 _new.IdFuenteFinanciamiento= entity.IdFuenteFinanciamiento;
		 _new.Monto= entity.Monto;
		return _new;			
        }
		public override int CopyAndSave(PrestamoFinanciamiento entity,string renameFormat)
        {
            PrestamoFinanciamiento  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(PrestamoFinanciamiento entity, int id)
        {            
            entity.IdPrestamoFinanciamiento = id;            
        }
		public override void Set(PrestamoFinanciamiento source,PrestamoFinanciamiento target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoFinanciamiento= source.IdPrestamoFinanciamiento ;
		 target.IdPrestamoComponente= source.IdPrestamoComponente ;
		 target.IdPrestamoSubComponente= source.IdPrestamoSubComponente ;
		 target.IdFuenteFinanciamiento= source.IdFuenteFinanciamiento ;
		 target.Monto= source.Monto ;
		 		  
		}
		public override void Set(PrestamoFinanciamientoResult source,PrestamoFinanciamiento target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoFinanciamiento= source.IdPrestamoFinanciamiento ;
		 target.IdPrestamoComponente= source.IdPrestamoComponente ;
		 target.IdPrestamoSubComponente= source.IdPrestamoSubComponente ;
		 target.IdFuenteFinanciamiento= source.IdFuenteFinanciamiento ;
		 target.Monto= source.Monto ;
		 
		}
		public override void Set(PrestamoFinanciamiento source,PrestamoFinanciamientoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoFinanciamiento= source.IdPrestamoFinanciamiento ;
		 target.IdPrestamoComponente= source.IdPrestamoComponente ;
		 target.IdPrestamoSubComponente= source.IdPrestamoSubComponente ;
		 target.IdFuenteFinanciamiento= source.IdFuenteFinanciamiento ;
		 target.Monto= source.Monto ;
		 	
		}		
		public override void Set(PrestamoFinanciamientoResult source,PrestamoFinanciamientoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoFinanciamiento= source.IdPrestamoFinanciamiento ;
		 target.IdPrestamoComponente= source.IdPrestamoComponente ;
		 target.IdPrestamoSubComponente= source.IdPrestamoSubComponente ;
		 target.IdFuenteFinanciamiento= source.IdFuenteFinanciamiento ;
		 target.Monto= source.Monto ;
		 target.FuenteFinanciamiento_Codigo= source.FuenteFinanciamiento_Codigo;	
			target.FuenteFinanciamiento_Nombre= source.FuenteFinanciamiento_Nombre;	
			target.FuenteFinanciamiento_IdFuenteFinanciamientoTipo= source.FuenteFinanciamiento_IdFuenteFinanciamientoTipo;	
			target.FuenteFinanciamiento_Activo= source.FuenteFinanciamiento_Activo;	
			target.FuenteFinanciamiento_IdFuenteFinanciamientoPadre= source.FuenteFinanciamiento_IdFuenteFinanciamientoPadre;	
			target.FuenteFinanciamiento_BreadcrumbId= source.FuenteFinanciamiento_BreadcrumbId;	
			target.FuenteFinanciamiento_BreadcrumbOrden= source.FuenteFinanciamiento_BreadcrumbOrden;	
			target.FuenteFinanciamiento_Nivel= source.FuenteFinanciamiento_Nivel;	
			target.FuenteFinanciamiento_Orden= source.FuenteFinanciamiento_Orden;	
			target.FuenteFinanciamiento_Descripcion= source.FuenteFinanciamiento_Descripcion;	
			target.FuenteFinanciamiento_DescripcionInvertida= source.FuenteFinanciamiento_DescripcionInvertida;	
			target.FuenteFinanciamiento_Seleccionable= source.FuenteFinanciamiento_Seleccionable;	
			target.FuenteFinanciamiento_BreadcrumbCode= source.FuenteFinanciamiento_BreadcrumbCode;	
			target.FuenteFinanciamiento_DescripcionCodigo= source.FuenteFinanciamiento_DescripcionCodigo;	
			target.PrestamoComponente_IdPrestamo= source.PrestamoComponente_IdPrestamo;	
			target.PrestamoComponente_IdObjetivo= source.PrestamoComponente_IdObjetivo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(PrestamoFinanciamiento source,PrestamoFinanciamiento target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoFinanciamiento.Equals(target.IdPrestamoFinanciamiento))return false;
		  if(!source.IdPrestamoComponente.Equals(target.IdPrestamoComponente))return false;
		  if((source.IdPrestamoSubComponente == null)?(target.IdPrestamoSubComponente.HasValue):!source.IdPrestamoSubComponente.Equals(target.IdPrestamoSubComponente))return false;
			 if(!source.IdFuenteFinanciamiento.Equals(target.IdFuenteFinanciamiento))return false;
		  if(!source.Monto.Equals(target.Monto))return false;
		 
		  return true;
        }
		public override bool Equals(PrestamoFinanciamientoResult source,PrestamoFinanciamientoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoFinanciamiento.Equals(target.IdPrestamoFinanciamiento))return false;
		  if(!source.IdPrestamoComponente.Equals(target.IdPrestamoComponente))return false;
		  if((source.IdPrestamoSubComponente == null)?(target.IdPrestamoSubComponente.HasValue):!source.IdPrestamoSubComponente.Equals(target.IdPrestamoSubComponente))return false;
			 if(!source.IdFuenteFinanciamiento.Equals(target.IdFuenteFinanciamiento))return false;
		  if(!source.Monto.Equals(target.Monto))return false;
		  if((source.FuenteFinanciamiento_Codigo == null)?target.FuenteFinanciamiento_Codigo!=null: !( (target.FuenteFinanciamiento_Codigo== String.Empty && source.FuenteFinanciamiento_Codigo== null) || (target.FuenteFinanciamiento_Codigo==null && source.FuenteFinanciamiento_Codigo== String.Empty )) &&   !source.FuenteFinanciamiento_Codigo.Trim().Replace ("\r","").Equals(target.FuenteFinanciamiento_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.FuenteFinanciamiento_Nombre == null)?target.FuenteFinanciamiento_Nombre!=null: !( (target.FuenteFinanciamiento_Nombre== String.Empty && source.FuenteFinanciamiento_Nombre== null) || (target.FuenteFinanciamiento_Nombre==null && source.FuenteFinanciamiento_Nombre== String.Empty )) &&   !source.FuenteFinanciamiento_Nombre.Trim().Replace ("\r","").Equals(target.FuenteFinanciamiento_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.FuenteFinanciamiento_IdFuenteFinanciamientoTipo.Equals(target.FuenteFinanciamiento_IdFuenteFinanciamientoTipo))return false;
					  if(!source.FuenteFinanciamiento_Activo.Equals(target.FuenteFinanciamiento_Activo))return false;
					  if((source.FuenteFinanciamiento_IdFuenteFinanciamientoPadre == null)?(target.FuenteFinanciamiento_IdFuenteFinanciamientoPadre.HasValue && target.FuenteFinanciamiento_IdFuenteFinanciamientoPadre.Value > 0):!source.FuenteFinanciamiento_IdFuenteFinanciamientoPadre.Equals(target.FuenteFinanciamiento_IdFuenteFinanciamientoPadre))return false;
									  if((source.FuenteFinanciamiento_BreadcrumbId == null)?target.FuenteFinanciamiento_BreadcrumbId!=null: !( (target.FuenteFinanciamiento_BreadcrumbId== String.Empty && source.FuenteFinanciamiento_BreadcrumbId== null) || (target.FuenteFinanciamiento_BreadcrumbId==null && source.FuenteFinanciamiento_BreadcrumbId== String.Empty )) &&   !source.FuenteFinanciamiento_BreadcrumbId.Trim().Replace ("\r","").Equals(target.FuenteFinanciamiento_BreadcrumbId.Trim().Replace ("\r","")))return false;
						 if((source.FuenteFinanciamiento_BreadcrumbOrden == null)?target.FuenteFinanciamiento_BreadcrumbOrden!=null: !( (target.FuenteFinanciamiento_BreadcrumbOrden== String.Empty && source.FuenteFinanciamiento_BreadcrumbOrden== null) || (target.FuenteFinanciamiento_BreadcrumbOrden==null && source.FuenteFinanciamiento_BreadcrumbOrden== String.Empty )) &&   !source.FuenteFinanciamiento_BreadcrumbOrden.Trim().Replace ("\r","").Equals(target.FuenteFinanciamiento_BreadcrumbOrden.Trim().Replace ("\r","")))return false;
						 if((source.FuenteFinanciamiento_Nivel == null)?(target.FuenteFinanciamiento_Nivel.HasValue ):!source.FuenteFinanciamiento_Nivel.Equals(target.FuenteFinanciamiento_Nivel))return false;
						 if((source.FuenteFinanciamiento_Orden == null)?(target.FuenteFinanciamiento_Orden.HasValue ):!source.FuenteFinanciamiento_Orden.Equals(target.FuenteFinanciamiento_Orden))return false;
						 if((source.FuenteFinanciamiento_Descripcion == null)?target.FuenteFinanciamiento_Descripcion!=null: !( (target.FuenteFinanciamiento_Descripcion== String.Empty && source.FuenteFinanciamiento_Descripcion== null) || (target.FuenteFinanciamiento_Descripcion==null && source.FuenteFinanciamiento_Descripcion== String.Empty )) &&   !source.FuenteFinanciamiento_Descripcion.Trim().Replace ("\r","").Equals(target.FuenteFinanciamiento_Descripcion.Trim().Replace ("\r","")))return false;
						 if((source.FuenteFinanciamiento_DescripcionInvertida == null)?target.FuenteFinanciamiento_DescripcionInvertida!=null: !( (target.FuenteFinanciamiento_DescripcionInvertida== String.Empty && source.FuenteFinanciamiento_DescripcionInvertida== null) || (target.FuenteFinanciamiento_DescripcionInvertida==null && source.FuenteFinanciamiento_DescripcionInvertida== String.Empty )) &&   !source.FuenteFinanciamiento_DescripcionInvertida.Trim().Replace ("\r","").Equals(target.FuenteFinanciamiento_DescripcionInvertida.Trim().Replace ("\r","")))return false;
						 if(!source.FuenteFinanciamiento_Seleccionable.Equals(target.FuenteFinanciamiento_Seleccionable))return false;
					  if((source.FuenteFinanciamiento_BreadcrumbCode == null)?target.FuenteFinanciamiento_BreadcrumbCode!=null: !( (target.FuenteFinanciamiento_BreadcrumbCode== String.Empty && source.FuenteFinanciamiento_BreadcrumbCode== null) || (target.FuenteFinanciamiento_BreadcrumbCode==null && source.FuenteFinanciamiento_BreadcrumbCode== String.Empty )) &&   !source.FuenteFinanciamiento_BreadcrumbCode.Trim().Replace ("\r","").Equals(target.FuenteFinanciamiento_BreadcrumbCode.Trim().Replace ("\r","")))return false;
						 if((source.FuenteFinanciamiento_DescripcionCodigo == null)?target.FuenteFinanciamiento_DescripcionCodigo!=null: !( (target.FuenteFinanciamiento_DescripcionCodigo== String.Empty && source.FuenteFinanciamiento_DescripcionCodigo== null) || (target.FuenteFinanciamiento_DescripcionCodigo==null && source.FuenteFinanciamiento_DescripcionCodigo== String.Empty )) &&   !source.FuenteFinanciamiento_DescripcionCodigo.Trim().Replace ("\r","").Equals(target.FuenteFinanciamiento_DescripcionCodigo.Trim().Replace ("\r","")))return false;
						 if(!source.PrestamoComponente_IdPrestamo.Equals(target.PrestamoComponente_IdPrestamo))return false;
					  if(!source.PrestamoComponente_IdObjetivo.Equals(target.PrestamoComponente_IdObjetivo))return false;
					 		
		  return true;
        }
		#endregion
    }
}

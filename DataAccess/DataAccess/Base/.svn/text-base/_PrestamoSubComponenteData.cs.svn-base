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
    public abstract class _PrestamoSubComponenteData : EntityData<PrestamoSubComponente,PrestamoSubComponenteFilter,PrestamoSubComponenteResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.PrestamoSubComponente entity)
		{			
			return entity.IdPrestamoSubComponente;
		}		
		public override PrestamoSubComponente GetByEntity(PrestamoSubComponente entity)
        {
            return this.GetById(entity.IdPrestamoSubComponente);
        }
        public override PrestamoSubComponente GetById(int id)
        {
            return (from o in this.Table where o.IdPrestamoSubComponente == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<PrestamoSubComponente> Query(PrestamoSubComponenteFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPrestamoSubComponente == null || filter.IdPrestamoSubComponente == 0 || o.IdPrestamoSubComponente==filter.IdPrestamoSubComponente)
					  && (filter.IdPrestamoComponente == null || filter.IdPrestamoComponente == 0 || o.IdPrestamoComponente==filter.IdPrestamoComponente)
					  && (filter.Descripcion == null || filter.Descripcion.Trim() == string.Empty || filter.Descripcion.Trim() == "%"  || (filter.Descripcion.EndsWith("%") && filter.Descripcion.StartsWith("%") && (o.Descripcion.Contains(filter.Descripcion.Replace("%", "")))) || (filter.Descripcion.EndsWith("%") && o.Descripcion.StartsWith(filter.Descripcion.Replace("%",""))) || (filter.Descripcion.StartsWith("%") && o.Descripcion.EndsWith(filter.Descripcion.Replace("%",""))) || o.Descripcion == filter.Descripcion )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PrestamoSubComponenteResult> QueryResult(PrestamoSubComponenteFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.PrestamoComponentes on o.IdPrestamoComponente equals t1.IdPrestamoComponente   
				   select new PrestamoSubComponenteResult(){
					 IdPrestamoSubComponente=o.IdPrestamoSubComponente
					 ,IdPrestamoComponente=o.IdPrestamoComponente
					 ,Descripcion=o.Descripcion
					,PrestamoComponente_IdPrestamo= t1.IdPrestamo	
						,PrestamoComponente_IdObjetivo= t1.IdObjetivo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.PrestamoSubComponente Copy(nc.PrestamoSubComponente entity)
        {           
            nc.PrestamoSubComponente _new = new nc.PrestamoSubComponente();
		 _new.IdPrestamoComponente= entity.IdPrestamoComponente;
		 _new.Descripcion= entity.Descripcion;
		return _new;			
        }
		public override int CopyAndSave(PrestamoSubComponente entity,string renameFormat)
        {
            PrestamoSubComponente  newEntity = Copy(entity);
            newEntity.Descripcion = string.Format(renameFormat,newEntity.Descripcion);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(PrestamoSubComponente entity, int id)
        {            
            entity.IdPrestamoSubComponente = id;            
        }
		public override void Set(PrestamoSubComponente source,PrestamoSubComponente target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoSubComponente= source.IdPrestamoSubComponente ;
		 target.IdPrestamoComponente= source.IdPrestamoComponente ;
		 target.Descripcion= source.Descripcion ;
		 		  
		}
		public override void Set(PrestamoSubComponenteResult source,PrestamoSubComponente target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoSubComponente= source.IdPrestamoSubComponente ;
		 target.IdPrestamoComponente= source.IdPrestamoComponente ;
		 target.Descripcion= source.Descripcion ;
		 
		}
		public override void Set(PrestamoSubComponente source,PrestamoSubComponenteResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoSubComponente= source.IdPrestamoSubComponente ;
		 target.IdPrestamoComponente= source.IdPrestamoComponente ;
		 target.Descripcion= source.Descripcion ;
		 	
		}		
		public override void Set(PrestamoSubComponenteResult source,PrestamoSubComponenteResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoSubComponente= source.IdPrestamoSubComponente ;
		 target.IdPrestamoComponente= source.IdPrestamoComponente ;
		 target.Descripcion= source.Descripcion ;
		 target.PrestamoComponente_IdPrestamo= source.PrestamoComponente_IdPrestamo;	
			target.PrestamoComponente_IdObjetivo= source.PrestamoComponente_IdObjetivo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(PrestamoSubComponente source,PrestamoSubComponente target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoSubComponente.Equals(target.IdPrestamoSubComponente))return false;
		  if(!source.IdPrestamoComponente.Equals(target.IdPrestamoComponente))return false;
		  if((source.Descripcion == null)?target.Descripcion!=null:  !( (target.Descripcion== String.Empty && source.Descripcion== null) || (target.Descripcion==null && source.Descripcion== String.Empty )) &&  !source.Descripcion.Trim().Replace ("\r","").Equals(target.Descripcion.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(PrestamoSubComponenteResult source,PrestamoSubComponenteResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoSubComponente.Equals(target.IdPrestamoSubComponente))return false;
		  if(!source.IdPrestamoComponente.Equals(target.IdPrestamoComponente))return false;
		  if((source.Descripcion == null)?target.Descripcion!=null: !( (target.Descripcion== String.Empty && source.Descripcion== null) || (target.Descripcion==null && source.Descripcion== String.Empty )) && !source.Descripcion.Trim().Replace ("\r","").Equals(target.Descripcion.Trim().Replace ("\r","")))return false;
			 if(!source.PrestamoComponente_IdPrestamo.Equals(target.PrestamoComponente_IdPrestamo))return false;
					  if(!source.PrestamoComponente_IdObjetivo.Equals(target.PrestamoComponente_IdObjetivo))return false;
					 		
		  return true;
        }
		#endregion
    }
}

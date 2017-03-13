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
    public abstract class _ObjetivoSupuestoData : EntityData<ObjetivoSupuesto,ObjetivoSupuestoFilter,ObjetivoSupuestoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ObjetivoSupuesto entity)
		{			
			return entity.IdObjetivoSupuesto;
		}		
		public override ObjetivoSupuesto GetByEntity(ObjetivoSupuesto entity)
        {
            return this.GetById(entity.IdObjetivoSupuesto);
        }
        public override ObjetivoSupuesto GetById(int id)
        {
            return (from o in this.Table where o.IdObjetivoSupuesto == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ObjetivoSupuesto> Query(ObjetivoSupuestoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdObjetivoSupuesto == null || o.IdObjetivoSupuesto >=  filter.IdObjetivoSupuesto) && (filter.IdObjetivoSupuesto_To == null || o.IdObjetivoSupuesto <= filter.IdObjetivoSupuesto_To)
					  && (filter.IdObjetivo == null || filter.IdObjetivo == 0 || o.IdObjetivo==filter.IdObjetivo)
					  && (filter.Descripcion == null || filter.Descripcion.Trim() == string.Empty || filter.Descripcion.Trim() == "%"  || (filter.Descripcion.EndsWith("%") && filter.Descripcion.StartsWith("%") && (o.Descripcion.Contains(filter.Descripcion.Replace("%", "")))) || (filter.Descripcion.EndsWith("%") && o.Descripcion.StartsWith(filter.Descripcion.Replace("%",""))) || (filter.Descripcion.StartsWith("%") && o.Descripcion.EndsWith(filter.Descripcion.Replace("%",""))) || o.Descripcion == filter.Descripcion )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ObjetivoSupuestoResult> QueryResult(ObjetivoSupuestoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Objetivos on o.IdObjetivo equals t1.IdObjetivo   
				   select new ObjetivoSupuestoResult(){
					 IdObjetivoSupuesto=o.IdObjetivoSupuesto
					 ,IdObjetivo=o.IdObjetivo
					 ,Descripcion=o.Descripcion
					,Objetivo_Nombre= t1.Nombre	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ObjetivoSupuesto Copy(nc.ObjetivoSupuesto entity)
        {           
            nc.ObjetivoSupuesto _new = new nc.ObjetivoSupuesto();
		 _new.IdObjetivo= entity.IdObjetivo;
		 _new.Descripcion= entity.Descripcion;
		return _new;			
        }
		public override int CopyAndSave(ObjetivoSupuesto entity,string renameFormat)
        {
            ObjetivoSupuesto  newEntity = Copy(entity);
            newEntity.Descripcion = string.Format(renameFormat,newEntity.Descripcion);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ObjetivoSupuesto entity, int id)
        {            
            entity.IdObjetivoSupuesto = id;            
        }
		public override void Set(ObjetivoSupuesto source,ObjetivoSupuesto target,bool hadSetId)
		{		   
		if(hadSetId)target.IdObjetivoSupuesto= source.IdObjetivoSupuesto ;
		 target.IdObjetivo= source.IdObjetivo ;
		 target.Descripcion= source.Descripcion ;
		 		  
		}
		public override void Set(ObjetivoSupuestoResult source,ObjetivoSupuesto target,bool hadSetId)
		{		   
		if(hadSetId)target.IdObjetivoSupuesto= source.IdObjetivoSupuesto ;
		 target.IdObjetivo= source.IdObjetivo ;
		 target.Descripcion= source.Descripcion ;
		 
		}
		public override void Set(ObjetivoSupuesto source,ObjetivoSupuestoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdObjetivoSupuesto= source.IdObjetivoSupuesto ;
		 target.IdObjetivo= source.IdObjetivo ;
		 target.Descripcion= source.Descripcion ;
		 	
		}		
		public override void Set(ObjetivoSupuestoResult source,ObjetivoSupuestoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdObjetivoSupuesto= source.IdObjetivoSupuesto ;
		 target.IdObjetivo= source.IdObjetivo ;
		 target.Descripcion= source.Descripcion ;
		 target.Objetivo_Nombre= source.Objetivo_Nombre;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ObjetivoSupuesto source,ObjetivoSupuesto target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdObjetivoSupuesto.Equals(target.IdObjetivoSupuesto))return false;
		  if(!source.IdObjetivo.Equals(target.IdObjetivo))return false;
		  if((source.Descripcion == null)?target.Descripcion!=null:  !( (target.Descripcion== String.Empty && source.Descripcion== null) || (target.Descripcion==null && source.Descripcion== String.Empty )) &&  !source.Descripcion.Trim().Replace ("\r","").Equals(target.Descripcion.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(ObjetivoSupuestoResult source,ObjetivoSupuestoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdObjetivoSupuesto.Equals(target.IdObjetivoSupuesto))return false;
		  if(!source.IdObjetivo.Equals(target.IdObjetivo))return false;
		  if((source.Descripcion == null)?target.Descripcion!=null: !( (target.Descripcion== String.Empty && source.Descripcion== null) || (target.Descripcion==null && source.Descripcion== String.Empty )) && !source.Descripcion.Trim().Replace ("\r","").Equals(target.Descripcion.Trim().Replace ("\r","")))return false;
			 if((source.Objetivo_Nombre == null)?target.Objetivo_Nombre!=null: !( (target.Objetivo_Nombre== String.Empty && source.Objetivo_Nombre== null) || (target.Objetivo_Nombre==null && source.Objetivo_Nombre== String.Empty )) &&   !source.Objetivo_Nombre.Trim().Replace ("\r","").Equals(target.Objetivo_Nombre.Trim().Replace ("\r","")))return false;
								
		  return true;
        }
		#endregion
    }
}

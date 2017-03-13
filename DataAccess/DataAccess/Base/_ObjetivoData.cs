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
    public abstract class _ObjetivoData : EntityData<Objetivo,ObjetivoFilter,ObjetivoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Objetivo entity)
		{			
			return entity.IdObjetivo;
		}		
		public override Objetivo GetByEntity(Objetivo entity)
        {
            return this.GetById(entity.IdObjetivo);
        }
        public override Objetivo GetById(int id)
        {
            return (from o in this.Table where o.IdObjetivo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Objetivo> Query(ObjetivoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdObjetivo == null || filter.IdObjetivo == 0 || o.IdObjetivo==filter.IdObjetivo)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ObjetivoResult> QueryResult(ObjetivoFilter filter)
        {
		  return (from o in Query(filter)					
					select new ObjetivoResult(){
					 IdObjetivo=o.IdObjetivo
					 ,Nombre=o.Nombre
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Objetivo Copy(nc.Objetivo entity)
        {           
            nc.Objetivo _new = new nc.Objetivo();
		 _new.Nombre= entity.Nombre;
		return _new;			
        }
		public override int CopyAndSave(Objetivo entity,string renameFormat)
        {
            Objetivo  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Objetivo entity, int id)
        {            
            entity.IdObjetivo = id;            
        }
		public override void Set(Objetivo source,Objetivo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdObjetivo= source.IdObjetivo ;
		 target.Nombre= source.Nombre ;
		 		  
		}
		public override void Set(ObjetivoResult source,Objetivo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdObjetivo= source.IdObjetivo ;
		 target.Nombre= source.Nombre ;
		 
		}
		public override void Set(Objetivo source,ObjetivoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdObjetivo= source.IdObjetivo ;
		 target.Nombre= source.Nombre ;
		 	
		}		
		public override void Set(ObjetivoResult source,ObjetivoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdObjetivo= source.IdObjetivo ;
		 target.Nombre= source.Nombre ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(Objetivo source,Objetivo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdObjetivo.Equals(target.IdObjetivo))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(ObjetivoResult source,ObjetivoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdObjetivo.Equals(target.IdObjetivo))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
					
		  return true;
        }
		#endregion
    }
}

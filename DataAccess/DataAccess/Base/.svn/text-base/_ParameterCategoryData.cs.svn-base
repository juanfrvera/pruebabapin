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
    public abstract class _ParameterCategoryData : EntityData<ParameterCategory,ParameterCategoryFilter,ParameterCategoryResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ParameterCategory entity)
		{			
			return entity.IdParameterCategoty;
		}		
		public override ParameterCategory GetByEntity(ParameterCategory entity)
        {
            return this.GetById(entity.IdParameterCategoty);
        }
        public override ParameterCategory GetById(int id)
        {
            return (from o in this.Table where o.IdParameterCategoty == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ParameterCategory> Query(ParameterCategoryFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdParameterCategoty == null || filter.IdParameterCategoty == 0 || o.IdParameterCategoty==filter.IdParameterCategoty)
					  && (filter.Name == null || filter.Name.Trim() == string.Empty || filter.Name.Trim() == "%"  || (filter.Name.EndsWith("%") && filter.Name.StartsWith("%") && (o.Name.Contains(filter.Name.Replace("%", "")))) || (filter.Name.EndsWith("%") && o.Name.StartsWith(filter.Name.Replace("%",""))) || (filter.Name.StartsWith("%") && o.Name.EndsWith(filter.Name.Replace("%",""))) || o.Name == filter.Name )
					  && (filter.Description == null || filter.Description.Trim() == string.Empty || filter.Description.Trim() == "%"  || (filter.Description.EndsWith("%") && filter.Description.StartsWith("%") && (o.Description.Contains(filter.Description.Replace("%", "")))) || (filter.Description.EndsWith("%") && o.Description.StartsWith(filter.Description.Replace("%",""))) || (filter.Description.StartsWith("%") && o.Description.EndsWith(filter.Description.Replace("%",""))) || o.Description == filter.Description )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ParameterCategoryResult> QueryResult(ParameterCategoryFilter filter)
        {
		  return (from o in Query(filter)					
					select new ParameterCategoryResult(){
					 IdParameterCategoty=o.IdParameterCategoty
					 ,Name=o.Name
					 ,Description=o.Description
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ParameterCategory Copy(nc.ParameterCategory entity)
        {           
            nc.ParameterCategory _new = new nc.ParameterCategory();
		 _new.Name= entity.Name;
		 _new.Description= entity.Description;
		return _new;			
        }
		public override int CopyAndSave(ParameterCategory entity,string renameFormat)
        {
            ParameterCategory  newEntity = Copy(entity);
            newEntity.Name = string.Format(renameFormat,newEntity.Name);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ParameterCategory entity, int id)
        {            
            entity.IdParameterCategoty = id;            
        }
		public override void Set(ParameterCategory source,ParameterCategory target,bool hadSetId)
		{		   
		if(hadSetId)target.IdParameterCategoty= source.IdParameterCategoty ;
		 target.Name= source.Name ;
		 target.Description= source.Description ;
		 		  
		}
		public override void Set(ParameterCategoryResult source,ParameterCategory target,bool hadSetId)
		{		   
		if(hadSetId)target.IdParameterCategoty= source.IdParameterCategoty ;
		 target.Name= source.Name ;
		 target.Description= source.Description ;
		 
		}
		public override void Set(ParameterCategory source,ParameterCategoryResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdParameterCategoty= source.IdParameterCategoty ;
		 target.Name= source.Name ;
		 target.Description= source.Description ;
		 	
		}		
		public override void Set(ParameterCategoryResult source,ParameterCategoryResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdParameterCategoty= source.IdParameterCategoty ;
		 target.Name= source.Name ;
		 target.Description= source.Description ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(ParameterCategory source,ParameterCategory target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdParameterCategoty.Equals(target.IdParameterCategoty))return false;
		  if((source.Name == null)?target.Name!=null:  !( (target.Name== String.Empty && source.Name== null) || (target.Name==null && source.Name== String.Empty )) &&  !source.Name.Trim().Replace ("\r","").Equals(target.Name.Trim().Replace ("\r","")))return false;
			 if((source.Description == null)?target.Description!=null:  !( (target.Description== String.Empty && source.Description== null) || (target.Description==null && source.Description== String.Empty )) &&  !source.Description.Trim().Replace ("\r","").Equals(target.Description.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(ParameterCategoryResult source,ParameterCategoryResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdParameterCategoty.Equals(target.IdParameterCategoty))return false;
		  if((source.Name == null)?target.Name!=null: !( (target.Name== String.Empty && source.Name== null) || (target.Name==null && source.Name== String.Empty )) && !source.Name.Trim().Replace ("\r","").Equals(target.Name.Trim().Replace ("\r","")))return false;
			 if((source.Description == null)?target.Description!=null: !( (target.Description== String.Empty && source.Description== null) || (target.Description==null && source.Description== String.Empty )) && !source.Description.Trim().Replace ("\r","").Equals(target.Description.Trim().Replace ("\r","")))return false;
					
		  return true;
        }
		#endregion
    }
}

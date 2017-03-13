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
    public abstract class _TextCategoryData : EntityData<TextCategory,TextCategoryFilter,TextCategoryResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.TextCategory entity)
		{			
			return entity.IdTextCategory;
		}		
		public override TextCategory GetByEntity(TextCategory entity)
        {
            return this.GetById(entity.IdTextCategory);
        }
        public override TextCategory GetById(int id)
        {
            return (from o in this.Table where o.IdTextCategory == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<TextCategory> Query(TextCategoryFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdTextCategory == null || filter.IdTextCategory == 0 || o.IdTextCategory==filter.IdTextCategory)
					  && (filter.Name == null || filter.Name.Trim() == string.Empty || filter.Name.Trim() == "%"  || (filter.Name.EndsWith("%") && filter.Name.StartsWith("%") && (o.Name.Contains(filter.Name.Replace("%", "")))) || (filter.Name.EndsWith("%") && o.Name.StartsWith(filter.Name.Replace("%",""))) || (filter.Name.StartsWith("%") && o.Name.EndsWith(filter.Name.Replace("%",""))) || o.Name == filter.Name )
					  && (filter.Description == null || filter.Description.Trim() == string.Empty || filter.Description.Trim() == "%"  || (filter.Description.EndsWith("%") && filter.Description.StartsWith("%") && (o.Description.Contains(filter.Description.Replace("%", "")))) || (filter.Description.EndsWith("%") && o.Description.StartsWith(filter.Description.Replace("%",""))) || (filter.Description.StartsWith("%") && o.Description.EndsWith(filter.Description.Replace("%",""))) || o.Description == filter.Description )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<TextCategoryResult> QueryResult(TextCategoryFilter filter)
        {
		  return (from o in Query(filter)					
					select new TextCategoryResult(){
					 IdTextCategory=o.IdTextCategory
					 ,Name=o.Name
					 ,Description=o.Description
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.TextCategory Copy(nc.TextCategory entity)
        {           
            nc.TextCategory _new = new nc.TextCategory();
		 _new.Name= entity.Name;
		 _new.Description= entity.Description;
		return _new;			
        }
		public override int CopyAndSave(TextCategory entity,string renameFormat)
        {
            TextCategory  newEntity = Copy(entity);
            newEntity.Name = string.Format(renameFormat,newEntity.Name);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(TextCategory entity, int id)
        {            
            entity.IdTextCategory = id;            
        }
		public override void Set(TextCategory source,TextCategory target,bool hadSetId)
		{		   
		if(hadSetId)target.IdTextCategory= source.IdTextCategory ;
		 target.Name= source.Name ;
		 target.Description= source.Description ;
		 		  
		}
		public override void Set(TextCategoryResult source,TextCategory target,bool hadSetId)
		{		   
		if(hadSetId)target.IdTextCategory= source.IdTextCategory ;
		 target.Name= source.Name ;
		 target.Description= source.Description ;
		 
		}
		public override void Set(TextCategory source,TextCategoryResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdTextCategory= source.IdTextCategory ;
		 target.Name= source.Name ;
		 target.Description= source.Description ;
		 	
		}		
		public override void Set(TextCategoryResult source,TextCategoryResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdTextCategory= source.IdTextCategory ;
		 target.Name= source.Name ;
		 target.Description= source.Description ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(TextCategory source,TextCategory target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdTextCategory.Equals(target.IdTextCategory))return false;
		  if((source.Name == null)?target.Name!=null:  !( (target.Name== String.Empty && source.Name== null) || (target.Name==null && source.Name== String.Empty )) &&  !source.Name.Trim().Replace ("\r","").Equals(target.Name.Trim().Replace ("\r","")))return false;
			 if((source.Description == null)?target.Description!=null:  !( (target.Description== String.Empty && source.Description== null) || (target.Description==null && source.Description== String.Empty )) &&  !source.Description.Trim().Replace ("\r","").Equals(target.Description.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(TextCategoryResult source,TextCategoryResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdTextCategory.Equals(target.IdTextCategory))return false;
		  if((source.Name == null)?target.Name!=null: !( (target.Name== String.Empty && source.Name== null) || (target.Name==null && source.Name== String.Empty )) && !source.Name.Trim().Replace ("\r","").Equals(target.Name.Trim().Replace ("\r","")))return false;
			 if((source.Description == null)?target.Description!=null: !( (target.Description== String.Empty && source.Description== null) || (target.Description==null && source.Description== String.Empty )) && !source.Description.Trim().Replace ("\r","").Equals(target.Description.Trim().Replace ("\r","")))return false;
					
		  return true;
        }
		#endregion
    }
}

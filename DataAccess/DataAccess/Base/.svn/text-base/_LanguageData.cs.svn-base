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
    public abstract class _LanguageData : EntityData<Language,LanguageFilter,LanguageResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Language entity)
		{			
			return entity.IdLanguage;
		}		
		public override Language GetByEntity(Language entity)
        {
            return this.GetById(entity.IdLanguage);
        }
        public override Language GetById(int id)
        {
            return (from o in this.Table where o.IdLanguage == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Language> Query(LanguageFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdLanguage == null || filter.IdLanguage == 0 || o.IdLanguage==filter.IdLanguage)
					  && (filter.Name == null || filter.Name.Trim() == string.Empty || filter.Name.Trim() == "%"  || (filter.Name.EndsWith("%") && filter.Name.StartsWith("%") && (o.Name.Contains(filter.Name.Replace("%", "")))) || (filter.Name.EndsWith("%") && o.Name.StartsWith(filter.Name.Replace("%",""))) || (filter.Name.StartsWith("%") && o.Name.EndsWith(filter.Name.Replace("%",""))) || o.Name == filter.Name )
					  && (filter.Code == null || filter.Code.Trim() == string.Empty || filter.Code.Trim() == "%"  || (filter.Code.EndsWith("%") && filter.Code.StartsWith("%") && (o.Code.Contains(filter.Code.Replace("%", "")))) || (filter.Code.EndsWith("%") && o.Code.StartsWith(filter.Code.Replace("%",""))) || (filter.Code.StartsWith("%") && o.Code.EndsWith(filter.Code.Replace("%",""))) || o.Code == filter.Code )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<LanguageResult> QueryResult(LanguageFilter filter)
        {
		  return (from o in Query(filter)					
					select new LanguageResult(){
					 IdLanguage=o.IdLanguage
					 ,Name=o.Name
					 ,Code=o.Code
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Language Copy(nc.Language entity)
        {           
            nc.Language _new = new nc.Language();
		 _new.Name= entity.Name;
		 _new.Code= entity.Code;
		return _new;			
        }
		public override int CopyAndSave(Language entity,string renameFormat)
        {
            Language  newEntity = Copy(entity);
            newEntity.Name = string.Format(renameFormat,newEntity.Name);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Language entity, int id)
        {            
            entity.IdLanguage = id;            
        }
		public override void Set(Language source,Language target,bool hadSetId)
		{		   
		if(hadSetId)target.IdLanguage= source.IdLanguage ;
		 target.Name= source.Name ;
		 target.Code= source.Code ;
		 		  
		}
		public override void Set(LanguageResult source,Language target,bool hadSetId)
		{		   
		if(hadSetId)target.IdLanguage= source.IdLanguage ;
		 target.Name= source.Name ;
		 target.Code= source.Code ;
		 
		}
		public override void Set(Language source,LanguageResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdLanguage= source.IdLanguage ;
		 target.Name= source.Name ;
		 target.Code= source.Code ;
		 	
		}		
		public override void Set(LanguageResult source,LanguageResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdLanguage= source.IdLanguage ;
		 target.Name= source.Name ;
		 target.Code= source.Code ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(Language source,Language target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdLanguage.Equals(target.IdLanguage))return false;
		  if((source.Name == null)?target.Name!=null:  !( (target.Name== String.Empty && source.Name== null) || (target.Name==null && source.Name== String.Empty )) &&  !source.Name.Trim().Replace ("\r","").Equals(target.Name.Trim().Replace ("\r","")))return false;
			 if((source.Code == null)?target.Code!=null:  !( (target.Code== String.Empty && source.Code== null) || (target.Code==null && source.Code== String.Empty )) &&  !source.Code.Trim().Replace ("\r","").Equals(target.Code.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(LanguageResult source,LanguageResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdLanguage.Equals(target.IdLanguage))return false;
		  if((source.Name == null)?target.Name!=null: !( (target.Name== String.Empty && source.Name== null) || (target.Name==null && source.Name== String.Empty )) && !source.Name.Trim().Replace ("\r","").Equals(target.Name.Trim().Replace ("\r","")))return false;
			 if((source.Code == null)?target.Code!=null: !( (target.Code== String.Empty && source.Code== null) || (target.Code==null && source.Code== String.Empty )) && !source.Code.Trim().Replace ("\r","").Equals(target.Code.Trim().Replace ("\r","")))return false;
					
		  return true;
        }
		#endregion
    }
}

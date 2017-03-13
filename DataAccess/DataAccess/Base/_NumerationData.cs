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
    public abstract class _NumerationData : EntityData<Numeration,NumerationFilter,NumerationResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Numeration entity)
		{			
			return entity.IdNumeration;
		}		
		public override Numeration GetByEntity(Numeration entity)
        {
            return this.GetById(entity.IdNumeration);
        }
        public override Numeration GetById(int id)
        {
            return (from o in this.Table where o.IdNumeration == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Numeration> Query(NumerationFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdNumeration == null || o.IdNumeration >=  filter.IdNumeration) && (filter.IdNumeration_To == null || o.IdNumeration <= filter.IdNumeration_To)
					  && (filter.Code == null || filter.Code.Trim() == string.Empty || filter.Code.Trim() == "%"  || (filter.Code.EndsWith("%") && filter.Code.StartsWith("%") && (o.Code.Contains(filter.Code.Replace("%", "")))) || (filter.Code.EndsWith("%") && o.Code.StartsWith(filter.Code.Replace("%",""))) || (filter.Code.StartsWith("%") && o.Code.EndsWith(filter.Code.Replace("%",""))) || o.Code == filter.Code )
					  && (filter.Lastvalue == null || o.Lastvalue >=  filter.Lastvalue) && (filter.Lastvalue_To == null || o.Lastvalue <= filter.Lastvalue_To)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<NumerationResult> QueryResult(NumerationFilter filter)
        {
		  return (from o in Query(filter)					
					select new NumerationResult(){
					 IdNumeration=o.IdNumeration
					 ,Code=o.Code
					 ,Lastvalue=o.Lastvalue
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Numeration Copy(nc.Numeration entity)
        {           
            nc.Numeration _new = new nc.Numeration();
		 _new.Code= entity.Code;
		 _new.Lastvalue= entity.Lastvalue;
		return _new;			
        }
		public override int CopyAndSave(Numeration entity,string renameFormat)
        {
            Numeration  newEntity = Copy(entity);
            newEntity.Code = string.Format(renameFormat,newEntity.Code);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Numeration entity, int id)
        {            
            entity.IdNumeration = id;            
        }
		public override void Set(Numeration source,Numeration target,bool hadSetId)
		{		   
		if(hadSetId)target.IdNumeration= source.IdNumeration ;
		 target.Code= source.Code ;
		 target.Lastvalue= source.Lastvalue ;
		 		  
		}
		public override void Set(NumerationResult source,Numeration target,bool hadSetId)
		{		   
		if(hadSetId)target.IdNumeration= source.IdNumeration ;
		 target.Code= source.Code ;
		 target.Lastvalue= source.Lastvalue ;
		 
		}
		public override void Set(Numeration source,NumerationResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdNumeration= source.IdNumeration ;
		 target.Code= source.Code ;
		 target.Lastvalue= source.Lastvalue ;
		 	
		}		
		public override void Set(NumerationResult source,NumerationResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdNumeration= source.IdNumeration ;
		 target.Code= source.Code ;
		 target.Lastvalue= source.Lastvalue ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(Numeration source,Numeration target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdNumeration.Equals(target.IdNumeration))return false;
		  if((source.Code == null)?target.Code!=null:  !( (target.Code== String.Empty && source.Code== null) || (target.Code==null && source.Code== String.Empty )) &&  !source.Code.Trim().Replace ("\r","").Equals(target.Code.Trim().Replace ("\r","")))return false;
			 if(!source.Lastvalue.Equals(target.Lastvalue))return false;
		 
		  return true;
        }
		public override bool Equals(NumerationResult source,NumerationResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdNumeration.Equals(target.IdNumeration))return false;
		  if((source.Code == null)?target.Code!=null: !( (target.Code== String.Empty && source.Code== null) || (target.Code==null && source.Code== String.Empty )) && !source.Code.Trim().Replace ("\r","").Equals(target.Code.Trim().Replace ("\r","")))return false;
			 if(!source.Lastvalue.Equals(target.Lastvalue))return false;
		 		
		  return true;
        }
		#endregion
    }
}

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
    public abstract class _PriorityData : EntityData<Priority,PriorityFilter,PriorityResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Priority entity)
		{			
			return entity.IdPriority;
		}		
		public override Priority GetByEntity(Priority entity)
        {
            return this.GetById(entity.IdPriority);
        }
        public override Priority GetById(int id)
        {
            return (from o in this.Table where o.IdPriority == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Priority> Query(PriorityFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPriority == null || filter.IdPriority == 0 || o.IdPriority==filter.IdPriority)
					  && (filter.Name == null || filter.Name.Trim() == string.Empty || filter.Name.Trim() == "%"  || (filter.Name.EndsWith("%") && filter.Name.StartsWith("%") && (o.Name.Contains(filter.Name.Replace("%", "")))) || (filter.Name.EndsWith("%") && o.Name.StartsWith(filter.Name.Replace("%",""))) || (filter.Name.StartsWith("%") && o.Name.EndsWith(filter.Name.Replace("%",""))) || o.Name == filter.Name )
					  && (filter.Img == null || filter.Img.Trim() == string.Empty || filter.Img.Trim() == "%"  || (filter.Img.EndsWith("%") && filter.Img.StartsWith("%") && (o.Img.Contains(filter.Img.Replace("%", "")))) || (filter.Img.EndsWith("%") && o.Img.StartsWith(filter.Img.Replace("%",""))) || (filter.Img.StartsWith("%") && o.Img.EndsWith(filter.Img.Replace("%",""))) || o.Img == filter.Img )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PriorityResult> QueryResult(PriorityFilter filter)
        {
		  return (from o in Query(filter)					
					select new PriorityResult(){
					 IdPriority=o.IdPriority
					 ,Name=o.Name
					 ,Img=o.Img
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Priority Copy(nc.Priority entity)
        {           
            nc.Priority _new = new nc.Priority();
		 _new.Name= entity.Name;
		 _new.Img= entity.Img;
		return _new;			
        }
		public override int CopyAndSave(Priority entity,string renameFormat)
        {
            Priority  newEntity = Copy(entity);
            newEntity.Name = string.Format(renameFormat,newEntity.Name);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Priority entity, int id)
        {            
            entity.IdPriority = id;            
        }
		public override void Set(Priority source,Priority target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPriority= source.IdPriority ;
		 target.Name= source.Name ;
		 target.Img= source.Img ;
		 		  
		}
		public override void Set(PriorityResult source,Priority target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPriority= source.IdPriority ;
		 target.Name= source.Name ;
		 target.Img= source.Img ;
		 
		}
		public override void Set(Priority source,PriorityResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPriority= source.IdPriority ;
		 target.Name= source.Name ;
		 target.Img= source.Img ;
		 	
		}		
		public override void Set(PriorityResult source,PriorityResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPriority= source.IdPriority ;
		 target.Name= source.Name ;
		 target.Img= source.Img ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(Priority source,Priority target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPriority.Equals(target.IdPriority))return false;
		  if((source.Name == null)?target.Name!=null:  !( (target.Name== String.Empty && source.Name== null) || (target.Name==null && source.Name== String.Empty )) &&  !source.Name.Trim().Replace ("\r","").Equals(target.Name.Trim().Replace ("\r","")))return false;
			 if((source.Img == null)?target.Img!=null:  !( (target.Img== String.Empty && source.Img== null) || (target.Img==null && source.Img== String.Empty )) &&  !source.Img.Trim().Replace ("\r","").Equals(target.Img.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(PriorityResult source,PriorityResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPriority.Equals(target.IdPriority))return false;
		  if((source.Name == null)?target.Name!=null: !( (target.Name== String.Empty && source.Name== null) || (target.Name==null && source.Name== String.Empty )) && !source.Name.Trim().Replace ("\r","").Equals(target.Name.Trim().Replace ("\r","")))return false;
			 if((source.Img == null)?target.Img!=null: !( (target.Img== String.Empty && source.Img== null) || (target.Img==null && source.Img== String.Empty )) && !source.Img.Trim().Replace ("\r","").Equals(target.Img.Trim().Replace ("\r","")))return false;
					
		  return true;
        }
		#endregion
    }
}

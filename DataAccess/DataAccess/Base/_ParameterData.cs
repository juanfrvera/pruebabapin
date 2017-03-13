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
    public abstract class _ParameterData : EntityData<Parameter,ParameterFilter,ParameterResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Parameter entity)
		{			
			return entity.IdParameter;
		}		
		public override Parameter GetByEntity(Parameter entity)
        {
            return this.GetById(entity.IdParameter);
        }
        public override Parameter GetById(int id)
        {
            return (from o in this.Table where o.IdParameter == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Parameter> Query(ParameterFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdParameter == null || o.IdParameter >=  filter.IdParameter) && (filter.IdParameter_To == null || o.IdParameter <= filter.IdParameter_To)
					  && (filter.Name == null || filter.Name.Trim() == string.Empty || filter.Name.Trim() == "%"  || (filter.Name.EndsWith("%") && filter.Name.StartsWith("%") && (o.Name.Contains(filter.Name.Replace("%", "")))) || (filter.Name.EndsWith("%") && o.Name.StartsWith(filter.Name.Replace("%",""))) || (filter.Name.StartsWith("%") && o.Name.EndsWith(filter.Name.Replace("%",""))) || o.Name == filter.Name )
					  && (filter.Code == null || filter.Code.Trim() == string.Empty || filter.Code.Trim() == "%"  || (filter.Code.EndsWith("%") && filter.Code.StartsWith("%") && (o.Code.Contains(filter.Code.Replace("%", "")))) || (filter.Code.EndsWith("%") && o.Code.StartsWith(filter.Code.Replace("%",""))) || (filter.Code.StartsWith("%") && o.Code.EndsWith(filter.Code.Replace("%",""))) || o.Code == filter.Code )
					  && (filter.Description == null || filter.Description.Trim() == string.Empty || filter.Description.Trim() == "%"  || (filter.Description.EndsWith("%") && filter.Description.StartsWith("%") && (o.Description.Contains(filter.Description.Replace("%", "")))) || (filter.Description.EndsWith("%") && o.Description.StartsWith(filter.Description.Replace("%",""))) || (filter.Description.StartsWith("%") && o.Description.EndsWith(filter.Description.Replace("%",""))) || o.Description == filter.Description )
					  && (filter.IdParameterCategory == null || filter.IdParameterCategory == 0 || o.IdParameterCategory==filter.IdParameterCategory)
					  && (filter.StringValue == null || filter.StringValue.Trim() == string.Empty || filter.StringValue.Trim() == "%"  || (filter.StringValue.EndsWith("%") && filter.StringValue.StartsWith("%") && (o.StringValue.Contains(filter.StringValue.Replace("%", "")))) || (filter.StringValue.EndsWith("%") && o.StringValue.StartsWith(filter.StringValue.Replace("%",""))) || (filter.StringValue.StartsWith("%") && o.StringValue.EndsWith(filter.StringValue.Replace("%",""))) || o.StringValue == filter.StringValue )
					  && (filter.NumberValue == null || o.NumberValue >=  filter.NumberValue) && (filter.NumberValue_To == null || o.NumberValue <= filter.NumberValue_To)
					  && (filter.NumberValueIsNull == null || filter.NumberValueIsNull == true || o.NumberValue != null ) && (filter.NumberValueIsNull == null || filter.NumberValueIsNull == false || o.NumberValue == null)
					  && (filter.DateValue == null || filter.DateValue == DateTime.MinValue || o.DateValue >=  filter.DateValue) && (filter.DateValue_To == null || filter.DateValue_To == DateTime.MinValue || o.DateValue <= filter.DateValue_To)
					  && (filter.DateValueIsNull == null || filter.DateValueIsNull == true || o.DateValue != null ) && (filter.DateValueIsNull == null || filter.DateValueIsNull == false || o.DateValue == null)
					  && (filter.TextValue == null || filter.TextValue.Trim() == string.Empty || filter.TextValue.Trim() == "%"  || (filter.TextValue.EndsWith("%") && filter.TextValue.StartsWith("%") && (o.TextValue.Contains(filter.TextValue.Replace("%", "")))) || (filter.TextValue.EndsWith("%") && o.TextValue.StartsWith(filter.TextValue.Replace("%",""))) || (filter.TextValue.StartsWith("%") && o.TextValue.EndsWith(filter.TextValue.Replace("%",""))) || o.TextValue == filter.TextValue )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ParameterResult> QueryResult(ParameterFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.ParameterCategories on o.IdParameterCategory equals t1.IdParameterCategoty   
				   select new ParameterResult(){
					 IdParameter=o.IdParameter
					 ,Name=o.Name
					 ,Code=o.Code
					 ,Description=o.Description
					 ,IdParameterCategory=o.IdParameterCategory
					 ,StringValue=o.StringValue
					 ,NumberValue=o.NumberValue
					 ,DateValue=o.DateValue
					 ,TextValue=o.TextValue
					,ParameterCategory_Name= t1.Name	
						,ParameterCategory_Description= t1.Description	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Parameter Copy(nc.Parameter entity)
        {           
            nc.Parameter _new = new nc.Parameter();
		 _new.Name= entity.Name;
		 _new.Code= entity.Code;
		 _new.Description= entity.Description;
		 _new.IdParameterCategory= entity.IdParameterCategory;
		 _new.StringValue= entity.StringValue;
		 _new.NumberValue= entity.NumberValue;
		 _new.DateValue= entity.DateValue;
		 _new.TextValue= entity.TextValue;
		return _new;			
        }
		public override int CopyAndSave(Parameter entity,string renameFormat)
        {
            Parameter  newEntity = Copy(entity);
            newEntity.Name = string.Format(renameFormat,newEntity.Name);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Parameter entity, int id)
        {            
            entity.IdParameter = id;            
        }
		public override void Set(Parameter source,Parameter target,bool hadSetId)
		{		   
		if(hadSetId)target.IdParameter= source.IdParameter ;
		 target.Name= source.Name ;
		 target.Code= source.Code ;
		 target.Description= source.Description ;
		 target.IdParameterCategory= source.IdParameterCategory ;
		 target.StringValue= source.StringValue ;
		 target.NumberValue= source.NumberValue ;
		 target.DateValue= source.DateValue ;
		 target.TextValue= source.TextValue ;
		 		  
		}
		public override void Set(ParameterResult source,Parameter target,bool hadSetId)
		{		   
		if(hadSetId)target.IdParameter= source.IdParameter ;
		 target.Name= source.Name ;
		 target.Code= source.Code ;
		 target.Description= source.Description ;
		 target.IdParameterCategory= source.IdParameterCategory ;
		 target.StringValue= source.StringValue ;
		 target.NumberValue= source.NumberValue ;
		 target.DateValue= source.DateValue ;
		 target.TextValue= source.TextValue ;
		 
		}
		public override void Set(Parameter source,ParameterResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdParameter= source.IdParameter ;
		 target.Name= source.Name ;
		 target.Code= source.Code ;
		 target.Description= source.Description ;
		 target.IdParameterCategory= source.IdParameterCategory ;
		 target.StringValue= source.StringValue ;
		 target.NumberValue= source.NumberValue ;
		 target.DateValue= source.DateValue ;
		 target.TextValue= source.TextValue ;
		 	
		}		
		public override void Set(ParameterResult source,ParameterResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdParameter= source.IdParameter ;
		 target.Name= source.Name ;
		 target.Code= source.Code ;
		 target.Description= source.Description ;
		 target.IdParameterCategory= source.IdParameterCategory ;
		 target.StringValue= source.StringValue ;
		 target.NumberValue= source.NumberValue ;
		 target.DateValue= source.DateValue ;
		 target.TextValue= source.TextValue ;
		 target.ParameterCategory_Name= source.ParameterCategory_Name;	
			target.ParameterCategory_Description= source.ParameterCategory_Description;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(Parameter source,Parameter target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdParameter.Equals(target.IdParameter))return false;
		  if((source.Name == null)?target.Name!=null:  !( (target.Name== String.Empty && source.Name== null) || (target.Name==null && source.Name== String.Empty )) &&  !source.Name.Trim().Replace ("\r","").Equals(target.Name.Trim().Replace ("\r","")))return false;
			 if((source.Code == null)?target.Code!=null:  !( (target.Code== String.Empty && source.Code== null) || (target.Code==null && source.Code== String.Empty )) &&  !source.Code.Trim().Replace ("\r","").Equals(target.Code.Trim().Replace ("\r","")))return false;
			 if((source.Description == null)?target.Description!=null:  !( (target.Description== String.Empty && source.Description== null) || (target.Description==null && source.Description== String.Empty )) &&  !source.Description.Trim().Replace ("\r","").Equals(target.Description.Trim().Replace ("\r","")))return false;
			 if(!source.IdParameterCategory.Equals(target.IdParameterCategory))return false;
		  if((source.StringValue == null)?target.StringValue!=null:  !( (target.StringValue== String.Empty && source.StringValue== null) || (target.StringValue==null && source.StringValue== String.Empty )) &&  !source.StringValue.Trim().Replace ("\r","").Equals(target.StringValue.Trim().Replace ("\r","")))return false;
			 if((source.NumberValue == null)?(target.NumberValue.HasValue):!source.NumberValue.Equals(target.NumberValue))return false;
			 if((source.DateValue == null)?(target.DateValue.HasValue):!source.DateValue.Equals(target.DateValue))return false;
			 if((source.TextValue == null)?target.TextValue!=null:  !( (target.TextValue== String.Empty && source.TextValue== null) || (target.TextValue==null && source.TextValue== String.Empty )) &&  !source.TextValue.Trim().Replace ("\r","").Equals(target.TextValue.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(ParameterResult source,ParameterResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdParameter.Equals(target.IdParameter))return false;
		  if((source.Name == null)?target.Name!=null: !( (target.Name== String.Empty && source.Name== null) || (target.Name==null && source.Name== String.Empty )) && !source.Name.Trim().Replace ("\r","").Equals(target.Name.Trim().Replace ("\r","")))return false;
			 if((source.Code == null)?target.Code!=null: !( (target.Code== String.Empty && source.Code== null) || (target.Code==null && source.Code== String.Empty )) && !source.Code.Trim().Replace ("\r","").Equals(target.Code.Trim().Replace ("\r","")))return false;
			 if((source.Description == null)?target.Description!=null: !( (target.Description== String.Empty && source.Description== null) || (target.Description==null && source.Description== String.Empty )) && !source.Description.Trim().Replace ("\r","").Equals(target.Description.Trim().Replace ("\r","")))return false;
			 if(!source.IdParameterCategory.Equals(target.IdParameterCategory))return false;
		  if((source.StringValue == null)?target.StringValue!=null: !( (target.StringValue== String.Empty && source.StringValue== null) || (target.StringValue==null && source.StringValue== String.Empty )) && !source.StringValue.Trim().Replace ("\r","").Equals(target.StringValue.Trim().Replace ("\r","")))return false;
			 if((source.NumberValue == null)?(target.NumberValue.HasValue):!source.NumberValue.Equals(target.NumberValue))return false;
			 if((source.DateValue == null)?(target.DateValue.HasValue):!source.DateValue.Equals(target.DateValue))return false;
			 if((source.TextValue == null)?target.TextValue!=null: !( (target.TextValue== String.Empty && source.TextValue== null) || (target.TextValue==null && source.TextValue== String.Empty )) && !source.TextValue.Trim().Replace ("\r","").Equals(target.TextValue.Trim().Replace ("\r","")))return false;
			 if((source.ParameterCategory_Name == null)?target.ParameterCategory_Name!=null: !( (target.ParameterCategory_Name== String.Empty && source.ParameterCategory_Name== null) || (target.ParameterCategory_Name==null && source.ParameterCategory_Name== String.Empty )) &&   !source.ParameterCategory_Name.Trim().Replace ("\r","").Equals(target.ParameterCategory_Name.Trim().Replace ("\r","")))return false;
						 if((source.ParameterCategory_Description == null)?target.ParameterCategory_Description!=null: !( (target.ParameterCategory_Description== String.Empty && source.ParameterCategory_Description== null) || (target.ParameterCategory_Description==null && source.ParameterCategory_Description== String.Empty )) &&   !source.ParameterCategory_Description.Trim().Replace ("\r","").Equals(target.ParameterCategory_Description.Trim().Replace ("\r","")))return false;
								
		  return true;
        }
		#endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ParameterResult : IResult<int>
    {        
		public virtual int ID{get{return IdParameter;}}
		 public int IdParameter{get;set;}
		 public string Name{get;set;}
		 public string Code{get;set;}
		 public string Description{get;set;}
		 public int IdParameterCategory{get;set;}
		 public string StringValue{get;set;}
		 public decimal? NumberValue{get;set;}
		 public DateTime? DateValue{get;set;}
		 public string TextValue{get;set;}
		 
		 public string ParameterCategory_Name{get;set;}	
	public string ParameterCategory_Description{get;set;}	
					
		public virtual Parameter ToEntity()
		{
		   Parameter _Parameter = new Parameter();
		_Parameter.IdParameter = this.IdParameter;
		 _Parameter.Name = this.Name;
		 _Parameter.Code = this.Code;
		 _Parameter.Description = this.Description;
		 _Parameter.IdParameterCategory = this.IdParameterCategory;
		 _Parameter.StringValue = this.StringValue;
		 _Parameter.NumberValue = this.NumberValue;
		 _Parameter.DateValue = this.DateValue;
		 _Parameter.TextValue = this.TextValue;
		 
		  return _Parameter;
		}		
		public virtual void Set(Parameter entity)
		{		   
		 this.IdParameter= entity.IdParameter ;
		  this.Name= entity.Name ;
		  this.Code= entity.Code ;
		  this.Description= entity.Description ;
		  this.IdParameterCategory= entity.IdParameterCategory ;
		  this.StringValue= entity.StringValue ;
		  this.NumberValue= entity.NumberValue ;
		  this.DateValue= entity.DateValue ;
		  this.TextValue= entity.TextValue ;
		 		  
		}		
		public virtual bool Equals(Parameter entity)
        {
		   if(entity == null)return false;
         if(!entity.IdParameter.Equals(this.IdParameter))return false;
		  if(!entity.Name.Equals(this.Name))return false;
		  if(!entity.Code.Equals(this.Code))return false;
		  if((entity.Description == null)?this.Description!=null:!entity.Description.Equals(this.Description))return false;
			 if(!entity.IdParameterCategory.Equals(this.IdParameterCategory))return false;
		  if((entity.StringValue == null)?this.StringValue!=null:!entity.StringValue.Equals(this.StringValue))return false;
			 if((entity.NumberValue == null)?this.NumberValue!=null:!entity.NumberValue.Equals(this.NumberValue))return false;
			 if((entity.DateValue == null)?this.DateValue!=null:!entity.DateValue.Equals(this.DateValue))return false;
			 if((entity.TextValue == null)?this.TextValue!=null:!entity.TextValue.Equals(this.TextValue))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Parameter", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Name","Name")
			,new DataColumnMapping("Code","Code")
			,new DataColumnMapping("Description","Description")
			,new DataColumnMapping("ParameterCategory","ParameterCategory_Name")
			,new DataColumnMapping("StringValue","StringValue")
			,new DataColumnMapping("NumberValue","NumberValue")
			,new DataColumnMapping("DateValue","DateValue","{0:dd/MM/yyyy}")
			,new DataColumnMapping("TextValue","TextValue")
			}));
		}
	}
}
		
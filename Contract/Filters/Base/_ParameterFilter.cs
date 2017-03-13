using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ParameterFilter : Filter
    {   
		#region Private
		private string _Name;
		 private string _Code;
		 private string _Description;
		 private string _StringValue;
		 private string _TextValue;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdParameter", IsRequired = false)]public int? IdParameter{get;set;}		
[DataMember(Name = "IdParameter_To", IsRequired = false)]		
public int? IdParameter_To{get;set;}		

		  [DataMember(Name = "Name", IsRequired = false)]
		  public string Name
		  {
		   get{ if(_Name==null)_Name= string.Empty;
				return _Name; 
				}
		   set{ _Name=value;}
		  }
		 
		  [DataMember(Name = "Code", IsRequired = false)]
		  public string Code
		  {
		   get{ if(_Code==null)_Code= string.Empty;
				return _Code; 
				}
		   set{ _Code=value;}
		  }
		 
		  [DataMember(Name = "Description", IsRequired = false)]
		  public string Description
		  {
		   get{ if(_Description==null)_Description= string.Empty;
				return _Description; 
				}
		   set{ _Description=value;}
		  }
		 [DataMember(Name = "IdParameterCategory", IsRequired = false)]public int? IdParameterCategory{get;set;}		

		  [DataMember(Name = "StringValue", IsRequired = false)]
		  public string StringValue
		  {
		   get{ if(_StringValue==null)_StringValue= string.Empty;
				return _StringValue; 
				}
		   set{ _StringValue=value;}
		  }
		 [DataMember(Name = "NumberValueIsNull", IsRequired = false)]
			  public bool? NumberValueIsNull{get;set;}[DataMember(Name = "NumberValue", IsRequired = false)]public decimal? NumberValue{get;set;}		
[DataMember(Name = "NumberValue_To", IsRequired = false)]		
public decimal? NumberValue_To{get;set;}		
[DataMember(Name = "DateValueIsNull", IsRequired = false)]
			  public bool? DateValueIsNull{get;set;}[DataMember(Name = "DateValue", IsRequired = false)]public DateTime? DateValue{get;set;}		
[DataMember(Name = "DateValue_To", IsRequired = false)]		
public DateTime? DateValue_To{get;set;}		

		  [DataMember(Name = "TextValue", IsRequired = false)]
		  public string TextValue
		  {
		   get{ if(_TextValue==null)_TextValue= string.Empty;
				return _TextValue; 
				}
		   set{ _TextValue=value;}
		  }
		 
		#endregion
    }
}

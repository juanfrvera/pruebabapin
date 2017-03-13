using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ConfigurationFilter : Filter
    {   
		#region Private
		private string _Name;
		 private string _Code;
		 private string _Description;
		 private string _StringValue;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdConfiguration", IsRequired = false)]public int? IdConfiguration{get;set;}		
[DataMember(Name = "IdConfiguration_To", IsRequired = false)]		
public int? IdConfiguration_To{get;set;}		

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
		 [DataMember(Name = "IdConfigurationCategory", IsRequired = false)]public int? IdConfigurationCategory{get;set;}		
[DataMember(Name = "Active", IsRequired = false)]public bool? Active{get;set;}		
[DataMember(Name = "IdSistemaEntidadIsNull", IsRequired = false)]
			  public bool? IdSistemaEntidadIsNull{get;set;}[DataMember(Name = "IdSistemaEntidad", IsRequired = false)]public int? IdSistemaEntidad{get;set;}		
[DataMember(Name = "IdEstadoIsNull", IsRequired = false)]
			  public bool? IdEstadoIsNull{get;set;}[DataMember(Name = "IdEstado", IsRequired = false)]public int? IdEstado{get;set;}		

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
[DataMember(Name = "BooleanValue", IsRequired = false)]public bool? BooleanValue{get;set;}		

		#endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _TextFilter : Filter
    {   
		#region Private
		private string _Code;
		 private string _Description;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdText", IsRequired = false)]public int? IdText{get;set;}		

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
		 [DataMember(Name = "IdTextCategory", IsRequired = false)]public int? IdTextCategory{get;set;}		
[DataMember(Name = "IsAutomaticLoad", IsRequired = false)]public bool? IsAutomaticLoad{get;set;}		
[DataMember(Name = "StartDate", IsRequired = false)]public DateTime? StartDate{get;set;}		
[DataMember(Name = "StartDate_To", IsRequired = false)]		
public DateTime? StartDate_To{get;set;}		
[DataMember(Name = "Checked", IsRequired = false)]public bool? Checked{get;set;}		
[DataMember(Name = "CheckedDateIsNull", IsRequired = false)]
			  public bool? CheckedDateIsNull{get;set;}[DataMember(Name = "CheckedDate", IsRequired = false)]public DateTime? CheckedDate{get;set;}		
[DataMember(Name = "CheckedDate_To", IsRequired = false)]		
public DateTime? CheckedDate_To{get;set;}		
[DataMember(Name = "IdUsuarioCheckedIsNull", IsRequired = false)]
			  public bool? IdUsuarioCheckedIsNull{get;set;}[DataMember(Name = "IdUsuarioChecked", IsRequired = false)]public int? IdUsuarioChecked{get;set;}		

		#endregion
    }
}

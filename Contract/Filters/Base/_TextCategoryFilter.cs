using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _TextCategoryFilter : Filter
    {   
		#region Private
		private string _Name;
		 private string _Description;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdTextCategory", IsRequired = false)]public int? IdTextCategory{get;set;}		

		  [DataMember(Name = "Name", IsRequired = false)]
		  public string Name
		  {
		   get{ if(_Name==null)_Name= string.Empty;
				return _Name; 
				}
		   set{ _Name=value;}
		  }
		 
		  [DataMember(Name = "Description", IsRequired = false)]
		  public string Description
		  {
		   get{ if(_Description==null)_Description= string.Empty;
				return _Description; 
				}
		   set{ _Description=value;}
		  }
		 
		#endregion
    }
}

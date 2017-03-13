using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _LanguageFilter : Filter
    {   
		#region Private
		private string _Name;
		 private string _Code;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdLanguage", IsRequired = false)]public int? IdLanguage{get;set;}		

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
		 
		#endregion
    }
}

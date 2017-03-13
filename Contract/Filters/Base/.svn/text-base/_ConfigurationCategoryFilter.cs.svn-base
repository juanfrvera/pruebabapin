using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ConfigurationCategoryFilter : Filter
    {   
		#region Private
		private string _Name;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdConfigurationCategory", IsRequired = false)]public int? IdConfigurationCategory{get;set;}		

		  [DataMember(Name = "Name", IsRequired = false)]
		  public string Name
		  {
		   get{ if(_Name==null)_Name= string.Empty;
				return _Name; 
				}
		   set{ _Name=value;}
		  }
		 
		#endregion
    }
}

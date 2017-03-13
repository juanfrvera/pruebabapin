using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _MessageMediaFilter : Filter
    {   
		#region Private
		private string _Name;
		 private string _Img;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdMessageMedia", IsRequired = false)]public int? IdMessageMedia{get;set;}		

		  [DataMember(Name = "Name", IsRequired = false)]
		  public string Name
		  {
		   get{ if(_Name==null)_Name= string.Empty;
				return _Name; 
				}
		   set{ _Name=value;}
		  }
		 
		  [DataMember(Name = "Img", IsRequired = false)]
		  public string Img
		  {
		   get{ if(_Img==null)_Img= string.Empty;
				return _Img; 
				}
		   set{ _Img=value;}
		  }
		 
		#endregion
    }
}

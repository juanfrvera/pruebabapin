using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _MessageAttachFilter : Filter
    {   
		#region Private
		private string _FileName;
		 private string _FileType;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdMessageAttach", IsRequired = false)]public int? IdMessageAttach{get;set;}		
[DataMember(Name = "IdMessageAttach_To", IsRequired = false)]		
public int? IdMessageAttach_To{get;set;}		
[DataMember(Name = "IdMessage", IsRequired = false)]public int? IdMessage{get;set;}		

		  [DataMember(Name = "FileName", IsRequired = false)]
		  public string FileName
		  {
		   get{ if(_FileName==null)_FileName= string.Empty;
				return _FileName; 
				}
		   set{ _FileName=value;}
		  }
		 
		  [DataMember(Name = "FileType", IsRequired = false)]
		  public string FileType
		  {
		   get{ if(_FileType==null)_FileType= string.Empty;
				return _FileType; 
				}
		   set{ _FileType=value;}
		  }
		 [DataMember(Name = "FileContentIsNull", IsRequired = false)]
			  public bool? FileContentIsNull{get;set;}[DataMember(Name = "FileContent", IsRequired = false)]public byte[] FileContent{get;set;}		

		#endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _FileInfoFilter : Filter
    {   
		#region Private
		private string _FileType;
		 private string _FileName;
		 private string _Folder;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdFile", IsRequired = false)]public int? IdFile{get;set;}		
[DataMember(Name = "DateIsNull", IsRequired = false)]
			  public bool? DateIsNull{get;set;}[DataMember(Name = "Date", IsRequired = false)]public DateTime? Date{get;set;}		
[DataMember(Name = "Date_To", IsRequired = false)]		
public DateTime? Date_To{get;set;}		

		  [DataMember(Name = "FileType", IsRequired = false)]
		  public string FileType
		  {
		   get{ if(_FileType==null)_FileType= string.Empty;
				return _FileType; 
				}
		   set{ _FileType=value;}
		  }
		 
		  [DataMember(Name = "FileName", IsRequired = false)]
		  public string FileName
		  {
		   get{ if(_FileName==null)_FileName= string.Empty;
				return _FileName; 
				}
		   set{ _FileName=value;}
		  }
		 [DataMember(Name = "DataIsNull", IsRequired = false)]
			  public bool? DataIsNull{get;set;}[DataMember(Name = "Data", IsRequired = false)]public byte[] Data{get;set;}		
[DataMember(Name = "CheckedIsNull", IsRequired = false)]
			  public bool? CheckedIsNull{get;set;}[DataMember(Name = "Checked", IsRequired = false)]public bool? Checked{get;set;}		

		  [DataMember(Name = "Folder", IsRequired = false)]
		  public string Folder
		  {
		   get{ if(_Folder==null)_Folder= string.Empty;
				return _Folder; 
				}
		   set{ _Folder=value;}
		  }
		 [DataMember(Name = "FileVersionIsNull", IsRequired = false)]
			  public bool? FileVersionIsNull{get;set;}[DataMember(Name = "FileVersion", IsRequired = false)]public int? FileVersion{get;set;}		
[DataMember(Name = "FileVersion_To", IsRequired = false)]		
public int? FileVersion_To{get;set;}		

		#endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc=Contract;
using nd=DataAccess;

namespace DataAccess.Base
{
    public abstract class _FileInfoData : EntityData<FileInfo,FileInfoFilter,FileInfoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.FileInfo entity)
		{			
			return entity.IdFile;
		}		
		public override FileInfo GetByEntity(FileInfo entity)
        {
            return this.GetById(entity.IdFile);
        }
        public override FileInfo GetById(int id)
        {
            return (from o in this.Table where o.IdFile == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<FileInfo> Query(FileInfoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdFile == null || filter.IdFile == 0 || o.IdFile==filter.IdFile)
					  && (filter.Date == null || filter.Date == DateTime.MinValue || o.Date >=  filter.Date) && (filter.Date_To == null || filter.Date_To == DateTime.MinValue || o.Date <= filter.Date_To)
					  && (filter.DateIsNull == null || filter.DateIsNull == true || o.Date != null ) && (filter.DateIsNull == null || filter.DateIsNull == false || o.Date == null)
					  && (filter.FileType == null || filter.FileType.Trim() == string.Empty || filter.FileType.Trim() == "%"  || (filter.FileType.EndsWith("%") && filter.FileType.StartsWith("%") && (o.FileType.Contains(filter.FileType.Replace("%", "")))) || (filter.FileType.EndsWith("%") && o.FileType.StartsWith(filter.FileType.Replace("%",""))) || (filter.FileType.StartsWith("%") && o.FileType.EndsWith(filter.FileType.Replace("%",""))) || o.FileType == filter.FileType )
					  && (filter.FileName == null || filter.FileName.Trim() == string.Empty || filter.FileName.Trim() == "%"  || (filter.FileName.EndsWith("%") && filter.FileName.StartsWith("%") && (o.FileName.Contains(filter.FileName.Replace("%", "")))) || (filter.FileName.EndsWith("%") && o.FileName.StartsWith(filter.FileName.Replace("%",""))) || (filter.FileName.StartsWith("%") && o.FileName.EndsWith(filter.FileName.Replace("%",""))) || o.FileName == filter.FileName )
					  && (filter.Data == null || o.Data==filter.Data)
					  && (filter.DataIsNull == null || filter.DataIsNull == true || o.Data != null ) && (filter.DataIsNull == null || filter.DataIsNull == false || o.Data == null)
					  && (filter.Checked == null || o.Checked==filter.Checked)
					  && (filter.CheckedIsNull == null || filter.CheckedIsNull == true || o.Checked != null ) && (filter.CheckedIsNull == null || filter.CheckedIsNull == false || o.Checked == null)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<FileInfoResult> QueryResult(FileInfoFilter filter)
        {
		  return (from o in Query(filter)					
					select new FileInfoResult(){
					 IdFile=o.IdFile
					 ,Date=o.Date
					 ,FileType=o.FileType
					 ,FileName=o.FileName
					 ,Data=o.Data
					 ,Checked=o.Checked
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.FileInfo Copy(nc.FileInfo entity)
        {           
            nc.FileInfo _new = new nc.FileInfo();
		 _new.Date= entity.Date;
		 _new.FileType= entity.FileType;
		 _new.FileName= entity.FileName;
		 _new.Data= entity.Data;
		 _new.Checked= entity.Checked;
		return _new;			
        }
		#endregion
		#region Set
		public override void SetId(FileInfo entity, int id)
        {            
            entity.IdFile = id;            
        }
		public override void Set(FileInfo source,FileInfo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdFile= source.IdFile ;
		 target.Date= source.Date ;
		 target.FileType= source.FileType ;
		 target.FileName= source.FileName ;
		 target.Data= source.Data ;
		 target.Checked= source.Checked ;
		 		  
		}
		public override void Set(FileInfoResult source,FileInfo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdFile= source.IdFile ;
		 target.Date= source.Date ;
		 target.FileType= source.FileType ;
		 target.FileName= source.FileName ;
		 target.Data= source.Data ;
		 target.Checked= source.Checked ;
		 
		}
		public override void Set(FileInfo source,FileInfoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdFile= source.IdFile ;
		 target.Date= source.Date ;
		 target.FileType= source.FileType ;
		 target.FileName= source.FileName ;
		 target.Data= source.Data ;
		 target.Checked= source.Checked ;
		 	
		}		
		public override void Set(FileInfoResult source,FileInfoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdFile= source.IdFile ;
		 target.Date= source.Date ;
		 target.FileType= source.FileType ;
		 target.FileName= source.FileName ;
		 target.Data= source.Data ;
		 target.Checked= source.Checked ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(FileInfo source,FileInfo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdFile.Equals(target.IdFile))return false;
		  if((source.Date == null)?target.Date!=null:!source.Date.Equals(target.Date))return false;
			 if(!source.FileType.Equals(target.FileType))return false;
		  if(!source.FileName.Equals(target.FileName))return false;
		  if((source.Data == null)?target.Data!=null:!source.Data.Equals(target.Data))return false;
			 if((source.Checked == null)?target.Checked!=null:!source.Checked.Equals(target.Checked))return false;
			
		  return true;
        }
		public override bool Equals(FileInfoResult source,FileInfoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdFile.Equals(target.IdFile))return false;
		  if((source.Date == null)?target.Date!=null:!source.Date.Equals(target.Date))return false;
			 if(!source.FileType.Equals(target.FileType))return false;
		  if(!source.FileName.Equals(target.FileName))return false;
		  if((source.Data == null)?target.Data!=null:!source.Data.Equals(target.Data))return false;
			 if((source.Checked == null)?target.Checked!=null:!source.Checked.Equals(target.Checked))return false;
					
		  return true;
        }
		#endregion
    }
}

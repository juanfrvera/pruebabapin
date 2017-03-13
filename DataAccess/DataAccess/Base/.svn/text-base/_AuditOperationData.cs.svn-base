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
    public abstract class _AuditOperationData : EntityData<AuditOperation,AuditOperationFilter,AuditOperationResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.AuditOperation entity)
		{			
			return entity.IdAuditOperation;
		}		
		public override AuditOperation GetByEntity(AuditOperation entity)
        {
            return this.GetById(entity.IdAuditOperation);
        }
        public override AuditOperation GetById(int id)
        {
            return (from o in this.Table where o.IdAuditOperation == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<AuditOperation> Query(AuditOperationFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdAuditOperation == null || filter.IdAuditOperation == 0 || o.IdAuditOperation==filter.IdAuditOperation)
					  && (filter.IdAuditSession == null || filter.IdAuditSession == 0 || o.IdAuditSession==filter.IdAuditSession)
					  && (filter.UserName == null || filter.UserName.Trim() == string.Empty || filter.UserName.Trim() == "%"  || (filter.UserName.EndsWith("%") && filter.UserName.StartsWith("%") && (o.UserName.Contains(filter.UserName.Replace("%", "")))) || (filter.UserName.EndsWith("%") && o.UserName.StartsWith(filter.UserName.Replace("%",""))) || (filter.UserName.StartsWith("%") && o.UserName.EndsWith(filter.UserName.Replace("%",""))) || o.UserName == filter.UserName )
					  && (filter.EntityName == null || filter.EntityName.Trim() == string.Empty || filter.EntityName.Trim() == "%"  || (filter.EntityName.EndsWith("%") && filter.EntityName.StartsWith("%") && (o.EntityName.Contains(filter.EntityName.Replace("%", "")))) || (filter.EntityName.EndsWith("%") && o.EntityName.StartsWith(filter.EntityName.Replace("%",""))) || (filter.EntityName.StartsWith("%") && o.EntityName.EndsWith(filter.EntityName.Replace("%",""))) || o.EntityName == filter.EntityName )
					  && (filter.EntityBaseName == null || filter.EntityBaseName.Trim() == string.Empty || filter.EntityBaseName.Trim() == "%"  || (filter.EntityBaseName.EndsWith("%") && filter.EntityBaseName.StartsWith("%") && (o.EntityBaseName.Contains(filter.EntityBaseName.Replace("%", "")))) || (filter.EntityBaseName.EndsWith("%") && o.EntityBaseName.StartsWith(filter.EntityBaseName.Replace("%",""))) || (filter.EntityBaseName.StartsWith("%") && o.EntityBaseName.EndsWith(filter.EntityBaseName.Replace("%",""))) || o.EntityBaseName == filter.EntityBaseName )
					  && (filter.TypeName == null || filter.TypeName.Trim() == string.Empty || filter.TypeName.Trim() == "%"  || (filter.TypeName.EndsWith("%") && filter.TypeName.StartsWith("%") && (o.TypeName.Contains(filter.TypeName.Replace("%", "")))) || (filter.TypeName.EndsWith("%") && o.TypeName.StartsWith(filter.TypeName.Replace("%",""))) || (filter.TypeName.StartsWith("%") && o.TypeName.EndsWith(filter.TypeName.Replace("%",""))) || o.TypeName == filter.TypeName )
					  && (filter.EntityId == null || filter.EntityId.Trim() == string.Empty || filter.EntityId.Trim() == "%"  || (filter.EntityId.EndsWith("%") && filter.EntityId.StartsWith("%") && (o.EntityId.Contains(filter.EntityId.Replace("%", "")))) || (filter.EntityId.EndsWith("%") && o.EntityId.StartsWith(filter.EntityId.Replace("%",""))) || (filter.EntityId.StartsWith("%") && o.EntityId.EndsWith(filter.EntityId.Replace("%",""))) || o.EntityId == filter.EntityId )
					  && (filter.EntityKey == null || filter.EntityKey.Trim() == string.Empty || filter.EntityKey.Trim() == "%"  || (filter.EntityKey.EndsWith("%") && filter.EntityKey.StartsWith("%") && (o.EntityKey.Contains(filter.EntityKey.Replace("%", "")))) || (filter.EntityKey.EndsWith("%") && o.EntityKey.StartsWith(filter.EntityKey.Replace("%",""))) || (filter.EntityKey.StartsWith("%") && o.EntityKey.EndsWith(filter.EntityKey.Replace("%",""))) || o.EntityKey == filter.EntityKey )
					  && (filter.Module == null || filter.Module.Trim() == string.Empty || filter.Module.Trim() == "%"  || (filter.Module.EndsWith("%") && filter.Module.StartsWith("%") && (o.Module.Contains(filter.Module.Replace("%", "")))) || (filter.Module.EndsWith("%") && o.Module.StartsWith(filter.Module.Replace("%",""))) || (filter.Module.StartsWith("%") && o.Module.EndsWith(filter.Module.Replace("%",""))) || o.Module == filter.Module )
					  && (filter.ServiceType == null || filter.ServiceType.Trim() == string.Empty || filter.ServiceType.Trim() == "%"  || (filter.ServiceType.EndsWith("%") && filter.ServiceType.StartsWith("%") && (o.ServiceType.Contains(filter.ServiceType.Replace("%", "")))) || (filter.ServiceType.EndsWith("%") && o.ServiceType.StartsWith(filter.ServiceType.Replace("%",""))) || (filter.ServiceType.StartsWith("%") && o.ServiceType.EndsWith(filter.ServiceType.Replace("%",""))) || o.ServiceType == filter.ServiceType )
					  && (filter.Service == null || filter.Service.Trim() == string.Empty || filter.Service.Trim() == "%"  || (filter.Service.EndsWith("%") && filter.Service.StartsWith("%") && (o.Service.Contains(filter.Service.Replace("%", "")))) || (filter.Service.EndsWith("%") && o.Service.StartsWith(filter.Service.Replace("%",""))) || (filter.Service.StartsWith("%") && o.Service.EndsWith(filter.Service.Replace("%",""))) || o.Service == filter.Service )
					  && (filter.Operation == null || filter.Operation.Trim() == string.Empty || filter.Operation.Trim() == "%"  || (filter.Operation.EndsWith("%") && filter.Operation.StartsWith("%") && (o.Operation.Contains(filter.Operation.Replace("%", "")))) || (filter.Operation.EndsWith("%") && o.Operation.StartsWith(filter.Operation.Replace("%",""))) || (filter.Operation.StartsWith("%") && o.Operation.EndsWith(filter.Operation.Replace("%",""))) || o.Operation == filter.Operation )
					  && (filter.StatusName == null || filter.StatusName.Trim() == string.Empty || filter.StatusName.Trim() == "%"  || (filter.StatusName.EndsWith("%") && filter.StatusName.StartsWith("%") && (o.StatusName.Contains(filter.StatusName.Replace("%", "")))) || (filter.StatusName.EndsWith("%") && o.StatusName.StartsWith(filter.StatusName.Replace("%",""))) || (filter.StatusName.StartsWith("%") && o.StatusName.EndsWith(filter.StatusName.Replace("%",""))) || o.StatusName == filter.StatusName )
					  && (filter.Info == null || filter.Info.Trim() == string.Empty || filter.Info.Trim() == "%"  || (filter.Info.EndsWith("%") && filter.Info.StartsWith("%") && (o.Info.Contains(filter.Info.Replace("%", "")))) || (filter.Info.EndsWith("%") && o.Info.StartsWith(filter.Info.Replace("%",""))) || (filter.Info.StartsWith("%") && o.Info.EndsWith(filter.Info.Replace("%",""))) || o.Info == filter.Info )
					  && (filter.Comment == null || filter.Comment.Trim() == string.Empty || filter.Comment.Trim() == "%"  || (filter.Comment.EndsWith("%") && filter.Comment.StartsWith("%") && (o.Comment.Contains(filter.Comment.Replace("%", "")))) || (filter.Comment.EndsWith("%") && o.Comment.StartsWith(filter.Comment.Replace("%",""))) || (filter.Comment.StartsWith("%") && o.Comment.EndsWith(filter.Comment.Replace("%",""))) || o.Comment == filter.Comment )
					  && (filter.DataOld == null || filter.DataOld.Trim() == string.Empty || filter.DataOld.Trim() == "%"  || (filter.DataOld.EndsWith("%") && filter.DataOld.StartsWith("%") && (o.DataOld.Contains(filter.DataOld.Replace("%", "")))) || (filter.DataOld.EndsWith("%") && o.DataOld.StartsWith(filter.DataOld.Replace("%",""))) || (filter.DataOld.StartsWith("%") && o.DataOld.EndsWith(filter.DataOld.Replace("%",""))) || o.DataOld == filter.DataOld )
					  && (filter.DataPreOperation == null || filter.DataPreOperation.Trim() == string.Empty || filter.DataPreOperation.Trim() == "%"  || (filter.DataPreOperation.EndsWith("%") && filter.DataPreOperation.StartsWith("%") && (o.DataPreOperation.Contains(filter.DataPreOperation.Replace("%", "")))) || (filter.DataPreOperation.EndsWith("%") && o.DataPreOperation.StartsWith(filter.DataPreOperation.Replace("%",""))) || (filter.DataPreOperation.StartsWith("%") && o.DataPreOperation.EndsWith(filter.DataPreOperation.Replace("%",""))) || o.DataPreOperation == filter.DataPreOperation )
					  && (filter.DataPostOperation == null || filter.DataPostOperation.Trim() == string.Empty || filter.DataPostOperation.Trim() == "%"  || (filter.DataPostOperation.EndsWith("%") && filter.DataPostOperation.StartsWith("%") && (o.DataPostOperation.Contains(filter.DataPostOperation.Replace("%", "")))) || (filter.DataPostOperation.EndsWith("%") && o.DataPostOperation.StartsWith(filter.DataPostOperation.Replace("%",""))) || (filter.DataPostOperation.StartsWith("%") && o.DataPostOperation.EndsWith(filter.DataPostOperation.Replace("%",""))) || o.DataPostOperation == filter.DataPostOperation )
					  && (filter.StartDate == null || filter.StartDate == DateTime.MinValue || o.StartDate >=  filter.StartDate) && (filter.StartDate_To == null || filter.StartDate_To == DateTime.MinValue || o.StartDate <= filter.StartDate_To)
					  && (filter.EndDate == null || filter.EndDate == DateTime.MinValue || o.EndDate >=  filter.EndDate) && (filter.EndDate_To == null || filter.EndDate_To == DateTime.MinValue || o.EndDate <= filter.EndDate_To)
					  && (filter.EndDateIsNull == null || filter.EndDateIsNull == true || o.EndDate != null ) && (filter.EndDateIsNull == null || filter.EndDateIsNull == false || o.EndDate == null)
					  && (filter.EnableViewLog == null || o.EnableViewLog==filter.EnableViewLog)
					  && (filter.ApplicationName == null || filter.ApplicationName.Trim() == string.Empty || filter.ApplicationName.Trim() == "%"  || (filter.ApplicationName.EndsWith("%") && filter.ApplicationName.StartsWith("%") && (o.ApplicationName.Contains(filter.ApplicationName.Replace("%", "")))) || (filter.ApplicationName.EndsWith("%") && o.ApplicationName.StartsWith(filter.ApplicationName.Replace("%",""))) || (filter.ApplicationName.StartsWith("%") && o.ApplicationName.EndsWith(filter.ApplicationName.Replace("%",""))) || o.ApplicationName == filter.ApplicationName )
					  && (filter.FormPath == null || filter.FormPath.Trim() == string.Empty || filter.FormPath.Trim() == "%"  || (filter.FormPath.EndsWith("%") && filter.FormPath.StartsWith("%") && (o.FormPath.Contains(filter.FormPath.Replace("%", "")))) || (filter.FormPath.EndsWith("%") && o.FormPath.StartsWith(filter.FormPath.Replace("%",""))) || (filter.FormPath.StartsWith("%") && o.FormPath.EndsWith(filter.FormPath.Replace("%",""))) || o.FormPath == filter.FormPath )
					  && (filter.FormName == null || filter.FormName.Trim() == string.Empty || filter.FormName.Trim() == "%"  || (filter.FormName.EndsWith("%") && filter.FormName.StartsWith("%") && (o.FormName.Contains(filter.FormName.Replace("%", "")))) || (filter.FormName.EndsWith("%") && o.FormName.StartsWith(filter.FormName.Replace("%",""))) || (filter.FormName.StartsWith("%") && o.FormName.EndsWith(filter.FormName.Replace("%",""))) || o.FormName == filter.FormName )
					  && (filter.UserControlName == null || filter.UserControlName.Trim() == string.Empty || filter.UserControlName.Trim() == "%"  || (filter.UserControlName.EndsWith("%") && filter.UserControlName.StartsWith("%") && (o.UserControlName.Contains(filter.UserControlName.Replace("%", "")))) || (filter.UserControlName.EndsWith("%") && o.UserControlName.StartsWith(filter.UserControlName.Replace("%",""))) || (filter.UserControlName.StartsWith("%") && o.UserControlName.EndsWith(filter.UserControlName.Replace("%",""))) || o.UserControlName == filter.UserControlName )
					  && (filter.UserControlPath == null || filter.UserControlPath.Trim() == string.Empty || filter.UserControlPath.Trim() == "%"  || (filter.UserControlPath.EndsWith("%") && filter.UserControlPath.StartsWith("%") && (o.UserControlPath.Contains(filter.UserControlPath.Replace("%", "")))) || (filter.UserControlPath.EndsWith("%") && o.UserControlPath.StartsWith(filter.UserControlPath.Replace("%",""))) || (filter.UserControlPath.StartsWith("%") && o.UserControlPath.EndsWith(filter.UserControlPath.Replace("%",""))) || o.UserControlPath == filter.UserControlPath )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<AuditOperationResult> QueryResult(AuditOperationFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.AuditSessions on o.IdAuditSession equals t1.IdAuditSession   
				   select new AuditOperationResult(){
					 IdAuditOperation=o.IdAuditOperation
					 ,IdAuditSession=o.IdAuditSession
					 ,UserName=o.UserName
					 ,EntityName=o.EntityName
					 ,EntityBaseName=o.EntityBaseName
					 ,TypeName=o.TypeName
					 ,EntityId=o.EntityId
					 ,EntityKey=o.EntityKey
					 ,Module=o.Module
					 ,ServiceType=o.ServiceType
					 ,Service=o.Service
					 ,Operation=o.Operation
					 ,StatusName=o.StatusName
					 ,Info=o.Info
					 ,Comment=o.Comment
					 ,DataOld=o.DataOld
					 ,DataPreOperation=o.DataPreOperation
					 ,DataPostOperation=o.DataPostOperation
					 ,StartDate=o.StartDate
					 ,EndDate=o.EndDate
					 ,EnableViewLog=o.EnableViewLog
					 ,ApplicationName=o.ApplicationName
					 ,FormPath=o.FormPath
					 ,FormName=o.FormName
					 ,UserControlName=o.UserControlName
					 ,UserControlPath=o.UserControlPath
					,AuditSession_UserName= t1.UserName	
						,AuditSession_SessionId= t1.SessionId	
						,AuditSession_Login= t1.Login	
						,AuditSession_Rols= t1.Rols	
						,AuditSession_Area= t1.Area	
						,AuditSession_IP= t1.IP	
						,AuditSession_BrowserVersion= t1.BrowserVersion	
						,AuditSession_OperatingSystem= t1.OperatingSystem	
						,AuditSession_StartDate= t1.StartDate	
						,AuditSession_EndDate= t1.EndDate	
						,AuditSession_Mandate= t1.Mandate	
						,AuditSession_Message= t1.Message	
						,AuditSession_Comments= t1.Comments	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.AuditOperation Copy(nc.AuditOperation entity)
        {           
            nc.AuditOperation _new = new nc.AuditOperation();
		 _new.IdAuditSession= entity.IdAuditSession;
		 _new.UserName= entity.UserName;
		 _new.EntityName= entity.EntityName;
		 _new.EntityBaseName= entity.EntityBaseName;
		 _new.TypeName= entity.TypeName;
		 _new.EntityId= entity.EntityId;
		 _new.EntityKey= entity.EntityKey;
		 _new.Module= entity.Module;
		 _new.ServiceType= entity.ServiceType;
		 _new.Service= entity.Service;
		 _new.Operation= entity.Operation;
		 _new.StatusName= entity.StatusName;
		 _new.Info= entity.Info;
		 _new.Comment= entity.Comment;
		 _new.DataOld= entity.DataOld;
		 _new.DataPreOperation= entity.DataPreOperation;
		 _new.DataPostOperation= entity.DataPostOperation;
		 _new.StartDate= entity.StartDate;
		 _new.EndDate= entity.EndDate;
		 _new.EnableViewLog= entity.EnableViewLog;
		 _new.ApplicationName= entity.ApplicationName;
		 _new.FormPath= entity.FormPath;
		 _new.FormName= entity.FormName;
		 _new.UserControlName= entity.UserControlName;
		 _new.UserControlPath= entity.UserControlPath;
		return _new;			
        }
		public override int CopyAndSave(AuditOperation entity,string renameFormat)
        {
            AuditOperation  newEntity = Copy(entity);
            newEntity.UserName = string.Format(renameFormat,newEntity.UserName);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(AuditOperation entity, int id)
        {            
            entity.IdAuditOperation = id;            
        }
		public override void Set(AuditOperation source,AuditOperation target,bool hadSetId)
		{		   
		if(hadSetId)target.IdAuditOperation= source.IdAuditOperation ;
		 target.IdAuditSession= source.IdAuditSession ;
		 target.UserName= source.UserName ;
		 target.EntityName= source.EntityName ;
		 target.EntityBaseName= source.EntityBaseName ;
		 target.TypeName= source.TypeName ;
		 target.EntityId= source.EntityId ;
		 target.EntityKey= source.EntityKey ;
		 target.Module= source.Module ;
		 target.ServiceType= source.ServiceType ;
		 target.Service= source.Service ;
		 target.Operation= source.Operation ;
		 target.StatusName= source.StatusName ;
		 target.Info= source.Info ;
		 target.Comment= source.Comment ;
		 target.DataOld= source.DataOld ;
		 target.DataPreOperation= source.DataPreOperation ;
		 target.DataPostOperation= source.DataPostOperation ;
		 target.StartDate= source.StartDate ;
		 target.EndDate= source.EndDate ;
		 target.EnableViewLog= source.EnableViewLog ;
		 target.ApplicationName= source.ApplicationName ;
		 target.FormPath= source.FormPath ;
		 target.FormName= source.FormName ;
		 target.UserControlName= source.UserControlName ;
		 target.UserControlPath= source.UserControlPath ;
		 		  
		}
		public override void Set(AuditOperationResult source,AuditOperation target,bool hadSetId)
		{		   
		if(hadSetId)target.IdAuditOperation= source.IdAuditOperation ;
		 target.IdAuditSession= source.IdAuditSession ;
		 target.UserName= source.UserName ;
		 target.EntityName= source.EntityName ;
		 target.EntityBaseName= source.EntityBaseName ;
		 target.TypeName= source.TypeName ;
		 target.EntityId= source.EntityId ;
		 target.EntityKey= source.EntityKey ;
		 target.Module= source.Module ;
		 target.ServiceType= source.ServiceType ;
		 target.Service= source.Service ;
		 target.Operation= source.Operation ;
		 target.StatusName= source.StatusName ;
		 target.Info= source.Info ;
		 target.Comment= source.Comment ;
		 target.DataOld= source.DataOld ;
		 target.DataPreOperation= source.DataPreOperation ;
		 target.DataPostOperation= source.DataPostOperation ;
		 target.StartDate= source.StartDate ;
		 target.EndDate= source.EndDate ;
		 target.EnableViewLog= source.EnableViewLog ;
		 target.ApplicationName= source.ApplicationName ;
		 target.FormPath= source.FormPath ;
		 target.FormName= source.FormName ;
		 target.UserControlName= source.UserControlName ;
		 target.UserControlPath= source.UserControlPath ;
		 
		}
		public override void Set(AuditOperation source,AuditOperationResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdAuditOperation= source.IdAuditOperation ;
		 target.IdAuditSession= source.IdAuditSession ;
		 target.UserName= source.UserName ;
		 target.EntityName= source.EntityName ;
		 target.EntityBaseName= source.EntityBaseName ;
		 target.TypeName= source.TypeName ;
		 target.EntityId= source.EntityId ;
		 target.EntityKey= source.EntityKey ;
		 target.Module= source.Module ;
		 target.ServiceType= source.ServiceType ;
		 target.Service= source.Service ;
		 target.Operation= source.Operation ;
		 target.StatusName= source.StatusName ;
		 target.Info= source.Info ;
		 target.Comment= source.Comment ;
		 target.DataOld= source.DataOld ;
		 target.DataPreOperation= source.DataPreOperation ;
		 target.DataPostOperation= source.DataPostOperation ;
		 target.StartDate= source.StartDate ;
		 target.EndDate= source.EndDate ;
		 target.EnableViewLog= source.EnableViewLog ;
		 target.ApplicationName= source.ApplicationName ;
		 target.FormPath= source.FormPath ;
		 target.FormName= source.FormName ;
		 target.UserControlName= source.UserControlName ;
		 target.UserControlPath= source.UserControlPath ;
		 	
		}		
		public override void Set(AuditOperationResult source,AuditOperationResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdAuditOperation= source.IdAuditOperation ;
		 target.IdAuditSession= source.IdAuditSession ;
		 target.UserName= source.UserName ;
		 target.EntityName= source.EntityName ;
		 target.EntityBaseName= source.EntityBaseName ;
		 target.TypeName= source.TypeName ;
		 target.EntityId= source.EntityId ;
		 target.EntityKey= source.EntityKey ;
		 target.Module= source.Module ;
		 target.ServiceType= source.ServiceType ;
		 target.Service= source.Service ;
		 target.Operation= source.Operation ;
		 target.StatusName= source.StatusName ;
		 target.Info= source.Info ;
		 target.Comment= source.Comment ;
		 target.DataOld= source.DataOld ;
		 target.DataPreOperation= source.DataPreOperation ;
		 target.DataPostOperation= source.DataPostOperation ;
		 target.StartDate= source.StartDate ;
		 target.EndDate= source.EndDate ;
		 target.EnableViewLog= source.EnableViewLog ;
		 target.ApplicationName= source.ApplicationName ;
		 target.FormPath= source.FormPath ;
		 target.FormName= source.FormName ;
		 target.UserControlName= source.UserControlName ;
		 target.UserControlPath= source.UserControlPath ;
		 target.AuditSession_UserName= source.AuditSession_UserName;	
			target.AuditSession_SessionId= source.AuditSession_SessionId;	
			target.AuditSession_Login= source.AuditSession_Login;	
			target.AuditSession_Rols= source.AuditSession_Rols;	
			target.AuditSession_Area= source.AuditSession_Area;	
			target.AuditSession_IP= source.AuditSession_IP;	
			target.AuditSession_BrowserVersion= source.AuditSession_BrowserVersion;	
			target.AuditSession_OperatingSystem= source.AuditSession_OperatingSystem;	
			target.AuditSession_StartDate= source.AuditSession_StartDate;	
			target.AuditSession_EndDate= source.AuditSession_EndDate;	
			target.AuditSession_Mandate= source.AuditSession_Mandate;	
			target.AuditSession_Message= source.AuditSession_Message;	
			target.AuditSession_Comments= source.AuditSession_Comments;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(AuditOperation source,AuditOperation target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdAuditOperation.Equals(target.IdAuditOperation))return false;
		  if(!source.IdAuditSession.Equals(target.IdAuditSession))return false;
		  if((source.UserName == null)?target.UserName!=null:  !( (target.UserName== String.Empty && source.UserName== null) || (target.UserName==null && source.UserName== String.Empty )) &&  !source.UserName.Trim().Replace ("\r","").Equals(target.UserName.Trim().Replace ("\r","")))return false;
			 if((source.EntityName == null)?target.EntityName!=null:  !( (target.EntityName== String.Empty && source.EntityName== null) || (target.EntityName==null && source.EntityName== String.Empty )) &&  !source.EntityName.Trim().Replace ("\r","").Equals(target.EntityName.Trim().Replace ("\r","")))return false;
			 if((source.EntityBaseName == null)?target.EntityBaseName!=null:  !( (target.EntityBaseName== String.Empty && source.EntityBaseName== null) || (target.EntityBaseName==null && source.EntityBaseName== String.Empty )) &&  !source.EntityBaseName.Trim().Replace ("\r","").Equals(target.EntityBaseName.Trim().Replace ("\r","")))return false;
			 if((source.TypeName == null)?target.TypeName!=null:  !( (target.TypeName== String.Empty && source.TypeName== null) || (target.TypeName==null && source.TypeName== String.Empty )) &&  !source.TypeName.Trim().Replace ("\r","").Equals(target.TypeName.Trim().Replace ("\r","")))return false;
			 if((source.EntityId == null)?target.EntityId!=null:  !( (target.EntityId== String.Empty && source.EntityId== null) || (target.EntityId==null && source.EntityId== String.Empty )) &&  !source.EntityId.Trim().Replace ("\r","").Equals(target.EntityId.Trim().Replace ("\r","")))return false;
			 if((source.EntityKey == null)?target.EntityKey!=null:  !( (target.EntityKey== String.Empty && source.EntityKey== null) || (target.EntityKey==null && source.EntityKey== String.Empty )) &&  !source.EntityKey.Trim().Replace ("\r","").Equals(target.EntityKey.Trim().Replace ("\r","")))return false;
			 if((source.Module == null)?target.Module!=null:  !( (target.Module== String.Empty && source.Module== null) || (target.Module==null && source.Module== String.Empty )) &&  !source.Module.Trim().Replace ("\r","").Equals(target.Module.Trim().Replace ("\r","")))return false;
			 if((source.ServiceType == null)?target.ServiceType!=null:  !( (target.ServiceType== String.Empty && source.ServiceType== null) || (target.ServiceType==null && source.ServiceType== String.Empty )) &&  !source.ServiceType.Trim().Replace ("\r","").Equals(target.ServiceType.Trim().Replace ("\r","")))return false;
			 if((source.Service == null)?target.Service!=null:  !( (target.Service== String.Empty && source.Service== null) || (target.Service==null && source.Service== String.Empty )) &&  !source.Service.Trim().Replace ("\r","").Equals(target.Service.Trim().Replace ("\r","")))return false;
			 if((source.Operation == null)?target.Operation!=null:  !( (target.Operation== String.Empty && source.Operation== null) || (target.Operation==null && source.Operation== String.Empty )) &&  !source.Operation.Trim().Replace ("\r","").Equals(target.Operation.Trim().Replace ("\r","")))return false;
			 if((source.StatusName == null)?target.StatusName!=null:  !( (target.StatusName== String.Empty && source.StatusName== null) || (target.StatusName==null && source.StatusName== String.Empty )) &&  !source.StatusName.Trim().Replace ("\r","").Equals(target.StatusName.Trim().Replace ("\r","")))return false;
			 if((source.Info == null)?target.Info!=null:  !( (target.Info== String.Empty && source.Info== null) || (target.Info==null && source.Info== String.Empty )) &&  !source.Info.Trim().Replace ("\r","").Equals(target.Info.Trim().Replace ("\r","")))return false;
			 if((source.Comment == null)?target.Comment!=null:  !( (target.Comment== String.Empty && source.Comment== null) || (target.Comment==null && source.Comment== String.Empty )) &&  !source.Comment.Trim().Replace ("\r","").Equals(target.Comment.Trim().Replace ("\r","")))return false;
			 if((source.DataOld == null)?target.DataOld!=null:  !( (target.DataOld== String.Empty && source.DataOld== null) || (target.DataOld==null && source.DataOld== String.Empty )) &&  !source.DataOld.Trim().Replace ("\r","").Equals(target.DataOld.Trim().Replace ("\r","")))return false;
			 if((source.DataPreOperation == null)?target.DataPreOperation!=null:  !( (target.DataPreOperation== String.Empty && source.DataPreOperation== null) || (target.DataPreOperation==null && source.DataPreOperation== String.Empty )) &&  !source.DataPreOperation.Trim().Replace ("\r","").Equals(target.DataPreOperation.Trim().Replace ("\r","")))return false;
			 if((source.DataPostOperation == null)?target.DataPostOperation!=null:  !( (target.DataPostOperation== String.Empty && source.DataPostOperation== null) || (target.DataPostOperation==null && source.DataPostOperation== String.Empty )) &&  !source.DataPostOperation.Trim().Replace ("\r","").Equals(target.DataPostOperation.Trim().Replace ("\r","")))return false;
			 if(!source.StartDate.Equals(target.StartDate))return false;
		  if((source.EndDate == null)?(target.EndDate.HasValue):!source.EndDate.Equals(target.EndDate))return false;
			 if(!source.EnableViewLog.Equals(target.EnableViewLog))return false;
		  if((source.ApplicationName == null)?target.ApplicationName!=null:  !( (target.ApplicationName== String.Empty && source.ApplicationName== null) || (target.ApplicationName==null && source.ApplicationName== String.Empty )) &&  !source.ApplicationName.Trim().Replace ("\r","").Equals(target.ApplicationName.Trim().Replace ("\r","")))return false;
			 if((source.FormPath == null)?target.FormPath!=null:  !( (target.FormPath== String.Empty && source.FormPath== null) || (target.FormPath==null && source.FormPath== String.Empty )) &&  !source.FormPath.Trim().Replace ("\r","").Equals(target.FormPath.Trim().Replace ("\r","")))return false;
			 if((source.FormName == null)?target.FormName!=null:  !( (target.FormName== String.Empty && source.FormName== null) || (target.FormName==null && source.FormName== String.Empty )) &&  !source.FormName.Trim().Replace ("\r","").Equals(target.FormName.Trim().Replace ("\r","")))return false;
			 if((source.UserControlName == null)?target.UserControlName!=null:  !( (target.UserControlName== String.Empty && source.UserControlName== null) || (target.UserControlName==null && source.UserControlName== String.Empty )) &&  !source.UserControlName.Trim().Replace ("\r","").Equals(target.UserControlName.Trim().Replace ("\r","")))return false;
			 if((source.UserControlPath == null)?target.UserControlPath!=null:  !( (target.UserControlPath== String.Empty && source.UserControlPath== null) || (target.UserControlPath==null && source.UserControlPath== String.Empty )) &&  !source.UserControlPath.Trim().Replace ("\r","").Equals(target.UserControlPath.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(AuditOperationResult source,AuditOperationResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdAuditOperation.Equals(target.IdAuditOperation))return false;
		  if(!source.IdAuditSession.Equals(target.IdAuditSession))return false;
		  if((source.UserName == null)?target.UserName!=null: !( (target.UserName== String.Empty && source.UserName== null) || (target.UserName==null && source.UserName== String.Empty )) && !source.UserName.Trim().Replace ("\r","").Equals(target.UserName.Trim().Replace ("\r","")))return false;
			 if((source.EntityName == null)?target.EntityName!=null: !( (target.EntityName== String.Empty && source.EntityName== null) || (target.EntityName==null && source.EntityName== String.Empty )) && !source.EntityName.Trim().Replace ("\r","").Equals(target.EntityName.Trim().Replace ("\r","")))return false;
			 if((source.EntityBaseName == null)?target.EntityBaseName!=null: !( (target.EntityBaseName== String.Empty && source.EntityBaseName== null) || (target.EntityBaseName==null && source.EntityBaseName== String.Empty )) && !source.EntityBaseName.Trim().Replace ("\r","").Equals(target.EntityBaseName.Trim().Replace ("\r","")))return false;
			 if((source.TypeName == null)?target.TypeName!=null: !( (target.TypeName== String.Empty && source.TypeName== null) || (target.TypeName==null && source.TypeName== String.Empty )) && !source.TypeName.Trim().Replace ("\r","").Equals(target.TypeName.Trim().Replace ("\r","")))return false;
			 if((source.EntityId == null)?target.EntityId!=null: !( (target.EntityId== String.Empty && source.EntityId== null) || (target.EntityId==null && source.EntityId== String.Empty )) && !source.EntityId.Trim().Replace ("\r","").Equals(target.EntityId.Trim().Replace ("\r","")))return false;
			 if((source.EntityKey == null)?target.EntityKey!=null: !( (target.EntityKey== String.Empty && source.EntityKey== null) || (target.EntityKey==null && source.EntityKey== String.Empty )) && !source.EntityKey.Trim().Replace ("\r","").Equals(target.EntityKey.Trim().Replace ("\r","")))return false;
			 if((source.Module == null)?target.Module!=null: !( (target.Module== String.Empty && source.Module== null) || (target.Module==null && source.Module== String.Empty )) && !source.Module.Trim().Replace ("\r","").Equals(target.Module.Trim().Replace ("\r","")))return false;
			 if((source.ServiceType == null)?target.ServiceType!=null: !( (target.ServiceType== String.Empty && source.ServiceType== null) || (target.ServiceType==null && source.ServiceType== String.Empty )) && !source.ServiceType.Trim().Replace ("\r","").Equals(target.ServiceType.Trim().Replace ("\r","")))return false;
			 if((source.Service == null)?target.Service!=null: !( (target.Service== String.Empty && source.Service== null) || (target.Service==null && source.Service== String.Empty )) && !source.Service.Trim().Replace ("\r","").Equals(target.Service.Trim().Replace ("\r","")))return false;
			 if((source.Operation == null)?target.Operation!=null: !( (target.Operation== String.Empty && source.Operation== null) || (target.Operation==null && source.Operation== String.Empty )) && !source.Operation.Trim().Replace ("\r","").Equals(target.Operation.Trim().Replace ("\r","")))return false;
			 if((source.StatusName == null)?target.StatusName!=null: !( (target.StatusName== String.Empty && source.StatusName== null) || (target.StatusName==null && source.StatusName== String.Empty )) && !source.StatusName.Trim().Replace ("\r","").Equals(target.StatusName.Trim().Replace ("\r","")))return false;
			 if((source.Info == null)?target.Info!=null: !( (target.Info== String.Empty && source.Info== null) || (target.Info==null && source.Info== String.Empty )) && !source.Info.Trim().Replace ("\r","").Equals(target.Info.Trim().Replace ("\r","")))return false;
			 if((source.Comment == null)?target.Comment!=null: !( (target.Comment== String.Empty && source.Comment== null) || (target.Comment==null && source.Comment== String.Empty )) && !source.Comment.Trim().Replace ("\r","").Equals(target.Comment.Trim().Replace ("\r","")))return false;
			 if((source.DataOld == null)?target.DataOld!=null: !( (target.DataOld== String.Empty && source.DataOld== null) || (target.DataOld==null && source.DataOld== String.Empty )) && !source.DataOld.Trim().Replace ("\r","").Equals(target.DataOld.Trim().Replace ("\r","")))return false;
			 if((source.DataPreOperation == null)?target.DataPreOperation!=null: !( (target.DataPreOperation== String.Empty && source.DataPreOperation== null) || (target.DataPreOperation==null && source.DataPreOperation== String.Empty )) && !source.DataPreOperation.Trim().Replace ("\r","").Equals(target.DataPreOperation.Trim().Replace ("\r","")))return false;
			 if((source.DataPostOperation == null)?target.DataPostOperation!=null: !( (target.DataPostOperation== String.Empty && source.DataPostOperation== null) || (target.DataPostOperation==null && source.DataPostOperation== String.Empty )) && !source.DataPostOperation.Trim().Replace ("\r","").Equals(target.DataPostOperation.Trim().Replace ("\r","")))return false;
			 if(!source.StartDate.Equals(target.StartDate))return false;
		  if((source.EndDate == null)?(target.EndDate.HasValue):!source.EndDate.Equals(target.EndDate))return false;
			 if(!source.EnableViewLog.Equals(target.EnableViewLog))return false;
		  if((source.ApplicationName == null)?target.ApplicationName!=null: !( (target.ApplicationName== String.Empty && source.ApplicationName== null) || (target.ApplicationName==null && source.ApplicationName== String.Empty )) && !source.ApplicationName.Trim().Replace ("\r","").Equals(target.ApplicationName.Trim().Replace ("\r","")))return false;
			 if((source.FormPath == null)?target.FormPath!=null: !( (target.FormPath== String.Empty && source.FormPath== null) || (target.FormPath==null && source.FormPath== String.Empty )) && !source.FormPath.Trim().Replace ("\r","").Equals(target.FormPath.Trim().Replace ("\r","")))return false;
			 if((source.FormName == null)?target.FormName!=null: !( (target.FormName== String.Empty && source.FormName== null) || (target.FormName==null && source.FormName== String.Empty )) && !source.FormName.Trim().Replace ("\r","").Equals(target.FormName.Trim().Replace ("\r","")))return false;
			 if((source.UserControlName == null)?target.UserControlName!=null: !( (target.UserControlName== String.Empty && source.UserControlName== null) || (target.UserControlName==null && source.UserControlName== String.Empty )) && !source.UserControlName.Trim().Replace ("\r","").Equals(target.UserControlName.Trim().Replace ("\r","")))return false;
			 if((source.UserControlPath == null)?target.UserControlPath!=null: !( (target.UserControlPath== String.Empty && source.UserControlPath== null) || (target.UserControlPath==null && source.UserControlPath== String.Empty )) && !source.UserControlPath.Trim().Replace ("\r","").Equals(target.UserControlPath.Trim().Replace ("\r","")))return false;
			 if((source.AuditSession_UserName == null)?target.AuditSession_UserName!=null: !( (target.AuditSession_UserName== String.Empty && source.AuditSession_UserName== null) || (target.AuditSession_UserName==null && source.AuditSession_UserName== String.Empty )) &&   !source.AuditSession_UserName.Trim().Replace ("\r","").Equals(target.AuditSession_UserName.Trim().Replace ("\r","")))return false;
						 if((source.AuditSession_SessionId == null)?target.AuditSession_SessionId!=null: !( (target.AuditSession_SessionId== String.Empty && source.AuditSession_SessionId== null) || (target.AuditSession_SessionId==null && source.AuditSession_SessionId== String.Empty )) &&   !source.AuditSession_SessionId.Trim().Replace ("\r","").Equals(target.AuditSession_SessionId.Trim().Replace ("\r","")))return false;
						 if((source.AuditSession_Login == null)?target.AuditSession_Login!=null: !( (target.AuditSession_Login== String.Empty && source.AuditSession_Login== null) || (target.AuditSession_Login==null && source.AuditSession_Login== String.Empty )) &&   !source.AuditSession_Login.Trim().Replace ("\r","").Equals(target.AuditSession_Login.Trim().Replace ("\r","")))return false;
						 if((source.AuditSession_Rols == null)?target.AuditSession_Rols!=null: !( (target.AuditSession_Rols== String.Empty && source.AuditSession_Rols== null) || (target.AuditSession_Rols==null && source.AuditSession_Rols== String.Empty )) &&   !source.AuditSession_Rols.Trim().Replace ("\r","").Equals(target.AuditSession_Rols.Trim().Replace ("\r","")))return false;
						 if((source.AuditSession_Area == null)?target.AuditSession_Area!=null: !( (target.AuditSession_Area== String.Empty && source.AuditSession_Area== null) || (target.AuditSession_Area==null && source.AuditSession_Area== String.Empty )) &&   !source.AuditSession_Area.Trim().Replace ("\r","").Equals(target.AuditSession_Area.Trim().Replace ("\r","")))return false;
						 if((source.AuditSession_IP == null)?target.AuditSession_IP!=null: !( (target.AuditSession_IP== String.Empty && source.AuditSession_IP== null) || (target.AuditSession_IP==null && source.AuditSession_IP== String.Empty )) &&   !source.AuditSession_IP.Trim().Replace ("\r","").Equals(target.AuditSession_IP.Trim().Replace ("\r","")))return false;
						 if((source.AuditSession_BrowserVersion == null)?target.AuditSession_BrowserVersion!=null: !( (target.AuditSession_BrowserVersion== String.Empty && source.AuditSession_BrowserVersion== null) || (target.AuditSession_BrowserVersion==null && source.AuditSession_BrowserVersion== String.Empty )) &&   !source.AuditSession_BrowserVersion.Trim().Replace ("\r","").Equals(target.AuditSession_BrowserVersion.Trim().Replace ("\r","")))return false;
						 if((source.AuditSession_OperatingSystem == null)?target.AuditSession_OperatingSystem!=null: !( (target.AuditSession_OperatingSystem== String.Empty && source.AuditSession_OperatingSystem== null) || (target.AuditSession_OperatingSystem==null && source.AuditSession_OperatingSystem== String.Empty )) &&   !source.AuditSession_OperatingSystem.Trim().Replace ("\r","").Equals(target.AuditSession_OperatingSystem.Trim().Replace ("\r","")))return false;
						 if((source.AuditSession_StartDate == null)?(target.AuditSession_StartDate.HasValue ):!source.AuditSession_StartDate.Equals(target.AuditSession_StartDate))return false;
						 if((source.AuditSession_EndDate == null)?(target.AuditSession_EndDate.HasValue ):!source.AuditSession_EndDate.Equals(target.AuditSession_EndDate))return false;
						 if((source.AuditSession_Mandate == null)?target.AuditSession_Mandate!=null: !( (target.AuditSession_Mandate== String.Empty && source.AuditSession_Mandate== null) || (target.AuditSession_Mandate==null && source.AuditSession_Mandate== String.Empty )) &&   !source.AuditSession_Mandate.Trim().Replace ("\r","").Equals(target.AuditSession_Mandate.Trim().Replace ("\r","")))return false;
						 if((source.AuditSession_Message == null)?target.AuditSession_Message!=null: !( (target.AuditSession_Message== String.Empty && source.AuditSession_Message== null) || (target.AuditSession_Message==null && source.AuditSession_Message== String.Empty )) &&   !source.AuditSession_Message.Trim().Replace ("\r","").Equals(target.AuditSession_Message.Trim().Replace ("\r","")))return false;
						 if((source.AuditSession_Comments == null)?target.AuditSession_Comments!=null: !( (target.AuditSession_Comments== String.Empty && source.AuditSession_Comments== null) || (target.AuditSession_Comments==null && source.AuditSession_Comments== String.Empty )) &&   !source.AuditSession_Comments.Trim().Replace ("\r","").Equals(target.AuditSession_Comments.Trim().Replace ("\r","")))return false;
								
		  return true;
        }
		#endregion
    }
}

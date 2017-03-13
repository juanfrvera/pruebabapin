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
    public abstract class _AuditOperationDetailData : EntityData<AuditOperationDetail,AuditOperationDetailFilter,AuditOperationDetailResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.AuditOperationDetail entity)
		{			
			return entity.IdOperationDetail;
		}		
		public override AuditOperationDetail GetByEntity(AuditOperationDetail entity)
        {
            return this.GetById(entity.IdOperationDetail);
        }
        public override AuditOperationDetail GetById(int id)
        {
            return (from o in this.Table where o.IdOperationDetail == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<AuditOperationDetail> Query(AuditOperationDetailFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdOperationDetail == null || o.IdOperationDetail >=  filter.IdOperationDetail) && (filter.IdOperationDetail_To == null || o.IdOperationDetail <= filter.IdOperationDetail_To)
					  && (filter.IdAuditOperation == null || filter.IdAuditOperation == 0 || o.IdAuditOperation==filter.IdAuditOperation)
					  && (filter.ParentId == null || o.ParentId >=  filter.ParentId) && (filter.ParentId_To == null || o.ParentId <= filter.ParentId_To)
					  && (filter.ParentIdIsNull == null || filter.ParentIdIsNull == true || o.ParentId != null ) && (filter.ParentIdIsNull == null || filter.ParentIdIsNull == false || o.ParentId == null)
					  && (filter.Detail == null || filter.Detail.Trim() == string.Empty || filter.Detail.Trim() == "%"  || (filter.Detail.EndsWith("%") && filter.Detail.StartsWith("%") && (o.Detail.Contains(filter.Detail.Replace("%", "")))) || (filter.Detail.EndsWith("%") && o.Detail.StartsWith(filter.Detail.Replace("%",""))) || (filter.Detail.StartsWith("%") && o.Detail.EndsWith(filter.Detail.Replace("%",""))) || o.Detail == filter.Detail )
					  && (filter.StartDate == null || filter.StartDate == DateTime.MinValue || o.StartDate >=  filter.StartDate) && (filter.StartDate_To == null || filter.StartDate_To == DateTime.MinValue || o.StartDate <= filter.StartDate_To)
					  && (filter.EndDate == null || filter.EndDate == DateTime.MinValue || o.EndDate >=  filter.EndDate) && (filter.EndDate_To == null || filter.EndDate_To == DateTime.MinValue || o.EndDate <= filter.EndDate_To)
					  && (filter.EndDateIsNull == null || filter.EndDateIsNull == true || o.EndDate != null ) && (filter.EndDateIsNull == null || filter.EndDateIsNull == false || o.EndDate == null)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<AuditOperationDetailResult> QueryResult(AuditOperationDetailFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.AuditOperations on o.IdAuditOperation equals t1.IdAuditOperation   
				   select new AuditOperationDetailResult(){
					 IdOperationDetail=o.IdOperationDetail
					 ,IdAuditOperation=o.IdAuditOperation
					 ,ParentId=o.ParentId
					 ,Detail=o.Detail
					 ,StartDate=o.StartDate
					 ,EndDate=o.EndDate
					,AuditOperation_IdAuditSession= t1.IdAuditSession	
						,AuditOperation_UserName= t1.UserName	
						,AuditOperation_EntityName= t1.EntityName	
						,AuditOperation_EntityBaseName= t1.EntityBaseName	
						,AuditOperation_TypeName= t1.TypeName	
						,AuditOperation_EntityId= t1.EntityId	
						,AuditOperation_EntityKey= t1.EntityKey	
						,AuditOperation_Module= t1.Module	
						,AuditOperation_ServiceType= t1.ServiceType	
						,AuditOperation_Service= t1.Service	
						,AuditOperation_Operation= t1.Operation	
						,AuditOperation_StatusName= t1.StatusName	
						,AuditOperation_Info= t1.Info	
						,AuditOperation_Comment= t1.Comment	
						,AuditOperation_DataOld= t1.DataOld	
						,AuditOperation_DataPreOperation= t1.DataPreOperation	
						,AuditOperation_DataPostOperation= t1.DataPostOperation	
						,AuditOperation_StartDate= t1.StartDate	
						,AuditOperation_EndDate= t1.EndDate	
						,AuditOperation_EnableViewLog= t1.EnableViewLog	
						,AuditOperation_ApplicationName= t1.ApplicationName	
						,AuditOperation_FormPath= t1.FormPath	
						,AuditOperation_FormName= t1.FormName	
						,AuditOperation_UserControlName= t1.UserControlName	
						,AuditOperation_UserControlPath= t1.UserControlPath	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.AuditOperationDetail Copy(nc.AuditOperationDetail entity)
        {           
            nc.AuditOperationDetail _new = new nc.AuditOperationDetail();
		 _new.IdAuditOperation= entity.IdAuditOperation;
		 _new.ParentId= entity.ParentId;
		 _new.Detail= entity.Detail;
		 _new.StartDate= entity.StartDate;
		 _new.EndDate= entity.EndDate;
		return _new;			
        }
		public override int CopyAndSave(AuditOperationDetail entity,string renameFormat)
        {
            AuditOperationDetail  newEntity = Copy(entity);
            newEntity.Detail = string.Format(renameFormat,newEntity.Detail);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(AuditOperationDetail entity, int id)
        {            
            entity.IdOperationDetail = id;            
        }
		public override void Set(AuditOperationDetail source,AuditOperationDetail target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOperationDetail= source.IdOperationDetail ;
		 target.IdAuditOperation= source.IdAuditOperation ;
		 target.ParentId= source.ParentId ;
		 target.Detail= source.Detail ;
		 target.StartDate= source.StartDate ;
		 target.EndDate= source.EndDate ;
		 		  
		}
		public override void Set(AuditOperationDetailResult source,AuditOperationDetail target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOperationDetail= source.IdOperationDetail ;
		 target.IdAuditOperation= source.IdAuditOperation ;
		 target.ParentId= source.ParentId ;
		 target.Detail= source.Detail ;
		 target.StartDate= source.StartDate ;
		 target.EndDate= source.EndDate ;
		 
		}
		public override void Set(AuditOperationDetail source,AuditOperationDetailResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOperationDetail= source.IdOperationDetail ;
		 target.IdAuditOperation= source.IdAuditOperation ;
		 target.ParentId= source.ParentId ;
		 target.Detail= source.Detail ;
		 target.StartDate= source.StartDate ;
		 target.EndDate= source.EndDate ;
		 	
		}		
		public override void Set(AuditOperationDetailResult source,AuditOperationDetailResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOperationDetail= source.IdOperationDetail ;
		 target.IdAuditOperation= source.IdAuditOperation ;
		 target.ParentId= source.ParentId ;
		 target.Detail= source.Detail ;
		 target.StartDate= source.StartDate ;
		 target.EndDate= source.EndDate ;
		 target.AuditOperation_IdAuditSession= source.AuditOperation_IdAuditSession;	
			target.AuditOperation_UserName= source.AuditOperation_UserName;	
			target.AuditOperation_EntityName= source.AuditOperation_EntityName;	
			target.AuditOperation_EntityBaseName= source.AuditOperation_EntityBaseName;	
			target.AuditOperation_TypeName= source.AuditOperation_TypeName;	
			target.AuditOperation_EntityId= source.AuditOperation_EntityId;	
			target.AuditOperation_EntityKey= source.AuditOperation_EntityKey;	
			target.AuditOperation_Module= source.AuditOperation_Module;	
			target.AuditOperation_ServiceType= source.AuditOperation_ServiceType;	
			target.AuditOperation_Service= source.AuditOperation_Service;	
			target.AuditOperation_Operation= source.AuditOperation_Operation;	
			target.AuditOperation_StatusName= source.AuditOperation_StatusName;	
			target.AuditOperation_Info= source.AuditOperation_Info;	
			target.AuditOperation_Comment= source.AuditOperation_Comment;	
			target.AuditOperation_DataOld= source.AuditOperation_DataOld;	
			target.AuditOperation_DataPreOperation= source.AuditOperation_DataPreOperation;	
			target.AuditOperation_DataPostOperation= source.AuditOperation_DataPostOperation;	
			target.AuditOperation_StartDate= source.AuditOperation_StartDate;	
			target.AuditOperation_EndDate= source.AuditOperation_EndDate;	
			target.AuditOperation_EnableViewLog= source.AuditOperation_EnableViewLog;	
			target.AuditOperation_ApplicationName= source.AuditOperation_ApplicationName;	
			target.AuditOperation_FormPath= source.AuditOperation_FormPath;	
			target.AuditOperation_FormName= source.AuditOperation_FormName;	
			target.AuditOperation_UserControlName= source.AuditOperation_UserControlName;	
			target.AuditOperation_UserControlPath= source.AuditOperation_UserControlPath;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(AuditOperationDetail source,AuditOperationDetail target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdOperationDetail.Equals(target.IdOperationDetail))return false;
		  if(!source.IdAuditOperation.Equals(target.IdAuditOperation))return false;
		  if((source.ParentId == null)?(target.ParentId.HasValue):!source.ParentId.Equals(target.ParentId))return false;
			 if((source.Detail == null)?target.Detail!=null:  !( (target.Detail== String.Empty && source.Detail== null) || (target.Detail==null && source.Detail== String.Empty )) &&  !source.Detail.Trim().Replace ("\r","").Equals(target.Detail.Trim().Replace ("\r","")))return false;
			 if(!source.StartDate.Equals(target.StartDate))return false;
		  if((source.EndDate == null)?(target.EndDate.HasValue):!source.EndDate.Equals(target.EndDate))return false;
			
		  return true;
        }
		public override bool Equals(AuditOperationDetailResult source,AuditOperationDetailResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdOperationDetail.Equals(target.IdOperationDetail))return false;
		  if(!source.IdAuditOperation.Equals(target.IdAuditOperation))return false;
		  if((source.ParentId == null)?(target.ParentId.HasValue):!source.ParentId.Equals(target.ParentId))return false;
			 if((source.Detail == null)?target.Detail!=null: !( (target.Detail== String.Empty && source.Detail== null) || (target.Detail==null && source.Detail== String.Empty )) && !source.Detail.Trim().Replace ("\r","").Equals(target.Detail.Trim().Replace ("\r","")))return false;
			 if(!source.StartDate.Equals(target.StartDate))return false;
		  if((source.EndDate == null)?(target.EndDate.HasValue):!source.EndDate.Equals(target.EndDate))return false;
			 if(!source.AuditOperation_IdAuditSession.Equals(target.AuditOperation_IdAuditSession))return false;
					  if((source.AuditOperation_UserName == null)?target.AuditOperation_UserName!=null: !( (target.AuditOperation_UserName== String.Empty && source.AuditOperation_UserName== null) || (target.AuditOperation_UserName==null && source.AuditOperation_UserName== String.Empty )) &&   !source.AuditOperation_UserName.Trim().Replace ("\r","").Equals(target.AuditOperation_UserName.Trim().Replace ("\r","")))return false;
						 if((source.AuditOperation_EntityName == null)?target.AuditOperation_EntityName!=null: !( (target.AuditOperation_EntityName== String.Empty && source.AuditOperation_EntityName== null) || (target.AuditOperation_EntityName==null && source.AuditOperation_EntityName== String.Empty )) &&   !source.AuditOperation_EntityName.Trim().Replace ("\r","").Equals(target.AuditOperation_EntityName.Trim().Replace ("\r","")))return false;
						 if((source.AuditOperation_EntityBaseName == null)?target.AuditOperation_EntityBaseName!=null: !( (target.AuditOperation_EntityBaseName== String.Empty && source.AuditOperation_EntityBaseName== null) || (target.AuditOperation_EntityBaseName==null && source.AuditOperation_EntityBaseName== String.Empty )) &&   !source.AuditOperation_EntityBaseName.Trim().Replace ("\r","").Equals(target.AuditOperation_EntityBaseName.Trim().Replace ("\r","")))return false;
						 if((source.AuditOperation_TypeName == null)?target.AuditOperation_TypeName!=null: !( (target.AuditOperation_TypeName== String.Empty && source.AuditOperation_TypeName== null) || (target.AuditOperation_TypeName==null && source.AuditOperation_TypeName== String.Empty )) &&   !source.AuditOperation_TypeName.Trim().Replace ("\r","").Equals(target.AuditOperation_TypeName.Trim().Replace ("\r","")))return false;
						 if((source.AuditOperation_EntityId == null)?target.AuditOperation_EntityId!=null: !( (target.AuditOperation_EntityId== String.Empty && source.AuditOperation_EntityId== null) || (target.AuditOperation_EntityId==null && source.AuditOperation_EntityId== String.Empty )) &&   !source.AuditOperation_EntityId.Trim().Replace ("\r","").Equals(target.AuditOperation_EntityId.Trim().Replace ("\r","")))return false;
						 if((source.AuditOperation_EntityKey == null)?target.AuditOperation_EntityKey!=null: !( (target.AuditOperation_EntityKey== String.Empty && source.AuditOperation_EntityKey== null) || (target.AuditOperation_EntityKey==null && source.AuditOperation_EntityKey== String.Empty )) &&   !source.AuditOperation_EntityKey.Trim().Replace ("\r","").Equals(target.AuditOperation_EntityKey.Trim().Replace ("\r","")))return false;
						 if((source.AuditOperation_Module == null)?target.AuditOperation_Module!=null: !( (target.AuditOperation_Module== String.Empty && source.AuditOperation_Module== null) || (target.AuditOperation_Module==null && source.AuditOperation_Module== String.Empty )) &&   !source.AuditOperation_Module.Trim().Replace ("\r","").Equals(target.AuditOperation_Module.Trim().Replace ("\r","")))return false;
						 if((source.AuditOperation_ServiceType == null)?target.AuditOperation_ServiceType!=null: !( (target.AuditOperation_ServiceType== String.Empty && source.AuditOperation_ServiceType== null) || (target.AuditOperation_ServiceType==null && source.AuditOperation_ServiceType== String.Empty )) &&   !source.AuditOperation_ServiceType.Trim().Replace ("\r","").Equals(target.AuditOperation_ServiceType.Trim().Replace ("\r","")))return false;
						 if((source.AuditOperation_Service == null)?target.AuditOperation_Service!=null: !( (target.AuditOperation_Service== String.Empty && source.AuditOperation_Service== null) || (target.AuditOperation_Service==null && source.AuditOperation_Service== String.Empty )) &&   !source.AuditOperation_Service.Trim().Replace ("\r","").Equals(target.AuditOperation_Service.Trim().Replace ("\r","")))return false;
						 if((source.AuditOperation_Operation == null)?target.AuditOperation_Operation!=null: !( (target.AuditOperation_Operation== String.Empty && source.AuditOperation_Operation== null) || (target.AuditOperation_Operation==null && source.AuditOperation_Operation== String.Empty )) &&   !source.AuditOperation_Operation.Trim().Replace ("\r","").Equals(target.AuditOperation_Operation.Trim().Replace ("\r","")))return false;
						 if((source.AuditOperation_StatusName == null)?target.AuditOperation_StatusName!=null: !( (target.AuditOperation_StatusName== String.Empty && source.AuditOperation_StatusName== null) || (target.AuditOperation_StatusName==null && source.AuditOperation_StatusName== String.Empty )) &&   !source.AuditOperation_StatusName.Trim().Replace ("\r","").Equals(target.AuditOperation_StatusName.Trim().Replace ("\r","")))return false;
						 if((source.AuditOperation_Info == null)?target.AuditOperation_Info!=null: !( (target.AuditOperation_Info== String.Empty && source.AuditOperation_Info== null) || (target.AuditOperation_Info==null && source.AuditOperation_Info== String.Empty )) &&   !source.AuditOperation_Info.Trim().Replace ("\r","").Equals(target.AuditOperation_Info.Trim().Replace ("\r","")))return false;
						 if((source.AuditOperation_Comment == null)?target.AuditOperation_Comment!=null: !( (target.AuditOperation_Comment== String.Empty && source.AuditOperation_Comment== null) || (target.AuditOperation_Comment==null && source.AuditOperation_Comment== String.Empty )) &&   !source.AuditOperation_Comment.Trim().Replace ("\r","").Equals(target.AuditOperation_Comment.Trim().Replace ("\r","")))return false;
						 if((source.AuditOperation_DataOld == null)?target.AuditOperation_DataOld!=null: !( (target.AuditOperation_DataOld== String.Empty && source.AuditOperation_DataOld== null) || (target.AuditOperation_DataOld==null && source.AuditOperation_DataOld== String.Empty )) &&   !source.AuditOperation_DataOld.Trim().Replace ("\r","").Equals(target.AuditOperation_DataOld.Trim().Replace ("\r","")))return false;
						 if((source.AuditOperation_DataPreOperation == null)?target.AuditOperation_DataPreOperation!=null: !( (target.AuditOperation_DataPreOperation== String.Empty && source.AuditOperation_DataPreOperation== null) || (target.AuditOperation_DataPreOperation==null && source.AuditOperation_DataPreOperation== String.Empty )) &&   !source.AuditOperation_DataPreOperation.Trim().Replace ("\r","").Equals(target.AuditOperation_DataPreOperation.Trim().Replace ("\r","")))return false;
						 if((source.AuditOperation_DataPostOperation == null)?target.AuditOperation_DataPostOperation!=null: !( (target.AuditOperation_DataPostOperation== String.Empty && source.AuditOperation_DataPostOperation== null) || (target.AuditOperation_DataPostOperation==null && source.AuditOperation_DataPostOperation== String.Empty )) &&   !source.AuditOperation_DataPostOperation.Trim().Replace ("\r","").Equals(target.AuditOperation_DataPostOperation.Trim().Replace ("\r","")))return false;
						 if(!source.AuditOperation_StartDate.Equals(target.AuditOperation_StartDate))return false;
					  if((source.AuditOperation_EndDate == null)?(target.AuditOperation_EndDate.HasValue ):!source.AuditOperation_EndDate.Equals(target.AuditOperation_EndDate))return false;
						 if(!source.AuditOperation_EnableViewLog.Equals(target.AuditOperation_EnableViewLog))return false;
					  if((source.AuditOperation_ApplicationName == null)?target.AuditOperation_ApplicationName!=null: !( (target.AuditOperation_ApplicationName== String.Empty && source.AuditOperation_ApplicationName== null) || (target.AuditOperation_ApplicationName==null && source.AuditOperation_ApplicationName== String.Empty )) &&   !source.AuditOperation_ApplicationName.Trim().Replace ("\r","").Equals(target.AuditOperation_ApplicationName.Trim().Replace ("\r","")))return false;
						 if((source.AuditOperation_FormPath == null)?target.AuditOperation_FormPath!=null: !( (target.AuditOperation_FormPath== String.Empty && source.AuditOperation_FormPath== null) || (target.AuditOperation_FormPath==null && source.AuditOperation_FormPath== String.Empty )) &&   !source.AuditOperation_FormPath.Trim().Replace ("\r","").Equals(target.AuditOperation_FormPath.Trim().Replace ("\r","")))return false;
						 if((source.AuditOperation_FormName == null)?target.AuditOperation_FormName!=null: !( (target.AuditOperation_FormName== String.Empty && source.AuditOperation_FormName== null) || (target.AuditOperation_FormName==null && source.AuditOperation_FormName== String.Empty )) &&   !source.AuditOperation_FormName.Trim().Replace ("\r","").Equals(target.AuditOperation_FormName.Trim().Replace ("\r","")))return false;
						 if((source.AuditOperation_UserControlName == null)?target.AuditOperation_UserControlName!=null: !( (target.AuditOperation_UserControlName== String.Empty && source.AuditOperation_UserControlName== null) || (target.AuditOperation_UserControlName==null && source.AuditOperation_UserControlName== String.Empty )) &&   !source.AuditOperation_UserControlName.Trim().Replace ("\r","").Equals(target.AuditOperation_UserControlName.Trim().Replace ("\r","")))return false;
						 if((source.AuditOperation_UserControlPath == null)?target.AuditOperation_UserControlPath!=null: !( (target.AuditOperation_UserControlPath== String.Empty && source.AuditOperation_UserControlPath== null) || (target.AuditOperation_UserControlPath==null && source.AuditOperation_UserControlPath== String.Empty )) &&   !source.AuditOperation_UserControlPath.Trim().Replace ("\r","").Equals(target.AuditOperation_UserControlPath.Trim().Replace ("\r","")))return false;
								
		  return true;
        }
		#endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _AuditOperationDetailResult : IResult<int>
    {        
		public virtual int ID{get{return IdOperationDetail;}}
		 public int IdOperationDetail{get;set;}
		 public int IdAuditOperation{get;set;}
		 public int? ParentId{get;set;}
		 public string Detail{get;set;}
		 public DateTime StartDate{get;set;}
		 public DateTime? EndDate{get;set;}
		 
		 public int AuditOperation_IdAuditSession{get;set;}	
	public string AuditOperation_UserName{get;set;}	
	public string AuditOperation_EntityName{get;set;}	
	public string AuditOperation_EntityBaseName{get;set;}	
	public string AuditOperation_TypeName{get;set;}	
	public string AuditOperation_EntityId{get;set;}	
	public string AuditOperation_EntityKey{get;set;}	
	public string AuditOperation_Module{get;set;}	
	public string AuditOperation_ServiceType{get;set;}	
	public string AuditOperation_Service{get;set;}	
	public string AuditOperation_Operation{get;set;}	
	public string AuditOperation_StatusName{get;set;}	
	public string AuditOperation_Info{get;set;}	
	public string AuditOperation_Comment{get;set;}	
	public string AuditOperation_DataOld{get;set;}	
	public string AuditOperation_DataPreOperation{get;set;}	
	public string AuditOperation_DataPostOperation{get;set;}	
	public DateTime AuditOperation_StartDate{get;set;}	
	public DateTime? AuditOperation_EndDate{get;set;}	
	public bool AuditOperation_EnableViewLog{get;set;}	
	public string AuditOperation_ApplicationName{get;set;}	
	public string AuditOperation_FormPath{get;set;}	
	public string AuditOperation_FormName{get;set;}	
	public string AuditOperation_UserControlName{get;set;}	
	public string AuditOperation_UserControlPath{get;set;}	
					
		public virtual AuditOperationDetail ToEntity()
		{
		   AuditOperationDetail _AuditOperationDetail = new AuditOperationDetail();
		_AuditOperationDetail.IdOperationDetail = this.IdOperationDetail;
		 _AuditOperationDetail.IdAuditOperation = this.IdAuditOperation;
		 _AuditOperationDetail.ParentId = this.ParentId;
		 _AuditOperationDetail.Detail = this.Detail;
		 _AuditOperationDetail.StartDate = this.StartDate;
		 _AuditOperationDetail.EndDate = this.EndDate;
		 
		  return _AuditOperationDetail;
		}		
		public virtual void Set(AuditOperationDetail entity)
		{		   
		 this.IdOperationDetail= entity.IdOperationDetail ;
		  this.IdAuditOperation= entity.IdAuditOperation ;
		  this.ParentId= entity.ParentId ;
		  this.Detail= entity.Detail ;
		  this.StartDate= entity.StartDate ;
		  this.EndDate= entity.EndDate ;
		 		  
		}		
		public virtual bool Equals(AuditOperationDetail entity)
        {
		   if(entity == null)return false;
         if(!entity.IdOperationDetail.Equals(this.IdOperationDetail))return false;
		  if(!entity.IdAuditOperation.Equals(this.IdAuditOperation))return false;
		  if((entity.ParentId == null)?this.ParentId!=null:!entity.ParentId.Equals(this.ParentId))return false;
			 if((entity.Detail == null)?this.Detail!=null:!entity.Detail.Equals(this.Detail))return false;
			 if(!entity.StartDate.Equals(this.StartDate))return false;
		  if((entity.EndDate == null)?this.EndDate!=null:!entity.EndDate.Equals(this.EndDate))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("AuditOperationDetail", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("AuditOperation","AuditOperation_UserName")
			,new DataColumnMapping("Parent","ParentId")
			,new DataColumnMapping("Detail","Detail")
			,new DataColumnMapping("StartDate","StartDate","{0:dd/MM/yyyy}")
			,new DataColumnMapping("EndDate","EndDate","{0:dd/MM/yyyy}")
			}));
		}
	}
}
		
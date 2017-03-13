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
    public abstract class _AuditSessionData : EntityData<AuditSession,AuditSessionFilter,AuditSessionResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.AuditSession entity)
		{			
			return entity.IdAuditSession;
		}		
		public override AuditSession GetByEntity(AuditSession entity)
        {
            return this.GetById(entity.IdAuditSession);
        }
        public override AuditSession GetById(int id)
        {
            return (from o in this.Table where o.IdAuditSession == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<AuditSession> Query(AuditSessionFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdAuditSession == null || filter.IdAuditSession == 0 || o.IdAuditSession==filter.IdAuditSession)
					  && (filter.UserName == null || filter.UserName.Trim() == string.Empty || filter.UserName.Trim() == "%"  || (filter.UserName.EndsWith("%") && filter.UserName.StartsWith("%") && (o.UserName.Contains(filter.UserName.Replace("%", "")))) || (filter.UserName.EndsWith("%") && o.UserName.StartsWith(filter.UserName.Replace("%",""))) || (filter.UserName.StartsWith("%") && o.UserName.EndsWith(filter.UserName.Replace("%",""))) || o.UserName == filter.UserName )
					  && (filter.SessionId == null || filter.SessionId.Trim() == string.Empty || filter.SessionId.Trim() == "%"  || (filter.SessionId.EndsWith("%") && filter.SessionId.StartsWith("%") && (o.SessionId.Contains(filter.SessionId.Replace("%", "")))) || (filter.SessionId.EndsWith("%") && o.SessionId.StartsWith(filter.SessionId.Replace("%",""))) || (filter.SessionId.StartsWith("%") && o.SessionId.EndsWith(filter.SessionId.Replace("%",""))) || o.SessionId == filter.SessionId )
					  && (filter.Login == null || filter.Login.Trim() == string.Empty || filter.Login.Trim() == "%"  || (filter.Login.EndsWith("%") && filter.Login.StartsWith("%") && (o.Login.Contains(filter.Login.Replace("%", "")))) || (filter.Login.EndsWith("%") && o.Login.StartsWith(filter.Login.Replace("%",""))) || (filter.Login.StartsWith("%") && o.Login.EndsWith(filter.Login.Replace("%",""))) || o.Login == filter.Login )
					  && (filter.Rols == null || filter.Rols.Trim() == string.Empty || filter.Rols.Trim() == "%"  || (filter.Rols.EndsWith("%") && filter.Rols.StartsWith("%") && (o.Rols.Contains(filter.Rols.Replace("%", "")))) || (filter.Rols.EndsWith("%") && o.Rols.StartsWith(filter.Rols.Replace("%",""))) || (filter.Rols.StartsWith("%") && o.Rols.EndsWith(filter.Rols.Replace("%",""))) || o.Rols == filter.Rols )
					  && (filter.Area == null || filter.Area.Trim() == string.Empty || filter.Area.Trim() == "%"  || (filter.Area.EndsWith("%") && filter.Area.StartsWith("%") && (o.Area.Contains(filter.Area.Replace("%", "")))) || (filter.Area.EndsWith("%") && o.Area.StartsWith(filter.Area.Replace("%",""))) || (filter.Area.StartsWith("%") && o.Area.EndsWith(filter.Area.Replace("%",""))) || o.Area == filter.Area )
					  && (filter.IP == null || filter.IP.Trim() == string.Empty || filter.IP.Trim() == "%"  || (filter.IP.EndsWith("%") && filter.IP.StartsWith("%") && (o.IP.Contains(filter.IP.Replace("%", "")))) || (filter.IP.EndsWith("%") && o.IP.StartsWith(filter.IP.Replace("%",""))) || (filter.IP.StartsWith("%") && o.IP.EndsWith(filter.IP.Replace("%",""))) || o.IP == filter.IP )
					  && (filter.BrowserVersion == null || filter.BrowserVersion.Trim() == string.Empty || filter.BrowserVersion.Trim() == "%"  || (filter.BrowserVersion.EndsWith("%") && filter.BrowserVersion.StartsWith("%") && (o.BrowserVersion.Contains(filter.BrowserVersion.Replace("%", "")))) || (filter.BrowserVersion.EndsWith("%") && o.BrowserVersion.StartsWith(filter.BrowserVersion.Replace("%",""))) || (filter.BrowserVersion.StartsWith("%") && o.BrowserVersion.EndsWith(filter.BrowserVersion.Replace("%",""))) || o.BrowserVersion == filter.BrowserVersion )
					  && (filter.OperatingSystem == null || filter.OperatingSystem.Trim() == string.Empty || filter.OperatingSystem.Trim() == "%"  || (filter.OperatingSystem.EndsWith("%") && filter.OperatingSystem.StartsWith("%") && (o.OperatingSystem.Contains(filter.OperatingSystem.Replace("%", "")))) || (filter.OperatingSystem.EndsWith("%") && o.OperatingSystem.StartsWith(filter.OperatingSystem.Replace("%",""))) || (filter.OperatingSystem.StartsWith("%") && o.OperatingSystem.EndsWith(filter.OperatingSystem.Replace("%",""))) || o.OperatingSystem == filter.OperatingSystem )
					  && (filter.StartDate == null || filter.StartDate == DateTime.MinValue || o.StartDate >=  filter.StartDate) && (filter.StartDate_To == null || filter.StartDate_To == DateTime.MinValue || o.StartDate <= filter.StartDate_To)
					  && (filter.StartDateIsNull == null || filter.StartDateIsNull == true || o.StartDate != null ) && (filter.StartDateIsNull == null || filter.StartDateIsNull == false || o.StartDate == null)
					  && (filter.EndDate == null || filter.EndDate == DateTime.MinValue || o.EndDate >=  filter.EndDate) && (filter.EndDate_To == null || filter.EndDate_To == DateTime.MinValue || o.EndDate <= filter.EndDate_To)
					  && (filter.EndDateIsNull == null || filter.EndDateIsNull == true || o.EndDate != null ) && (filter.EndDateIsNull == null || filter.EndDateIsNull == false || o.EndDate == null)
					  && (filter.Mandate == null || filter.Mandate.Trim() == string.Empty || filter.Mandate.Trim() == "%"  || (filter.Mandate.EndsWith("%") && filter.Mandate.StartsWith("%") && (o.Mandate.Contains(filter.Mandate.Replace("%", "")))) || (filter.Mandate.EndsWith("%") && o.Mandate.StartsWith(filter.Mandate.Replace("%",""))) || (filter.Mandate.StartsWith("%") && o.Mandate.EndsWith(filter.Mandate.Replace("%",""))) || o.Mandate == filter.Mandate )
					  && (filter.Message == null || filter.Message.Trim() == string.Empty || filter.Message.Trim() == "%"  || (filter.Message.EndsWith("%") && filter.Message.StartsWith("%") && (o.Message.Contains(filter.Message.Replace("%", "")))) || (filter.Message.EndsWith("%") && o.Message.StartsWith(filter.Message.Replace("%",""))) || (filter.Message.StartsWith("%") && o.Message.EndsWith(filter.Message.Replace("%",""))) || o.Message == filter.Message )
					  && (filter.Comments == null || filter.Comments.Trim() == string.Empty || filter.Comments.Trim() == "%"  || (filter.Comments.EndsWith("%") && filter.Comments.StartsWith("%") && (o.Comments.Contains(filter.Comments.Replace("%", "")))) || (filter.Comments.EndsWith("%") && o.Comments.StartsWith(filter.Comments.Replace("%",""))) || (filter.Comments.StartsWith("%") && o.Comments.EndsWith(filter.Comments.Replace("%",""))) || o.Comments == filter.Comments )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<AuditSessionResult> QueryResult(AuditSessionFilter filter)
        {
		  return (from o in Query(filter)					
					select new AuditSessionResult(){
					 IdAuditSession=o.IdAuditSession
					 ,UserName=o.UserName
					 ,SessionId=o.SessionId
					 ,Login=o.Login
					 ,Rols=o.Rols
					 ,Area=o.Area
					 ,IP=o.IP
					 ,BrowserVersion=o.BrowserVersion
					 ,OperatingSystem=o.OperatingSystem
					 ,StartDate=o.StartDate
					 ,EndDate=o.EndDate
					 ,Mandate=o.Mandate
					 ,Message=o.Message
					 ,Comments=o.Comments
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.AuditSession Copy(nc.AuditSession entity)
        {           
            nc.AuditSession _new = new nc.AuditSession();
		 _new.UserName= entity.UserName;
		 _new.SessionId= entity.SessionId;
		 _new.Login= entity.Login;
		 _new.Rols= entity.Rols;
		 _new.Area= entity.Area;
		 _new.IP= entity.IP;
		 _new.BrowserVersion= entity.BrowserVersion;
		 _new.OperatingSystem= entity.OperatingSystem;
		 _new.StartDate= entity.StartDate;
		 _new.EndDate= entity.EndDate;
		 _new.Mandate= entity.Mandate;
		 _new.Message= entity.Message;
		 _new.Comments= entity.Comments;
		return _new;			
        }
		public override int CopyAndSave(AuditSession entity,string renameFormat)
        {
            AuditSession  newEntity = Copy(entity);
            newEntity.UserName = string.Format(renameFormat,newEntity.UserName);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(AuditSession entity, int id)
        {            
            entity.IdAuditSession = id;            
        }
		public override void Set(AuditSession source,AuditSession target,bool hadSetId)
		{		   
		if(hadSetId)target.IdAuditSession= source.IdAuditSession ;
		 target.UserName= source.UserName ;
		 target.SessionId= source.SessionId ;
		 target.Login= source.Login ;
		 target.Rols= source.Rols ;
		 target.Area= source.Area ;
		 target.IP= source.IP ;
		 target.BrowserVersion= source.BrowserVersion ;
		 target.OperatingSystem= source.OperatingSystem ;
		 target.StartDate= source.StartDate ;
		 target.EndDate= source.EndDate ;
		 target.Mandate= source.Mandate ;
		 target.Message= source.Message ;
		 target.Comments= source.Comments ;
		 		  
		}
		public override void Set(AuditSessionResult source,AuditSession target,bool hadSetId)
		{		   
		if(hadSetId)target.IdAuditSession= source.IdAuditSession ;
		 target.UserName= source.UserName ;
		 target.SessionId= source.SessionId ;
		 target.Login= source.Login ;
		 target.Rols= source.Rols ;
		 target.Area= source.Area ;
		 target.IP= source.IP ;
		 target.BrowserVersion= source.BrowserVersion ;
		 target.OperatingSystem= source.OperatingSystem ;
		 target.StartDate= source.StartDate ;
		 target.EndDate= source.EndDate ;
		 target.Mandate= source.Mandate ;
		 target.Message= source.Message ;
		 target.Comments= source.Comments ;
		 
		}
		public override void Set(AuditSession source,AuditSessionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdAuditSession= source.IdAuditSession ;
		 target.UserName= source.UserName ;
		 target.SessionId= source.SessionId ;
		 target.Login= source.Login ;
		 target.Rols= source.Rols ;
		 target.Area= source.Area ;
		 target.IP= source.IP ;
		 target.BrowserVersion= source.BrowserVersion ;
		 target.OperatingSystem= source.OperatingSystem ;
		 target.StartDate= source.StartDate ;
		 target.EndDate= source.EndDate ;
		 target.Mandate= source.Mandate ;
		 target.Message= source.Message ;
		 target.Comments= source.Comments ;
		 	
		}		
		public override void Set(AuditSessionResult source,AuditSessionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdAuditSession= source.IdAuditSession ;
		 target.UserName= source.UserName ;
		 target.SessionId= source.SessionId ;
		 target.Login= source.Login ;
		 target.Rols= source.Rols ;
		 target.Area= source.Area ;
		 target.IP= source.IP ;
		 target.BrowserVersion= source.BrowserVersion ;
		 target.OperatingSystem= source.OperatingSystem ;
		 target.StartDate= source.StartDate ;
		 target.EndDate= source.EndDate ;
		 target.Mandate= source.Mandate ;
		 target.Message= source.Message ;
		 target.Comments= source.Comments ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(AuditSession source,AuditSession target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdAuditSession.Equals(target.IdAuditSession))return false;
		  if((source.UserName == null)?target.UserName!=null:  !( (target.UserName== String.Empty && source.UserName== null) || (target.UserName==null && source.UserName== String.Empty )) &&  !source.UserName.Trim().Replace ("\r","").Equals(target.UserName.Trim().Replace ("\r","")))return false;
			 if((source.SessionId == null)?target.SessionId!=null:  !( (target.SessionId== String.Empty && source.SessionId== null) || (target.SessionId==null && source.SessionId== String.Empty )) &&  !source.SessionId.Trim().Replace ("\r","").Equals(target.SessionId.Trim().Replace ("\r","")))return false;
			 if((source.Login == null)?target.Login!=null:  !( (target.Login== String.Empty && source.Login== null) || (target.Login==null && source.Login== String.Empty )) &&  !source.Login.Trim().Replace ("\r","").Equals(target.Login.Trim().Replace ("\r","")))return false;
			 if((source.Rols == null)?target.Rols!=null:  !( (target.Rols== String.Empty && source.Rols== null) || (target.Rols==null && source.Rols== String.Empty )) &&  !source.Rols.Trim().Replace ("\r","").Equals(target.Rols.Trim().Replace ("\r","")))return false;
			 if((source.Area == null)?target.Area!=null:  !( (target.Area== String.Empty && source.Area== null) || (target.Area==null && source.Area== String.Empty )) &&  !source.Area.Trim().Replace ("\r","").Equals(target.Area.Trim().Replace ("\r","")))return false;
			 if((source.IP == null)?target.IP!=null:  !( (target.IP== String.Empty && source.IP== null) || (target.IP==null && source.IP== String.Empty )) &&  !source.IP.Trim().Replace ("\r","").Equals(target.IP.Trim().Replace ("\r","")))return false;
			 if((source.BrowserVersion == null)?target.BrowserVersion!=null:  !( (target.BrowserVersion== String.Empty && source.BrowserVersion== null) || (target.BrowserVersion==null && source.BrowserVersion== String.Empty )) &&  !source.BrowserVersion.Trim().Replace ("\r","").Equals(target.BrowserVersion.Trim().Replace ("\r","")))return false;
			 if((source.OperatingSystem == null)?target.OperatingSystem!=null:  !( (target.OperatingSystem== String.Empty && source.OperatingSystem== null) || (target.OperatingSystem==null && source.OperatingSystem== String.Empty )) &&  !source.OperatingSystem.Trim().Replace ("\r","").Equals(target.OperatingSystem.Trim().Replace ("\r","")))return false;
			 if((source.StartDate == null)?(target.StartDate.HasValue):!source.StartDate.Equals(target.StartDate))return false;
			 if((source.EndDate == null)?(target.EndDate.HasValue):!source.EndDate.Equals(target.EndDate))return false;
			 if((source.Mandate == null)?target.Mandate!=null:  !( (target.Mandate== String.Empty && source.Mandate== null) || (target.Mandate==null && source.Mandate== String.Empty )) &&  !source.Mandate.Trim().Replace ("\r","").Equals(target.Mandate.Trim().Replace ("\r","")))return false;
			 if((source.Message == null)?target.Message!=null:  !( (target.Message== String.Empty && source.Message== null) || (target.Message==null && source.Message== String.Empty )) &&  !source.Message.Trim().Replace ("\r","").Equals(target.Message.Trim().Replace ("\r","")))return false;
			 if((source.Comments == null)?target.Comments!=null:  !( (target.Comments== String.Empty && source.Comments== null) || (target.Comments==null && source.Comments== String.Empty )) &&  !source.Comments.Trim().Replace ("\r","").Equals(target.Comments.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(AuditSessionResult source,AuditSessionResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdAuditSession.Equals(target.IdAuditSession))return false;
		  if((source.UserName == null)?target.UserName!=null: !( (target.UserName== String.Empty && source.UserName== null) || (target.UserName==null && source.UserName== String.Empty )) && !source.UserName.Trim().Replace ("\r","").Equals(target.UserName.Trim().Replace ("\r","")))return false;
			 if((source.SessionId == null)?target.SessionId!=null: !( (target.SessionId== String.Empty && source.SessionId== null) || (target.SessionId==null && source.SessionId== String.Empty )) && !source.SessionId.Trim().Replace ("\r","").Equals(target.SessionId.Trim().Replace ("\r","")))return false;
			 if((source.Login == null)?target.Login!=null: !( (target.Login== String.Empty && source.Login== null) || (target.Login==null && source.Login== String.Empty )) && !source.Login.Trim().Replace ("\r","").Equals(target.Login.Trim().Replace ("\r","")))return false;
			 if((source.Rols == null)?target.Rols!=null: !( (target.Rols== String.Empty && source.Rols== null) || (target.Rols==null && source.Rols== String.Empty )) && !source.Rols.Trim().Replace ("\r","").Equals(target.Rols.Trim().Replace ("\r","")))return false;
			 if((source.Area == null)?target.Area!=null: !( (target.Area== String.Empty && source.Area== null) || (target.Area==null && source.Area== String.Empty )) && !source.Area.Trim().Replace ("\r","").Equals(target.Area.Trim().Replace ("\r","")))return false;
			 if((source.IP == null)?target.IP!=null: !( (target.IP== String.Empty && source.IP== null) || (target.IP==null && source.IP== String.Empty )) && !source.IP.Trim().Replace ("\r","").Equals(target.IP.Trim().Replace ("\r","")))return false;
			 if((source.BrowserVersion == null)?target.BrowserVersion!=null: !( (target.BrowserVersion== String.Empty && source.BrowserVersion== null) || (target.BrowserVersion==null && source.BrowserVersion== String.Empty )) && !source.BrowserVersion.Trim().Replace ("\r","").Equals(target.BrowserVersion.Trim().Replace ("\r","")))return false;
			 if((source.OperatingSystem == null)?target.OperatingSystem!=null: !( (target.OperatingSystem== String.Empty && source.OperatingSystem== null) || (target.OperatingSystem==null && source.OperatingSystem== String.Empty )) && !source.OperatingSystem.Trim().Replace ("\r","").Equals(target.OperatingSystem.Trim().Replace ("\r","")))return false;
			 if((source.StartDate == null)?(target.StartDate.HasValue):!source.StartDate.Equals(target.StartDate))return false;
			 if((source.EndDate == null)?(target.EndDate.HasValue):!source.EndDate.Equals(target.EndDate))return false;
			 if((source.Mandate == null)?target.Mandate!=null: !( (target.Mandate== String.Empty && source.Mandate== null) || (target.Mandate==null && source.Mandate== String.Empty )) && !source.Mandate.Trim().Replace ("\r","").Equals(target.Mandate.Trim().Replace ("\r","")))return false;
			 if((source.Message == null)?target.Message!=null: !( (target.Message== String.Empty && source.Message== null) || (target.Message==null && source.Message== String.Empty )) && !source.Message.Trim().Replace ("\r","").Equals(target.Message.Trim().Replace ("\r","")))return false;
			 if((source.Comments == null)?target.Comments!=null: !( (target.Comments== String.Empty && source.Comments== null) || (target.Comments==null && source.Comments== String.Empty )) && !source.Comments.Trim().Replace ("\r","").Equals(target.Comments.Trim().Replace ("\r","")))return false;
					
		  return true;
        }
		#endregion
    }
}

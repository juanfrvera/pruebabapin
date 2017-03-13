using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class AuditOperationData : _AuditOperationData
    {
	   #region Singleton
	   private static volatile AuditOperationData current;
	   private static object syncRoot = new Object();

	   //private AuditOperationData() {}
	   public static AuditOperationData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new AuditOperationData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdAuditOperation"; } }

       protected override IQueryable<AuditOperation> Query(AuditOperationFilter filter)
       {
           return (from o in this.Table
                   where (filter.IdAuditSession == null || filter.IdAuditSession == 0 || o.IdAuditSession == filter.IdAuditSession)
                   && (filter.UserName == null || filter.UserName.Trim() == string.Empty || filter.UserName.Trim() == "%" || (filter.UserName.EndsWith("%") && filter.UserName.StartsWith("%") && (o.UserName.Contains(filter.UserName.Replace("%", "")))) || (filter.UserName.EndsWith("%") && o.UserName.StartsWith(filter.UserName.Replace("%", ""))) || (filter.UserName.StartsWith("%") && o.UserName.EndsWith(filter.UserName.Replace("%", ""))) || o.UserName == filter.UserName)
                   && (filter.EntityName == null || filter.EntityName.Trim() == string.Empty || filter.EntityName.Trim() == "%" || (filter.EntityName.EndsWith("%") && filter.EntityName.StartsWith("%") && (o.EntityName.Contains(filter.EntityName.Replace("%", "")))) || (filter.EntityName.EndsWith("%") && o.EntityName.StartsWith(filter.EntityName.Replace("%", ""))) || (filter.EntityName.StartsWith("%") && o.EntityName.EndsWith(filter.EntityName.Replace("%", ""))) || o.EntityName == filter.EntityName)
                   && (filter.EntityBaseName == null || filter.EntityBaseName.Trim() == string.Empty || filter.EntityBaseName.Trim() == "%" || (filter.EntityBaseName.EndsWith("%") && filter.EntityBaseName.StartsWith("%") && (o.EntityBaseName.Contains(filter.EntityBaseName.Replace("%", "")))) || (filter.EntityBaseName.EndsWith("%") && o.EntityBaseName.StartsWith(filter.EntityBaseName.Replace("%", ""))) || (filter.EntityBaseName.StartsWith("%") && o.EntityBaseName.EndsWith(filter.EntityBaseName.Replace("%", ""))) || o.EntityBaseName == filter.EntityBaseName)
                   && (filter.TypeName == null || filter.TypeName.Trim() == string.Empty || filter.TypeName.Trim() == "%" || (filter.TypeName.EndsWith("%") && filter.TypeName.StartsWith("%") && (o.TypeName.Contains(filter.TypeName.Replace("%", "")))) || (filter.TypeName.EndsWith("%") && o.TypeName.StartsWith(filter.TypeName.Replace("%", ""))) || (filter.TypeName.StartsWith("%") && o.TypeName.EndsWith(filter.TypeName.Replace("%", ""))) || o.TypeName == filter.TypeName)
                   && (filter.EntityId == null || filter.EntityId.Trim() == string.Empty || filter.EntityId.Trim() == "%" || (filter.EntityId.EndsWith("%") && filter.EntityId.StartsWith("%") && (o.EntityId.Contains(filter.EntityId.Replace("%", "")))) || (filter.EntityId.EndsWith("%") && o.EntityId.StartsWith(filter.EntityId.Replace("%", ""))) || (filter.EntityId.StartsWith("%") && o.EntityId.EndsWith(filter.EntityId.Replace("%", ""))) || o.EntityId == filter.EntityId)
                   && (filter.EntityKey == null || filter.EntityKey.Trim() == string.Empty || filter.EntityKey.Trim() == "%" || (filter.EntityKey.EndsWith("%") && filter.EntityKey.StartsWith("%") && (o.EntityKey.Contains(filter.EntityKey.Replace("%", "")))) || (filter.EntityKey.EndsWith("%") && o.EntityKey.StartsWith(filter.EntityKey.Replace("%", ""))) || (filter.EntityKey.StartsWith("%") && o.EntityKey.EndsWith(filter.EntityKey.Replace("%", ""))) || o.EntityKey == filter.EntityKey)
                   && (filter.Module == null || filter.Module.Trim() == string.Empty || filter.Module.Trim() == "%" || (filter.Module.EndsWith("%") && filter.Module.StartsWith("%") && (o.Module.Contains(filter.Module.Replace("%", "")))) || (filter.Module.EndsWith("%") && o.Module.StartsWith(filter.Module.Replace("%", ""))) || (filter.Module.StartsWith("%") && o.Module.EndsWith(filter.Module.Replace("%", ""))) || o.Module == filter.Module)
                   && (filter.ServiceType == null || filter.ServiceType.Trim() == string.Empty || filter.ServiceType.Trim() == "%" || (filter.ServiceType.EndsWith("%") && filter.ServiceType.StartsWith("%") && (o.ServiceType.Contains(filter.ServiceType.Replace("%", "")))) || (filter.ServiceType.EndsWith("%") && o.ServiceType.StartsWith(filter.ServiceType.Replace("%", ""))) || (filter.ServiceType.StartsWith("%") && o.ServiceType.EndsWith(filter.ServiceType.Replace("%", ""))) || o.ServiceType == filter.ServiceType)
                   && (filter.Service == null || filter.Service.Trim() == string.Empty || filter.Service.Trim() == "%" || (filter.Service.EndsWith("%") && filter.Service.StartsWith("%") && (o.Service.Contains(filter.Service.Replace("%", "")))) || (filter.Service.EndsWith("%") && o.Service.StartsWith(filter.Service.Replace("%", ""))) || (filter.Service.StartsWith("%") && o.Service.EndsWith(filter.Service.Replace("%", ""))) || o.Service == filter.Service)
                   && (filter.Operation == null || filter.Operation.Trim() == string.Empty || filter.Operation.Trim() == "%" || (filter.Operation.EndsWith("%") && filter.Operation.StartsWith("%") && (o.Operation.Contains(filter.Operation.Replace("%", "")))) || (filter.Operation.EndsWith("%") && o.Operation.StartsWith(filter.Operation.Replace("%", ""))) || (filter.Operation.StartsWith("%") && o.Operation.EndsWith(filter.Operation.Replace("%", ""))) || o.Operation == filter.Operation)
                   && (filter.StatusName == null || filter.StatusName.Trim() == string.Empty || filter.StatusName.Trim() == "%" || (filter.StatusName.EndsWith("%") && filter.StatusName.StartsWith("%") && (o.StatusName.Contains(filter.StatusName.Replace("%", "")))) || (filter.StatusName.EndsWith("%") && o.StatusName.StartsWith(filter.StatusName.Replace("%", ""))) || (filter.StatusName.StartsWith("%") && o.StatusName.EndsWith(filter.StatusName.Replace("%", ""))) || o.StatusName == filter.StatusName)
                   && (filter.Info == null || filter.Info.Trim() == string.Empty || filter.Info.Trim() == "%" || (filter.Info.EndsWith("%") && filter.Info.StartsWith("%") && (o.Info.Contains(filter.Info.Replace("%", "")))) || (filter.Info.EndsWith("%") && o.Info.StartsWith(filter.Info.Replace("%", ""))) || (filter.Info.StartsWith("%") && o.Info.EndsWith(filter.Info.Replace("%", ""))) || o.Info == filter.Info)
                   && (filter.Comment == null || filter.Comment.Trim() == string.Empty || filter.Comment.Trim() == "%" || (filter.Comment.EndsWith("%") && filter.Comment.StartsWith("%") && (o.Comment.Contains(filter.Comment.Replace("%", "")))) || (filter.Comment.EndsWith("%") && o.Comment.StartsWith(filter.Comment.Replace("%", ""))) || (filter.Comment.StartsWith("%") && o.Comment.EndsWith(filter.Comment.Replace("%", ""))) || o.Comment == filter.Comment)
                   && (filter.DataOld == null || filter.DataOld.Trim() == string.Empty || filter.DataOld.Trim() == "%" || (filter.DataOld.EndsWith("%") && filter.DataOld.StartsWith("%") && (o.DataOld.Contains(filter.DataOld.Replace("%", "")))) || (filter.DataOld.EndsWith("%") && o.DataOld.StartsWith(filter.DataOld.Replace("%", ""))) || (filter.DataOld.StartsWith("%") && o.DataOld.EndsWith(filter.DataOld.Replace("%", ""))) || o.DataOld == filter.DataOld)
                   && (filter.DataPreOperation == null || filter.DataPreOperation.Trim() == string.Empty || filter.DataPreOperation.Trim() == "%" || (filter.DataPreOperation.EndsWith("%") && filter.DataPreOperation.StartsWith("%") && (o.DataPreOperation.Contains(filter.DataPreOperation.Replace("%", "")))) || (filter.DataPreOperation.EndsWith("%") && o.DataPreOperation.StartsWith(filter.DataPreOperation.Replace("%", ""))) || (filter.DataPreOperation.StartsWith("%") && o.DataPreOperation.EndsWith(filter.DataPreOperation.Replace("%", ""))) || o.DataPreOperation == filter.DataPreOperation)
                   && (filter.DataPostOperation == null || filter.DataPostOperation.Trim() == string.Empty || filter.DataPostOperation.Trim() == "%" || (filter.DataPostOperation.EndsWith("%") && filter.DataPostOperation.StartsWith("%") && (o.DataPostOperation.Contains(filter.DataPostOperation.Replace("%", "")))) || (filter.DataPostOperation.EndsWith("%") && o.DataPostOperation.StartsWith(filter.DataPostOperation.Replace("%", ""))) || (filter.DataPostOperation.StartsWith("%") && o.DataPostOperation.EndsWith(filter.DataPostOperation.Replace("%", ""))) || o.DataPostOperation == filter.DataPostOperation)
                   && (filter.StartDate == null || filter.StartDate == DateTime.MinValue || o.StartDate >= filter.StartDate) && (filter.StartDate_To == null || filter.StartDate_To == DateTime.MinValue || o.StartDate <= filter.StartDate_To)
                   && (filter.EndDate == null || filter.EndDate == DateTime.MinValue || o.EndDate >= filter.EndDate) && (filter.EndDate_To == null || filter.EndDate_To == DateTime.MinValue || o.EndDate <= filter.EndDate_To)
                   && (filter.EndDateIsNull == null || filter.EndDateIsNull == true || o.EndDate != null) && (filter.EndDateIsNull == null || filter.EndDateIsNull == false || o.EndDate == null)
                   && (filter.EnableViewLog == null || o.EnableViewLog == filter.EnableViewLog)
                   && (filter.ApplicationName == null || filter.ApplicationName.Trim() == string.Empty || filter.ApplicationName.Trim() == "%" || (filter.ApplicationName.EndsWith("%") && filter.ApplicationName.StartsWith("%") && (o.ApplicationName.Contains(filter.ApplicationName.Replace("%", "")))) || (filter.ApplicationName.EndsWith("%") && o.ApplicationName.StartsWith(filter.ApplicationName.Replace("%", ""))) || (filter.ApplicationName.StartsWith("%") && o.ApplicationName.EndsWith(filter.ApplicationName.Replace("%", ""))) || o.ApplicationName == filter.ApplicationName)
                   && (filter.FormPath == null || filter.FormPath.Trim() == string.Empty || filter.FormPath.Trim() == "%" || (filter.FormPath.EndsWith("%") && filter.FormPath.StartsWith("%") && (o.FormPath.Contains(filter.FormPath.Replace("%", "")))) || (filter.FormPath.EndsWith("%") && o.FormPath.StartsWith(filter.FormPath.Replace("%", ""))) || (filter.FormPath.StartsWith("%") && o.FormPath.EndsWith(filter.FormPath.Replace("%", ""))) || o.FormPath == filter.FormPath)
                   && (filter.FormName == null || filter.FormName.Trim() == string.Empty || filter.FormName.Trim() == "%" || (filter.FormName.EndsWith("%") && filter.FormName.StartsWith("%") && (o.FormName.Contains(filter.FormName.Replace("%", "")))) || (filter.FormName.EndsWith("%") && o.FormName.StartsWith(filter.FormName.Replace("%", ""))) || (filter.FormName.StartsWith("%") && o.FormName.EndsWith(filter.FormName.Replace("%", ""))) || o.FormName == filter.FormName)
                   && (filter.UserControlName == null || filter.UserControlName.Trim() == string.Empty || filter.UserControlName.Trim() == "%" || (filter.UserControlName.EndsWith("%") && filter.UserControlName.StartsWith("%") && (o.UserControlName.Contains(filter.UserControlName.Replace("%", "")))) || (filter.UserControlName.EndsWith("%") && o.UserControlName.StartsWith(filter.UserControlName.Replace("%", ""))) || (filter.UserControlName.StartsWith("%") && o.UserControlName.EndsWith(filter.UserControlName.Replace("%", ""))) || o.UserControlName == filter.UserControlName)
                   && (filter.UserControlPath == null || filter.UserControlPath.Trim() == string.Empty || filter.UserControlPath.Trim() == "%" || (filter.UserControlPath.EndsWith("%") && filter.UserControlPath.StartsWith("%") && (o.UserControlPath.Contains(filter.UserControlPath.Replace("%", "")))) || (filter.UserControlPath.EndsWith("%") && o.UserControlPath.StartsWith(filter.UserControlPath.Replace("%", ""))) || (filter.UserControlPath.StartsWith("%") && o.UserControlPath.EndsWith(filter.UserControlPath.Replace("%", ""))) || o.UserControlPath == filter.UserControlPath)
                   && (filter.SessionId == null || filter.SessionId.Trim() == string.Empty || filter.SessionId.Trim() == "%" || (from s in this.Context.AuditSessions where (filter.SessionId.EndsWith("%") && filter.SessionId.StartsWith("%") && (s.SessionId.Contains(filter.SessionId.Replace("%", "")))) || (filter.SessionId.EndsWith("%") && s.SessionId.StartsWith(filter.SessionId.Replace("%", ""))) || (filter.SessionId.StartsWith("%") && s.SessionId.EndsWith(filter.SessionId.Replace("%", ""))) || s.SessionId == filter.SessionId select s.IdAuditSession).Contains(o.IdAuditSession))

                   select o
                   ).AsQueryable();
                //Matias 20170309 - Ticket #COMPAUDIT Comprimir Auditoria
                //).Take(3000).AsQueryable();
                //FinMatias 20170309 - Ticket #COMPAUDIT - Comprimir Auditoria
       }

    }
}

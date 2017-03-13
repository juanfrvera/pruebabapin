using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Ingematica.Librerias.Helpers;
using System.Transactions;
using System.Xml.Serialization;
using System.IO;
using System.Security.Principal;
using System.Xml;
using System.Globalization;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.Data;
using System.Collections;

namespace Service
{
    public abstract class ViewService<TEntity, TFilter, TResult, TIdType> : IViewService<TEntity, TFilter, TResult, TIdType>
        where TEntity : class
        where TFilter : Filter, new()
        where TResult : IResult<TIdType>, new()
        where TIdType : IComparable
    {
        protected abstract IViewBusiness<TEntity, TFilter, TResult, TIdType> ViewBusiness { get; }
        protected void ManageException(Exception exception)
        {
            //throw exception;
            if (exception.Message.Length > 50)
                throw new Exception(exception.Message);
            else
                ExceptionPolicy.HandleException(exception, "Service Policy");
        }

        #region Gets
        public virtual TEntity GetByEntity(TEntity entity)
        {
            try
            {
                return ViewBusiness.GetByEntity(entity);
            }
            catch (Exception exception)
            {
                ManageException(exception);
                return null;
            }
        }
        public virtual ListPaged<TEntity> GetList()
        {
            try
            {
                return ViewBusiness.GetList();
            }
            catch (Exception exception)
            {
                ManageException(exception);
                return null;
            }
        }
        public virtual TIdType GetId(TEntity entity)
        {
            try
            {
                return ViewBusiness.GetId(entity);
            }
            catch (Exception exception)
            {
                ManageException(exception);
                return default(TIdType);
            }
        }
        public virtual TEntity GetById(TIdType id)
        {
            try
            {
                return ViewBusiness.GetById(id);
            }
            catch (Exception exception)
            {
                ManageException(exception);
                return null;
            }
        }
        public virtual List<TEntity> GetByIds(TIdType[] ids)
        {
            try
            {
                return ViewBusiness.GetByIds(ids);
            }
            catch (Exception exception)
            {
                ManageException(exception);
                return null;
            }
        }
        public virtual TEntity FirstOrDefault(TFilter filter)
        {
            try
            {
                return ViewBusiness.FirstOrDefault(filter);
            }
            catch (Exception exception)
            {
                ManageException(exception);
                return null;
            }
        }
        public virtual TEntity FirstOrDefaultUsingResult(TFilter filter)
        {
            try
            {
                return ViewBusiness.FirstOrDefaultUsingResult(filter);
            }
            catch (Exception exception)
            {
                ManageException(exception);
                return null;
            }
        }
        public virtual TResult FirstOrDefaultResult(TFilter filter)
        {
            try
            {
                return ViewBusiness.FirstOrDefaultResult(filter);
            }
            catch (Exception exception)
            {
                ManageException(exception);
                return default(TResult);
            }
        }
        public virtual ListPaged<TEntity> GetList(TFilter filter)
        {
            try
            {
                return ViewBusiness.GetList(filter);
            }
            catch (Exception exception)
            {
                ManageException(exception);
                return null;
            }
        }
        public virtual ListPaged<TResult> GetResult()
        {
            try
            {
                return ViewBusiness.GetResult();
            }
            catch (Exception exception)
            {
                ManageException(exception);
                return null;
            }
        }
        public virtual ListPaged<TResult> GetResult(TFilter filter)
        {
            try
            {
                return ViewBusiness.GetResult(filter);
            }
            catch (Exception exception)
            {
                ManageException(exception);
                return null;
            }
        }
        public virtual ListPaged<SimpleResult<TIdType>> GetSimpleList(TFilter filter)
        {
            try
            {
                return ViewBusiness.GetSimpleList(filter);
            }
            catch (Exception exception)
            {
                ManageException(exception);
                return null;
            }
        }
        public virtual DataTable GetFromStoreProcedure(int idCommandName, TFilter filter)
        {
            return ViewBusiness.GetFromStoreProcedure(idCommandName, filter);
        }
        public virtual DataTable GetFromStoreProcedure(string commandText, TFilter filter)
        {
            return ViewBusiness.GetFromStoreProcedure(commandText, filter);
        }
        public virtual DataTable GetFromStoreProcedure(string commandText)
        {
            return ViewBusiness.GetFromStoreProcedure(commandText);
        }
        public virtual void ExecuteStoreProcedure(int idCommandName, TFilter filter)
        {
            SistemaCommand sistemaCommand = SistemaCommandBusiness.Current.GetById(idCommandName);
            ViewBusiness.ExecuteStoreProcedure(sistemaCommand.CommandText, filter);
        }
        public virtual void ExecuteStoreProcedure(string commandText, TFilter filter)
        {
            ViewBusiness.ExecuteStoreProcedure(commandText, filter);
        }
        public virtual void ExecuteStoreProcedure(string commandText)
        {
            ViewBusiness.ExecuteStoreProcedure(commandText);
        }

        #region Report
        public virtual ReportInfo GetReport(string reporteCodigo, TIdType id)
        {
            return ViewBusiness.GetReport(reporteCodigo, id);
        }
        public virtual ReportInfo GetReport(int idReporte, TIdType id)
        {
            return ViewBusiness.GetReport(idReporte, id);
        }
        public virtual ReportInfo GetReport(SistemaReporte reporte, TIdType id)
        {
            return ViewBusiness.GetReport(reporte, id);
        }
        public virtual ReportInfo GetReport(string reporteCodigo, TFilter filter)
        {
            return ViewBusiness.GetReport(reporteCodigo, filter);
        }
        public virtual ReportInfo GetReport(int idReporte, TFilter filter)
        {
            return ViewBusiness.GetReport(idReporte, filter);
        }
        public virtual ReportInfo GetReport(SistemaReporte reporte, TFilter filter)
        {
            return ViewBusiness.GetReport(reporte, filter);
        }

        public virtual void SaveHistoryReport(string reporteCodigo, ReportHistoryInfo info, TIdType id, IContextUser contextUser)
        {
            ViewBusiness.SaveHistoryReport(reporteCodigo, info, id, contextUser);
        }
        public virtual void SaveHistoryReport(int idReporte, ReportHistoryInfo info, TIdType id, IContextUser contextUser)
        {
            ViewBusiness.SaveHistoryReport(idReporte, info, id, contextUser);
        }
        public virtual void SaveHistoryReport(SistemaReporte reporte, ReportHistoryInfo info, TIdType id, IContextUser contextUser)
        {
            ViewBusiness.SaveHistoryReport(reporte, info, id, contextUser);
        }
        public virtual void SaveHistoryReport(string reporteCodigo, ReportHistoryInfo info, TFilter filter, IContextUser contextUser)
        {
            ViewBusiness.SaveHistoryReport(reporteCodigo, info, filter, contextUser);
        }
        public virtual void SaveHistoryReport(int idReporte, ReportHistoryInfo info, TFilter filter, IContextUser contextUser)
        {
            ViewBusiness.SaveHistoryReport(idReporte, info, filter, contextUser);
        }
        public virtual void SaveHistoryReport(SistemaReporte reporte, ReportHistoryInfo info, TFilter filter, IContextUser contextUser)
        {
            ViewBusiness.SaveHistoryReport(reporte, info, filter, contextUser);
        }
        public virtual ReportInfo GetHistoryReport(int idReporteHistorico)
        {
            return ViewBusiness.GetHistoryReport(idReporteHistorico);
        }
        public virtual ReportInfo GetHistoryReport(SistemaReporteHistorico reporteHistorico)
        {
            return ViewBusiness.GetHistoryReport(reporteHistorico);
        }
        #endregion

        #region Count
        public int Count()
        {
            try
            {
                return ViewBusiness.Count();
            }
            catch (Exception exception)
            {
                ManageException(exception);
                return 0;
            }
        }
        public int Count(TFilter filter)
        {
            try
            {
                return ViewBusiness.Count(filter);
            }
            catch (Exception exception)
            {
                ManageException(exception);
                return 0;
            }
        }
        public int CountResult()
        {
            try
            {
                return ViewBusiness.CountResult();
            }
            catch (Exception exception)
            {
                ManageException(exception);
                return 0;
            }
        }
        public int CountResult(TFilter filter)
        {
            try
            {
                return ViewBusiness.CountResult(filter);
            }
            catch (Exception exception)
            {
                ManageException(exception);
                return 0;
            }
        }
        #endregion
        #endregion
    }



    public abstract class EntityService<TEntity, TFilter, TResult, TIdType> : ViewService<TEntity, TFilter, TResult, TIdType>, IEntityService<TEntity, TFilter, TResult, TIdType>
        where TEntity : class, new()
        where TFilter : Filter, new()
        where TResult : IResult<TIdType>, new()
        where TIdType : IComparable
    {
        public virtual EntityServiceBehaviour Behaviour { get { return new EntityServiceBehaviour(); } }

        protected abstract IEntityBusiness<TEntity, TFilter, TResult, TIdType> EntityBusiness { get; }
        protected override IViewBusiness<TEntity, TFilter, TResult, TIdType> ViewBusiness
        {
            get { return EntityBusiness; }
        }
        public IObjectService GetObjectService()
        {
            return new ObjectWrapperService<TEntity, TFilter, TResult, TIdType>(this);
        }

        #region Audit
        //Matias 20170306 - Ticket #COMPAUDIT - Comprimir auditoria
        private string CompressString(string texto)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(texto);
            var memoryStream = new MemoryStream();
            using (var gZipStream = new System.IO.Compression.GZipStream(memoryStream, System.IO.Compression.CompressionMode.Compress, true))
            {
                gZipStream.Write(buffer, 0, buffer.Length);
            }

            memoryStream.Position = 0;

            var compressedData = new byte[memoryStream.Length];
            memoryStream.Read(compressedData, 0, compressedData.Length);

            var gZipBuffer = new byte[compressedData.Length + 4];
            Buffer.BlockCopy(compressedData, 0, gZipBuffer, 4, compressedData.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gZipBuffer, 0, 4);

            return Convert.ToBase64String(gZipBuffer);
        }
        private string DecompressString(string compressedText)
        {
            byte[] gZipBuffer = Convert.FromBase64String(compressedText);
            using (var memoryStream = new MemoryStream())
            {
                int dataLength = BitConverter.ToInt32(gZipBuffer, 0);
                memoryStream.Write(gZipBuffer, 4, gZipBuffer.Length - 4);

                var buffer = new byte[dataLength];

                memoryStream.Position = 0;
                using (var gZipStream = new System.IO.Compression.GZipStream(memoryStream, System.IO.Compression.CompressionMode.Decompress))
                {
                    gZipStream.Read(buffer, 0, buffer.Length);
                }

                return Encoding.UTF8.GetString(buffer);
            }
        }
        //FinMatias 20170306 - Ticket #COMPAUDIT - Comprimir auditoria

        protected void Audit(DateTime startDate, string pre, TEntity post, string actionName, IContextUser contextUser, Hashtable args)
        {
            AuditOperation audit = AuditOperationService.Current.GetNew();
            //Matias 20170306 - Ticket #COMPAUDIT - Comprimir auditoria
            //audit.DataPreOperation = pre;
            //audit.DataPostOperation = this.Serialize(post);
            audit.DataPreOperation = null;
            audit.DataPostOperation = CompressString(this.Serialize(post));
            //FinMatias 20170306 - Ticket #COMPAUDIT - Comprimir auditoria
            InfoEntity info = GetInfoEntity(post);
            audit.EntityName = info.EntityName;
            audit.EntityBaseName = info.EntityBaseName;
            audit.TypeName = info.TypeName;
            audit.EntityId = info.EntityId;
            audit.EntityKey = info.EntityKey;
            audit.StatusName = info.StatusName;
            audit.Info = info.Info;
            audit.EnableViewLog = info.EnableViewLog;

            audit.Service = this.ServiceName;
            audit.IdAuditSession = contextUser.AuditSession.IdAuditSession;
            audit.UserName = contextUser.User.NombreUsuario;
            audit.Operation = actionName;
            audit.StartDate = startDate;
            audit.EndDate = DateTime.Now;

            audit.ApplicationName = contextUser.FormContext.ApplicationName;
            audit.FormName = contextUser.FormContext.FromName;
            audit.FormPath = contextUser.FormContext.FromPath;
            audit.UserControlName = contextUser.FormContext.UserControlName;
            audit.UserControlPath = contextUser.FormContext.UserControlPath;

            SolutionContext.Current.AuditManager.Save(audit);
        }
        public virtual TEntity GetLog(int logId)
        {
            TEntity entity = null;
            AuditOperation audit = AuditOperationService.Current.GetById(logId);
            if (audit.EntityName != this.GetEntityName()) return entity;
            try
            {
                //Matias 20170306 - Ticket #COMPAUDIT - Comprimir auditoria
                //entity = this.Deserialize(audit.DataPostOperation);
                entity = this.Deserialize(DecompressString(audit.DataPostOperation));
                //Matias 20170306 - Ticket #COMPAUDIT - Comprimir auditoria
            }
            catch { }
            return entity;
        }
        #endregion
        #region Gets
        public virtual string ServiceName { get { return this.GetType().Name; } }
        public virtual string GetEntityName()
        {
            return EntityBusiness.GetEntityName();
        }
        public virtual InfoEntity GetInfoEntity(TEntity entity)
        {
            return EntityBusiness.GetInfoEntity(entity);
        }
        public virtual bool IsNew(TEntity entity)
        {
            return EntityBusiness.IsNew(entity);
        }
        public virtual TEntity GetNew()
        {
            return EntityBusiness.GetNew();
        }
        public virtual TEntity GetNew(TResult example)
        {
            return EntityBusiness.GetNew(example);
        }
        public virtual List<TResult> GetResultFromList(TFilter filter)
        {
            return EntityBusiness.GetResultFromList(filter);
        }
        #endregion
        #region Actions
        #region Quick access
        public virtual void Add(TEntity entity, IContextUser contextUser)
        {
            Execute(entity, ActionConfig.CREATE, contextUser);
        }
        public virtual void Add(List<TEntity> entities, IContextUser contextUser)
        {
            Execute(entities, ActionConfig.CREATE, contextUser);
        }
        public virtual void Update(TEntity entity, IContextUser contextUser)
        {
            Execute(entity, ActionConfig.UPDATE, contextUser);
        }
        public virtual void Update(List<TEntity> entities, IContextUser contextUser)
        {
            Execute(entities, ActionConfig.UPDATE, contextUser);
        }
        public virtual void Save(TEntity entity, IContextUser contextUser)
        {
            if (EntityBusiness.IsNew(entity)) Add(entity, contextUser);
            else Update(entity, contextUser);
        }
        public virtual void Save(List<TEntity> entities, IContextUser contextUser)
        {
            Execute(entities, ActionConfig.SAVE, contextUser);
        }
        public virtual TEntity Copy(TEntity entity, IContextUser contextUser)
        {
            return Execute(entity, ActionConfig.COPY, contextUser) as TEntity;
        }
        public virtual TEntity Copy(TIdType id, IContextUser contextUser)
        {
            return Execute(id, ActionConfig.COPY, contextUser) as TEntity;
        }

        #region CopyAndSave
        public virtual TIdType CopyAndSave(TIdType id, string rename, IContextUser contextUser)
        {
            return EntityBusiness.CopyAndSave(id, rename, contextUser);
        }
        public virtual TIdType CopyAndSave(TIdType id, IContextUser contextUser)
        {
            return EntityBusiness.CopyAndSave(id, contextUser);
        }
        public virtual TIdType CopyAndSave(TEntity entity, string rename, IContextUser contextUser)
        {
            return EntityBusiness.CopyAndSave(entity, rename, contextUser);
        }
        public virtual TIdType CopyAndSave(TEntity entity, IContextUser contextUser)
        {
            return EntityBusiness.CopyAndSave(entity, contextUser);
        }
        public virtual TIdType[] CopiesAndSave(List<TEntity> entities, IContextUser contextUser)
        {
            return EntityBusiness.CopiesAndSave(entities, contextUser);
        }
        public virtual TIdType[] CopiesAndSave(TFilter filter, IContextUser contextUser)
        {
            return EntityBusiness.CopiesAndSave(filter, contextUser);
        }
        public virtual TIdType[] CopiesAndSave(TIdType[] ids, IContextUser contextUser)
        {
            return EntityBusiness.CopiesAndSave(ids, contextUser);
        }
        public virtual TIdType[] CopiesAndSave(List<TEntity> entities, string prefix, IContextUser contextUser)
        {
            return EntityBusiness.CopiesAndSave(entities, prefix, contextUser);
        }
        public virtual TIdType[] CopiesAndSave(TFilter filter, string prefix, IContextUser contextUser)
        {
            return EntityBusiness.CopiesAndSave(filter, prefix, contextUser);
        }
        public virtual TIdType[] CopiesAndSave(TIdType[] ids, string prefix, IContextUser contextUser)
        {
            return EntityBusiness.CopiesAndSave(ids, prefix, contextUser);
        }
        #endregion

        public virtual List<TEntity> Copies(List<TEntity> entities, IContextUser contextUser)
        {
            return Execute(entities, ActionConfig.COPY, contextUser) as ListPaged<TEntity>;
        }
        public virtual List<TEntity> Copies(TIdType[] ids, IContextUser contextUser)
        {
            return Execute(ids, ActionConfig.COPY, contextUser) as ListPaged<TEntity>;
        }
        public virtual List<TEntity> Copies(TFilter filter, IContextUser contextUser)
        {
            return Execute(filter, ActionConfig.COPY, contextUser) as ListPaged<TEntity>;
        }
        public virtual void Delete(TEntity entity, IContextUser contextUser)
        {
            Execute(entity, ActionConfig.DELETE, contextUser);
        }
        public virtual void Delete(List<TEntity> entities, IContextUser contextUser)
        {
            Execute(entities, ActionConfig.DELETE, contextUser);
        }
        public virtual void Delete(TIdType id, IContextUser contextUser)
        {
            Execute(id, ActionConfig.DELETE, contextUser);
        }
        public virtual void Delete(TIdType[] ids, IContextUser contextUser)
        {
            Execute(ids, ActionConfig.DELETE, contextUser);
        }
        public virtual void Delete(TFilter filter, IContextUser contextUser)
        {
            Execute(filter, ActionConfig.DELETE, contextUser);
        }
        #endregion
        #region Can
        public bool Can(TIdType id, ActionEnum actionEnum, IContextUser contextUser)
        {
            return Can(id, ActionConfig.GetConst(actionEnum), contextUser, null);
        }
        public bool Can(TIdType id, ActionEnum actionEnum, IContextUser contextUser, Hashtable args)
        {
            return Can(id, ActionConfig.GetConst(actionEnum), contextUser, args);
        }
        public virtual bool Can(TIdType id, string actionName, IContextUser contextUser)
        {
            return EntityBusiness.Can(id, actionName, contextUser, null);
        }
        public virtual bool Can(TIdType id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return EntityBusiness.Can(id, actionName, contextUser, args);
        }
        public bool Can(TEntity entity, ActionEnum actionEnum, IContextUser contextUser)
        {
            return Can(entity, ActionConfig.GetConst(actionEnum), contextUser, null);
        }

        //public bool Can(TEntity entity, ActionEnum actionEnum, IContextUser contextUser)
        //{
        //    return Can(entity, ActionConfig.GetConst(actionEnum), contextUser);
        //}
        public bool Can(TEntity entity, ActionEnum actionEnum, IContextUser contextUser, Hashtable args)
        {
            return Can(entity, ActionConfig.GetConst(actionEnum), contextUser, args);
        }

        public virtual bool Can(TEntity entity, string actionName, IContextUser contextUser)
        {
            return EntityBusiness.Can(entity, actionName, contextUser, null);
        }
        public virtual bool Can(TEntity entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            return EntityBusiness.Can(entity, actionName, contextUser, args);
        }

        public bool Can(TResult result, ActionEnum actionEnum, IContextUser contextUser)
        {
            return Can(result, ActionConfig.GetConst(actionEnum), contextUser);
        }
        public bool Can(TResult result, ActionEnum actionEnum, IContextUser contextUser, Hashtable args)
        {
            return Can(result, ActionConfig.GetConst(actionEnum), contextUser, args);
        }

        public virtual bool Can(TResult result, string actionName, IContextUser contextUser)
        {
            return EntityBusiness.Can(result, actionName, contextUser, null);
        }
        public virtual bool Can(TResult result, string actionName, IContextUser contextUser, Hashtable args)
        {
            return EntityBusiness.Can(result, actionName, contextUser, args);
        }

        public bool Can(List<TEntity> entities, ActionEnum actionEnum, IContextUser contextUser)
        {
            return Can(entities, ActionConfig.GetConst(actionEnum), contextUser);
        }
        public bool Can(List<TEntity> entities, ActionEnum actionEnum, IContextUser contextUser, Hashtable args)
        {
            return Can(entities, ActionConfig.GetConst(actionEnum), contextUser, args);
        }

        public virtual bool Can(List<TEntity> entities, string actionName, IContextUser contextUser)
        {
            foreach (TEntity entity in entities)
                if (!EntityBusiness.Can(entity, actionName, contextUser, null)) return false;
            return true;
        }
        public virtual bool Can(List<TEntity> entities, string actionName, IContextUser contextUser, Hashtable args)
        {
            foreach (TEntity entity in entities)
                if (!EntityBusiness.Can(entity, actionName, contextUser, args)) return false;
            return true;
        }
        #endregion
        #region Execute
        public object Execute(TEntity entity, ActionEnum actionEnum, IContextUser contextUser)
        {
            return Execute(entity, ActionConfig.GetConst(actionEnum), contextUser, null);
        }
        public object Execute(TEntity entity, ActionEnum actionEnum, IContextUser contextUser, Hashtable args)
        {
            return Execute(entity, ActionConfig.GetConst(actionEnum), contextUser, args);
        }
        public virtual object Execute(TEntity entity, string actionName, IContextUser contextUser)
        {
            return Execute(entity, actionName, contextUser, null);
        }
        public virtual object Execute(TEntity entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            object Return = null;
            DateTime startDate = DateTime.Now;
            //TEntity pre = entity;
            //string pre = null;
            try
            {
                EntityBusiness.Validate(entity, actionName, contextUser, args);

                #region ConfigTransactionConTimeout
                //Matias 20170306 - Ticket #COMPAUDIT
                //TransactionOptions options = new TransactionOptions();
                //options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                //options.Timeout = new System.TimeSpan(1, 00, 0); //TransactionManager.DefaultTimeout;
                //using(TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, options))
                //FinMatias 20170306 - Ticket #COMPAUDIT    
                #endregion

                using (TransactionScope ts = TransactionFactory.Create())
                {
                    PreExecuteAction(entity, actionName, contextUser, args);
                    switch (actionName)
                    {
                        case ActionConfig.CREATE:
                            EntityBusiness.Add(entity, contextUser);
                            break;
                        case ActionConfig.COPY:
                            Return = EntityBusiness.Copy(entity, contextUser);
                            break;
                        case ActionConfig.UPDATE:
                            EntityBusiness.Update(entity, contextUser);
                            break;
                        case ActionConfig.DELETE:
                            EntityBusiness.Delete(entity, contextUser);
                            break;
                        case ActionConfig.SAVE:
                            EntityBusiness.Save(entity, contextUser);
                            break;
                        default:
                            Return = ExecuteAction(entity, actionName, contextUser, args);
                            break;
                    }
                    PosExecuteAction(entity, actionName, contextUser, args);
                    //Matias 20131206 - Tarea 90
                    // Original ==> if (Behaviour.Audit) Audit(startDate, pre, entity, actionName, contextUser, args);
                    if ((Behaviour.Audit) && (SolutionContext.Current.ParameterManager.GetBooleanValue("ACTIVAR_AUDITORIA")))
                        Audit(startDate, Serialize(entity), entity, actionName, contextUser, args);
                    //FinMatias 20131206 - Tarea 90
                    ts.Complete();
                }
            }
            catch (Exception exception)
            {
                ManageException(exception);
                return null;
            }
            return Return;
        }
        protected virtual object ExecuteAction(TEntity entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            return null;
        }
        protected virtual void PreExecuteAction(TEntity entity, string actionName, IContextUser contextUser, Hashtable args) { }
        protected virtual void PosExecuteAction(TEntity entity, string actionName, IContextUser contextUser, Hashtable args) { }

        public object Execute(List<TEntity> entities, ActionEnum actionEnum, IContextUser contextUser)
        {
            return Execute(entities, ActionConfig.GetConst(actionEnum), contextUser, null);
        }
        public object Execute(List<TEntity> entities, ActionEnum actionEnum, IContextUser contextUser, Hashtable args)
        {
            return Execute(entities, ActionConfig.GetConst(actionEnum), contextUser, args);
        }
        public object Execute(List<TEntity> entities, string actionName, IContextUser contextUser)
        {
            return Execute(entities, actionName, contextUser, null);
        }
        public virtual object Execute(List<TEntity> entities, string actionName, IContextUser contextUser, Hashtable args)
        {
            object Return = null;
            try
            {
                foreach (TEntity entity in entities)
                    EntityBusiness.Validate(entity, actionName, contextUser, args);

                using (TransactionScope ts = TransactionFactory.Create())
                {
                    PreExecuteAction(entities, actionName, contextUser, args);
                    switch (actionName)
                    {
                        case ActionConfig.CREATE:
                            EntityBusiness.Add(entities, contextUser);
                            break;
                        case ActionConfig.COPY:
                            Return = EntityBusiness.Copies(entities, contextUser);
                            break;
                        case ActionConfig.UPDATE:
                            EntityBusiness.Update(entities, contextUser);
                            break;
                        case ActionConfig.DELETE:
                            EntityBusiness.Delete(entities, contextUser);
                            break;
                        case ActionConfig.SAVE:
                            EntityBusiness.Save(entities, contextUser);
                            break;
                        default:
                            Return = ExecuteAction(entities, actionName, contextUser, args);
                            break;
                    }
                    PosExecuteAction(entities, actionName, contextUser, args);
                    ts.Complete();
                }
            }
            catch (Exception exception)
            {
                ManageException(exception);
                return null;
            }
            return Return;
        }
        protected virtual object ExecuteAction(List<TEntity> entities, string actionName, IContextUser contextUser, Hashtable args)
        {
            return null;
        }
        protected virtual void PreExecuteAction(List<TEntity> entities, string actionName, IContextUser contextUser, Hashtable args) { }
        protected virtual void PosExecuteAction(List<TEntity> entities, string actionName, IContextUser contextUser, Hashtable args) { }

        public object Execute(TIdType id, ActionEnum actionEnum, IContextUser contextUser)
        {
            return Execute(id, ActionConfig.GetConst(actionEnum), contextUser, null);
        }
        public object Execute(TIdType id, ActionEnum actionEnum, IContextUser contextUser, Hashtable args)
        {
            return Execute(id, ActionConfig.GetConst(actionEnum), contextUser, args);
        }
        public object Execute(TIdType id, string actionName, IContextUser contextUser)
        {
            return Execute(id, actionName, contextUser, null);
        }
        public virtual object Execute(TIdType id, string actionName, IContextUser contextUser, Hashtable args)
        {
            object Return = null;
            TEntity entity = null;
            DateTime startDate = DateTime.Now;
            try
            {
                entity = GetById(id);
                EntityBusiness.Validate(entity, actionName, contextUser, args);
                using (TransactionScope ts = TransactionFactory.Create())
                {
                    PreExecuteAction(id, actionName, contextUser, args);
                    switch (actionName)
                    {
                        case ActionConfig.COPY:
                            Return = EntityBusiness.Copy(id, contextUser);
                            break;
                        case ActionConfig.DELETE:
                            EntityBusiness.Delete(id, contextUser);
                            break;
                        default:
                            Return = ExecuteAction(id, actionName, contextUser, args);
                            break;
                    }
                    PosExecuteAction(id, actionName, contextUser, args);
                    if (Behaviour.Audit)
                    {
                        Audit(startDate, null, (actionName == ActionConfig.DELETE) ? entity : GetById(id), actionName, contextUser, args);
                    }
                    ts.Complete();
                }
            }
            catch (Exception exception)
            {
                ManageException(exception);
                return null;
            }
            return Return;
        }
        protected virtual object ExecuteAction(TIdType id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return null;
        }
        protected virtual void PreExecuteAction(TIdType id, string actionName, IContextUser contextUser, Hashtable args) { }
        protected virtual void PosExecuteAction(TIdType id, string actionName, IContextUser contextUser, Hashtable args) { }

        public object Execute(TIdType[] ids, ActionEnum actionEnum, IContextUser contextUser)
        {
            return Execute(ids, ActionConfig.GetConst(actionEnum), contextUser, null);
        }
        public object Execute(TIdType[] ids, ActionEnum actionEnum, IContextUser contextUser, Hashtable args)
        {
            return Execute(ids, ActionConfig.GetConst(actionEnum), contextUser, args);
        }
        public object Execute(TIdType[] ids, string actionName, IContextUser contextUser)
        {
            return Execute(ids, actionName, contextUser, null);
        }
        public virtual object Execute(TIdType[] ids, string actionName, IContextUser contextUser, Hashtable args)
        {
            object Return = null;
            try
            {
                foreach (TIdType id in ids)
                    EntityBusiness.Validate(GetById(id), actionName, contextUser, args);

                using (TransactionScope ts = TransactionFactory.Create())
                {
                    PreExecuteAction(ids, actionName, contextUser, args);
                    switch (actionName)
                    {
                        case ActionConfig.COPY:
                            Return = EntityBusiness.Copies(ids, contextUser);
                            break;
                        case ActionConfig.DELETE:
                            EntityBusiness.Delete(ids, contextUser);
                            break;
                        default:
                            Return = ExecuteAction(ids, actionName, contextUser, args);
                            break;
                    }
                    PosExecuteAction(ids, actionName, contextUser, args);
                    ts.Complete();
                }
            }
            catch (Exception exception)
            {
                ManageException(exception);
                return null;
            }
            return Return;
        }
        protected virtual object ExecuteAction(TIdType[] ids, string actionName, IContextUser contextUser, Hashtable args)
        {
            return null;
        }
        protected virtual void PreExecuteAction(TIdType[] ids, string actionName, IContextUser contextUser, Hashtable args) { }
        protected virtual void PosExecuteAction(TIdType[] ids, string actionName, IContextUser contextUser, Hashtable args) { }

        public object Execute(TFilter filter, ActionEnum actionEnum, IContextUser contextUser)
        {
            return Execute(filter, ActionConfig.GetConst(actionEnum), contextUser, null);
        }
        public object Execute(TFilter filter, ActionEnum actionEnum, IContextUser contextUser, Hashtable args)
        {
            return Execute(filter, ActionConfig.GetConst(actionEnum), contextUser, args);
        }
        public object Execute(TFilter filter, string actionName, IContextUser contextUser)
        {
            return Execute(filter, actionName, contextUser, null);
        }
        public virtual object Execute(TFilter filter, string actionName, IContextUser contextUser, Hashtable args)
        {
            object Return = null;
            try
            {
                using (TransactionScope ts = TransactionFactory.Create())
                {
                    PreExecuteAction(filter, actionName, contextUser, args);
                    switch (actionName)
                    {
                        case ActionConfig.COPY:
                            Return = EntityBusiness.Copies(filter, contextUser);
                            break;
                        case ActionConfig.DELETE:
                            EntityBusiness.Delete(filter, contextUser);
                            break;
                        default:
                            Return = ExecuteAction(filter, actionName, contextUser, args);
                            break;
                    }
                    PosExecuteAction(filter, actionName, contextUser, args);
                    ts.Complete();
                }
            }
            catch (Exception exception)
            {
                ManageException(exception);
                return null;
            }
            return Return;
        }
        protected virtual object ExecuteAction(TFilter filter, string actionName, IContextUser contextUser, Hashtable args)
        {
            return null;
        }
        protected virtual void PreExecuteAction(TFilter filter, string actionName, IContextUser contextUser, Hashtable args) { }
        protected virtual void PosExecuteAction(TFilter filter, string actionName, IContextUser contextUser, Hashtable args) { }

        #endregion
        #endregion
        #region Set
        public virtual void SetId(TEntity entity, TIdType id)
        {
            EntityBusiness.SetId(entity, id);
        }
        public virtual void Set(TEntity source, TEntity target)
        {
            EntityBusiness.Set(source, target);
        }
        public virtual void Set(TEntity source, TResult target)
        {
            EntityBusiness.Set(source, target);
        }
        public virtual void Set(TResult source, TEntity target)
        {
            EntityBusiness.Set(source, target);
        }
        public virtual void Set(TResult source, TResult target)
        {
            EntityBusiness.Set(source, target);
        }
        public virtual void Set(TEntity source, TEntity target, bool hadSetId)
        {
            EntityBusiness.Set(source, target, hadSetId);
        }
        public virtual void Set(TEntity source, TResult target, bool hadSetId)
        {
            EntityBusiness.Set(source, target, hadSetId);
        }
        public virtual void Set(TResult source, TEntity target, bool hadSetId)
        {
            EntityBusiness.Set(source, target, hadSetId);
        }
        public virtual void Set(TResult source, TResult target, bool hadSetId)
        {
            EntityBusiness.Set(source, target, hadSetId);
        }
        #endregion
        #region ToEntity
        public virtual TEntity ToEntity(TResult source, TIdType id)
        {
            return EntityBusiness.ToEntity(source, id);
        }
        public virtual TEntity ToEntity(TResult source)
        {
            return EntityBusiness.ToEntity(source);
        }
        #endregion
        #region ToResult
        public virtual TResult ToResult(TEntity source)
        {
            return EntityBusiness.ToResult(source);
        }
        public virtual List<TResult> ToResults(List<TEntity> source)
        {
            return EntityBusiness.ToResults(source);
        }
        public virtual ListPaged<TResult> ToResults(ListPaged<TEntity> source)
        {
            return EntityBusiness.ToResults(source);
        }
        #endregion
        #region Equals
        public virtual bool Equals(TEntity source, TEntity target)
        {
            return EntityBusiness.Equals(source, target);
        }
        public virtual bool Equals(TResult source, TEntity target)
        {
            return EntityBusiness.Equals(source, target);
        }
        public virtual bool Equals(TEntity source, TResult target)
        {
            return EntityBusiness.Equals(source, target);
        }
        public virtual bool Equals(TResult source, TResult target)
        {
            return EntityBusiness.Equals(source, target);
        }
        #endregion
        #region Serialization
        public virtual string Serialize(TEntity entity)
        {
            if (entity == null)
                entity = GetNew();
            SerializableEntity<TEntity> serializable = new SerializableEntity<TEntity>(entity);

            XmlSerializer serizer = new XmlSerializer(serializable.GetType());
            CultureInfo ci = new CultureInfo("es-AR");
            StringWriter sw = new StringWriter(ci);
            XmlWriter xmlWriter = XmlWriter.Create(sw);
            serizer.Serialize(xmlWriter, serializable);
            sw.Flush();
            string text = sw.GetStringBuilder().ToString();
            return text;
        }
        public virtual TEntity Deserialize(string text)
        {
            try
            {
                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                SerializableEntity<TEntity> serializable = new SerializableEntity<TEntity>();
                XmlSerializer serizer = new XmlSerializer(serializable.GetType());
                StringReader sr = new StringReader(text);
                XmlReader xr = XmlReader.Create(sr);
                serializable = serizer.Deserialize(xr) as SerializableEntity<TEntity>;
                System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
                return serializable.Entity;
            }
            catch { return null; }
        }
        #endregion
    }

    public abstract class EntityComposeService<TEntity, TFilter, TResult, TIdType> : EntityService<TEntity, TFilter, TResult, TIdType>
        where TEntity : class, new()
        where TFilter : Filter, new()
        where TResult : IResult<TIdType>, new()
        where TIdType : IComparable
    {
        public EntityComposeService()
        {

        }

        #region Serialization
        public override string Serialize(TEntity entity)
        {
            if (entity == null) entity = GetNew();
            XmlSerializer serizer = new XmlSerializer(typeof(TEntity));
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            serizer.Serialize(sw, entity);
            return sb.ToString();
        }
        public override TEntity Deserialize(string text)
        {
            try
            {
                XmlSerializer serizer = new XmlSerializer(typeof(TEntity));
                StringReader sr = new StringReader(text);
                return serizer.Deserialize(sr) as TEntity;
            }
            catch { return null; }
        }
        #endregion
    }

    public class ObjectWrapperService<TEntity, TFilter, TResult, TIdType> : IObjectService
        where TEntity : class, new()
        where TFilter : Filter, new()
        where TResult : IResult<TIdType>
        where TIdType : IComparable
    {
        public IEntityService<TEntity, TFilter, TResult, TIdType> Service { get; set; }

        public ObjectWrapperService(IEntityService<TEntity, TFilter, TResult, TIdType> service)
        {
            this.Service = service;
        }

        protected TIdType[] ConvertIds(object[] ids)
        {
            TIdType[] _ids = new TIdType[ids.Length];
            for (int i = 0, count = ids.Length; i < count; i++)
                _ids[i] = (TIdType)ids[i];
            return _ids;
        }
        protected List<TEntity> ConvertEntities(object[] entities)
        {
            List<TEntity> _entities = new List<TEntity>(entities.Length);
            for (int i = 0, count = entities.Length; i < count; i++)
                _entities[i] = entities[i] as TEntity;
            return _entities;
        }

        #region Gets
        public virtual bool IsNew(object entity)
        {
            return Service.IsNew(entity as TEntity);
        }
        public virtual object GetNew()
        {
            return Service.GetNew();
        }
        public virtual object GetByEntity(object entity)
        {
            return Service.GetByEntity(entity as TEntity);
        }
        public virtual object GetList()
        {
            return Service.GetList();
        }
        public virtual object GetId(object entity)
        {
            return Service.GetId(entity as TEntity);
        }
        public virtual object GetById(object id)
        {
            return Service.GetById((TIdType)id);
        }
        public virtual object GetByIds(object[] ids)
        {
            return Service.GetByIds(ConvertIds(ids));
        }
        public virtual object FirstOrDefault(object filter)
        {
            return Service.FirstOrDefault(filter as TFilter);
        }
        public virtual object GetList(object filter)
        {
            return Service.GetList(filter as TFilter);
        }
        public virtual object GetResult()
        {
            return Service.GetResult();
        }
        public virtual object GetResult(object filter)
        {
            return Service.GetResult(filter as TFilter);
        }
        #endregion
        #region Actions
        #region Quick access
        public virtual void Add(object entity, IContextUser contextUser)
        {
            Service.Execute(entity as TEntity, ActionConfig.CREATE, contextUser);
        }
        public virtual void Add(object[] entities, IContextUser contextUser)
        {
            Service.Execute(ConvertEntities(entities), ActionConfig.CREATE, contextUser);
        }
        public virtual void Update(object entity, IContextUser contextUser)
        {
            Service.Execute(entity as TEntity, ActionConfig.UPDATE, contextUser);
        }
        public virtual void Update(object[] entities, IContextUser contextUser)
        {
            Service.Execute(ConvertEntities(entities), ActionConfig.UPDATE, contextUser);
        }
        public virtual void Save(object entity, IContextUser contextUser)
        {
            Service.Execute(entity as TEntity, ActionConfig.SAVE, contextUser);
        }
        public virtual void Save(object[] entities, IContextUser contextUser)
        {
            Service.Execute(ConvertEntities(entities), ActionConfig.SAVE, contextUser);
        }
        public virtual object Copy(object entity, IContextUser contextUser)
        {
            return Service.Execute(entity as TEntity, ActionConfig.COPY, contextUser) as TEntity;
        }
        public virtual object CopyById(object id, IContextUser contextUser)
        {
            return Service.Execute((TIdType)id, ActionConfig.COPY, contextUser) as TEntity;
        }
        public virtual object Copies(object[] entities, IContextUser contextUser)
        {
            return Service.Execute(ConvertEntities(entities), ActionConfig.COPY, contextUser) as List<TEntity>;
        }
        public virtual object CopiesById(object[] ids, IContextUser contextUser)
        {
            return Service.Execute(ConvertIds(ids), ActionConfig.COPY, contextUser) as List<TEntity>;
        }
        public virtual object CopiesByFilter(object filter, IContextUser contextUser)
        {
            return Service.Execute(filter as TFilter, ActionConfig.COPY, contextUser) as List<TEntity>;
        }
        public virtual void Delete(object entity, IContextUser contextUser)
        {
            Service.Execute(entity as TEntity, ActionConfig.DELETE, contextUser);
        }
        public virtual void Delete(object[] entities, IContextUser contextUser)
        {
            Service.Execute(ConvertEntities(entities), ActionConfig.DELETE, contextUser);
        }
        public virtual void DeleteById(object id, IContextUser contextUser)
        {
            Service.Execute((TIdType)id, ActionConfig.DELETE, contextUser);
        }
        public virtual void DeleteById(object[] ids, IContextUser contextUser)
        {
            Service.Execute(ConvertIds(ids), ActionConfig.DELETE, contextUser);
        }

        #endregion
        #region Can
        public bool Can(object entity, ActionEnum actionEnum, IContextUser contextUser, Hashtable args)
        {
            return Service.Can(entity as TEntity, actionEnum, contextUser, args);
        }
        public virtual bool Can(object entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Service.Can(entity as TEntity, actionName, contextUser, args);
        }
        public bool Can(object[] entities, ActionEnum actionEnum, IContextUser contextUser, Hashtable args)
        {
            return Service.Can(ConvertEntities(entities), actionEnum, contextUser, args);
        }
        public virtual bool Can(object[] entities, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Service.Can(ConvertEntities(entities), actionName, contextUser, args);
        }
        #endregion
        #region Execute
        public object Execute(object entity, ActionEnum actionEnum, IContextUser contextUser, Hashtable args)
        {
            return Service.Execute(entity as TEntity, actionEnum, contextUser, args);
        }
        public virtual object Execute(object entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Service.Execute(entity as TEntity, actionName, contextUser, args);
        }
        public object Execute(object[] entities, ActionEnum actionEnum, IContextUser contextUser, Hashtable args)
        {
            return Service.Execute(ConvertEntities(entities), actionEnum, contextUser, args);
        }
        public virtual object Execute(object[] entities, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Service.Execute(ConvertEntities(entities), actionName, contextUser, args);
        }
        public object ExecuteById(object id, ActionEnum actionEnum, IContextUser contextUser, Hashtable args)
        {
            return Service.Execute((TIdType)id, actionEnum, contextUser, args);
        }
        public virtual object ExecuteById(object id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Service.Execute((TIdType)id, actionName, contextUser, args);
        }
        public object ExecuteByIds(object[] ids, ActionEnum actionEnum, IContextUser contextUser, Hashtable args)
        {
            return Service.Execute(ConvertIds(ids), actionEnum, contextUser, args);
        }
        public virtual object ExecuteByIds(object[] ids, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Service.Execute(ConvertIds(ids), actionName, contextUser, args);
        }
        public object ExecuteByFilter(object filter, ActionEnum actionEnum, IContextUser contextUser, Hashtable args)
        {
            return Service.Execute(filter as TFilter, actionEnum, contextUser, args);
        }
        public virtual object ExecuteByFilter(object filter, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Service.Execute(filter as TFilter, actionName, contextUser, args);
        }
        #endregion
        #endregion
        #region Serialization
        public virtual string Serialize(object entity)
        {
            return Service.Serialize(entity as TEntity);
        }
        public virtual object Deserialize(string text)
        {
            return Service.Deserialize(text) as TEntity;
        }
        #endregion
    }
}


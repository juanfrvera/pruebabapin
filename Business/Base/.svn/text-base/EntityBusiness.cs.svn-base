using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using System.Data;
using System.Collections;

namespace Business
{
   

    public abstract class EntityBusiness<TEntity,TIdType> : IEntityBusiness<TEntity, TIdType>
        where TEntity : class,new()
        where TIdType : IComparable
    {
        #region Info
        public virtual string GetEntityName()
        {
            return typeof(TEntity).Name;
        }
        public virtual string GetEntityKey(TEntity entity)
        {
            return this.GetId(entity).ToString();
        }
        public virtual InfoEntity GetInfoEntity(TEntity entity)
        {
            InfoEntity info = new InfoEntity();
            info.EntityName = GetEntityName();
            info.EntityBaseName = GetEntityName();
            info.TypeName = GetEntityName();
            info.EntityId = this.GetId(entity).ToString();
            info.EntityKey = this.GetEntityKey(entity);
            info.StatusName = "";
            info.Info = "";
            info.EnableViewLog = true;
            return info;
        }
        public virtual string EntityName
        {
            get { return typeof(TEntity).Name; }
        }
        #endregion
        #region Get
        public virtual bool IsNew(TEntity entity)
        {
            return GetId(entity).CompareTo(default(TIdType))==0;
        }
        public virtual TEntity GetNew()
        {
            return new TEntity();
        }
        public abstract TIdType GetId(TEntity entity);
        public abstract TEntity GetById(TIdType id);
        public abstract List<TEntity> GetByIds(TIdType[] ids);
        public virtual TEntity GetByEntity(TEntity entity)
        {
            return GetById(GetId(entity));
        }
        public abstract ListPaged<TEntity> GetList();
        public abstract int Count();
        public abstract int CountResult();
        #endregion        
        #region Actions
        public abstract void Add(TEntity entity, IContextUser contextUser);
        public abstract void Add(List<TEntity> entities, IContextUser contextUser);
        public abstract void Update(TEntity entity, IContextUser contextUser);
        public abstract void Update(List<TEntity> entities, IContextUser contextUser);
        public virtual void Save(TEntity entity, IContextUser contextUser)
        {
            if (IsNew(entity)) Add(entity, contextUser);
            else Update(entity, contextUser);  
        }
        public virtual void Save(List<TEntity> entities, IContextUser contextUser)
        {
            foreach (TEntity entity in entities)
                Save(entity, contextUser);        
        }
        public abstract TEntity Copy(TEntity entity, IContextUser contextUser);
        public virtual List<TEntity> Copies(List<TEntity> entities, IContextUser contextUser)
        {
            List<TEntity> list = new List<TEntity>(entities.Count);
            foreach (TEntity entity in entities)
                list.Add(Copy(entity, contextUser));
            return list;
        }
        public virtual TEntity Copy(TIdType id, IContextUser contextUser)
        {
            return Copy(GetById(id), contextUser);
        }
        public virtual List<TEntity> Copies(TIdType[] ids, IContextUser contextUser)
        {
            List<TEntity> list = new List<TEntity>(ids.Length);
            foreach (TIdType id in ids)
                list.Add(Copy(id, contextUser));
            return list;
        }
        public abstract void Delete(TEntity entity, IContextUser contextUser);
        public abstract void Delete(List<TEntity> entities, IContextUser contextUser);
        public abstract void Delete(TIdType id, IContextUser contextUser);
        public abstract void Delete(TIdType[] ids, IContextUser contextUser);
        #endregion
        #region validations
        public virtual void Validate(TEntity entity, string actionName,IContextUser contextUser,Hashtable args)
        { 
            
        }
        public virtual bool Can(TEntity entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            switch (actionName)
            { 
                case ActionConfig.DELETE:
                    //if (!CanByRol(actionName)) return false;
                    return !IsNew(entity);
                case ActionConfig.COPY:
                    //if (!CanByRol(actionName)) return false;
                    return !IsNew(entity);                
            }            
            return true;
        }       
        #endregion
        public abstract void ReloadContext();       
    }



    public abstract class ViewBusiness<TEntity, TFilter, TResult, TIdType> : IViewBusiness<TEntity, TFilter, TResult, TIdType>
        where TEntity : class,new()
        where TFilter : Filter, new()
        where TResult : IResult<TIdType>,new()
        where TIdType : IComparable

    {
        protected abstract IViewData<TEntity, TFilter, TResult, TIdType> ViewData { get; }

        #region Managers
        protected string Translate(string key, IContextUser contextUser)
        {
            if (SolutionContext.Current.TextManager == null) return key;
            return SolutionContext.Current.TextManager.Translate(key, contextUser.User.Language_Code);
        }
        #endregion

        #region Gets
        public virtual TIdType GetId(TEntity entity)
        {
            return ViewData.GetId(entity);
        }
        public virtual TEntity GetById(TIdType id)
        {
            try
            {
                return ViewData.GetById(id);
            }
            catch (Exception exception)
            {
                ReloadContext();
                throw exception;
            }
        } 
        public virtual List<TEntity> GetByIds(TIdType[] ids)
        {
            return ViewData.GetByIds(ids);
        }
        public virtual TEntity GetByEntity(TEntity entity)
        {
            return GetById(GetId(entity));
        }
        public virtual ListPaged<TEntity> GetList()
        {
            try
            {
                return ViewData.GetList();
            }
            catch (Exception exception)
            {
                ReloadContext();
                throw exception;
            }
        }
        public virtual TEntity FirstOrDefault(TFilter filter)
        {
            try
            {
                return ViewData.FirstOrDefault(filter);
            }
            catch (Exception exception)
            {
                ReloadContext();
                throw exception;
            }
        }
        public virtual TEntity FirstOrDefaultUsingResult(TFilter filter)
        {
            try
            {
                TResult result = ViewData.FirstOrDefaultResult(filter);
                if (result == null) return null;
                return ToEntity(result);
            }
            catch (Exception exception)
            {
                ReloadContext();
                throw exception;
            }
        }
        public virtual TResult FirstOrDefaultResult(TFilter filter)
        {
            try
            {
                return ViewData.FirstOrDefaultResult(filter);
            }
            catch (Exception exception)
            {
                ReloadContext();
                throw exception;
            }
        }
        public virtual ListPaged<TEntity> GetList(TFilter filter)
        {
            try
            {
                return ViewData.GetList(filter);
            }
            catch (Exception exception)
            {
                ReloadContext();
                throw exception;
            }
        }
        public virtual ListPaged<TResult> GetResult()
        {
            return ViewData.GetResult(new TFilter());
        }
        public virtual ListPaged<TResult> GetResult(TFilter filter)
        {
            return ViewData.GetResult(filter);
        }
        public virtual ListPaged<SimpleResult<TIdType>> GetSimpleList(TFilter filter)
        {
            return ViewData.GetSimpleList(filter);
        }        
        public virtual DataTable GetFromStoreProcedure(int idCommandName, TFilter filter)
        {
            SistemaCommand  sistemaCommand=SistemaCommandBusiness.Current.GetById(idCommandName);
            return ViewData.GetFromStoreProcedure(sistemaCommand.CommandText, filter);
        }
        public virtual DataTable GetFromStoreProcedure(string commandText, TFilter filter)
        {
            return ViewData.GetFromStoreProcedure(commandText, filter);
        }
        public virtual DataTable GetFromStoreProcedure(string commandText)
        {
            return ViewData.GetFromStoreProcedure(commandText);
        }
        public virtual void  ExecuteStoreProcedure(int idCommandName, TFilter filter)
        {
            SistemaCommand sistemaCommand = SistemaCommandBusiness.Current.GetById(idCommandName);
            ViewData.ExecuteStoreProcedure(sistemaCommand.CommandText, filter);
        }
        public virtual void ExecuteStoreProcedure(string commandText, TFilter filter)
        {
            ViewData.ExecuteStoreProcedure(commandText, filter);
        }
        public virtual void ExecuteStoreProcedure(string commandText)
        {
            ViewData.ExecuteStoreProcedure(commandText);
        }

        #region Report 
        #region GetReport
        public ReportInfo GetReport(string reporteCodigo, TIdType id)
        {
            SistemaReporte reporte = SistemaReporteBusiness.Current.FirstOrDefault(new SistemaReporteFilter() {  Codigo = reporteCodigo });
            return GetReport(reporte, id);
        }
        public ReportInfo GetReport(int idReporte, TIdType id)
        {
            SistemaReporte reporte = SistemaReporteBusiness.Current.GetById(idReporte);
            return GetReport(reporte, id);
        }
        public virtual ReportInfo GetReport(SistemaReporte reporte, TIdType id)
        {
            throw new NotImplementedException();
        }
        
        public ReportInfo GetReport(string reporteCodigo, TFilter filter)
        {
            SistemaReporte reporte = SistemaReporteBusiness.Current.FirstOrDefault(new SistemaReporteFilter() { Codigo = reporteCodigo });
            return GetReport(reporte, filter);
        }
        public ReportInfo GetReport(int idReporte, TFilter filter)
        {
            SistemaReporte reporte = SistemaReporteBusiness.Current.GetById(idReporte);
            return GetReport(reporte, filter);
        }
        public virtual ReportInfo GetReport(SistemaReporte reporte, TFilter filter)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region SaveHistoryReport
        public void SaveHistoryReport(string reporteCodigo, ReportHistoryInfo info, TIdType id,IContextUser contextUser)
        {
            SistemaReporte reporte = SistemaReporteBusiness.Current.FirstOrDefault(new SistemaReporteFilter() { Codigo = reporteCodigo });
            SaveHistoryReport(reporte, info, id, contextUser);
        }
        public void SaveHistoryReport(int idReporte, ReportHistoryInfo info, TIdType id, IContextUser contextUser)
        {
            SistemaReporte reporte = SistemaReporteBusiness.Current.GetById(idReporte);
            SaveHistoryReport(reporte, info, id, contextUser);
        }
        public virtual void SaveHistoryReport(SistemaReporte reporte, ReportHistoryInfo info, TIdType id, IContextUser contextUser)
        {
            ReportInfo reportInfo =GetReport(reporte,id);
            if(reportInfo==null)return;
            SistemaReporteHistorico sistemaReporteHistorico = SistemaReporteHistoricoBusiness.Current.GetNew();
            sistemaReporteHistorico.Fecha = DateTime.Now;
            sistemaReporteHistorico.IdUsuario = contextUser.User.IdUsuario;
            sistemaReporteHistorico.EntityId = id.ToString();
            sistemaReporteHistorico.Comentarios = info.Comments;
            sistemaReporteHistorico.Data = DataHelper.SerializeObject<ReportInfo>(reportInfo);
            SistemaReporteHistoricoBusiness.Current.Add(sistemaReporteHistorico, contextUser);
        }

        public void SaveHistoryReport(string reporteCodigo, ReportHistoryInfo info, TFilter filter, IContextUser contextUser)
        {
            SistemaReporte reporte = SistemaReporteBusiness.Current.FirstOrDefault(new SistemaReporteFilter() { Codigo = reporteCodigo });
            SaveHistoryReport(reporte, info, filter, contextUser);
        }
        public void SaveHistoryReport(int idReporte, ReportHistoryInfo info, TFilter filter, IContextUser contextUser)
        {
            SistemaReporte reporte = SistemaReporteBusiness.Current.GetById(idReporte);
            SaveHistoryReport(reporte, info, filter, contextUser);
        }
        public virtual void SaveHistoryReport(SistemaReporte reporte, ReportHistoryInfo info, TFilter filter, IContextUser contextUser)
        {
            ReportInfo reportInfo = GetReport(reporte, filter);
            if (reportInfo == null) return;
            SistemaReporteHistorico sistemaReporteHistorico = SistemaReporteHistoricoBusiness.Current.GetNew();
            sistemaReporteHistorico.IdSistemaReporte = reporte.IdSistemaReporte;
            sistemaReporteHistorico.Fecha = DateTime.Now;
            sistemaReporteHistorico.IdUsuario = contextUser.User.IdUsuario;
            sistemaReporteHistorico.FilterData = DataHelper.SerializeObject<TFilter>(filter);
            sistemaReporteHistorico.Comentarios = info.Comments;
            sistemaReporteHistorico.Data = DataHelper.SerializeObject<ReportInfo>(reportInfo);
            SistemaReporteHistoricoBusiness.Current.Add(sistemaReporteHistorico, contextUser);
        }
        #endregion

        #region GetHistoryReport        
        public ReportInfo GetHistoryReport(int idReporteHistorico)
        {
            SistemaReporteHistorico reporteHistorico = SistemaReporteHistoricoBusiness.Current.GetById(idReporteHistorico);
            return GetHistoryReport(reporteHistorico);
        }
        public virtual ReportInfo GetHistoryReport(SistemaReporteHistorico reporteHistorico)
        {
            if (reporteHistorico == null) return null;
            string xml = reporteHistorico.Data.Substring(0,1)=="?"?reporteHistorico.Data.Substring(1,reporteHistorico.Data.Length-1):reporteHistorico.Data;
            return DataHelper.DeserializeObject<ReportInfo>(xml);
        }
        #endregion
        #endregion

        #region Count
        public virtual int Count()
        {
            return ViewData.Count();
        }
        public virtual int Count(TFilter filter)
        {
            return ViewData.Count(filter);
        }
        public virtual int CountResult()
        {
            return ViewData.CountResult();
        }
        public virtual int CountResult(TFilter filter)
        {
            return ViewData.CountResult(filter);
        }
        #endregion

        #region Set
        public virtual void SetId(TEntity entity, TIdType id)
        {
            ViewData.SetId(entity, id);
        }
        public virtual void Set(TEntity source, TEntity target)
        {
            ViewData.Set(source, target);
        }
        public virtual void Set(TEntity source, TResult target)
        {
            ViewData.Set(source, target);
        }
        public virtual void Set(TResult source, TEntity target)
        {
            ViewData.Set(source, target);
        }
        public virtual void Set(TResult source, TResult target)
        {
            ViewData.Set(source, target);
        }
        public virtual void Set(TEntity source, TEntity target, bool hadSetId)
        {
            ViewData.Set(source, target, hadSetId);
        }
        public virtual void Set(TEntity source, TResult target, bool hadSetId)
        {
            ViewData.Set(source, target, hadSetId);
        }
        public virtual void Set(TResult source, TEntity target, bool hadSetId)
        {
            ViewData.Set(source, target, hadSetId);
        }
        public virtual void Set(TResult source, TResult target, bool hadSetId)
        {
            ViewData.Set(source, target, hadSetId);
        }
        #endregion
        #region ToEntity
        public virtual TEntity ToEntity(TResult source, TIdType id)
        {
            return ViewData.ToEntity(source, id);
        }
        public virtual TEntity ToEntity(TResult source)
        {
            return ViewData.ToEntity(source);
        }
        #endregion
        #region ToResult
        public virtual TResult ToResult(TEntity source)
        {
            TResult result = new TResult();
            Set(source, result);
            return result;
        }
        public virtual List<TResult> ToResults(List<TEntity> source)
        {
            List<TResult> results = new List<TResult>(source.Count);
            foreach (TEntity entity in source)
            {
                TResult result = new TResult();
                Set(entity, result);
                results.Add(result);
            }
            return results;
        }
        public virtual ListPaged<TResult> ToResults(ListPaged<TEntity> source)
        {
            ListPaged<TResult> results = new ListPaged<TResult>(source.Count);
            foreach (TEntity entity in source)
            {
                TResult result = new TResult();
                Set(entity, result);
                results.Add(result);
            }
            return results;
        }
        #endregion
        #region Equals
        public virtual bool Equals(TEntity source, TEntity target)
        {
            return ViewData.Equals(source, target);
        }
        public virtual bool Equals(TResult source, TEntity target)
        {
            return ViewData.Equals(source, target);
        }
        public virtual bool Equals(TEntity source, TResult target)
        {
            return ViewData.Equals(source, target);
        }
        public virtual bool Equals(TResult source, TResult target)
        {
            return ViewData.Equals(source, target);
        }
        #endregion
        #endregion

        public virtual void ReloadContext()
        {
            LinqUtility.ReloadContext();
        }
    }



    public abstract class EntityBusiness<TEntity, TFilter, TResult, TIdType> : ViewBusiness<TEntity, TFilter, TResult, TIdType> , IEntityBusiness<TEntity, TFilter, TResult, TIdType>
        where TEntity : class, new()
        where TFilter : Filter, new()
        where TResult : IResult<TIdType>,new()
        where TIdType : IComparable
    {
        protected abstract IEntityData<TEntity, TFilter, TResult, TIdType> EntityData { get; }
        protected override IViewData<TEntity, TFilter, TResult, TIdType> ViewData
        {
            get { return EntityData; }
        } 

        #region Info
        public virtual string GetEntityName()
        {
            return typeof(TEntity).Name;
        }
        public virtual string GetEntityKey(TEntity entity)
        {
            return this.GetId(entity).ToString();
        }
        public virtual InfoEntity GetInfoEntity(TEntity entity)
        {
            InfoEntity info = new InfoEntity();
            info.EntityName = GetEntityName();
            info.EntityBaseName = GetEntityName();
            info.TypeName = GetEntityName();
            info.EntityId = this.GetId(entity).ToString();
            info.EntityKey = this.GetEntityKey(entity);
            info.StatusName = "";
            info.Info = "";
            info.EnableViewLog = true;
            return info;
        }
        public virtual string EntityName
        {
            get { return typeof(TEntity).Name; }
        }
        #endregion

        #region Gets
        public virtual bool IsNew(TEntity entity)
        {
            return GetId(entity).CompareTo(default(TIdType)) == 0;
        }
        public virtual TEntity GetNew(TResult example)
        {
            return GetNew();
        }
        public virtual TEntity GetNew()
        {
            return new TEntity();
        }
        #endregion
        
        #region GetResultFromList
        public virtual ListPaged<TResult> GetResultFromList(TFilter filter)
        {
            ListPaged<TEntity> entities = GetList(filter);
            return ToResults(entities);        
        }
        #endregion

       
        #region Actions
        public virtual void Add(TEntity entity, IContextUser contextUser)
        {
            EntityData.Add(entity);
        }
        public virtual void Add(List<TEntity> entities, IContextUser contextUser)
        {
            EntityData.Add(entities);
        }
        public virtual void Update(TEntity entity, IContextUser contextUser)
        {
            EntityData.Update(entity);
        }
        public virtual void Update(List<TEntity> entities, IContextUser contextUser)
        {
            EntityData.Update(entities);
        }
        public virtual TEntity Save(TResult result,IContextUser contextUser)
        {            
            TEntity entity = ToEntity(result);
            if (IsNew(entity))Add(entity, contextUser);
            else Update(entity, contextUser);
            return entity;
        }
        public virtual void Save(TEntity entity, IContextUser contextUser)
        {
            if (IsNew(entity)) Add(entity, contextUser);
            else Update(entity, contextUser);
        }
        public virtual void Save(List<TEntity> entities, IContextUser contextUser)
        {
            foreach (TEntity entity in entities)
                Save(entity, contextUser);
        }

        #region Copy
        public virtual TEntity Copy(TIdType id, IContextUser contextUser)
        {
            return Copy(GetById(id), contextUser);
        }
        public virtual TEntity Copy(TEntity entity, IContextUser contextUser)
        {
            return EntityData.Copy(entity);
        }        
        public virtual List<TEntity> Copies(List<TEntity> entities, IContextUser contextUser)
        {
            List<TEntity> list = new List<TEntity>(entities.Count);
            foreach (TEntity entity in entities)
                list.Add(Copy(entity, contextUser));
            return list;
        }
        public virtual List<TEntity> Copies(TFilter filter, IContextUser contextUser)
        {
            return Copies(GetList(filter), contextUser);
        }
        public virtual List<TEntity> Copies(TIdType[] ids, IContextUser contextUser)
        {
            List<TEntity> list = new List<TEntity>(ids.Length);
            foreach (TIdType id in ids)
                list.Add(Copy(id, contextUser));
            return list;
        }
        #endregion

        #region CopyAndSave
        public virtual TIdType CopyAndSave(TIdType id, string rename, IContextUser contextUser)
        {
            TEntity newEntity = GetById(id);
            return CopyAndSave(newEntity, rename, contextUser);
        }
        public virtual TIdType CopyAndSave(TIdType id, IContextUser contextUser)
        {
            string renameFormat = Translate("Copia de", contextUser) + " {0}";
            TEntity newEntity = GetById(id);
            return CopyAndSave(newEntity, renameFormat, contextUser);
        }
        public virtual TIdType CopyAndSave(TEntity entity, string rename, IContextUser contextUser)
        {
            return EntityData.CopyAndSave(entity, rename);
        }
        public virtual TIdType CopyAndSave(TEntity entity, IContextUser contextUser)
        {
            string renameFormat = Translate("Copia de", contextUser)+" {0}";
            return EntityData.CopyAndSave(entity, renameFormat);
        }
        public virtual TIdType[] CopiesAndSave(List<TEntity> entities, IContextUser contextUser)
        {
            List<TIdType> newsIds = new List<TIdType>(entities.Count);
            string renameFormat = Translate("Copia de", contextUser) + " {0}";
            foreach (TEntity entity in entities)
                newsIds.Add(CopyAndSave(entity, renameFormat, contextUser));
            return newsIds.ToArray();
        }
        public virtual TIdType[] CopiesAndSave(TFilter filter, IContextUser contextUser)
        {
            string renameFormat = Translate("Copia de", contextUser) + " {0}";            
            return CopiesAndSave(GetList(filter), renameFormat, contextUser);
        }
        public virtual TIdType[] CopiesAndSave(TIdType[] ids, IContextUser contextUser)
        {
            List<TIdType> newsIds = new List<TIdType>(ids.Length);
            string renameFormat = Translate("Copia de", contextUser) + " {0}";
            foreach (TIdType id in ids)
                newsIds.Add(CopyAndSave(id, renameFormat, contextUser));
            return newsIds.ToArray();
        }
        public virtual TIdType[] CopiesAndSave(List<TEntity> entities, string prefix, IContextUser contextUser)
        {
            List<TIdType> newsIds = new List<TIdType>(entities.Count);
            foreach (TEntity entity in entities)
                newsIds.Add(CopyAndSave(entity, prefix + " {0}", contextUser));
            return newsIds.ToArray();
        }
        public virtual TIdType[] CopiesAndSave(TFilter filter, string prefix, IContextUser contextUser)
        {
             return CopiesAndSave(GetList(filter), prefix, contextUser);
        }
        public virtual TIdType[] CopiesAndSave(TIdType[] ids, string prefix, IContextUser contextUser)
        {
            List<TIdType> newsIds = new List<TIdType>(ids.Length);
            foreach (TIdType id in ids)
                newsIds.Add(CopyAndSave(id, prefix + " {0}", contextUser));
            return newsIds.ToArray();
        }
        #endregion

        #region Copy Result
        public virtual TResult CopyResult(TResult source)
        {
            TResult target = new TResult();
            EntityData.Set(source,target);
            return target;
        }
        public virtual List<TResult> CopiesResult(List<TResult> sources)
        {
            List<TResult> targets = new List<TResult>(sources.Count);
            foreach (TResult source in sources)
                targets.Add(CopyResult(source));
            return targets;
        }
        #endregion

        public virtual void Delete(TEntity entity, IContextUser contextUser)
        {
            EntityData.Delete(entity);
        }
        public virtual void Delete(List<TEntity> entities, IContextUser contextUser)
        {
            EntityData.Delete(entities);
        }
        public virtual void Delete(TIdType id, IContextUser contextUser)
        {
            EntityData.Delete(id);
        }
        public virtual void Delete(TIdType[] ids, IContextUser contextUser)
        {
            EntityData.Delete(ids);
        }     
        public virtual void Delete(TFilter filter, IContextUser contextUser)
        {
            EntityData.Delete(filter);
        }
                
        #endregion
        #region Validations        
        public abstract bool Can(TIdType id, string actionName, IContextUser contextUser, Hashtable args);
        public virtual bool Can(TEntity entity, string actionName, IContextUser contextUser, Hashtable args)
        { 
            switch (actionName)
            {
                case ActionConfig.DELETE:
                    //if (!CanByRol(actionName)) return false;
                    return !IsNew(entity);
                case ActionConfig.COPY:
                    //if (!CanByRol(actionName)) return false;
                    return !IsNew(entity);
            }
            return true;
        }
        public virtual bool Can(TResult result, string actionName, IContextUser contextUser, Hashtable args)
        {
            TEntity entity = GetNew();
            Set(result, entity);
            return Can(entity, actionName, contextUser, args);
        }
        public virtual void Validate(TEntity entity, string actionName, IContextUser contextUser, Hashtable args)
        {

        }
        public virtual void Validate(TResult result, string actionName, IContextUser contextUser, Hashtable args)
        {
            TEntity entity = GetNew();
            Set(result, entity);
            Validate(entity, actionName, contextUser, args);
        }
        #endregion        
    }

    public abstract class EntityComposeBusiness<TEntityCompose, TEntity, TFilter, TResult, TIdType> : EntityBusiness<TEntityCompose, TFilter, TResult, TIdType>
        where TEntityCompose : class, new()
        where TEntity : class, new()
        where TFilter : Filter, new()
        where TResult : IResult<TIdType>,new()
        where TIdType : IComparable
    {
        #region Properties
        protected abstract EntityBusiness<TEntity, TFilter, TResult, TIdType> EntityBusinessBase{get;}
        protected override IEntityData<TEntityCompose, TFilter, TResult, TIdType> EntityData
        {
            get { return null; }
        }
        #endregion        
        public override List<TEntityCompose> GetByIds(TIdType[] ids)
        {
            throw new NotImplementedException();
        }
        public override ListPaged<TEntityCompose> GetList()
        {
            throw new NotImplementedException();
        }
        public override List<TEntityCompose> Copies(TFilter filter, IContextUser contextUser)
        {
            throw new NotImplementedException();
        }
        public override TEntityCompose FirstOrDefault(TFilter filter)
        {
            TEntity entity =EntityBusinessBase.FirstOrDefault(filter);
            return GetByEntityBase(entity);
        }
        public override TEntityCompose FirstOrDefaultUsingResult(TFilter filter)
        {
            TEntity entity = EntityBusinessBase.FirstOrDefaultUsingResult(filter);
            DataHelper.Validate(entity != null, "No se encontro la entidad", 9001);
            return GetByEntityBase(entity);
        }
        //Conviene sobreescribir este metodo para reutilizar la llamada
        public virtual TEntityCompose GetByEntityBase(TEntity entity)
        {
            return GetById(EntityBusinessBase.GetId(entity));
        }
        //public override TEntityCompose FirstOrDefault(TFilter filter)
        //{
        //    throw new NotImplementedException();
        //}
        public override ListPaged<TEntityCompose> GetList(TFilter filter)
        {
            throw new NotImplementedException();
        }
        public override TEntityCompose Copy(TEntityCompose entity, IContextUser contextUser)
        {
            throw new NotImplementedException();
        }
        public override TIdType CopyAndSave(TEntityCompose entity, string renameFormat, IContextUser contextUser)
        {
            throw new NotImplementedException();
        }
        public override ListPaged<TResult> GetResult()
        {
            return EntityBusinessBase.GetResult();
        }
        public override ListPaged<TResult> GetResult(TFilter filter)
        {
            return EntityBusinessBase.GetResult(filter);
        }       
        #region Actions

        public override void Add(List<TEntityCompose> entities, IContextUser contextUser)
        {
            foreach (TEntityCompose entity in entities)
                Add(entity, contextUser);
        }
        public override void Update(List<TEntityCompose> entities, IContextUser contextUser)
        {
            foreach (TEntityCompose entity in entities)
                Update(entity, contextUser);
        }
        public override void Delete(List<TEntityCompose> entities, IContextUser contextUser)
        {
            foreach (TEntityCompose entity in entities)
                Delete(entity, contextUser);
        }
        public override void Delete(TIdType id, IContextUser contextUser)
        {
            TEntityCompose compose = this.GetById(id);
            Delete(compose, contextUser);
        }
        public override void Delete(TIdType[] ids, IContextUser contextUser)
        {
            foreach (TIdType id in ids)
                Delete(id, contextUser);
        }
        public override void Delete(TFilter filter, IContextUser contextUser)
        {
            EntityBusinessBase.Delete(filter, contextUser);
        } 
        #endregion

        public override bool Can(TIdType id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return EntityBusinessBase.Can(id, actionName, contextUser, args);
        }
                
    }
}


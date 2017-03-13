using System;
using System.Collections.Generic;
using Contract;
using DataAccess;
using System.Data;
using System.Collections;

namespace Business
{
   

    public interface IEntityBusiness { }
    public interface IEntityBusiness<TEntity> : IEntityBusiness where TEntity : class
    {
        bool IsNew(TEntity entity);
        TEntity GetNew();
        TEntity GetByEntity(TEntity entity);
        ListPaged<TEntity> GetList();

        void Add(TEntity entity,IContextUser contextUser);
        void Add(List<TEntity> entities, IContextUser contextUser);
        void Update(TEntity entity, IContextUser contextUser);
        void Update(List<TEntity> entities, IContextUser contextUser);
        void Save(TEntity entity, IContextUser contextUser);
        void Save(List<TEntity> entities, IContextUser contextUser);
        TEntity Copy(TEntity entity, IContextUser contextUser);
        List<TEntity> Copies(List<TEntity> entities, IContextUser contextUser);
        void Delete(TEntity entity, IContextUser contextUser);
        void Delete(List<TEntity> entities, IContextUser contextUser);

        void Validate(TEntity entity, string actionName, IContextUser contextUser, Hashtable args);
        bool Can(TEntity entity, string actionName,IContextUser contextUser, Hashtable args);
        //Esto Es Provisorio
        void ReloadContext();
        int Count();
        int CountResult();

                
    }
    public interface IEntityBusiness<TEntity, TIdType> : IEntityBusiness<TEntity> where TEntity : class
    {
        TIdType GetId(TEntity entity);
        TEntity GetById(TIdType id);
        List<TEntity> GetByIds(TIdType[] ids);
        TEntity Copy(TIdType id, IContextUser contextUser);
        List<TEntity> Copies(TIdType[] ids, IContextUser contextUser);
        void Delete(TIdType id, IContextUser contextUser);
        void Delete(TIdType[] ids, IContextUser contextUser);
    }

    public interface IViewBusiness { }
    public interface IViewBusiness<TEntity, TFilter, TResult, TIdType> : IViewBusiness
        where TEntity : class
        where TFilter : Filter, new()
        where TResult : IResult<TIdType>
        where TIdType : IComparable
    {        
        #region Gets
        TIdType GetId(TEntity entity);
        TEntity GetById(TIdType id);
        List<TEntity> GetByIds(TIdType[] ids);
        TEntity GetByEntity(TEntity entity);

        TEntity FirstOrDefault(TFilter filter);
        TEntity FirstOrDefaultUsingResult(TFilter filter);
        TResult FirstOrDefaultResult(TFilter filter);

        ListPaged<SimpleResult<TIdType>> GetSimpleList(TFilter filter);
        ListPaged<TEntity> GetList();
        ListPaged<TEntity> GetList(TFilter filter);
        ListPaged<TResult> GetResult();
        ListPaged<TResult> GetResult(TFilter filter);

        DataTable GetFromStoreProcedure(int idCommandName, TFilter filter);
        DataTable GetFromStoreProcedure(string commandText, TFilter filter);
        DataTable GetFromStoreProcedure(string commandText);

        ReportInfo GetReport(string reporteCodigo, TIdType id);
        ReportInfo GetReport(int idReporte, TIdType id);
        ReportInfo GetReport(SistemaReporte reporte, TIdType id);
        ReportInfo GetReport(string reporteCodigo, TFilter filter);
        ReportInfo GetReport(int idReporte, TFilter filter);
        ReportInfo GetReport(SistemaReporte reporte, TFilter filter);

        void SaveHistoryReport(string reporteCodigo, ReportHistoryInfo info, TIdType id, IContextUser contextUser);
        void SaveHistoryReport(int idReporte, ReportHistoryInfo info, TIdType id, IContextUser contextUser);
        void SaveHistoryReport(SistemaReporte reporte, ReportHistoryInfo info, TIdType id, IContextUser contextUser);
        void SaveHistoryReport(string reporteCodigo, ReportHistoryInfo info, TFilter filter, IContextUser contextUser);
        void SaveHistoryReport(int idReporte, ReportHistoryInfo info, TFilter filter, IContextUser contextUser);
        void SaveHistoryReport(SistemaReporte reporte, ReportHistoryInfo info, TFilter filter, IContextUser contextUser);
        ReportInfo GetHistoryReport(int idReporteHistorico);
        ReportInfo GetHistoryReport(SistemaReporteHistorico reporteHistorico);

        int Count();
        int Count(TFilter filter);
        int CountResult();
        int CountResult(TFilter filter);
        #endregion

        void ExecuteStoreProcedure(int idCommandName, TFilter filter);
        void ExecuteStoreProcedure(string commandText, TFilter filter);
        void ExecuteStoreProcedure(string commandText);

        void ReloadContext();

        #region Sets
        void SetId(TEntity entity, TIdType id);
        void Set(TEntity source, TEntity target);
        void Set(TEntity source, TResult target);
        void Set(TResult source, TEntity target);
        void Set(TResult source, TResult target);
        void Set(TEntity source, TEntity target, bool hadSetId);
        void Set(TEntity source, TResult target, bool hadSetId);
        void Set(TResult source, TEntity target, bool hadSetId);
        void Set(TResult source, TResult target, bool hadSetId);
        #endregion
        #region ToEntity
        TEntity ToEntity(TResult source, TIdType id);
        TEntity ToEntity(TResult source);
        #endregion
        #region ToResult
        TResult ToResult(TEntity source);
        List<TResult> ToResults(List<TEntity> source);
        ListPaged<TResult> ToResults(ListPaged<TEntity> source);
        #endregion
        #region Equals
        bool Equals(TEntity source, TEntity target);
        bool Equals(TResult source, TEntity target);
        bool Equals(TEntity source, TResult target);
        bool Equals(TResult source, TResult target);
        #endregion
    }
    
    
    public interface IEntityBusiness<TEntity, TFilter, TResult, TIdType> : IViewBusiness<TEntity, TFilter, TResult, TIdType>, IEntityBusiness
        where TEntity : class
        where TFilter : Filter, new()
        where TResult : IResult<TIdType>,new()
        where TIdType : IComparable
    {
        #region Info
        string GetEntityName();
        string GetEntityKey(TEntity entity);
        InfoEntity GetInfoEntity(TEntity entity);
        #endregion
        #region Action
        bool IsNew(TEntity entity);
        TEntity GetNew();
        TEntity GetNew(TResult example);
        ListPaged<TResult> GetResultFromList(TFilter filter);
        
        void Add(TEntity entity, IContextUser contextUser);
        void Add(List<TEntity> entities, IContextUser contextUser);
        void Update(TEntity entity, IContextUser contextUser);
        void Update(List<TEntity> entities, IContextUser contextUser);
        TEntity Save(TResult result, IContextUser contextUser);        
        void Save(TEntity entity, IContextUser contextUser);
        void Save(List<TEntity> entities, IContextUser contextUser);

        TEntity Copy(TIdType id, IContextUser contextUser);
        TEntity Copy(TEntity entity, IContextUser contextUser);
        List<TEntity> Copies(TIdType[] ids, IContextUser contextUser);
        List<TEntity> Copies(List<TEntity> entities, IContextUser contextUser);
        List<TEntity> Copies(TFilter filter, IContextUser contextUser);

        TResult CopyResult(TResult source);
        List<TResult> CopiesResult(List<TResult> sources);

        #region CopyAndSave
        TIdType CopyAndSave(TIdType id, string rename, IContextUser contextUser);
        TIdType CopyAndSave(TIdType id, IContextUser contextUser);
        TIdType CopyAndSave(TEntity entity, string rename, IContextUser contextUser);
        TIdType CopyAndSave(TEntity entity, IContextUser contextUser);
        TIdType[] CopiesAndSave(List<TEntity> entities, IContextUser contextUser);
        TIdType[] CopiesAndSave(TFilter filter, IContextUser contextUser);
        TIdType[] CopiesAndSave(TIdType[] ids, IContextUser contextUser);
        TIdType[] CopiesAndSave(List<TEntity> entities, string prefix, IContextUser contextUser);
        TIdType[] CopiesAndSave(TFilter filter, string prefix, IContextUser contextUser);
        TIdType[] CopiesAndSave(TIdType[] ids, string prefix, IContextUser contextUser);
        #endregion

        void Delete(TIdType id, IContextUser contextUser);
        void Delete(TIdType[] ids, IContextUser contextUser);
        void Delete(TEntity entity, IContextUser contextUser);
        void Delete(List<TEntity> entities, IContextUser contextUser);
        void Delete(TFilter filter, IContextUser contextUser);
        #endregion
        #region Validations
        void Validate(TEntity entity, string actionName, IContextUser contextUser, Hashtable args);
        bool Can(TEntity entity, string actionName, IContextUser contextUser, Hashtable args);
        bool Can(TResult result, string actionName, IContextUser contextUser, Hashtable args);
        bool Can(TIdType id, string actionName, IContextUser contextUser, Hashtable args);
        #endregion
      
        
    }   
}

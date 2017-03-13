using System;
using System.Collections.Generic;
using Contract;
using Business;
using System.Security.Principal;
using System.Data;
using System.Collections;

namespace Service
{

    public class EntityServiceBehaviour
    {
        public EntityServiceBehaviour()
        {
            Audit = true;
            EntityIsSerializable = true;
        }
        public bool Audit { get; set; }
        public bool EntityIsSerializable { get; set; }
    }

    public interface IService { }
    public interface IObjectService : IService
    {
        #region Gets
        bool IsNew(object entity);
        object GetNew();
        object GetByEntity(object entity);
        object GetList();
        object GetId(object entity);
        object GetById(object id);
        object GetByIds(object[] ids);
        object FirstOrDefault(object filter);
        object GetList(object filter);
        object GetResult();
        object GetResult(object filter);                
        #endregion
        #region Actions
        #region Quick access
        void Add(object entity, IContextUser contextUser);
        void Add(object[] entities, IContextUser contextUser);
        void Update(object entity, IContextUser contextUser);
        void Update(object[] entities, IContextUser contextUser);
        void Save(object entity, IContextUser contextUser);
        void Save(object[] entities, IContextUser contextUser);
        object Copy(object entity, IContextUser contextUser);
        object CopyById(object id, IContextUser contextUser);
        object Copies(object[] entities, IContextUser contextUser);
        object CopiesById(object[] ids, IContextUser contextUser);
        object CopiesByFilter(object filter, IContextUser contextUser);
        void Delete(object entity, IContextUser contextUser);
        void Delete(object[] entities, IContextUser contextUser);
        void DeleteById(object id, IContextUser contextUser);
        void DeleteById(object[] ids, IContextUser contextUser);
        #endregion
        #region Can
        bool Can(object entity, ActionEnum actionEnum, IContextUser contextUser, Hashtable args);
        bool Can(object entity, string actionName, IContextUser contextUser,Hashtable args);
        bool Can(object[] entities, ActionEnum actionEnum, IContextUser contextUser, Hashtable args);
        bool Can(object[] entities, string actionName, IContextUser contextUser, Hashtable args);
        #endregion
        #region Execute
        object Execute(object entity, ActionEnum actionEnum, IContextUser contextUser, Hashtable args );
        object Execute(object entity, string actionName, IContextUser contextUser, Hashtable args);
        object Execute(object[] entities, ActionEnum actionEnum, IContextUser contextUser, Hashtable args);
        object Execute(object[] entities, string actionName, IContextUser contextUser, Hashtable args);
        object ExecuteById(object id, ActionEnum actionEnum, IContextUser contextUser, Hashtable args);
        object ExecuteById(object id, string actionName, IContextUser contextUser, Hashtable args);
        object ExecuteByIds(object[] ids, ActionEnum actionEnum, IContextUser contextUser, Hashtable args);
        object ExecuteByIds(object[] ids, string actionName, IContextUser contextUser, Hashtable args);
        object ExecuteByFilter(object filter, ActionEnum actionEnum, IContextUser contextUser, Hashtable args);
        object ExecuteByFilter(object filter, string actionName, IContextUser contextUser, Hashtable args);
        #endregion
        #endregion

        string Serialize(object entity);
        object Deserialize(string text);
    }

    public interface IEntityService : IService
    {
        IObjectService GetObjectService();
    }
    public interface IEntityService<TEntity> : IEntityService  where TEntity : class
    {
        string GetEntityName();
        TEntity GetLog(int logId);

        bool IsNew(TEntity entity);
        TEntity GetNew();
        TEntity GetByEntity(TEntity entity);
        ListPaged<TEntity> GetList();
        int Count();
        int CountResult();

        void Add(TEntity entity, IContextUser contextUser);
        void Add(List<TEntity> entities, IContextUser contextUser);
        void Delete(TEntity entity, IContextUser contextUser);
        void Delete(List<TEntity> entities, IContextUser contextUser);
        void Update(TEntity entity, IContextUser contextUser);
        void Update(List<TEntity> entities, IContextUser contextUser);
        void Save(TEntity entity, IContextUser contextUser);
        TEntity Copy(TEntity entity, IContextUser contextUser);
        List<TEntity> Copies(List<TEntity> entities, IContextUser contextUser);

        bool Can(TEntity entity, ActionEnum actionEnum, IContextUser contextUser, params string[] args);
        bool Can(TEntity entity, string actionName, IContextUser contextUser, params string[] args);



        bool Can(List<TEntity> entities, ActionEnum actionEnum, IContextUser contextUser, params string[] args);
        bool Can(List<TEntity> entities, string actionName, IContextUser contextUser, params string[] args);
        object Execute(TEntity entity, ActionEnum actionEnum, IContextUser contextUser, params string[] args);
        object Execute(TEntity entity, string actionName, IContextUser contextUser, params string[] args);
        object Execute(List<TEntity> entities, ActionEnum actionEnum, IContextUser contextUser, params string[] args);
        object Execute(List<TEntity> entities, string actionName, IContextUser contextUser, params string[] args);
                
        string Serialize(TEntity entity);
        TEntity Deserialize(string text);       
    }
    public interface IEntityService<TEntity, TIdType> : IEntityService<TEntity>  where TEntity : class
    {
        TIdType GetId(TEntity entity);
        TEntity GetById(TIdType id);
        List<TEntity> GetByIds(TIdType[] ids);
        void Delete(TIdType id, IContextUser contextUser);
        void Delete(TIdType[] ids, IContextUser contextUser);        
        TEntity Copy(TIdType id, IContextUser contextUser);
        List<TEntity> Copies(TIdType[] ids, IContextUser contextUser);

        object Execute(TIdType id, ActionEnum actionEnum, IContextUser contextUser, params string[] args);
        object Execute(TIdType id, string actionName, IContextUser contextUser, params string[] args);
        object Execute(TIdType[] ids, ActionEnum actionEnum, IContextUser contextUser, params string[] args);
        object Execute(TIdType[] ids, string actionName, IContextUser contextUser, params string[] args);
    }



    public interface IViewService { }
    public interface IViewService<TEntity, TFilter, TResult, TIdType> : IViewService
        where TEntity : class
        where TFilter : Filter, new()
        where TResult : IResult<TIdType>
        where TIdType : IComparable
    {
        TIdType GetId(TEntity entity);
        TEntity GetById(TIdType id);
        TEntity GetByEntity(TEntity entity);
        List<TEntity> GetByIds(TIdType[] ids);
        ListPaged<SimpleResult<TIdType>> GetSimpleList(TFilter filter);
        TEntity FirstOrDefault(TFilter filter);
        TEntity FirstOrDefaultUsingResult(TFilter filter);
        TResult FirstOrDefaultResult(TFilter filter);

    /*    TResult ToResult(TEntity source);
        List<TResult> ToResults(List<TEntity> source);
        ListPaged<TResult> ToResults(ListPaged<TEntity> source);*/

        ListPaged<TEntity> GetList();
        ListPaged<TEntity> GetList(TFilter filter);
        ListPaged<TResult> GetResult();
        ListPaged<TResult> GetResult(TFilter filter);

        DataTable GetFromStoreProcedure(int idCommandName, TFilter filter);
        DataTable GetFromStoreProcedure(string commandText, TFilter filter);
        DataTable GetFromStoreProcedure(string commandText);

        void ExecuteStoreProcedure(int idCommandName, TFilter filter);
        void ExecuteStoreProcedure(string commandText, TFilter filter);
        void ExecuteStoreProcedure(string commandText);

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
    }

    public interface IEntityService<TEntity, TFilter, TResult, TIdType> : IViewService<TEntity, TFilter, TResult, TIdType>, IEntityService
        where TEntity : class
        where TFilter : Filter, new()
        where TResult : IResult<TIdType>
        where TIdType : IComparable
    {

        string GetEntityName();
        TEntity GetLog(int logId);
        InfoEntity GetInfoEntity(TEntity entity);
        EntityServiceBehaviour Behaviour { get;}
        List<TResult> GetResultFromList(TFilter filter);

        bool IsNew(TEntity entity);
        TEntity GetNew();
        TEntity GetNew(TResult example); 

        void Add(TEntity entity, IContextUser contextUser);
        void Add(List<TEntity> entities, IContextUser contextUser);            

        void Update(TEntity entity, IContextUser contextUser);
        void Update(List<TEntity> entities, IContextUser contextUser);

        void Save(TEntity entity, IContextUser contextUser);

        TEntity Copy(TIdType id, IContextUser contextUser);
        TEntity Copy(TEntity entity, IContextUser contextUser);
        List<TEntity> Copies(TIdType[] ids, IContextUser contextUser);
        List<TEntity> Copies(List<TEntity> entities, IContextUser contextUser);
        List<TEntity> Copies(TFilter filter, IContextUser contextUser);

        #region CopyAndSave
        TIdType CopyAndSave(TIdType id, string rename, IContextUser contextUser);
        TIdType CopyAndSave(TEntity entity, string rename, IContextUser contextUser);
        TIdType CopyAndSave(TIdType id, IContextUser contextUser);
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

        object Execute(TIdType id, ActionEnum actionEnum, IContextUser contextUser);
        object Execute(TIdType id, ActionEnum actionEnum, IContextUser contextUser, Hashtable args);
        object Execute(TIdType id, string actionName, IContextUser contextUser);
        object Execute(TIdType id, string actionName, IContextUser contextUser, Hashtable args);
        object Execute(TIdType[] ids, ActionEnum actionEnum, IContextUser contextUser);
        object Execute(TIdType[] ids, ActionEnum actionEnum, IContextUser contextUser, Hashtable args);
        object Execute(TIdType[] ids, string actionName, IContextUser contextUser);
        object Execute(TIdType[] ids, string actionName, IContextUser contextUser, Hashtable args);
        object Execute(TEntity entity, ActionEnum actionEnum, IContextUser contextUser);
        object Execute(TEntity entity, ActionEnum actionEnum, IContextUser contextUser, Hashtable args);
        object Execute(TEntity entity, string actionName, IContextUser contextUser);
        object Execute(TEntity entity, string actionName, IContextUser contextUser, Hashtable args);
        object Execute(List<TEntity> entities, ActionEnum actionEnum, IContextUser contextUser);
        object Execute(List<TEntity> entities, ActionEnum actionEnum, IContextUser contextUser, Hashtable args);
        object Execute(List<TEntity> entities, string actionName, IContextUser contextUser);
        object Execute(List<TEntity> entities, string actionName, IContextUser contextUser, Hashtable args);
        object Execute(TFilter filter, ActionEnum actionEnum, IContextUser contextUser);
        object Execute(TFilter filter, ActionEnum actionEnum, IContextUser contextUser, Hashtable args);
        object Execute(TFilter filter, string actionName, IContextUser contextUser);
        object Execute(TFilter filter, string actionName, IContextUser contextUser, Hashtable args);

        bool Can(TIdType id, ActionEnum actionEnum, IContextUser contextUser);
        bool Can(TIdType id, ActionEnum actionEnum, IContextUser contextUser, Hashtable args);
        bool Can(TIdType id, string actionName, IContextUser contextUser);
        bool Can(TIdType id, string actionName, IContextUser contextUser, Hashtable args);
        bool Can(TEntity entity, ActionEnum actionEnum, IContextUser contextUser);
        bool Can(TEntity entity, ActionEnum actionEnum, IContextUser contextUser, Hashtable args);
        bool Can(TEntity entity, string actionName, IContextUser contextUser);
        bool Can(TEntity entity, string actionName, IContextUser contextUser, Hashtable args);
        bool Can(List<TEntity> entities, ActionEnum actionEnum, IContextUser contextUser);
        bool Can(List<TEntity> entities, ActionEnum actionEnum, IContextUser contextUser, Hashtable args);
        bool Can(List<TEntity> entities, string actionName, IContextUser contextUser);
        bool Can(List<TEntity> entities, string actionName, IContextUser contextUser, Hashtable args);
        bool Can(TResult result, ActionEnum actionEnum, IContextUser contextUser);
        bool Can(TResult result, ActionEnum actionEnum, IContextUser contextUser, Hashtable args);
        bool Can(TResult result, string actionName, IContextUser contextUser);
        bool Can(TResult result, string actionName, IContextUser contextUser, Hashtable args);

        string Serialize(TEntity entity);
        TEntity Deserialize(string text);

        void SetId(TEntity entity, TIdType id);
        void Set(TEntity source, TEntity target);
        void Set(TEntity source, TResult target);
        void Set(TResult source, TEntity target);
        void Set(TResult source, TResult target);
        void Set(TEntity source, TEntity target, bool hadSetId);
        void Set(TEntity source, TResult target, bool hadSetId);
        void Set(TResult source, TEntity target, bool hadSetId);
        void Set(TResult source, TResult target, bool hadSetId);

        TEntity ToEntity(TResult source, TIdType id);
        TEntity ToEntity(TResult source);

        TResult ToResult(TEntity source);
        List<TResult> ToResults(List<TEntity> source);
        ListPaged<TResult> ToResults(ListPaged<TEntity> source);

        bool Equals(TEntity source, TEntity target);
        bool Equals(TResult source, TEntity target);
        bool Equals(TEntity source, TResult target);
        bool Equals(TResult source, TResult target);
    } 
}

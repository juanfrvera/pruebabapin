using System;
using System.Collections.Generic;
using Contract;
using System.Data;
using System.Data.Linq;

namespace DataAccess
{
    public interface IEntityData<TEntity, TIdType> where TEntity : class
    {
        TIdType GetId(TEntity entity);
        TEntity GetById(TIdType id);
        TEntity GetByEntity(TEntity entity);
        ListPaged<TEntity> GetByIds(TIdType[] ids);
        ListPaged<TEntity> GetList();
        void Add(TEntity entity);
        void Add(List<TEntity> entities);
        void Update(TEntity entity);
        void Update(List<TEntity> entities);  
        void Delete(TEntity entity);
        void Delete(List<TEntity> entities);
        void Delete(TIdType id);
        void Delete(TIdType[] ids);
        TEntity Copy(TEntity entity);

        int Count();
        int CountResult();
        
    }

    public interface IViewData<TEntity, TFilter, TResult, TIdType>
        where TEntity : class
        where TFilter : Filter
        where TResult : IResult<TIdType>
        where TIdType : IComparable
    {
       
        TIdType GetId(TEntity entity);
        TEntity GetById(TIdType id);
        TEntity GetByEntity(TEntity entity);
        ListPaged<TEntity> GetByIds(TIdType[] ids);
        TEntity FirstOrDefault(TFilter filter);
        TResult FirstOrDefaultResult(TFilter filter);
        ListPaged<TEntity> GetList();
        ListPaged<TEntity> GetList(TFilter filter);
        ListPaged<TResult> GetResult(TFilter filter);
        ListPaged<SimpleResult<TIdType>> GetSimpleList(TFilter filter);

        DataTable GetFromStoreProcedure(string commandText, TFilter filter);
        DataTable GetFromStoreProcedure(string commandText);

        void ExecuteStoreProcedure(string commandText, TFilter filter);
        void ExecuteStoreProcedure(string commandText);

        int Count();
        int CountResult();
        int Count(TFilter filter);
        int CountResult(TFilter filter);

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

        bool Equals(TEntity source, TEntity target);
        bool Equals(TResult source, TEntity target);
        bool Equals(TEntity source, TResult target);
        bool Equals(TResult source, TResult target);

    }

    public interface IEntityData<TEntity, TFilter, TResult, TIdType> : IViewData<TEntity, TFilter, TResult, TIdType>
        where TEntity : class
        where TFilter : Filter
        where TResult : IResult<TIdType>
        where TIdType : IComparable
    {     
                
        void Add(TEntity entity);
        void Add(List<TEntity> entities);
        void Update(TEntity entity);
        void Update(List<TEntity> entities);
        void Delete(TEntity entity);
        void Delete(List<TEntity> entities);
        void Delete(TIdType id);
        void Delete(TIdType[] ids);
        void Delete(TFilter filter);

        TEntity Copy(TEntity entity);
        TIdType CopyAndSave(TEntity entity, string renameFormat);

        
       
        //Esto es provisorio
        void ReloadContext();
    }   
}

using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using Contract;
using System.Linq.Expressions;
using System.Data;

namespace DataAccess
{
    public static class Singletons
    {
        public static int COUNT_CHANGES;
    }
    public abstract class ViewData<TEntity, TFilter, TResult, TIdType> : IViewData<TEntity, TFilter, TResult, TIdType>
        where TEntity : class, new()
        where TFilter : Filter, new()
        where TResult : class, IResult<TIdType>
        where TIdType : IComparable
    {
        public ViewData()
        {
            Singletons.COUNT_CHANGES = 0;
        }
        #region Context
        public DataContext DataContext
        {
            get { return LinqUtility.Context; }
        }
        /// <summary>
        /// Tabla relacionada a la Entidad
        /// </summary>
        protected System.Data.Linq.Table<TEntity> Table
        {
            get { return LinqUtility.Context.GetTable<TEntity>(); }
        }
        public void ReloadContext()
        {
            LinqUtility.ReloadContext();
        }
        #endregion
        #region info
        public virtual string IdFieldName { get { return null; } }
        #endregion
        #region Get
        public virtual TIdType GetId(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public virtual TEntity GetById(TIdType id)
        {
            throw new NotImplementedException();
        }
        public virtual ListPaged<TEntity> GetByIds(TIdType[] ids)
        {
            ListPaged<TEntity> list = new ListPaged<TEntity>(ids.Length);
            foreach (TIdType id in ids)
                list.Add(GetById(id));
            return list;
        }
        public virtual TEntity GetByEntity(TEntity entity)
        {
            return GetById(GetId(entity));
        }
        public virtual ListPaged<SimpleResult<TIdType>> GetSimpleList(TFilter filter)
        {
            return null;
        }
        public virtual ListPaged<TEntity> GetList()
        {
            TEntity[] array = (from o in this.Table select o).ToArray();
            return new ListPaged<TEntity>(array);
        }
        public virtual TEntity FirstOrDefault(TFilter filter)
        {
            return ListPaged<TEntity>(Query(filter), filter).FirstOrDefault();
        }
        public virtual TResult FirstOrDefaultResult(TFilter filter)
        {
            return ListPaged<TResult>(QueryResult(filter), filter).FirstOrDefault();
        }
        public virtual ListPaged<TEntity> GetList(TFilter filter)
        {
            return ListPaged<TEntity>(Query(filter), filter);
        }
        public virtual ListPaged<TResult> GetResult(TFilter filter)
        {
            return ListPaged<TResult>(QueryResult(filter), filter);
        }
        public virtual DataTable GetFromStoreProcedure(string commandText, TFilter filter)
        {
            return DbUtility.Current.Get(commandText, CommandType.StoredProcedure, filter);
        }
        public virtual DataTable GetFromStoreProcedure(string commandText)
        {
            return DbUtility.Current.Get(commandText, CommandType.StoredProcedure);
        }
        public virtual void ExecuteStoreProcedure(string commandText, TFilter filter)
        {
            DbUtility.Current.Execute(commandText, CommandType.StoredProcedure, filter);
        }
        public virtual void ExecuteStoreProcedure(string commandText)
        {
            DbUtility.Current.Execute(commandText, CommandType.StoredProcedure);
        }

        protected abstract IQueryable<TEntity> Query(TFilter filter);
        protected abstract IQueryable<TResult> QueryResult(TFilter filter);
        #endregion
        #region Count
        public int Count()
        {
            return (from o in this.Table select o).Count();
        }
        public int Count(TFilter filter)
        {
            return Query(filter).Count();
        }
        public int CountResult()
        {
            return QueryResult(new TFilter()).Count();
        }
        public int CountResult(TFilter filter)
        {
            return QueryResult(filter).Count();
        }
        #endregion
        #region Pagging
        protected TEntity[] ListEntity(IQueryable<TEntity> query, Filter filter)
        {
            return List<TEntity>(query, filter);
        }
        protected ListPaged<T> ListPaged<T>(IQueryable<T> query, Filter filter) where T : class
        {
            int? totalRows = null;
            if (filter.GetTotaRowsCount)
            {
                totalRows = query.Count();
                if (totalRows.HasValue)
                {
                    if (filter.PageNumber * filter.PageSize >= totalRows + filter.PageSize)
                        filter.PageNumber = 1;
                }
            }
            ListPaged<T> list = new ListPaged<T>(List<T>(query, filter));
            list.TotalRows = totalRows;
            return list;
        }
        protected T[] List<T>(IQueryable<T> query, Filter filter) where T : class
        {
            IQueryable<T> q = null;
            if (filter.PageNumber > 0 && filter.PageSize > 0)
            {
                int from = filter.PageSize * (filter.PageNumber - 1);
                if (filter.OrderByProperty != null && filter.OrderByProperty.Trim() != string.Empty)
                {
                    //return OrderBy<T>(query, filter.OrderByProperty, filter.OrderByDesc).Skip(from).Take(filter.PageSize).ToArray();
                    q = (from o in OrderBy<T>(query, filter.OrderBys) select o).AsQueryable();
                    q = (from o in q select o).Skip(from).Take(filter.PageSize).AsQueryable();
                    return q.ToArray();

                }
                q = query.Skip(from).Take(filter.PageSize).AsQueryable();
                return q.ToArray();
            }
            else if (filter.OrderBys != null && filter.OrderBys.Count > 0)
            {
                if (filter.OrderByProperty != null)
                {
                    q = OrderBy<T>(query,filter.OrderByProperty, filter.OrderBys[0].OrderByDesc).AsQueryable();
                    return q.ToArray();
                }
                else
                {
                    q = OrderBy<T>(query, filter.OrderBys).AsQueryable();
                    return q.ToArray();
                }
               
            }
            else if (filter.OrderByProperty != null)
            {
                q = OrderBy<T>(query, filter.OrderByProperty, filter.OrderByDesc).AsQueryable();
                return q.ToArray();
            }
            else
            {
                return query.ToArray();
            }
        }
        public IQueryable<T> OrderBy<T>(IQueryable<T> source, string orderByProperty, bool desc) where T : class
        {
            string command = desc ? "OrderByDescending" : "OrderBy";
            var type = typeof(T);
            var property = type.GetProperty(orderByProperty);
            if (property == null)
                return source;
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
            source.Expression, Expression.Quote(orderByExpression));
            return source.Provider.CreateQuery<T>(resultExpression);
        }
        public IQueryable<T> OrderBy<T>(IQueryable<T> source, List<FilterOrderBy> orderBys) where T : class
        {
            Expression auxExpression = source.Expression;
            bool first = true;
            bool hadOrder = false;
            foreach (FilterOrderBy orderBy in orderBys)
            {
                if (orderBy.OrderByProperty == null) continue;

                string command = first ? (orderBy.OrderByDesc ? "OrderByDescending" : "OrderBy") : (orderBy.OrderByDesc ? "ThenByDescending" : "ThenBy");
                var type = typeof(T);
                var property = type.GetProperty(orderBy.OrderByProperty);
                if (property == null)
                    return source;
                var parameter = Expression.Parameter(type, "p");
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var orderByExpression = Expression.Lambda(propertyAccess, parameter);
                auxExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
                auxExpression, Expression.Quote(orderByExpression));
                first = false;
                hadOrder = true;
            }
            if (hadOrder && this.IdFieldName != null)
            {
                var type = typeof(T);
                var property = type.GetProperty(this.IdFieldName);
                if (property == null)
                    return source;
                var parameter = Expression.Parameter(type, "p");
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var orderByExpression = Expression.Lambda(propertyAccess, parameter);
                auxExpression = Expression.Call(typeof(Queryable), "ThenBy", new Type[] { type, property.PropertyType },
                auxExpression, Expression.Quote(orderByExpression));
            }
            return source.Provider.CreateQuery<T>(auxExpression);
        }
        protected TResult[] ListResult(IQueryable<TResult> query, Filter filter)
        {
            return List<TResult>(query, filter);
        }
        #endregion
        #region Set
        public abstract void SetId(TEntity entity, TIdType id);
        public virtual void Set(TEntity source, TEntity target)
        {
            Set(source, target, true);
        }
        public virtual void Set(TEntity source, TResult target)
        {
            Set(source, target, true);
        }
        public virtual void Set(TResult source, TEntity target)
        {
            Set(source, target, true);
        }
        public virtual void Set(TResult source, TResult target)
        {
            Set(source, target, true);
        }
        public abstract void Set(TEntity source, TEntity target, bool hadSetId);
        public abstract void Set(TEntity source, TResult target, bool hadSetId);
        public abstract void Set(TResult source, TEntity target, bool hadSetId);
        public abstract void Set(TResult source, TResult target, bool hadSetId);
        #endregion
        #region ToEntity
        #region ToEntity
        public virtual TEntity ToEntity(TResult source, TIdType id)
        {
            TEntity target = ToEntity(source);
            SetId(target, id);
            return target;
        }
        public virtual TEntity ToEntity(TResult source)
        {
            TEntity target = new TEntity();
            Set(source, target);
            return target;
        }
        #endregion
        #endregion
        #region Equals
        public abstract bool Equals(TEntity source, TEntity target);
        public virtual bool Equals(TResult source, TEntity target)
        {
            if (source == null && target == null) return true;
            if (source == null) return false;
            if (target == null) return false;
            TEntity _source = new TEntity();
            Set(source, _source);
            return this.Equals(_source, target);
        }
        public virtual bool Equals(TEntity source, TResult target)
        {
            if (source == null && target == null) return true;
            if (source == null) return false;
            if (target == null) return false;
            TEntity _target = new TEntity();
            Set(target, _target);
            return this.Equals(source, _target);
        }
        public abstract bool Equals(TResult source, TResult target);
        #endregion
    }

    public abstract class EntityData<TEntity, TFilter, TResult, TIdType> : ViewData<TEntity, TFilter, TResult, TIdType>, IEntityData<TEntity, TFilter, TResult, TIdType>
        where TEntity : class,new()
        where TFilter : Filter, new()
        where TResult : class,IResult<TIdType>
        where TIdType : IComparable
    {
        #region Methods

        #region Actions
        public virtual void Add(TEntity entity)
        {
            try
            {
                Table.InsertOnSubmit(entity);
                Singletons.COUNT_CHANGES += 1;
                DataContext.SubmitChanges();
            }
            catch (ChangeConflictException changeConflictException)
            {
                foreach (ObjectChangeConflict occ in DataContext.ChangeConflicts)
                    occ.Resolve(RefreshMode.KeepCurrentValues);
                if (Singletons.COUNT_CHANGES > 0)
                    Singletons.COUNT_CHANGES -= 1;
            }
            catch (Exception exception2)
            {

                ReloadContext();
                if (Singletons.COUNT_CHANGES > 0)
                    Singletons.COUNT_CHANGES -= 1;
                throw exception2;
            }
        }
        public virtual void Add(List<TEntity> entities)
        {
            foreach (TEntity entity in entities)
                Add(entity);
        }
        public virtual void Update(TEntity entity)
        {
            try
            {
                ChangeSet changes = DataContext.GetChangeSet();
                if (changes.Updates.Contains(entity))
                    Singletons.COUNT_CHANGES += 1;
                DataContext.Refresh(System.Data.Linq.RefreshMode.KeepChanges, entity);
            }

            catch (ArgumentException exception)
            {
                //if (exception.Message == "An object specified for refresh is not recognized."
                //    || exception.Message == "No se reconoce el objeto especificado para actualización.")
                //{
                TEntity old = this.GetByEntity(entity);
                LinqUtility.CopiarAtributos(entity, old);
                DataContext.Refresh(System.Data.Linq.RefreshMode.KeepChanges, old);
                ChangeSet changes = DataContext.GetChangeSet();
                if (changes.Updates.Contains(old))
                    Singletons.COUNT_CHANGES += 1;
                else
                    if (Singletons.COUNT_CHANGES > 0)
                        Singletons.COUNT_CHANGES -= 1;
                //}
                //else
                //    throw exception;
            }
            try
            {
                DataContext.SubmitChanges();
            }
            catch (ChangeConflictException changeConflictException)
            {
                foreach (ObjectChangeConflict occ in DataContext.ChangeConflicts)
                    occ.Resolve(RefreshMode.KeepCurrentValues);
                if (Singletons.COUNT_CHANGES > 0)
                    Singletons.COUNT_CHANGES -= 1;
            }
            catch (Exception exception2)
            {
                ReloadContext();
                if (Singletons.COUNT_CHANGES > 0)
                    Singletons.COUNT_CHANGES -= 1;
                throw exception2;
            }
        }
        //public virtual void Update(TEntity entity)
        //{
        //    try
        //    {
        //        DataContext.Refresh(System.Data.Linq.RefreshMode.KeepChanges, entity);
        //    }
        //    catch (ArgumentException exception)
        //    {
        //        if (exception.Message == "An object specified for refresh is not recognized.")
        //        {
        //            TEntity old = this.GetByEntity(entity);
        //            LinqUtility.CopiarAtributos(entity, old);
        //            DataContext.Refresh(System.Data.Linq.RefreshMode.KeepChanges, old);
        //        }
        //        else
        //            throw exception;
        //    }
        //    try
        //    {
        //        DataContext.SubmitChanges();
        //    }
        //    catch (ChangeConflictException changeConflictException)
        //    {
        //        foreach (ObjectChangeConflict occ in DataContext.ChangeConflicts)
        //            occ.Resolve(RefreshMode.KeepCurrentValues);
        //    }
        //    catch (Exception exception2)
        //    {
        //        ReloadContext();
        //        throw exception2;
        //    }
        //}
        public virtual void Update(List<TEntity> entities)
        {
            foreach (TEntity entity in entities)
                Update(entity);
        }
        /// <summary>
        /// Elimina una Entidad
        /// </summary>
        public virtual void Delete(TEntity entity)
        {
            try
            {
                Table.DeleteOnSubmit(entity);
                Singletons.COUNT_CHANGES += 1;
                DataContext.SubmitChanges();
            }
            catch (ChangeConflictException changeConflictException)
            {
                foreach (ObjectChangeConflict occ in DataContext.ChangeConflicts)
                    occ.Resolve(RefreshMode.KeepCurrentValues);
                if (Singletons.COUNT_CHANGES > 0)
                    Singletons.COUNT_CHANGES -= 1;
            }
            catch (Exception exception2)
            {
                ReloadContext();
                if (Singletons.COUNT_CHANGES > 0)
                    Singletons.COUNT_CHANGES -= 1;
                throw exception2;
            }
        }
        /// <summary>
        /// Elimina un Listado de Entidades
        /// </summary>
        public virtual void Delete(List<TEntity> entities)
        {
            try
            {
                Table.DeleteAllOnSubmit(entities);
                ChangeSet changes = DataContext.GetChangeSet();
                if (changes.Deletes.Count > 0)
                    Singletons.COUNT_CHANGES += 1;
                DataContext.SubmitChanges();
            }
            catch (ChangeConflictException changeConflictException)
            {
                foreach (ObjectChangeConflict occ in DataContext.ChangeConflicts)
                    occ.Resolve(RefreshMode.KeepCurrentValues);
                if (Singletons.COUNT_CHANGES > 0)
                    Singletons.COUNT_CHANGES -= 1;
            }
            catch (Exception exception2)
            {
                ReloadContext();
                if (Singletons.COUNT_CHANGES > 0)
                    Singletons.COUNT_CHANGES -= 1;
                throw exception2;
            }
        }
        public virtual void Delete(TFilter filter)
        {
            Delete(GetList(filter));
        }
        public virtual void Delete(TIdType id)
        {
            Delete(GetById(id));
        }
        public virtual void Delete(TIdType[] ids)
        {
            foreach (TIdType id in ids)
                Delete(GetById(id));
        }
        public abstract TEntity Copy(TEntity entity);
        public virtual TIdType CopyAndSave(TEntity entity, string renameFormat)
        {
            TEntity newEntity = Copy(entity);
            Add(newEntity);
            return GetId(newEntity);
        }
        #endregion
        #endregion
    }
}